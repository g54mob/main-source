using System;

namespace Crosstales.FB.Wrapper
{
	public interface IFileBrowser
	{
		bool canOpenMultipleFiles { get; }

		bool canOpenMultipleFolders { get; }

		bool isPlatformSupported { get; }

		string OpenSingleFile(string title, string directory, ExtensionFilter[] extensions);

		string[] OpenFiles(string title, string directory, ExtensionFilter[] extensions, bool multiselect);

		string OpenSingleFolder(string title, string directory);

		string[] OpenFolders(string title, string directory, bool multiselect);

		string SaveFile(string title, string directory, string defaultName, ExtensionFilter[] extensions);

		void OpenFilesAsync(string title, string directory, ExtensionFilter[] extensions, bool multiselect, Action<string[]> cb);

		void OpenFoldersAsync(string title, string directory, bool multiselect, Action<string[]> cb);

		void SaveFileAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb);
	}
}
