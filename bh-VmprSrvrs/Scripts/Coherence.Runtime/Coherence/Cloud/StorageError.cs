using System;
using System.Diagnostics.CodeAnalysis;
using Coherence.Common;
using Coherence.Log;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public sealed class StorageError : CoherenceError<StorageErrorType>
	{
		public RequestException RequestException { get; }

		internal StorageError(StorageErrorType type, string message, Error error = Error.UnobservedError, bool hasBeenObserved = false)
		{
		}

		internal StorageError([DisallowNull] RequestException requestException, StorageObjectId[] storageObjectIds, Error error = Error.UnobservedError, bool hasBeenObserved = false)
		{
		}

		private protected override Exception ToException()
		{
			return null;
		}

		private static StorageErrorType GetStorageErrorType(RequestException requestException)
		{
			return default(StorageErrorType);
		}

		private static string GetMessage(RequestException requestException, StorageObjectId[] storageObjectIds)
		{
			return null;
		}
	}
}
