using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Password = { "books", "asile", "self", "password", "font", "borrow" };
    string[] level2Password = { "prisoner", "handcuffs", "holster", "uniform", "arrest", "bullet" };
    string[] level3Password = { "starfield", "astronut", "meteoroids", "environment", "asteroid", "comets " };

    //Game State
    int level;
    enum Screen { MainMenu, Password, Win}
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    //Show Main Menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the local police station");
        Terminal.WriteLine("Press 3 for the NASA");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "Menu" || input == "menu") //We can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "Exit" || input == "Close" || input == "Quit")
        {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") //Easter egg
        {
            Terminal.WriteLine("Welcome! James Bond!");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level!");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Password[Random.Range(0, level1Password.Length)];
                break;
            case 2:
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;
            case 3:
                password = level3Password[Random.Range(0, level3Password.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Reached.");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a Book..");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/

");
                break;
            case 2:
                Terminal.WriteLine("You got a prisoner key..");
                Terminal.WriteLine(@"
  8 8          ,o. 
 d8o8azzzzzzzzd   b
               `o'");
                break;
            case 3:
                Terminal.WriteLine("Welcome to NASA's internal system!");
                Terminal.WriteLine(@"
        _..._
      .'     '.      _
     /    .-""-\   _/ \
   .-|   /:.   |  |   |
   |  \  |:.   /.-'-./
   | .-'-;:__.'    =/
   .'=  *=|NASA _.='
  /   _.  |    ;
 ;-.-'|    \   |
/   | \    _\  _\
\__/'._;.  ==' ==\
         \    \   |
         /    /   /
         /-._/-._/
        \   `\  \
          `-._/._/
");
                break;
            default:
                Debug.LogError("Invalid Level Reached.");
                break;
        }
    }

    private void Update()
    {
        int index = Random.Range(0, level1Password.Length);
        print(index);
    }
}
