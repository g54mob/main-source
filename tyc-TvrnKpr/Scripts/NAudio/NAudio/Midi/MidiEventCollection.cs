using System.Collections;
using System.Collections.Generic;

namespace NAudio.Midi
{
	public class MidiEventCollection : IEnumerable<IList<MidiEvent>>, IEnumerable
	{
		private int midiFileType;

		private readonly List<IList<MidiEvent>> trackEvents;

		public int Tracks => 0;

		public long StartAbsoluteTime { get; set; }

		public int DeltaTicksPerQuarterNote { get; }

		public IList<MidiEvent> this[int trackNumber] => null;

		public int MidiFileType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public MidiEventCollection(int midiFileType, int deltaTicksPerQuarterNote)
		{
		}

		public IList<MidiEvent> GetTrackEvents(int trackNumber)
		{
			return null;
		}

		public IList<MidiEvent> AddTrack()
		{
			return null;
		}

		public IList<MidiEvent> AddTrack(IList<MidiEvent> initialEvents)
		{
			return null;
		}

		public void RemoveTrack(int track)
		{
		}

		public void Clear()
		{
		}

		public void AddEvent(MidiEvent midiEvent, int originalTrack)
		{
		}

		private void EnsureTracks(int count)
		{
		}

		private void ExplodeToManyTracks()
		{
		}

		private void FlattenToOneTrack()
		{
		}

		public void PrepareForExport()
		{
		}

		public IEnumerator<IList<MidiEvent>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
