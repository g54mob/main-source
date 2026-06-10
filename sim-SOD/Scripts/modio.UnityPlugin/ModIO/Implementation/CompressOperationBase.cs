using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ModIO.Implementation
{
	internal abstract class CompressOperationBase : IModIOZipOperation, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCompressStream_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string entryName;

			public ZipOutputStream zipStream;

			public Stream fileStream;

			public CompressOperationBase _003C_003E4__this;

			private long _003Cmax_003E5__2;

			private byte[] _003Cdata_003E5__3;

			private TaskAwaiter<int> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		private const bool sizeLimitReached = false;

		protected bool cancel;

		protected ProgressHandle progressHandle;

		protected Task<ResultAnd<MemoryStream>> _operation;

		protected CompressOperationBase(ProgressHandle progressHandle)
		{
		}

		public Task GetOperation()
		{
			return null;
		}

		public virtual void Cancel()
		{
		}

		public void Dispose()
		{
		}

		public virtual Task<ResultAnd<MemoryStream>> Compress()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCompressStream_003Ed__9))]
		protected Task CompressStream(string entryName, Stream fileStream, ZipOutputStream zipStream)
		{
			return null;
		}

		protected ResultAnd<MemoryStream> Abort(ResultAnd<MemoryStream> resultAnd, string details)
		{
			return null;
		}
	}
}
