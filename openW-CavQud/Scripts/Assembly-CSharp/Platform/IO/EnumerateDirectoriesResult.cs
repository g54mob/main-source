using LaundryBear.PlatformServices;

namespace Platform.IO
{
	public struct EnumerateDirectoriesResult : IStorageErrorable<EnumerateDirectoriesResult>
	{
		public StorageResult result;

		public string[] directories;

		public EnumerateDirectoriesResult(StorageResult result, string[] directories)
		{
			this.result = result;
			this.directories = directories;
		}

		public bool WasSuccessful()
		{
			return result.WasSuccessful();
		}

		public EnumerateDirectoriesResult ThrowIfFailed()
		{
			result.ThrowIfFailedWithDetails("Enumerate Directories issue");
			return this;
		}

		public EnumerateDirectoriesResult LogErrorIfFailed()
		{
			result.LogIfFailedWithDetails("Enumerate Directories issue");
			return this;
		}
	}
}
