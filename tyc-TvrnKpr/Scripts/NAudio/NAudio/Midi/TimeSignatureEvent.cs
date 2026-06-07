using System.IO;

namespace NAudio.Midi
{
	public class TimeSignatureEvent : MetaEvent
	{
		private byte numerator;

		private byte denominator;

		private byte ticksInMetronomeClick;

		private byte no32ndNotesInQuarterNote;

		public int Numerator => 0;

		public int Denominator => 0;

		public int TicksInMetronomeClick => 0;

		public int No32ndNotesInQuarterNote => 0;

		public string TimeSignature => null;

		public TimeSignatureEvent(BinaryReader br, int length)
		{
		}

		public TimeSignatureEvent(long absoluteTime, int numerator, int denominator, int ticksInMetronomeClick, int no32ndNotesInQuarterNote)
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
