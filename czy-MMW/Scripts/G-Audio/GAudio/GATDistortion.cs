using System;
using UnityEngine;

namespace GAudio
{
	public class GATDistortion : AGATMonoFilter, IGATDistortion
	{
		[SerializeField]
		private float _threshold = 0.1f;

		[SerializeField]
		private float _mix = 1f;

		public override Type ControlInterfaceType => typeof(IGATDistortion);

		public float Threshold
		{
			get
			{
				return _threshold;
			}
			set
			{
				if (value <= 0f)
				{
					_threshold = 0.001f;
				}
				else
				{
					_threshold = value;
				}
			}
		}

		public float Mix
		{
			get
			{
				return _mix;
			}
			set
			{
				_mix = value;
			}
		}

		public override int NbOfFilterableChannels => 999;

		public override bool ProcessChunk(float[] data, int fromIndex, int length, bool emptyData)
		{
			if (emptyData)
			{
				return false;
			}
			length += fromIndex;
			for (int i = fromIndex; i < length; i++)
			{
				float num = data[i];
				if (num > Threshold || num < 0f - Threshold)
				{
					data[i] = num * (1f - _mix) + _mix * (Mathf.Abs(Mathf.Abs((num - Threshold) % (Threshold * 4f)) - Threshold * 2f) - Threshold);
				}
			}
			return true;
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
			length += fromIndex;
			for (int i = fromIndex; i < length; i += stride)
			{
				float num = data[i];
				if (num > Threshold || num < 0f - Threshold)
				{
					data[i] = num * (1f - _mix) + _mix * (Mathf.Abs(Mathf.Abs((num - Threshold) % (Threshold * 4f)) - Threshold * 2f) - Threshold);
				}
			}
		}

		public override void ResetFilter()
		{
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("Distortion does not need multi channel wrappers - it can be applied safely to interlaced audio data");
		}

		static GATDistortion()
		{
			AGATMonoFilter.RegisterMonoFilter("Distortion", typeof(GATDistortion));
		}
	}
}
