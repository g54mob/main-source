using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rhizomatic.LoggyLogger
{
	public class FileTransport : Transport
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CProcessQueueAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public FileTransport _003C_003E4__this;

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

		private string _path;

		private readonly ConcurrentQueue<string> _logQueue;

		private readonly SemaphoreSlim _semaphore;

		private readonly CancellationTokenSource _cts;

		private readonly Task _logWorker;

		private readonly TimeSpan _flushInterval;

		private readonly int _batchSize;

		private static readonly StringBuilder _sb;

		public FileTransport(string path)
		{
		}

		protected override void Log(Log log)
		{
		}

		public static string Serialize(Log log)
		{
			return null;
		}

		private static void AppendJsonField(string key, string value)
		{
		}

		private static string EscapeJsonString(string value)
		{
			return null;
		}

		public string GetFilePath()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CProcessQueueAsync_003Ed__14))]
		private Task ProcessQueueAsync()
		{
			return null;
		}

		public override void Dispose()
		{
		}
	}
}
