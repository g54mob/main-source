namespace ModIO
{
	public enum SubscribedModStatus
	{
		Installed = 0,
		WaitingToDownload = 1,
		WaitingToInstall = 2,
		WaitingToUpdate = 3,
		WaitingToUninstall = 4,
		Downloading = 5,
		Installing = 6,
		Uninstalling = 7,
		Updating = 8,
		ProblemOccurred = 9,
		None = 10
	}
}
