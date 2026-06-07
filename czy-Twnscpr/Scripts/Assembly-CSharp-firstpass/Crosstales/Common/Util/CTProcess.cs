using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Crosstales.Common.Util
{
	public class CTProcess : IDisposable
	{
		private uint exitCode;

		private CTProcessStartInfo startInfo;

		private IntPtr threadHandle;

		private static readonly FieldInfo[] eventFields;

		private const uint Infinite = uint.MaxValue;

		private const uint CREATE_NO_WINDOW = 134217728u;

		public IntPtr Handle { get; private set; }

		public int Id { get; private set; }

		public CTProcessStartInfo StartInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasExited { get; private set; }

		public uint ExitCode => 0u;

		public DateTime StartTime { get; private set; }

		public DateTime ExitTime { get; private set; }

		public StreamReader StandardOutput { get; private set; }

		public StreamReader StandardError { get; private set; }

		public bool isBusy { get; private set; }

		public event EventHandler Exited
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event DataReceivedEventHandler OutputDataReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event DataReceivedEventHandler ErrorDataReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void onExited()
		{
		}

		public void Start()
		{
		}

		public void Start(CTProcessStartInfo info)
		{
		}

		public void Kill()
		{
		}

		public void WaitForExit(int milliseconds = 0)
		{
		}

		public void BeginOutputReadLine()
		{
		}

		public void BeginErrorReadLine()
		{
		}

		public void Dispose()
		{
		}

		private void createProcess()
		{
		}

		private void cleanup()
		{
		}

		private void watchStdOut()
		{
		}

		private void watchStdErr()
		{
		}

		private static DataReceivedEventArgs createMockDataReceivedEventArgs(string data)
		{
			return null;
		}
	}
}
