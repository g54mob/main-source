namespace NAudio.Wave
{
	public class CueWaveFileReader : WaveFileReader
	{
		private CueList cues;

		public CueList Cues => null;

		public CueWaveFileReader(string fileName)
			: base((string)null)
		{
		}
	}
}
