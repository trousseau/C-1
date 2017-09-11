using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public struct Geolocation
    {
        readonly public decimal Longitude;
        readonly public decimal Latitude;

        public Geolocation(decimal latitude, decimal longitude)
        {
            if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180)
            {
                throw new ArgumentOutOfRangeException();
            }

            Longitude = longitude;
            Latitude = latitude;
        }

        public Geolocation(Geolocation other)
        {
            Latitude = other.Latitude;
            Longitude = other.Longitude;
        }

        public string DMS()
        {
            int degreesLat = (int)Math.Truncate(Latitude);
            int degreesLong = (int)Math.Truncate(Longitude);
            decimal latResult = (Latitude - degreesLat) * 60;
            decimal longResult = (Longitude - degreesLong) * 60;
            int latMin = (int)Math.Truncate(latResult);
            int latSec = (int)Decimal.Round((latResult - latMin) * 60);
            int longMin = (int)Math.Truncate(longResult);
            int longSec = (int)Decimal.Round((longResult - longMin) * 60);
            char latHem;
            char longHem;

            if (Latitude >= 0)
            {
                latHem = 'N';
            }
            else
            {
                latHem = 'S';
            }

            if (Longitude >= 0)
            {
                longHem = 'E';
            }
            else
            {
                longHem = 'W';
            }

            return String.Format($"{Math.Abs(degreesLat)}\u00B0 {Math.Abs(latMin),3}\' {Math.Abs(latSec),3}\" {latHem} {Math.Abs(degreesLong),4}\u00B0 {Math.Abs(longMin),3}\' {Math.Abs(longSec),3}\" {longHem}");
        }

        public decimal GreatCircleDistance(Geolocation other, LengthTypes lengthtype = LengthTypes.Meters)
        {
            double lat1 = ToRadians((double)Latitude);
            double lng1 = ToRadians((double)Longitude);
            double lat2 = ToRadians((double)other.Latitude);
            double lng2 = ToRadians((double)other.Longitude);

            double latDiff = lat1 - lat2;
            double lngDiff = lng1 - lng2;

            double sin2Lat = Math.Pow(Math.Sin(latDiff / 2),2);
            double sin2Lng = Math.Pow(Math.Sin(lngDiff / 2), 2);

            double a = sin2Lat + Math.Cos(lat1) * Math.Cos(lat2) * sin2Lng;

            double arcLength = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));

            decimal distance = (decimal)(6371000 * arcLength);

            switch (lengthtype)
            {
                case LengthTypes.Meters:
                    return distance;
                case LengthTypes.Kilometers:
                    return distance * 0.001M;
                case LengthTypes.Feet:
                    return distance * 3.2808399M;
                case LengthTypes.Miles:
                    return distance * 0.00062137119M;
                default:
                    return distance;
            }
        }

        private static double ToRadians(double degreeVal)
        {
            return (degreeVal * (Math.PI / 180.0));
        }
    }
}
