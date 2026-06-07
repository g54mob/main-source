namespace NAudio.SoundFont
{
	public class InfoChunk
	{
		public SFVersion SoundFontVersion { get; }

		public string WaveTableSoundEngine { get; set; }

		public string BankName { get; set; }

		public string DataROM { get; set; }

		public string CreationDate { get; set; }

		public string Author { get; set; }

		public string TargetProduct { get; set; }

		public string Copyright { get; set; }

		public string Comments { get; set; }

		public string Tools { get; set; }

		public SFVersion ROMVersion { get; set; }

		internal InfoChunk(RiffChunk chunk)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
