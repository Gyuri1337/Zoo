using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoorychlovka
{
    public enum Gender
    {
        Male,
        Female
    }
    class Program
    {
        public class Animal
        {
            public Animal(int Born, int ExpectedYearLive, int ID, int Eats) {
                this.Born = Born;
                this.ExpectedYearsLive = ExpectedYearLive;
                this.ID = ID;
                this.IsDead = false;
                this.Eats = Eats;
            }
            public int Eats;
            public int Born;
            public int ExpectedYearsLive;
            public bool IsDead;
            public int ID;
            public void Die()
            {
                this.IsDead = true;
            }
            
        }
        public class Tiger : Animal
        {
            public Tiger(int Born, int ExpectedYearLive,int ID, int Eats) : base(Born, ExpectedYearLive, ID, Eats) { }
            

        }
        public class Cat : Animal
        {
            public Cat(int Born, int ExpectedYearLive, int ID, int Eats) : base(Born, ExpectedYearLive, ID, Eats) { }


        }
        public class Dog : Animal
        {
            public Dog(int Born, int ExpectedYearLive,int ID, int Eats) : base(Born, ExpectedYearLive, ID, Eats) { }


        }
        public class Turtle : Animal
        {
            public Turtle(int Born, int ExpectedYearLive, int ID, int Eats) : base(Born, ExpectedYearLive, ID, Eats) { }


        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("How many FOOD? (kg)");
            int Food = int.Parse(Console.ReadLine());
            List<Animal> ZOO = new List<Animal>();
            int Tigers = 10;
            int Turtles = 12;
            int Dogs = 6;
            int Cat = 4;
            int ID = 0;
            int Year = 1;
            Console.WriteLine("Tiger : {0}, Cat : {1}, Dog : {2}, Turtle : {3}", Tigers, Cat, Dogs, Turtles);
            for (int i = 0; i < Math.Max(Math.Max(Tigers,Turtles),Math.Max(Dogs,Cat)); i++)
            {
                if (i < Tigers)
                {
                    ZOO.Add(new Tiger(0, 10, ID, 10));
                    ID++;
                }
                if (i < Cat)
                {
                    ZOO.Add(new Cat(0, 12, ID, 2));
                    ID++;
                }
                if (i < Dogs)
                {
                    ZOO.Add(new Dog(0, 15, ID, 5));
                    ID++;
                }
                if (i < Turtles)
                {
                    ZOO.Add(new Turtle(0, 100, ID, 1));
                    ID++;
                }
            }
            bool ZooAlive = true;
            while ((Food > 0)&&(ZooAlive == true))
            {
                int TigerStat= 0;
                int TurtleStat =0;
                int CatStat =0;
                int DogStat =0;
                ZooAlive = false;
                bool IfDie = false; 
                List < Animal > Child = new List<Animal>();
                foreach (var animal in ZOO)
                {
                    if (animal.IsDead)
                        continue;

                    else {
                        ZooAlive = true;
                        Food = Food - animal.Eats;


                        if ((Year - animal.Born) < animal.ExpectedYearsLive)
                        {
                            if (rnd.Next(0, 100) > 75)
                                IfDie = true;
                            else
                            IfDie = false;
                        }
                        else if ((Year - animal.Born) == animal.ExpectedYearsLive)
                        {
                            if (rnd.Next(0, 100) > 40)
                                IfDie = true;
                        }
                        else if ((Year - animal.Born) > animal.ExpectedYearsLive)
                        {
                            if (rnd.Next(0, 100) < 95)
                                IfDie = true;
                        }
                        if (IfDie)
                            animal.IsDead = true;
                        
                        if (rnd.Next(0, 3) == 2)
                        {
                            if (animal is Tiger)
                                Child.Add(new Tiger(Year, 10, ID, 10));
                            else if (animal is Cat)
                                Child.Add(new Cat(Year, 12, ID, 2));
                            else if (animal is Dog)
                                Child.Add(new Dog(Year, 15, ID, 5));
                            else 
                                Child.Add(new Turtle(Year, 100, ID, 1));
                            ID++;
                        }


                    }
                }
                ZOO.AddRange(Child);
                foreach (var animal in ZOO)
                {
                    if (animal.IsDead == false)
                    {


                        if (animal is Tiger)
                            TigerStat++;
                        else if (animal is Cat)
                            CatStat++;
                        else if (animal is Dog)
                            DogStat++;
                        else
                            TurtleStat++;
                    }
                }
                Console.WriteLine("Tiger : {0}, Cat : {1}, Dog : {2}, Turtle : {3}",TigerStat,CatStat,DogStat,TurtleStat);
                Year++;
                
            }
            Console.WriteLine(Year);
        }
    }
}
