namespace FuryStudios.FurySDK.Internal
{
	public class DotNetCheckIfFileExists : AsyncRequest<bool>
	{
		private readonly string filePath;

		public DotNetCheckIfFileExists(string filePath)
		{
		}

		protected override void OnStarted()
		{
		}
	}
}
