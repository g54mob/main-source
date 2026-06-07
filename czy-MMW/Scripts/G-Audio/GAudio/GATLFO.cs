using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GAudio
{
	public class GATLFO : AGATMonoFilter, IGATLFO
	{
		[SerializeField]
		private float _frequency = 4f;

		private float _phase;

		[SerializeField]
		private float _strength = 0.5f;

		private float _phaseIncrement;

		private float _initFreq;

		private float _initStrength;

		public static bool UseNative;

		public override Type ControlInterfaceType => typeof(IGATLFO);

		public float Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_phaseIncrement = (float)Math.PI * 2f * value / (float)GATInfo.OutputSampleRate;
				_frequency = value;
			}
		}

		public float Strength
		{
			get
			{
				return _strength;
			}
			set
			{
				_strength = value;
			}
		}

		public float FrequencyAtStart => _initFreq;

		public float StrengthAtStart => _initStrength;

		public override int NbOfFilterableChannels => 999;

		public void SetInitParams(float frequency, float strength)
		{
			_strength = strength;
			Frequency = frequency;
			_initFreq = frequency;
			_initStrength = strength;
		}

		protected virtual void OnEnable()
		{
			SetInitParams(_frequency, _strength);
		}

		public override void ProcessChunk(float[] data, int sourceIndex, int length, int stride)
		{
			if (sourceIndex < 0)
			{
				Debug.LogErrorFormat("Caught negative sourceIndex ({0}) in GATLFO.ProcessChunk().", sourceIndex);
				sourceIndex = 0;
			}
			if (sourceIndex + length > data.Length)
			{
				Debug.LogErrorFormat("Caught out of bounds in GATLFO.ProcessChunk(). sourceIndex = {0}, length = {1}, data.Length = {2}", sourceIndex, length, data.Length);
				length = data.Length - sourceIndex;
			}
			if (UseNative)
			{
				GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
				_phase = NativeLFOProcessChunk(gCHandle.AddrOfPinnedObject(), sourceIndex, length, 1, _phase, _phaseIncrement, _strength);
				gCHandle.Free();
				return;
			}
			length += sourceIndex;
			for (int i = sourceIndex; i < length; i += stride)
			{
				float num = Mathf.Sin(_phase);
				num = (num + 1f) / 2f;
				num = num * _strength + (1f - _strength);
				_phase += _phaseIncrement;
				if (_phase > (float)Math.PI * 2f)
				{
					_phase -= (float)Math.PI * 2f;
				}
				data[i] *= num;
			}
		}

		public override bool ProcessChunk(float[] data, int sourceIndex, int length, bool emptyData)
		{
			if (emptyData)
			{
				return false;
			}
			if (sourceIndex < 0)
			{
				Debug.LogErrorFormat("Caught negative sourceIndex ({0}) in GATLFO.ProcessChunk().", sourceIndex);
				sourceIndex = 0;
			}
			if (sourceIndex + length > data.Length)
			{
				Debug.LogErrorFormat("Caught out of bounds in GATLFO.ProcessChunk(). sourceIndex = {0}, length = {1}, data.Length = {2}", sourceIndex, length, data.Length);
				length = data.Length - sourceIndex;
			}
			if (UseNative)
			{
				GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
				_phase = NativeLFOProcessChunk(gCHandle.AddrOfPinnedObject(), sourceIndex, length, 1, _phase, _phaseIncrement, _strength);
				gCHandle.Free();
			}
			else
			{
				length += sourceIndex;
				for (int i = sourceIndex; i < length; i++)
				{
					float num = Mathf.Sin(_phase);
					num = (num + 1f) / 2f;
					num = num * _strength + (1f - _strength);
					_phase += _phaseIncrement;
					if (_phase > (float)Math.PI * 2f)
					{
						_phase -= (float)Math.PI * 2f;
					}
					data[i] *= num;
				}
			}
			return true;
		}

		public override void ResetFilter()
		{
			_phase = 0f;
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("Not implemented yet");
		}

		static GATLFO()
		{
			UseNative = true;
			AGATMonoFilter.RegisterMonoFilter("LFO", typeof(GATLFO));
		}

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LFOProcessChunk")]
		private static extern float NativeLFOProcessChunk(IntPtr data, int sourceIndex, int length, int stride, float phase, float phaseIncrement, float strength);
	}
}
