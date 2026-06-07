using System;
using UnityEngine;

namespace GAudio
{
	[Serializable]
	public abstract class AGATBiQuad : AGATMonoFilter, IGATBiQuadFilter
	{
		[SerializeField]
		protected float _fq;

		[SerializeField]
		protected float _frequency = 440f;

		[SerializeField]
		protected float _peakGain = 5f;

		protected double _a0;

		protected double _a1;

		protected double _a2;

		protected double _b1;

		protected double _b2;

		[SerializeField]
		protected double _Q = 0.76;

		protected double _z1;

		protected double _z2;

		protected double _K;

		protected double _KSq;

		protected bool _inZeroState = true;

		[SerializeField]
		protected float _mix = 1f;

		public override Type ControlInterfaceType => typeof(IGATBiQuadFilter);

		public virtual float Freq
		{
			get
			{
				return _frequency;
			}
			set
			{
				_fq = value / (float)GATInfo.OutputSampleRate;
				_frequency = value;
				UpdateK();
				CalcBiquad();
			}
		}

		public virtual double Q
		{
			get
			{
				return _Q;
			}
			set
			{
				_Q = value;
				CalcBiquad();
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
				if (_mix != value)
				{
					_mix = value;
				}
			}
		}

		public virtual float PeakGain { get; set; }

		public override int NbOfFilterableChannels => 1;

		public virtual void SetParams(float frequency, double q, float peakGain)
		{
			_fq = frequency / (float)GATInfo.OutputSampleRate;
			_frequency = frequency;
			_Q = q;
			_peakGain = peakGain;
			UpdateK();
			CalcBiquad();
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
			if (_mix <= 0f)
			{
				return;
			}
			length += fromIndex;
			if (_mix < 1f)
			{
				for (int i = fromIndex; i < length; i += stride)
				{
					float num = data[i];
					double num2 = (double)num * _a0 + _z1;
					_z1 = (double)num * _a1 + _z2 - _b1 * num2;
					_z2 = (double)num * _a2 - _b2 * num2;
					data[i] = (float)num2 * _mix + data[i] * (1f - _mix);
				}
			}
			else
			{
				for (int i = fromIndex; i < length; i += stride)
				{
					float num = data[i];
					double num2 = (double)num * _a0 + _z1;
					_z1 = (double)num * _a1 + _z2 - _b1 * num2;
					_z2 = (double)num * _a2 - _b2 * num2;
					data[i] = (float)num2;
				}
			}
		}

		public override bool ProcessChunk(float[] data, int fromIndex, int length, bool emptyData)
		{
			if (emptyData)
			{
				if (!_inZeroState)
				{
					ResetFilter();
					_inZeroState = true;
				}
				return false;
			}
			if (_mix <= 0f)
			{
				return true;
			}
			length += fromIndex;
			if (_mix < 1f)
			{
				for (int i = fromIndex; i < length; i++)
				{
					float num = data[i];
					double num2 = (double)num * _a0 + _z1;
					_z1 = (double)num * _a1 + _z2 - _b1 * num2;
					_z2 = (double)num * _a2 - _b2 * num2;
					data[i] = (float)num2 * _mix + data[i] * (1f - _mix);
				}
			}
			else
			{
				for (int i = fromIndex; i < length; i++)
				{
					float num = data[i];
					double num2 = (double)num * _a0 + _z1;
					_z1 = (double)num * _a1 + _z2 - _b1 * num2;
					_z2 = (double)num * _a2 - _b2 * num2;
					data[i] = (float)num2;
				}
			}
			if (_inZeroState)
			{
				_inZeroState = false;
			}
			return true;
		}

		public override void ResetFilter()
		{
			_a0 = 0.0;
			_a1 = 0.0;
			_a2 = 0.0;
			_b1 = 0.0;
			_b2 = 0.0;
			_z1 = 0.0;
			_z2 = 0.0;
			CalcBiquad();
			_inZeroState = true;
		}

		protected virtual void OnEnable()
		{
			SetParams(_frequency, _Q, _peakGain);
		}

		protected void UpdateK()
		{
			_K = Mathf.Tan((float)Math.PI * _fq);
			_KSq = _K * _K;
		}

		protected abstract void CalcBiquad();

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			GATMultiChannelBiquad gATMultiChannelBiquad = ScriptableObject.CreateInstance<GATMultiChannelBiquad>();
			gATMultiChannelBiquad.InitMultiChannelBiquad(nbOfChannels, this as T);
			return gATMultiChannelBiquad;
		}
	}
}
