namespace Coherence.Common
{
	public struct Vector4d
	{
		public double x;

		public double y;

		public double z;

		public double w;

		public static Vector4d zero => default(Vector4d);

		public Vector4d normalized => default(Vector4d);

		public Vector4d(double x, double y, double z, double w)
		{
			this.x = 0.0;
			this.y = 0.0;
			this.z = 0.0;
			this.w = 0.0;
		}

		public static Vector4d Normalize(Vector4d v)
		{
			return default(Vector4d);
		}

		public static double Magnitude(Vector4d a)
		{
			return 0.0;
		}

		public static double Dot(Vector4d a, Vector4d b)
		{
			return 0.0;
		}

		public static Vector4d Project(Vector4d a, Vector4d b)
		{
			return default(Vector4d);
		}

		public static Vector4d operator *(Vector4d a, double d)
		{
			return default(Vector4d);
		}

		public static Vector4d operator /(Vector4d a, double d)
		{
			return default(Vector4d);
		}
	}
}
