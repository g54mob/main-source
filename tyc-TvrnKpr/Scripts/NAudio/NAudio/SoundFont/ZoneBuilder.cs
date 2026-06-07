using System.IO;

namespace NAudio.SoundFont
{
	internal class ZoneBuilder : StructureBuilder<Zone>
	{
		private Zone lastZone;

		public Zone[] Zones => null;

		public override int Length => 0;

		public override Zone Read(BinaryReader br)
		{
			return null;
		}

		public override void Write(BinaryWriter bw, Zone zone)
		{
		}

		public void Load(Modulator[] modulators, Generator[] generators)
		{
		}
	}
}
