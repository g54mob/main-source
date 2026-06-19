using System;
using System.Net;

[Serializable]
public struct ServerConnectionInfo
{
	public string PublicIP;

	[NonSerialized]
	public string LocalIP;

	public string Port;

	public string Password;

	public string GameID;

	[NonSerialized]
	public bool JoinedWithIP;

	private static readonly string[] urlStarters = new string[4] { "https://", "http://", "https:", "http:" };

	private static readonly string[] urlEnders = new string[1] { "/" };

	public bool SupportsDirectConnection => !string.IsNullOrEmpty(Password);

	public string CopiedPackedInfo => PackConnectionID(PublicIP, Port, null, Password);

	public string PackedGameInfo => PackConnectionID(PublicIP, Port, GameID, Password);

	public string PasswordGameID
	{
		get
		{
			if (string.IsNullOrEmpty(Password))
			{
				return GameID;
			}
			return PackedGameInfo;
		}
	}

	public string IPPort => PublicIP + ":" + Port;

	public override string ToString()
	{
		return PasswordGameID;
	}

	public bool IsValid()
	{
		return !string.IsNullOrEmpty(JoinedWithIP ? Password : GameID);
	}

	public void CopyData(ServerConnectionInfo connectionInfo)
	{
		if (!string.IsNullOrEmpty(connectionInfo.GameID))
		{
			GameID = connectionInfo.GameID;
		}
		if (!string.IsNullOrEmpty(connectionInfo.Password))
		{
			Password = connectionInfo.Password;
		}
		JoinedWithIP = connectionInfo.JoinedWithIP;
		if (!string.IsNullOrEmpty(connectionInfo.PublicIP) && string.IsNullOrEmpty(PublicIP))
		{
			PublicIP = connectionInfo.PublicIP;
		}
		if (!string.IsNullOrEmpty(connectionInfo.Port) && string.IsNullOrEmpty(Port))
		{
			Port = connectionInfo.Port;
		}
	}

	public static bool IsDirectServerIP(string id)
	{
		if (id != null)
		{
			if (!id.Contains(";") && !id.Contains(":"))
			{
				return id.Contains("/");
			}
			return true;
		}
		return false;
	}

	public static string PackConnectionID(ServerConnectionInfo serverConnectionInfo)
	{
		return PackConnectionID(serverConnectionInfo.PublicIP, serverConnectionInfo.Port, serverConnectionInfo.GameID, serverConnectionInfo.Password);
	}

	public static string PackConnectionID(string ip, string port, string gameID, string password)
	{
		return ip + ";" + port + ";" + gameID + ";" + password;
	}

	public static ServerConnectionInfo UnPackConnectionID(string id)
	{
		if (IsDirectServerIP(id))
		{
			string[] array = urlStarters;
			foreach (string text in array)
			{
				if (id.StartsWith(text))
				{
					id = id.Substring(text.Length);
				}
			}
			string[] array2 = id.Split(":");
			if (!id.Contains(":") || array2[0].Length <= 4)
			{
				array2 = id.Split(";");
			}
			string text2 = array2[0];
			string text3 = null;
			string text4 = null;
			string text5 = null;
			if (array2.Length > 1)
			{
				text3 = array2[1];
			}
			if (array2.Length > 2)
			{
				text4 = array2[2];
			}
			if (array2.Length > 3)
			{
				int num = text2.Length + text3.Length + text4.Length + 3;
				int num2 = id.Length - num;
				if (num2 > 0)
				{
					text5 = id.Substring(num, num2);
				}
			}
			if (IPAddress.TryParse(text2, out var address))
			{
				text2 = address.ToString();
			}
			else
			{
				array = urlEnders;
				foreach (string text6 in array)
				{
					if (text2.EndsWith(text6))
					{
						text2 = text2.Substring(0, text2.Length - text6.Length);
					}
				}
			}
			return new ServerConnectionInfo
			{
				PublicIP = text2,
				Port = text3,
				GameID = text4,
				Password = text5,
				JoinedWithIP = !string.IsNullOrEmpty(text5)
			};
		}
		return new ServerConnectionInfo
		{
			GameID = id,
			JoinedWithIP = false
		};
	}

	public override bool Equals(object obj)
	{
		if (obj is ServerConnectionInfo connectionInfo)
		{
			return Equals(connectionInfo);
		}
		return false;
	}

	public bool Equals(ServerConnectionInfo connectionInfo)
	{
		if (GameID == connectionInfo.GameID)
		{
			return Password == connectionInfo.Password;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (GameID, Password).GetHashCode();
	}

	public static bool operator ==(ServerConnectionInfo lhs, ServerConnectionInfo rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(ServerConnectionInfo lhs, ServerConnectionInfo rhs)
	{
		return !lhs.Equals(rhs);
	}
}
