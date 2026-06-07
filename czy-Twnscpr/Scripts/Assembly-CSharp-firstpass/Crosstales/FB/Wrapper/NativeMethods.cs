using System;
using System.Runtime.InteropServices;

namespace Crosstales.FB.Wrapper
{
	internal static class NativeMethods
	{
		public delegate int BrowseCallbackProc(IntPtr hwnd, int uMsg, IntPtr lParam, IntPtr lpData);

		[StructLayout((LayoutKind)0, CharSet = CharSet.Unicode)]
		internal struct OpenFileName
		{
			public int structSize;

			public IntPtr dlgOwner;

			public IntPtr instance;

			public string filter;

			public string customFilter;

			public int maxCustFilter;

			public int filterIndex;

			public IntPtr file;

			public int maxFile;

			public string fileTitle;

			public int maxFileTitle;

			public string initialDir;

			public string title;

			public int flags;

			public ushort fileOffset;

			public ushort fileExtension;

			public string defExt;

			public string custData;

			public IntPtr hook;

			public string templateName;

			public IntPtr reservedPtr;

			public int reservedInt;

			public int flagsEx;
		}

		[StructLayout((LayoutKind)0, CharSet = CharSet.Unicode)]
		internal struct BROWSEINFO
		{
			public IntPtr dlgOwner;

			public IntPtr pidlRoot;

			public IntPtr pszDisplayName;

			public string lpszTitle;

			public uint ulFlags;

			public BrowseCallbackProc lpfn;

			public IntPtr lParam;

			public int iImage;
		}

		[ComImport]
		public interface IShellItem
		{
			void BindToHandler();

			void GetParent();

			void GetDisplayName([In] SIGDN sigdnName, out string ppszName);

			void GetAttributes();

			void Compare();
		}

		[ComImport]
		internal class FileOpenDialog : System.__Il2CppComObject
		{
			extern ~FileOpenDialog();
		}

		[ComImport]
		internal interface IFileOpenDialog
		{
			[PreserveSig]
			uint Show([In] IntPtr parent);

			void SetFileTypes();

			void SetFileTypeIndex([In] uint iFileType);

			void GetFileTypeIndex(out uint piFileType);

			void Advise();

			void Unadvise();

			void SetOptions([In] FOS fos);

			void GetOptions(out FOS pfos);

			void SetDefaultFolder(IShellItem psi);

			void SetFolder([In] IShellItem psi);

			void GetFolder(out IShellItem ppsi);

			void GetCurrentSelection(out IShellItem ppsi);

			void SetFileName([In] string pszName);

			void GetFileName(out string pszName);

			void SetTitle([In] string pszTitle);

			void SetOkButtonLabel([In] string pszText);

			void SetFileNameLabel([In] string pszLabel);

			void GetResult(out IShellItem ppsi);

			void AddPlace(IShellItem psi, int alignment);

			void SetDefaultExtension([In] string pszDefaultExtension);

			void Close(int hr);

			void SetClientGuid();

			void ClearClientData();

			void SetFilter(IntPtr pFilter);

			void GetResults(out IntPtr ppenum);

			void GetSelectedItems(out IntPtr ppsai);
		}

		[PreserveSig]
		public static extern bool GetOpenFileName(ref OpenFileName ofn);

		[PreserveSig]
		public static extern bool GetSaveFileName(ref OpenFileName sfn);

		[PreserveSig]
		internal static extern IntPtr SHBrowseForFolder(ref BROWSEINFO lpbi);

		[PreserveSig]
		internal static extern bool SHGetPathFromIDList(IntPtr pidl, IntPtr pszPath);

		[PreserveSig]
		internal static extern IntPtr GetActiveWindow();

		[PreserveSig]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, int wParam, IntPtr lParam);

		[PreserveSig]
		public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, string lParam);
	}
}
