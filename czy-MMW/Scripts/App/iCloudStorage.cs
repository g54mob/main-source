using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using AOT;
using Factory;

public class iCloudStorage : IPersistentStorageProvider, ICreatedInScopeHandler, IReleasedFromScopeHandler
{
	private PersistentStorageServiceStatus _status;

	private bool _hasConnected;

	private bool _isInitialLoadRequested;

	private bool _hasInitialLoadCompleted;

	private Action _loadCallback;

	private bool _haveFilesChanged;

	private bool _hasLoadCompleted;

	private bool _wasLoadSuccessful;

	private string _userId;

	private bool _hasUserChanged;

	private string _playerIdToDelete;

	private readonly List<string> _filenamesToDelete = new List<string>();

	private readonly Dictionary<string, List<NamedStoreCompleted>> _storeCallbacks = new Dictionary<string, List<NamedStoreCompleted>>();

	[Dependency]
	private iCloudKernel _kernel;

	[Dependency]
	private PlayerDatabase _playerDatabase;

	[Dependency]
	private IReachability _reachability;

	[Dependency]
	private IStorableTypeHandlerRegistry _storableTypeHandlerRegistry;

	[Dependency]
	private IiCloudCache _localCache;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("iCloudStorage");

	private static string LegacyCachePath = "players/legacy";

	private static string UnsyncedCachePath = "players/local";

	private static string iCloudCachePath = "players/iCloud";

	private static float ConnectionTimeout = 15f;

	private static iCloudStorage Instance;

	private readonly TimeSpan _recentSaveThreshold = TimeSpan.FromDays(90.0);

	public bool RequiresOptionsPanel => true;

	private bool CanNotifyInitialLoad
	{
		get
		{
			if (!_isInitialLoadRequested)
			{
				return false;
			}
			float timeSinceConnection = _kernel.TimeSinceConnection;
			if (timeSinceConnection > ConnectionTimeout)
			{
				Log.Info("Can notify because the connection has timed out after {0}s.", timeSinceConnection);
				return true;
			}
			if (!_hasUserChanged)
			{
				return false;
			}
			if (!IsSignedIn)
			{
				Log.Info("Can notify because no user is signed in.");
				return true;
			}
			if (_reachability.Connectivity == InternetConnectivity.Disconnected)
			{
				SetStatusIssues(PersistentStorageServiceIssues.NotAvailable);
				Log.Info("Can notify because we have no internet connection.");
				return true;
			}
			if (_hasLoadCompleted)
			{
				Log.Info("Can notify because the load has completed in {0}s.", timeSinceConnection);
				return true;
			}
			return false;
		}
	}

	private bool IsSignedIn => !string.IsNullOrEmpty(_userId);

	private string iCloudUserCachePath => Path.Combine(iCloudCachePath, _userId);

	private string ActiveCachePath
	{
		get
		{
			if (!IsSignedIn)
			{
				return UnsyncedCachePath;
			}
			return iCloudUserCachePath;
		}
	}

	public event Action<PersistentStorageServiceStatus> StatusChanged;

