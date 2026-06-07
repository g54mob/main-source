using System.IO;

namespace SevenZip.Compression.LZ
{
	public class InWindow
	{
		public byte[] _bufferBase;

		private Stream _stream;

		private uint _posLimit;

		private bool _streamEndWasReached;

		private uint _pointerToLastSafePosition;

		public uint _bufferOffset;

		public uint _blockSize;

		public uint _pos;

		private uint _keepSizeBefore;

		private uint _keepSizeAfter;

		public uint _streamPos;

		public void MoveBlock()
		{
		}

		public virtual void ReadBlock()
		{
		}

		private void Free()
		{
		}

		public void Create(uint keepSizeBefore, uint keepSizeAfter, uint keepSizeReserv)
		{
		}

		public void SetStream(Stream stream)
		{
		}

		public void ReleaseStream()
		{
		}

		public void Init()
		{
		}

		public void MovePos()
		{
		}

		public byte GetIndexByte(int index)
		{
			return 0;
		}

		public uint GetMatchLen(int index, uint distance, uint limit)
		{
			return 0u;
		}

		public uint GetNumAvailableBytes()
		{
			return 0u;
		}

		public void ReduceOffsets(int subValue)
		{
		}
	}
}
