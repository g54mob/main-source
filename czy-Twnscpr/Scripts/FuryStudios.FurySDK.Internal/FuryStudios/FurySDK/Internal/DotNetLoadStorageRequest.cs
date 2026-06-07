namespace FuryStudios.FurySDK.Internal
{
	public class DotNetLoadStorageRequest : DotNetStorageRequest
	{
		private byte[] data;

		public DotNetLoadStorageRequest(string filePath)
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
