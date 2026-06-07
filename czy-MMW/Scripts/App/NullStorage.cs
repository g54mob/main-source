using System;

public class NullStorage : IPersistentStorageProvider
{
	public bool RequiresOptionsPanel => false;

	public event Action<PersistentStorageServiceStatus> StatusChanged
	{
		add
		{
		}
		remove
		{
		}
	}

	public void Tick()
	{
	}

	public void LoadAll(Action loadCompleteCallback)
	{
		loadCompleteCallback?.Invoke();
	}

	public bool Store(string filename, byte[] data, NamedStoreCompleted storeCompleted)
	{
		storeCompleted(filename, StoreOperationResult.Failed);
		return false;
	}

	public bool Delete(string filename)
	{
		return false;
	}

	public bool DeletePlayer(string playerId)
	{
		return false;
	}
}
