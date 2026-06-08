using LaundryBear.PlatformServices;

namespace Platform.IO
{
	public struct EnumerateFilesResult : IStorageErrorable<EnumerateFilesResult>
	{
		public StorageResult result;

		public string[] files;

		public EnumerateFilesResult(StorageResult result, string[] files)
		{
			this.result = result;
			this.files = files;
		}

		public EnumerateFilesResult ThrowIfFailed()
		{
			result.ThrowIfFailedWithDetails("Enumerate Files issue");
			return this;
		}

		public bool WasSuccessful()
		{
			return result.WasSuccessful();
		}

		public EnumerateFilesResult LogErrorIfFailed()
		{
			result.LogIfErrored();
			return this;
		}
	}
}
