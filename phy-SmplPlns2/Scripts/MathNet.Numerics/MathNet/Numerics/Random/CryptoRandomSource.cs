using System;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;

namespace MathNet.Numerics.Random
{
	public sealed class CryptoRandomSource : RandomSource, IDisposable
	{
		private const double Reciprocal = 2.3283064365386963E-10;

		private readonly RandomNumberGenerator _crypto;

		public CryptoRandomSource()
		{
			_crypto = RandomNumberGenerator.Create();
		}

		public CryptoRandomSource(RandomNumberGenerator rng)
		{
			_crypto = rng;
		}

		public CryptoRandomSource(bool threadSafe)
			: base(threadSafe)
		{
			_crypto = RandomNumberGenerator.Create();
		}

		public CryptoRandomSource(RandomNumberGenerator rng, bool threadSafe)
			: base(threadSafe)
		{
			_crypto = rng;
		}

		protected override void DoSampleBytes(byte[] buffer)
		{
			_crypto.GetBytes(buffer);
		}

		protected override double DoSample()
		{
			byte[] array = new byte[4];
			_crypto.GetBytes(array);
			return (double)BitConverter.ToUInt32(array, 0) * 2.3283064365386963E-10;
		}

		protected override int DoSampleInteger()
		{
			byte[] array = new byte[4];
			_crypto.GetBytes(array);
			int num = (int)(BitConverter.ToUInt32(array, 0) >> 1);
			if (num == int.MaxValue)
			{
				return DoSampleInteger();
			}
			return num;
		}

		public void Dispose()
		{
			_crypto.Dispose();
		}

		public static void Doubles(double[] values)
		{
			byte[] array = new byte[values.Length * 4];
			using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
			{
				randomNumberGenerator.GetBytes(array);
			}
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = (double)BitConverter.ToUInt32(array, i * 4) * 2.3283064365386963E-10;
			}
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double[] Doubles(int length)
		{
			double[] array = new double[length];
			Doubles(array);
			return array;
		}

		public static IEnumerable<double> DoubleSequence()
		{
			RandomNumberGenerator rnd = RandomNumberGenerator.Create();
			byte[] buffer = new byte[4096];
			while (true)
			{
				rnd.GetBytes(buffer);
				for (int i = 0; i < buffer.Length; i += 4)
				{
					yield return (double)BitConverter.ToUInt32(buffer, i) * 2.3283064365386963E-10;
				}
			}
		}
	}
}
