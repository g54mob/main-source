using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.Platform;
using Steamworks;
using Steamworks.Data;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport;
using UnityEngine;
using UnityEngine.Networking;

public abstract class NetworkSubsetBase
{
	public const int SERVER_MAX_ID_LENGTH = 28;

	public const int SERVER_MIN_ID_LENGTH = 15;

	public const int SERVER_SEARCH_ID_LENGTH = 9;

	public const int SERVER_PASSWORD_LENGTH = 6;

	protected const int LOBBY_SEARCH_ID_LENGTH = 6;

	protected const int CLIENT_PASSWORD_LENGTH = 8;

	protected const int DEFAULT_PORT = 27015;

	public const string DEFAULT_IP = "0.0.0.0";

	protected const uint _lobbyIdUpperPart = 25559040u;

	protected NetAddress serverAddress;

	public string LocalIP = "0.0.0.0";

	public string IP = "0.0.0.0";

	public ushort Port;

	private bool _clientAuthenticated;

	private object _lock;

	protected byte[] _steamRelayPasswordBytes;

	protected string _steamRelayPassword;

	protected Func<ulong, bool> IsUserBannedCheck;

	protected string steamRelayPassword
	{
		get
		{
			return _steamRelayPassword;
		}
		set
		{
			if (value != null)
			{
				_steamRelayPasswordBytes = Encoding.UTF8.GetBytes(value);
			}
			_steamRelayPassword = value;
		}
	}

	public byte[] PasswordBytes => _steamRelayPasswordBytes;

	protected static int _passwordLength => 8;

	public virtual SteamId MySteamID => default(SteamId);

	public abstract bool UsesDirectConnection();

	public abstract bool ConnectedToDedicatedServer(ServerConnectionInfo session);

	public virtual void SetPasswordFromSession(ServerConnectionInfo session)
	{
		if (!string.IsNullOrEmpty(session.GameID))
		{
			steamRelayPassword = GetPasswordFromSession(session.GameID);
		}
	}

	private static int SearchIDLength(string session)
	{
		return session.Length - (IsServer(session) ? 6 : 8);
	}

	protected string GetPasswordFromSession(string session)
	{
		return session.Substring(SearchIDLength(session));
	}

	public virtual void ProvideValidSessionID(ref ServerConnectionInfo sessionInfo)
	{
		if (string.IsNullOrEmpty(sessionInfo.GameID) || sessionInfo.GameID.Length < 15 || sessionInfo.GameID.Length > 28 || !Manager.networking.IsValidSessionId(sessionInfo.GameID))
		{
			if (string.IsNullOrEmpty(sessionInfo.GameID))
			{
				Manager.main.AddStartupIssue("No GameID found. Creating new GameID for the session.");
			}
			else if (sessionInfo.GameID.Length < 15)
			{
				Manager.main.AddStartupIssue("Provided GameID \"" + sessionInfo.GameID + "\" was too short. Proper GameID was created instead.");
			}
			else if (sessionInfo.GameID.Length > 28)
			{
				Manager.main.AddStartupIssue("Provided GameID \"" + sessionInfo.GameID + "\" was too long. Proper GameID was created instead.");
			}
			else if (!Manager.networking.IsValidSessionId(sessionInfo.GameID))
			{
				Manager.main.AddStartupIssue("Provided GameID \"" + sessionInfo.GameID + "\" contained invalid characters. Proper GameID was created instead.");
			}
			sessionInfo.GameID = Manager.networking.GenerateSessionId(9 + _passwordLength);
		}
		sessionInfo.JoinedWithIP = false;
	}

	public abstract bool IsUserValid(SteamId steamId);

	public abstract Task<Pug.Platform.SteamNetworking.ConnectResult> Connect(ServerConnectionInfo connectionInfo, CancellationToken cancellationToken);

	public abstract ConnectionManager TryConnect(IConnectionManager iConnectionManager, ref Pug.Platform.SteamNetworking.ConnectResult result);

	public abstract byte[] AuthenticationMessage();

	public abstract bool IsValidConnection(SteamId connectedTo);

	public abstract void AuthenticatePlayer();

