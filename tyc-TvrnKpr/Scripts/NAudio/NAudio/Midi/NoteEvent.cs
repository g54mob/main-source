using System.IO;

namespace NAudio.Midi
{
	public class NoteEvent : MidiEvent
	{
		private int noteNumber;

		private int velocity;

		private static readonly string[] NoteNames;

		public virtual int NoteNumber
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Velocity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string NoteName => null;

		public NoteEvent(BinaryReader br)
		{
		}

		public NoteEvent(long absoluteTime, int channel, MidiCommandCode commandCode, int noteNumber, int velocity)
		{
		}

		public override int GetAsShortMessage()
		{
			return 0;
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
