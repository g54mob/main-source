using System.IO;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class TrueSpeechWaveFormat : WaveFormat
	{
		private short[] unknown;

		public override void Serialize(BinaryWriter writer)
		{
		}
	}
}
