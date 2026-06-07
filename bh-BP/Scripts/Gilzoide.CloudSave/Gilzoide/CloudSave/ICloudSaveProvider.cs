using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gilzoide.CloudSave
{
	public interface ICloudSaveProvider
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadTextAsync_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public ICloudSaveProvider _003C_003E4__this;

			public ICloudSaveGameMetadata metadata;

			public CancellationToken cancellationToken;

			private Encoding _003C_003E7__wrap1;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

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

		bool IsCloudSaveEnabled { get; }

		Task<List<ICloudSaveGameMetadata>> FetchAllAsync(CancellationToken cancellationToken = default(CancellationToken));

		Task<ICloudSaveGameMetadata> FindAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

		Task<byte[]> LoadBytesAsync(ICloudSaveGameMetadata metadata, CancellationToken cancellationToken = default(CancellationToken));

		[AsyncStateMachine(typeof(_003CLoadTextAsync_003Ed__5))]
		Task<string> LoadTextAsync(ICloudSaveGameMetadata metadata, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		Task<ICloudSaveGameMetadata> SaveBytesAsync(string name, byte[] bytes, CloudSaveGameMetadataUpdate metadata = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<ICloudSaveGameMetadata> SaveTextAsync(string name, string text, CloudSaveGameMetadataUpdate metadata = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		Task<bool> DeleteAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
	}
}
