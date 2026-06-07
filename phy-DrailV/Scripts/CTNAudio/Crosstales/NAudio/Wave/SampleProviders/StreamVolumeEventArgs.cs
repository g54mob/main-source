using System;

namespace Crosstales.NAudio.Wave.SampleProviders
{
	public class StreamVolumeEventArgs : EventArgs
	{
		public float[] MaxSampleValues { get; set; }
	}
}
