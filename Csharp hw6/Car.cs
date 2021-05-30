using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_hw6
{
    

    abstract class Car
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int CorrentSpeed { get; set; }
        public int CorrentDistance { get; set; } = 0;
        public bool Winner { get; set; } = false;
        protected Random random = new Random();


        public abstract void Drive();
        public abstract void ReadyToStart();
    }
    class SportCar : Car
    {
        public SportCar()
        {
            base.Name = "Sport car";
            base.MaxSpeed = 30;
        }
        public SportCar(string name, int maxSpeed)
        {
            base.Name = name;
            base.MaxSpeed = maxSpeed;
        }
        public override void Drive()
        {
            base.CorrentSpeed = random.Next(0, MaxSpeed);
            base.CorrentDistance += CorrentSpeed;
        }

        public override void ReadyToStart()
        {
            Console.WriteLine($"{Name} ready to start..");
        }
    }
    class SimpleCar : Car
    {
        public SimpleCar()
        {
            base.Name = "Simple car";
            base.MaxSpeed = 20;
        }
        public SimpleCar(string name, int maxSpeed)
        {
            base.Name = name;
            base.MaxSpeed = maxSpeed;
        }
        public override void Drive()
        {
            base.CorrentSpeed = random.Next(0, MaxSpeed);
            base.CorrentDistance += CorrentSpeed;
        }

        public override void ReadyToStart()
        {
            Console.WriteLine($"{Name} ready to start..");
        }
    }
    class Truck : Car
    {
        public Truck()
        {
            base.Name = "Truck";
            base.MaxSpeed = 17;
        }
        public Truck(string name, int maxSpeed)
        {
            base.Name = name;
            base.MaxSpeed = maxSpeed;
        }
        public override void Drive()
        {
            base.CorrentSpeed = random.Next(0, MaxSpeed);
            base.CorrentDistance += CorrentSpeed;
        }

        public override void ReadyToStart()
        {
            Console.WriteLine($"{Name} ready to start..");
        }
    }
    class Bus : Car
    {
        public Bus()
        {
            base.Name = "Bus";
            base.MaxSpeed = 15;
        }
        public Bus(string name, int maxSpeed)
        {
            base.Name = name;
            base.MaxSpeed = maxSpeed;
        }
        public override void Drive()
        {
            base.CorrentSpeed = random.Next(0, MaxSpeed);
            base.CorrentDistance += CorrentSpeed;
        }

        public override void ReadyToStart()
        {
            Console.WriteLine($"{Name} ready to start..");
        }
    }
}
