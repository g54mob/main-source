using System;
using System.Threading;

namespace Coherence.Cloud
{
	internal readonly struct DeferredStorageObjectQuery
	{
		public readonly StorageObjectId ObjectId;

		public readonly Type ObjectType;

		public readonly Key[] Filter;

		public readonly bool IsPartial;

		public readonly CancellationToken CancellationToken;

		public readonly LoadTaskCompletionHandler TaskCompletionHandler;

		public DeferredStorageObjectQuery(StorageObjectId objectId, Type objectType, Key[] filter, bool isPartial, LoadTaskCompletionHandler taskCompletionHandler, CancellationToken cancellationToken)
		{
			ObjectId = default(StorageObjectId);
			ObjectType = null;
			Filter = null;
			IsPartial = false;
			CancellationToken = default(CancellationToken);
			TaskCompletionHandler = null;
		}
	}
}
