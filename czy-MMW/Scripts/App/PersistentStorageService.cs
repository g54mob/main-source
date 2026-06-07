using System;
using System.Collections.Generic;
using System.Diagnostics;
using Factory;

public class PersistentStorageService : IPersistentStorageService, ICreatedInScopeHandler
{
	private PersistentStorageServiceStatus _status;

	private bool _hasRegisteredTick;

	private bool _hasProviderCompletedInitialLoad;

	private readonly List<Action> _loadCallbacks = new List<Action>();

	private readonly Dictionary<string, IStorable> _storablesToWrite = new Dictionary<string, IStorable>();

	private readonly Dictionary<string, List<StoreCompleted>> _storeCallbacks = new Dictionary<string, List<StoreCompleted>>();

	private readonly HashSet<string> _filenamesToDelete = new HashSet<string>();

	private readonly HashSet<string> _playersToDelete = new HashSet<string>();

	[Dependency]
	private TickRegistry _tickRegistry;

	[Dependency]
	private IStorableTypeHandlerRegistry _storableTypeHandlerRegistry;

	[Dependency]
	private IPersistentStorageProvider _provider;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("PersistentStorageService");

	public bool RequiresOptionsPanel => _provider.RequiresOptionsPanel;

	public PersistentStorageServiceStatus Status => _status;

	public event Action<PersistentStorageServiceStatus> StatusChanged;

	public void LoadAll(Action loadCompletedCallback)
	{
		if (!_hasRegisteredTick)
		{
			_hasRegisteredTick = true;
			_tickRegistry.AppTicking += Tick;
		}
		if (loadCompletedCallback != null)
		{
			_loadCallbacks.Add(loadCompletedCallback);
		}
		using (_auditTrail.OpenEvent("IPersistentStorageProvider.LoadAll"))
		{
			_provider.LoadAll(OnLoadCompleted);
		}
	}

