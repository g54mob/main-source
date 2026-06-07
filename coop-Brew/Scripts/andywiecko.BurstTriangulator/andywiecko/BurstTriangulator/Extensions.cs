using System;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace andywiecko.BurstTriangulator
{
	public static class Extensions
	{
		[Obsolete("Use AsNativeArray(out Handle) instead! You can learn more in the project manual.")]
		public static NativeArray<T> AsNativeArray<T>(this T[] array) where T : struct
		{
			return default(NativeArray<T>);
		}

		public static NativeArray<T> AsNativeArray<T>(this T[] array, out Handle handle) where T : struct
		{
			handle = default(Handle);
			return default(NativeArray<T>);
		}

		public static void Run(this Triangulator<float2> @this)
		{
		}

		public static JobHandle Schedule(this Triangulator<float2> @this, JobHandle dependencies = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void Run(this Triangulator<Vector2> @this)
		{
		}

		public static JobHandle Schedule(this Triangulator<Vector2> @this, JobHandle dependencies = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void Run(this Triangulator<double2> @this)
		{
		}

		public static JobHandle Schedule(this Triangulator<double2> @this, JobHandle dependencies = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void Run(this Triangulator<int2> @this)
		{
		}

		public static JobHandle Schedule(this Triangulator<int2> @this, JobHandle dependencies = default(JobHandle))
		{
			return default(JobHandle);
		}
	}
}
