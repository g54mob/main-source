using System.IO;

namespace NAudio.Midi
{
	public class TempoEvent : MetaEvent
	{
		private int microsecondsPerQuarterNote;

		public int MicrosecondsPerQuarterNote
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public double Tempo
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public TempoEvent(BinaryReader br, int length)
		{
		}

		public TempoEvent(int microsecondsPerQuarterNote, long absoluteTime)
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
