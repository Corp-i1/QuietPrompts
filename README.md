# Win-Labs
### My Website: [Corpi1.uk](https://Corpi1.uk)
This project is my popup window alternative with customisability (no more dinging!).

## Installation
To install please head to the latest relase [here](https://github.com/Corp-i1/QuietPrompts/releases).

## Building

If you want to build the project yourself, you can do so by following these steps:

1. Install [Visual Studio](https://visualstudio.microsoft.com/) (Community Edition works plenty fine)
    - When installing, make sure to select the **.NET desktop development** workload as this installs the required components for building WPF applications.
1. Clone the [``master``](https://github.com/Corp-i1/Win-Labs/tree/master) branch repository to your local machine using Git (can be done in Visual Studio if you want) or download it as a ZIP file.
1. Open the folder in Visual Studio as a new project.
1. Build the project by selecting **Build > Build Solution** from the menu or pressing `Ctrl + Shift + B`
    - This should install all the required dependencies and build the project if it doesn't manual install the following as NuGet packages:
    - This can be done manually if necessary by right clicking on the project in the Solution Explorer and selecting **Manage NuGet Packages**. Then search for the package name and click **Install**.
1. One the build completes you can run it in two ways:
    1. Run from Visual Studio by selecting **Debug > Start Debugging** from the menu or pressing `F5`
    1. Run the built executable from `\"The folder in visual studio"\bin\Debug\net8.0-windows7.0` (replace "The folder in visual studio" with the path to the folder you opened in Visual Studio).
        - If you built a release version the path is the same as above but replace `Debug` with `Release`.

## License  
This project is licensed under the **MPL-2.0 with a No Resale Clause**.  

You are free to use, modify, and distribute the software. **Businesses and individuals can use it**, including in commercial activities. However, **you may not sell, repackage, or monetize the software itself**.  

See the [LICENSE](LICENSE.md) file for full terms.  
 
