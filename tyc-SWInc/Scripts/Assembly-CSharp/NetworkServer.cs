using System;
using SINetworking;

[Serializable]
public class NetworkServer : IServerHost
{
	public float Markup;

	public byte PlayerID;

	public string CachedPlayerName;

	public string ServerName { get; set; }

	public float Power { get; set; }

	public float Cost
	{
		get
		{
			return GetCost(Markup);
		}
	}

	public static float GetCost(float markup)
	{
		return Server.GetISPCost() * (1f + markup);
	}

	public NetworkServer()
	{
	}

	public NetworkServer(byte playerID, float markup, float power)
	{
		ServerName = "NETWORKPLAYERCLOUD" + playerID;
		PlayerID = playerID;
		Markup = markup;
		Power = power;
		CachedPlayerName = NetworkManager.GetPlayer(playerID).Name;
	}
}
