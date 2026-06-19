using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pug.Platform;
using Steamworks;
using Steamworks.Data;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class StandaloneNetworkingSubset : NetworkSubsetBase
{
	protected byte[] _directConnectionPasswordBytes;

	protected string _directConnectionPassword;

	protected string directConnectionPassword
	{
		get
		{
			return _directConnectionPassword;
		}
		set
		{
			if (value != null)
			{
				_directConnectionPasswordBytes = Encoding.UTF8.GetBytes(value);
			}
			_directConnectionPassword = value;
		}
	}

	public override bool UsesDirectConnection()
	{
		return true;
	}

	public override bool ConnectedToDedicatedServer(ServerConnectionInfo session)
	{
		return session.IsValid();
	}

	public override void SetPasswordFromSession(ServerConnectionInfo session)
	{
		base.SetPasswordFromSession(session);
		if (!string.IsNullOrEmpty(session.Password))
		{
			directConnectionPassword = session.Password;
		}
	}

	public override void ProvideValidSessionID(ref ServerConnectionInfo sessionInfo)
	{
		base.ProvideValidSessionID(ref sessionInfo);
		if (string.IsNullOrEmpty(sessionInfo.Password) || sessionInfo.Password == "PleaseChangeMe")
		{
			Manager.main.AddStartupIssue("No proper Password found. Creating new Password for the session.");
			sessionInfo.Password = Manager.networking.GenerateSessionId(9 + NetworkSubsetBase._passwordLength);
		}
		if (LocalIP == "0.0.0.0")
		{
			string internalIp = GetInternalIp();
			if (!string.IsNullOrEmpty(internalIp))
			{
				LocalIP = internalIp;
			}
		}
		sessionInfo.PublicIP = IP;
		sessionInfo.LocalIP = LocalIP;
		sessionInfo.Port = Port.ToString();
		sessionInfo.JoinedWithIP = true;
	}

	public override bool IsUserValid(SteamId steamId)
	{
		return true;
	}

	public override Task<Pug.Platform.SteamNetworking.ConnectResult> Connect(ServerConnectionInfo connectionInfo, CancellationToken cancellationToken)
	{
		Pug.Platform.SteamNetworking.ConnectResult result = default(Pug.Platform.SteamNetworking.ConnectResult);
		string publicIP = connectionInfo.PublicIP;
		ushort port = ushort.Parse(connectionInfo.Port);
		bool flag = false;
		if (IPAddress.TryParse(publicIP, out var address))
		{
			if (address.AddressFamily != AddressFamily.InterNetwork && address.AddressFamily != AddressFamily.InterNetworkV6)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		string text = (flag ? Gethostbyname(publicIP) : publicIP);
		SteamNetworkingUtils.AllowWithoutAuth = 1;
		Debug.Log("IP: " + text + ":" + port);
		serverAddress = NetAddress.From(text, port);
		IP = publicIP;
		Port = port;
		result.NetworkEndPoint = EndPointFromSteamId(0uL);
		return Task.FromResult(result);
	}

	public override ConnectionManager TryConnect(IConnectionManager iConnectionManager, ref Pug.Platform.SteamNetworking.ConnectResult result)
	{
		if (serverAddress.Port != 0 && !serverAddress.IsFakeIPv4)
		{
			Debug.Log($"Trying to connect to {serverAddress}");
			return SteamNetworkingSockets.ConnectNormal(serverAddress, iConnectionManager);
		}
		return null;
	}

	public override byte[] AuthenticationMessage()
	{
		return Encoding.UTF8.GetBytes(_directConnectionPassword + ":" + Manager.platform.platformImpl.GetPlatformUserID().GetPlatformOnlineId());
	}

	public override bool IsValidConnection(SteamId connectedTo)
	{
		return true;
	}

	public override void AuthenticatePlayer()
	{
	}

	public unsafe override bool CheckPasswordAndAuthentication(NetIdentity identity, IntPtr data, int size, out string debugString, out ulong playerID)
	{
		if (base.CheckPasswordAndAuthentication(identity, data, size, out debugString, out playerID))
		{
			return true;
		}
		fixed (byte* directConnectionPasswordBytes = _directConnectionPasswordBytes)
		{
			if (UnsafeUtility.MemCmp((void*)data, directConnectionPasswordBytes, directConnectionPassword.Length) != 0)
			{
				Debug.Log("Authentication: failed authenticating password");
				return false;
			}
		}
		string text = Marshal.PtrToStringUTF8(data, size);
		if (!text.Contains(":"))
		{
			Debug.Log("Authentication: failed authentication due to not providing password.");
			return false;
		}
		int num = text.LastIndexOf(":", StringComparison.Ordinal);
		if (num != directConnectionPassword.Length)
		{
			Debug.Log("Authentication: The password wasn't correct length.");
			return false;
		}
		string text2 = text.Substring(num + 1, text.Length - (num + 1));
		if (!ulong.TryParse(text2, out playerID))
		{
			Debug.Log("Authentication: failed authentication due to not providing proper ulong account id: " + text2);
			return false;
		}
		if (IsUserBanned(playerID, onConnecting: false))
		{
			Debug.Log("Authentication: disconnected player due to them being banned");
			debugString = "Banned";
			return false;
		}
		return true;
	}

	public override bool IsUserBanned(ulong userID, bool onConnecting)
	{
		if (!onConnecting)
		{
			return IsUserBannedCheck(userID);
		}
		return true;
	}

	public override async Task SetPublicIP()
	{
		IP = await NetworkSubsetBase.GetPublicIP();
		if (IP == null)
		{
			Debug.Log(string.Format("{0}.{1}: Didn't receive public ip.", this, "SetPublicIP"));
			IP = "None";
		}
		else
		{
			Debug.Log(string.Format("{0}.{1}: Received public ip {2}", this, "SetPublicIP", IP));
		}
	}

	public string GetInternalIp()
	{
		string result = null;
		try
		{
			string text = InternalIPCheck(AddressFamily.InterNetwork);
			if (text == null)
			{
				text = InternalIPCheck(AddressFamily.InterNetworkV6);
			}
			if (text != null)
			{
				result = text;
			}
		}
		catch
		{
			Debug.Log("failed get internal IP");
		}
		return result;
	}

	private string InternalIPCheck(AddressFamily addressFamily)
	{
		UnicastIPAddressInformation unicastIPAddressInformation = null;
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface networkInterface in allNetworkInterfaces)
		{
			if (networkInterface.OperationalStatus != OperationalStatus.Up)
			{
				continue;
			}
			IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
			if (iPProperties.GatewayAddresses.Count == 0)
			{
				continue;
			}
			foreach (UnicastIPAddressInformation unicastAddress in iPProperties.UnicastAddresses)
			{
				if (unicastAddress.Address.AddressFamily != addressFamily || IPAddress.IsLoopback(unicastAddress.Address))
				{
					continue;
				}
				if (!unicastAddress.IsDnsEligible)
				{
					if (unicastIPAddressInformation == null)
					{
						unicastIPAddressInformation = unicastAddress;
					}
					continue;
				}
				if (unicastAddress.PrefixOrigin != PrefixOrigin.Dhcp)
				{
					if (unicastIPAddressInformation == null || !unicastIPAddressInformation.IsDnsEligible)
					{
						unicastIPAddressInformation = unicastAddress;
					}
					continue;
				}
				return unicastAddress.Address.ToString();
			}
		}
		return unicastIPAddressInformation?.Address.ToString();
	}

	public static string Gethostbyname(string url)
	{
		url = url.Replace("http://", "");
		url = url.Replace("https://", "");
		if (url.Contains("/"))
		{
			url = url.Substring(0, url.IndexOf("/"));
		}
		if (!url.Contains("www."))
		{
			url = "www." + url;
		}
		return Dns.GetHostEntry(url).AddressList[0].ToString();
	}

	public StandaloneNetworkingSubset(object lockObject, Func<ulong, bool> isUserBannedCheck)
		: base(lockObject, isUserBannedCheck)
	{
	}
}
