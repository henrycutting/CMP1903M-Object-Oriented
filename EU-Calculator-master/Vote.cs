using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EUCalculator
{
    class Vote
    {
        private List<Country> countries;
        public IEnumerable<Country> voteY;
        public List<Country> Countries
        {
            get => countries;
            set
            {
                countries = value;
                voteY = from countries in Countries
                        where countries.Vote == 0
                        select countries;


            }
        }
        public Vote(List<Country> countries) => Countries = countries;

        public enum Choices 
        {

            Yes, No, Abstain, NonParticipation

        }

        public double Population()
        {
            double populationY = 0;
            for (int i = 0; i < voteY.Count(); i++)
            {
                populationY += voteY.ElementAt(i).Percentage;

            }
            return populationY;
        }

        public bool QualifiedMajority()
        {
            double populationY = 0;
            for (int i = 0; i < voteY.Count(); i++)
            {
                populationY += voteY.ElementAt(i).Percentage;

            }
            if (voteY.Count() > 0.55 * Countries.Count && populationY > 65)
            {
                return true;

            }
            return false;
        }

        public bool reinforcedQualifiedMajority()
        {
            double populationY = 0;
            for(int i = 0; i < voteY.Count(); i++)
            {
                populationY += voteY.ElementAt(i).Percentage;
            }
            if (voteY.Count() > 0.72 * Countries.Count && populationY > 65)
            {
                return true;
            }
            return false;
        }

        public bool simpleMajority()
        {
            double populationY = 0;
            for (int i = 0; i < voteY.Count(); i++)
            {
                populationY += voteY.ElementAt(i).Percentage;
            }
            if (voteY.Count() > 0.5 * Countries.Count)
            {
                return true;
            }
            return false;
        }

        public bool unanimity()
        {
            if (voteY.Count() == Countries.Count)
            {
                return true;
            }
            return false;
        }
    }
}
