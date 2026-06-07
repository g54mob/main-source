using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout((LayoutKind)0, Size = 1)]
	internal readonly struct IntUtils : IUtils<int, int2, long>
	{
		public int Cast(long v)
		{
			return 0;
		}

		public int2 CircumCenter(int2 a, int2 b, int2 c)
		{
			return default(int2);
		}

		public int Const(float v)
		{
			return 0;
		}

		public long EPSILON()
		{
			return 0L;
		}

		public bool InCircle(int2 a, int2 b, int2 c, int2 p)
		{
			return false;
		}

		public long MaxValue()
		{
			return 0L;
		}

		public int2 MaxValue2()
		{
			return default(int2);
		}

		public int2 MinValue2()
		{
			return default(int2);
		}

		public bool PointInsideTriangle(int2 p, int2 a, int2 b, int2 c)
		{
			return false;
		}

		public bool SupportsRefinement()
		{
			return false;
		}

		public int X(int2 a)
		{
			return 0;
		}

		public int Y(int2 a)
		{
			return 0;
		}

		public int Zero()
		{
			return 0;
		}

		public long ZeroTBig()
		{
			return 0L;
		}

		public int abs(int v)
		{
			return 0;
		}

		public long abs(long v)
		{
			return 0L;
		}

		public int alpha(int concentricShellReferenceRadius, int edgeLengthSq)
		{
			return 0;
		}

		public bool anygreaterthan(int a, int b, int c, int v)
		{
			return false;
		}

		public int2 avg(int2 a, int2 b)
		{
			return default(int2);
		}

		public int cos(int v)
		{
			return 0;
		}

		public int diff(int a, int b)
		{
			return 0;
		}

		public long diff(long a, long b)
		{
			return 0L;
		}

		public int2 diff(int2 a, int2 b)
		{
			return default(int2);
		}

		public long distancesq(int2 a, int2 b)
		{
			return 0L;
		}

		public int dot(int2 a, int2 b)
		{
			return 0;
		}

		public bool2 eq(int2 v, int2 w)
		{
			return default(bool2);
		}

		public bool2 ge(int2 a, int2 b)
		{
			return default(bool2);
		}

		public bool greater(int a, int b)
		{
			return false;
		}

		public bool greater(long a, long b)
		{
			return false;
		}

		public int hashkey(int2 p, int2 c, int hashSize)
		{
			return 0;
		}

		public bool2 isfinite(int2 v)
		{
			return default(bool2);
		}

		public bool le(int a, int b)
		{
			return false;
		}

		public bool le(long a, long b)
		{
			return false;
		}

		public bool2 le(int2 a, int2 b)
		{
			return default(bool2);
		}

		public int2 lerp(int2 a, int2 b, int v)
		{
			return default(int2);
		}

		public bool less(long a, long b)
		{
			return false;
		}

		public int2 max(int2 v, int2 w)
		{
			return default(int2);
		}

		public int2 min(int2 v, int2 w)
		{
			return default(int2);
		}

		public long mul(int a, int b)
		{
			return 0L;
		}

		public int2 neg(int2 v)
		{
			return default(int2);
		}

		public int2 normalizesafe(int2 v)
		{
			return default(int2);
		}
	}
}
