using System;

namespace Crosstales.FB.Wrapper
{
	public abstract class FileBrowserBase : IFileBrowser
	{
		public abstract bool canOpenMultipleFiles { get; }

		public abstract bool canOpenMultipleFolders { get; }

		public abstract bool isPlatformSupported { get; }

		public string OpenSingleFile(string title, string directory, ExtensionFilter[] extensions)
		{
			string[] array = OpenFiles(title, directory, extensions, multiselect: false);
			if (array.Length == 0)
			{
				return string.Empty;
			}
			return array[0];
		}

		public abstract string[] OpenFiles(string title, string directory, ExtensionFilter[] extensions, bool multiselect);

		public string OpenSingleFolder(string title, string directory)
		{
			string[] array = OpenFolders(title, directory, multiselect: false);
			if (array.Length == 0)
			{
				return string.Empty;
			}
			return array[0];
		}

		public abstract string[] OpenFolders(string title, string directory, bool multiselect);

		public abstract string SaveFile(string title, string directory, string defaultName, ExtensionFilter[] extensions);

		public abstract void OpenFilesAsync(string title, string directory, ExtensionFilter[] extensions, bool multiselect, Action<string[]> cb);

		public abstract void OpenFoldersAsync(string title, string directory, bool multiselect, Action<string[]> cb);

		public abstract void SaveFileAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb);
	}
}
