using System;

namespace Crosstales.FB.Wrapper
{
	public class FileBrowserWindows : BaseFileBrowser
	{
		private static FileBrowserWindows instance;

		private static string _initialPath;

		private const int OFN_EXPLORER = 524288;

		private const int MAX_OPEN_FILE_LENGTH = 65536;

		private const int MAX_SAVE_FILE_LENGTH = 4096;

		private const int MAX_PATH_LENGTH = 4096;

		private const int WM_USER = 1024;

		private const int BFFM_INITIALIZED = 1;

		private const int BFFM_SELCHANGED = 2;

		private const int BFFM_SETSELECTIONW = 1127;

		private const int BFFM_SETSTATUSTEXTW = 1128;

		private const uint BIF_NEWDIALOGSTYLE = 64u;

		private const uint BIF_SHAREABLE = 32768u;

		private static readonly IntPtr currentWindow;

		private static readonly char[] nullChar;

		private string allFilesText;

		public override bool canOpenFile => false;

		public override bool canOpenFolder => false;

		public override bool canSaveFile => false;

		public override bool canOpenMultipleFiles => false;

		public override bool canOpenMultipleFolders => false;

		public override bool isPlatformSupported => false;

		public override bool isWorkingInEditor => false;

		public override string CurrentOpenSingleFile { get; set; }

		public override string[] CurrentOpenFiles { get; set; }

		public override string CurrentOpenSingleFolder { get; set; }

		public override string[] CurrentOpenFolders { get; set; }

		public override string CurrentSaveFile { get; set; }

		public override string[] OpenFiles(string title, string directory, string defaultName, bool multiselect, params ExtensionFilter[] extensions)
		{
			return null;
		}

		public override string[] OpenFolders(string title, string directory, bool multiselect)
		{
			return null;
		}

		public override string SaveFile(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
			return null;
		}

		public override void OpenFilesAsync(string title, string directory, string defaultName, bool multiselect, ExtensionFilter[] extensions, Action<string[]> cb)
		{
		}

		public override void OpenFoldersAsync(string title, string directory, bool multiselect, Action<string[]> cb)
		{
		}

		public override void SaveFileAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb)
		{
		}

		private static string[] openFiles(string title, string directory, string defaultName, bool multiselect, params ExtensionFilter[] extensions)
		{
			return null;
		}

		private static string[] openFolders(string directory, bool isAsync)
		{
			return null;
		}

		private static string[] openFoldersNew(string directory, bool isAsync)
		{
			return null;
		}

		private static string saveFile(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
			return null;
		}

		private static int onBrowseEvent(IntPtr hWnd, int msg, IntPtr lp, IntPtr lpData)
		{
			return 0;
		}

		private static string getDefaultExtension(ExtensionFilter[] extensions)
		{
			return null;
		}

		private static string getFilterFromFileExtensionList(ExtensionFilter[] extensions)
		{
			return null;
		}
	}
}