	public void Tick()
	{
		if (!_hasInitialLoadCompleted)
		{
			if (!CanNotifyInitialLoad)
			{
				return;
			}
			Log.Info("Processing data for initial load.");
			MigrateLegacyFiles();
			if (IsSignedIn)
			{
				Log.Info("Device is signed in to iCloud.");
				LoadiCloudFiles();
				if (HasRecentlyModifiedIcloudData(_userId))
				{
					SetStatusIssues(PersistentStorageServiceIssues.AuthenticatedButOtherUsersiCloudData);
				}
				foreach (Player player in _playerDatabase.Players)
				{
					IExtendedUserProfile extendedUserProfile = player.ExtendedUserProfile;
					if (extendedUserProfile.iCloudProvenance == iCloudProvenance.Unknown)
					{
						Log.Info("Confirming provenance of migrated player '{0}'.", player.Id);
						DateTime utcTimestamp = extendedUserProfile.UtcTimestamp;
						extendedUserProfile.iCloudProvenance = iCloudProvenance.Confirmed;
						extendedUserProfile.UtcTimestamp = utcTimestamp;
						_auditTrail.RecordEvent("iCloudStorage.ConfirmProvenance", delegate(Dictionary<string, string> metadata)
						{
							metadata["playerId"] = player.Id;
						});
					}
				}
				foreach (string item in _localCache.GetFilenamesInDirectory(LegacyCachePath))
				{
					if (!_storableTypeHandlerRegistry.IsFilenameRecognized(item, out var playerId, out var _))
					{
						continue;
					}
					Player player2 = _playerDatabase.GetPlayer(playerId);
					if (player2 != null)
					{
						Log.Info("Importing legacy file '{0}'.", item);
						LoadStorableFromCache(LegacyCachePath, item);
						if (player2.ExtendedUserProfile.iCloudProvenance == iCloudProvenance.Confirmed)
						{
							Log.Info("Deleting legacy file '{0}' because its provenance has been confirmed.", item);
							string legacyFilepath = Path.Combine(LegacyCachePath, item);
							_localCache.DeleteFile(legacyFilepath);
							_auditTrail.RecordEvent("iCloudCache.DeleteFile", delegate(Dictionary<string, string> metadata)
							{
								metadata["filepath"] = legacyFilepath;
							});
						}
					}
					else
					{
						Log.Info("Legacy file '{0}' was found, but ignoring because it does not match any known iCloud player.", item);
					}
				}
				LoadCachedFiles(iCloudUserCachePath);
				if (_playerDatabase.PlayerCount == 0)
				{
					Log.Info("No players imported.");
					if (_reachability.Connectivity != InternetConnectivity.Connected || !_hasLoadCompleted || !_wasLoadSuccessful)
					{
						Log.Info("This device cannot connect to iCloud, so all legacy files will be assumed to be owned by the current iCloud account.");
						using (_auditTrail.OpenEvent("iCloudStorage.CopyLegacyFiles", delegate(Dictionary<string, string> metadata)
						{
							metadata["toDirectory"] = iCloudUserCachePath;
						}))
						{
							_localCache.CopyNewFilesInDirectory(LegacyCachePath, iCloudUserCachePath);
						}
						LoadCachedFiles(iCloudUserCachePath);
						foreach (Player player3 in _playerDatabase.Players)
						{
							Log.Info("Marking the provenance of legacy player '{0}' as presumed.", player3.Id);
							IExtendedUserProfile extendedUserProfile2 = player3.ExtendedUserProfile;
							DateTime utcTimestamp2 = extendedUserProfile2.UtcTimestamp;
							extendedUserProfile2.iCloudProvenance = iCloudProvenance.Presumed;
							extendedUserProfile2.UtcTimestamp = utcTimestamp2;
							_auditTrail.RecordEvent("iCloudStorage.PresumeProvenance", delegate(Dictionary<string, string> metadata)
							{
								metadata["playerId"] = player3.Id;
							});
						}
					}
				}
			}
			else
			{
				Log.Info("Device is not signed in to iCloud.");
				if (HasRecentlyModifiedIcloudData(string.Empty))
				{
					SetStatusIssues(PersistentStorageServiceIssues.RecentUnauthenticatedData);
				}
				using (_auditTrail.OpenEvent("iCloudStorage.CopyLegacyFiles", delegate(Dictionary<string, string> metadata)
				{
					metadata["toDirectory"] = UnsyncedCachePath;
				}))
				{
					_localCache.CopyNewFilesInDirectory(LegacyCachePath, UnsyncedCachePath);
				}
				LoadCachedFiles(UnsyncedCachePath);
			}
			_hasInitialLoadCompleted = true;
			if (_loadCallback != null)
			{
				_loadCallback();
				_loadCallback = null;
			}
		}
		else if (_haveFilesChanged)
		{
			Log.Info("Processing changes to iCloud data.");
			_haveFilesChanged = false;
			using (_auditTrail.OpenEvent("iCloudStorage.LoadChangedFiles"))
			{
				iCloudForEachChangedFile(Marshal.GetFunctionPointerForDelegate<Action<string>>(OnFileChangedDelegate));
			}
		}
	}

	public void LoadAll(Action loadCompleteCallback)
	{
		if (!_hasConnected)
		{
			_kernel.Connect();
			_hasConnected = true;
			_kernel.UserChanged += OnUserChanged;
			_kernel.FilesChanged += OnFilesChanged;
			_kernel.LoadCompleted += OnLoadCompleted;
			_kernel.FileDeleted += OnFileDeleted;
			_kernel.UserMessageChanged += OnUserMessageChanged;
			_kernel.FileStored += OnFileStored;
		}
		if (!_hasInitialLoadCompleted)
		{
			_loadCallback = loadCompleteCallback;
			_isInitialLoadRequested = true;
		}
	}

