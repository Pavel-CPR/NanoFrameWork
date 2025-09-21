using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.DatabaseServices;
using Teigha.Geometry;

namespace NanoFrameWork
{
    public static class PointExtension
    {
        /// <summary>
        /// Проверяет лежит ли точка внутри контура
        /// </summary>
        /// <param name="point"></param>
        /// <param name="contour"></param>
        /// <returns></returns>
        public static bool IsInsideContour(this Point3d point, Polyline contour)
        {
            var startPoint = point;
            var endPoint = new Point3d(point.X + 100000, point.Y + 100000, point.Z);

            var ray = new Line(startPoint, endPoint);
            var intersectionPoints = new Point3dCollection();
            ray.IntersectWith(contour, Intersect.OnBothOperands, intersectionPoints, IntPtr.Zero, IntPtr.Zero);

            if (intersectionPoints.Count % 2 != 0)
            {
                return true;
            }

            return false;
        }

        public static Point3d ConevertTo3d(this Point2d point)
        {
            return new Point3d(point.X, point.Y, 0);
        }
    }
}
