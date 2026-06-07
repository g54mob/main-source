using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Microsoft.Win32
{
	internal static class NativeMethods
	{
		public const int E_ABORT = -2147467260;

		public const int PROCESS_TERMINATE = 1;

		public const int PROCESS_CREATE_THREAD = 2;

		public const int PROCESS_SET_SESSIONID = 4;

		public const int PROCESS_VM_OPERATION = 8;

		public const int PROCESS_VM_READ = 16;

		public const int PROCESS_VM_WRITE = 32;

		public const int PROCESS_DUP_HANDLE = 64;

		public const int PROCESS_CREATE_PROCESS = 128;

		public const int PROCESS_SET_QUOTA = 256;

		public const int PROCESS_SET_INFORMATION = 512;

		public const int PROCESS_QUERY_INFORMATION = 1024;

		public const int PROCESS_QUERY_LIMITED_INFORMATION = 4096;

		public const int STANDARD_RIGHTS_REQUIRED = 983040;

		public const int SYNCHRONIZE = 1048576;

		public const int PROCESS_ALL_ACCESS = 2035711;

		public const int DUPLICATE_CLOSE_SOURCE = 1;

		public const int DUPLICATE_SAME_ACCESS = 2;

		public const int STILL_ACTIVE = 259;

		public const int WAIT_OBJECT_0 = 0;

		public const int WAIT_FAILED = -1;

		public const int WAIT_TIMEOUT = 258;

		public const int WAIT_ABANDONED = 128;

		public const int WAIT_ABANDONED_0 = 128;

		public const int ERROR_FILE_NOT_FOUND = 2;

		public const int ERROR_PATH_NOT_FOUND = 3;

		public const int ERROR_ACCESS_DENIED = 5;

		public const int ERROR_INVALID_HANDLE = 6;

		public const int ERROR_SHARING_VIOLATION = 32;

		public const int ERROR_INVALID_NAME = 123;

		public const int ERROR_ALREADY_EXISTS = 183;

		public const int ERROR_FILENAME_EXCED_RANGE = 206;

		public static bool DuplicateHandle(HandleRef hSourceProcessHandle, SafeHandle hSourceHandle, HandleRef hTargetProcess, out SafeWaitHandle targetHandle, int dwDesiredAccess, bool bInheritHandle, int dwOptions)
		{
			targetHandle = null;
			return false;
		}

		public static bool DuplicateHandle(HandleRef hSourceProcessHandle, HandleRef hSourceHandle, HandleRef hTargetProcess, out SafeProcessHandle targetHandle, int dwDesiredAccess, bool bInheritHandle, int dwOptions)
		{
			targetHandle = null;
			return false;
		}

		public static IntPtr GetCurrentProcess()
		{
			return (IntPtr)0;
		}

		public static bool GetExitCodeProcess(IntPtr processHandle, out int exitCode)
		{
			exitCode = default(int);
			return false;
		}

		public static bool GetExitCodeProcess(SafeProcessHandle processHandle, out int exitCode)
		{
			exitCode = default(int);
			return false;
		}

		public static bool TerminateProcess(IntPtr processHandle, int exitCode)
		{
			return false;
		}

		public static bool TerminateProcess(SafeProcessHandle processHandle, int exitCode)
		{
			return false;
		}

		public static int WaitForInputIdle(IntPtr handle, int milliseconds)
		{
			return 0;
		}

		public static int WaitForInputIdle(SafeProcessHandle handle, int milliseconds)
		{
			return 0;
		}

		public static bool GetProcessWorkingSetSize(IntPtr handle, out IntPtr min, out IntPtr max)
		{
			min = default(IntPtr);
			max = default(IntPtr);
			return false;
		}

		public static bool GetProcessWorkingSetSize(SafeProcessHandle handle, out IntPtr min, out IntPtr max)
		{
			min = default(IntPtr);
			max = default(IntPtr);
			return false;
		}

		public static bool SetProcessWorkingSetSize(IntPtr handle, IntPtr min, IntPtr max)
		{
			return false;
		}

		public static bool SetProcessWorkingSetSize(SafeProcessHandle handle, IntPtr min, IntPtr max)
		{
			return false;
		}

		public static bool GetProcessTimes(IntPtr handle, out long creation, out long exit, out long kernel, out long user)
		{
			creation = default(long);
			exit = default(long);
			kernel = default(long);
			user = default(long);
			return false;
		}

		public static bool GetProcessTimes(SafeProcessHandle handle, out long creation, out long exit, out long kernel, out long user)
		{
			creation = default(long);
			exit = default(long);
			kernel = default(long);
			user = default(long);
			return false;
		}

		public static int GetCurrentProcessId()
		{
			return 0;
		}

		public static int GetPriorityClass(IntPtr handle)
		{
			return 0;
		}

		public static int GetPriorityClass(SafeProcessHandle handle)
		{
			return 0;
		}

		public static bool SetPriorityClass(IntPtr handle, int priorityClass)
		{
			return false;
		}

		public static bool SetPriorityClass(SafeProcessHandle handle, int priorityClass)
		{
			return false;
		}

		public static bool CloseProcess(IntPtr handle)
		{
			return false;
		}
	}
}
