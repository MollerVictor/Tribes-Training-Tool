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

        public static float SqrDistance(Vector3 a, Vector3 b)
        {
            float distance = 0;
            distance += (float)Math.Pow(a.x - b.x, 2);
            distance += (float)Math.Pow(a.y - b.y, 2);
            distance += (float)Math.Pow(a.z - b.z, 2);
            return distance;
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            return (float)Math.Sqrt(SqrDistance(a,b));
        }
    }
}
