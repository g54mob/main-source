using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class PoissonDiskSampler
{
	[Serializable]
	public class WeightedDistanceRange
	{
		public int Minimum;

		public int Maximum;

		public int Weight;

		[NonSerialized]
		public int WeightThreshold;
	}

	[SerializeField]
	private int _sampleCount = 1;

	[SerializeField]
	[Range(1f, 1000f)]
	private int _minimumDistance = 50;

	[SerializeField]
	[Range(1f, 1000f)]
	private int _maximumDistance = 100;

	[SerializeField]
	[Range(1f, 100f)]
	protected int _sampleLimit = 30;

	[Header("Weighted Distance Ranges")]
	[SerializeField]
	private bool _useWeightedDistanceRanges;

	[SerializeField]
	private WeightedDistanceRange[] _weightedDistanceRanges;

	private int _weightedDistanceRangesTotalWeight;

	public List<Vector2> Samples { get; private set; }

	public int MinimumDistance { get; private set; }

	public void GenerateSamples()
	{
		GenerateSamples(_sampleCount, _sampleLimit, Vector2.zero);
	}

	public void GenerateSamples(Vector2 origin)
	{
		GenerateSamples(_sampleCount, _sampleLimit, origin);
	}

	protected void GenerateSamples(int sampleCount, int sampleLimit, Vector2 origin)
	{
		if (Samples == null)
		{
			Samples = new List<Vector2>();
		}
		else
		{
			Samples.Clear();
		}
		Samples.Add(origin);
		InitializeWeightedInstances();
		int num = 1;
		int num2 = 0;
		while (num < sampleCount && num2 < 500)
		{
			int num3 = UnityEngine.Random.Range(0, Samples.Count);
			Vector2 vector = Samples[num3];
			for (int i = 0; i < sampleLimit; i++)
			{
				Vector2 vector2 = vector + ReturnRandomOnCircle(ReturnSampleDistance());
				bool flag = false;
				if (!IsValidSample(vector2))
				{
					continue;
				}
				foreach (Vector2 sample in Samples)
				{
					flag = vector2.IsInRange(sample, MinimumDistance);
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					Samples.Add(vector2);
					break;
				}
			}
			if (Samples.Count == num)
			{
				if (num3 != 0)
				{
					Samples.RemoveAt(num3);
					num--;
				}
				num2++;
			}
			else
			{
				num++;
			}
		}
	}

	private void InitializeWeightedInstances()
	{
		if (_useWeightedDistanceRanges)
		{
			_weightedDistanceRangesTotalWeight = 0;
			MinimumDistance = int.MaxValue;
			WeightedDistanceRange[] weightedDistanceRanges = _weightedDistanceRanges;
			foreach (WeightedDistanceRange weightedDistanceRange in weightedDistanceRanges)
			{
				_weightedDistanceRangesTotalWeight += weightedDistanceRange.Weight;
				weightedDistanceRange.WeightThreshold = _weightedDistanceRangesTotalWeight;
				if (weightedDistanceRange.Minimum < MinimumDistance)
				{
					MinimumDistance = weightedDistanceRange.Minimum;
				}
			}
		}
		else
		{
			MinimumDistance = _minimumDistance;
		}
	}

	protected virtual bool IsValidSample(Vector2 sample)
	{
		return true;
	}

	private int ReturnSampleDistance()
	{
		int minInclusive = _minimumDistance;
		int maxExclusive = _maximumDistance;
		if (_useWeightedDistanceRanges)
		{
			int num = UnityEngine.Random.Range(0, _weightedDistanceRangesTotalWeight);
			WeightedDistanceRange[] weightedDistanceRanges = _weightedDistanceRanges;
			foreach (WeightedDistanceRange weightedDistanceRange in weightedDistanceRanges)
			{
				if (num < weightedDistanceRange.WeightThreshold)
				{
					minInclusive = weightedDistanceRange.Minimum;
					maxExclusive = weightedDistanceRange.Maximum;
					break;
				}
			}
		}
		return UnityEngine.Random.Range(minInclusive, maxExclusive);
	}

	private Vector2 ReturnRandomOnCircle(float distance)
	{
		return Quaternion.AngleAxis(UnityEngine.Random.Range(0f, 360f), Vector3.forward) * Vector2.up * distance;
	}
}