	public bool Store(IStorable storable, StoreCompleted storeCompletedCallback)
	{
		IStorableTypeHandler handlerForStorable = _storableTypeHandlerRegistry.GetHandlerForStorable(storable);
		if (handlerForStorable == null)
		{
			return false;
		}
		string filename = handlerForStorable.GetFilename(storable);
		if (string.IsNullOrEmpty(filename))
		{
			Log.Error("Unable to find type handler for storable {0}.", storable);
			return false;
		}
		_auditTrail.RecordEvent("PersistentStorageService.Store", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
			metadata["stackTrace"] = new StackTrace(4).ToString();
		});
		_storablesToWrite[filename] = storable;
		_filenamesToDelete.Remove(filename);
		if (_playersToDelete.Count > 0 && handlerForStorable.IsFilenameRecognized(filename, out var playerId, out var _))
		{
			_playersToDelete.Remove(playerId);
		}
		if (storeCompletedCallback != null)
		{
			if (!_storeCallbacks.TryGetValue(filename, out var value))
			{
				value = new List<StoreCompleted>();
				_storeCallbacks.Add(filename, value);
			}
			value.Add(storeCompletedCallback);
		}
		return true;
	}

	public bool Delete(IStorable storable)
	{
		IStorableTypeHandler handlerForStorable = _storableTypeHandlerRegistry.GetHandlerForStorable(storable);
		if (handlerForStorable == null)
		{
			return false;
		}
		string filename = handlerForStorable.GetFilename(storable);
		if (string.IsNullOrEmpty(filename))
		{
			return false;
		}
		_auditTrail.RecordEvent("PersistentStorageService.Delete", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
			metadata["stackTrace"] = new StackTrace(4).ToString();
		});
		_filenamesToDelete.Add(filename);
		_storablesToWrite.Remove(filename);
		if (_storeCallbacks.TryGetValue(filename, out var value))
		{
			foreach (StoreCompleted item in value)
			{
				item(StoreOperationResult.Cancelled);
			}
			_storeCallbacks.Remove(filename);
		}
		return true;
	}

	public void DeletePlayer(string playerId)
	{
		_auditTrail.RecordEvent("PersistentStorageService.DeletePlayer", delegate(Dictionary<string, string> metadata)
		{
			metadata["playerId"] = playerId;
			metadata["stackTrace"] = new StackTrace(4).ToString();
		});
		_playersToDelete.Add(playerId);
	}

	public void OnCreatedInScope(IScope scope)
	{
		_provider.StatusChanged += OnStatusChanged;
	}

	private void Tick(float deltaTime)
	{
		if (_hasProviderCompletedInitialLoad)
		{
			if (_filenamesToDelete.Count > 0)
			{
				foreach (string filenameToDelete in _filenamesToDelete)
				{
					using (_auditTrail.OpenEvent("IPersistentStorageProvider.Delete", delegate(Dictionary<string, string> metadata)
					{
						metadata["filename"] = filenameToDelete;
					}))
					{
						if (!_provider.Delete(filenameToDelete))
						{
							Log.Warn("Failed to delete {0}. This is being ignored for now but is not ideal.");
						}
					}
				}
				_filenamesToDelete.Clear();
			}
			if (_playersToDelete.Count > 0)
			{
				foreach (string playerToDelete in _playersToDelete)
				{
					using (_auditTrail.OpenEvent("IPersistentStorageProvider.DeletePlayer", delegate(Dictionary<string, string> metadata)
					{
						metadata["playerId"] = playerToDelete;
					}))
					{
						if (!_provider.DeletePlayer(playerToDelete))
						{
							Log.Warn("Failed to delete storables for player {0}. This is being ignored for now but is not ideal.");
						}
					}
				}
				_playersToDelete.Clear();
			}
			if (_storablesToWrite.Count > 0)
			{
				foreach (KeyValuePair<string, IStorable> item in _storablesToWrite)
				{
					string filename = item.Key;
					IStorable value = item.Value;
					using (_auditTrail.OpenEvent("IPersistentStorageProvider.Store", delegate(Dictionary<string, string> metadata)
					{
						metadata["filename"] = filename;
					}))
					{
						IStorableTypeHandler handlerForStorable = _storableTypeHandlerRegistry.GetHandlerForStorable(value);
						if (handlerForStorable == null)
						{
							Log.Warn("Failed to type handler for storable {0}.", value);
							continue;
						}
						byte[] array = handlerForStorable.Store(value);
						if (array == null)
						{
							Log.Warn("Failed to store {0} as bytes. Data loss may occur", value);
						}
						else if (!_provider.Store(filename, array, OnStoreCompleted))
						{
							Log.Warn("Failed to store {0} as {1}. Data loss may occur.", value, filename);
						}
					}
				}
				_storablesToWrite.Clear();
			}
		}
		_provider.Tick();
	}

	private void OnLoadCompleted()
	{
		_hasProviderCompletedInitialLoad = true;
		foreach (Action loadCallback in _loadCallbacks)
		{
			loadCallback();
		}
		_loadCallbacks.Clear();
	}

	private void OnStoreCompleted(string filename, StoreOperationResult result)
	{
		Log.Info("Write to {0} completed with result {1}", filename, result.ToString());
		_auditTrail.RecordEvent("PersistentStorageService.OnStoreCompleted", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
			metadata["result"] = result.ToString();
		});
		if (!_storeCallbacks.TryGetValue(filename, out var value))
		{
			return;
		}
		foreach (StoreCompleted item in value)
		{
			item(result);
		}
		_storeCallbacks.Remove(filename);
	}

	private void OnStatusChanged(PersistentStorageServiceStatus status)
	{
		_auditTrail.RecordEvent("PersistentStorageService.OnStatusChanged", delegate(Dictionary<string, string> metadata)
		{
			if (_status.issues != status.issues)
			{
				metadata["oldIssues"] = _status.issues.ToString();
				metadata["newIssues"] = status.issues.ToString();
			}
			if (_status.messageKey != status.messageKey)
			{
				metadata["oldMessage"] = _status.messageKey;
				metadata["newMessage"] = status.messageKey;
			}
		});
		_status = status;
		this.StatusChanged?.Invoke(status);
	}
}
