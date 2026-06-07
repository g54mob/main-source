using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SINetworking;
using Steamworks;
using UnityEngine;

public class NetworkMeta : IByteData
{
	public string ServerName;

	public string Password;

	public ELobbyType LobbyType;

	public List<string> SaveUUIDs = new List<string>();

	public int DaysPerMonth;

	public Dictionary<string, byte> PlayerIDs = new Dictionary<string, byte>();

	private HashSet<byte> _currentlyPlaying = new HashSet<byte>();

	public Dictionary<byte, float> OldPlayers = new Dictionary<byte, float>();

	public Dictionary<byte, uint> PlayerCompanies = new Dictionary<byte, uint>();

	public string LocalUniqueID;

	public bool AllowCodeMods;

	public bool AllowModdedFurniture;

	public byte NextID = 1;

	public bool IsDirty;

	[NonSerialized]
	public bool IncludePassword;

	public string CurrentUUID
	{
		get
		{
			return SaveUUIDs.Last();
		}
	}

	public IEnumerable<string> GetSomeUUIDs()
	{
		for (int i = Mathf.Max(0, SaveUUIDs.Count - 10); i < SaveUUIDs.Count; i++)
		{
			yield return SaveUUIDs[i];
		}
	}

	public static void SetDirty()
	{
		if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.NetworkData != null)
		{
			GameSettings.Instance.NetworkData.IsDirty = true;
		}
	}

	public static void CheckDirty()
	{
		if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.NetworkData != null && GameSettings.Instance.NetworkData.IsDirty)
		{
			if (NetworkManager.NotConnectedOrHost)
			{
				GameSettings.Instance.NetworkData.GenerateUUID();
				NetworkMessaging.SendBroadcastUUID(GameSettings.Instance.NetworkData.CurrentUUID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			else
			{
				GameSettings.Instance.NetworkData.IsDirty = false;
				NetworkMessaging.SendControlStatement(NetworkMessaging.ControlType.UUIDDirty, NetworkMessaging.MessageTarget.Host, 0);
			}
		}
	}

	public NetworkMeta()
	{
	}

	public NetworkMeta(NetworkMeta clone)
	{
		ServerName = clone.ServerName;
		Password = clone.Password;
		LobbyType = clone.LobbyType;
		SaveUUIDs = clone.SaveUUIDs.ToList();
		DaysPerMonth = clone.DaysPerMonth;
		PlayerIDs = clone.PlayerIDs.ToDictionary((KeyValuePair<string, byte> x) => x.Key, (KeyValuePair<string, byte> x) => x.Value);
		_currentlyPlaying = clone._currentlyPlaying.ToHashSet();
		OldPlayers = clone.OldPlayers.ToDictionary((KeyValuePair<byte, float> x) => x.Key, (KeyValuePair<byte, float> x) => x.Value);
		PlayerCompanies = clone.PlayerCompanies.ToDictionary((KeyValuePair<byte, uint> x) => x.Key, (KeyValuePair<byte, uint> x) => x.Value);
		LocalUniqueID = clone.LocalUniqueID;
		AllowCodeMods = clone.AllowCodeMods;
		AllowModdedFurniture = clone.AllowModdedFurniture;
		NextID = clone.NextID;
	}

	public bool ShareUUIDs(NetworkMeta other)
	{
		for (int i = 0; i < SaveUUIDs.Count; i++)
		{
			if (other.SaveUUIDs.Contains(SaveUUIDs[i]))
			{
				return true;
			}
		}
		return false;
	}

	public void SetPassword(string password)
	{
		if (!NetworkManager.IsHost)
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(password))
		{
			password = null;
		}
		if (password != Password)
		{
			Password = password;
			if (NetworkManager.Instance.Layer.CurrentLobby != null)
			{
				NetworkManager.Instance.Layer.CurrentLobby.PasswordProtected = Password != null;
			}
		}
	}

	public bool VerifyPassword(string password)
	{
		if (!string.IsNullOrWhiteSpace(Password))
		{
			return Password.Equals(password);
		}
		return true;
	}

	public bool TryGetPlayerCompany(string player, out uint company)
	{
		company = 0u;
		byte value;
		if (PlayerIDs.TryGetValue(player, out value))
		{
			return PlayerCompanies.TryGetValue(value, out company);
		}
		return false;
	}

	public void RegisterCompany(byte player, uint company)
	{
		PlayerCompanies[player] = company;
	}

	public void UnregisterCompany(byte player, uint company)
	{
		uint value;
		if (PlayerCompanies.TryGetValue(player, out value) && value == company)
		{
			PlayerCompanies.Remove(player);
		}
	}

	public void ReRegisterAllPlayers()
	{
		_currentlyPlaying.Clear();
		List<NetworkPlayer> players = NetworkManager.Instance.Players;
		for (int i = 0; i < players.Count; i++)
		{
			if (players[i].Connected)
			{
				_currentlyPlaying.Add(players[i].ID);
			}
		}
	}

	public void RegisterPlayer(string uniqueID)
	{
		byte value;
		if (PlayerIDs.TryGetValue(uniqueID, out value))
		{
			_currentlyPlaying.Add(value);
		}
		else
		{
			Debug.LogError("Tried to register non-existent player: " + uniqueID + " to currently playing list");
		}
	}

	public void DeRegisterPlayer(string uniqueID)
	{
		byte value;
		if (PlayerIDs.TryGetValue(uniqueID, out value))
		{
			_currentlyPlaying.Remove(value);
		}
		else
		{
			Debug.LogError("Tried to de-register non-existent player: " + uniqueID + " from currently playing list");
		}
	}

	public void RegisterPlayer(byte id)
	{
		_currentlyPlaying.Add(id);
	}

	public void DeRegisterPlayer(byte id)
	{
		_currentlyPlaying.Remove(id);
	}

	public void ClearActivePlayers()
	{
		_currentlyPlaying.Clear();
	}

	public bool IsPlaying(string uniqueID)
	{
		byte value;
		if (PlayerIDs.TryGetValue(uniqueID, out value))
		{
			return _currentlyPlaying.Contains(value);
		}
		return false;
	}

	public bool IsPlaying(byte id)
	{
		return _currentlyPlaying.Contains(id);
	}

	public IEnumerable<string> GetPlayingUnique()
	{
		return _currentlyPlaying.Select((byte b) => PlayerIDs.LookupKey(b));
	}

	public IEnumerable<byte> GetPlayingID()
	{
		return _currentlyPlaying;
	}

	public NetworkMeta(string localUniqueID, string serverName, string password, bool allowCodeMods, bool allowModdedFurniture, ELobbyType lobbyType)
	{
		ServerName = serverName;
		Password = password;
		LobbyType = lobbyType;
		LocalUniqueID = localUniqueID;
		DaysPerMonth = GameSettings.DaysPerMonth;
		AllowCodeMods = allowCodeMods;
		AllowModdedFurniture = allowModdedFurniture;
		GenerateUUID();
	}

	public void GenerateUUID()
	{
		AddUUID(Guid.NewGuid().ToString());
	}

	public void AddUUID(string uuid)
	{
		if (SaveUUIDs.Count == 0 || !uuid.Equals(SaveUUIDs.Last()))
		{
			SaveUUIDs.Add(uuid);
			if (SaveUUIDs.Count > 20)
			{
				SaveUUIDs.RemoveAt(0);
			}
			IsDirty = false;
		}
	}

	public NetworkMeta(string serverName, string password, ELobbyType lobbyType, List<string> uuids, Dictionary<string, byte> playerIDs, Dictionary<byte, float> oldPlayers, Dictionary<byte, uint> companies, int daysPerMonth)
	{
		ServerName = serverName;
		Password = password;
		LobbyType = lobbyType;
		SaveUUIDs = uuids;
		PlayerIDs = playerIDs;
		OldPlayers = oldPlayers;
		PlayerCompanies = companies;
		DaysPerMonth = daysPerMonth;
	}

	public string Serialize()
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			ActuallyWriteData(memoryStream, true, false);
			return SDFCreator.GetTreeString(memoryStream.ToArray());
		}
	}

	public void WriteData(Stream st)
	{
		ActuallyWriteData(st, IncludePassword, true);
	}

	public void ActuallyWriteData(Stream st, bool includePassword, bool includePlaying)
	{
		st.WriteInt(DaysPerMonth);
		st.WriteStringUTF8(ServerName);
		if (includePassword)
		{
			st.WriteStringUTF8(Password);
		}
		else if (Password != null)
		{
			st.WriteInt(0);
		}
		else
		{
			st.WriteInt(-1);
		}
		st.WriteByte((byte)LobbyType);
		st.WriteArray(SaveUUIDs, delegate(Stream s, string x)
		{
			s.WriteStringUTF8(x);
		});
		st.WriteInt(PlayerIDs.Count);
		foreach (KeyValuePair<string, byte> playerID in PlayerIDs)
		{
			st.WriteStringUTF8(playerID.Key);
			st.WriteByte(playerID.Value);
		}
		st.WriteInt(OldPlayers.Count);
		foreach (KeyValuePair<byte, float> oldPlayer in OldPlayers)
		{
			st.WriteByte(oldPlayer.Key);
			st.WriteFloat(oldPlayer.Value);
		}
		st.WriteInt(PlayerCompanies.Count);
		foreach (KeyValuePair<byte, uint> playerCompany in PlayerCompanies)
		{
			st.WriteByte(playerCompany.Key);
			st.WriteUInt(playerCompany.Value);
		}
		if (includePlaying)
		{
			st.WriteInt(_currentlyPlaying.Count);
			foreach (byte item in _currentlyPlaying)
			{
				st.WriteByte(item);
			}
		}
		else
		{
			st.WriteInt(0);
		}
		st.WriteStringUTF8(LocalUniqueID);
		st.WriteBools(AllowCodeMods, AllowModdedFurniture);
		st.WriteByte(NextID);
	}

	public static NetworkMeta ReadData(Stream st)
	{
		int num = st.ReadInt();
		if (num < 0)
		{
			return null;
		}
		string serverName = st.ReadStringUTF8();
		string password = st.ReadStringUTF8();
		ELobbyType lobbyType = (ELobbyType)st.ReadByte();
		string[] source = st.ReadArray((Stream s) => s.ReadStringUTF8());
		int num2 = st.ReadInt();
		Dictionary<string, byte> dictionary = new Dictionary<string, byte>(num2);
		for (int num3 = 0; num3 < num2; num3++)
		{
			dictionary[st.ReadStringUTF8()] = (byte)st.ReadByte();
		}
		num2 = st.ReadInt();
		Dictionary<byte, float> dictionary2 = new Dictionary<byte, float>(num2);
		for (int num4 = 0; num4 < num2; num4++)
		{
			dictionary2[(byte)st.ReadByte()] = st.ReadFloat();
		}
		num2 = st.ReadInt();
		Dictionary<byte, uint> dictionary3 = new Dictionary<byte, uint>(num2);
		for (int num5 = 0; num5 < num2; num5++)
		{
			dictionary3[(byte)st.ReadByte()] = st.ReadUInt();
		}
		NetworkMeta networkMeta = new NetworkMeta(serverName, password, lobbyType, source.ToList(), dictionary, dictionary2, dictionary3, num);
		num2 = st.ReadInt();
		for (int num6 = 0; num6 < num2; num6++)
		{
			networkMeta.RegisterPlayer((byte)st.ReadByte());
		}
		networkMeta.LocalUniqueID = st.ReadStringUTF8();
		st.ReadBools(out networkMeta.AllowCodeMods, out networkMeta.AllowModdedFurniture);
		networkMeta.NextID = (byte)st.ReadByte();
		return networkMeta;
	}
}
