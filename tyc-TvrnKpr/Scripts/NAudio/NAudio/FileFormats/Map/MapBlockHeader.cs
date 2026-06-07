using System.IO;

namespace NAudio.FileFormats.Map
{
	internal class MapBlockHeader
	{
		private int length;

		private int value2;

		private short value3;

		private short value4;

		public int Length => 0;

		public static MapBlockHeader Read(BinaryReader reader)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
