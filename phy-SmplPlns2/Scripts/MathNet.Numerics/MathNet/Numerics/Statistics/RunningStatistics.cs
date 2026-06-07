using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Statistics
{
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public sealed class RunningStatistics
	{
		[DataMember(Order = 1)]
		private long _n;

		[DataMember(Order = 2)]
		private double _min = double.PositiveInfinity;

		[DataMember(Order = 3)]
		private double _max = double.NegativeInfinity;

		[DataMember(Order = 4)]
		private double _m1;

		[DataMember(Order = 5)]
		private double _m2;

		[DataMember(Order = 6)]
		private double _m3;

		[DataMember(Order = 7)]
		private double _m4;

		public long Count => _n;

		public double Minimum
		{
			get
			{
				if (_n <= 0)
				{
					return double.NaN;
				}
				return _min;
			}
		}

		public double Maximum
		{
			get
			{
				if (_n <= 0)
				{
					return double.NaN;
				}
				return _max;
			}
		}

		public double Mean
		{
			get
			{
				if (_n <= 0)
				{
					return double.NaN;
				}
				return _m1;
			}
		}

		public double Variance
		{
			get
			{
				if (_n >= 2)
				{
					return _m2 / (double)(_n - 1);
				}
				return double.NaN;
			}
		}

		public double PopulationVariance
		{
			get
			{
				if (_n >= 2)
				{
					return _m2 / (double)_n;
				}
				return double.NaN;
			}
		}

		public double StandardDeviation
		{
			get
			{
				if (_n >= 2)
				{
					return Math.Sqrt(_m2 / (double)(_n - 1));
				}
				return double.NaN;
			}
		}

		public double PopulationStandardDeviation
		{
			get
			{
				if (_n >= 2)
				{
					return Math.Sqrt(_m2 / (double)_n);
				}
				return double.NaN;
			}
		}

		public double Skewness
		{
			get
			{
				if (_n >= 3)
				{
					return (double)_n * _m3 * Math.Sqrt(_m2 / (double)(_n - 1)) / (_m2 * _m2 * (double)(_n - 2)) * (double)(_n - 1);
				}
				return double.NaN;
			}
		}

		public double PopulationSkewness
		{
			get
			{
				if (_n >= 2)
				{
					return Math.Sqrt(_n) * _m3 / Math.Pow(_m2, 1.5);
				}
				return double.NaN;
			}
		}

		public double Kurtosis
		{
			get
			{
				if (_n >= 4)
				{
					return ((double)_n * (double)_n - 1.0) / (double)((_n - 2) * (_n - 3)) * ((double)_n * _m4 / (_m2 * _m2) - 3.0 + 6.0 / (double)(_n + 1));
				}
				return double.NaN;
			}
		}

		public double PopulationKurtosis
		{
			get
			{
				if (_n >= 3)
				{
					return (double)_n * _m4 / (_m2 * _m2) - 3.0;
				}
				return double.NaN;
			}
		}

		public RunningStatistics()
		{
		}

		public RunningStatistics(RunningStatistics runningStatistics)
		{
			_n = runningStatistics._n;
			_min = runningStatistics._min;
			_max = runningStatistics._max;
			_m1 = runningStatistics._m1;
			_m2 = runningStatistics._m2;
			_m3 = runningStatistics._m3;
			_m4 = runningStatistics._m4;
		}

		public RunningStatistics(IEnumerable<double> values)
		{
			PushRange(values);
		}

		public void Push(double value)
		{
			_n++;
			double num = value - _m1;
			double num2 = num / (double)_n;
			double num3 = num2 * num2;
			double num4 = num * num2 * (double)(_n - 1);
			_m1 += num2;
			_m4 += num4 * num3 * (double)(_n * _n - 3 * _n + 3) + 6.0 * num3 * _m2 - 4.0 * num2 * _m3;
			_m3 += num4 * num2 * (double)(_n - 2) - 3.0 * num2 * _m2;
			_m2 += num4;
			if (value < _min || double.IsNaN(value))
			{
				_min = value;
			}
			if (value > _max || double.IsNaN(value))
			{
				_max = value;
			}
		}

		public void PushRange(IEnumerable<double> values)
		{
			foreach (double value in values)
			{
				Push(value);
			}
		}

		public static RunningStatistics Combine(RunningStatistics a, RunningStatistics b)
		{
			if (a._n == 0L)
			{
				return new RunningStatistics(b);
			}
			if (b._n == 0L)
			{
				return new RunningStatistics(a);
			}
			long num = a._n + b._n;
			double num2 = b._m1 - a._m1;
			double num3 = num2 * num2;
			double num4 = num3 * num2;
			double num5 = num3 * num3;
			double m = ((double)a._n * a._m1 + (double)b._n * b._m1) / (double)num;
			double m2 = a._m2 + b._m2 + num3 * (double)a._n * (double)b._n / (double)num;
			double m3 = a._m3 + b._m3 + num4 * (double)a._n * (double)b._n * (double)(a._n - b._n) / (double)(num * num) + 3.0 * num2 * ((double)a._n * b._m2 - (double)b._n * a._m2) / (double)num;
			double m4 = a._m4 + b._m4 + num5 * (double)a._n * (double)b._n * (double)(a._n * a._n - a._n * b._n + b._n * b._n) / (double)(num * num * num) + 6.0 * num3 * ((double)(a._n * a._n) * b._m2 + (double)(b._n * b._n) * a._m2) / (double)(num * num) + 4.0 * num2 * ((double)a._n * b._m3 - (double)b._n * a._m3) / (double)num;
			double min = Math.Min(a._min, b._min);
			double max = Math.Max(a._max, b._max);
			return new RunningStatistics
			{
				_n = num,
				_m1 = m,
				_m2 = m2,
				_m3 = m3,
				_m4 = m4,
				_min = min,
				_max = max
			};
		}

		public static RunningStatistics operator +(RunningStatistics a, RunningStatistics b)
		{
			return Combine(a, b);
		}
	}
}
