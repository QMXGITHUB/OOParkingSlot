﻿using Xunit;

namespace OOParkingslot.Tests
{
    public class ParkingManagerTest
    {
        [Fact]
        public void should_park_in_his_parkinglot()
        {
            var parkinglot = new Parkinglot();
            var parkingManager = new ParkingManager(
                ParkingBoyFactory.CreateParkingBoy(new Parkinglot(0)),
                ParkingBoyFactory.CreateSmartParkingBoy(new Parkinglot(0)),
                ParkingBoyFactory.CreateSuperParkingBoy(new Parkinglot(0)),
                parkinglot);
            var car = new Car();

            var token = parkingManager.Park(car);

            Assert.Same(car, parkinglot.Pick(token));
        }

        [Fact]
        public void should_pick_from_his_parkinglot()
        {
            var parkinglot = new Parkinglot(1);
            var parkingManager = new ParkingManager(
                ParkingBoyFactory.CreateParkingBoy(new Parkinglot(0)),
                ParkingBoyFactory.CreateSmartParkingBoy(new Parkinglot(0)),
                ParkingBoyFactory.CreateSuperParkingBoy(new Parkinglot(0)),
                parkinglot);
            var car = new Car();

            var token = parkinglot.Park(car);

            Assert.Same(car, parkingManager.Pick(token));
        }

        [Fact]
        public void should_parkingmanager_park_in_parkinglot_with_parkingboy()
        {
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new Parkinglot());
            var parkingManager = new ParkingManager(
                ParkingBoyFactory.CreateSmartParkingBoy(new Parkinglot(0)),
                ParkingBoyFactory.CreateSuperParkingBoy(new Parkinglot(0)),
                parkingBoy,
                new Parkinglot(0));
            var car = new Car();

            var token = parkingManager.Park(car);

            Assert.Same(car, parkingBoy.Pick(token));
        }

        [Fact]
        public void should_parkingManager_pick_when_parkingboy_parked()
        {
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new Parkinglot());
            var parkingManager = new ParkingManager(
                ParkingBoyFactory.CreateSmartParkingBoy(new Parkinglot(0)),
                parkingBoy,
                ParkingBoyFactory.CreateSuperParkingBoy(new Parkinglot()),
                new Parkinglot());
            var car = new Car();

            var token = parkingBoy.Park(car);

            Assert.Same(car, parkingManager.Pick(token));
        }
    }
}