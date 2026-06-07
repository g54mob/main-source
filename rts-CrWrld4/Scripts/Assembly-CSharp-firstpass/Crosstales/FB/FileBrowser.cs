using System;
using System.Runtime.CompilerServices;
using Crosstales.Common.Util;
using Crosstales.FB.Wrapper;
using UnityEngine;

namespace Crosstales.FB
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class FileBrowser : Singleton<FileBrowser>
	{
		public delegate void OpenFilesStart();

		public delegate void OpenFilesComplete(bool selected, string singleFile, string[] files);

		public delegate void OpenFoldersStart();

		public delegate void OpenFoldersComplete(bool selected, string singleFolder, string[] folders);

		public delegate void SaveFileStart();

		public delegate void SaveFileComplete(bool selected, string file);

		[SerializeField]
		private BaseCustomFileBrowser customWrapper;

		[SerializeField]
		private bool customMode;

		[SerializeField]
		private bool legacyFolderBrowser;

		[SerializeField]
		private bool askOverwriteFile;

		[SerializeField]
		private string titleOpenFile;

		[SerializeField]
		private string titleOpenFiles;

		[SerializeField]
		private string titleOpenFolder;

		[SerializeField]
		private string titleOpenFolders;

		[SerializeField]
		private string titleSaveFile;

		[SerializeField]
		private string textAllFiles;

		[SerializeField]
		private string nameSaveFile;

		private static string lastOpenSingleFile;

		private static string[] lastOpenFiles;

		private static string lastOpenSingleFolder;

		private static string[] lastOpenFolders;

		private static string lastSaveFile;

		private WrapperHolder wrapperHolder;

		public OnOpenFilesCompleted OnOpenFilesCompleted;

		public OnOpenFoldersCompleted OnOpenFoldersCompleted;

		public OnSaveFileCompleted OnSaveFileCompleted;

		public BaseCustomFileBrowser CustomWrapper
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CustomMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LegacyFolderBrowser
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AskOverwriteFile
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string TitleOpenFile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TitleOpenFiles
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TitleOpenFolder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TitleOpenFolders
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TitleSaveFile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TextAllFiles
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string NameSaveFile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CurrentOpenSingleFile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] CurrentOpenFiles
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CurrentOpenSingleFolder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] CurrentOpenFolders
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CurrentSaveFile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public byte[] CurrentOpenSingleFileData => null;

		private bool canOpenFile => false;

		private bool canOpenFolder => false;

		private bool canSaveFile => false;

		public bool canOpenMultipleFiles => false;

		public bool canOpenMultipleFolders => false;

		public bool isPlatformSupported => false;

		public bool isWorkingInEditor => false;

		public event OpenFilesStart OnOpenFilesStart
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

		public event OpenFilesComplete OnOpenFilesComplete
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

		public event OpenFoldersStart OnOpenFoldersStart
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

		public event OpenFoldersComplete OnOpenFoldersComplete
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

		public event SaveFileStart OnSaveFileStart
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

		public event SaveFileComplete OnSaveFileComplete
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

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		public string OpenSingleFile(string extension = "*")
		{
			return null;
		}

		public string OpenSingleFile(string title, string directory, string defaultName, params string[] extensions)
		{
			return null;
		}

		public string OpenSingleFile(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
			return null;
		}

		public string[] OpenFiles(string extension = "*")
		{
			return null;
		}

		public string[] OpenFiles(string title, string directory, string defaultName, params string[] extensions)
		{
			return null;
		}

		public string[] OpenFiles(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
			return null;
		}

		public string OpenSingleFolder()
		{
			return null;
		}

		public string OpenSingleFolder(string title, string directory = "")
		{
			return null;
		}

		public string[] OpenFolders()
		{
			return null;
		}

		public string[] OpenFolders(string title, string directory = "")
		{
			return null;
		}

		public string SaveFile(string defaultName = "", string extension = "*")
		{
			return null;
		}

		public string SaveFile(string title, string directory, string defaultName, params string[] extensions)
		{
			return null;
		}

		public string SaveFile(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
			return null;
		}

		public void OpenSingleFileAsync(string extension = "*")
		{
		}

		public void OpenSingleFileAsync(string title, string directory, string defaultName, params string[] extensions)
		{
		}

		public void OpenSingleFileAsync(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
		}

		public void OpenFilesAsync(bool multiselect = true, params string[] extensions)
		{
		}

		public void OpenFilesAsync(string title, string directory, string defaultName, bool multiselect = true, params string[] extensions)
		{
		}

		public void OpenFilesAsync(string title, string directory, string defaultName, bool multiselect = true, params ExtensionFilter[] extensions)
		{
		}

		public void OpenSingleFolderAsync()
		{
		}

		public void OpenSingleFolderAsync(string title, string directory = "")
		{
		}

		public void OpenFoldersAsync(bool multiselect = true)
		{
		}

		public void OpenFoldersAsync(string title, string directory = "", bool multiselect = true)
		{
		}

		public void SaveFileAsync(string defaultName = "", string extension = "*")
		{
		}

		public void SaveFileAsync(string title, string directory, string defaultName, params string[] extensions)
		{
		}

		public void SaveFileAsync(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
		}

		public string[] GetFiles(string path, bool isRecursive = false, params string[] extensions)
		{
			return null;
		}

		public string[] GetFiles(string path, bool isRecursive, params ExtensionFilter[] extensions)
		{
			return null;
		}

		public string[] GetFolders(string path, bool isRecursive = false)
		{
			return null;
		}

		public string[] GetDrives()
		{
			return null;
		}

		public static void CopyFile(string sourceFile, string destFile, bool move = false)
		{
		}

		public static void CopyFolder(string sourcePath, string destPath, bool move = false)
		{
		}

		public static void ShowFile(string file)
		{
		}

		public static void ShowFolder(string path)
		{
		}

		public static void OpenFile(string file)
		{
		}

		public void OpenFilesAsync(Action<string[]> cb, bool multiselect = true, params string[] extensions)
		{
		}

		public void OpenFilesAsync(Action<string[]> cb, string title, string directory, string defaultName, bool multiselect = true, params string[] extensions)
		{
		}

		public void OpenFilesAsync(Action<string[]> cb, string title, string directory, string defaultName, bool multiselect = true, params ExtensionFilter[] extensions)
		{
		}

		public void OpenFoldersAsync(Action<string[]> cb, bool multiselect = true)
		{
		}

		public void OpenFoldersAsync(Action<string[]> cb, string title, string directory = "", bool multiselect = true)
		{
		}

		public void SaveFileAsync(Action<string> cb, string defaultName = "", string extension = "*")
		{
		}

		public void SaveFileAsync(Action<string> cb, string title, string directory, string defaultName, params string[] extensions)
		{
		}

		public void SaveFileAsync(Action<string> cb, string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
		}

		private void setOpenFiles(params string[] paths)
		{
		}

		private void setOpenFolders(params string[] paths)
		{
		}

		private void setSaveFile(params string[] paths)
		{
		}

		private ExtensionFilter[] getFilter(params string[] extensions)
		{
			return null;
		}

		private void makeSureInstanceExists()
		{
		}

		private void onOpenFilesStart()
		{
		}

		private void onOpenFilesComplete(bool selected, string singleFile, string[] files)
		{
		}

		private void onOpenFoldersStart()
		{
		}

		private void onOpenFoldersComplete(bool selected, string singleFolder, string[] folders)
		{
		}

		private void onSaveFileStart()
		{
		}

		private void onSaveFileComplete(bool selected, string file)
		{
		}
	}
}
