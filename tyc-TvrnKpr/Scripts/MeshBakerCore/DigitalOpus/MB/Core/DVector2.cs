using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public struct DVector2
	{
		private static double epsilon;

		public double x;

		public double y;

		public static DVector2 Subtract(DVector2 a, DVector2 b)
		{
			return default(DVector2);
		}

		public DVector2(double xx, double yy)
		{
			x = 0.0;
			y = 0.0;
		}

		public DVector2(DVector2 r)
		{
			x = 0.0;
			y = 0.0;
		}

		public Vector2 GetVector2()
		{
			return default(Vector2);
		}

		public bool IsContainedIn(DRect r)
		{
			return false;
		}

		public bool IsContainedInWithMargin(DRect r)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(string formatS)
		{
			return null;
		}

		public static double Distance(DVector2 a, DVector2 b)
		{
			return 0.0;
		}
	}
}
