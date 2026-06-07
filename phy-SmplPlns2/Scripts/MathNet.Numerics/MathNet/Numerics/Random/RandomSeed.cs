using System;
using System.Security.Cryptography;

namespace MathNet.Numerics.Random
{
	public static class RandomSeed
	{
		private static readonly object Lock = new object();

		private static readonly RandomNumberGenerator MasterRng = RandomNumberGenerator.Create();

		public static int Time()
		{
			return Environment.TickCount;
		}

		public static int Guid()
		{
			return Environment.TickCount ^ System.Guid.NewGuid().GetHashCode();
		}

		public static int Robust()
		{
			lock (Lock)
			{
				byte[] array = new byte[4];
				MasterRng.GetBytes(array);
				return BitConverter.ToInt32(array, 0);
			}
		}
	}
}
