using System;
using System.Threading;
using UnityEngine;

namespace NSMedieval.Tools.Math
{
	public static class Random
	{
		private static int seed;

		private static readonly ThreadLocal<System.Random> ThreadSafeRandom = new ThreadLocal<System.Random>(() => new System.Random(Interlocked.Increment(ref seed)));

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			seed = Environment.TickCount;
		}

		public static int Next()
		{
			return ThreadSafeRandom.Value.Next();
		}

		public static int Range(int min, int max)
		{
			return ThreadSafeRandom.Value.Next(min, max);
		}

		public static float Range(float min, float max)
		{
			return (float)ThreadSafeRandom.Value.NextDouble() * (max - min) + min;
		}

		public static double Range(double min, double max)
		{
			return ThreadSafeRandom.Value.NextDouble() * (max - min) + min;
		}

		public static float Value()
		{
			return (float)ThreadSafeRandom.Value.NextDouble();
		}
	}
}
