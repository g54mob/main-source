using System;
using UnityEngine;

namespace GAudio
{
	public class GATAudialDistortion : AGATMonoFilter, IGATAudialDistortion
	{
		[SerializeField]
		private float _inputGain = 1f;

		[SerializeField]
		private float _threshold = 0.036f;

		[SerializeField]
		private float _dryWet = 0.258f;

		[SerializeField]
		private float _outputGain = 1f;

		public override Type ControlInterfaceType => typeof(IGATAudialDistortion);

		public float InGain
		{
			get
			{
				return _inputGain;
			}
			set
			{
				if (_inputGain != value)
				{
					_inputGain = Mathf.Clamp(value, 0f, 3f);
				}
			}
		}

		public float Thresh
		{
			get
			{
				return _threshold;
			}
			set
			{
				if (_threshold != value)
				{
					_threshold = Mathf.Clamp(value, 1E-05f, 1f);
				}
			}
		}

		public float DryWet
		{
			get
			{
				return _dryWet;
			}
			set
			{
				if (_dryWet != value)
				{
					_dryWet = Mathf.Clamp(value, 0f, 1f);
				}
			}
		}

		public float OutGain
		{
			get
			{
				return _outputGain;
			}
			set
			{
				if (_outputGain != value)
				{
					_outputGain = Mathf.Clamp(value, 0f, 5f);
				}
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
				num *= InGain;
				float num2 = num;
				if (Mathf.Abs(num2) > Thresh)
				{
					num2 = Mathf.Sign(num2);
				}
				data[i] = ((1f - DryWet) * num + DryWet * num2) * OutGain;
			}
			return true;
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
			length += fromIndex;
			for (int i = fromIndex; i < length; i += stride)
			{
				float num = data[i];
				num *= InGain;
				float num2 = num;
				if (Mathf.Abs(num2) > Thresh)
				{
					num2 = Mathf.Sign(num2);
				}
				data[i] = ((1f - DryWet) * num + DryWet * num2) * OutGain;
			}
		}

		public override void ResetFilter()
		{
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("Distortion does not need multi channel wrappers - it can be applied safely to interlaced audio data");
		}

		static GATAudialDistortion()
		{
			AGATMonoFilter.RegisterMonoFilter("Audial > Distortion", typeof(GATAudialDistortion));
		}
	}
}
