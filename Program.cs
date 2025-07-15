using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager;

namespace TaskManager
{
    // This class represents a chore with a unique identifier and a description. //
    public class chore
    {
        public int IDictionary { get; set; } // Unique identifier for the chore //
        public string Description { get; set; } // Description of the chore //
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // This is a simple console application that serves as a task manager.
            // It currently does not implement any functionality but serves as a starting point.
            Console.WriteLine("Welcome to the Task Manager Console Application!");
            Console.WriteLine("This application is designed to ensure that Mr and Mrs Scat keep on top of the house chores, as we are busy people with a new baby and sometimes forget.");
            Console.WriteLine("Press any key to get today's tasks...");
            Console.WriteLine("Please keep in mind that we don't do chores on Saturday or Sunday as we are often busy/away.");
            Console.ReadKey();

            // The following lines identify the chores for each day of the week, which will be assigned at random to either myself or my wife. We have excluded cooking and our clothes wash as //
            // those chores are already split between us, and Lucy cannot cook to save her life... I also put a wash on and immediately forget about it...//
            // The chores will always be split evenly, but at random, so you could get a hot streak of avoiding doing the bathrooms for months, if you're lucky! //

            var dailyChoresList = new Dictionary<string, List<chore>>
            {
                { "Monday", new List<chore>
                    {
                        new chore { IDictionary = 1, Description = "Hoover the house" },
                        new chore { IDictionary = 2, Description = "Bathe Minnie" },
                        new chore { IDictionary = 3, Description = "Clean the kitchen" },
                        new chore { IDictionary = 4, Description = "Noah Wash" },
                        new chore { IDictionary = 5, Description = "Bottle Wash" },
                        new chore { IDictionary = 6, Description = "Take out the bin" }
                    }
                },
                { "Tuesday", new List<chore>
                    {
                        new chore { IDictionary = 1, Description = "Clean the kitchen" },
                        new chore { IDictionary = 2, Description = "Dust the surfaces" },
                        new chore { IDictionary = 3, Description = "Weekly Foodshop" },
                        new chore { IDictionary = 4, Description = "Bottle Wash" },
                        new chore { IDictionary = 5, Description = "Noah Wash" },
                        new chore { IDictionary = 6, Description = "Take out the bin" }
                    }
                },
                { "Wednesday", new List<chore>
                    {
                        new chore { IDictionary = 1, Description = "Clean the kitchen" },
                        new chore { IDictionary = 2, Description = "Noah Wash" },
                        new chore { IDictionary = 3, Description = "Bottle Wash" },
                        new chore { IDictionary = 4, Description = "Clean the bathrooms" },
                        new chore { IDictionary = 5, Description = "Take out the bin" }
                    }
                },
                { "Thursday", new List<chore>
                    {
                        new chore { IDictionary = 1, Description = "Clean the kitchen" },
                        new chore { IDictionary = 2, Description = "Noah Wash" },
                        new chore { IDictionary = 3, Description = "Bottle Wash" },
                        new chore { IDictionary = 4, Description = "Take out the bin" }
                    }
                },
                { "Friday", new List<chore>
                    {
                        new chore { IDictionary = 1, Description = "Clean the kitchen" },
                        new chore { IDictionary = 2, Description = "Noah Wash" },
                        new chore { IDictionary = 3, Description = "Bottle Wash" },
                        new chore { IDictionary = 4, Description = "Take out the bin" }
                    }
                }
            };

            string[] people = { "Andy", "Lucy" };
            Random random = new Random();

            // Assign chores randomly to Andy or Lucy //
            foreach (var day in dailyChoresList)
            {
                Console.WriteLine($"\n{day.Key}:");

                //Randomly assign chores to Andy or Lucy but make sure they are split evenly or she will hunt me down and kill me!//
                int andyCount = 0;
                int lucyCount = 0;

                // Shuffle chores so assignment feels random
                var shuffledChores = day.Value.OrderBy(c => random.Next()).ToList();

                for (int i = 0; i < shuffledChores.Count; i++)
                {
                    string assignedTo;

                    if (andyCount <= lucyCount)
                    {
                        assignedTo = "Andy";
                        andyCount++;
                    }
                    else
                    {
                        assignedTo = "Lucy";
                        lucyCount++;
                    }

                    Console.WriteLine($"- {shuffledChores[i].Description} (Assigned to: {assignedTo})");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}