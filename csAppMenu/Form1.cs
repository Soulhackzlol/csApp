using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;
using CSGSI;
using CSGSI.Nodes;
using OpenRGB.NET;
using System.Net;

namespace csAppMenu
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            // set theme
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            pictureBox1.BackColor = System.Drawing.Color.FromArgb(255, _menuColor.R, _menuColor.G, _menuColor.B);
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(255, _CTColor.R, _CTColor.G, _CTColor.B); ;
            pictureBox3.BackColor = System.Drawing.Color.FromArgb(255, _TColor.R, _TColor.G, _TColor.B); ;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Soulhackzlol/csApp");

        }

        // app code
        // RGB controller client
        private static OpenRgbClient? _rgbClient;

        // Colors
        private static OpenRGB.NET.Color _menuColor = new OpenRGB.NET.Color(255, 255, 255);
        private static OpenRGB.NET.Color _CTColor = new OpenRGB.NET.Color(0, 130, 255);
        private static OpenRGB.NET.Color _TColor = new OpenRGB.NET.Color(255, 130, 0);

        // Available devices
        private static Device[]? _devices;

        // Selected device index (-1 for all devices)
        private static int _selectedDeviceIndex = -1;

        // Bomb-related variables
        private static DateTime? _bombPlantedTime = null;
        private static double _bombCountdown = 39;
        private static bool _canDefuse = false;
        private static bool _updateRequired = true;
        private static string _bombText = "bomb status";

        // Timer for bomb countdown
        private static System.Timers.Timer _bombTimer = new System.Timers.Timer(1000);

        // Cant really explain this var lol
        private static int _count = 0;

        // Game state listener
        private static GameStateListener? _gameStateListener;

        private void RemoveConnection()
        {
            _rgbClient?.Dispose();

            try
            {
                _gameStateListener.Stop();
            }
            catch (HttpListenerException e)
            {

            }
            connected = false;
            materialRaisedButton2.Text = "Connect";
            status_label.ForeColor = System.Drawing.Color.White;
            status_label.Text = "not connected!";
        }

        private void StartThread()
        {
            try
            {
                _rgbClient = new OpenRgbClient();
                _rgbClient.Connect();

                connected = true;
                _devices = _rgbClient.GetAllControllerData();
                materialRaisedButton2.Text = "Disconnect";
                int selection = -1;
                int maxSelection = _devices.Count() - 1;
                bool done = false;


                // TODO: ADD Device Selection, rn i just select all devices.
                /* while (!done)
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
                 }*/

                _selectedDeviceIndex = -1;

                _gameStateListener = new GameStateListener(3000);
                _gameStateListener.NewGameState += OnNewGameState;
                _gameStateListener.EnableRaisingIntricateEvents = true;
                if (!_gameStateListener.Start())
                {
                    Environment.Exit(0);
                }
                status_label.ForeColor = System.Drawing.Color.Blue;
                status_label.Text = "Listening... (waiting for csgo)";
            }
            catch (Exception ex)
            {
                status_label.ForeColor = System.Drawing.Color.Red;
                status_label.Text = "Error!";
                connected = false;
                materialRaisedButton2.Text = "Connect";
            }
        }

        public void daTimer(PlayerNode player)
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
                        _bombText = "The bomb is " + color + " and has " + timeLeft + " seconds left.";
                        Console.ResetColor();
                    }
                }
            };
            _bombTimer.Start();
        }

        private void OnNewGameState(GameState gs)
        {

            if (!connected)
                return;

            // Extract data from game state
            PlayerNode player = gs.Player;
            RoundNode round = gs.Round;
            MapNode map = gs.Map;

            status_label.ForeColor = System.Drawing.Color.Green;
            status_label.Text = "Connected!";

            // Set data to the grid
            dataGridView1.AutoGenerateColumns = true;

            // Agregar una nueva fila con los datos del objeto GameState
            // Crear columnas si aún no existen
            if (dataGridView1.Columns.Count == 0)
            {
                // Agregar columnas para cada propiedad que quieres mostrar
                dataGridView1.Columns.Add("Map", "Map");
                dataGridView1.Columns.Add("CT", "CT");
                dataGridView1.Columns.Add("T", "T");
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Health", "Health");
                dataGridView1.Columns.Add("Team", "Team");
            }

            dataGridView1.Rows.Clear();

            // Agregar fila con datos
            dataGridView1.Rows.Add(map.Name, map.TeamCT.Score, map.TeamT.Score, player.Name, player.State.Health, player.Team);

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
                    _bombText = "Bomb Planted! ";
                    _bombPlantedTime = DateTime.Now;
                    _updateRequired = false;
                }
                else if (round.Bomb == BombState.Exploded || round.Bomb == BombState.Defused)
                {
                    _bombPlantedTime = null;
                    _updateRequired = true;
                }
            }
            else if (round.Phase == RoundPhase.FreezeTime)
            {
                if (gs.Previously.Round.Bomb == BombState.Exploded || gs.Previously.Round.Bomb == BombState.Defused)
                {
                    _bombText = $"Bomb has been {gs.Previously.Round.Bomb.ToString().ToLower()}.";
                }
                else
                {
                    _bombText = "bomb status";
                }
                _bombPlantedTime = null;
                _updateRequired = true;
                _count = 0;
            }

            // Start bomb timer if bomb is planted
            if (_bombPlantedTime != null && _count == 0)
            {
                textUpd.Start();
                daTimer(player);
                _count += 1;
            }
            else if (_bombPlantedTime == null)
            {
                textUpd.Stop();

                // Set device color as team
                if (player.Team.ToString() == "T")
                {
                    SetDeviceColor(_TColor.R, _TColor.G, _TColor.B);
                }
                else if (player.Team.ToString() == "CT")
                {
                    SetDeviceColor(_CTColor.R, _CTColor.G, _CTColor.B);
                }
                else
                {
                    SetDeviceColor(_menuColor.R, _menuColor.G, _menuColor.B);
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
                    var colors = new OpenRGB.NET.Color[device.Colors.Length];
                    for (var i = 0; i < colors.Length; i++)
                        colors[i] = new OpenRGB.NET.Color(r, g, b);
                    _rgbClient.UpdateLeds(device.Index, colors);
                }
            }
            else
            {
                var colors = new OpenRGB.NET.Color[devices[_selectedDeviceIndex].Colors.Length];
                for (var i = 0; i < colors.Length; i++)
                    colors[i] = new OpenRGB.NET.Color(r, g, b);
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
        bool connected = false;

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (!connected)
                StartThread();
            else
                RemoveConnection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = MyDialog.Color;
                _menuColor = new OpenRGB.NET.Color(MyDialog.Color.R, MyDialog.Color.G, MyDialog.Color.B);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = MyDialog.Color;
                _CTColor = new OpenRGB.NET.Color(MyDialog.Color.R, MyDialog.Color.G, MyDialog.Color.B);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.BackColor = MyDialog.Color;
                _TColor = new OpenRGB.NET.Color(MyDialog.Color.R, MyDialog.Color.G, MyDialog.Color.B);
            }
        }

        private void textUpd_Tick(object sender, EventArgs e)
        {
            bomb_status.Text = _bombText;
        }
    }
}