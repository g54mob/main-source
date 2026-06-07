using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Log;
using Coherence.Plugins.NativeLauncher;
using Coherence.Plugins.NativeUtils;

namespace Coherence.Toolkit.ReplicationServer
{
	public class ReplicationServer : IReplicationServer
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CForwardLogs_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ReplicationServer _003C_003E4__this;

			public CancellationToken token;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		private Process process;

		private NlProcess nlProcess;

		private readonly bool nativeProcess;

		private CancellationTokenSource cancellationTokenSource;

		private readonly ConcurrentQueue<string> logQueue;

		private ThreadResumer threadResumer;

		private readonly Logger logger;

		public event LogHandler OnLog
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

		public event ExitHandler OnExit
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

		internal ReplicationServer(Process process)
		{
		}

		internal ReplicationServer(NlProcess process)
		{
		}

		private void OnDataReceivedEventHandler(object sender, DataReceivedEventArgs args)
		{
		}

		private void OnDataReceivedEventHandler(object sender, StreamDataReceivedEvent args)
		{
		}

		[AsyncStateMachine(typeof(_003CForwardLogs_003Ed__17))]
		private Task ForwardLogs(CancellationToken token)
		{
			return null;
		}

		private void OnProcessExited(object sender, EventArgs args)
		{
		}

		public bool Start()
		{
			return false;
		}

		public bool Stop(int timeoutMs = 0)
		{
			return false;
		}

		private bool StopProcess(int timeoutMs)
		{
			return false;
		}

		private bool StopNlProcess(int timeoutMs)
		{
			return false;
		}

		private void CleanupOnExit()
		{
		}
	}
}
