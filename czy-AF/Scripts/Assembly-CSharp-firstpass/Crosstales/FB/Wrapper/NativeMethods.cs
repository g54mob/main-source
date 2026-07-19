using System;
using System.Runtime.InteropServices;

namespace Crosstales.FB.Wrapper
{
	internal static class NativeMethods
	{
		public delegate int BrowseCallbackProc(IntPtr hwnd, int uMsg, IntPtr lParam, IntPtr lpData);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct OpenFileName
		{
			public int structSize;

			public IntPtr dlgOwner;

			public IntPtr instance;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string filter;

			[MarshalAs(UnmanagedType.LPStr)]
			public string customFilter;

			public int maxCustFilter;

			public int filterIndex;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string file;

			public int maxFile;

			[MarshalAs(UnmanagedType.LPStr)]
			public string fileTitle;

			public int maxFileTitle;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string initialDir;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string title;

			public int flags;

			public ushort fileOffset;

			public ushort fileExtension;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string defExt;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string custData;

			public IntPtr hook;

			[MarshalAs(UnmanagedType.LPWStr)]
			public string templateName;

			public IntPtr reservedPtr;

			public int reservedInt;

			public int flagsEx;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct BROWSEINFO
		{
			public IntPtr dlgOwner;

			public IntPtr pidlRoot;

			public IntPtr pszDisplayName;

			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszTitle;

			public uint ulFlags;

			public BrowseCallbackProc lpfn;

			public IntPtr lParam;

			public int iImage;
		}

		[DllImport("Comdlg32.dll", CharSet = CharSet.Unicode)]
		public static extern bool GetOpenFileName(ref OpenFileName ofn);

		[DllImport("Comdlg32.dll", CharSet = CharSet.Unicode)]
		public static extern bool GetSaveFileName(ref OpenFileName sfn);

		[DllImport("shell32.dll")]
		internal static extern IntPtr SHBrowseForFolder(ref BROWSEINFO lpbi);

		[DllImport("shell32.dll", CharSet = CharSet.Unicode)]
		internal static extern bool SHGetPathFromIDList(IntPtr pidl, IntPtr pszPath);

		[DllImport("user32.dll")]
		internal static extern IntPtr GetActiveWindow();

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, int wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, string lParam);
	}
}
