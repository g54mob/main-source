using System;
using UnityEngine;

namespace GAudio
{
	public class GATAudialSaturator : AGATMonoFilter, IGATAudialSaturator
	{
		[SerializeField]
		private float _inputGain = 1f;

		[SerializeField]
		private float _threshold = 0.247f;

		[SerializeField]
		public float _amount = 0.5f;

		public override Type ControlInterfaceType => typeof(IGATAudialSaturator);

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
					_threshold = Mathf.Clamp(value, 0f, 1f);
				}
			}
		}

		public float Amount
		{
			get
			{
				return _amount;
			}
			set
			{
				if (_amount != value)
				{
					_amount = Mathf.Clamp(value, 0f, 1f);
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
				float num = data[i] * InGain;
				float num2 = Mathf.Abs(num);
				float num3 = Mathf.Sign(num);
				if (num2 > 1f)
				{
					num = (Thresh + 1f) / 2f * num3;
				}
				else if (num2 > Thresh)
				{
					num = (Thresh + (num2 - Thresh) / (1f + Mathf.Pow((num2 - Thresh) / (1f - Amount), 2f))) * num3;
				}
				data[i] = num;
			}
			return true;
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
			length += fromIndex;
			for (int i = fromIndex; i < length; i += stride)
			{
				float num = data[i] * InGain;
				float num2 = Mathf.Abs(num);
				float num3 = Mathf.Sign(num);
				if (num2 > 1f)
				{
					num = (Thresh + 1f) / 2f * num3;
				}
				else if (num2 > Thresh)
				{
					num = (Thresh + (num2 - Thresh) / (1f + Mathf.Pow((num2 - Thresh) / (1f - Amount), 2f))) * num3;
				}
				data[i] = num;
			}
		}

		public override void ResetFilter()
		{
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("Saturator does not need multi channel wrappers - it can be applied safely to interlaced audio data");
		}

		static GATAudialSaturator()
		{
			AGATMonoFilter.RegisterMonoFilter("Audial > Saturator", typeof(GATAudialSaturator));
		}
	}
}
