using System;
using System.Collections.Generic;
using System.IO;

namespace EUCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("What voting style do you want to use?");
            Console.WriteLine("1 : Qualified majority");
            Console.WriteLine("2 : Reinforced qualified majority");
            Console.WriteLine("3 : Simple majority");
            Console.WriteLine("4 : Unanimity");
            int votingRule = Convert.ToInt16(Console.ReadLine());

            List<Country> list = new List<Country>();

            string[] info = File.ReadAllLines("Countries.txt");
            for(int i = 0; i < info.Length; i++)
            {
                string[] extract = info[i].Split(',');
                Country countryInfo = new Country(extract[0], Convert.ToDouble(extract[1]));
                list.Add(countryInfo);
            }

            while (true) 
            {
                Vote vote = new Vote(list);
                Console.WriteLine("Calculator");
                for (int i = 0; i < vote.Countries.Count; i++)
                {
                    Console.WriteLine(i + " : " + vote.Countries[i].CountryName + " : " +
                        vote.Countries[i].Percentage + "% : " + (Vote.Choices)vote.Countries[i].Vote);

                }

                Console.WriteLine("Country you're changing a vote for: ");
                int integerChoice = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Please Vote Using Y = Yes, N = No, A = Abstain, and NP = Not Participating");
                var choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "Y":
                        Console.WriteLine("Yes");
                        list[integerChoice].Vote = (int)Vote.Choices.Yes;
                        break;
                    case "N":
                        Console.WriteLine("No");
                        list[integerChoice].Vote = (int)Vote.Choices.No;
                        break;
                    case "A":
                        Console.WriteLine("Abstain");
                        list[integerChoice].Vote = (int)Vote.Choices.Abstain;
                        break;
                    case "NP":
                        Console.WriteLine("Not Participating");
                        list[integerChoice].Vote = (int)Vote.Choices.NonParticipation;
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
                if (votingRule == 1)
                {
                    Console.WriteLine("Percentage yes votes: " + Math.Round(vote.Population(), 0) + "%");
                    Console.WriteLine("Qualified Majority: " + vote.QualifiedMajority());
                }
                if (votingRule == 2)
                {
                    Console.WriteLine("Percentage yes votes: " + Math.Round(vote.Population(), 0) + "%");
                    Console.WriteLine("Reinforced Qualified Majority: " + vote.reinforcedQualifiedMajority());
                }
                if (votingRule == 3)
                {
                    Console.WriteLine("Percentage yes votes: " + Math.Round(vote.Population(), 0) + "%");
                    Console.WriteLine("Simple Majority: " + vote.simpleMajority());
                }
                if (votingRule == 4)
                {
                    Console.WriteLine("Percentage yes votes: " + Math.Round(vote.Population(), 0) + "%");
                    Console.WriteLine("Unanimity: " + vote.unanimity());
                }
            } 


        }
    }
}
