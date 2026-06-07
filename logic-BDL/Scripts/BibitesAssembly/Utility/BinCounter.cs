using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
	public class BinCounter
	{
		private long[] _bins;

		public IList<long> Bins;

		private float _rangeMin;

		private float _rangeMax;

		private long _countBelowRangeMin;

		private long _countAboveRangeMax;

		private float _minObservation = float.NaN;

		private float _maxObservation = float.NaN;

		private int _numBins;

		private float _binSize;

		private long _totalObservations;

		private double _runningSum;

		public float RangeMin => _rangeMin;

		public float RangeMax => _rangeMax;

		public long CountBelowRangeMin => _countBelowRangeMin;

		public long CountAboveRangeMax => _countAboveRangeMax;

		public float MinObservation => _minObservation;

		public float MaxObservation => _maxObservation;

		public int NumBins => _numBins;

		public float BinSize => _binSize;

		public long TotalObservations => _totalObservations;

		public bool IsFull => _totalObservations == long.MaxValue;

		public float Mean => (float)_runningSum / (float)TotalObservations;

		public BinCounter(int numBins, float rangeMin, float rangeMax)
		{
			_bins = new long[numBins];
			Bins = Array.AsReadOnly(_bins);
			_numBins = numBins;
			_rangeMin = rangeMin;
			_rangeMax = rangeMax;
			_binSize = (_rangeMax - rangeMin) / (float)_numBins;
		}

		public void Log(double observation, long count = 1L)
		{
			Log((float)observation, count);
		}

		public void Log(float observation, long count = 1L)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count", "Count must be positive.");
			}
			if (!float.IsNaN(observation) && !IsFull)
			{
				if (long.MaxValue - TotalObservations < count)
				{
					count = long.MaxValue - TotalObservations;
				}
				if (float.IsNaN(_minObservation) || observation < _minObservation)
				{
					_minObservation = observation;
				}
				if (float.IsNaN(_maxObservation) || observation > _maxObservation)
				{
					_maxObservation = observation;
				}
				_runningSum += (float)count * observation;
				int num;
				if (observation < _rangeMin)
				{
					num = 0;
					_countBelowRangeMin += count;
				}
				else if (observation > _rangeMax)
				{
					num = _numBins - 1;
					_countAboveRangeMax += count;
				}
				else
				{
					num = (int)((observation - _rangeMin) / _binSize);
					num = Math.Min(num, NumBins - 1);
				}
				_bins[num] += count;
				_totalObservations += count;
			}
		}

		public string GetHistogram(bool includeStats = true)
		{
			if (TotalObservations == 0L)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			long num = 0L;
			long num2 = 0L;
			long num3 = 0L;
			long num4 = TotalObservations / 2;
			for (int i = 0; i < NumBins; i++)
			{
				if (Bins[i] > num)
				{
					num = Bins[i];
				}
				if (num2 < num4 && num2 + Bins[i] >= num4)
				{
					num3 = i;
				}
				num2 += Bins[i];
			}
			if (includeStats)
			{
				stringBuilder.AppendLine($"TotalEntries: {TotalObservations}");
				stringBuilder.AppendLine($"CountBelowRangeMin: {CountBelowRangeMin}");
				stringBuilder.AppendLine($"CountAboveRangeMax: {CountAboveRangeMax}");
				float num5 = RangeMin + (float)num3 * BinSize;
				float num6 = num5 + BinSize;
				stringBuilder.AppendLine($"MedianBinIdx: {num3}");
				stringBuilder.AppendLine($"MedianBinRange: {num5,4:F3}<->{num6,4:F3}");
				stringBuilder.AppendLine($"MinObservation: {MinObservation,4:F3}");
				stringBuilder.AppendLine($"MaxObservation: {MaxObservation,4:F3}");
				stringBuilder.AppendLine($"Mean: {Mean,4:F3}");
			}
			for (int j = 0; j < NumBins; j++)
			{
				float num7 = RangeMin + (float)j * BinSize;
				float num8 = num7 + BinSize;
				if (j == 0)
				{
					stringBuilder.Append($"<--{num7,9:F2}--<={num8,-12:F2}");
				}
				else if (j == NumBins - 1)
				{
					stringBuilder.Append($"{num7,12:F2}--<={num8,-12:F2}-->");
				}
				else
				{
					stringBuilder.Append($"{num7,12:F2}--<={num8,-12:F2}");
				}
				stringBuilder.Append($"\t:\t{Bins[j],-10} ");
				stringBuilder.Append('*', (int)(100f * ((float)Bins[j] / (float)num)));
				stringBuilder.Append('\n');
			}
			return stringBuilder.ToString();
		}

		public void Reset()
		{
			Array.Clear(_bins, 0, _bins.Length);
			_countAboveRangeMax = 0L;
			_countBelowRangeMin = 0L;
			_minObservation = float.NaN;
			_maxObservation = float.NaN;
			_runningSum = 0.0;
			_totalObservations = 0L;
		}
	}
}
