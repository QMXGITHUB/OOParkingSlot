﻿using Xunit;

namespace OOParkingslot
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_pick_car_when_only_one_parkinglot_parked()
        {
            var parkinglot = new Parkinglot();
            var parkingBoy = new ParkingBoy(parkinglot);

            var car = new Car();
            var parkToken = parkinglot.Park(car);

            Assert.Same(car, parkingBoy.Pick(parkToken));
        }

    }
}