using System;

public interface IPersistentStorageService
{
	PersistentStorageServiceStatus Status { get; }

	bool RequiresOptionsPanel { get; }

	event Action<PersistentStorageServiceStatus> StatusChanged;

	void LoadAll(Action loadCompletedCallback);

	bool Store(IStorable storable, StoreCompleted storeCompletedCallback = null);

	bool Delete(IStorable storable);

	void DeletePlayer(string playerId);
}
