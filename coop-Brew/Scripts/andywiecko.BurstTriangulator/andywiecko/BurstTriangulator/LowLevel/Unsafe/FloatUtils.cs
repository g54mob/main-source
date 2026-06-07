using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct FloatUtils : IUtils<float, float2, float>
	{
		public float Cast(float v)
		{
			return 0f;
		}

		public float2 CircumCenter(float2 a, float2 b, float2 c)
		{
			return default(float2);
		}

		public float Const(float v)
		{
			return 0f;
		}

		public float EPSILON()
		{
			return 0f;
		}

		public bool InCircle(float2 a, float2 b, float2 c, float2 p)
		{
			return false;
		}

		public float MaxValue()
		{
			return 0f;
		}

		public float2 MaxValue2()
		{
			return default(float2);
		}

		public float2 MinValue2()
		{
			return default(float2);
		}

		public bool PointInsideTriangle(float2 p, float2 a, float2 b, float2 c)
		{
			return false;
		}

		public bool SupportsRefinement()
		{
			return false;
		}

		public float X(float2 a)
		{
			return 0f;
		}

		public float Y(float2 a)
		{
			return 0f;
		}

		public float Zero()
		{
			return 0f;
		}

		public float ZeroTBig()
		{
			return 0f;
		}

		public float abs(float v)
		{
			return 0f;
		}

		public float alpha(float concentricShellReferenceRadius, float edgeLengthSq)
		{
			return 0f;
		}

		public bool anygreaterthan(float a, float b, float c, float v)
		{
			return false;
		}

		public float2 avg(float2 a, float2 b)
		{
			return default(float2);
		}

		public float cos(float v)
		{
			return 0f;
		}

		public float diff(float a, float b)
		{
			return 0f;
		}

		public float2 diff(float2 a, float2 b)
		{
			return default(float2);
		}

		public float distancesq(float2 a, float2 b)
		{
			return 0f;
		}

		public float dot(float2 a, float2 b)
		{
			return 0f;
		}

		public bool2 eq(float2 v, float2 w)
		{
			return default(bool2);
		}

		public bool2 ge(float2 a, float2 b)
		{
			return default(bool2);
		}

		public bool greater(float a, float b)
		{
			return false;
		}

		public int hashkey(float2 p, float2 c, int hashSize)
		{
			return 0;
		}

		public bool2 isfinite(float2 v)
		{
			return default(bool2);
		}

		public bool le(float a, float b)
		{
			return false;
		}

		public bool2 le(float2 a, float2 b)
		{
			return default(bool2);
		}

		public float2 lerp(float2 a, float2 b, float v)
		{
			return default(float2);
		}

		public bool less(float a, float b)
		{
			return false;
		}

		public float2 max(float2 v, float2 w)
		{
			return default(float2);
		}

		public float2 min(float2 v, float2 w)
		{
			return default(float2);
		}

		public float mul(float a, float b)
		{
			return 0f;
		}

		public float2 neg(float2 v)
		{
			return default(float2);
		}

		public float2 normalizesafe(float2 v)
		{
			return default(float2);
		}
	}
}
