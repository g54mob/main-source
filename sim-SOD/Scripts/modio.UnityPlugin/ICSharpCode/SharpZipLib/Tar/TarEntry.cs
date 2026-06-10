using System;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarEntry
	{
		private string file;

		private TarHeader header;

		public TarHeader TarHeader => null;

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

		public string File => null;

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

		public bool IsDirectory => false;

		private TarEntry()
		{
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public TarEntry(byte[] headerBuffer)
		{
		}

		public TarEntry(byte[] headerBuffer, Encoding nameEncoding)
		{
		}

		public TarEntry(TarHeader header)
		{
		}

		public object Clone()
		{
			return null;
		}

		public static TarEntry CreateTarEntry(string name)
		{
			return null;
		}

		public static TarEntry CreateEntryFromFile(string fileName)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool IsDescendent(TarEntry toTest)
		{
			return false;
		}

		public void SetIds(int userId, int groupId)
		{
		}

		public void SetNames(string userName, string groupName)
		{
		}

		public void GetFileTarHeader(TarHeader header, string file)
		{
		}

		public TarEntry[] GetDirectoryEntries()
		{
			return null;
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public void WriteEntryHeader(byte[] outBuffer)
		{
		}

		public void WriteEntryHeader(byte[] outBuffer, Encoding nameEncoding)
		{
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public static void AdjustEntryName(byte[] buffer, string newName)
		{
		}

		public static void AdjustEntryName(byte[] buffer, string newName, Encoding nameEncoding)
		{
		}

		public static void NameTarHeader(TarHeader header, string name)
		{
		}
	}
}
