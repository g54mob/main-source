using System;
using Crosstales.FB.Wrapper;
using UnityEngine;

namespace Crosstales.FB
{
	[ExecuteInEditMode]
	public class WrapperExample : BaseCustomFileBrowser
	{
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
	}
}
