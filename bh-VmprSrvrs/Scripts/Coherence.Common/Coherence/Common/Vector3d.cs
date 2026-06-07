using System.Numerics;

namespace Coherence.Common
{
	public struct Vector3d
	{
		public double x;

		public double y;

		public double z;

		public Vector3d normalized => default(Vector3d);

		public double magnitude => 0.0;

		public double sqrMagnitude => 0.0;

		public static Vector3d zero => default(Vector3d);

		public static Vector3d one => default(Vector3d);

		public static Vector3d forward => default(Vector3d);

		public static Vector3d back => default(Vector3d);

		public static Vector3d up => default(Vector3d);

		public static Vector3d down => default(Vector3d);

		public static Vector3d left => default(Vector3d);

		public static Vector3d right => default(Vector3d);

		public Vector3d(double x, double y, double z)
		{
			this.x = 0.0;
			this.y = 0.0;
			this.z = 0.0;
		}

		public Vector3d(float x, float y, float z)
		{
			this.x = 0.0;
			this.y = 0.0;
			this.z = 0.0;
		}

		public Vector3d(double x, double y)
		{
			this.x = 0.0;
			this.y = 0.0;
			z = 0.0;
		}

		public static Vector3d operator +(Vector3d a, Vector3d b)
		{
			return default(Vector3d);
		}

		public static Vector3d operator -(Vector3d a, Vector3d b)
		{
			return default(Vector3d);
		}

		public static Vector3d operator -(Vector3d a)
		{
			return default(Vector3d);
		}

		public static Vector3d operator *(Vector3d a, double d)
		{
			return default(Vector3d);
		}

		public static Vector3d operator *(double d, Vector3d a)
		{
			return default(Vector3d);
		}

		public static Vector3d operator /(Vector3d a, double d)
		{
			return default(Vector3d);
		}

		public static bool operator ==(Vector3d lhs, Vector3d rhs)
		{
			return false;
		}

		public static bool operator !=(Vector3d lhs, Vector3d rhs)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static Vector3d Normalize(Vector3d value)
		{
			return default(Vector3d);
		}

		public void Normalize()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static double Magnitude(Vector3d a)
		{
			return 0.0;
		}

		public static double SqrMagnitude(Vector3d a)
		{
			return 0.0;
		}

		public bool IsWithinRange(double maxRange)
		{
			return false;
		}

		public Vector3 ToCoreVector3()
		{
			return default(Vector3);
		}
	}
}
