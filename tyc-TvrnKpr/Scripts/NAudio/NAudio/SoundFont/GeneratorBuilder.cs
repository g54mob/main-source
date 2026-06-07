using System.IO;

namespace NAudio.SoundFont
{
	internal class GeneratorBuilder : StructureBuilder<Generator>
	{
		public override int Length => 0;

		public Generator[] Generators => null;

		public override Generator Read(BinaryReader br)
		{
			return null;
		}

		public override void Write(BinaryWriter bw, Generator o)
		{
		}

		public void Load(Instrument[] instruments)
		{
		}

		public void Load(SampleHeader[] sampleHeaders)
		{
		}
	}
}
