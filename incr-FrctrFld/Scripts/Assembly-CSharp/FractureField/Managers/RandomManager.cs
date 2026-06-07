using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FractureField.Managers
{
	public class RandomManager
	{
		private Random _random;

		private int _currentSeed;

		private const int CheckpointInterval = 1000;

		private static int seedCounter;

		[JsonProperty]
		private int InitialSeed { get; set; }

		[JsonProperty]
		private int GenerationCount { get; set; }

		private int CalculateSeed(int seed, int checkpoints)
		{
			return 0;
		}

		private void IncrementAndCheckpoint()
		{
		}

		public int NextInt(int minValueInclusive, int maxValueExclusive)
		{
			return 0;
		}

		public float NextFloat()
		{
			return 0f;
		}

		public float NextFloat(float minValueInclusive, float maxValueExclusive)
		{
			return 0f;
		}

		private double NextDouble()
		{
			return 0.0;
		}

		public bool NextChance(float chance)
		{
			return false;
		}

		public T RandomFromList<T>(List<T> list)
		{
			return default(T);
		}
	}
}
