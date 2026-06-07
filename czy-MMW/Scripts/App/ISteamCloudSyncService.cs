using JetBrains.Annotations;

public interface ISteamCloudSyncService
{
	bool IsSupported { get; }

	AsyncRequestHandle Authenticate([NotNull] SteamCloudAuthenticationCompleted authenticationCompleted);

	AsyncRequestHandle DownloadProfiles([NotNull] string accessToken, [NotNull] SteamCloudProfileDownloadCompleted downloadCompleted);
}
