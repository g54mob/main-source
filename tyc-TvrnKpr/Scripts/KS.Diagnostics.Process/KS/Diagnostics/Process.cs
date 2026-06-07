using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;

namespace KS.Diagnostics
{
	public class Process : IDisposable
	{
		private static class FuncPtrClass<T> where T : Delegate
		{
			public static Dictionary<int, T> StaticHandlers;

			public static int GeneratePtr(T value, List<(T, int)> list)
			{
				return 0;
			}

			public static bool GetFromList(T value, out int delPtr, List<(T, int)> list)
			{
				delPtr = default(int);
				return false;
			}

			public static void ClearHandlers(List<(T, int)> list)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void DataReceivedHandlerWithPtr(int functionPtr, string value);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void EventHandlerWithPtr(int functionPtr);

		public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);

		public class DataReceivedEventArgs : EventArgs
		{
			public string Data { get; }

			internal DataReceivedEventArgs(string data)
			{
			}
		}

		private readonly List<(DataReceivedEventHandler, int)> OutputDataReceivedList;

		private readonly List<(EventHandler, int)> ExitedList;

		private string processName;

		private IntPtr ptr;

		private ProcessStartInfo startInfo;

		public FakeStandardInput StandardInput;

		public TimeSpan TotalProcessorTime => default(TimeSpan);

		public int Id => 0;

		public int ExitCode => 0;

		public DateTime ExitTime => default(DateTime);

		public DateTime StartTime => default(DateTime);

		public string ProcessName => null;

		public string ProcessNameCached => null;

		public ProcessStartInfo StartInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool EnableRaisingEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event DataReceivedEventHandler OutputDataReceived
		{
			add
			{
			}
			remove
			{
			}
		}

		public event DataReceivedEventHandler ErrorDataReceived
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventHandler Exited
		{
			add
			{
			}
			remove
			{
			}
		}

		static Process()
		{
		}

		[PreserveSig]
		private static extern void Kill(IntPtr ptr);

		public void Kill()
		{
		}

		[PreserveSig]
		private static extern long GetTotalProcessorTime(IntPtr ptr);

		[PreserveSig]
		private static extern void KillBool(IntPtr ptr, bool entireProcessTree);

		public void Kill(bool entireProcessTree)
		{
		}

		[PreserveSig]
		private static extern IntPtr GetProcessesString(ref int arrayCount, ref IntPtr arrGcHandlePtr, string machineName);

		public static Process[] GetProcesses(string machineName)
		{
			return null;
		}

		[PreserveSig]
		private static extern IntPtr GetProcesses(ref int arrayCount, ref IntPtr arrGcHandlePtr);

		public static Process[] GetProcesses()
		{
			return null;
		}

		private static Process[] GetProcessesShared(IntPtr arrGcHandlePtr, IntPtr arrayPtr, int count)
		{
			return null;
		}

		[PreserveSig]
		private static extern IntPtr GetProcessesByName(ref int arrayCount, ref IntPtr arrGcHandlePtr, string namePtr);

		public static Process[] GetProcessesByName(string processName)
		{
			return null;
		}

		public static void Throw()
		{
		}

		private static void Throw(IntPtr ptr)
		{
		}

		[PreserveSig]
		private static extern IntPtr GetProcessesByNameString(ref int arrayCount, ref IntPtr arrGcHandlePtr, string namePtr, string machineNamePtr);

		public static Process[] GetProcessesByName(string processName, string machineName)
		{
			return null;
		}

		[PreserveSig]
		private static extern int GetProcessId(IntPtr ptr);

		[PreserveSig]
		private static extern int GetProcessExitCode(IntPtr ptr);

		[PreserveSig]
		private static extern long GetProcessExitTime(IntPtr ptr);

		[PreserveSig]
		private static extern long GetProcessStartTime(IntPtr ptr);

		[PreserveSig]
		private static extern IntPtr GetProcessName(IntPtr ptr);

		[MonoPInvokeCallback(typeof(DataReceivedHandlerWithPtr))]
		private static void OutputDataReceivedWrapper(int functionPtr, string s)
		{
		}

		[PreserveSig]
		private static extern void AddExited(IntPtr ptr, EventHandlerWithPtr del, int funcPtr);

		[PreserveSig]
		private static extern void RemoveExited(IntPtr ptr, int funcPtr);

		[MonoPInvokeCallback(typeof(EventHandlerWithPtr))]
		private static void ExitedWrapper(int functionPtr)
		{
		}

		[PreserveSig]
		private static extern void AddOutputDataReceived(IntPtr ptr, DataReceivedHandlerWithPtr del, int funcPtr);

		[PreserveSig]
		private static extern void RemoveOutputDataReceived(IntPtr ptr, int funcPtr);

		[PreserveSig]
		private static extern void AddErrorDataReceived(IntPtr ptr, DataReceivedHandlerWithPtr del, int funcPtr);

		[PreserveSig]
		private static extern void RemoveErrorDataReceived(IntPtr ptr, int funcPtr);

		[PreserveSig]
		private static extern void SetStartInfo(IntPtr ptr, IntPtr ptrStartInfo);

		[PreserveSig]
		private static extern IntPtr CreateProcess();

		private Process(IntPtr ptr)
		{
		}

		public Process()
		{
		}

		private void SetPtr(IntPtr ptr)
		{
		}

		[PreserveSig]
		private static extern bool GetEnableRaisingEvents(IntPtr p);

		[PreserveSig]
		private static extern void SetEnableRaisingEvents(IntPtr p, bool value);

		[PreserveSig]
		private static extern void Start(IntPtr ptr);

		public void Start()
		{
		}

		[PreserveSig]
		private static extern void BeginOutputReadLine(IntPtr ptr);

		public void BeginOutputReadLine()
		{
		}

		[PreserveSig]
		private static extern void BeginErrorReadLine(IntPtr ptr);

		public void BeginErrorReadLine()
		{
		}

		[PreserveSig]
		private static extern void WaitForExit(IntPtr ptr);

		public void WaitForExit()
		{
		}

		[PreserveSig]
		private static extern void WaitForExitMilliseconds(IntPtr ptr, int milliseconds);

		public void WaitForExit(int milliseconds)
		{
		}

		[PreserveSig]
		private static extern void CancelOutputRead(IntPtr ptr);

		public void CancelOutputRead()
		{
		}

		[PreserveSig]
		private static extern void DisposeProcess(IntPtr ptr);

		public void Dispose()
		{
		}
	}
}
