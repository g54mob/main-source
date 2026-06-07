using System;
using UnityEngine;

namespace GAudio
{
	public class GATDelay : AGATMonoFilter, IGATDelay
	{
		[SerializeField]
		private float _delay = 1f;

		private double _delaySamples;

		[SerializeField]
		private float _feedback = 0.5f;

		private int _counter;

		private float[] _buffer;

		private static int MAX_DELAY_SAMPLES;

		public override Type ControlInterfaceType => typeof(IGATDelay);

		public float Delay
		{
			get
			{
				return _delay;
			}
			set
			{
				if (value <= 0f)
				{
					_delay = 0.001f;
				}
				else
				{
					_delay = value;
				}
				_delaySamples = (double)_delay * (double)GATInfo.OutputSampleRate;
			}
		}

		public float Feedback
		{
			get
			{
				return _feedback;
			}
			set
			{
				_feedback = value;
			}
		}

		public override int NbOfFilterableChannels => 999;

		protected virtual void OnEnable()
		{
			Debug.Log("Delay OnEnable");
			if (MAX_DELAY_SAMPLES == 0)
			{
				MAX_DELAY_SAMPLES = GATInfo.OutputSampleRate;
			}
			_buffer = new float[MAX_DELAY_SAMPLES];
			Delay = _delay;
		}

		public override bool ProcessChunk(float[] data, int fromIndex, int length, bool emptyData)
		{
			int num = _counter;
			double delaySamples = _delaySamples;
			length += fromIndex;
			for (int i = fromIndex; i < length; i++)
			{
				double num2 = (double)num - delaySamples;
				if (num2 < 0.0)
				{
					num2 = (double)MAX_DELAY_SAMPLES + num2;
				}
				int num3 = (int)num2;
				int num4 = num3 - 1;
				int num5 = num3 + 1;
				int num6 = num3 + 2;
				if (num4 < 0)
				{
					num4 = MAX_DELAY_SAMPLES - 1;
				}
				if (num5 >= MAX_DELAY_SAMPLES)
				{
					num5 = 0;
				}
				if (num6 >= MAX_DELAY_SAMPLES)
				{
					num6 = 0;
				}
				float num7 = _buffer[num4];
				float num8 = _buffer[num3];
				float num9 = _buffer[num5];
				float num10 = _buffer[num6];
				float num11 = (float)num2 - (float)num3;
				float num12 = num8;
				float num13 = 0.5f * (num9 - num7);
				float num14 = num7 - 2.5f * num8 + 2f * num9 - 0.5f * num10;
				float num15 = (((0.5f * (num10 - num7) + 1.5f * (num8 - num9)) * num11 + num14) * num11 + num13) * num11 + num12;
				_buffer[num] = data[i] + num15 * _feedback;
				num++;
				if (num >= MAX_DELAY_SAMPLES)
				{
					num = 0;
				}
				data[i] = num15;
			}
			_counter = num;
			return true;
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
		}

		public override void ResetFilter()
		{
			Array.Clear(_buffer, 0, _buffer.Length);
			_counter = 0;
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("Distortion does not need multi channel wrappers - it can be applied safely to interlaced audio data");
		}

		static GATDelay()
		{
			AGATMonoFilter.RegisterMonoFilter("Delay", typeof(GATDelay));
		}
	}
}
