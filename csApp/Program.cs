using CSGSI;
using CSGSI.Nodes;
using OpenRGB.NET;

namespace csApp
{
    internal class Program
    {
        // RGB controller client
        private static OpenRgbClient? _rgbClient;

        // Available devices
        private static Device[]? _devices;

        // Selected device index (-1 for all devices)
        private static int _selectedDeviceIndex = -1;

        // Bomb-related variables
        private static DateTime? _bombPlantedTime = null;
        private static bool _bombExploded = false;
        private static double _bombCountdown = 39;
        private static bool _canDefuse = false;
        private static bool _updateRequired = true;

        // Timer for bomb countdown
        private static System.Timers.Timer _bombTimer = new System.Timers.Timer(1000);

        // Cant really explain this var lol
        private static int _count = 0;

        // Game state listener
        private static GameStateListener? _gameStateListener;

        static void Main(string[] args)
        {
            _rgbClient = new OpenRgbClient();
            _rgbClient.Connect();
            Console.Title = "csApp by s1moscs";
            Console.WriteLine("Connected to OpenRGB");

            _devices = _rgbClient.GetAllControllerData();

            Console.CursorVisible = false;

            int selection = -1;
            int maxSelection = _devices.Count() - 1;
            bool done = false;

            while (!done)
            {
                // Clear the console and reprint the device list
                Console.Clear();
                Console.WriteLine("Select a device to control:\n");

                for (int i = -1; i < _devices.Count(); i++)
                {
                    string deviceName = (i == -1) ? "All devices" : _devices[i].Name;
                    bool isSelected = (i == selection);
                    Console.ForegroundColor = isSelected ? ConsoleColor.DarkYellow : ConsoleColor.Gray;
                    Console.WriteLine(isSelected ? " > {0}" : "   {0}", deviceName);
                    Console.ResetColor();
                }

                // Wait for keyboard input
                var key = Console.ReadKey(true);

                // Update selection based on arrow keys
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selection = (selection == -1) ? maxSelection : selection - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selection = (selection == maxSelection) ? -1 : selection + 1;
                        break;
                    case ConsoleKey.Enter:
                        _selectedDeviceIndex = selection;
                        done = true;
                        break;
                }
            }

            _gameStateListener = new GameStateListener(3000);
            _gameStateListener.NewGameState += OnNewGameState;

            if (!_gameStateListener.Start())
            {
                Environment.Exit(0);
            }

            Console.WriteLine("\nListening...");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| Name         | Health | Weapon                |");
            Console.WriteLine("--------------------------------------------------");
        }

        static void daTimer(PlayerNode player)
        {

            // Add an event handler to update the bomb timer every time the timer ticks
            _bombTimer.Elapsed += (sender, e) => {

                if (_bombPlantedTime != null)
                {
                    TimeSpan timeSincePlanted = DateTime.Now - _bombPlantedTime.Value;
                    int timeLeft = (int)Math.Max(_bombCountdown - timeSincePlanted.TotalSeconds, 0);

                    if (timeLeft == 0)
                    {
                        _bombPlantedTime = null;
                        _bombExploded = false;
                        _updateRequired = true;
                    }
                    else
                    {
                        string color;
                        if (timeLeft >= 11)
                        {
                            SetDeviceColor(0, 255, 50);
                            color = "green";
                            _canDefuse = true;
                        }
                        else if (timeLeft >= 6)
                        {
                            SetDeviceColor(255, 103, 0);
                            color = "orange";
                            _canDefuse = true;
                        }
                        else
                        {
                            SetDeviceColor(255, 25, 0);
                            color = "red";
                            _canDefuse = false;
                        }

                        Console.ForegroundColor = (_canDefuse ? ConsoleColor.Green : ConsoleColor.Red);
                        Console.WriteLine("The bomb is " + color + " and has " + timeLeft + " seconds left.");
                        Console.ResetColor();
                    }
                }
            };
            _bombTimer.Start();
        }

        static void OnNewGameState(GameState gs)
        {
            // Extract data from game state
            PlayerNode player = gs.Player;
            RoundNode round = gs.Round;
            MapNode map = gs.Map;

            // Clear console
            Console.Clear();

            // Display map and score
            Console.WriteLine($"Map: {map.Name}");
            Console.WriteLine($"Mode: {map.Mode}");
            Console.WriteLine($"Score: {map.TeamCT.Score} - {map.TeamT.Score}");
            Console.WriteLine("--------------------------------------------------");

            // Display player info
            Console.WriteLine($"| {player.Name,-12} | {player.State.Health,-6} | {player.Weapons.ActiveWeapon.Name,-20} |");
            Console.WriteLine("--------------------------------------------------");

            // Update bomb info
            if (round.Phase == RoundPhase.Live)
            {
                if (round.Bomb == BombState.Planted && gs.Previously.Round.Bomb != BombState.Planted && _updateRequired)
                {
                    Console.WriteLine("Bomb has been planted.");
                    _bombPlantedTime = DateTime.Now;
                    _updateRequired = false;
                }
                else if (round.Bomb == BombState.Exploded || round.Bomb == BombState.Defused)
                {
                    _bombPlantedTime = null;
                    _bombExploded = gs.Previously.Round.Bomb == BombState.Exploded;
                    _updateRequired = true;
                }
            }
            else if (round.Phase == RoundPhase.FreezeTime)
            {
                if (gs.Previously.Round.Bomb == BombState.Exploded || gs.Previously.Round.Bomb == BombState.Defused)
                {
                    Console.WriteLine($"Bomb has been {gs.Previously.Round.Bomb.ToString().ToLower()}.");
                }
                _bombPlantedTime = null;
                _bombExploded = false;
                _updateRequired = true;
                _count = 0;
            }

            // Start bomb timer if bomb is planted
            if (_bombPlantedTime != null && _count == 0)
            {
                daTimer(player);
                _count += 1;
            }
            else if (_bombPlantedTime == null)
            {
                // Set device color as team
                if (player.Team == "T")
                {
                    SetDeviceColor(255, 130, 0);
                }
                else if (player.Team == "CT")
                {
                    SetDeviceColor(0, 130, 255);
                }
                else
                {
                    SetDeviceColor(255, 255, 255);
                }
            }
        }

        static void SetDeviceColor(byte r, byte g, byte b)
        {
            var devices = GetDevices();

            if (_rgbClient == null)
                return;

            if (_selectedDeviceIndex == -1)
            {
                foreach (var device in devices)
                {
                    var colors = new Color[device.Colors.Length];
                    for (var i = 0; i < colors.Length; i++)
                        colors[i] = new Color(r, g, b);
                    _rgbClient.UpdateLeds(device.Index, colors);
                }
            }
            else
            {
                var colors = new Color[devices[_selectedDeviceIndex].Colors.Length];
               for (var i = 0; i < colors.Length; i++)
                        colors[i] = new Color(r, g, b);
                _rgbClient.UpdateLeds(devices[_selectedDeviceIndex].Index, colors);
            }
        }


        // function to access the devices variable from anywhere in your code
        public static Device[] GetDevices()
        {
            if (_devices == null)
                return new Device[0];

            return _devices;
        }
    }
}