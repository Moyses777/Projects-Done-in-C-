using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternAppExample
{
    public interface IBuilder
    {
        void reset();
        CarBuilder setSeats(int seats);
        CarBuilder setGPS(string gps);
        CarBuilder setWheels(int wheels);
        CarBuilder setModel(string model);
    }

    public class Car
    {
        private string _GPS;
        private CarBuilder _builder;

        public Car(CarBuilder builder)
        {
            this._builder = builder;
        }

        public string GPS { get { return _GPS; } set { if (_GPS != value) _GPS = value; } }
        public CarBuilder Builder { get { return _builder; } set { if (_builder != value) _builder = value; } }
    }

    public class CarBuilder : IBuilder
    {
        Car car;
        private string _Model;
        private int _Seats;
        private int _Wheels;

        public string Model { get { return _Model; } }
        public int Seats { get { return _Seats; } }
        public int Wheels { get { return _Wheels; } }

        public CarBuilder()
        {
            car = new Car(this);
        }

        public void reset()
        {
            this.car = new Car(this);
        }

        public CarBuilder setGPS(string gps)
        {
            this.car.GPS = gps;
            return this;
        }

        public CarBuilder setModel(string model)
        {
            this._Model = model;
            return this;
        }

        public CarBuilder setSeats(int seats)
        {
            this._Seats = seats;
            return this;
        }

        public CarBuilder setWheels(int wheels)
        {
            this._Wheels = wheels;
            return this;
        }

        public Car build() => new Car(this);
    }

    public class HeadMaster
    {
        public HeadMaster()
        {
            
        }

        public void makeSportiveCar(IBuilder builder)
        {
            builder.setGPS("automatic").setModel("BMW").setWheels(4);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarBuilder builder = new CarBuilder();
            HeadMaster headMaster = new HeadMaster();
            headMaster.makeSportiveCar(builder);
            Car car = builder.build();
            Console.WriteLine(car.Builder.Seats);
            Console.ReadKey();
        }
    }
}
