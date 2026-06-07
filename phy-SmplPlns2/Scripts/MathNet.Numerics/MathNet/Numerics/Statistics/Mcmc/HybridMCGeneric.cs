using System;
using MathNet.Numerics.Distributions;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public abstract class HybridMCGeneric<T> : McmcSampler<T>
	{
		public delegate T DiffMethod(DensityLn<T> f, T x);

		private readonly DensityLn<T> _energy;

		protected T Current;

		private int _burnInterval;

		private double _stepSize;

		private int _frogLeapSteps;

		private readonly DiffMethod _diff;

		public int BurnInterval
		{
			get
			{
				return _burnInterval;
			}
			set
			{
				_burnInterval = SetNonNegative(value);
			}
		}

		public int FrogLeapSteps
		{
			get
			{
				return _frogLeapSteps;
			}
			set
			{
				_frogLeapSteps = SetPositive(value);
			}
		}

		public double StepSize
		{
			get
			{
				return _stepSize;
			}
			set
			{
				_stepSize = SetPositive(value);
			}
		}

		protected HybridMCGeneric(T x0, DensityLn<T> pdfLnP, int frogLeapSteps, double stepSize, int burnInterval, System.Random randomSource, DiffMethod diff)
		{
			_energy = (T sample) => 0.0 - pdfLnP(sample);
			FrogLeapSteps = frogLeapSteps;
			StepSize = stepSize;
			BurnInterval = burnInterval;
			Current = x0;
			_diff = diff;
			base.RandomSource = randomSource;
		}

		public override T Sample()
		{
			Burn(_burnInterval + 1);
			return Current;
		}

		protected void Burn(int n)
		{
			T p = Create();
			double e = _energy(Current);
			T gradient = _diff(_energy, Current);
			for (int i = 0; i < n; i++)
			{
				RandomizeMomentum(ref p);
				double num = Hamiltonian(p, e);
				T mNew = Copy(Current);
				T gNew = Copy(gradient);
				for (int j = 0; j < _frogLeapSteps; j++)
				{
					HamiltonianEquations(ref gNew, ref mNew, ref p);
				}
				double num2 = _energy(mNew);
				double dh = Hamiltonian(p, num2) - num;
				Update(ref e, ref gradient, mNew, gNew, num2, dh);
				Samples++;
			}
		}

		protected void Update(ref double e, ref T gradient, T mNew, T gNew, double enew, double dh)
		{
			if (dh <= 0.0)
			{
				Current = mNew;
				gradient = gNew;
				e = enew;
				Accepts++;
			}
			else if (Bernoulli.Sample(base.RandomSource, Math.Exp(0.0 - dh)) == 1)
			{
				Current = mNew;
				gradient = gNew;
				e = enew;
				Accepts++;
			}
		}

		protected abstract T Create();

		protected abstract T Copy(T source);

		protected abstract double DoProduct(T first, T second);

		protected abstract void DoAdd(ref T first, double factor, T second);

		protected abstract void DoSubtract(ref T first, double factor, T second);

		protected abstract void RandomizeMomentum(ref T p);

		protected void HamiltonianEquations(ref T gNew, ref T mNew, ref T p)
		{
			DoSubtract(ref p, _stepSize / 2.0, gNew);
			DoAdd(ref mNew, _stepSize, p);
			gNew = _diff(_energy, mNew);
			DoSubtract(ref p, _stepSize / 2.0, gNew);
		}

		protected double Hamiltonian(T momentum, double e)
		{
			return e + DoProduct(momentum, momentum) / 2.0;
		}

		protected int SetNonNegative(int value)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", "Value must not be negative (zero is ok).");
			}
			return value;
		}

		protected int SetPositive(int value)
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException("value", "Value must not be negative (zero is ok).");
			}
			return value;
		}

		protected double SetPositive(double value)
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value", "Value must not be negative (zero is ok).");
			}
			return value;
		}
	}
}
