using System;

namespace MiscUtil
{
	public static class StaticRandom
	{
		private static Random random = new Random();

		private static object myLock = new object();

		public static int Next()
		{
			lock (myLock)
			{
				return random.Next();
			}
		}

		public static int Next(int max)
		{
			lock (myLock)
			{
				return random.Next(max);
			}
		}

		public static int Next(int min, int max)
		{
			lock (myLock)
			{
				return random.Next(min, max);
			}
		}

		public static double NextDouble()
		{
			lock (myLock)
			{
				return random.NextDouble();
			}
		}

		public static void NextBytes(byte[] buffer)
		{
			lock (myLock)
			{
				random.NextBytes(buffer);
			}
		}
	}
}
