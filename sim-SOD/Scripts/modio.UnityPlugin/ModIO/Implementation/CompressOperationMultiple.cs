using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ModIO.Implementation
{
	internal class CompressOperationMultiple : CompressOperationBase
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCompress_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<MemoryStream>> _003C_003Et__builder;

			public CompressOperationMultiple _003C_003E4__this;

			private ResultAnd<MemoryStream> _003CresultAnd_003E5__2;

			private int _003Ccount_003E5__3;

			private ZipOutputStream _003CzipStream_003E5__4;

			private IEnumerator<byte[]> _003C_003E7__wrap4;

			private MemoryStream _003CmemoryStream_003E5__6;

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

		public IEnumerable<byte[]> data;

		public CompressOperationMultiple(IEnumerable<byte[]> compressed, ProgressHandle progressHandle)
			: base(null)
		{
		}

		public override void Cancel()
		{
		}

		[AsyncStateMachine(typeof(_003CCompress_003Ed__3))]
		public override Task<ResultAnd<MemoryStream>> Compress()
		{
			return null;
		}
	}
}
