using System;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public abstract class McmcSampler<T>
	{
		private System.Random _randomNumberGenerator;

		protected int Accepts;

		protected int Samples;

		public System.Random RandomSource
		{
			get
			{
				return _randomNumberGenerator;
			}
			set
			{
				_randomNumberGenerator = value ?? SystemRandomSource.Default;
			}
		}

		public double AcceptanceRate => (double)Accepts / (double)Samples;

		protected McmcSampler()
		{
			Accepts = 0;
			Samples = 0;
			RandomSource = SystemRandomSource.Default;
		}

		public abstract T Sample();

		public virtual T[] Sample(int n)
		{
			T[] array = new T[n];
			for (int i = 0; i < n; i++)
			{
				array[i] = Sample();
			}
			return array;
		}
	}
}
