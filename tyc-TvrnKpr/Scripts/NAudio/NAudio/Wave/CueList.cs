using System.Collections.Generic;

namespace NAudio.Wave
{
	public class CueList
	{
		private readonly List<Cue> cues;

		public int[] CuePositions => null;

		public string[] CueLabels => null;

		public int Count => 0;

		public Cue this[int index] => null;

		public CueList()
		{
		}

		public void Add(Cue cue)
		{
		}

		internal CueList(byte[] cueChunkData, byte[] listChunkData)
		{
		}

		internal byte[] GetRiffChunks()
		{
			return null;
		}

		internal static CueList FromChunks(WaveFileReader reader)
		{
			return null;
		}
	}
}
