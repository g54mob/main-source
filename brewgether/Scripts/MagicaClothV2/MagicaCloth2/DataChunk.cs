namespace MagicaCloth2
{
	public struct DataChunk
	{
		public int startIndex;

		public int dataLength;

		public bool IsValid => false;

		public static DataChunk Empty => default(DataChunk);

		public DataChunk(int sindex, int length)
		{
			startIndex = 0;
			dataLength = 0;
		}

		public DataChunk(int sindex)
		{
			startIndex = 0;
			dataLength = 0;
		}

		public void Clear()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
