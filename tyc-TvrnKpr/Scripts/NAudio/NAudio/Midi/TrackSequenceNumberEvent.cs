using System.IO;

namespace NAudio.Midi
{
	public class TrackSequenceNumberEvent : MetaEvent
	{
		private ushort sequenceNumber;

		public TrackSequenceNumberEvent(ushort sequenceNumber)
		{
		}

		public TrackSequenceNumberEvent(BinaryReader br, int length)
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
