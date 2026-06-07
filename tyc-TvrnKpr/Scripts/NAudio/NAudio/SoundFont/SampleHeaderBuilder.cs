using System.IO;

namespace NAudio.SoundFont
{
	internal class SampleHeaderBuilder : StructureBuilder<SampleHeader>
	{
		public override int Length => 0;

		public SampleHeader[] SampleHeaders => null;

		public override SampleHeader Read(BinaryReader br)
		{
			return null;
		}

		public override void Write(BinaryWriter bw, SampleHeader sampleHeader)
		{
		}

		internal void RemoveEOS()
		{
		}
	}
}
