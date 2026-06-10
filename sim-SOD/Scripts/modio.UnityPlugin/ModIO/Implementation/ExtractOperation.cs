using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ModIO.Implementation
{
	internal class ExtractOperation : IModIOZipOperation, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExtract_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ExtractOperation _003C_003E4__this;

			private TaskAwaiter<Result> _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExtractAll_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ExtractOperation _003C_003E4__this;

			private Result _003Cresult_003E5__2;

			private TaskAwaiter<Result> _003C_003Eu__1;

			private Stream _003CfileStream_003E5__3;

			private long _003Cmax_003E5__4;

			private ZipInputStream _003Cstream_003E5__5;

			private Stream _003CstreamWriter_003E5__6;

			private byte[] _003Cdata_003E5__7;

			private TaskAwaiter<int> _003C_003Eu__2;

			private TaskAwaiter _003C_003Eu__3;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CIsThereEnoughSpaceForExtracting_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public ExtractOperation _003C_003E4__this;

			private Stream _003CfileStream_003E5__2;

			private ZipInputStream _003Cstream_003E5__3;

			private long _003CuncompressedSize_003E5__4;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		public bool cancel;

		public long modId;

		public long fileId;

		public ProgressHandle progressHandle;

		Task IModIOZipOperation.GetOperation()
		{
			return null;
		}

		public ExtractOperation(long modId, long fileId, ProgressHandle progressHandle = null)
		{
		}

		[AsyncStateMachine(typeof(_003CExtract_003Ed__6))]
		public Task<Result> Extract()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CExtractAll_003Ed__7))]
		private Task<Result> ExtractAll()
		{
			return null;
		}

		private Result CancelAndCleanup(Result result)
		{
			return default(Result);
		}

		[AsyncStateMachine(typeof(_003CIsThereEnoughSpaceForExtracting_003Ed__9))]
		private Task<Result> IsThereEnoughSpaceForExtracting()
		{
			return null;
		}

		void IModIOZipOperation.Cancel()
		{
		}

		public void Dispose()
		{
		}
	}
}
