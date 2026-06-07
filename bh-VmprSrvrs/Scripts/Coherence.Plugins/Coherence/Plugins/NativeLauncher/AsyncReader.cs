using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Plugins.Utils;

namespace Coherence.Plugins.NativeLauncher
{
	internal class AsyncReader
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadProcessOutput_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AsyncReader _003C_003E4__this;

			public CancellationToken token;

			private Encoding _003Cencoding_003E5__2;

			private byte[] _003CbyteBuffer_003E5__3;

			private char[] _003CcharBuffer_003E5__4;

			private InteropBuffer _003CiopBuffer_003E5__5;

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

		private const int BufferSize = 1024;

		private readonly IntPtr processHandle;

		private readonly CancellationTokenSource cts;

		private readonly LineSplitter lineSplitter;

		private readonly Action<string> userCallback;

		private bool reading;

		private bool cancelled;

		public AsyncReader(IntPtr handle, Action<string> callback)
		{
		}

		public void StartReading()
		{
		}

		[AsyncStateMachine(typeof(_003CReadProcessOutput_003Ed__9))]
		private Task ReadProcessOutput(CancellationToken token)
		{
			return null;
		}

		public void StopReading()
		{
		}

		private void FlushMessages(IReadOnlyList<string> messages)
		{
		}
	}
}
