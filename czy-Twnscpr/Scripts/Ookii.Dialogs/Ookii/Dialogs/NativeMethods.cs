using System;
using System.Runtime.InteropServices;
using System.Text;
using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	internal static class NativeMethods
	{
		[Flags]
		public enum LoadLibraryExFlags : uint
		{
			DontResolveDllReferences = 1u,
			LoadLibraryAsDatafile = 2u,
			LoadWithAlteredSearchPath = 8u,
			LoadIgnoreCodeAuthzLevel = 0x10u
		}

		[StructLayout((LayoutKind)0, CharSet = CharSet.Auto, Pack = 4, Size = 8)]
		internal struct COMDLG_FILTERSPEC
		{
			internal string pszName;

			internal string pszSpec;
		}

		internal enum SIGDN : uint
		{
			SIGDN_NORMALDISPLAY = 0u,
			SIGDN_PARENTRELATIVEPARSING = 2147581953u,
			SIGDN_DESKTOPABSOLUTEPARSING = 2147647488u,
			SIGDN_PARENTRELATIVEEDITING = 2147684353u,
			SIGDN_DESKTOPABSOLUTEEDITING = 2147794944u,
			SIGDN_FILESYSPATH = 2147844096u,
			SIGDN_URL = 2147909632u,
			SIGDN_PARENTRELATIVEFORADDRESSBAR = 2147991553u,
			SIGDN_PARENTRELATIVE = 2148007937u
		}

		[Flags]
		internal enum FOS : uint
		{
			FOS_OVERWRITEPROMPT = 2u,
			FOS_STRICTFILETYPES = 4u,
			FOS_NOCHANGEDIR = 8u,
			FOS_PICKFOLDERS = 0x20u,
			FOS_FORCEFILESYSTEM = 0x40u,
			FOS_ALLNONSTORAGEITEMS = 0x80u,
			FOS_NOVALIDATE = 0x100u,
			FOS_ALLOWMULTISELECT = 0x200u,
			FOS_PATHMUSTEXIST = 0x800u,
			FOS_FILEMUSTEXIST = 0x1000u,
			FOS_CREATEPROMPT = 0x2000u,
			FOS_SHAREAWARE = 0x4000u,
			FOS_NOREADONLYRETURN = 0x8000u,
			FOS_NOTESTFILECREATE = 0x10000u,
			FOS_HIDEMRUPLACES = 0x20000u,
			FOS_HIDEPINNEDPLACES = 0x40000u,
			FOS_NODEREFERENCELINKS = 0x100000u,
			FOS_DONTADDTORECENT = 0x2000000u,
			FOS_FORCESHOWHIDDEN = 0x10000000u,
			FOS_DEFAULTNOMINIMODE = 0x20000000u
		}

		[Flags]
		public enum FormatMessageFlags
		{
			FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100,
			FORMAT_MESSAGE_IGNORE_INSERTS = 0x200,
			FORMAT_MESSAGE_FROM_STRING = 0x400,
			FORMAT_MESSAGE_FROM_HMODULE = 0x800,
			FORMAT_MESSAGE_FROM_SYSTEM = 0x1000,
			FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x2000
		}

		public static bool IsWindowsVistaOrLater => false;

		[PreserveSig]
		public static extern SafeModuleHandle LoadLibraryEx(string lpFileName, IntPtr hFile, LoadLibraryExFlags dwFlags);

		[PreserveSig]
		public static extern bool FreeLibrary(IntPtr hModule);

		[PreserveSig]
		public static extern int SHCreateItemFromParsingName(string pszPath, IntPtr pbc, ref Guid riid, out object ppv);

		public static IShellItem CreateItemFromParsingName(string path)
		{
			return null;
		}

		[PreserveSig]
		public static extern int LoadString(SafeModuleHandle hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

		[PreserveSig]
		public static extern uint FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, string[] Arguments);
	}
}
