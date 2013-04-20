using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tribes_Training_Tool
{
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3()
        {
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            float distance = 0;
            distance += Math.Abs(a.x - b.x);
            distance += Math.Abs(a.y - b.y);
            distance += Math.Abs(a.z - b.z);
            return distance;
        }
    }
}
