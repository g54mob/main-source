using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Statistics
{
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public class RunningWeightedStatistics
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

		[DataMember(Order = 8)]
		private double _w1;

		[DataMember(Order = 9)]
		private double _w2;

		[DataMember(Order = 10)]
		private double _w3;

		[DataMember(Order = 11)]
		private double _w4;

		[DataMember(Order = 12)]
		private double _den;

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
					return _m2 / _den;
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
					return _m2 / _w1;
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
					return Math.Sqrt(_m2 / _den);
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
					return Math.Sqrt(_m2 / _w1);
				}
				return double.NaN;
			}
		}

		public double Skewness
		{
			get
			{
				if (_n < 3)
				{
					return double.NaN;
				}
				double num = (_w1 * (_w1 * _w1 - 3.0 * _w2) + 2.0 * _w3) / (_w1 * _w1);
				return _m3 / (num * Math.Pow(_m2 / _den, 1.5));
			}
		}

		public double PopulationSkewness
		{
			get
			{
				if (_n >= 2)
				{
					return _m3 * Math.Sqrt(_w1) / Math.Pow(_m2, 1.5);
				}
				return double.NaN;
			}
		}

		public double Kurtosis
		{
			get
			{
				if (_n < 4)
				{
					return double.NaN;
				}
				double num = _w1 * _w1;
				double num2 = num * num;
				double num3 = _w2 * _w2;
				double num4 = num2 - 6.0 * num * _w2 + 8.0 * _w1 * _w3 + 3.0 * num3 - 6.0 * _w4;
				double num5 = num2 - 4.0 * _w1 * _w3 + 3.0 * num3;
				double num6 = 3.0 * (num2 - 2.0 * num * _w2 + 4.0 * _w1 * _w3 - 3.0 * num3);
				return (num5 * _w1 * _m4 / (_m2 * _m2) - num6) * (_den / (_w1 * num4));
			}
		}

		public double PopulationKurtosis
		{
			get
			{
				if (_n >= 3)
				{
					return _w1 * _m4 / (_m2 * _m2) - 3.0;
				}
				return double.NaN;
			}
		}

		public double TotalWeight => _w1;

		public double EffectiveSampleSize => _w2 / _w1;

		public RunningWeightedStatistics()
		{
		}

		public RunningWeightedStatistics(IEnumerable<Tuple<double, double>> values)
		{
			PushRange(values);
		}

		public void Push(double weight, double value)
		{
			if (weight != 0.0)
			{
				if (weight < 0.0)
				{
					throw new ArgumentOutOfRangeException("weight", weight, "Expected non-negative weighting of sample");
				}
				_n++;
				double w = _w1;
				double num = weight;
				_w1 += num;
				num *= weight;
				_w2 += num;
				num *= weight;
				_w3 += num;
				num *= weight;
				_w4 += num;
				_den += weight * (2.0 * w - _den) / _w1;
				double num2 = value - _m1;
				double num3 = num2 * weight / _w1;
				double num4 = num3 * num3;
				double num5 = num2 * num3 * w;
				_m1 += num3;
				double num6 = w / weight;
				_m4 += num5 * num4 * (num6 * num6 + 1.0 - num6) + 6.0 * num4 * _m2 - 4.0 * num3 * _m3;
				_m3 += num5 * num3 * (num6 - 1.0) - 3.0 * num3 * _m2;
				_m2 += num5;
				if (value < _min || double.IsNaN(value))
				{
					_min = value;
				}
				if (value > _max || double.IsNaN(value))
				{
					_max = value;
				}
			}
		}

		public void PushRange(IEnumerable<Tuple<double, double>> values)
		{
			foreach (Tuple<double, double> value in values)
			{
				Push(value.Item1, value.Item2);
			}
		}

		public void PushRange(IEnumerable<double> weights, IEnumerable<double> values)
		{
			using IEnumerator<double> enumerator = weights.GetEnumerator();
			using IEnumerator<double> enumerator2 = values.GetEnumerator();
			bool flag = enumerator.MoveNext();
			for (bool flag2 = enumerator2.MoveNext(); flag2 && flag; flag2 = enumerator2.MoveNext())
			{
				if (flag2 != flag)
				{
					throw new ArgumentException("Weights and values need to be same length", "values");
				}
				Push(enumerator.Current, enumerator2.Current);
				flag = enumerator.MoveNext();
			}
		}

		public static RunningWeightedStatistics Combine(RunningWeightedStatistics a, RunningWeightedStatistics b)
		{
			if (a._n == 0L)
			{
				return b;
			}
			if (b._n == 0L)
			{
				return a;
			}
			long n = a._n + b._n;
			double num = a._w1 + b._w1;
			double w = a._w2 + b._w2;
			double w2 = a._w3 + b._w3;
			double w3 = a._w4 + b._w4;
			double num2 = b._m1 - a._m1;
			double num3 = num2 * num2;
			double num4 = num3 * num2;
			double num5 = num3 * num3;
			double m = (a._w1 * a._m1 + b._w1 * b._m1) / num;
			double m2 = a._m2 + b._m2 + num3 * a._w1 * b._w1 / num;
			double m3 = a._m3 + b._m3 + num4 * a._w1 * b._w1 * (a._w1 - b._w1) / (num * num) + 3.0 * num2 * (a._w1 * b._m2 - b._w1 * a._m2) / num;
			double m4 = a._m4 + b._m4 + num5 * a._w1 * b._w1 * (a._w1 * a._w1 - a._w1 * b._w1 + b._w1 * b._w1) / (num * num * num) + 6.0 * num3 * (a._w1 * a._w1 * b._m2 + b._w1 * b._w1 * a._m2) / (num * num) + 4.0 * num2 * (a._w1 * b._m3 - b._w1 * a._m3) / num;
			double min = Math.Min(a._min, b._min);
			double max = Math.Max(a._max, b._max);
			double den = num - ((a._w1 - a._den) * a._w1 + (b._w1 - b._den) * b._w1) / num;
			return new RunningWeightedStatistics
			{
				_n = n,
				_m1 = m,
				_m2 = m2,
				_m3 = m3,
				_m4 = m4,
				_min = min,
				_max = max,
				_w1 = num,
				_den = den,
				_w2 = w,
				_w3 = w2,
				_w4 = w3
			};
		}

		public static RunningWeightedStatistics operator +(RunningWeightedStatistics a, RunningWeightedStatistics b)
		{
			return Combine(a, b);
		}
	}
}
