using System;
using System.Collections.Generic;
using Factory;

public class SwitchUserStorage : IPersistentStorageProvider
{
	[Dependency]
	private IFileSystem _fileSystem;

	[Dependency]
	private IStorableTypeHandlerRegistry _storableTypeHandlerRegistry;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("SwitchUserStorage");

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
		foreach (string item in _fileSystem.GetFilesInDirectory(string.Empty))
		{
			string playerId;
			string deviceId;
			IStorableTypeHandler handlerForFilename = _storableTypeHandlerRegistry.GetHandlerForFilename(item, out playerId, out deviceId);
			if (handlerForFilename == null)
			{
				Log.Info("Found unrecognised file {0} in Switch user storage.", item);
				continue;
			}
			byte[] array = _fileSystem.ReadFile(item);
			if (array != null)
			{
				IStorable storable = handlerForFilename.Load(array);
				if (storable == null)
				{
					Log.Warn("The file {0} was unable to be parsed as the type {1}.", item, handlerForFilename);
				}
				else
				{
					handlerForFilename.ProcessLoadedStorable(storable, playerId, deviceId);
				}
			}
		}
		loadCompleteCallback?.Invoke();
	}

	public bool Store(string filename, byte[] data, NamedStoreCompleted storeCompleteCallback)
	{
		bool didStoreSucceed = _fileSystem.WriteFile(filename, data);
		_auditTrail.RecordEvent("SwitchFileStorage.Store", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
			metadata["success"] = didStoreSucceed.ToString();
		});
		storeCompleteCallback?.Invoke(filename, didStoreSucceed ? StoreOperationResult.Succeeded : StoreOperationResult.Failed);
		return didStoreSucceed;
	}

	public bool Delete(string filename)
	{
		_auditTrail.RecordEvent("SwitchFileStorage.Delete", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
		});
		if (_fileSystem.DeleteFile(filename))
		{
			return true;
		}
		Log.Warn("Unable to delete {0}.", filename);
		return false;
	}

	public bool DeletePlayer(string playerIdToDelete)
	{
		foreach (string item in _fileSystem.GetFilesInDirectory(string.Empty))
		{
			if (_storableTypeHandlerRegistry.IsFilenameRecognized(item, out var playerId, out var _) && playerId == playerIdToDelete)
			{
				Delete(item);
			}
		}
		return true;
	}
}
