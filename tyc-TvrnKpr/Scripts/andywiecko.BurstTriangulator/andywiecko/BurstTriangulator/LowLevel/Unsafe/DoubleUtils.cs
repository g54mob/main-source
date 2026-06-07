using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout((LayoutKind)0, Size = 1)]
	internal readonly struct DoubleUtils : IUtils<double, double2, double>
	{
		public double Cast(double v)
		{
			return 0.0;
		}

		public double2 CircumCenter(double2 a, double2 b, double2 c)
		{
			return default(double2);
		}

		public double Const(float v)
		{
			return 0.0;
		}

		public double EPSILON()
		{
			return 0.0;
		}

		public bool InCircle(double2 a, double2 b, double2 c, double2 p)
		{
			return false;
		}

		public double MaxValue()
		{
			return 0.0;
		}

		public double2 MaxValue2()
		{
			return default(double2);
		}

		public double2 MinValue2()
		{
			return default(double2);
		}

		public bool PointInsideTriangle(double2 p, double2 a, double2 b, double2 c)
		{
			return false;
		}

		public bool SupportsRefinement()
		{
			return false;
		}

		public double X(double2 a)
		{
			return 0.0;
		}

		public double Y(double2 a)
		{
			return 0.0;
		}

		public double Zero()
		{
			return 0.0;
		}

		public double ZeroTBig()
		{
			return 0.0;
		}

		public double abs(double v)
		{
			return 0.0;
		}

		public double alpha(double concentricShellReferenceRadius, double edgeLengthSq)
		{
			return 0.0;
		}

		public bool anygreaterthan(double a, double b, double c, double v)
		{
			return false;
		}

		public double2 avg(double2 a, double2 b)
		{
			return default(double2);
		}

		public double cos(double v)
		{
			return 0.0;
		}

		public double diff(double a, double b)
		{
			return 0.0;
		}

		public double2 diff(double2 a, double2 b)
		{
			return default(double2);
		}

		public double distancesq(double2 a, double2 b)
		{
			return 0.0;
		}

		public double dot(double2 a, double2 b)
		{
			return 0.0;
		}

		public bool2 eq(double2 v, double2 w)
		{
			return default(bool2);
		}

		public bool2 ge(double2 a, double2 b)
		{
			return default(bool2);
		}

		public bool greater(double a, double b)
		{
			return false;
		}

		public int hashkey(double2 p, double2 c, int hashSize)
		{
			return 0;
		}

		public bool2 isfinite(double2 v)
		{
			return default(bool2);
		}

		public bool le(double a, double b)
		{
			return false;
		}

		public bool2 le(double2 a, double2 b)
		{
			return default(bool2);
		}

		public double2 lerp(double2 a, double2 b, double v)
		{
			return default(double2);
		}

		public bool less(double a, double b)
		{
			return false;
		}

		public double2 max(double2 v, double2 w)
		{
			return default(double2);
		}

		public double2 min(double2 v, double2 w)
		{
			return default(double2);
		}

		public double mul(double a, double b)
		{
			return 0.0;
		}

		public double2 neg(double2 v)
		{
			return default(double2);
		}

		public double2 normalizesafe(double2 v)
		{
			return default(double2);
		}
	}
}
