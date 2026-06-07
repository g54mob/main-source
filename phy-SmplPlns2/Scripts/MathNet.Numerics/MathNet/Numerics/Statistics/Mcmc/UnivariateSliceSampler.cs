using System;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public class UnivariateSliceSampler : McmcSampler<double>
	{
		private readonly DensityLn<double> _pdfLnP;

		private double _current;

		private double _currentDensityLn;

		private int _burnInterval;

		private double _scale;

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

		public double Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				if (value <= 0.0)
				{
					throw new ArgumentException("Value must be positive (and not zero).");
				}
				_scale = value;
			}
		}

		public UnivariateSliceSampler(double x0, DensityLn<double> pdfLnP, double scale)
			: this(x0, pdfLnP, 0, scale)
		{
		}

		public UnivariateSliceSampler(double x0, DensityLn<double> pdfLnP, int burnInterval, double scale)
		{
			_current = x0;
			_currentDensityLn = pdfLnP(x0);
			_pdfLnP = pdfLnP;
			Scale = scale;
			BurnInterval = burnInterval;
			Burn(BurnInterval);
		}

		private void Burn(int n)
		{
			for (int i = 0; i < n; i++)
			{
				double num = Math.Log(base.RandomSource.NextDouble()) + _currentDensityLn;
				double num2 = base.RandomSource.NextDouble();
				double num3 = _current - num2 * Scale;
				double num4 = _current + (1.0 - num2) * Scale;
				while (_pdfLnP(num3) > num)
				{
					num3 -= Scale;
				}
				for (; _pdfLnP(num4) > num; num4 += Scale)
				{
				}
				double num5;
				while (true)
				{
					num5 = base.RandomSource.NextDouble() * (num4 - num3) + num3;
					_currentDensityLn = _pdfLnP(num5);
					if (_currentDensityLn > num)
					{
						break;
					}
					if (num5 > _current)
					{
						num4 = num5;
					}
					else
					{
						num3 = num5;
					}
				}
				_current = num5;
				Accepts++;
				Samples++;
			}
		}

		public override double Sample()
		{
			Burn(BurnInterval + 1);
			return _current;
		}
	}
}
