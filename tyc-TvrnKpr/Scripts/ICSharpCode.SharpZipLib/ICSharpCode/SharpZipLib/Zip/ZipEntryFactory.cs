using System;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ZipEntryFactory : IEntryFactory
	{
		public enum TimeSetting
		{
			LastWriteTime = 0,
			LastWriteTimeUtc = 1,
			CreateTime = 2,
			CreateTimeUtc = 3,
			LastAccessTime = 4,
			LastAccessTimeUtc = 5,
			Fixed = 6
		}

		private INameTransform nameTransform_;

		private DateTime fixedDateTime_;

		private TimeSetting timeSetting_;

		private bool isUnicodeText_;

		private int getAttributes_;

		private int setAttributes_;

		public INameTransform NameTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TimeSetting Setting
		{
			get
			{
				return default(TimeSetting);
			}
			set
			{
			}
		}

		public DateTime FixedDateTime
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public int GetAttributes
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SetAttributes
		{
			get
			{
				return 0;
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

		public ZipEntryFactory()
		{
		}

		public ZipEntryFactory(TimeSetting timeSetting)
		{
		}

		public ZipEntryFactory(DateTime time)
		{
		}

		public ZipEntry MakeFileEntry(string fileName)
		{
			return null;
		}

		public ZipEntry MakeFileEntry(string fileName, bool useFileSystem)
		{
			return null;
		}

		public ZipEntry MakeDirectoryEntry(string directoryName)
		{
			return null;
		}

		public ZipEntry MakeDirectoryEntry(string directoryName, bool useFileSystem)
		{
			return null;
		}
	}
}
