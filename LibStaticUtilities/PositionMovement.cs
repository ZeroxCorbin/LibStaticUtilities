using System;

namespace LibStaticUtilities
{
    public static class PositionMovement
    {
        public static bool IsPointWithinCircumference(System.Drawing.Point center, double radius, System.Drawing.Point pointToCheck)
        {
            // Calculate the distance between the center and the point to check
            var distance = Math.Sqrt(Math.Pow(pointToCheck.X - center.X, 2) + Math.Pow(pointToCheck.Y - center.Y, 2));

            // Check if the distance is within the radius
            return distance <= radius;
        }
    }
}
