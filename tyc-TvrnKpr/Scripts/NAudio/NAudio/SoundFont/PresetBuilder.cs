using System.IO;

namespace NAudio.SoundFont
{
	internal class PresetBuilder : StructureBuilder<Preset>
	{
		private Preset lastPreset;

		public override int Length => 0;

		public Preset[] Presets => null;

		public override Preset Read(BinaryReader br)
		{
			return null;
		}

		public override void Write(BinaryWriter bw, Preset preset)
		{
		}

		public void LoadZones(Zone[] presetZones)
		{
		}
	}
}
