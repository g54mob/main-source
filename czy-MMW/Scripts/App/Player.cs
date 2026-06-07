using System;
using System.Collections.Generic;
using System.Globalization;
using Factory;

public class Player : IReleasedFromScopeHandler
{
	private string _id;

	private ILegacyUserProfile _userProfile;

	private IExtendedUserProfile _extendedUserProfile;

	private IDeviceSettings _deviceSettings;

	private IGameJournalSave _localSavedGame;

	private readonly List<IGameJournalSave> _foreignSavedGames = new List<IGameJournalSave>();

	[Dependency]
	private IScope _scope;

	[Dependency]
	private IPersistentStorageService _storage;

	[Dependency]
	private PlayerDatabase _playerDatabase;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Player");

	public string Id => _id;

	public DateTime LastPlayedUtcTimeOnLocalDevice
	{
		get
		{
			if (_deviceSettings.LastPlayedUtcTime > DateTime.MinValue)
			{
				Log.Info("Player {0} has a last-played time on this device of {1}.", _id, _deviceSettings.LastPlayedUtcTime.ToString(DateTimeFormatInfo.InvariantInfo));
				return _deviceSettings.LastPlayedUtcTime;
			}
			DateTime utcTimestamp = _userProfile.UtcTimestamp;
			if (_extendedUserProfile.UtcTimestamp > utcTimestamp)
			{
				utcTimestamp = _extendedUserProfile.UtcTimestamp;
			}
			if (_deviceSettings.UtcTimestamp > utcTimestamp)
			{
				utcTimestamp = _deviceSettings.UtcTimestamp;
			}
			if (_localSavedGame != null && _localSavedGame.UtcTimestamp > utcTimestamp)
			{
				utcTimestamp = _localSavedGame.UtcTimestamp;
			}
			Log.Info("Player {0} has no last-played time on this device, estimating a time of {1} instead.", _id, utcTimestamp.ToString(DateTimeFormatInfo.InvariantInfo));
			return utcTimestamp;
		}
	}

	public bool HasAvatar
	{
		get
		{
			if (AvatarColorIndex != -1)
			{
				return AvatarIconIndex != -1;
			}
			return false;
		}
	}

	public int AvatarColorIndex
	{
		get
		{
			return ExtendedUserProfile.AvatarColorIndex;
		}
		set
		{
			ExtendedUserProfile.AvatarColorIndex = value;
		}
	}

	public int AvatarIconIndex
	{
		get
		{
			return ExtendedUserProfile.AvatarIconIndex;
		}
		set
		{
			ExtendedUserProfile.AvatarIconIndex = value;
		}
	}

	public LocaleDatabase.LocaleId LocaleId
	{
		get
		{
			return DeviceSettings.LastLocaleId;
		}
		set
		{
			DeviceSettings.LastLocaleId = value;
		}
	}

	public bool HasLocalSavedGame => _localSavedGame != null;

	public IGameJournalSave LocalSavedGame
	{
		get
		{
			return _localSavedGame;
		}
		set
		{
			if (_localSavedGame != value)
			{
				if (_localSavedGame != null)
				{
					_scope.Release(_localSavedGame);
				}
				_localSavedGame = value;
				if (_localSavedGame != null)
				{
					_localSavedGame.Player = this;
				}
				this.SavedGamesChanged?.Invoke();
			}
		}
	}

	public bool HasForeignSavedGames => _foreignSavedGames.Count + _playerDatabase.GlobalSavedGames.Count > 0;

	public IEnumerable<IGameJournalSave> ForeignSavedGames
	{
		get
		{
			foreach (IGameJournalSave foreignSavedGame in _foreignSavedGames)
			{
				yield return foreignSavedGame;
			}
			foreach (IGameJournalSave globalSavedGame in _playerDatabase.GlobalSavedGames)
			{
				yield return globalSavedGame;
			}
		}
	}

	public ILegacyUserProfile UserProfile => _userProfile;

	public IExtendedUserProfile ExtendedUserProfile => _extendedUserProfile;

	public IDeviceSettings DeviceSettings => _deviceSettings;

	public event Action DataChanged;

	public event Action SavedGamesChanged;

	public void Initialize(string id)
	{
		_id = id;
		_userProfile = _scope.Get<ILegacyUserProfile>();
		_userProfile.DataChanged += OnDataChanged;
		_userProfile.Player = this;
		_extendedUserProfile = _scope.Get<IExtendedUserProfile>();
		_extendedUserProfile.DataChanged += OnDataChanged;
		_extendedUserProfile.Player = this;
		_deviceSettings = _scope.Get<IDeviceSettings>();
		_deviceSettings.DataChanged += OnDataChanged;
		_deviceSettings.Player = this;
	}

