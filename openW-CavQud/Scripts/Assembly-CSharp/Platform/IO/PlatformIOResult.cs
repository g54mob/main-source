using LaundryBear.PlatformServices;
using UnityEngine;

namespace Platform.IO
{
	public struct PlatformIOResult : IStorageErrorable<PlatformIOResult>
	{
		public StorageResult result;

		public string errorDetails;

		public PlatformIOResult(StorageResult result, string errorDetails = null)
		{
			this.result = result;
			this.errorDetails = errorDetails;
		}

		public bool WasSuccessful()
		{
			return result.WasSuccessful();
		}

		public PlatformIOResult ThrowIfFailed()
		{
			if (WasSuccessful())
			{
				return this;
			}
			throw result.StorageResultToException(errorDetails);
		}

		public PlatformIOResult LogErrorIfFailed()
		{
			if (!WasSuccessful())
			{
				Debug.LogError("Platform.IO Error:: " + ToString());
			}
			return this;
		}

		public PlatformIOResult LogIfErrored()
		{
			if (!WasSuccessful())
			{
				Debug.LogError("Platform.IO Error:: " + ToString());
			}
			return this;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}", "result", result, "errorDetails", errorDetails);
		}
	}
}
