using System;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarHeader
	{
		public const int NAMELEN = 100;

		public const int MODELEN = 8;

		public const int UIDLEN = 8;

		public const int GIDLEN = 8;

		public const int CHKSUMLEN = 8;

		public const int CHKSUMOFS = 148;

		public const int SIZELEN = 12;

		public const int MAGICLEN = 6;

		public const int VERSIONLEN = 2;

		public const int MODTIMELEN = 12;

		public const int UNAMELEN = 32;

		public const int GNAMELEN = 32;

		public const int DEVLEN = 8;

		public const int PREFIXLEN = 155;

		public const byte LF_OLDNORM = 0;

		public const byte LF_NORMAL = 48;

		public const byte LF_LINK = 49;

		public const byte LF_SYMLINK = 50;

		public const byte LF_CHR = 51;

		public const byte LF_BLK = 52;

		public const byte LF_DIR = 53;

		public const byte LF_FIFO = 54;

		public const byte LF_CONTIG = 55;

		public const byte LF_GHDR = 103;

		public const byte LF_XHDR = 120;

		public const byte LF_ACL = 65;

		public const byte LF_GNU_DUMPDIR = 68;

		public const byte LF_EXTATTR = 69;

		public const byte LF_META = 73;

		public const byte LF_GNU_LONGLINK = 75;

		public const byte LF_GNU_LONGNAME = 76;

		public const byte LF_GNU_MULTIVOL = 77;

		public const byte LF_GNU_NAMES = 78;

		public const byte LF_GNU_SPARSE = 83;

		public const byte LF_GNU_VOLHDR = 86;

		public const string TMAGIC = "ustar";

		public const string GNU_TMAGIC = "ustar  ";

		private const long timeConversionFactor = 10000000L;

		private static readonly DateTime dateTime1970;

		private string name;

		private int mode;

		private int userId;

		private int groupId;

		private long size;

		private DateTime modTime;

		private int checksum;

		private bool isChecksumValid;

		private byte typeFlag;

		private string linkName;

		private string magic;

		private string version;

		private string userName;

		private string groupName;

		private int devMajor;

		private int devMinor;

		internal static int userIdAsSet;

		internal static int groupIdAsSet;

		internal static string userNameAsSet;

		internal static string groupNameAsSet;

		internal static int defaultUserId;

		internal static int defaultGroupId;

		internal static string defaultGroupName;

		internal static string defaultUser;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Mode
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int UserId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int GroupId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

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

		public DateTime ModTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public int Checksum => 0;

		public bool IsChecksumValid => false;

		public byte TypeFlag
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string LinkName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Magic
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Version
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string UserName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string GroupName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int DevMajor
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int DevMinor
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Obsolete("Use the Name property instead", true)]
		public string GetName()
		{
			return null;
		}

		public object Clone()
		{
			return null;
		}

		public void ParseBuffer(byte[] header, Encoding nameEncoding)
		{
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public void ParseBuffer(byte[] header)
		{
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public void WriteHeader(byte[] outBuffer)
		{
		}

		public void WriteHeader(byte[] outBuffer, Encoding nameEncoding)
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		internal static void SetValueDefaults(int userId, string userName, int groupId, string groupName)
		{
		}

		internal static void RestoreSetValues()
		{
		}

		private static long ParseBinaryOrOctal(byte[] header, int offset, int length)
		{
			return 0L;
		}

		public static long ParseOctal(byte[] header, int offset, int length)
		{
			return 0L;
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public static StringBuilder ParseName(byte[] header, int offset, int length)
		{
			return null;
		}

		public static StringBuilder ParseName(byte[] header, int offset, int length, Encoding encoding)
		{
			return null;
		}

		public static int GetNameBytes(StringBuilder name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			return 0;
		}

		public static int GetNameBytes(string name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			return 0;
		}

		public static int GetNameBytes(string name, int nameOffset, byte[] buffer, int bufferOffset, int length, Encoding encoding)
		{
			return 0;
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public static int GetNameBytes(StringBuilder name, byte[] buffer, int offset, int length)
		{
			return 0;
		}

		public static int GetNameBytes(StringBuilder name, byte[] buffer, int offset, int length, Encoding encoding)
		{
			return 0;
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public static int GetNameBytes(string name, byte[] buffer, int offset, int length)
		{
			return 0;
		}

		public static int GetNameBytes(string name, byte[] buffer, int offset, int length, Encoding encoding)
		{
			return 0;
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			return 0;
		}

		public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length, Encoding encoding)
		{
			return 0;
		}

		public static int GetOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			return 0;
		}

		private static int GetBinaryOrOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			return 0;
		}

		private static void GetCheckSumOctalBytes(long value, byte[] buffer, int offset, int length)
		{
		}

		private static int ComputeCheckSum(byte[] buffer)
		{
			return 0;
		}

		private static int MakeCheckSum(byte[] buffer)
		{
			return 0;
		}

		private static int GetCTime(DateTime dateTime)
		{
			return 0;
		}

		private static DateTime GetDateTimeFromCTime(long ticks)
		{
			return default(DateTime);
		}
	}
}
