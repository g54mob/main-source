using System;

namespace Coherence.Cloud
{
	internal sealed class StorageException : Exception
	{
		public StorageErrorType ErrorType { get; }

		internal StorageException(StorageErrorType errorType, string message, Exception innerException = null)
		{
		}

		internal static StorageException NotLoggedIn(StorageObjectId[] storageIds, string methodName)
		{
			return null;
		}

		internal static StorageException StorageObjectNotFound(params StorageObjectId[] idsNotFound)
		{
			return null;
		}

		internal static StorageException From(Exception exception, params StorageObjectId[] storageIds)
		{
			return null;
		}

		internal static string GetStorageObjectNotFoundErrorMessage(params StorageObjectId[] storageIds)
		{
			return null;
		}
	}
}
