using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	internal class OggWaveFormat : WaveFormat
	{
		public uint dwVorbisACMVersion;

		public uint dwLibVorbisVersion;
	}
}
