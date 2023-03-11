# CS:GO App (dont know how to call this so...)
This is a simple application that listens for changes in a game of Counter-Strike: Global Offensive (CS:GO) and changes the RGB lighting of OpenRGB-compatible devices accordingly.

![pic1](https://user-images.githubusercontent.com/52952716/224498884-cf5cf964-d2ee-49cc-afe3-69faa4ffcc97.png)

![pic2](https://user-images.githubusercontent.com/52952716/224498919-b617e468-88c2-4536-b00a-5f5adef21a1b.png)

![pic3](https://user-images.githubusercontent.com/52952716/224498937-49d121f0-2793-4336-8750-a5cc80f3992a.png)

![pic4](https://user-images.githubusercontent.com/52952716/224498951-0eed7449-d983-4f2d-b1c3-3f2f1a3718de.png)

# Requirements
- .NET 6.0 runtime
- OpenRGB running with SDK server enabled
- Json.NET - Newtonsoft

# Usage
- Make sure OpenRGB is running with the SDK server enabled. To do this, open the OpenRGB app and go to "SDK Server", start it and you should be good to go! 

- Clone or download the repository.

- Build the project.

- Run the application.

- Select the device you want to control from the list of available devices using the arrow keys and press "Enter" to confirm your selection.

- The application will now start listening for changes in CS:GO. When a bomb is planted, the RGB lighting of the selected device(s) will change to reflect the bomb's timer.

# Acknowledgements
## This application makes use of the following libraries:

- CSGSI, a library for parsing CS:GO's Game State Integration (GSI) JSON data.
- OpenRGB.NET, a .NET wrapper for the OpenRGB SDK.

**A big thank you to the creators and maintainers of these libraries!**

# Explanation
The application works by subscribing to CS:GO's Game State Integration (GSI) and parsing the JSON data using the CSGSI library. When a bomb is planted, the application starts a timer and changes the RGB lighting of the selected device(s) to reflect the bomb's timer. The bomb timer changes color as it ticks down, starting from green and ending in red. If the bomb is defused or explodes, the RGB lighting returns to its original state.

# Troubleshooting
- If the application is not working, make sure that OpenRGB is running with the SDK server enabled. If the server is not enabled, enable it and restart OpenRGB.

- If the application is still not working, make sure that you have the required dependencies installed (see "Requirements" above).

- If you encounter any other issues, please feel free to open an issue in this repository.

# Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

# License
This project is licensed under the MIT License - see the LICENSE file for details.
