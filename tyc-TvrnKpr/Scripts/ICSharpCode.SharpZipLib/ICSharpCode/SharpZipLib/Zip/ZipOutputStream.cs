using System.Collections;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ZipOutputStream : DeflaterOutputStream
	{
		private ArrayList entries;

		private Crc32 crc;

		private ZipEntry curEntry;

		private int defaultCompressionLevel;

		private CompressionMethod curMethod;

		private long size;

		private long offset;

		private byte[] zipComment;

		private bool patchEntryHeader;

		private long crcPatchPos;

		private long sizePatchPos;

		private UseZip64 useZip64_;

		public bool IsFinished => false;

		public UseZip64 UseZip64
		{
			get
			{
				return default(UseZip64);
			}
			set
			{
			}
		}

		public ZipOutputStream(Stream baseOutputStream)
			: base(null)
		{
		}

		public ZipOutputStream(Stream baseOutputStream, int bufferSize)
			: base(null)
		{
		}

		public void SetComment(string comment)
		{
		}

		public void SetLevel(int level)
		{
		}

		public int GetLevel()
		{
			return 0;
		}

		private void WriteLeShort(int value)
		{
		}

		private void WriteLeInt(int value)
		{
		}

		private void WriteLeLong(long value)
		{
		}

		public void PutNextEntry(ZipEntry entry)
		{
		}

		public void CloseEntry()
		{
		}

		private void WriteEncryptionHeader(long crcValue)
		{
		}

		private static void AddExtraDataAES(ZipEntry entry, ZipExtraData extraData)
		{
		}

		private void WriteAESHeader(ZipEntry entry)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		private void CopyAndEncrypt(byte[] buffer, int offset, int count)
		{
		}

		public override void Finish()
		{
		}
	}
}
