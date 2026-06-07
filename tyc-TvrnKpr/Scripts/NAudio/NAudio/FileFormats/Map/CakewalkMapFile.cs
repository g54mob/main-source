using System.Collections.Generic;
using System.IO;

namespace NAudio.FileFormats.Map
{
	public class CakewalkMapFile
	{
		private int mapEntryCount;

		private readonly List<CakewalkDrumMapping> drumMappings;

		private MapBlockHeader fileHeader1;

		private MapBlockHeader fileHeader2;

		private MapBlockHeader mapNameHeader;

		private MapBlockHeader outputs1Header;

		private MapBlockHeader outputs2Header;

		private MapBlockHeader outputs3Header;

		private int outputs1Count;

		private int outputs2Count;

		private int outputs3Count;

		private string mapName;

		public List<CakewalkDrumMapping> DrumMappings => null;

		public CakewalkMapFile(string filename)
		{
		}

		private void ReadMapHeader(BinaryReader reader)
		{
		}

		private CakewalkDrumMapping ReadMapEntry(BinaryReader reader)
		{
			return null;
		}

		private void ReadMapName(BinaryReader reader)
		{
		}

		private void ReadOutputsSection1(BinaryReader reader)
		{
		}

		private void ReadOutputsSection2(BinaryReader reader)
		{
		}

		private void ReadOutputsSection3(BinaryReader reader)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
