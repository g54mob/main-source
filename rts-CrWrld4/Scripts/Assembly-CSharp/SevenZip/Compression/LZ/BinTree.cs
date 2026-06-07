using System.IO;

namespace SevenZip.Compression.LZ
{
	public class BinTree : InWindow, IMatchFinder, IInWindowStream
	{
		private uint _cyclicBufferPos;

		private uint _cyclicBufferSize;

		private uint _matchMaxLen;

		private uint[] _son;

		private uint[] _hash;

		private uint _cutValue;

		private uint _hashMask;

		private uint _hashSizeSum;

		private bool HASH_ARRAY;

		private const uint kHash2Size = 1024u;

		private const uint kHash3Size = 65536u;

		private const uint kBT2HashSize = 65536u;

		private const uint kStartMaxLen = 1u;

		private const uint kHash3Offset = 1024u;

		private const uint kEmptyHashValue = 0u;

		private const uint kMaxValForNormalize = 2147483647u;

		private uint kNumHashDirectBytes;

		private uint kMinMatchCheck;

		private uint kFixHashSize;

		public void SetType(int numHashBytes)
		{
		}

		public new void SetStream(Stream stream)
		{
		}

		public new void ReleaseStream()
		{
		}

		public new void Init()
		{
		}

		public new void MovePos()
		{
		}

		public new byte GetIndexByte(int index)
		{
			return 0;
		}

		public new uint GetMatchLen(int index, uint distance, uint limit)
		{
			return 0u;
		}

		public new uint GetNumAvailableBytes()
		{
			return 0u;
		}

		public void Create(uint historySize, uint keepAddBufferBefore, uint matchMaxLen, uint keepAddBufferAfter)
		{
		}

		public uint GetMatches(uint[] distances)
		{
			return 0u;
		}

		public void Skip(uint num)
		{
		}

		private void NormalizeLinks(uint[] items, uint numItems, uint subValue)
		{
		}

		private void Normalize()
		{
		}

		public void SetCutValue(uint cutValue)
		{
		}
	}
}
