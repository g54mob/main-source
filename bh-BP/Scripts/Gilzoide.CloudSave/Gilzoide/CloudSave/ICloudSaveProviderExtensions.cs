using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Gilzoide.CloudSave
{
	public static class ICloudSaveProviderExtensions
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadBytesAsync_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

			public ICloudSaveProvider cloudSaveProvider;

			public string name;

			public CancellationToken cancellationToken;

			private TaskAwaiter<ICloudSaveGameMetadata> _003C_003Eu__1;

			private TaskAwaiter<byte[]> _003C_003Eu__2;

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
		private struct _003CLoadJsonAsync_003Ed__2<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public ICloudSaveProvider cloudSaveProvider;

			public ICloudSaveGameMetadata metadata;

			public CancellationToken cancellationToken;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CLoadJsonAsync_003Ed__3<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public ICloudSaveProvider cloudSaveProvider;

			public string name;

			public CancellationToken cancellationToken;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CLoadJsonOverwriteAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ICloudSaveProvider cloudSaveProvider;

			public ICloudSaveGameMetadata metadata;

			public CancellationToken cancellationToken;

			public object objectToOverwrite;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CLoadJsonOverwriteAsync_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ICloudSaveProvider cloudSaveProvider;

			public string name;

			public CancellationToken cancellationToken;

			public object objectToOverwrite;

			private TaskAwaiter<string> _003C_003Eu__1;

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
		private struct _003CLoadTextAsync_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public ICloudSaveProvider cloudSaveProvider;

			public string name;

			public CancellationToken cancellationToken;

			private TaskAwaiter<ICloudSaveGameMetadata> _003C_003Eu__1;

			private TaskAwaiter<string> _003C_003Eu__2;

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

		[AsyncStateMachine(typeof(_003CLoadBytesAsync_003Ed__0))]
		public static Task<byte[]> LoadBytesAsync(this ICloudSaveProvider cloudSaveProvider, string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadTextAsync_003Ed__1))]
		public static Task<string> LoadTextAsync(this ICloudSaveProvider cloudSaveProvider, string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadJsonAsync_003Ed__2<>))]
		public static Task<T> LoadJsonAsync<T>(this ICloudSaveProvider cloudSaveProvider, ICloudSaveGameMetadata metadata, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadJsonAsync_003Ed__3<>))]
		public static Task<T> LoadJsonAsync<T>(this ICloudSaveProvider cloudSaveProvider, string name, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadJsonOverwriteAsync_003Ed__4))]
		public static Task LoadJsonOverwriteAsync(this ICloudSaveProvider cloudSaveProvider, ICloudSaveGameMetadata metadata, object objectToOverwrite, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadJsonOverwriteAsync_003Ed__5))]
		public static Task LoadJsonOverwriteAsync(this ICloudSaveProvider cloudSaveProvider, string name, object objectToOverwrite, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static Task<ICloudSaveGameMetadata> SaveJsonAsync(this ICloudSaveProvider cloudSaveProvider, string name, object obj, CloudSaveGameMetadataUpdate metadata = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
