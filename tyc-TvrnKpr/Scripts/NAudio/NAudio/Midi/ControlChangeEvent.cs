using System.IO;

namespace NAudio.Midi
{
	public class ControlChangeEvent : MidiEvent
	{
		private MidiController controller;

		private byte controllerValue;

		public MidiController Controller
		{
			get
			{
				return default(MidiController);
			}
			set
			{
			}
		}

		public int ControllerValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ControlChangeEvent(BinaryReader br)
		{
		}

		public ControlChangeEvent(long absoluteTime, int channel, MidiController controller, int controllerValue)
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
