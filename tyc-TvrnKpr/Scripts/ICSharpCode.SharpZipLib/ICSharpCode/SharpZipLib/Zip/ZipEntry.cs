using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ZipEntry : ICloneable
	{
		[Flags]
		private enum Known : byte
		{
			None = 0,
			Size = 1,
			CompressedSize = 2,
			Crc = 4,
			Time = 8,
			ExternalAttributes = 0x10
		}

		private Known known;

		private int externalFileAttributes;

		private ushort versionMadeBy;

		private string name;

		private ulong size;

		private ulong compressedSize;

		private ushort versionToExtract;

		private uint crc;

		private uint dosTime;

		private CompressionMethod method;

		private byte[] extra;

		private string comment;

		private int flags;

		private long zipFileIndex;

		private long offset;

		private bool forceZip64_;

		private byte cryptoCheckValue_;

		private int _aesVer;

		private int _aesEncryptionStrength;

		public bool HasCrc => false;

		public bool IsCrypted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsUnicodeText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal byte CryptoCheckValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Flags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public long ZipFileIndex
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long Offset
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public int ExternalFileAttributes
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int VersionMadeBy => 0;

		public bool IsDOSEntry => false;

		public int HostSystem
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Version => 0;

		public bool CanDecompress => false;

		public bool LocalHeaderRequiresZip64 => false;

		public bool CentralHeaderRequiresZip64 => false;

		public long DosTime
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public DateTime DateTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public string Name => null;

		public long Size
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long CompressedSize
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long Crc
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public CompressionMethod CompressionMethod
		{
			get
			{
				return default(CompressionMethod);
			}
			set
			{
			}
		}

		internal CompressionMethod CompressionMethodForHeader => default(CompressionMethod);

		public byte[] ExtraData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int AESKeySize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal byte AESEncryptionStrength => 0;

		internal int AESSaltLen => 0;

		internal int AESOverheadSize => 0;

		public string Comment
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsDirectory => false;

		public bool IsFile => false;

		public ZipEntry(string name)
		{
		}

		internal ZipEntry(string name, int versionRequiredToExtract)
		{
		}

		internal ZipEntry(string name, int versionRequiredToExtract, int madeByInfo, CompressionMethod method)
		{
		}

		[Obsolete("Use Clone instead")]
		public ZipEntry(ZipEntry entry)
		{
		}

		private bool HasDosAttributes(int attributes)
		{
			return false;
		}

		public void ForceZip64()
		{
		}

		public bool IsZip64Forced()
		{
			return false;
		}

		internal void ProcessExtraData(bool localHeader)
		{
		}

		private void ProcessAESExtraData(ZipExtraData extraData)
		{
		}

		public bool IsCompressionMethodSupported()
		{
			return false;
		}

		public object Clone()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public static bool IsCompressionMethodSupported(CompressionMethod method)
		{
			return false;
		}

		public static string CleanName(string name)
		{
			return null;
		}
	}
}
