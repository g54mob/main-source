using System;
using System.Collections;
using System.Collections.Generic;

namespace Coherence.Cloud
{
	internal sealed class StorageObjectDeletion : IEquatable<StorageObjectId>, IEnumerable<Key>, IEnumerable
	{
		public StorageObjectId ObjectId { get; }

		internal Key[] Filter { get; }

		internal bool IsPartial { get; }

		public StorageObjectDeletion(StorageObjectId objectId)
		{
		}

		internal StorageObjectDeletion(StorageObjectId objectId, params Key[] keys)
		{
		}

		private StorageObjectDeletion(StorageObjectId objectId, Key[] keys, bool isPartial)
		{
		}

		public bool Equals(StorageObjectId other)
		{
			return false;
		}

		public IEnumerator<Key> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public static implicit operator StorageObjectDeletion(StorageObjectId id)
		{
			return null;
		}
	}
}