	public void ChooseAvatar(int colorCount, int iconCount)
	{
		List<int> list = new List<int>();
		while (list.Count < colorCount)
		{
			list.Add(list.Count);
		}
		Random.ShuffleList(list);
		List<int> list2 = new List<int>();
		while (list2.Count < iconCount)
		{
			list2.Add(list2.Count);
		}
		Random.ShuffleList(list2);
		ExtendedUserProfile.AvatarColorIndex = -1;
		ExtendedUserProfile.AvatarIconIndex = -1;
		foreach (int item in list)
		{
			bool flag = true;
			foreach (Player player in _playerDatabase.Players)
			{
				if (player.AvatarColorIndex == item)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				ExtendedUserProfile.AvatarColorIndex = item;
				break;
			}
		}
		foreach (int item2 in list2)
		{
			bool flag2 = true;
			foreach (Player player2 in _playerDatabase.Players)
			{
				if (player2.AvatarIconIndex == item2)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				ExtendedUserProfile.AvatarIconIndex = item2;
				break;
			}
		}
		if (ExtendedUserProfile.AvatarColorIndex == -1)
		{
			ExtendedUserProfile.AvatarColorIndex = Random.Range(0, colorCount);
		}
		if (ExtendedUserProfile.AvatarIconIndex == -1)
		{
			ExtendedUserProfile.AvatarIconIndex = Random.Range(0, iconCount);
		}
	}

	public void AddForeignSavedGame(IGameJournalSave newForeignSavedGame)
	{
		int num = 0;
		while (num < _foreignSavedGames.Count)
		{
			if (_foreignSavedGames[num].DeviceId == newForeignSavedGame.DeviceId)
			{
				IGameJournalSave obj = _foreignSavedGames[num];
				_foreignSavedGames.RemoveAt(num);
				_scope.Release(obj);
			}
			else
			{
				num++;
			}
		}
		newForeignSavedGame.Player = this;
		_foreignSavedGames.Add(newForeignSavedGame);
		this.SavedGamesChanged?.Invoke();
	}

	public IGameJournalSave GetForeignSavedGame(string savedGameId)
	{
		foreach (IGameJournalSave foreignSavedGame in _foreignSavedGames)
		{
			if (foreignSavedGame.DeviceId == savedGameId)
			{
				return foreignSavedGame;
			}
		}
		foreach (IGameJournalSave globalSavedGame in _playerDatabase.GlobalSavedGames)
		{
			if (globalSavedGame.DeviceId == savedGameId)
			{
				return globalSavedGame;
			}
		}
		return null;
	}

	public void RemoveSavedGame(IGameJournalSave savedGame)
	{
		if (savedGame == _localSavedGame)
		{
			LocalSavedGame = null;
		}
		else if (_foreignSavedGames.Contains(savedGame))
		{
			_foreignSavedGames.Remove(savedGame);
			_storage.Delete(savedGame);
			this.SavedGamesChanged?.Invoke();
		}
	}

	public void RemoveSavedGame(string savedGameDeviceId)
	{
		if (_localSavedGame != null && (savedGameDeviceId == _localSavedGame.DeviceId || savedGameDeviceId == PlayerDatabase.LegacyDeviceId))
		{
			RemoveSavedGame(_localSavedGame);
			return;
		}
		foreach (IGameJournalSave foreignSavedGame in _foreignSavedGames)
		{
			if (foreignSavedGame.DeviceId == savedGameDeviceId)
			{
				RemoveSavedGame(foreignSavedGame);
				break;
			}
		}
	}

	public void MergeUserProfile(ILegacyUserProfile newUserProfile)
	{
		_userProfile.Merge(newUserProfile);
		_auditTrail.RecordEvent("Player.MergeUserProfile", delegate(Dictionary<string, string> metadata)
		{
			metadata["mergedTimestamp"] = _userProfile.UtcTimestamp.ToString(DateTimeFormatInfo.InvariantInfo);
			metadata["mergedJson"] = Json.Serialize(_userProfile.SerializeToJson());
		});
	}

	public void MergeExtendedUserProfile(IExtendedUserProfile newExtendedUserProfile)
	{
		_extendedUserProfile.Merge(newExtendedUserProfile);
		_auditTrail.RecordEvent("Player.MergeExtendedUserProfile", delegate(Dictionary<string, string> metadata)
		{
			metadata["mergedTimestamp"] = _extendedUserProfile.UtcTimestamp.ToString(DateTimeFormatInfo.InvariantInfo);
			metadata["mergedJson"] = Json.Serialize(_extendedUserProfile.SerializeToJson());
		});
	}

	public void MergeDeviceSettings(IDeviceSettings newDeviceSettings)
	{
		_deviceSettings.Merge(newDeviceSettings);
		_auditTrail.RecordEvent("Player.MergeDeviceSettings", delegate(Dictionary<string, string> metadata)
		{
			metadata["mergedTimestamp"] = _deviceSettings.UtcTimestamp.ToString(DateTimeFormatInfo.InvariantInfo);
			metadata["mergedJson"] = Json.Serialize(_deviceSettings.SerializeToJson());
		});
	}

	public static int CompareAccessTime(Player x, Player y)
	{
		int num = x.DeviceSettings.LastPlayedUtcTime.CompareTo(y.DeviceSettings.LastPlayedUtcTime);
		if (num != 0)
		{
			return num;
		}
		return x.LastPlayedUtcTimeOnLocalDevice.CompareTo(y.LastPlayedUtcTimeOnLocalDevice);
	}

	public void OnReleasedFromScope(IScope scope)
	{
		_scope.Release(_userProfile);
		_scope.Release(_extendedUserProfile);
		_scope.Release(_deviceSettings);
		if (_localSavedGame != null)
		{
			_scope.Release(_localSavedGame);
		}
	}

	private void OnDataChanged()
	{
		this.DataChanged?.Invoke();
	}
}
