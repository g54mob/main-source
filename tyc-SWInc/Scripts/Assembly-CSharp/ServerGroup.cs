using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServerGroup
{
	public string Name;

	public string Fallback;

	public float Available = 1f;

	public float PowerSum;

	public float LastUsed;

	public bool Broken;

	public bool IsCloud;

	public Color WireColor;

	public Server Rep;

	public HashSet<IServerHost> Servers = new HashSet<IServerHost>();

	public HashSet<IServerItem> Items = new HashSet<IServerItem>();

	private static List<MinimumSpanningTree<Server, Vector3>.TreeNode> _cachedResult = new List<MinimumSpanningTree<Server, Vector3>.TreeNode>();

	public byte CloudProvider
	{
		get
		{
			NetworkServer networkServer;
			if (Servers.Count != 1 || (networkServer = Servers.First() as NetworkServer) == null)
			{
				return 0;
			}
			return networkServer.PlayerID;
		}
	}

	public ServerGroup(string name)
	{
		Name = name;
		WireColor = CreateColor(from x in GameSettings.Instance.GetAllServerGroups()
			select x.WireColor);
	}

	public float GetCost()
	{
		if (IsCloud)
		{
			return GameSettings.Instance.MyCompany.CloudService.Cost;
		}
		NetworkServer networkServer;
		if (Servers.Count == 1 && (networkServer = Servers.First() as NetworkServer) != null)
		{
			return networkServer.Cost;
		}
		return 0f;
	}

	public string GetDisplayName()
	{
		if (CloudProvider > 0)
		{
			NetworkServer networkServer = (NetworkServer)Servers.First();
			return networkServer.CachedPlayerName + " (" + networkServer.Cost.Currency() + ")";
		}
		return Name;
	}

	public string GetLoadAfter(float newLoad, params IServerItem[] items)
	{
		float num = 0f;
		foreach (IServerItem item in Items)
		{
			if (!items.Contains(item))
			{
				num += item.GetLoadRequirement().BandwidthFactor(SDateTime.Now());
			}
		}
		float num2 = (num + newLoad) / PowerSum;
		if (!(num2 > 1f))
		{
			return num2.ToPercent();
		}
		return num2.ToPercent().FontColor(Color.red);
	}

	public NetworkServerItem GetItemFor(byte playerID)
	{
		foreach (IServerItem item in Items)
		{
			NetworkServerItem networkServerItem;
			if ((networkServerItem = item as NetworkServerItem) != null && networkServerItem.PlayerID == playerID)
			{
				return networkServerItem;
			}
		}
		return null;
	}

	public float GetLoadFor(byte playerID)
	{
		foreach (IServerItem item in Items)
		{
			NetworkServerItem networkServerItem;
			if ((networkServerItem = item as NetworkServerItem) != null && networkServerItem.PlayerID == playerID)
			{
				return networkServerItem.CurrentLoad * networkServerItem.LastLoad;
			}
		}
		return 0f;
	}

	public void RefreshRep()
	{
		Rep = Servers.FirstOrDefaultOf<Server>();
	}

	public void RefreshPower()
	{
		Broken = false;
		PowerSum = 0f;
		foreach (IServerHost server2 in Servers)
		{
			Server server;
			if ((object)(server = server2 as Server) != null && !server.IsReferenceNull() && !server.furn.IsReferenceNull())
			{
				Furniture furn = server.furn;
				if (furn.HasUpg && furn.upg.Broken)
				{
					Broken = true;
					PowerSum = 0f;
					break;
				}
			}
			PowerSum += server2.Power;
		}
		RefreshUsage();
	}

	public void RefreshUsage()
	{
		float useModifier = Mathf.Min(1f, LastUsed / PowerSum);
		foreach (IServerHost server2 in Servers)
		{
			Server server = server2 as Server;
			if (!server.IsReferenceNull() && !server.furn.IsReferenceNull())
			{
				server.furn.UseModifier = useModifier;
			}
		}
	}

	public static SVector3 CreateColor(IEnumerable<Color> prevColors, float saturation = 0.75f, float value = 1f)
	{
		SortedSet<float> sortedSet = new SortedSet<float>();
		int num = 0;
		float num2 = 0f;
		if (prevColors != null)
		{
			foreach (Color prevColor in prevColors)
			{
				Vector3 vector = Utilities.RGBToHSV(prevColor);
				if (num == 0)
				{
					num2 = vector.x;
				}
				if (vector.y > 0.1f)
				{
					sortedSet.Add(vector.x);
				}
				num++;
			}
		}
		switch (num)
		{
		case 0:
			return Utilities.HSVToRGBA(Utilities.RandomValue, saturation, value);
		case 1:
			return Utilities.HSVToRGBA((num2 + 0.5f) % 1f, saturation, value);
		default:
		{
			float num3 = 0f;
			float num4 = 1f;
			float num5 = 0f;
			float num6 = 0f;
			foreach (float item in sortedSet)
			{
				float num7 = item - num6;
				if (num7 > num5)
				{
					num3 = num6;
					num4 = item;
					num5 = num7;
				}
				num6 = item;
			}
			if (1f - num6 > num5)
			{
				num3 = num6;
				num4 = 1f;
			}
			return Utilities.HSVToRGBA(num3 + Utilities.RandomRange(0.25f, 0.75f) * (num4 - num3), saturation, value);
		}
		}
	}

	public void FixWiring()
	{
		List<MinimumSpanningTree<Server, Vector3>.TreeNode> list = MinimumSpanningTree<Server, Vector3>.Run(Servers.OfType<Server>(), (Server x) => x.transform.position, (Vector3 pos) => pos.x + pos.y + pos.z, (Vector3 p1, Vector3 p2) => Mathf.Abs(p1.x - p2.x) + Mathf.Abs(p1.y - p2.y) + Mathf.Abs(p1.z - p2.z), _cachedResult);
		if (list != null)
		{
			for (int num = 0; num < list.Count; num++)
			{
				list[num].S.WiredTo = list[num].PointTo;
				list[num].S.ReWire();
			}
			MinimumSpanningTree<Server, Vector3>.Finish(list);
		}
	}

	public WriteDictionary Serialize()
	{
		WriteDictionary writeDictionary = new WriteDictionary("ServerGroup");
		writeDictionary["Name"] = Name;
		writeDictionary["Fallback"] = Fallback;
		writeDictionary["Available"] = Available;
		writeDictionary["PowerSum"] = PowerSum;
		writeDictionary["WireColor"] = (SVector3)WireColor;
		writeDictionary["Broken"] = Broken;
		writeDictionary["LastUsed"] = LastUsed;
		writeDictionary["Cloud"] = IsCloud;
		if (CloudProvider > 0)
		{
			writeDictionary["CloudProvider"] = Servers.First();
		}
		return writeDictionary;
	}

	public static ServerGroup Deserialize(WriteDictionary dict)
	{
		ServerGroup serverGroup = new ServerGroup(dict["Name"].ToString());
		serverGroup.Fallback = dict.Get<string>("Fallback", null);
		serverGroup.Available = dict.Get("Available", 1f);
		serverGroup.PowerSum = dict.Get("PowerSum", 0f);
		serverGroup.WireColor = dict.Get("WireColor", CreateColor(from x in GameSettings.Instance.GetAllServerGroups()
			select x.WireColor));
		serverGroup.Broken = dict.Get("Broken", false);
		serverGroup.LastUsed = dict.Get("LastUsed", 0f);
		serverGroup.IsCloud = dict.Get("Cloud", false);
		if (dict.Contains("CloudProvider"))
		{
			serverGroup.Servers.Add(dict.Get<NetworkServer>("CloudProvider"));
		}
		return serverGroup;
	}

	public void FixReferences()
	{
		Items = Items.SelectNotNull((IServerItem x) => x.FixReferences() as IServerItem).ToHashSet();
		Items.ForEachEnum(delegate(IServerItem x)
		{
			x.SerializeServer(Name);
		});
	}

	public void ReWireAll()
	{
		foreach (Server item in Servers.OfType<Server>())
		{
			item.ReWire();
		}
	}

	public override string ToString()
	{
		return GetDisplayName();
	}
}
