using System.IO;

namespace NAudio.SoundFont
{
	public class SoundFont
	{
		private InfoChunk info;

		private PresetsChunk presetsChunk;

		private SampleDataChunk sampleData;

		public InfoChunk FileInfo => null;

		public Preset[] Presets => null;

		public Instrument[] Instruments => null;

		public SampleHeader[] SampleHeaders => null;

		public byte[] SampleData => null;

		public SoundFont(string fileName)
		{
		}

		public SoundFont(Stream sfFile)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
