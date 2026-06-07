using System.IO;

namespace NAudio.Midi
{
	public class NoteOnEvent : NoteEvent
	{
		private NoteEvent offEvent;

		public NoteEvent OffEvent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override int NoteNumber
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int Channel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int NoteLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public NoteOnEvent(BinaryReader br)
			: base(null)
		{
		}

		public NoteOnEvent(long absoluteTime, int channel, int noteNumber, int velocity, int duration)
			: base(null)
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
	}
}
