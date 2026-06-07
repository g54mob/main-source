using Unity.Mathematics;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal interface IUtils<T, T2, TBig> where T : struct where T2 : struct where TBig : struct
	{
		T Cast(TBig v);

		T2 CircumCenter(T2 a, T2 b, T2 c);

		T Const(float v);

		TBig EPSILON();

		bool InCircle(T2 a, T2 b, T2 c, T2 p);

		TBig MaxValue();

		T2 MaxValue2();

		T2 MinValue2();

		bool PointInsideTriangle(T2 p, T2 a, T2 b, T2 c);

		bool SupportsRefinement();

		T X(T2 v);

		T Y(T2 v);

		T Zero();

		TBig ZeroTBig();

		T abs(T v);

		TBig abs(TBig v);

		T alpha(T concentricShellReferenceRadius, T dSquare);

		bool anygreaterthan(T a, T b, T c, T v);

		T2 avg(T2 a, T2 b);

		T cos(T v);

		T diff(T a, T b);

		TBig diff(TBig a, TBig b);

		T2 diff(T2 a, T2 b);

		TBig distancesq(T2 a, T2 b);

		T dot(T2 a, T2 b);

		bool2 eq(T2 v, T2 w);

		bool2 ge(T2 a, T2 b);

		bool greater(T a, T b);

		bool greater(TBig a, TBig b);

		int hashkey(T2 p, T2 c, int hashSize);

		bool2 isfinite(T2 v);

		bool le(T a, T b);

		bool le(TBig a, TBig b);

		bool2 le(T2 a, T2 b);

		T2 lerp(T2 a, T2 b, T v);

		bool less(TBig a, TBig b);

		T2 max(T2 v, T2 w);

		T2 min(T2 v, T2 w);

		TBig mul(T a, T b);

		T2 neg(T2 v);

		T2 normalizesafe(T2 v);
	}
}
