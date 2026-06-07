using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	public static class BSplineHelper
	{
		public static Vector3 DeBoorClamped(int p, int k, float u, int nPlus1, [NotNull] Vector3[] pArray)
		{
			return default(Vector3);
		}

		public static Vector3 DeBoorUnclamped(int p, int k, float u, [NotNull] Vector3[] pArray)
		{
			return default(Vector3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetBSplineN(int controlPointsCount, int degree, bool closed)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetBSplineUAndK(float tf, bool isClamped, int p, int n, out float u, out int k)
		{
			u = default(float);
			k = default(int);
		}
	}
}
