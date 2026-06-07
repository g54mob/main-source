public class NullSteamCloudSyncService : ISteamCloudSyncService
{
	public bool IsSupported => false;

	public AsyncRequestHandle Authenticate(SteamCloudAuthenticationCompleted authenticationCompleted)
	{
		authenticationCompleted(null, SteamCloudSyncError.NotSupported);
		return AsyncRequestHandle.CompletedRequestHandle;
	}

	public AsyncRequestHandle DownloadProfiles(string accessToken, SteamCloudProfileDownloadCompleted downloadCompleted)
	{
		downloadCompleted(null, null, SteamCloudSyncError.NotSupported);
		return AsyncRequestHandle.CompletedRequestHandle;
	}
}
