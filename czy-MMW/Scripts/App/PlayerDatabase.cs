using System;
using System.Collections.Generic;
using System.Globalization;
using Factory;
using UnityEngine;

public class PlayerDatabase
{
	private readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();

	private readonly List<IGameJournalSave> _globalSavedGames = new List<IGameJournalSave>();

	[Dependency]
	private IScope _scope;

	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	[Dependency]
	private IActivePlayer _activePlayer;

	[Dependency]
	private LocaleDatabase _localeDatabase;

	[Dependency]
	private IPersistentStorageService _storage;

	[Dependency]
	private Diagnostics.StorageAuditTrail _auditTrail;

	public static readonly string LegacyDeviceId;

	private static Diagnostics.Log.Channel Log;

	public Player MostRecentPlayer
	{
		get
		{
			Player player = null;
			foreach (Player value in _players.Values)
			{
				if (player == null || Player.CompareAccessTime(value, player) > 0)
				{
					player = value;
				}
			}
			if (player == null)
			{
				Log.Info("No most recent player found in the database.");
				return null;
			}
			Log.Info("Selecting player {0} as the most recent player on this device. Last played time was {1}, last timestamp was {2}.", player.Id, player.DeviceSettings.LastPlayedUtcTime.ToString(DateTimeFormatInfo.InvariantInfo), player.LastPlayedUtcTimeOnLocalDevice.ToString(DateTimeFormatInfo.InvariantInfo));
			return player;
		}
	}

	public IEnumerable<Player> Players => _players.Values;

	public int PlayerCount => _players.Count;

	public IList<IGameJournalSave> GlobalSavedGames => _globalSavedGames;

	public Player CreatePlayer()
	{
		string text;
		do
		{
			text = Guid.NewGuid().ToString().Replace("-", "");
		}
		while (_players.ContainsKey(text));
		Player player = CreatePlayer(text);
		Locale currentLocale = _localeDatabase.CurrentLocale;
		if (currentLocale != null)
		{
			player.LocaleId = currentLocale.Id;
		}
		return player;
	}

	public void RemovePlayer(Player player)
	{
		_auditTrail.RecordEvent("PlayerDatabase.RemovePlayer", delegate(Dictionary<string, string> metadata)
		{
			metadata["playerId"] = player.Id;
		});
		_players.Remove(player.Id);
		if (_activePlayer.Player == player)
		{
			Player newActivePlayer = MostRecentPlayer ?? CreatePlayer();
			_activePlayer.ActivatePlayer(newActivePlayer);
		}
		_scope.Release(player);
	}

	public void RemovePlayer(string playerId)
	{
		Player player = GetPlayer(playerId);
		if (player != null)
		{
			RemovePlayer(player);
		}
	}

	public void DeletePlayer(Player player)
	{
		_storage.DeletePlayer(player.Id);
		RemovePlayer(player);
	}

	public Player GetPlayer(string playerId)
	{
		if (_players.TryGetValue(playerId, out var value))
		{
			return value;
		}
		return null;
	}

	public void AddUserProfile(ILegacyUserProfile newUserProfile, string playerId)
	{
		using (_auditTrail.OpenEvent("PlayerDatabase.AddUserProfile", delegate(Dictionary<string, string> metadata)
		{
			metadata["playerId"] = playerId;
			metadata["newTimestamp"] = newUserProfile.UtcTimestamp.ToString(DateTimeFormatInfo.InvariantInfo);
			metadata["newJson"] = Json.Serialize(newUserProfile.SerializeToJson());
		}))
		{
			GetOrCreatePlayer(playerId).MergeUserProfile(newUserProfile);
		}
	}

	public void AddExtendedUserProfile(IExtendedUserProfile newExtendedUserProfile, string playerId)
	{
		using (_auditTrail.OpenEvent("PlayerDatabase.AddExtendedUserProfile", delegate(Dictionary<string, string> metadata)
		{
			metadata["playerId"] = playerId;
			metadata["newTimestamp"] = newExtendedUserProfile.UtcTimestamp.ToString(DateTimeFormatInfo.InvariantInfo);
			metadata["newJson"] = Json.Serialize(newExtendedUserProfile.SerializeToJson());
		}))
		{
			GetOrCreatePlayer(playerId).MergeExtendedUserProfile(newExtendedUserProfile);
		}
	}

	public void AddDeviceSettings(IDeviceSettings newDeviceSettings, string playerId, string deviceId)
	{
		using (_auditTrail.OpenEvent("PlayerDatabase.AddDeviceSettings", delegate(Dictionary<string, string> metadata)
		{
			metadata["playerId"] = playerId;
			metadata["deviceId"] = deviceId;
			metadata["newTimestamp"] = newDeviceSettings.UtcTimestamp.ToString(DateTimeFormatInfo.InvariantInfo);
			metadata["newJson"] = Json.Serialize(newDeviceSettings.SerializeToJson());
		}))
		{
			if (deviceId == _hardwareCapabilities.UniqueDeviceId || deviceId == LegacyDeviceId)
			{
				GetOrCreatePlayer(playerId).MergeDeviceSettings(newDeviceSettings);
			}
		}
	}

	public void AddSavedGame(string playerId, string deviceId, IGameJournalSave newSavedGame)
	{
		using (_auditTrail.OpenEvent("PlayerDatabase.AddSavedGame", delegate(Dictionary<string, string> metadata)
		{
			metadata["playerId"] = playerId;
			metadata["deviceId"] = deviceId;
		}))
		{
			Player orCreatePlayer = GetOrCreatePlayer(playerId);
			if (deviceId == _hardwareCapabilities.UniqueDeviceId || deviceId == LegacyDeviceId)
			{
				newSavedGame.DeviceId = _hardwareCapabilities.UniqueDeviceId;
				orCreatePlayer.LocalSavedGame = newSavedGame;
			}
			else
			{
				newSavedGame.DeviceId = deviceId;
				orCreatePlayer.AddForeignSavedGame(newSavedGame);
			}
		}
	}

	public void AddGlobalSavedGame(IGameJournalSave newGlobalSavedGame)
	{
		_globalSavedGames.Add(newGlobalSavedGame);
	}

	private Player GetOrCreatePlayer(string playerId)
	{
		if (_players.TryGetValue(playerId, out var value))
		{
			return value;
		}
		return CreatePlayer(playerId);
	}

	private Player CreatePlayer(string playerId)
	{
		Log.Info("Creating new player with id {0}.", playerId);
		Player player = _scope.Get<Player>();
		player.Initialize(playerId);
		_players[playerId] = player;
		_auditTrail.RecordEvent("PlayerDatabase.CreatePlayer", delegate(Dictionary<string, string> metadata)
		{
			metadata["playerId"] = playerId;
		});
		return player;
	}

	static PlayerDatabase()
	{
		Log = Diagnostics.Log.OpenChannel("PlayerDatabase");
		LegacyDeviceId = HashUtils.GetMD5(SystemInfo.deviceName);
	}
}
