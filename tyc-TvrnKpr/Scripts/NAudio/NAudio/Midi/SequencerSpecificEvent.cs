using System.IO;

namespace NAudio.Midi
{
	public class SequencerSpecificEvent : MetaEvent
	{
		private byte[] data;

		public byte[] Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SequencerSpecificEvent(BinaryReader br, int length)
		{
		}

		public SequencerSpecificEvent(byte[] data, long absoluteTime)
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
