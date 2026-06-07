namespace NAudio.Midi
{
	public class MidiMessage
	{
		private int rawData;

		public int RawData => 0;

		public MidiMessage(int status, int data1, int data2)
		{
		}

		public MidiMessage(int rawData)
		{
		}

		public static MidiMessage StartNote(int note, int volume, int channel)
		{
			return null;
		}

		private static void ValidateNoteParameters(int note, int volume, int channel)
		{
		}

		private static void ValidateChannel(int channel)
		{
		}

		public static MidiMessage StopNote(int note, int volume, int channel)
		{
			return null;
		}

		public static MidiMessage ChangePatch(int patch, int channel)
		{
			return null;
		}

		public static MidiMessage ChangeControl(int controller, int value, int channel)
		{
			return null;
		}
	}
}
