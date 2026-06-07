using System;
using System.Collections;
using System.Collections.Generic;

namespace Coherence.Cloud
{
	internal sealed class StorageObjectQuery : IEquatable<StorageObjectId>, IEnumerable<Key>, IEnumerable
	{
		public StorageObjectId ObjectId { get; }

		public Type ObjectType { get; }

		internal Key[] Filter { get; }

		internal bool IsPartial { get; }

		public StorageObjectQuery(StorageObjectId objectId, Type objectType)
		{
		}

		internal StorageObjectQuery(StorageObjectId objectId, Type objectType, params Key[] keys)
		{
		}

		private StorageObjectQuery(StorageObjectId objectId, Type objectType, Key[] keys, bool isPartial)
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
	}
}
