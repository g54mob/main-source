using System;
using MathNet.Numerics.Distributions;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public class MetropolisHastingsSampler<T> : McmcSampler<T>
	{
		private readonly DensityLn<T> _pdfLnP;

		private readonly TransitionKernelLn<T> _krnlQ;

		private readonly LocalProposalSampler<T> _proposal;

		private T _current;

		private double _currentDensityLn;

		private int _burnInterval;

		public int BurnInterval
		{
			get
			{
				return _burnInterval;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Value must not be negative (zero is ok).");
				}
				_burnInterval = value;
			}
		}

		public MetropolisHastingsSampler(T x0, DensityLn<T> pdfLnP, TransitionKernelLn<T> krnlQ, LocalProposalSampler<T> proposal, int burnInterval = 0)
		{
			_current = x0;
			_currentDensityLn = pdfLnP(x0);
			_pdfLnP = pdfLnP;
			_krnlQ = krnlQ;
			_proposal = proposal;
			BurnInterval = burnInterval;
			Burn(BurnInterval);
		}

		private void Burn(int n)
		{
			for (int i = 0; i < n; i++)
			{
				T val = _proposal(_current);
				double num = _pdfLnP(val);
				double num2 = _krnlQ(val, _current);
				double num3 = _krnlQ(_current, val);
				Samples++;
				double num4 = Math.Min(0.0, num + num3 - _currentDensityLn - num2);
				if (num4 == 0.0)
				{
					_current = val;
					_currentDensityLn = num;
					Accepts++;
				}
				else if (Bernoulli.Sample(base.RandomSource, Math.Exp(num4)) == 1)
				{
					_current = val;
					_currentDensityLn = num;
					Accepts++;
				}
			}
		}

		public override T Sample()
		{
			Burn(BurnInterval + 1);
			return _current;
		}
	}
}
