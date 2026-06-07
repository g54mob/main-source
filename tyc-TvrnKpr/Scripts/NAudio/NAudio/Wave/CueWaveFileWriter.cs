using System.IO;

namespace NAudio.Wave
{
	public class CueWaveFileWriter : WaveFileWriter
	{
		private CueList cues;

		public CueWaveFileWriter(string fileName, WaveFormat waveFormat)
			: base((Stream)null, (WaveFormat)null)
		{
		}

		public void AddCue(int position, string label)
		{
		}

		private void WriteCues(BinaryWriter w)
		{
		}

		protected override void UpdateHeader(BinaryWriter writer)
		{
		}
	}
}
