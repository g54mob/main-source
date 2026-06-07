using System.IO;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class AdpcmWaveFormat : WaveFormat
	{
		private short samplesPerBlock;

		private short numCoeff;

		private short[] coefficients;

		public int SamplesPerBlock => 0;

		public int NumCoefficients => 0;

		public short[] Coefficients => null;

		private AdpcmWaveFormat()
		{
		}

		public AdpcmWaveFormat(int sampleRate, int channels)
		{
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
