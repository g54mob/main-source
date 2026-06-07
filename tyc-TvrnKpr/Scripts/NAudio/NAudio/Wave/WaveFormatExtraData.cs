using System.IO;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)0)]
	public class WaveFormatExtraData : WaveFormat
	{
		private byte[] extraData;

		public byte[] ExtraData => null;

		internal WaveFormatExtraData()
		{
		}

		public WaveFormatExtraData(BinaryReader reader)
		{
		}

		internal void ReadExtraData(BinaryReader reader)
		{
		}

		public override void Serialize(BinaryWriter writer)
		{
		}
	}
}
