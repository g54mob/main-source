using System;
using UnityEngine;

namespace Assets.Scripts.Terrain.Diagnostics
{
	[Serializable]
	public class QuadGenerationPerformanceMetric
	{
		[SerializeField]
		private double _average;

		[SerializeField]
		private double _max;

		[SerializeField]
		private double _min;

		[SerializeField]
		private double _percentageOfTotal;

		[SerializeField]
		private long _samples;

		[SerializeField]
		private double _totalTime;

		public double Average => _average;

		public double Max => _max;

		public double Min => _min;

		public double PercentageOfTotal => _percentageOfTotal;

		public long Samples => _samples;

		public double TotalTime => _totalTime;

		public QuadGenerationPerformanceMetric()
		{
			_min = double.MaxValue;
		}

		public void Update(double time, double totalTime)
		{
			_samples++;
			_totalTime += time;
			_average = _totalTime / (double)_samples;
			_min = Mathd.Min(_min, time);
			_max = Mathd.Max(_max, time);
			_percentageOfTotal = (float)(int)(_totalTime / totalTime * 10000.0) / 100f;
		}
	}
}
