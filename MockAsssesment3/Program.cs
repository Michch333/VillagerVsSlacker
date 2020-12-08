using System;
using System.Collections.Generic;

namespace MockAsssesment3
{
    class Program
    {
        static void Main(string[] args)
        {
            var TheresasTown = new Town();
            Console.WriteLine(TheresasTown.SurviveTheWinter());

        }
    }

    public abstract class Villager
    {
        public int Hunger { get; set; }
        public virtual int Farm()
        {
            return -1;
        }

    }
    public class Slacker : Villager
    {
        public Slacker()
        {
            Hunger = 3;
        }
        public override int Farm()
        {
            return 0;
        }
    }
    public class Farmer : Villager
    {
        public Farmer()
        {
            Hunger = 1;
        }
        public override int Farm()
        {
            return 2;
        }
    }
    public class Town
    {
        public List<Villager> Villagers { get; set; } // Property - things that DESCRIBE what the object looks
        public Town()
        {
            var listOfVillagers = new List<Villager>();

            listOfVillagers.Add(new Farmer());
            listOfVillagers.Add(new Slacker());
            listOfVillagers.Add(new Slacker());
            listOfVillagers.Add(new Slacker());

            Villagers = listOfVillagers;
        }
        public int Harvest()
        {
            var total = 0;
            foreach (Villager dude in Villagers) // Go thru the ENTIRE village
            {
                total = total + dude.Farm(); // Tell each 'villager' to Farm
            }
            return total;
        }
        public int CalcFoodConsumption()
        {
            var total = 0;
            foreach (var villager in Villagers)
            {
                total = total + villager.Hunger;
            }
            return total;
        }
        public bool SurviveTheWinter()
        {
            var resultOne = Harvest();
            var resultTwo = CalcFoodConsumption();
            if (resultTwo <= resultOne)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
