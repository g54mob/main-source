using System.IO;

namespace NAudio.SoundFont
{
	internal class ModulatorBuilder : StructureBuilder<Modulator>
	{
		public override int Length => 0;

		public Modulator[] Modulators => null;

		public override Modulator Read(BinaryReader br)
		{
			return null;
		}

		public override void Write(BinaryWriter bw, Modulator o)
		{
		}
	}
}
