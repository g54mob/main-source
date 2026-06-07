using System;
using UnityEngine;

namespace GAudio
{
	[Serializable]
	public class PatternSample
	{
		[SerializeField]
		private string _sampleName;

		[SerializeField]
		private float _pitch;

		[SerializeField]
		private float _semiTones;

		[SerializeField]
		private float _gain = 1f;

		private IGATProcessedSample _processedSample;

		public string SampleName
		{
			get
			{
				return _sampleName;
			}
			set
			{
				if (!(_sampleName == value))
				{
					_sampleName = value;
					ProcessedSample = null;
				}
			}
		}

		public float Pitch
		{
			get
			{
				return _pitch;
			}
			set
			{
				if (_pitch != value)
				{
					_pitch = value;
					ProcessedSample = null;
				}
			}
		}

		public float SemiTones
		{
			get
			{
				return _semiTones;
			}
			set
			{
				if (_semiTones != value)
				{
					_semiTones = value;
					Pitch = GATMaths.GetRatioForInterval(value);
					ProcessedSample = null;
				}
			}
		}

		public float Gain
		{
			get
			{
				return _gain;
			}
			set
			{
				if (_gain != value)
				{
					_gain = value;
				}
			}
		}

		public IGATProcessedSample ProcessedSample
		{
			get
			{
				return _processedSample;
			}
			set
			{
				if (_processedSample != null)
				{
					_processedSample.Release();
				}
				_processedSample = value;
				value?.Retain();
			}
		}

		public PatternSample(string sampleName, float gain = 1f, int semiTones = 0)
		{
			_sampleName = sampleName;
			_gain = gain;
			_semiTones = semiTones;
			_pitch = GATMaths.GetRatioForInterval(semiTones);
		}
	}
}
