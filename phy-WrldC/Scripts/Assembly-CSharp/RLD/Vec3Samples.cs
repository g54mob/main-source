using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class Vec3Samples
	{
		private int _maxNumSamples = 2;

		private List<Vector3> _samples = new List<Vector3>();

		public int NumSamples => _samples.Count;

		public int MaxNumSamples => _maxNumSamples;

		public void AddSample(Vector3 sample)
		{
			if (NumSamples < MaxNumSamples)
			{
				_samples.Insert(0, sample);
				return;
			}
			for (int i = 0; i < NumSamples - 1; i++)
			{
				_samples[i + 1] = _samples[i];
			}
			_samples[0] = sample;
		}

		public void SetMaxNumSamples(int maxNumSamples)
		{
			if (maxNumSamples != MaxNumSamples && maxNumSamples < NumSamples)
			{
				int num = maxNumSamples - NumSamples;
				for (int i = 0; i < num; i++)
				{
					_samples.RemoveAt(_samples.Count - 1);
				}
			}
		}

		public Vector3 GetAverage()
		{
			Vector3 zero = Vector3.zero;
			foreach (Vector3 sample in _samples)
			{
				zero += sample;
			}
			return zero.normalized;
		}
	}
}
