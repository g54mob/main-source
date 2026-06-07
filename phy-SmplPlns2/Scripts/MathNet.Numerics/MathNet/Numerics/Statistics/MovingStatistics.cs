using System;
using System.Collections.Generic;

namespace MathNet.Numerics.Statistics
{
	public class MovingStatistics
	{
		private readonly double[] _oldValues;

		private readonly int _windowSize;

		private long _count;

		private long _totalCountOffset;

		private int _lastIndex;

		private int _lastNaNTimeToLive;

		private int _lastPosInfTimeToLive;

		private int _lastNegInfTimeToLive;

		private double _m1;

		private double _m2;

		private double _max = double.NegativeInfinity;

		private double _min = double.PositiveInfinity;

		public int WindowSize => _windowSize;

		public long Count => _totalCountOffset + _count;

		public double Minimum
		{
			get
			{
				if (_lastNaNTimeToLive > 0)
				{
					return double.NaN;
				}
				if (_lastNegInfTimeToLive > 0)
				{
					return double.NegativeInfinity;
				}
				if (_count <= 0 && _lastPosInfTimeToLive <= 0)
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
				if (_lastNaNTimeToLive > 0)
				{
					return double.NaN;
				}
				if (_lastPosInfTimeToLive > 0)
				{
					return double.PositiveInfinity;
				}
				if (_count <= 0 && _lastNegInfTimeToLive <= 0)
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
				if (_lastNaNTimeToLive > 0 || (_lastPosInfTimeToLive > 0 && _lastNegInfTimeToLive > 0))
				{
					return double.NaN;
				}
				if (_lastPosInfTimeToLive > 0)
				{
					return double.PositiveInfinity;
				}
				if (_lastNegInfTimeToLive > 0)
				{
					return double.NegativeInfinity;
				}
				if (_count != 0L)
				{
					return _m1;
				}
				return double.NaN;
			}
		}

		public double Variance
		{
			get
			{
				if (_lastNaNTimeToLive > 0 || _lastNegInfTimeToLive > 0)
				{
					return double.NaN;
				}
				if (_lastPosInfTimeToLive > 0)
				{
					return double.PositiveInfinity;
				}
				if (_count >= 2)
				{
					return _m2 / (double)(_count - 1);
				}
				return double.NaN;
			}
		}

		public double PopulationVariance
		{
			get
			{
				if (_lastNaNTimeToLive > 0 || _lastNegInfTimeToLive > 0)
				{
					return double.NaN;
				}
				if (_lastPosInfTimeToLive > 0)
				{
					return double.PositiveInfinity;
				}
				if (_count >= 2)
				{
					return _m2 / (double)_count;
				}
				return double.NaN;
			}
		}

		public double StandardDeviation
		{
			get
			{
				if (_lastNaNTimeToLive > 0 || _lastNegInfTimeToLive > 0)
				{
					return double.NaN;
				}
				if (_lastPosInfTimeToLive > 0)
				{
					return double.PositiveInfinity;
				}
				if (_count >= 2)
				{
					return Math.Sqrt(_m2 / (double)(_count - 1));
				}
				return double.NaN;
			}
		}

		public double PopulationStandardDeviation
		{
			get
			{
				if (_lastNaNTimeToLive > 0 || _lastNegInfTimeToLive > 0)
				{
					return double.NaN;
				}
				if (_lastPosInfTimeToLive > 0)
				{
					return double.PositiveInfinity;
				}
				if (_count >= 2)
				{
					return Math.Sqrt(_m2 / (double)_count);
				}
				return double.NaN;
			}
		}

		public MovingStatistics(int windowSize)
		{
			if (windowSize < 1)
			{
				throw new ArgumentException("Value must be positive.", "windowSize");
			}
			_windowSize = windowSize;
			_oldValues = new double[_windowSize];
		}

		public MovingStatistics(int windowSize, IEnumerable<double> values)
			: this(windowSize)
		{
			PushRange(values);
		}

		public void Push(double value)
		{
			DecrementTimeToLive();
			if (double.IsNaN(value))
			{
				_lastNaNTimeToLive = _windowSize;
				Reset(double.PositiveInfinity, double.NegativeInfinity);
				return;
			}
			if (double.IsPositiveInfinity(value))
			{
				_lastPosInfTimeToLive = _windowSize;
				Reset(_min, double.NegativeInfinity);
				return;
			}
			if (double.IsNegativeInfinity(value))
			{
				_lastNegInfTimeToLive = _windowSize;
				Reset(double.PositiveInfinity, _max);
				return;
			}
			if (_count < _windowSize)
			{
				_oldValues[_count] = value;
				_count++;
				double num = value - _m1;
				double num2 = num / (double)_count;
				double num3 = num * num2 * (double)(_count - 1);
				_m1 += num2;
				_m2 += num3;
				if (value < _min)
				{
					_min = value;
				}
				if (value > _max)
				{
					_max = value;
				}
				return;
			}
			double num4 = _oldValues[_lastIndex];
			double num5 = value - num4;
			double num6 = num5 / (double)_count;
			double m = _m1;
			_m1 += num6;
			double num7 = value - _m1 + num4 - m;
			double num8 = num5 * num7;
			_m2 += num8;
			_oldValues[_lastIndex] = value;
			_lastIndex++;
			if (_lastIndex == WindowSize)
			{
				_lastIndex = 0;
			}
			_max = ((value > _max) ? value : _oldValues.Maximum());
			_min = ((value < _min) ? value : _oldValues.Minimum());
		}

		public void PushRange(IEnumerable<double> values)
		{
			foreach (double value in values)
			{
				Push(value);
			}
		}

		private void DecrementTimeToLive()
		{
			if (_lastNaNTimeToLive > 0)
			{
				_lastNaNTimeToLive--;
			}
			if (_lastPosInfTimeToLive > 0)
			{
				_lastPosInfTimeToLive--;
			}
			if (_lastNegInfTimeToLive > 0)
			{
				_lastNegInfTimeToLive--;
			}
		}

		private void Reset(double min, double max)
		{
			_totalCountOffset += _count + 1;
			_count = 0L;
			_m1 = 0.0;
			_max = max;
			_min = min;
		}
	}
}
