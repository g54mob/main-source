using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class FastZip
	{
		public enum Overwrite
		{
			Prompt = 0,
			Never = 1,
			Always = 2
		}

		public delegate bool ConfirmOverwriteDelegate(string fileName);

		private bool continueRunning_;

		private byte[] buffer_;

		private ZipOutputStream outputStream_;

		private ZipFile zipFile_;

		private string sourceDirectory_;

		private NameFilter fileFilter_;

		private NameFilter directoryFilter_;

		private Overwrite overwrite_;

		private ConfirmOverwriteDelegate confirmDelegate_;

		private bool restoreDateTimeOnExtract_;

		private bool restoreAttributesOnExtract_;

		private bool createEmptyDirectories_;

		private FastZipEvents events_;

		private IEntryFactory entryFactory_;

		private INameTransform extractNameTransform_;

		private UseZip64 useZip64_;

		private string password_;

		public bool CreateEmptyDirectories
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public IEntryFactory EntryFactory
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public bool RestoreDateTimeOnExtract
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RestoreAttributesOnExtract
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public FastZip()
		{
		}

		public FastZip(FastZipEvents events)
		{
		}

		public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
		{
		}

		public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter)
		{
		}

		public void CreateZip(Stream outputStream, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
		{
		}

		public void ExtractZip(string zipFileName, string targetDirectory, string fileFilter)
		{
		}

		public void ExtractZip(string zipFileName, string targetDirectory, Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate, string fileFilter, string directoryFilter, bool restoreDateTime)
		{
		}

		public void ExtractZip(Stream inputStream, string targetDirectory, Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate, string fileFilter, string directoryFilter, bool restoreDateTime, bool isStreamOwner)
		{
		}

		private void ProcessDirectory(object sender, DirectoryEventArgs e)
		{
		}

		private void ProcessFile(object sender, ScanEventArgs e)
		{
		}

		private void AddFileContents(string name, Stream stream)
		{
		}

		private void ExtractFileEntry(ZipEntry entry, string targetName)
		{
		}

		private void ExtractEntry(ZipEntry entry)
		{
		}

		private static int MakeExternalAttributes(FileInfo info)
		{
			return 0;
		}

		private static bool NameIsValid(string name)
		{
			return false;
		}
	}
}
