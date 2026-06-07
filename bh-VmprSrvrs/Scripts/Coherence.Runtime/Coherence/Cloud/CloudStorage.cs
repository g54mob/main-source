using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Common;
using Coherence.Runtime;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public sealed class CloudStorage : IDisposable
	{
		internal struct PayloadLoadRequest
		{
			internal struct Response
			{
				[JsonProperty("data")]
				public PayloadStorageObject[] data;

				[JsonProperty("owner_id")]
				public string owner_id;
			}

			[JsonProperty("object_ids")]
			public PayloadStorageObjectId[] object_ids;
		}

		[Preserve]
		internal struct PayloadStorageObject
		{
			[JsonProperty("type")]
			public string type;

			[JsonProperty("id")]
			public string id;

			[JsonProperty("data")]
			public object data;

			[JsonProperty("owner_id")]
			public string owner_id;

			[JsonProperty("version")]
			public string version;

			[Preserve]
			public PayloadStorageObject(string type, string id, object data, string ownerId = null, string version = null)
			{
				this.type = null;
				this.id = null;
				this.data = null;
				owner_id = null;
				this.version = null;
			}
		}

		[Preserve]
		internal struct PayloadStorageObjectId
		{
			[JsonProperty("type")]
			public string type;

			[JsonProperty("id")]
			public string id;
		}

		internal struct PayloadSaveRequest
		{
			[JsonProperty("objects")]
			public PayloadStorageObject[] storageObjectMutations;
		}

		internal struct PayloadDeleteRequest
		{
			[JsonProperty("object_ids")]
			public PayloadStorageObjectId[] storageObjectIds;
		}

		private enum State
		{
			Active = 0,
			Disposing = 1,
			Disposed = 2
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public CloudStorage _003C_003E4__this;

			public bool waitForOngoingOperationsToFinish;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitForDeleteCooldown_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CloudStorage _003C_003E4__this;

			public CancellationToken cancellationToken;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitForLoadCooldown_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CloudStorage _003C_003E4__this;

			public CancellationToken cancellationToken;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWaitForSaveCooldown_003Ed__25 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CloudStorage _003C_003E4__this;

			public CancellationToken cancellationToken;

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

		internal const string BasePath = "/cloudstorage";

		internal const string DeletePathParams = "/delete";

		internal const string LoadRequestMethod = "POST";

		internal const string SaveRequestMethod = "PUT";

		internal const string DeleteRequestMethod = "POST";

		private readonly IRequestFactory requestFactory;

		private readonly IAuthClientInternal authClient;

		private readonly RequestThrottle throttle;

		private readonly StorageOperationQueue operationQueue;

		private State state;

		private int requestsInProgress;

		public bool IsReady => false;

		public bool IsBusy => false;

		internal CloudStorage(IRequestFactory requestFactory, IAuthClientInternal authClient, RequestThrottle throttle, Func<CloudStorage, StorageOperationQueue> operationQueueFactory = null)
		{
		}

		public StorageOperation<TObject> LoadObjectAsync<TObject>(StorageObjectId objectId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		internal StorageOperation<StorageObject[]> LoadBatchAsync([DisallowNull] IEnumerable<StorageObjectQuery> queries, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public StorageOperation SaveObjectAsync<TObject>(StorageObjectId objectId, TObject @object, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		internal StorageOperation SaveBatchAsync([DisallowNull] IEnumerable<StorageObjectMutation> mutations, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public StorageOperation DeleteObjectAsync(StorageObjectId objectId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		private StorageOperation DeleteAsync([DisallowNull] IEnumerable<StorageObjectDeletion> deletions, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		internal StorageOperation DeleteBatchAsync([DisallowNull] IEnumerable<StorageObjectDeletion> deletions, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWaitForLoadCooldown_003Ed__23))]
		private Task WaitForLoadCooldown(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWaitForDeleteCooldown_003Ed__24))]
		private Task WaitForDeleteCooldown(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWaitForSaveCooldown_003Ed__25))]
		private Task WaitForSaveCooldown(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		void IDisposable.Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__32))]
		internal ValueTask DisposeAsync(bool waitForOngoingOperationsToFinish)
		{
			return default(ValueTask);
		}

		[Preserve]
		private static void AOTFix()
		{
		}
	}
}
