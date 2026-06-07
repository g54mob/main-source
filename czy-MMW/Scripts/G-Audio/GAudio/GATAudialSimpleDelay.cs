using System;
using UnityEngine;

namespace GAudio
{
	public class GATAudialSimpleDelay : AGATMonoFilter, IGATAudialSimpleDelay
	{
		private float sampleFrequency;

		private float[] delayBuffer;

		private int index;

		[Range(10f, 3000f)]
		[SerializeField]
		private float _delayLengthMS = 120f;

		[Range(0f, 1f)]
		[SerializeField]
		private float _dryWet = 0.5f;

		[Range(0.1f, 1f)]
		[SerializeField]
		private float _decayLength = 0.25f;

		private int delaySamples;

		private float output;

		private bool _processingEmptyData = true;

		private double _emptyTargetTime;

		private float totalDelayDuration;

		public override Type ControlInterfaceType => typeof(IGATAudialSimpleDelay);

		public float DelayMS
		{
			get
			{
				return _delayLengthMS;
			}
			set
			{
				if (_delayLengthMS != value)
				{
					_delayLengthMS = Mathf.Clamp(value, 10f, 3000f);
					ChangeDelay();
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

		public float Decay
		{
			get
			{
				return _decayLength;
			}
			set
			{
				if (_decayLength != value)
				{
					_decayLength = Mathf.Clamp(value, 0.1f, 1f);
					ChangeDuration();
				}
			}
		}

		public override int NbOfFilterableChannels => 1;

		private void OnEnable()
		{
			sampleFrequency = GATInfo.OutputSampleRate;
			ChangeDelay();
		}

		private void ChangeDuration()
		{
			if (Decay == 1f)
			{
				totalDelayDuration = float.PositiveInfinity;
			}
			else
			{
				totalDelayDuration = Mathf.Log(0.001f, Decay) * DelayMS / 1000f;
			}
		}

		private void ChangeDelay()
		{
			delaySamples = (int)Mathf.Round(DelayMS * sampleFrequency / 1000f);
			delayBuffer = new float[delaySamples];
			ChangeDuration();
		}

		public override bool ProcessChunk(float[] data, int fromIndex, int length, bool emptyData)
		{
			if (emptyData)
			{
				double dspTime = AudioSettings.dspTime;
				if (_processingEmptyData)
				{
					if (dspTime > _emptyTargetTime)
					{
						return false;
					}
				}
				else
				{
					_processingEmptyData = true;
					_emptyTargetTime = dspTime + (double)totalDelayDuration;
				}
			}
			else
			{
				_processingEmptyData = false;
			}
			length += fromIndex;
			for (int i = fromIndex; i < length; i++)
			{
				index %= delaySamples;
				float num = delayBuffer[index];
				delayBuffer[index] = 0f;
				float num2 = data[i];
				float num3 = num;
				output = num2 * (1f - DryWet) + num3 * DryWet;
				data[i] = output;
				delayBuffer[index] += num3 * Decay;
				delayBuffer[index] += num2;
				index++;
			}
			return true;
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
			length += fromIndex;
			for (int i = fromIndex; i < length; i++)
			{
				index %= delaySamples;
				float num = delayBuffer[index];
				delayBuffer[index] = 0f;
				float num2 = data[i];
				float num3 = num;
				output = num2 * (1f - DryWet) + num3 * DryWet;
				data[i] = output;
				delayBuffer[index] += num3 * Decay;
				delayBuffer[index] += num2;
				index++;
			}
		}

		public override void ResetFilter()
		{
			Array.Clear(delayBuffer, 0, delayBuffer.Length);
			index = 0;
			_processingEmptyData = true;
			_emptyTargetTime = 0.0;
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("Audial Simple Delay( G-Audio version ) does not support multichannel audio - please use the standard Audial Delay instead.");
		}

		static GATAudialSimpleDelay()
		{
			AGATMonoFilter.RegisterMonoFilter("Audial > Simple Delay", typeof(GATAudialSimpleDelay));
		}
	}
}
