using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace PIEHid64Net
{
	internal class FileIOApiDeclarations
	{
		public struct OVERLAPPED
		{
			public IntPtr Internal;

			public IntPtr InternalHigh;

			public int Offset;

			public int OffsetHigh;

			public IntPtr hEvent;
		}

		public struct SECURITY_ATTRIBUTES
		{
			public int nLength;

			public IntPtr lpSecurityDescriptor;

			public int bInheritHandle;
		}

		public const int ERROR_INVALID_HANDLE = 6;

		public const int ERROR_DEVICE_NOT_CONNECTED = 1167;

		public const int ERROR_IO_INCOMPLETE = 996;

		public const int ERROR_IO_PENDING = 997;

		public const uint GENERIC_READ = 2147483648u;

		public const uint GENERIC_WRITE = 1073741824u;

		public const uint FILE_SHARE_READ = 1u;

		public const uint FILE_SHARE_WRITE = 2u;

		public const uint FILE_FLAG_OVERLAPPED = 1073741824u;

		public const int INVALID_HANDLE_VALUE = -1;

		public const short OPEN_EXISTING = 3;

		public const int WAIT_TIMEOUT = 258;

		public const short WAIT_OBJECT_0 = 0;

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int CancelIo(SafeFileHandle hFile);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreateEvent(ref SECURITY_ATTRIBUTES SecurityAttributes, int bManualReset, int bInitialState, string lpName);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int SetEvent(IntPtr eEvent);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int ResetEvent(IntPtr eEvent);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, int dwCreationDisposition, uint dwFlagsAndAttributes, int hTemplateFile);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int ReadFile(SafeFileHandle hFile, IntPtr lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, ref OVERLAPPED lpOverlapped);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int WriteFile(SafeFileHandle hFile, IntPtr lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, ref OVERLAPPED lpOverlapped);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int GetOverlappedResult(SafeFileHandle hFile, ref OVERLAPPED lpOverlapped, ref int lpNumberOfBytesTransferred, int bWait);
	}
}
