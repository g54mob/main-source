using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	internal readonly struct DeferredStorageObjectMutationOrDeletion
	{
		public readonly StorageObjectId ObjectId;

		[MaybeNull]
		public readonly StorageObject StorageObject;

		public readonly StorageItem[] Items;

		public readonly Key[] Filter;

		public readonly bool IsDelete;

		public readonly bool IsPartial;

		public readonly TaskCompletionSource<bool> TaskCompletionSource;

		public readonly CancellationToken CancellationToken;

		private DeferredStorageObjectMutationOrDeletion(StorageObjectId objectId, StorageObject storageObject, StorageItem[] items, Key[] filter, bool isDelete, bool isPartial, TaskCompletionSource<bool> taskCompletionSource, CancellationToken cancellationToken)
		{
			ObjectId = default(StorageObjectId);
			StorageObject = null;
			Items = null;
			Filter = null;
			IsDelete = false;
			IsPartial = false;
			TaskCompletionSource = null;
			CancellationToken = default(CancellationToken);
		}

		public static DeferredStorageObjectMutationOrDeletion Mutation(StorageObjectId objectId, StorageObject storageObject, StorageItem[] items, bool isPartial, TaskCompletionSource<bool> taskCompletionSource, CancellationToken cancellationToken)
		{
			return default(DeferredStorageObjectMutationOrDeletion);
		}

		public static DeferredStorageObjectMutationOrDeletion Deletion(StorageObjectId objectId, Key[] filter, bool isPartial, TaskCompletionSource<bool> taskCompletionSource, CancellationToken cancellationToken)
		{
			return default(DeferredStorageObjectMutationOrDeletion);
		}
	}
}
