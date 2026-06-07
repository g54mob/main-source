using System.IO;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class Gsm610WaveFormat : WaveFormat
	{
		private readonly short samplesPerBlock;

		public short SamplesPerBlock => 0;

		public override void Serialize(BinaryWriter writer)
		{
		}
	}
}
