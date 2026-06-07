using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	internal sealed class StorageOperationQueue
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass16_0
		{
			public StorageOperation deleteOperation;

			public List<TaskCompletionSource<bool>> deletionCompletionSources;

			public StorageOperation saveOperation;

			public List<TaskCompletionSource<bool>> mutationCompletionSources;

			internal void _003CSendNextMutationsOrDeletions_003Eb__0()
			{
			}

			internal void _003CSendNextMutationsOrDeletions_003Eb__1()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSendMutationsOrDeletionsLoop_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public StorageOperationQueue _003C_003E4__this;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private ValueTaskAwaiter _003C_003Eu__2;

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
		private struct _003CSendNextMutationsOrDeletions_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public StorageOperationQueue _003C_003E4__this;

			private _003C_003Ec__DisplayClass16_0 _003C_003E8__1;

			private TaskAwaiter<StorageOperation> _003C_003Eu__1;

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
		private struct _003CSendNextQueries_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public StorageOperationQueue _003C_003E4__this;

			private List<LoadTaskCompletionHandler> _003CtaskCompletionHandlers_003E5__2;

			private TaskAwaiter<StorageOperation<StorageObject[]>> _003C_003Eu__1;

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
		private struct _003CSendQueriesLoop_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public StorageOperationQueue _003C_003E4__this;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

			private ValueTaskAwaiter _003C_003Eu__2;

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

		private readonly CloudStorage cloudStorage;

		private readonly List<DeferredStorageObjectMutationOrDeletion> deferredMutationsAndDeletions;

		private readonly List<DeferredStorageObjectQuery> deferredQueries;

		private bool isProcessingMutationsAndDeletions;

		private bool isProcessingQueries;

		public bool IsEmpty => false;

		public StorageOperationQueue(CloudStorage cloudStorage)
		{
		}

		public void EnqueueSaveOperation(StorageObjectMutation[] mutations, TaskCompletionSource<bool> taskCompletionSource, CancellationToken cancellationToken)
		{
		}

		public void EnqueueDeleteOperation(StorageObjectDeletion[] deletions, TaskCompletionSource<bool> taskCompletionSource, CancellationToken cancellationToken)
		{
		}

		public void EnqueueLoadOperation(StorageObjectQuery[] queries, TaskCompletionSource<StorageObject[]> taskCompletionSource, CancellationToken cancellationToken)
		{
		}

		public void CancelAllQueuedOperations()
		{
		}

		internal static (IEnumerable<StorageObjectMutation>, IEnumerable<StorageObjectDeletion>) GetNextMutationsAndDeletions(List<DeferredStorageObjectMutationOrDeletion> queue, List<TaskCompletionSource<bool>> mutationCompletionSources, List<TaskCompletionSource<bool>> deletionCompletionSources)
		{
			return default((IEnumerable<StorageObjectMutation>, IEnumerable<StorageObjectDeletion>));
		}

		internal static IEnumerable<StorageObjectQuery> GetNextQueries(List<DeferredStorageObjectQuery> queue, List<LoadTaskCompletionHandler> taskCompletionHandlers)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendMutationsOrDeletionsLoop_003Ed__14))]
		private void SendMutationsOrDeletionsLoop()
		{
		}

		[AsyncStateMachine(typeof(_003CSendQueriesLoop_003Ed__15))]
		private void SendQueriesLoop()
		{
		}

		[AsyncStateMachine(typeof(_003CSendNextMutationsOrDeletions_003Ed__16))]
		private ValueTask SendNextMutationsOrDeletions()
		{
			return default(ValueTask);
		}

		[AsyncStateMachine(typeof(_003CSendNextQueries_003Ed__17))]
		private ValueTask SendNextQueries()
		{
			return default(ValueTask);
		}

		private static void CompleteAll(StorageOperation combinedOperation, List<TaskCompletionSource<bool>> taskCompletionSources)
		{
		}

		private static void SetResultForAll(List<TaskCompletionSource<bool>> taskCompletionSources, bool result)
		{
		}
	}
}
