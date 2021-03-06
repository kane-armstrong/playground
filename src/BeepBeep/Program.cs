﻿using BeepBeep.Sheets;
using System;
using System.Collections.Generic;

namespace BeepBeep
{
    internal class Program
    {
        private static readonly Dictionary<string, string> Sheets = new Dictionary<string, string>
        {
            {"1", "super_mario.json"},
            {"2", "imperial_march.json"},
            {"3", "tetris.json"},
        };

        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Pick a song: ");
                Console.WriteLine("1. Super Mario");
                Console.WriteLine("2. Imperial March");
                Console.WriteLine("3. Tetris");
                Console.WriteLine("q. quit");
                Console.Write("Selection: ");

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid selection!");
                    continue;
                }

                if (input.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                if (!Sheets.ContainsKey(input))
                {
                    Console.WriteLine("Invalid selection!");
                    continue;
                }

                try
                {
                    var sheet = SheetFile.Load(Sheets[input]);
                    Console.Write($"Now playing: {sheet.Name} ... ");
                    sheet.Play();
                    Console.WriteLine("done!");
                }
                catch (Exception)
                {
                    Console.WriteLine("oops :(");
                    Console.WriteLine("An error occurred while playing your selection. Looks like that songs busted!");
                }
            }
        }
    }
}