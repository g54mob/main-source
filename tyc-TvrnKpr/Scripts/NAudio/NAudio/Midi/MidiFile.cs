using System.Collections.Generic;
using System.IO;

namespace NAudio.Midi
{
	public class MidiFile
	{
		private readonly MidiEventCollection events;

		private readonly ushort fileFormat;

		private readonly ushort deltaTicksPerQuarterNote;

		private readonly bool strictChecking;

		public int FileFormat => 0;

		public MidiEventCollection Events => null;

		public int Tracks => 0;

		public int DeltaTicksPerQuarterNote => 0;

		public MidiFile(string filename)
		{
		}

		public MidiFile(string filename, bool strictChecking)
		{
		}

		public MidiFile(Stream inputStream, bool strictChecking)
		{
		}

		private MidiFile(Stream inputStream, bool strictChecking, bool ownInputStream)
		{
		}

		private void FindNoteOn(NoteEvent offEvent, List<NoteOnEvent> outstandingNoteOns)
		{
		}

		private static uint SwapUInt32(uint i)
		{
			return 0u;
		}

		private static ushort SwapUInt16(ushort i)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static void Export(string filename, MidiEventCollection events)
		{
		}
	}
}
