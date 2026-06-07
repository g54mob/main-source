using System;
using System.Collections.Generic;
using System.IO;
using Factory;

public class LocalFileStorage : IPersistentStorageProvider
{
	[Dependency]
	protected IScope _scope;

	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	[Dependency]
	protected IStorableTypeHandlerRegistry _storableTypeHandlerRegistry;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	protected static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("LocalFileStorage");

	public bool RequiresOptionsPanel => false;

	public event Action<PersistentStorageServiceStatus> StatusChanged;

	public virtual void LoadAll(Action loadCompleteCallback)
	{
		if (Directory.Exists(_hardwareCapabilities.PersistentStoragePath))
		{
			string[] files = Directory.GetFiles(_hardwareCapabilities.PersistentStoragePath);
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				string playerId;
				string deviceId;
				IStorableTypeHandler handlerForFilename = _storableTypeHandlerRegistry.GetHandlerForFilename(fileName, out playerId, out deviceId);
				if (handlerForFilename == null)
				{
					Log.Info("Found unrecognised file {0} in local file storage.", fileName);
					continue;
				}
				byte[] array = Read(text);
				if (array == null)
				{
					Log.Warn("The file {0} could not be loaded.", fileName);
					continue;
				}
				IStorable storable = handlerForFilename.Load(array);
				if (storable == null)
				{
					Log.Warn("The file {0} was unable to be parsed as the type {1}.", fileName, handlerForFilename);
					continue;
				}
				storable.IsAuthoritative = true;
				if (handlerForFilename.ProcessLoadedStorable(storable, playerId, deviceId))
				{
					if (!(deviceId == PlayerDatabase.LegacyDeviceId))
					{
						continue;
					}
					string filename = handlerForFilename.GetFilename(playerId, _hardwareCapabilities.UniqueDeviceId);
					string text2 = Path.Combine(_hardwareCapabilities.PersistentStoragePath, filename);
					Log.Info("Migrating file {0} with legacy device id to {1}.", text, text2);
					try
					{
						if (File.Exists(text2))
						{
							File.Delete(text);
						}
						else
						{
							File.Move(text, text2);
						}
					}
					catch (Exception ex)
					{
						Log.Warn("Failed to migrate.\n{0}", ex);
					}
				}
				else
				{
					_scope.Release(storable);
				}
			}
		}
		loadCompleteCallback?.Invoke();
	}

	public void Tick()
	{
	}

	public virtual bool Store(string filename, byte[] data, NamedStoreCompleted storeCompleteCallback)
	{
		string filepath = Path.Combine(_hardwareCapabilities.PersistentStoragePath, filename);
		StoreOperationResult storeOperationResult = (Write(filepath, data) ? StoreOperationResult.Succeeded : StoreOperationResult.Failed);
		storeCompleteCallback?.Invoke(filename, storeOperationResult);
		return storeOperationResult == StoreOperationResult.Succeeded;
	}

	public virtual bool Delete(string filename)
	{
		_auditTrail.RecordEvent("LocalFileStorage.Delete", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
		});
		string text = Path.Combine(_hardwareCapabilities.PersistentStoragePath, filename);
		try
		{
			File.Delete(text);
			return true;
		}
		catch (Exception ex)
		{
			Log.Warn("Unable to delete {0}.\n{1}", text, ex);
			return false;
		}
	}

	public virtual bool DeletePlayer(string playerIdToDelete)
	{
		if (Directory.Exists(_hardwareCapabilities.PersistentStoragePath))
		{
			string[] files = Directory.GetFiles(_hardwareCapabilities.PersistentStoragePath);
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				if (_storableTypeHandlerRegistry.IsFilenameRecognized(fileName, out var playerId, out var _) && playerId == playerIdToDelete)
				{
					try
					{
						File.Delete(text);
					}
					catch (Exception ex)
					{
						Log.Warn("Unable to delete {0}.\n{1}", text, ex);
					}
				}
			}
		}
		return true;
	}

	protected void SetStatus(PersistentStorageServiceStatus status)
	{
		this.StatusChanged?.Invoke(status);
	}

	private byte[] Read(string filepath)
	{
		try
		{
			return File.ReadAllBytes(filepath);
		}
		catch (Exception ex)
		{
			Log.Warn("Unable to read from {0}.\n{1}", filepath, ex);
			return null;
		}
	}

	private bool Write(string filepath, byte[] data)
	{
		try
		{
			File.WriteAllBytes(filepath, data);
			return true;
		}
		catch (Exception ex)
		{
			Log.Warn("Unable to write to {0}.\n{1}", filepath, ex);
			return false;
		}
	}
}
