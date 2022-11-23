using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoerselslogApp.Models.Car
{
    internal interface ICarRepository
    {
        void Add(CarModel carModel);
        void Edit(CarModel carModel);
        void Remove(CarModel carModel);
    }
}
