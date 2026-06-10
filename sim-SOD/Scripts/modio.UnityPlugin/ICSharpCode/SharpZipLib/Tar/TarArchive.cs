using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarArchive : IDisposable
	{
		private bool keepOldFiles;

		private bool asciiTranslate;

		private int userId;

		private string userName;

		private int groupId;

		private string groupName;

		private string rootPath;

		private string pathPrefix;

		private bool applyUserInfoOverrides;

		private TarInputStream tarIn;

		private TarOutputStream tarOut;

		private bool isDisposed;

		public bool AsciiTranslate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string PathPrefix
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string RootPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ApplyUserInfoOverrides
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int UserId => 0;

		public string UserName => null;

		public int GroupId => 0;

		public string GroupName => null;

		public int RecordSize => 0;

		public bool IsStreamOwner
		{
			set
			{
			}
		}

		public event ProgressMessageHandler ProgressMessageEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void OnProgressMessageEvent(TarEntry entry, string message)
		{
		}

		protected TarArchive()
		{
		}

		protected TarArchive(TarInputStream stream)
		{
		}

		protected TarArchive(TarOutputStream stream)
		{
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public static TarArchive CreateInputTarArchive(Stream inputStream)
		{
			return null;
		}

		public static TarArchive CreateInputTarArchive(Stream inputStream, Encoding nameEncoding)
		{
			return null;
		}

		[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
		public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor)
		{
			return null;
		}

		public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor, Encoding nameEncoding)
		{
			return null;
		}

		public static TarArchive CreateOutputTarArchive(Stream outputStream, Encoding nameEncoding)
		{
			return null;
		}

		public static TarArchive CreateOutputTarArchive(Stream outputStream)
		{
			return null;
		}

		public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor)
		{
			return null;
		}

		public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor, Encoding nameEncoding)
		{
			return null;
		}

		public void SetKeepOldFiles(bool keepExistingFiles)
		{
		}

		[Obsolete("Use the AsciiTranslate property")]
		public void SetAsciiTranslation(bool translateAsciiFiles)
		{
		}

		public void SetUserInfo(int userId, string userName, int groupId, string groupName)
		{
		}

		[Obsolete("Use Close instead")]
		public void CloseArchive()
		{
		}

		public void ListContents()
		{
		}

		public void ExtractContents(string destinationDirectory)
		{
		}

		public void ExtractContents(string destinationDirectory, bool allowParentTraversal)
		{
		}

		private void ExtractEntry(string destDir, TarEntry entry, bool allowParentTraversal)
		{
		}

		private void ExtractAndTranslateEntry(string destFile, Stream outputStream)
		{
		}

		public void WriteEntry(TarEntry sourceEntry, bool recurse)
		{
		}

		private void WriteEntryCore(TarEntry sourceEntry, bool recurse)
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public virtual void Close()
		{
		}

		~TarArchive()
		{
		}

		private static void EnsureDirectoryExists(string directoryName)
		{
		}

		private static bool IsBinary(string filename)
		{
			return false;
		}
	}
}
