using System.IO;

namespace NAudio.SoundFont
{
	internal class SFVersionBuilder : StructureBuilder<SFVersion>
	{
		public override int Length => 0;

		public override SFVersion Read(BinaryReader br)
		{
			return null;
		}

		public override void Write(BinaryWriter bw, SFVersion v)
		{
		}
	}
}
