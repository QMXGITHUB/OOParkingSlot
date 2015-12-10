﻿using System.Collections.Generic;
using System.Text;

namespace OOParkingslot
{
    public class ParkingDirector
    {
        private const string PrefixUnit = "  ";
        private ParkingManager parkingManager;

        public ParkingDirector(ParkingManager parkingManager)
        {
            this.parkingManager = parkingManager;
        }

        public string Report()
        {
            var report = new StringBuilder();
            var reportdatas = parkingManager.GenerateReportData();
            for (int i = 0; i < reportdatas.Length ; i++)
            {
                var reportdata = reportdatas[i];
                AppendPrefixForEachLine(reportdata, report);
                report.Append(reportdata.Style+" "+reportdata.CarsParked+" "+reportdata.AvailableStalls+"\r\n");
            }
            return report.ToString();
        }

        private static void AppendPrefixForEachLine(ReportModule reportdata, StringBuilder report)
        {
            for (int j = 0; j < reportdata.Level; j++)
            {
                report.Append(PrefixUnit);
            }
        }
    }
}