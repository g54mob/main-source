namespace NAudio.SoundFont
{
	public class PresetsChunk
	{
		private PresetBuilder presetHeaders;

		private ZoneBuilder presetZones;

		private ModulatorBuilder presetZoneModulators;

		private GeneratorBuilder presetZoneGenerators;

		private InstrumentBuilder instruments;

		private ZoneBuilder instrumentZones;

		private ModulatorBuilder instrumentZoneModulators;

		private GeneratorBuilder instrumentZoneGenerators;

		private SampleHeaderBuilder sampleHeaders;

		public Preset[] Presets => null;

		public Instrument[] Instruments => null;

		public SampleHeader[] SampleHeaders => null;

		internal PresetsChunk(RiffChunk chunk)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
