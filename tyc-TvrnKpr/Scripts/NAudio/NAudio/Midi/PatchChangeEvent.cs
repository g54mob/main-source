using System.IO;

namespace NAudio.Midi
{
	public class PatchChangeEvent : MidiEvent
	{
		private byte patch;

		private static readonly string[] patchNames;

		public int Patch
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static string GetPatchName(int patchNumber)
		{
			return null;
		}

		public PatchChangeEvent(BinaryReader br)
		{
		}

		public PatchChangeEvent(long absoluteTime, int channel, int patchNumber)
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
