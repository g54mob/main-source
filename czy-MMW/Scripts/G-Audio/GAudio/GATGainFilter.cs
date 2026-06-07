using System;
using UnityEngine;

namespace GAudio
{
	public class GATGainFilter : AGATMonoFilter, IGATGainFilter
	{
		[SerializeField]
		protected float _gain = 1f;

		[SerializeField]
		protected bool _clip;

		[SerializeField]
		protected float _clipThreshold = 1f;

		protected int _nbOfClippedSamples;

		protected float _negThreshold;

		public float Gain
		{
			get
			{
				return _gain;
			}
			set
			{
				_gain = value;
			}
		}

		public bool Clip
		{
			get
			{
				return _clip;
			}
			set
			{
				if (value != _clip)
				{
					_clip = value;
					if (!value)
					{
						_nbOfClippedSamples = 0;
					}
				}
			}
		}

		public float Threshold
		{
			get
			{
				return _clipThreshold;
			}
			set
			{
				if (value != _clipThreshold)
				{
					_clipThreshold = value;
					_negThreshold = 0f - value;
				}
			}
		}

		public int NbOfClippedSamples => _nbOfClippedSamples;

		public override Type ControlInterfaceType => typeof(IGATGainFilter);

		public override int NbOfFilterableChannels => 1000;

		static GATGainFilter()
		{
			AGATMonoFilter.RegisterMonoFilter("Gain and Clip", typeof(GATGainFilter));
		}

		public override void ResetFilter()
		{
			_nbOfClippedSamples = 0;
		}

		public override bool ProcessChunk(float[] data, int fromIndex, int length, bool emptyData)
		{
			if (emptyData)
			{
				return false;
			}
			int num = 0;
			if (_gain != 1f)
			{
				for (int i = fromIndex; i < data.Length; i++)
				{
					data[i] *= _gain;
				}
			}
			if (_clip)
			{
				for (int i = fromIndex; i < data.Length; i++)
				{
					if (data[i] > _clipThreshold)
					{
						data[i] = _clipThreshold;
						num++;
					}
					else if (data[i] < _negThreshold)
					{
						data[i] = _negThreshold;
						num++;
					}
				}
				_nbOfClippedSamples = num;
			}
			return true;
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
			throw new GATException("Not implemented");
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("Not implemented and not needed");
		}

		protected virtual void OnEnable()
		{
			_negThreshold = 0f - _clipThreshold;
		}
	}
}
