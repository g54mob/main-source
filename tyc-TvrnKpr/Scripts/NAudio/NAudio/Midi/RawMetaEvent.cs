using System.IO;

namespace NAudio.Midi
{
	public class RawMetaEvent : MetaEvent
	{
		public byte[] Data { get; set; }

		public RawMetaEvent(MetaEventType metaEventType, long absoluteTime, byte[] data)
		{
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
