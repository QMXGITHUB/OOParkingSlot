﻿using System.Linq;

namespace OOParkingslot
{
    public class ParkingBoy : BaseParkingBoy, ParkingPolicy
    {
        public ParkingBoy(params Parkinglot[] parkinglots):base(parkinglots)
        {
        }

        public Parkinglot FindParkinglotToPark(Parkinglot[] parkinglots)
        {
            return parkinglots.FirstOrDefault(parkinglot => parkinglot.IsFull() == false);
        }
    }
}