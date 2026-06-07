using System;

namespace Crosstales.FB.Wrapper
{
	public interface IFileBrowser
	{
		bool canOpenFile { get; }

		bool canOpenFolder { get; }

		bool canSaveFile { get; }

		bool canOpenMultipleFiles { get; }

		bool canOpenMultipleFolders { get; }

		bool isPlatformSupported { get; }

		bool isWorkingInEditor { get; }

		string CurrentOpenSingleFile { get; set; }

		string[] CurrentOpenFiles { get; set; }

		string CurrentOpenSingleFolder { get; set; }

		string[] CurrentOpenFolders { get; set; }

		string CurrentSaveFile { get; set; }

		byte[] CurrentOpenSingleFileData { get; }

		string OpenSingleFile(string title, string directory, string defaultName, params ExtensionFilter[] extensions);

		string[] OpenFiles(string title, string directory, string defaultName, bool multiselect, params ExtensionFilter[] extensions);

		string OpenSingleFolder(string title, string directory);

		string[] OpenFolders(string title, string directory, bool multiselect);

		string SaveFile(string title, string directory, string defaultName, params ExtensionFilter[] extensions);

		void OpenFilesAsync(string title, string directory, string defaultName, bool multiselect, ExtensionFilter[] extensions, Action<string[]> cb);

		void OpenFoldersAsync(string title, string directory, bool multiselect, Action<string[]> cb);

		void SaveFileAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb);
	}
}
