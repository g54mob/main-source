using JetBrains.Annotations;

public delegate void SteamCloudAuthenticationCompleted([CanBeNull] string accessToken, SteamCloudSyncError error);
