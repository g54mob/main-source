using System;
using System.Threading;

namespace Sentry.Internal
{
	internal class SynchronizedRandomValuesFactory : RandomValuesFactory
	{
		private static readonly AsyncLocal<Random> LocalRandom = new AsyncLocal<Random>();

		private static Random Random
		{
			get
			{
				AsyncLocal<Random> localRandom = LocalRandom;
				return localRandom.Value ?? (localRandom.Value = new Random());
			}
		}

		public override int NextInt()
		{
			return Random.Next();
		}

		public override int NextInt(int minValue, int maxValue)
		{
			return Random.Next(minValue, maxValue);
		}

		public override double NextDouble()
		{
			return Random.NextDouble();
		}

		public override void NextBytes(byte[] bytes)
		{
			Random.NextBytes(bytes);
		}
	}
}
