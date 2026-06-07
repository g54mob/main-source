using System.IO;

namespace NAudio.Midi
{
	public class SysexEvent : MidiEvent
	{
		private byte[] data;

		public static SysexEvent ReadSysexEvent(BinaryReader br)
		{
			return null;
		}

		public override MidiEvent Clone()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override void Export(ref long absoluteTime, BinaryWriter writer)
		{
		}
	}
}
