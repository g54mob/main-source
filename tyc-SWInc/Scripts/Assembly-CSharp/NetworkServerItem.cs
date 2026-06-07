using System;
using SINetworking;

[Serializable]
public class NetworkServerItem : IServerItem, IReferenceFix
{
	public byte PlayerID;

	public string PlayerName;

	public string ServerName;

	public float CurrentLoad;

	public float LastLoad = 1f;

	public bool UsesISP
	{
		get
		{
			return true;
		}
	}

	public NetworkServerItem(NetworkPlayer player)
	{
		PlayerID = player.ID;
		PlayerName = player.Name;
	}

	public NetworkServerItem()
	{
	}

	public IReferenceFix FixReferences()
	{
		return this;
	}

	public bool CancelOnUnload()
	{
		return true;
	}

	public float GetLoadRequirement()
	{
		return CurrentLoad;
	}

	public void HandleLoad(float load)
	{
		LastLoad = load;
	}

	public string GetDescription()
	{
		return PlayerName;
	}

	public void SerializeServer(string name)
	{
		ServerName = name;
	}
}
