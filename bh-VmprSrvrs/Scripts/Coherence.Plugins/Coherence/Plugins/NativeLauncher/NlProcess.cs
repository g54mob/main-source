using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Log;

namespace Coherence.Plugins.NativeLauncher
{
	public class NlProcess : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CMonitorProcess_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

			public NlProcess _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private IntPtr processHandle;

		private AsyncReader asyncReader;

		private CancellationTokenSource processMonitorCts;

		private readonly bool raiseOnExit;

		private bool raiseOnExitDone;

		private int exited;

		private Logger logger;

		public StreamDataReceivedEventHandler OutputDataReceived;

		public EventHandler Exited;

		private bool HasExited => false;

		public int ExitCode { get; private set; }

		public int Id { get; private set; }

		public NlProcess(NlProcessStartupInfo startupInfo)
		{
		}

		public void Dispose()
		{
		}

		public bool Start()
		{
			return false;
		}

		public bool Terminate(int timeout)
		{
			return false;
		}

		public void BeginOutputReadLine()
		{
		}

		[AsyncStateMachine(typeof(_003CMonitorProcess_003Ed__24))]
		private Task<int> MonitorProcess()
		{
			return null;
		}

		private void OutputReceivedCallback(string output)
		{
		}

		private void OnProcessExited(int code)
		{
		}

		private void RaiseOnExited()
		{
		}
	}
}
