using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JournalApp
{
    class Journal
    {
        private string JournalFile = "MyJournal.txt";
        private string TitleArt = 
@"(\ 
\'\ 
\'\     __________  
/ '|   ()_________)
\ '/    \ ~~~~~~~~ \
\       \ ~~~~~~   \
==).      \__________\
(__)       ()__________)";
        public void Run()
        {
            Title = "Journal App";
            DisplayIntro();
            CreateJournalFile();
            RunMenu();
            DisplayOutro();
        }
        private void RunMenu()
        {
            string choice;
            do
            {
                choice = GetChoice();
                switch (choice)
                {
                    case "1":
                        DisplayJournalContents();
                        break;
                    case "2":
                        ClearFile();
                        break;
                    case "3":
                        AddEntry();
                        break;
                    default:
                        break;
                }
            } while (choice != "4");
            
        }
        private string GetChoice()
        {
            bool isChoiceValid = false;
            string choice = "";
            do
            {
                Clear();
                ForegroundColor = ConsoleColor.DarkGray;
                WriteLine(TitleArt);
                ForegroundColor = ConsoleColor.Black;
                WriteLine("\nWhat would you like to do?");
                WriteLine(" > 1 - Read the journal.");
                WriteLine(" > 2 - Clear the journal.");
                WriteLine(" > 3 - Add to the journal.");
                WriteLine(" > 4 - Quit.");
                ForegroundColor = ConsoleColor.DarkBlue;
                choice = ReadLine().Trim();
                ForegroundColor = ConsoleColor.Black;
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    isChoiceValid = true;
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"\"{choice}\" is not a valid option. Please choose 1...4.");
                    WaitForKey();
                }
            } while (!isChoiceValid);
            return choice;
        }
        private void CreateJournalFile()
        {
            if (!File.Exists(JournalFile))
            {
                File.CreateText(JournalFile);
            }
        }
        private void DisplayIntro()
        {
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            Clear();
            WriteLine(TitleArt);
            WriteLine("\nWelcome to the only journaling app you`ll ever need!");
            WaitForKey();
        }
        private void DisplayOutro()
        {
            ForegroundColor = ConsoleColor.Black;
            WriteLine("\nArt from: https://www.asciiart.eu/books/books");
            WriteLine("Thanks for using the journal!");
            WaitForKey();
        }
        private void WaitForKey()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("Press any key...");
            ReadKey(true);
        }
        private void DisplayJournalContents()
        {
            ForegroundColor = ConsoleColor.DarkMagenta;
            string journalText = File.ReadAllText(JournalFile);
            WriteLine("\n=== Journal Contents ===");
            WriteLine(journalText);
            WriteLine("\n========================");
            WaitForKey();
        }
        private void ClearFile()
        {
            ForegroundColor = ConsoleColor.Black;
            File.WriteAllText(JournalFile, "");
            WriteLine("Journal cleared!");
            WaitForKey();
        }
        private void AddEntry()
        {
            ForegroundColor = ConsoleColor.Black;
            WriteLine("\nWhat you would like to add? (Type EXIT and press enter to stop.)");
            ForegroundColor = ConsoleColor.DarkMagenta;
            
            string newEntry = string.Empty;
            bool shouldContinue = true;
            while (shouldContinue)
            {
                string line = ReadLine();
                if(line.ToLower().Trim() == "exit")
                {
                    shouldContinue = false;
                }
                else
                {
                    newEntry += line + "\n";
                }
            }
            string newLine = ReadLine();
            File.AppendAllText(JournalFile, $"\nEntry:\n{newEntry}\n");
            ForegroundColor = ConsoleColor.Black;
            WriteLine("The journal has been modified.");
            WaitForKey();
        }
    }
}
