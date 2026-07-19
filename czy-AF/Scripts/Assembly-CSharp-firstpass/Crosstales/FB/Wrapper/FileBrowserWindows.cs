using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AOT;
using Crosstales.Common.Util;
using Crosstales.FB.Util;
using UnityEngine;

namespace Crosstales.FB.Wrapper
{
	public class FileBrowserWindows : FileBrowserBase
	{
		private static string _initialPath = string.Empty;

		private const int OFN_NOCHANGEDIR = 8;

		private const int OFN_ALLOWMULTISELECT = 512;

		private const int OFN_EXPLORER = 524288;

		private const int OFN_FILEMUSTEXIST = 4096;

		private const int OFN_PATHMUSTEXIST = 2048;

		private const int OFN_OVERWRITEPROMPT = 2;

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

		private static readonly IntPtr currentWindow = NativeMethods.GetActiveWindow();

		private static readonly char[] nullChar = new char[1];

		public override bool canOpenMultipleFiles => true;

		public override bool canOpenMultipleFolders => false;

		public override bool isPlatformSupported
		{
			get
			{
				if (!BaseHelper.isWindowsPlatform)
				{
					return BaseHelper.isWindowsEditor;
				}
				return true;
			}
		}

		public override string[] OpenFiles(string title, string directory, ExtensionFilter[] extensions, bool multiselect)
		{
			NativeMethods.OpenFileName ofn = default(NativeMethods.OpenFileName);
			string text = BaseHelper.ValidatePath(directory);
			try
			{
				ofn.dlgOwner = currentWindow;
				ofn.filter = getFilterFromFileExtensionList(extensions);
				ofn.filterIndex = 1;
				if (!string.IsNullOrEmpty(text))
				{
					ofn.initialDir = text;
				}
				ofn.file = BaseHelper.CreateString(" ", 65536);
				ofn.maxFile = 65536;
				ofn.title = title;
				ofn.flags = 0x1808 | (multiselect ? 524800 : 0);
				ofn.structSize = Marshal.SizeOf(ofn);
				if (NativeMethods.GetOpenFileName(ref ofn))
				{
					string file = ofn.file;
					if (multiselect)
					{
						string[] array = file.Split(nullChar, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length > 2)
						{
							List<string> list = new List<string>();
							for (int i = 1; i < array.Length - 1; i++)
							{
								string item = BaseHelper.ValidateFile(array[0] + "\\" + array[i]);
								list.Add(item);
							}
							return list.ToArray();
						}
					}
					return new string[1] { BaseHelper.ValidateFile(file) };
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			return new string[0];
		}

		public override string[] OpenFolders(string title, string directory, bool multiselect)
		{
			return openFolders(title, directory, multiselect, isAsync: false);
		}

		public override string SaveFile(string title, string directory, string defaultName, ExtensionFilter[] extensions)
		{
			NativeMethods.OpenFileName sfn = default(NativeMethods.OpenFileName);
			string text = BaseHelper.ValidatePath(directory);
			string defaultExtension = getDefaultExtension(extensions);
			try
			{
				sfn.dlgOwner = currentWindow;
				sfn.filter = getFilterFromFileExtensionList(extensions);
				sfn.filterIndex = 1;
				string text2 = (defaultExtension.Equals("*") ? defaultExtension : (defaultName + "." + defaultExtension));
				if (!string.IsNullOrEmpty(text))
				{
					sfn.initialDir = text;
				}
				sfn.file = text2 + BaseHelper.CreateString(" ", 4096 - text2.Length);
				sfn.maxFile = 4096;
				sfn.title = title;
				sfn.defExt = defaultExtension;
				sfn.flags = 2058;
				sfn.structSize = Marshal.SizeOf(sfn);
				if (NativeMethods.GetSaveFileName(ref sfn))
				{
					return BaseHelper.ValidateFile(sfn.file);
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			return string.Empty;
		}

		public override void OpenFilesAsync(string title, string directory, ExtensionFilter[] extensions, bool multiselect, Action<string[]> cb)
		{
			new Thread((ThreadStart)delegate
			{
				cb(OpenFiles(title, directory, extensions, multiselect));
			}).Start();
		}

		public override void OpenFoldersAsync(string title, string directory, bool multiselect, Action<string[]> cb)
		{
			new Thread((ThreadStart)delegate
			{
				cb(openFolders(title, directory, multiselect, isAsync: true));
			}).Start();
		}

		public override void SaveFileAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb)
		{
			new Thread((ThreadStart)delegate
			{
				cb(SaveFile(title, directory, defaultName, extensions));
			}).Start();
		}

		private string[] openFolders(string title, string directory, bool multiselect, bool isAsync)
		{
			if (Config.DEBUG && !string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("'title' is not supported under Windows.");
			}
			if (multiselect)
			{
				Debug.LogWarning("'multiselect' for folders is not supported under Windows.");
			}
			NativeMethods.BROWSEINFO lpbi = default(NativeMethods.BROWSEINFO);
			if (!string.IsNullOrEmpty(directory))
			{
				_initialPath = BaseHelper.ValidatePath(directory);
			}
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			string text = string.Empty;
			try
			{
				intPtr2 = Marshal.AllocHGlobal(4096);
				lpbi.dlgOwner = currentWindow;
				lpbi.pidlRoot = IntPtr.Zero;
				if (isAsync)
				{
					lpbi.ulFlags = 32768u;
				}
				else
				{
					lpbi.ulFlags = 32832u;
				}
				lpbi.lpfn = onBrowseEvent;
				lpbi.lParam = IntPtr.Zero;
				lpbi.iImage = 0;
				intPtr = NativeMethods.SHBrowseForFolder(ref lpbi);
				if (NativeMethods.SHGetPathFromIDList(intPtr, intPtr2))
				{
					text = (_initialPath = Marshal.PtrToStringUni(intPtr2));
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			finally
			{
				if (intPtr2 != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr2);
				}
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeCoTaskMem(intPtr);
				}
			}
			return new string[1] { text };
		}

		[MonoPInvokeCallback(typeof(NativeMethods.BrowseCallbackProc))]
		private static int onBrowseEvent(IntPtr hWnd, int msg, IntPtr lp, IntPtr lpData)
		{
			switch (msg)
			{
			case 1:
				NativeMethods.SendMessage(new HandleRef(null, hWnd), 1127, 1, _initialPath);
				break;
			case 2:
			{
				IntPtr intPtr = Marshal.AllocHGlobal(260 * Marshal.SystemDefaultCharSize);
				if (NativeMethods.SHGetPathFromIDList(lp, intPtr))
				{
					NativeMethods.SendMessage(new HandleRef(null, hWnd), 1128u, 0, intPtr);
				}
				Marshal.FreeHGlobal(intPtr);
				break;
			}
			}
			return 0;
		}

		private static string getDefaultExtension(ExtensionFilter[] extensions)
		{
			if (extensions != null && extensions.Length != 0 && extensions[0].Extensions.Length != 0)
			{
				return extensions[0].Extensions[0];
			}
			return "*";
		}

		private static string getFilterFromFileExtensionList(ExtensionFilter[] extensions)
		{
			if (extensions != null && extensions.Length != 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < extensions.Length; i++)
				{
					ExtensionFilter extensionFilter = extensions[i];
					stringBuilder.Append(extensionFilter.Name);
					stringBuilder.Append("\0");
					for (int j = 0; j < extensionFilter.Extensions.Length; j++)
					{
						stringBuilder.Append("*.");
						stringBuilder.Append(extensionFilter.Extensions[j]);
						if (j + 1 < extensionFilter.Extensions.Length)
						{
							stringBuilder.Append(";");
						}
					}
					stringBuilder.Append("\0");
				}
				stringBuilder.Append("\0");
				if (Config.DEBUG)
				{
					Debug.Log("getFilterFromFileExtensionList: " + stringBuilder);
				}
				return stringBuilder.ToString();
			}
			return Constants.TEXT_ALL_FILES + "\0*.*\0\0";
		}
	}
}
