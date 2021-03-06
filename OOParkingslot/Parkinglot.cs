﻿using System;
using System.Collections.Generic;

namespace OOParkingslot
{
    public class Parkinglot : IParkable
    {
        private readonly Dictionary<string, Car> garage = new Dictionary<string, Car>();
        private readonly int capacity;

        public Parkinglot(int capacity)
        {
            this.capacity = capacity;
        }

        public Parkinglot() : this(20){}

        public string Park(Car value)
        {
            if (IsFull()) return null;
            var parkingToken = ParkingToken.CreateParkingToken();
            garage.Add(parkingToken, value);
            return parkingToken;
        }

        public Car Pick(string token)
        {
            if (ValidateParkingToken(token)) return null;
            var car = garage[token];
            garage.Remove(token);
            return car;
        }

        public ReportData[] GenerateReportDatas()
        {
            return new ReportData[]
            {
                new ReportData()
                {
                    AvailableStalls = GetAvailableStallsCount(),
                    CarsParked = GetCarCountInGarage(),
                    Level = 0,
                    Style = "P"
                }
            };
        }

        private bool ValidateParkingToken(string parkingToken)
        {
            return parkingToken == null || !garage.ContainsKey(parkingToken);
        }

        public int GetAvailableStallsCount()
        {
            return capacity - GetCarCountInGarage();
        }

        private int GetCarCountInGarage()
        {
            return garage.Count;
        }

        public bool IsFull()
        {
            return GetAvailableStallsCount() == 0;
        }

        public double GetVacancyRate()
        {
            return GetAvailableStallsCount() / (double) capacity;
        }
    }

    public class ParkingToken
    {
        public static string CreateParkingToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}