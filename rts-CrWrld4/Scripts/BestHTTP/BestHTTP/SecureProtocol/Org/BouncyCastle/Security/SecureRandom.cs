using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public class SecureRandom : Random
	{
		private static long counter;

		private static readonly SecureRandom master;

		protected readonly IRandomGenerator generator;

		private static readonly double DoubleScale;

		private static SecureRandom Master => null;

		private static long NextCounterValue()
		{
			return 0L;
		}

		private static DigestRandomGenerator CreatePrng(string digestName, bool autoSeed)
		{
			return null;
		}

		public static byte[] GetNextBytes(SecureRandom secureRandom, int length)
		{
			return null;
		}

		public static SecureRandom GetInstance(string algorithm)
		{
			return null;
		}

		public static SecureRandom GetInstance(string algorithm, bool autoSeed)
		{
			return null;
		}

		public static byte[] GetSeed(int length)
		{
			return null;
		}

		public SecureRandom()
		{
		}

		public SecureRandom(byte[] seed)
		{
		}

		public SecureRandom(IRandomGenerator generator)
		{
		}

		public virtual byte[] GenerateSeed(int length)
		{
			return null;
		}

		public virtual void SetSeed(byte[] seed)
		{
		}

		public virtual void SetSeed(long seed)
		{
		}

		public override int Next()
		{
			return 0;
		}

		public override int Next(int maxValue)
		{
			return 0;
		}

		public override int Next(int minValue, int maxValue)
		{
			return 0;
		}

		public override void NextBytes(byte[] buf)
		{
		}

		public virtual void NextBytes(byte[] buf, int off, int len)
		{
		}

		public override double NextDouble()
		{
			return 0.0;
		}

		public virtual int NextInt()
		{
			return 0;
		}

		public virtual long NextLong()
		{
			return 0L;
		}
	}
}