	public unsafe virtual bool CheckPasswordAndAuthentication(NetIdentity identity, IntPtr data, int size, out string debugString, out ulong playerID)
	{
		debugString = "";
		playerID = 0uL;
		if (size != steamRelayPassword.Length)
		{
			Debug.Log($"Authentication message was wrong length: {size}");
			return false;
		}
		fixed (byte* steamRelayPasswordBytes = _steamRelayPasswordBytes)
		{
			if (UnsafeUtility.MemCmp((void*)data, steamRelayPasswordBytes, steamRelayPassword.Length) != 0)
			{
				Debug.Log("Authentication: failed authenticating password");
				return false;
			}
		}
		playerID = identity.SteamId.Value;
		return true;
	}

	public abstract bool IsUserBanned(ulong userID, bool onConnecting);

	public abstract Task SetPublicIP();

	protected NetworkSubsetBase(object lockObject, Func<ulong, bool> isUserBannedCheck)
	{
		_lock = lockObject;
		IsUserBannedCheck = isUserBannedCheck;
	}

	public void SetDefaultInfo()
	{
		if (Port == 0)
		{
			Port = 27015;
		}
	}

	public static string SearchIdFromSession(string session)
	{
		return session.Substring(0, SearchIDLength(session));
	}

	protected static bool IsServer(string session)
	{
		return session.Length >= 15;
	}

	private static string SessionFromLobbyId(uint lobbyId)
	{
		char[] sessionIdCharacterPool = NetworkingManager.sessionIdCharacterPool;
		StringBuilder stringBuilder = new StringBuilder(32);
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append(sessionIdCharacterPool[lobbyId % (uint)sessionIdCharacterPool.Length]);
			lobbyId /= (uint)sessionIdCharacterPool.Length;
		}
		return stringBuilder.ToString();
	}

	public static ServerConnectionInfo CreateLobbyID(uint accountID)
	{
		return new ServerConnectionInfo
		{
			GameID = SessionFromLobbyId(accountID) + Manager.networking.GenerateSessionId(_passwordLength)
		};
	}

	public static async Task<string> GetPublicIP()
	{
		int serverAmount = 3;
		int serverAnswers = 0;
		string publicIP = null;
		UnityMainThreadDispatcher.Instance().Enqueue(GetPublicIP("https://api64.ipify.org", ServerAnswer));
		UnityMainThreadDispatcher.Instance().Enqueue(GetPublicIP("https://checkip.amazonaws.com", ServerAnswer));
		UnityMainThreadDispatcher.Instance().Enqueue(GetPublicIP("https://ifconfig.me", ServerAnswer));
		while (serverAnswers < serverAmount && publicIP == null)
		{
			await Task.Delay(500);
		}
		return publicIP;
		void ServerAnswer(string ip)
		{
			serverAnswers++;
			if (ip != null && ip != "0.0.0.0")
			{
				publicIP = ip;
			}
		}
	}

	private static IEnumerator GetPublicIP(string url, Action<string> callback)
	{
		using UnityWebRequest request = UnityWebRequest.Get(url);
		yield return request.SendWebRequest();
		if (request.result == UnityWebRequest.Result.Success)
		{
			string obj = request.downloadHandler.text.Trim();
			callback?.Invoke(obj);
		}
		else
		{
			callback?.Invoke(null);
		}
	}

	public NetworkEndpoint GetLocalEndpoint()
	{
		return NetworkEndpoint.Parse(LocalIP, Port);
	}

	public unsafe NetworkEndpoint EndPointFromSteamId(ulong connectionId)
	{
		NetworkEndpoint result = default(NetworkEndpoint);
		NativeArray<byte> nativeArray = new NativeArray<byte>(UnsafeUtility.SizeOf<ulong>(), Allocator.Temp);
		UnsafeUtility.CopyStructureToPtr(ref connectionId, nativeArray.GetUnsafePtr());
		result.SetRawAddressBytes(nativeArray, NetworkFamily.Custom);
		nativeArray.Dispose();
		return result;
	}

	public bool IsAuthenticated()
	{
		lock (_lock)
		{
			return _clientAuthenticated;
		}
	}

	public void SetAuthenticated(bool isTrue)
	{
		lock (_lock)
		{
			_clientAuthenticated = isTrue;
		}
	}
}
