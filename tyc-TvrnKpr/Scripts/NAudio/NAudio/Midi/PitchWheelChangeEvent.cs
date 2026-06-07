using System.IO;

namespace NAudio.Midi
{
	public class PitchWheelChangeEvent : MidiEvent
	{
		private int pitch;

		public int Pitch
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public PitchWheelChangeEvent(BinaryReader br)
		{
		}

		public PitchWheelChangeEvent(long absoluteTime, int channel, int pitchWheel)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetAsShortMessage()
		{
			return 0;
		}

		public override void Export(ref long absoluteTime, BinaryWriter writer)
		{
		}
	}
}
