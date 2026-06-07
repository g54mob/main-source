namespace BrewGame.SaveSystem.Storage
{
	public enum CloudSyncStatus
	{
		NoSave = 0,
		Synced = 1,
		CloudNewer = 2,
		LocalNewer = 3,
		LocalOnly = 4,
		CloudOnly = 5,
		CloudUnavailable = 6
	}
}
