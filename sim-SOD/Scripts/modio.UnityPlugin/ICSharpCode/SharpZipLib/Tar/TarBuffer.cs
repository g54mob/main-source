using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarBuffer
	{
		public const int BlockSize = 512;

		public const int DefaultBlockFactor = 20;

		public const int DefaultRecordSize = 10240;

		private Stream inputStream;

		private Stream outputStream;

		private byte[] recordBuffer;

		private int currentBlockIndex;

		private int currentRecordIndex;

		private int recordSize;

		private int blockFactor;

		public int RecordSize => 0;

		public int BlockFactor => 0;

		public int CurrentBlock => 0;

		public bool IsStreamOwner { get; set; }

		public int CurrentRecord => 0;

		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return 0;
		}

		[Obsolete("Use BlockFactor property instead")]
		public int GetBlockFactor()
		{
			return 0;
		}

		protected TarBuffer()
		{
		}

		public static TarBuffer CreateInputTarBuffer(Stream inputStream)
		{
			return null;
		}

		public static TarBuffer CreateInputTarBuffer(Stream inputStream, int blockFactor)
		{
			return null;
		}

		public static TarBuffer CreateOutputTarBuffer(Stream outputStream)
		{
			return null;
		}

		public static TarBuffer CreateOutputTarBuffer(Stream outputStream, int blockFactor)
		{
			return null;
		}

		private void Initialize(int archiveBlockFactor)
		{
		}

		[Obsolete("Use IsEndOfArchiveBlock instead")]
		public bool IsEOFBlock(byte[] block)
		{
			return false;
		}

		public static bool IsEndOfArchiveBlock(byte[] block)
		{
			return false;
		}

		public void SkipBlock()
		{
		}

		public byte[] ReadBlock()
		{
			return null;
		}

		private bool ReadRecord()
		{
			return false;
		}

		[Obsolete("Use CurrentBlock property instead")]
		public int GetCurrentBlockNum()
		{
			return 0;
		}

		[Obsolete("Use CurrentRecord property instead")]
		public int GetCurrentRecordNum()
		{
			return 0;
		}

		public void WriteBlock(byte[] block)
		{
		}

		public void WriteBlock(byte[] buffer, int offset)
		{
		}

		private void WriteRecord()
		{
		}

		private void WriteFinalRecord()
		{
		}

		public void Close()
		{
		}
	}
}
