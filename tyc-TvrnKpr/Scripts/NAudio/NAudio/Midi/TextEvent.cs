using System.IO;

namespace NAudio.Midi
{
	public class TextEvent : MetaEvent
	{
		private byte[] data;

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public TextEvent(BinaryReader br, int length)
		{
		}

		public TextEvent(string text, MetaEventType metaEventType, long absoluteTime)
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
