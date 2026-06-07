using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class WaveFormat
	{
		protected WaveFormatEncoding waveFormatTag;

		protected short channels;

		protected int sampleRate;

		protected int averageBytesPerSecond;

		protected short blockAlign;

		protected short bitsPerSample;

		protected short extraSize;

		public WaveFormatEncoding Encoding => default(WaveFormatEncoding);

		public int Channels => 0;

		public int SampleRate => 0;

		public int AverageBytesPerSecond => 0;

		public virtual int BlockAlign => 0;

		public int BitsPerSample => 0;

		public int ExtraSize => 0;

		public WaveFormat()
		{
		}

		public WaveFormat(int sampleRate, int channels)
		{
		}

		public int ConvertLatencyToByteSize(int milliseconds)
		{
			return 0;
		}

		public static WaveFormat CreateCustomFormat(WaveFormatEncoding tag, int sampleRate, int channels, int averageBytesPerSecond, int blockAlign, int bitsPerSample)
		{
			return null;
		}

		public static WaveFormat CreateALawFormat(int sampleRate, int channels)
		{
			return null;
		}

		public static WaveFormat CreateMuLawFormat(int sampleRate, int channels)
		{
			return null;
		}

		public WaveFormat(int rate, int bits, int channels)
		{
		}

		public static WaveFormat CreateIeeeFloatWaveFormat(int sampleRate, int channels)
		{
			return null;
		}

		public static WaveFormat MarshalFromPtr(IntPtr pointer)
		{
			return null;
		}

		public static IntPtr MarshalToPtr(WaveFormat format)
		{
			return (IntPtr)0;
		}

		public static WaveFormat FromFormatChunk(BinaryReader br, int formatChunkLength)
		{
			return null;
		}

		private void ReadWaveFormat(BinaryReader br, int formatChunkLength)
		{
		}

		public WaveFormat(BinaryReader br)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public virtual void Serialize(BinaryWriter writer)
		{
		}
	}
}
