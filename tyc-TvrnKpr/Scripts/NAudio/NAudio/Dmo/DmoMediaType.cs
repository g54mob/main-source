using System;
using NAudio.Wave;

namespace NAudio.Dmo
{
	public struct DmoMediaType
	{
		private Guid majortype;

		private Guid subtype;

		private bool bFixedSizeSamples;

		private bool bTemporalCompression;

		private int lSampleSize;

		private Guid formattype;

		private IntPtr pUnk;

		private int cbFormat;

		private IntPtr pbFormat;

		public Guid MajorType => default(Guid);

		public string MajorTypeName => null;

		public Guid SubType => default(Guid);

		public string SubTypeName => null;

		public bool FixedSizeSamples => false;

		public int SampleSize => 0;

		public Guid FormatType => default(Guid);

		public string FormatTypeName => null;

		public WaveFormat GetWaveFormat()
		{
			return null;
		}

		public void SetWaveFormat(WaveFormat waveFormat)
		{
		}
	}
}
