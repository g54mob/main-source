using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ModIO.Implementation
{
	internal class CompressOperationDirectory : CompressOperationBase
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCompress_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<MemoryStream>> _003C_003Et__builder;

			public CompressOperationDirectory _003C_003E4__this;

			private ResultAnd<MemoryStream> _003CresultAnd_003E5__2;

			private ZipOutputStream _003CzipStream_003E5__3;

			private int _003CfolderOffset_003E5__4;

			private IEnumerator<ResultAnd<ModIOFileStream>> _003C_003E7__wrap4;

			private ModIOFileStream _003C_003E7__wrap5;

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

		private string directory;

		public CompressOperationDirectory(string directory, ProgressHandle progressHandle = null)
			: base(null)
		{
		}

		[AsyncStateMachine(typeof(_003CCompress_003Ed__2))]
		public override Task<ResultAnd<MemoryStream>> Compress()
		{
			return null;
		}

		private static string GetEntryName(int folderOffset, ResultAnd<ModIOFileStream> dir)
		{
			return null;
		}
	}
}
