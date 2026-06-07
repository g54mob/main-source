using JetBrains.Annotations;

public delegate void SteamCloudProfileDownloadCompleted([CanBeNull] ILegacyUserProfile steamUserProfile, [CanBeNull] IExtendedUserProfile steamExtendedUserProfile, SteamCloudSyncError error);
