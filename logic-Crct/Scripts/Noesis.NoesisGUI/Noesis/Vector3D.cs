using System.Text.RegularExpressions;

namespace Noesis
{
	public struct Vector3D
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

		public float Length => 0f;

		public float LengthSquared => 0f;

		public Vector3D(float x, float y, float z)
		{
			_x = 0f;
			_y = 0f;
			_z = 0f;
		}

		public void Normalize()
		{
		}

		public static Vector3D CrossProduct(Vector3D v0, Vector3D v1)
		{
			return default(Vector3D);
		}

		public static Vector3D operator -(Vector3D vector)
		{
			return default(Vector3D);
		}

		public void Negate()
		{
		}

		public static Vector3D operator +(Vector3D v0, Vector3D v1)
		{
			return default(Vector3D);
		}

		public static Vector3D Add(Vector3D v0, Vector3D v1)
		{
			return default(Vector3D);
		}

		public static Vector3D operator -(Vector3D v0, Vector3D v1)
		{
			return default(Vector3D);
		}

		public static Vector3D Subtract(Vector3D v0, Vector3D v1)
		{
			return default(Vector3D);
		}

		public static Point3D operator +(Vector3D vector, Point3D point)
		{
			return default(Point3D);
		}

		public static Point3D Add(Vector3D vector, Point3D point)
		{
			return default(Point3D);
		}

		public static Vector3D operator *(Vector3D vector, float scalar)
		{
			return default(Vector3D);
		}

		public static Vector3D Multiply(Vector3D vector, float scalar)
		{
			return default(Vector3D);
		}

		public static Vector3D operator *(float scalar, Vector3D vector)
		{
			return default(Vector3D);
		}

		public static Vector3D Multiply(float scalar, Vector3D vector)
		{
			return default(Vector3D);
		}

		public static Vector3D operator /(Vector3D vector, float scalar)
		{
			return default(Vector3D);
		}

		public static Vector3D Divide(Vector3D vector, float scalar)
		{
			return default(Vector3D);
		}

		public static float operator *(Vector3D v0, Vector3D v1)
		{
			return 0f;
		}

		public static float Multiply(Vector3D v0, Vector3D v1)
		{
			return 0f;
		}

		public static explicit operator Point3D(Vector3D vector)
		{
			return default(Point3D);
		}

		public static bool operator ==(Vector3D v0, Vector3D v1)
		{
			return false;
		}

		public static bool operator !=(Vector3D v0, Vector3D v1)
		{
			return false;
		}

		public static bool Equals(Vector3D v0, Vector3D v1)
		{
			return false;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public bool Equals(Vector3D value)
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

		public static Vector3D Parse(string str)
		{
			return default(Vector3D);
		}
	}
}
