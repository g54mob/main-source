using System;
using System.Runtime.InteropServices;

namespace SFB
{
	public class StandaloneFileBrowserWindows : IStandaloneFileBrowser
	{
		[PreserveSig]
		private static extern IntPtr GetActiveWindow();

		public string[] OpenFilePanel(string title, string directory, ExtensionFilter[] extensions, bool multiselect)
		{
			return null;
		}

		public void OpenFilePanelAsync(string title, string directory, ExtensionFilter[] extensions, bool multiselect, Action<string[]> cb)
		{
		}

		public string[] OpenFolderPanel(string title, string directory, bool multiselect)
		{
			return null;
		}

		public void OpenFolderPanelAsync(string title, string directory, bool multiselect, Action<string[]> cb)
		{
		}

		public string SaveFilePanel(string title, string directory, string defaultName, ExtensionFilter[] extensions)
		{
			return null;
		}

		public void SaveFilePanelAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb)
		{
		}

		private static string GetFilterFromFileExtensionList(ExtensionFilter[] extensions)
		{
			return null;
		}

		private static string GetDirectoryPath(string directory)
		{
			return null;
		}
	}
}
