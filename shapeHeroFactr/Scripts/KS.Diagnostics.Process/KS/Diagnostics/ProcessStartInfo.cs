using System;
using System.Runtime.InteropServices;

namespace KS.Diagnostics
{
	public class ProcessStartInfo : IDisposable
	{
		private readonly IntPtr ptr;

		public string WorkingDirectory
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Verb
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] Verbs => null;

		public string FileName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Arguments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseShellExecute
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RedirectStandardOutput
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RedirectStandardError
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CreateNoWindow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		static ProcessStartInfo()
		{
		}

		public IntPtr GetPtr()
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern void DisposeProcessStartInfo(IntPtr p);

		public void Dispose()
		{
		}

		[PreserveSig]
		private static extern IntPtr CreateProcessStartInfo();

		[PreserveSig]
		private static extern IntPtr GetWorkingDirectory(IntPtr p);

		[PreserveSig]
		private static extern void SetWorkingDirectory(IntPtr p, string name);

		[PreserveSig]
		private static extern IntPtr GetVerbs(IntPtr ptr);

		[PreserveSig]
		private static extern IntPtr SetVerb(IntPtr ptr, IntPtr strPtr);

		[PreserveSig]
		private static extern IntPtr GetVerb(IntPtr ptr);

		[PreserveSig]
		private static extern IntPtr GetFileName(IntPtr p);

		[PreserveSig]
		private static extern void SetFileName(IntPtr p, string name);

		[PreserveSig]
		private static extern IntPtr GetArguments(IntPtr p);

		[PreserveSig]
		private static extern void SetArguments(IntPtr p, string name);

		[PreserveSig]
		private static extern bool GetUseShellExecute(IntPtr p);

		[PreserveSig]
		private static extern void SetUseShellExecute(IntPtr p, bool b);

		[PreserveSig]
		private static extern bool GetRedirectStandardOutput(IntPtr p);

		[PreserveSig]
		private static extern void SetRedirectStandardOutput(IntPtr p, bool b);

		[PreserveSig]
		private static extern bool GetRedirectStandardError(IntPtr p);

		[PreserveSig]
		private static extern void SetRedirectStandardError(IntPtr p, bool b);

		[PreserveSig]
		private static extern bool GetCreateNoWindow(IntPtr p);

		[PreserveSig]
		private static extern void SetCreateNoWindow(IntPtr p, bool b);
	}
}
