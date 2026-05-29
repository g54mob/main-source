using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Protobuf
{
	internal static class ByteStringAsync
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFromStreamAsyncCore_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ByteString> _003C_003Et__builder;

			public Stream stream;

			public CancellationToken cancellationToken;

			private MemoryStream _003CmemoryStream_003E5__2;

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

		[AsyncStateMachine(typeof(_003CFromStreamAsyncCore_003Ed__0))]
		internal static Task<ByteString> FromStreamAsyncCore(Stream stream, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}
