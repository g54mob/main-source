namespace FuryStudios.FurySDK.Internal
{
	public class DotNetDeleteStorageRequest : DotNetStorageRequest
	{
		public DotNetDeleteStorageRequest(string filePath)
			: base(null, default(StorageAccessMode))
		{
		}

		protected override void OnStarted()
		{
		}
	}
}
