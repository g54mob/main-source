namespace VampireSurvivors.Framework.Platforms.Saves;

public interface IPlatformSaveBackup
{
	void TryRestoreBlobAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false);

	bool BackupExists(string blobName);
}
