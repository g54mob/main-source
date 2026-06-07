namespace ThreeDISevenZeroR.UnityGifDecoder.Decode
{
	public class GifLzwDictionary
	{
		private readonly int[] dictionaryEntryOffsets;

		private readonly int[] dictionaryEntrySizes;

		private byte[] dictionaryHeap;

		private int dictionarySize;

		private int dictionaryHeapPosition;

		private int initialDictionarySize;

		private int initialLzwCodeSize;

		private int initialDictionaryHeapPosition;

		private int nextLzwCodeGrowth;

		private int currentMinLzwCodeSize;

		private int codeSize;

		private int clearCodeId;

		private int stopCodeId;

		private int lastCodeId;

		private bool isFull;

		public void InitWithWordSize(int minLzwCodeSize)
		{
		}

		public void Clear()
		{
		}

		public void DecodeStream(GifBitBlockReader reader, GifCanvas c)
		{
		}

		public int CreateNewCode(int baseEntry, int deriveEntry)
		{
			return 0;
		}
	}
}
