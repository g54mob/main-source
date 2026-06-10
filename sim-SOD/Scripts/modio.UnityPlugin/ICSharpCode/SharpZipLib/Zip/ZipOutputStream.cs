using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ZipOutputStream : DeflaterOutputStream
	{
		private List<ZipEntry> entries;

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

		private string password;

		private static RandomNumberGenerator _aesRnd;

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

		public INameTransform NameTransform { get; set; }

		public string Password
		{
			get
			{
				return null;
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

		private void TransformEntryName(ZipEntry entry)
		{
		}

		public void PutNextEntry(ZipEntry entry)
		{
		}

		public void CloseEntry()
		{
		}

		private void InitializePassword(string password)
		{
		}

		private void InitializeAESPassword(ZipEntry entry, string rawPassword, out byte[] salt, out byte[] pwdVerifier)
		{
			salt = null;
			pwdVerifier = null;
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

		public override void Flush()
		{
		}
	}
}
