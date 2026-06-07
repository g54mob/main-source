using System;

public interface IPersistentStorageProvider
{
	bool RequiresOptionsPanel { get; }

	event Action<PersistentStorageServiceStatus> StatusChanged;

	void Tick();

	void LoadAll(Action loadCompleteCallback);

	bool Store(string filename, byte[] data, NamedStoreCompleted storeCompleteCallback);

	bool Delete(string filename);

	bool DeletePlayer(string playerId);
}
