using System.IO;

namespace NAudio.Midi
{
	public class KeySignatureEvent : MetaEvent
	{
		private byte sharpsFlats;

		private byte majorMinor;

		public int SharpsFlats => 0;

		public int MajorMinor => 0;

		public KeySignatureEvent(BinaryReader br, int length)
		{
		}

		public KeySignatureEvent(int sharpsFlats, int majorMinor, long absoluteTime)
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
