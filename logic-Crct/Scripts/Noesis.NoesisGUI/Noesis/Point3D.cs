using System.Text.RegularExpressions;

namespace Noesis
{
	public struct Point3D
	{
		private float _x;

		private float _y;

		private float _z;

		private static string sParseExpression;

		private static Regex sRegex;

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Z
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Point3D(float x, float y, float z)
		{
			_x = 0f;
			_y = 0f;
			_z = 0f;
		}

		public void Offset(float offsetX, float offsetY, float offsetZ)
		{
		}

		public static Point3D operator +(Point3D point, Vector3D vector)
		{
			return default(Point3D);
		}

		public static Point3D Add(Point3D point, Vector3D vector)
		{
			return default(Point3D);
		}

		public static Point3D operator -(Point3D point, Vector3D vector)
		{
			return default(Point3D);
		}

		public static Point3D Subtract(Point3D point, Vector3D vector)
		{
			return default(Point3D);
		}

		public static Vector3D operator -(Point3D point1, Point3D point2)
		{
			return default(Vector3D);
		}

		public static Vector3D Subtract(Point3D point1, Point3D point2)
		{
			return default(Vector3D);
		}

		public static Point3D operator *(Point3D point, Matrix3D matrix)
		{
			return default(Point3D);
		}

		public static Point3D Multiply(Point3D point, Matrix3D matrix)
		{
			return default(Point3D);
		}

		public static explicit operator Vector3D(Point3D point)
		{
			return default(Vector3D);
		}

		public static bool operator ==(Point3D point1, Point3D point2)
		{
			return false;
		}

		public static bool operator !=(Point3D point1, Point3D point2)
		{
			return false;
		}

		public static bool Equals(Point3D point1, Point3D point2)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public bool Equals(Point3D value)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static Point3D Parse(string str)
		{
			return default(Point3D);
		}
	}
}
