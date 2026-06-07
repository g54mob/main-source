using System.Collections.Generic;

namespace Coherence.Cloud
{
	internal static class StorageObjectExtensions
	{
		public static StorageObjectId[] Ids(this IEnumerable<StorageObjectMutation> mutations)
		{
			return null;
		}

		public static StorageObjectId[] Ids(this IEnumerable<StorageObjectQuery> queries)
		{
			return null;
		}

		public static StorageObjectId[] Ids(this IEnumerable<StorageObjectDeletion> deletions)
		{
			return null;
		}

		public static string AllToString(this IEnumerable<StorageObjectId> ids, string delimiter)
		{
			return null;
		}
	}
}
