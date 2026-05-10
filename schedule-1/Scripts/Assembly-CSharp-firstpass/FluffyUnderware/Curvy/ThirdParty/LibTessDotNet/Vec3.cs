namespace FluffyUnderware.Curvy.ThirdParty.LibTessDotNet
{
	public struct Vec3
	{
		public static readonly Vec3 Zero;

		public float X;

		public float Y;

		public float Z;

		public float this[int index]
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static void Sub(ref Vec3 lhs, ref Vec3 rhs, out Vec3 result)
		{
			result = default(Vec3);
		}

		public static void Neg(ref Vec3 v)
		{
		}

		public static void Dot(ref Vec3 u, ref Vec3 v, out float dot)
		{
			dot = default(float);
		}

		public static void Normalize(ref Vec3 v)
		{
		}

		public static int LongAxis(ref Vec3 v)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
