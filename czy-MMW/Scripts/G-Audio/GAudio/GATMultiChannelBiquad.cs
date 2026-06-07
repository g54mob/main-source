using System;
using UnityEngine;

namespace GAudio
{
	public class GATMultiChannelBiquad : AGATMonoFilter, IGATBiQuadFilterPeak
	{
		[SerializeField]
		private AGATBiQuad[] _biquads;

		[SerializeField]
		private int _nbOfChannels;

		protected bool _inZeroState = true;

		public float Freq
		{
			get
			{
				return _biquads[0].Freq;
			}
			set
			{
				for (int i = 0; i < _biquads.Length; i++)
				{
					_biquads[i].Freq = value;
				}
			}
		}

		public double Q
		{
			get
			{
				return _biquads[0].Q;
			}
			set
			{
				for (int i = 0; i < _biquads.Length; i++)
				{
					_biquads[i].Q = value;
				}
			}
		}

		public float PeakGain
		{
			get
			{
				return _biquads[0].PeakGain;
			}
			set
			{
				for (int i = 0; i < _biquads.Length; i++)
				{
					_biquads[i].PeakGain = value;
				}
			}
		}

		public float Mix
		{
			get
			{
				return _biquads[0].Mix;
			}
			set
			{
				for (int i = 0; i < _biquads.Length; i++)
				{
					_biquads[i].Mix = value;
				}
			}
		}

		public override Type ControlInterfaceType => typeof(IGATBiQuadFilterPeak);

		public override int NbOfFilterableChannels => 999;

		public void InitMultiChannelBiquad<T>(int nbOfChannels, T filterInstance) where T : AGATMonoFilter
		{
			_nbOfChannels = nbOfChannels;
			_biquads = new AGATBiQuad[nbOfChannels];
			_biquads[0] = filterInstance as AGATBiQuad;
			for (int i = 1; i < nbOfChannels; i++)
			{
				_biquads[i] = ScriptableObject.CreateInstance<T>() as AGATBiQuad;
			}
		}

		public void SetParams(float frequency, double q, float peakGain)
		{
			for (int i = 0; i < _nbOfChannels; i++)
			{
				_biquads[i].SetParams(frequency, q, peakGain);
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
			for (int i = 0; i < _nbOfChannels; i++)
			{
				_biquads[i].ProcessChunk(data, fromIndex + i, length, _nbOfChannels);
			}
			return true;
		}

		public override void ProcessChunk(float[] data, int fromIndex, int length, int stride)
		{
			throw new GATException("stride should not be specified when dealing with wrapped filters. Use ProcessChunk( data, index, length ) instead.");
		}

		private void OnDestroy()
		{
			if (Application.isPlaying)
			{
				for (int i = 0; i < _biquads.Length; i++)
				{
					UnityEngine.Object.Destroy(_biquads[i]);
				}
			}
			else
			{
				for (int i = 0; i < _biquads.Length; i++)
				{
					UnityEngine.Object.DestroyImmediate(_biquads[i]);
				}
			}
		}

		public override AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels)
		{
			throw new GATException("already a multichannel wrapper! ");
		}

		public override void ResetFilter()
		{
			for (int i = 0; i < _biquads.Length; i++)
			{
				_biquads[i].ResetFilter();
			}
		}
	}
}
