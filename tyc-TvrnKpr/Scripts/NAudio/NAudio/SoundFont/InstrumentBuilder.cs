using System.IO;

namespace NAudio.SoundFont
{
	internal class InstrumentBuilder : StructureBuilder<Instrument>
	{
		private Instrument lastInstrument;

		public override int Length => 0;

		public Instrument[] Instruments => null;

		public override Instrument Read(BinaryReader br)
		{
			return null;
		}

		public override void Write(BinaryWriter bw, Instrument instrument)
		{
		}

		public void LoadZones(Zone[] zones)
		{
		}
	}
}
