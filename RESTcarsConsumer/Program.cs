using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static RESTcarsConsumer.RESTClient;

namespace RESTcarsConsumer
{
    class Program
    {
        private const string BaseUri = "http://localhost:63523/api/cars";
        static void Main()
        {
            List<Car> cars = GetList<Car>(BaseUri).Result;
            Console.WriteLine("ALL: " + string.Join("\n", cars));
            try
            {
                Car car = GetSingle<Car>(BaseUri + "/28").Result;
                Console.WriteLine("GET by id: " + car);
            }
            catch (AggregateException ex)
            {
                ReadOnlyCollection<Exception> innerExceptions = ex.InnerExceptions;
                Exception exception = innerExceptions[0];
                Console.WriteLine(exception.Message);
            }

            Car newCar = new Car { Vendor = "NSU", Model = "King" };
            Car c = Post<Car, Car>(BaseUri, newCar).Result;
            Console.WriteLine("Added: " + c); 

            Car newValues = new Car { Vendor = "Audi", Model = "A100" };
            Car updatedCar = Put<Car, Car>(BaseUri + "/" + c.Id, newValues).Result;
            Console.WriteLine("Updated: " + updatedCar);

            Car deletedCar = Delete<Car>(BaseUri+ "/" + updatedCar.Id).Result;
            Console.WriteLine("Deleted: " + deletedCar);
        }
    }
}
