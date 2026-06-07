using System;
using UnityEngine;

namespace GAudio
{
	[Serializable]
	public abstract class AGATBiQuadPeak : AGATBiQuad, IGATBiQuadFilterPeak
	{
		protected double _V;

		protected double _sqrt2V;

		public override Type ControlInterfaceType => typeof(IGATBiQuadFilterPeak);

		public override float PeakGain
		{
			get
			{
				return _peakGain;
			}
			set
			{
				_peakGain = value;
				UpdateV();
				CalcBiquad();
			}
		}

		public AGATBiQuadPeak()
		{
		}

		public override void SetParams(float frequency, double q, float peakGain)
		{
			_fq = frequency / (float)GATInfo.OutputSampleRate;
			_frequency = frequency;
			_Q = q;
			_peakGain = peakGain;
			UpdateK();
			UpdateV();
			CalcBiquad();
		}

		private void UpdateV()
		{
			_V = Mathf.Pow(10f, Mathf.Abs(_peakGain) / 20f);
			_sqrt2V = Mathf.Sqrt((float)(2.0 * _V));
		}
	}
}
