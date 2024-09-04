using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typingSpeedCalc
{
    public class typer
    {
        public static void Main()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is a wpm calculator,you should type every character correctly.\nThe program ensures that you can type the letter correctly.\n{There is no use of backspace,you cant type the next character untill you get the current character correct}");
            Console.WriteLine();
            Console.WriteLine();
            string[] wordsList = {
            "abandon", "ability", "about", "above", "absent", "accident", "achieve", "across", "action", "actor",
            "adapt", "adjust", "affect", "afford", "agree", "almost", "alone", "amazing", "anger", "animal",
            "announce", "answer", "arrive", "assist", "attack", "attend", "believe", "benefit", "border", "borrow",
            "bottle", "brave", "broken", "budget", "cable", "camera", "cancer", "cancel", "career", "carry",
            "catch", "change", "charge", "check", "choose", "circle", "citizen", "climate", "command", "company",
            "compare", "consider", "control", "cookie", "palestine","create", "credit", "current", "damage", "debate", "decide",
            "define", "deliver", "demand", "dentist", "detail", "doctor", "double", "dream", "drive", "duty",
            "enable", "enjoy", "equal", "escape", "event", "expect", "explain", "failure", "fancy", "fashion",
            "figure", "finish", "focus", "follow", "forget", "friend", "future", "garden", "gentle", "global",
            "greet", "ground", "group", "handle","palestine", "health", "zeyad","honor", "hotel", "impact", "indoor", "invest",
            "issue", "judge", "light", "major", "manage","palestine", "method", "modern", "model", "month", "nature",
            "nurse", "ocean", "office", "order", "outcome", "owner", "peace", "perform", "planet", "player",
            "policy", "power", "prefer", "profit", "program", "public", "queen", "question", "rapid", "result",
            "review", "rocket", "safety", "sample", "search", "season", "series", "shout", "signal", "simple",
            "system", "travel", "treat", "unique", "update", "usual", "vision", "weapon", "weight", "worry",
            "writer", "yellow", "year", "youth", "zero", "accuse", "achieve", "admire", "advice", "agency",
            "ancient", "artist", "attach", "balance", "bargain", "basic", "beach", "benefit", "billion",
            "blanket", "border", "break", "bright", "build", "button", "camera", "captain", "cartoon", "center",
            "chance", "choice", "clever", "climb", "collect", "comfort", "content", "culture", "danger", "dealer",
            "desire", "device", "doctor", "effect", "effort", "enemy", "enable", "example", "factory", "famous",
            "friend", "general", "guest", "handle", "hobby", "impact", "income", "ladder", "library", "method",
            "mutual", "nature", "normal", "option", "outlet", "player", "private", "purpose", "reader", "rocket",
            "search", "social", "speech", "supply", "target", "thing", "timely", "travel", "unique", "volume",
            "weekend", "winter"
        };
            int newRound = 1, rounds = 1, maxWPM = 0;
            while(newRound == 1)
            {
                Random rnd = new Random();
                Console.ForegroundColor = originalColor;

                int start = rnd.Next(10, 36), plus = rnd.Next(5, 15);
                List<string> words = new List<string>();
                int dec = 1;
                for (int j = start; j < (start + plus); j++)
                {
                    words.Add(wordsList[j]);
                    words.Add(wordsList[wordsList.Length - dec]);
                    dec++;
                }
                string sentence = string.Join(' ', words);
                int totalKeys = 0;
                Console.WriteLine($"Round {rounds}");
                Console.WriteLine("Start Typing: ");
                Console.Write("{");
                foreach (string word in words)
                {
                    Console.Write($"{word} ");
                    totalKeys += word.Length;
                }
                Console.Write("}");
                Console.WriteLine();
                int kps = 0, cKps = 0;

                var exludedKeys = new HashSet<ConsoleKey>() { //creating a set of excluded keys to enhance readability
                ConsoleKey.Tab,
                ConsoleKey.Backspace,
                ConsoleKey.Enter,
            };
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Type Here -> ");
                Console.ForegroundColor = originalColor;
                Stopwatch sw = null; int fl = 0, i = 0;
                while (true)
                {
                    var keyInfo = Console.ReadKey(intercept: true);

                    if (!exludedKeys.Contains(keyInfo.Key))
                    {
                        kps++;
                        if (fl != 1) sw = Stopwatch.StartNew(); //started the timer
                        fl = 1;

                        if (sentence[i].ToString().Equals(keyInfo.KeyChar.ToString().ToLower()))
                        {
                            cKps++; i++;
                            Console.Write(keyInfo.KeyChar.ToString().ToLower());
                        }
                    }

                    if (i == sentence.Length) break;
                }
                sw.Stop();
                Console.WriteLine();
                double mins = sw.Elapsed.TotalMinutes;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Round ended, new score: {Math.Max(maxWPM, (int)((cKps / 5) / mins))} words per minute");
                Console.ForegroundColor = originalColor;
                Console.WriteLine("Press Enter to continue");
                Console.ReadKey();
                Console.Write("Type {1} for a new round, type any number (other than 1) if you want to stop: ");
                Console.WriteLine();
                newRound = int.Parse( Console.ReadLine() );
                rounds++;
                Console.ReadLine();
            }
        }
    }
}

