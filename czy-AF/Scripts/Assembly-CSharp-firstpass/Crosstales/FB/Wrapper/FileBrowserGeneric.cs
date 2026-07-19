using System;
using UnityEngine;

namespace Crosstales.FB.Wrapper
{
	public class FileBrowserGeneric : FileBrowserBase
	{
		public override bool canOpenMultipleFiles => false;

		public override bool canOpenMultipleFolders => false;

		public override bool isPlatformSupported => false;

		public override string[] OpenFiles(string title, string directory, ExtensionFilter[] extensions, bool multiselect)
		{
			Debug.LogWarning("'OpenFilePanel' is currently not supported for the current platform!");
			return new string[0];
		}

		public override string[] OpenFolders(string title, string directory, bool multiselect)
		{
			Debug.LogWarning("'OpenFolderPanel' is currently not supported for the current platform!");
			return new string[0];
		}

		public override string SaveFile(string title, string directory, string defaultName, ExtensionFilter[] extensions)
		{
			Debug.LogWarning("'SaveFilePanel' is currently not supported for the current platform!");
			return string.Empty;
		}

		public override void OpenFilesAsync(string title, string directory, ExtensionFilter[] extensions, bool multiselect, Action<string[]> cb)
		{
			cb(OpenFiles(title, directory, extensions, multiselect));
		}

		public override void OpenFoldersAsync(string title, string directory, bool multiselect, Action<string[]> cb)
		{
			cb(OpenFolders(title, directory, multiselect));
		}

		public override void SaveFileAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb)
		{
			cb(SaveFile(title, directory, defaultName, extensions));
		}
	}
}
