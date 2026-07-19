using System;
using System.Linq;
using Crosstales.Common.Util;
using Crosstales.FB.Util;
using Crosstales.FB.Wrapper;
using UnityEngine;

namespace Crosstales.FB
{
	public static class FileBrowser
	{
		private static readonly IFileBrowser platformWrapper;

		public static bool canOpenMultipleFiles => platformWrapper.canOpenMultipleFiles;

		public static bool canOpenMultipleFolders => platformWrapper.canOpenMultipleFolders;

		public static bool isPlatformSupported => platformWrapper.isPlatformSupported;

		static FileBrowser()
		{
			if (!BaseHelper.isEditor && !BaseHelper.isMacOSPlatform)
			{
				if (BaseHelper.isWindowsPlatform || BaseHelper.isWindowsEditor)
				{
					platformWrapper = new FileBrowserWindows();
				}
				else if (!BaseHelper.isLinuxPlatform && !BaseHelper.isWSAPlatform)
				{
					platformWrapper = new FileBrowserGeneric();
				}
			}
			if (Config.DEBUG)
			{
				Debug.Log(platformWrapper);
			}
		}

		public static string OpenSingleFile(string extension = "*")
		{
			return OpenSingleFile(Constants.TEXT_OPEN_FILE, string.Empty, getFilter(extension));
		}

		public static string OpenSingleFile(string title, string directory, params string[] extensions)
		{
			return OpenSingleFile(title, directory, getFilter(extensions));
		}

		public static string OpenSingleFile(string title, string directory, params ExtensionFilter[] extensions)
		{
			return platformWrapper.OpenSingleFile(title, directory, extensions);
		}

		public static string[] OpenFiles(string extension = "*")
		{
			return OpenFiles(Constants.TEXT_OPEN_FILES, string.Empty, getFilter(extension));
		}

		public static string[] OpenFiles(string title, string directory, params string[] extensions)
		{
			return OpenFiles(title, directory, getFilter(extensions));
		}

		public static string[] OpenFiles(string title, string directory, params ExtensionFilter[] extensions)
		{
			return platformWrapper.OpenFiles(title, directory, extensions, multiselect: true);
		}

		public static string OpenSingleFolder()
		{
			return OpenSingleFolder(Constants.TEXT_OPEN_FOLDER);
		}

		public static string OpenSingleFolder(string title, string directory = "")
		{
			return platformWrapper.OpenSingleFolder(title, directory);
		}

		public static string[] OpenFolders()
		{
			return OpenFolders(Constants.TEXT_OPEN_FOLDERS);
		}

		public static string[] OpenFolders(string title, string directory = "")
		{
			return platformWrapper.OpenFolders(title, directory, multiselect: true);
		}

		public static string SaveFile(string defaultName = "", string extension = "*")
		{
			return SaveFile(Constants.TEXT_SAVE_FILE, string.Empty, defaultName, getFilter(extension));
		}

		public static string SaveFile(string title, string directory, string defaultName, params string[] extensions)
		{
			return SaveFile(title, directory, defaultName, getFilter(extensions));
		}

		public static string SaveFile(string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
			return platformWrapper.SaveFile(title, directory, string.IsNullOrEmpty(defaultName) ? Constants.TEXT_SAVE_FILE_NAME : defaultName, extensions);
		}

		public static void OpenFilesAsync(Action<string[]> cb, bool multiselect = true, params string[] extensions)
		{
			OpenFilesAsync(cb, multiselect ? Constants.TEXT_OPEN_FILES : Constants.TEXT_OPEN_FILE, string.Empty, multiselect, getFilter(extensions));
		}

		public static void OpenFilesAsync(Action<string[]> cb, string title, string directory, bool multiselect = true, params string[] extensions)
		{
			OpenFilesAsync(cb, title, directory, multiselect, getFilter(extensions));
		}

		public static void OpenFilesAsync(Action<string[]> cb, string title, string directory, bool multiselect = true, params ExtensionFilter[] extensions)
		{
			platformWrapper.OpenFilesAsync(title, directory, extensions, multiselect, cb);
		}

		public static void OpenFoldersAsync(Action<string[]> cb, bool multiselect = true)
		{
			OpenFoldersAsync(cb, Constants.TEXT_OPEN_FOLDERS, string.Empty, multiselect);
		}

		public static void OpenFoldersAsync(Action<string[]> cb, string title, string directory = "", bool multiselect = true)
		{
			platformWrapper.OpenFoldersAsync(title, directory, multiselect, cb);
		}

		public static void SaveFileAsync(Action<string> cb, string defaultName = "", string extension = "*")
		{
			SaveFileAsync(cb, Constants.TEXT_SAVE_FILE, string.Empty, defaultName, getFilter(extension));
		}

		public static void SaveFileAsync(Action<string> cb, string title, string directory, string defaultName, params string[] extensions)
		{
			SaveFileAsync(cb, title, directory, defaultName, getFilter(extensions));
		}

		public static void SaveFileAsync(Action<string> cb, string title, string directory, string defaultName, params ExtensionFilter[] extensions)
		{
			platformWrapper.SaveFileAsync(title, directory, string.IsNullOrEmpty(defaultName) ? Constants.TEXT_SAVE_FILE_NAME : defaultName, extensions, cb);
		}

		public static string[] GetFiles(string path, bool isRecursive = false, params string[] extensions)
		{
			return BaseHelper.GetFiles(path, isRecursive, extensions);
		}

		public static string[] GetFiles(string path, bool isRecursive, params ExtensionFilter[] extensions)
		{
			return GetFiles(path, isRecursive, extensions.SelectMany((ExtensionFilter extensionFilter) => extensionFilter.Extensions).ToArray());
		}

		public static string[] GetDirectories(string path, bool isRecursive = false)
		{
			return BaseHelper.GetDirectories(path, isRecursive);
		}

		private static ExtensionFilter[] getFilter(params string[] extensions)
		{
			if (extensions != null && extensions.Length != 0)
			{
				if (extensions.Length == 1 && "*".Equals(extensions[0]))
				{
					return null;
				}
				ExtensionFilter[] array = new ExtensionFilter[extensions.Length];
				for (int i = 0; i < extensions.Length; i++)
				{
					string text = (string.IsNullOrEmpty(extensions[i]) ? "*" : extensions[i]);
					if (text.Equals("*"))
					{
						array[i] = new ExtensionFilter(Constants.TEXT_ALL_FILES, BaseHelper.isMacOSEditor ? string.Empty : text);
					}
					else
					{
						array[i] = new ExtensionFilter(text, text);
					}
				}
				if (Config.DEBUG)
				{
					Debug.Log("getFilter: " + array.CTDump());
				}
				return array;
			}
			return null;
		}
	}
}
