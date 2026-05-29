namespace FuryStudios.FurySDK.Internal
{
	public class DotNetSaveStorageRequest : DotNetStorageRequest
	{
		public DotNetSaveStorageRequest(string filePath, string text)
			: base(null, default(StorageAccessMode))
		{
		}

		public DotNetSaveStorageRequest(string filePath, byte[] bytes)
			: base(null, default(StorageAccessMode))
		{
		}

		protected override void OnStarted()
		{
		}

		protected override void OnTaskFinish()
		{
		}
	}
}