	public bool Store(string filename, byte[] data, NamedStoreCompleted storeCompleteCallback)
	{
		if (storeCompleteCallback != null)
		{
			if (!_storeCallbacks.TryGetValue(filename, out var value))
			{
				value = new List<NamedStoreCompleted>();
				_storeCallbacks.Add(filename, value);
			}
			value.Add(storeCompleteCallback);
		}
		GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
		bool didiCloudWriteSucceed = iCloudWriteFile(filename, gCHandle.AddrOfPinnedObject(), data.Length);
		if (!didiCloudWriteSucceed)
		{
			Log.Warn("Failed to write {0} to iCloud.", filename);
			storeCompleteCallback?.Invoke(filename, StoreOperationResult.Failed);
		}
		gCHandle.Free();
		_auditTrail.RecordEvent("iCloudWriteFile", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
			metadata["didSucceed"] = didiCloudWriteSucceed.ToString();
		});
		string cachedFilepath = Path.Combine(ActiveCachePath, filename);
		bool flag = true;
		if (!_localCache.HasSpaceToWriteFile(cachedFilepath, data.Length, out var bytesNeededToDelete))
		{
			Log.Warn("Unable to write {0} ({1} bytes) to the cache. We need to delete {2} bytes.", filename, data.Length, bytesNeededToDelete);
			IStorableTypeHandler handlerForType = _storableTypeHandlerRegistry.GetHandlerForType<IGameJournalSave>();
			string deviceId;
			string playerId;
			if (handlerForType != null)
			{
				Log.Info("Deleting legacy game journals to free space.");
				foreach (string item in _localCache.GetFilenamesInDirectory(LegacyCachePath))
				{
					if (handlerForType.IsFilenameRecognized(item, out deviceId, out playerId))
					{
						string text = Path.Combine(LegacyCachePath, item);
						int fileSize = _localCache.GetFileSize(text);
						if (_localCache.DeleteFile(text))
						{
							Log.Info("Deleted {0}, freeing up {1} bytes.", text, fileSize);
							bytesNeededToDelete -= fileSize;
						}
						else
						{
							Log.Warn("Failed to delete {0}!", text);
						}
					}
				}
			}
			if (bytesNeededToDelete > 0)
			{
				Log.Info("Deleting the local cache for other iCloud accounts.");
				foreach (string item2 in _localCache.GetDirectoriesInDirectory(iCloudCachePath))
				{
					if (bytesNeededToDelete <= 0)
					{
						break;
					}
					if (!(item2 != _userId))
					{
						continue;
					}
					Log.Info("Deleting the local cache for iCloud account {0}.", item2);
					string text2 = Path.Combine(iCloudCachePath, item2);
					foreach (string item3 in _localCache.GetFilenamesInDirectory(text2))
					{
						string text3 = Path.Combine(text2, item3);
						int fileSize2 = _localCache.GetFileSize(text3);
						if (_localCache.DeleteFile(text3))
						{
							Log.Info("Deleted {0}, freeing up {1} bytes.", text3, fileSize2);
							bytesNeededToDelete -= fileSize2;
						}
						else
						{
							Log.Warn("Failed to delete {0}.", text3);
						}
					}
				}
			}
			if (bytesNeededToDelete > 0 && IsSignedIn && handlerForType != null)
			{
				Log.Info("Deleting the local cache of saved games.");
				foreach (string item4 in _localCache.GetFilenamesInDirectory(ActiveCachePath))
				{
					if (item4 != filename && handlerForType.IsFilenameRecognized(item4, out playerId, out deviceId))
					{
						string text4 = Path.Combine(ActiveCachePath, item4);
						int fileSize3 = _localCache.GetFileSize(text4);
						if (_localCache.DeleteFile(text4))
						{
							Log.Info("Deleted {0}, freeing up {1} bytes.", text4, fileSize3);
							bytesNeededToDelete -= fileSize3;
						}
						else
						{
							Log.Warn("Failed to delete {0}.", text4);
						}
					}
				}
			}
			flag = bytesNeededToDelete <= 0;
			if (!flag)
			{
				Log.Warn("Unable to write {0}! We needed to free {1} additional bytes to make space for it.", filename, bytesNeededToDelete);
			}
		}
		bool didCacheWriteSucceed = false;
		if (flag)
		{
			didCacheWriteSucceed = _localCache.WriteFile(cachedFilepath, data);
			if (!didCacheWriteSucceed)
			{
				Log.Warn("Failed to write {0} to the iCloud cache.", filename);
			}
		}
		_auditTrail.RecordEvent("iCloudCache.WriteFile", delegate(Dictionary<string, string> metadata)
		{
			metadata["filepath"] = cachedFilepath;
			metadata["didSucceed"] = didCacheWriteSucceed.ToString();
		});
		return didiCloudWriteSucceed && didCacheWriteSucceed;
	}

	public bool Delete(string filename)
	{
		bool didiCloudDeleteSucceed = iCloudDeleteFile(filename);
		if (!didiCloudDeleteSucceed)
		{
			Log.Warn("Failed to delete {0} from iCloud.", filename);
		}
		_auditTrail.RecordEvent("iCloudDeleteFile", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
			metadata["didSucceed"] = didiCloudDeleteSucceed.ToString();
		});
		string cachedFilepath = Path.Combine(ActiveCachePath, filename);
		bool didCacheDeleteSucceed = _localCache.DeleteFile(cachedFilepath);
		if (!didCacheDeleteSucceed)
		{
			Log.Warn("Failed to delete {0} from the iCloud cache.", filename);
		}
		_auditTrail.RecordEvent("iCloudCache.DeleteFile", delegate(Dictionary<string, string> metadata)
		{
			metadata["filepath"] = cachedFilepath;
			metadata["didSucceed"] = didCacheDeleteSucceed.ToString();
		});
		return didiCloudDeleteSucceed && didCacheDeleteSucceed;
	}

	public bool DeletePlayer(string playerIdToDelete)
	{
		_playerIdToDelete = playerIdToDelete;
		_filenamesToDelete.Clear();
		iCloudForEachFile(Marshal.GetFunctionPointerForDelegate<Action<string>>(OnFileQueriedForDeletionDelegate));
		foreach (string filenameToDelete in _filenamesToDelete)
		{
			iCloudDeleteFile(filenameToDelete);
			_auditTrail.RecordEvent("iCloudDeleteFile", delegate(Dictionary<string, string> metadata)
			{
				metadata["filename"] = filenameToDelete;
			});
		}
		_filenamesToDelete.Clear();
		foreach (string item in _localCache.GetFilenamesInDirectory(ActiveCachePath))
		{
			if (_storableTypeHandlerRegistry.IsFilenameRecognized(item, out var playerId, out var _) && playerId == playerIdToDelete)
			{
				string cachedFilepath = Path.Combine(ActiveCachePath, item);
				_localCache.DeleteFile(cachedFilepath);
				_auditTrail.RecordEvent("iCloudCache.DeleteFile", delegate(Dictionary<string, string> metadata)
				{
					metadata["filepath"] = cachedFilepath;
				});
			}
		}
		return true;
	}

	public void OnCreatedInScope(IScope scope)
	{
		Instance = this;
		_reachability.ConnectivityChanged += OnInternetConnectivityChanged;
	}

	public void OnReleasedFromScope(IScope scope)
	{
		Instance = null;
		_kernel.UserChanged -= OnUserChanged;
		_kernel.FilesChanged -= OnFilesChanged;
		_kernel.LoadCompleted -= OnLoadCompleted;
		_kernel.FileDeleted -= OnFileDeleted;
		_kernel.UserMessageChanged -= OnUserMessageChanged;
		_kernel.FileStored -= OnFileStored;
		_reachability.ConnectivityChanged -= OnInternetConnectivityChanged;
	}

	private void LoadCachedFiles(string localDirectory)
	{
		using (_auditTrail.OpenEvent("iCloudStorage.LoadCachedFiles", delegate(Dictionary<string, string> metadata)
		{
			metadata["directory"] = localDirectory;
		}))
		{
			foreach (string item in _localCache.GetFilenamesInDirectory(localDirectory))
			{
				LoadStorableFromCache(localDirectory, item);
			}
		}
	}

	private IStorable LoadStorableFromCache(string cacheDirectory, string cacheFilename)
	{
		string filepath = cacheFilename;
		if (!string.IsNullOrEmpty(cacheDirectory))
		{
			filepath = Path.Combine(cacheDirectory, filepath);
		}
		using (_auditTrail.OpenEvent("iCloudStorage.LoadStorableFromCache", delegate(Dictionary<string, string> metadata)
		{
			metadata["filepath"] = filepath;
		}))
		{
			string playerId;
			string deviceId;
			IStorableTypeHandler handlerForFilename = _storableTypeHandlerRegistry.GetHandlerForFilename(cacheFilename, out playerId, out deviceId);
			if (handlerForFilename == null)
			{
				Log.Warn("Could not file storable type handler for {0}.", cacheFilename);
				return null;
			}
			byte[] array = _localCache.ReadFile(filepath);
			if (array == null)
			{
				Log.Warn("Could not load data from cached file at path {0}.", filepath);
				return null;
			}
			IStorable storable = handlerForFilename.Load(array);
			if (storable == null)
			{
				Log.Warn("Failed to load cached storable from path {0}.", filepath);
				return null;
			}
			storable.IsAuthoritative = false;
			handlerForFilename.ProcessLoadedStorable(storable, playerId, deviceId);
			Log.Info("Processed storable {0} for player {1}.", storable, playerId);
			return storable;
		}
	}

	private void LoadiCloudFiles()
	{
		using (_auditTrail.OpenEvent("iCloudStorage.LoadiCloudFiles"))
		{
			iCloudForEachFile(Marshal.GetFunctionPointerForDelegate<Action<string>>(OnFileChangedDelegate));
		}
		_haveFilesChanged = false;
	}

	private void MigrateLegacyFiles()
	{
		using (_auditTrail.OpenEvent("iCloudStorage.MigrateLegacyFiles"))
		{
			foreach (string legacyFilename in _localCache.GetFilenamesInDirectory(""))
			{
				Log.Info("Found legacy file at {0}.", legacyFilename);
				if (_storableTypeHandlerRegistry.IsFilenameRecognized(legacyFilename))
				{
					Log.Info("Recognised filename {0}.", legacyFilename);
					bool didMoveSucceed = _localCache.MoveFile(legacyFilename, LegacyCachePath);
					if (!didMoveSucceed)
					{
						Log.Warn("Unable to move file {0} to {1}.", legacyFilename, LegacyCachePath);
					}
					_auditTrail.RecordEvent("iCloudCache.MoveFile", delegate(Dictionary<string, string> metadata)
					{
						metadata["fromFilepath"] = legacyFilename;
						metadata["toDirectory"] = LegacyCachePath;
						metadata["didSucceed"] = didMoveSucceed.ToString();
					});
				}
			}
		}
	}

	private void SetStatusIssues(PersistentStorageServiceIssues issuesToSet)
	{
		PersistentStorageServiceIssues persistentStorageServiceIssues = _status.issues | issuesToSet;
		if (persistentStorageServiceIssues != _status.issues)
		{
			Log.Info("Status issues changed from {0} to {1}.", _status.issues, persistentStorageServiceIssues);
			_status.issues = persistentStorageServiceIssues;
			this.StatusChanged?.Invoke(_status);
		}
	}

	private void ClearStatusIssues(PersistentStorageServiceIssues issuesToClear)
	{
		PersistentStorageServiceIssues persistentStorageServiceIssues = _status.issues & ~issuesToClear;
		if (persistentStorageServiceIssues != _status.issues)
		{
			Log.Info("Status issues changed from {0} to {1}.", _status.issues, persistentStorageServiceIssues);
			_status.issues = persistentStorageServiceIssues;
			this.StatusChanged?.Invoke(_status);
		}
	}

	private void OnInternetConnectivityChanged(InternetConnectivity connectivity)
	{
		using (_auditTrail.OpenEvent("iCloudStorage.OnInternetConnectivityChanged", delegate(Dictionary<string, string> metadata)
		{
			metadata["connectivity"] = connectivity.ToString();
		}))
		{
			if (connectivity == InternetConnectivity.Disconnected)
			{
				SetStatusIssues(PersistentStorageServiceIssues.NotAvailable);
			}
		}
	}

	private void OnUserChanged(string newUserId)
	{
		if (_userId == newUserId && _hasUserChanged)
		{
			return;
		}
		_hasUserChanged = true;
		_userId = newUserId;
		using (_auditTrail.OpenEvent("iCloudStorage.OnUserChanged", delegate(Dictionary<string, string> metadata)
		{
			metadata["userId"] = (string.IsNullOrEmpty(newUserId) ? "none" : newUserId);
		}))
		{
			if (string.IsNullOrEmpty(_userId))
			{
				Log.Info("iCloud user disconnected.");
				SetStatusIssues(PersistentStorageServiceIssues.NotAuthenticated | PersistentStorageServiceIssues.NotAvailable);
			}
			else
			{
				Log.Info("iCloud user connected with id {0}.", _userId);
				ClearStatusIssues(PersistentStorageServiceIssues.NotAuthenticated);
			}
		}
	}

	private void OnFilesChanged()
	{
		Log.Info("Data changed, processing new files.");
		_haveFilesChanged = true;
		using (_auditTrail.OpenEvent("iCloudStorage.OnFilesChanged"))
		{
			ClearStatusIssues(PersistentStorageServiceIssues.NotAvailable);
		}
	}

	private void OnLoadCompleted(bool didSucceed)
	{
		if (didSucceed)
		{
			Log.Info("Load completed with no errors.");
		}
		else
		{
			Log.Info("Load completed with errors. Until we hear otherwise, we will continue but parse data assuming the data we have from iCloud is non-canonical.");
		}
		_hasLoadCompleted = true;
		_wasLoadSuccessful = didSucceed;
		using (_auditTrail.OpenEvent("iCloudStorage.OnLoadCompleted", delegate(Dictionary<string, string> metadata)
		{
			metadata["didSucceed"] = didSucceed.ToString();
		}))
		{
			if (didSucceed)
			{
				ClearStatusIssues(PersistentStorageServiceIssues.NotAvailable);
			}
			else
			{
				SetStatusIssues(PersistentStorageServiceIssues.NotAvailable);
			}
		}
	}

	private void OnFileDeleted(string deletedFilename)
	{
		using (_auditTrail.OpenEvent("iCloudStorage.OnFileDeleted", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = deletedFilename;
		}))
		{
			Log.Info("File {0} has been deleted from the database.", deletedFilename);
			string cachedFilepath = Path.Combine(ActiveCachePath, deletedFilename);
			bool didCacheDeleteSucceed = _localCache.DeleteFile(cachedFilepath);
			if (!didCacheDeleteSucceed)
			{
				Log.Warn("Failed to delete {0} from the iCloud cache.", deletedFilename);
			}
			_auditTrail.RecordEvent("iCloudCache.DeleteFile", delegate(Dictionary<string, string> metadata)
			{
				metadata["filepath"] = cachedFilepath;
				metadata["didSucceed"] = didCacheDeleteSucceed.ToString();
			});
			string playerId;
			string deviceId;
			IStorableTypeHandler handlerForFilename = _storableTypeHandlerRegistry.GetHandlerForFilename(deletedFilename, out playerId, out deviceId);
			if (handlerForFilename == null)
			{
				Log.Info("Unable to determine the file's type from the name; ignoring.");
				return;
			}
			handlerForFilename.ProcessDeletedStorable(playerId, deviceId);
			ClearStatusIssues(PersistentStorageServiceIssues.NotAvailable);
		}
	}

	private void OnUserMessageChanged(string messageStringKey)
	{
		Log.Info("Received message {0}.", messageStringKey);
		using (_auditTrail.OpenEvent("iCloudStorage.OnUserMessageChanged", delegate(Dictionary<string, string> metadata)
		{
			metadata["message"] = messageStringKey;
		}))
		{
			if (string.IsNullOrEmpty(messageStringKey))
			{
				ClearStatusIssues(PersistentStorageServiceIssues.NotAvailable);
				if (!string.IsNullOrEmpty(_status.messageKey))
				{
					_status.messageKey = null;
					this.StatusChanged?.Invoke(_status);
				}
			}
			else if (messageStringKey != _status.messageKey)
			{
				if (messageStringKey == StringId.iCloudQuotaExceeded.ToString())
				{
					SetStatusIssues(PersistentStorageServiceIssues.QuotaExceeded);
				}
				_status.messageKey = messageStringKey;
				this.StatusChanged?.Invoke(_status);
			}
		}
	}

	private void OnFileChanged(string filename)
	{
		using (_auditTrail.OpenEvent("iCloudStorage.OnFileChanged", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
		}))
		{
			Log.Info("Attempting to load iCloud file '{0}'.", filename);
			iCloudMarkCurrentVersionAsDownloaded(filename);
			string playerId;
			string deviceId;
			IStorableTypeHandler handlerForFilename = _storableTypeHandlerRegistry.GetHandlerForFilename(filename, out playerId, out deviceId);
			if (handlerForFilename == null)
			{
				Log.Info("Unable to determine the file's type from the name; ignoring.");
				return;
			}
			int dataLength = 0;
			if (!iCloudReadFile(filename, IntPtr.Zero, ref dataLength))
			{
				Log.Warn("Could not determine the file's length.");
				return;
			}
			if (dataLength <= 0)
			{
				Log.Warn("File had invalid length {0}.", dataLength);
				return;
			}
			byte[] array = new byte[dataLength];
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			int dataLength2 = dataLength;
			bool num = iCloudReadFile(filename, gCHandle.AddrOfPinnedObject(), ref dataLength2);
			gCHandle.Free();
			if (!num)
			{
				Log.Warn("Failed to read file from iCloud.");
				return;
			}
			if (dataLength2 != dataLength)
			{
				Log.Warn("We were expecting to read {0} bytes, but only read {0}.", dataLength, dataLength2);
				Array.Resize(ref array, dataLength2);
			}
			IStorable storable = handlerForFilename.Load(array);
			if (storable == null)
			{
				Log.Warn("Failed to import storable.");
				return;
			}
			storable.IsAuthoritative = true;
			Log.Info("Processing storable {0} with player id {1} and device id {2}.", storable, playerId, deviceId);
			handlerForFilename.ProcessLoadedStorable(storable, playerId, deviceId);
		}
	}

	private void OnFileStored(string filename)
	{
		Log.Info("File {0} was stored successfully.", filename);
		using (_auditTrail.OpenEvent("iCloudStorage.OnFileStored", delegate(Dictionary<string, string> metadata)
		{
			metadata["filename"] = filename;
		}))
		{
			if (_storeCallbacks.TryGetValue(filename, out var value))
			{
				foreach (NamedStoreCompleted item in value)
				{
					item(filename, StoreOperationResult.Succeeded);
				}
				_storeCallbacks.Remove(filename);
			}
			ClearStatusIssues(PersistentStorageServiceIssues.NotAvailable);
		}
	}

	private void OnFileQueriedForDeletion(string filename)
	{
		if (_storableTypeHandlerRegistry.IsFilenameRecognized(filename, out var playerId, out var _) && playerId == _playerIdToDelete)
		{
			Log.Info("Deleting file {0} associated with player {1}.", filename, _playerIdToDelete);
			_filenamesToDelete.Add(filename);
		}
	}

	private bool HasRecentlyModifiedIcloudData(string ignorediCloudUser = null, bool checkAgainstLocalData = false)
	{
		DateTime dateTime = DateTime.MinValue;
		foreach (string item in _localCache.GetFilenamesInDirectory(UnsyncedCachePath))
		{
			if (item.StartsWith("userProfile_"))
			{
				string filepath = Path.Combine(UnsyncedCachePath, item);
				dateTime = _localCache.GetFileModifiedTime(filepath);
			}
		}
		foreach (string item2 in _localCache.GetDirectoriesInDirectory(iCloudCachePath))
		{
			if (ignorediCloudUser == item2)
			{
				continue;
			}
			foreach (string item3 in _localCache.GetFilenamesInDirectory(Path.Combine(iCloudCachePath, item2)))
			{
				if (item3.StartsWith("userProfile_"))
				{
					string filepath2 = Path.Combine(iCloudCachePath, item2, item3);
					DateTime fileModifiedTime = _localCache.GetFileModifiedTime(filepath2);
					if ((fileModifiedTime > dateTime || !checkAgainstLocalData) && DateTime.UtcNow - fileModifiedTime < _recentSaveThreshold)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnFileChangedDelegate(string filename)
	{
		Instance?.OnFileChanged(filename);
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnFileQueriedForDeletionDelegate(string filename)
	{
		Instance?.OnFileQueriedForDeletion(filename);
	}

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool iCloudWriteFile(string filename, IntPtr data, int dataLength);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern int iCloudForEachFile(IntPtr fileHandler);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern int iCloudForEachChangedFile(IntPtr fileHandler);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool iCloudMarkCurrentVersionAsDownloaded(string filename);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool iCloudReadFile(string filename, IntPtr data, ref int dataLength);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool iCloudDeleteFile(string filename);
}
