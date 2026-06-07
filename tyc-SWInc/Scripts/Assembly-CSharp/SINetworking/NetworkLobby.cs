using System;
using System.Net;
using System.Net.Sockets;
using Steamworks;
using UnityEngine;

namespace SINetworking
{
	public class NetworkLobby
	{
		public enum RoundLimitType
		{
			DisablePause = 0,
			ForceFullSpeed = 1,
			Skipday = 2
		}

		public string Name;

		public ELobbyType Type;

		public object ConnectionObject;

		public object LobbyConnection;

		public string UniqueID;

		private int _availableSpots;

		private int _players;

		private int _currentYear;

		private int _daysPerMonth;

		private int _difficulty;

		private int _roundType;

		private float _forcedIPO;

		private float _roundLimit;

		private bool _dataMods;

		private bool _passwordProtected;

		private bool _furnitureMods;

		private bool _codeMods;

		private string _protocolVersion;

		private string _host;

		private string[] _saveIDs;

		public Versioning.Version V;

		public bool Compatible
		{
			get
			{
				return V.EqualsSimple(Versioning.CurrentVersion);
			}
		}

		public string ProtocolVersion
		{
			get
			{
				return _protocolVersion;
			}
			set
			{
				_protocolVersion = value;
				V = Versioning.DisectVersionString(value);
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "ProtocolVersion", _protocolVersion.ToString());
				}
			}
		}

		public string VersionHighlight
		{
			get
			{
				if (!Compatible)
				{
					return ProtocolVersion.FontColor(Color.red);
				}
				return ProtocolVersion;
			}
		}

		public string Host
		{
			get
			{
				return _host;
			}
			set
			{
				_host = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "Host", _host.ToString());
				}
			}
		}

		public RoundLimitType RoundType
		{
			get
			{
				return (RoundLimitType)_roundType;
			}
			set
			{
				_roundType = (int)value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "RoundType", _roundType.ToString());
				}
			}
		}

		public int AvailableSpots
		{
			get
			{
				return _availableSpots;
			}
			set
			{
				_availableSpots = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "AvailableSpots", _availableSpots.ToString());
				}
			}
		}

		public float ForcedIPO
		{
			get
			{
				return _forcedIPO;
			}
			set
			{
				_forcedIPO = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "ForcedIPO", _forcedIPO.ToString());
				}
			}
		}

		public float RoundLimit
		{
			get
			{
				return _roundLimit;
			}
			set
			{
				_roundLimit = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "RoundLimit", _roundLimit.ToString());
				}
			}
		}

		public int Players
		{
			get
			{
				return _players;
			}
			set
			{
				_players = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "Players", _players.ToString());
				}
			}
		}

		public int CurrentYear
		{
			get
			{
				return _currentYear;
			}
			set
			{
				_currentYear = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "CurrentYear", _currentYear.ToString());
				}
			}
		}

		public int DaysPerMonth
		{
			get
			{
				return _daysPerMonth;
			}
			set
			{
				_daysPerMonth = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "DaysPerMonth", _daysPerMonth.ToString());
				}
			}
		}

		public int Difficulty
		{
			get
			{
				return _difficulty;
			}
			set
			{
				_difficulty = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "Difficulty", _difficulty.ToString());
				}
			}
		}

		public bool DataMods
		{
			get
			{
				return _dataMods;
			}
			set
			{
				_dataMods = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "DataMods", _dataMods ? "1" : "0");
				}
			}
		}

		public bool CodeMods
		{
			get
			{
				return _codeMods;
			}
			set
			{
				_codeMods = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "CodeMods", _codeMods ? "1" : "0");
				}
			}
		}

		public bool FurnitureMods
		{
			get
			{
				return _furnitureMods;
			}
			set
			{
				_furnitureMods = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "FurnitureMods", _furnitureMods ? "1" : "0");
				}
			}
		}

		public string[] SaveIDs
		{
			get
			{
				return _saveIDs;
			}
			set
			{
				_saveIDs = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "SaveIDs", string.Join("|", _saveIDs));
				}
			}
		}

		public bool PasswordProtected
		{
			get
			{
				return _passwordProtected;
			}
			set
			{
				_passwordProtected = value;
				if (ShouldSetMeta())
				{
					NetworkLayer.Active.SetLobbyMeta(this, "PasswordProtected", _passwordProtected ? "1" : "0");
				}
			}
		}

		public string GetDifficultyName()
		{
			return DifficultyValues.NetworkDifficultyComp[Mathf.Clamp(_difficulty, 0, DifficultyValues.NetworkDifficultyComp.Length - 1)].Name;
		}

		public string GetRoundType()
		{
			if (float.IsInfinity(_roundLimit))
			{
				return "NotApplicableAbbr".Loc();
			}
			return RoundType.ToString().Loc();
		}

		public bool HasLocalSave()
		{
			if (_saveIDs != null)
			{
				return _saveIDs.Any(SaveGameManager.HasPlayed);
			}
			return false;
		}

		public NetworkLobby(string name, object connectionObject, string uniqueID)
		{
			Name = name;
			ConnectionObject = connectionObject;
			UniqueID = uniqueID;
		}

		public bool ShouldSetMeta()
		{
			if (NetworkManager.IsHost)
			{
				return NetworkLayer.Active.CurrentLobby == this;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Concat(Name, " (", ConnectionObject, ")");
		}

		public string GetMeta()
		{
			TcpListener tcpListener = (TcpListener)NetworkManager.Self.ConnectionObject;
			return string.Concat("QUERY\n", tcpListener.LocalEndpoint, "\n", Name, "\n", AvailableSpots, "\n", Players, "\n", CurrentYear, "\n", string.Join("|", SaveIDs), "\n", DataMods ? "1" : "0", "\n", Difficulty, "\n", DaysPerMonth, "\n", ForcedIPO, "\n", Host, "\n", PasswordProtected ? "1" : "0", "\n", CodeMods ? "1" : "0", "\n", FurnitureMods ? "1" : "0", "\n", Versioning.SimpleNetworkVersionString, "\n", RoundLimit, "\n", _roundType);
		}

		public static NetworkLobby ReceiveMeta(string meta, int lobbyPort, IPEndPoint remoteEP)
		{
			string[] array = meta.Split('\n');
			ValueTuple<string, int> valueTuple = LANLayer.ParseConnection(array[1], lobbyPort);
			NetworkLobby networkLobby = new NetworkLobby(array[2], new IPEndPoint(IPAddress.Parse(valueTuple.Item1), valueTuple.Item2), remoteEP.ToString());
			networkLobby.UpdateLobbyMeta("AvailableSpots", array[3]);
			networkLobby.UpdateLobbyMeta("Players", array[4]);
			networkLobby.UpdateLobbyMeta("CurrentYear", array[5]);
			networkLobby.UpdateLobbyMeta("SaveIDs", array[6]);
			networkLobby.UpdateLobbyMeta("DataMods", array[7]);
			networkLobby.UpdateLobbyMeta("Difficulty", array[8]);
			networkLobby.UpdateLobbyMeta("DaysPerMonth", array[9]);
			networkLobby.UpdateLobbyMeta("ForcedIPO", array[10]);
			networkLobby.UpdateLobbyMeta("Host", array[11]);
			networkLobby.UpdateLobbyMeta("PasswordProtected", array[12]);
			networkLobby.UpdateLobbyMeta("CodeMods", array[13]);
			networkLobby.UpdateLobbyMeta("FurnitureMods", array[14]);
			networkLobby.UpdateLobbyMeta("ProtocolVersion", array[15]);
			networkLobby.UpdateLobbyMeta("RoundLimit", array[16]);
			networkLobby.UpdateLobbyMeta("RoundType", array[17]);
			networkLobby.LobbyConnection = remoteEP;
			return networkLobby;
		}

		public void UpdateLobbyMeta(string var, string value)
		{
			switch (var)
			{
			case "AvailableSpots":
				_availableSpots = value.ConvertToIntDef(0);
				break;
			case "Players":
				_players = value.ConvertToIntDef(0);
				break;
			case "CurrentYear":
				_currentYear = value.ConvertToIntDef(0);
				break;
			case "SaveIDs":
				_saveIDs = value.Split('|');
				break;
			case "ProtocolVersion":
				_protocolVersion = value;
				V = Versioning.DisectVersionString(value);
				break;
			case "Difficulty":
				_difficulty = value.ConvertToIntDef(0);
				break;
			case "DaysPerMonth":
				_daysPerMonth = value.ConvertToIntDef(0);
				break;
			case "DataMods":
				_dataMods = value.ConvertToIntDef(0) > 0;
				break;
			case "ForcedIPO":
				_forcedIPO = value.ConvertToFloatDef(0f);
				break;
			case "RoundLimit":
				_roundLimit = value.ConvertToFloatDef(0f);
				break;
			case "Host":
				_host = value;
				break;
			case "PasswordProtected":
				_passwordProtected = value.ConvertToIntDef(0) > 0;
				break;
			case "CodeMods":
				_codeMods = value.ConvertToIntDef(0) > 0;
				break;
			case "FurnitureMods":
				_furnitureMods = value.ConvertToIntDef(0) > 0;
				break;
			case "RoundType":
				_roundType = value.ConvertToIntDef(0);
				break;
			}
		}
	}
}
