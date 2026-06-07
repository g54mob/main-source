using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class WaveFormatExtensible : WaveFormat
	{
		private short wValidBitsPerSample;

		private int dwChannelMask;

		private Guid subFormat;

		public Guid SubFormat => default(Guid);

		private WaveFormatExtensible()
		{
		}

		public WaveFormatExtensible(int rate, int bits, int channels)
		{
		}

		public WaveFormat ToStandardWaveFormat()
		{
			return null;
		}

		public override void Serialize(BinaryWriter writer)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
