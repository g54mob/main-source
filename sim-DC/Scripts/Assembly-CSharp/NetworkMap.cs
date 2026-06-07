using System;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMap : MonoBehaviour
{
	public class Device
	{
		public string Name;

		public CableLink.TypeOfLink Type;

		public int CustomerID;

		public HashSet<Device> Connections;

		public Device(string name, CableLink.TypeOfLink type, int customerID = -1)
		{
		}
	}

	[Serializable]
	public class LACPGroup
	{
		public int groupId;

		public string deviceA;

		public string deviceB;

		public List<int> cableIds;

		public float GetAggregatedSpeed(Dictionary<int, WaypointInitializationSystem.CableInfo> cables)
		{
			return 0f;
		}
	}

	public static NetworkMap instance;

	private Dictionary<string, Device> devices;

	private Dictionary<int, CustomerBase> customerBases;

	private Dictionary<string, Server> servers;

	private Dictionary<string, NetworkSwitch> switches;

	private Dictionary<string, Server> brokenServers;

	private Dictionary<string, NetworkSwitch> brokenSwitches;

	private Dictionary<int, LACPGroup> lacpGroups;

	private int nextLACPGroupId;

	private Dictionary<string, HashSet<string>> switchConnections;

	public Dictionary<int, (string startDevice, string endDevice)> cableConnections;

	private Dictionary<string, List<string>> adjacencyList;

	private void Awake()
	{
	}

	public void ClearMap()
	{
	}

	public void RegisterCustomerBase(CustomerBase customerBase)
	{
	}

	public CustomerBase GetCustomerBase(int customerId)
	{
		return null;
	}

	public void RegisterServer(Server server)
	{
	}

	public void RegisterSwitch(NetworkSwitch networkSwitch)
	{
	}

	public int[] GetNumberOfDevices()
	{
		return null;
	}

	public Server GetServer(string serverId)
	{
		return null;
	}

	public NetworkSwitch GetSwitchById(string switchId)
	{
		return null;
	}

	public IEnumerable<Server> GetAllServers()
	{
		return null;
	}

	public IEnumerable<NetworkSwitch> GetAllNetworkSwitches()
	{
		return null;
	}

	public void UpdateCustomerServerCountAndSpeed(int customerId, int serverCount, float speed)
	{
	}

	public void UpdateDeviceCustomerID(string deviceName, int customerID)
	{
	}

	public void AddDevice(string name, CableLink.TypeOfLink type, int customerID = -1)
	{
	}

	public void RemoveDevice(string name)
	{
	}

	public void Connect(string from, string to)
	{
	}

	public void Disconnect(string from, string to)
	{
	}

	public List<List<string>> FindAllRoutes(string baseName, string serverName)
	{
		return null;
	}

	private List<List<string>> FindPhysicalPath(string start, string target)
	{
		return null;
	}

	public Device GetDevice(string name)
	{
		return null;
	}

	public List<Device> GetAllDevices()
	{
		return null;
	}

	private string GenerateDeviceName(CableLink.TypeOfLink type, Vector3 position)
	{
		return null;
	}

	public void RegisterCableConnection(int cableId, Vector3 startPos, Vector3 endPos, CableLink.TypeOfLink startType, CableLink.TypeOfLink endType, string startSwitchID = "", string endSwitchID = "", int startCustomerID = -1, int endCustomerID = -1, string startServerID = "", string endServerID = "")
	{
	}

	private void AddSwitchConnection(string switchName, string deviceName)
	{
	}

	public void RemoveCableConnection(int cableId)
	{
	}

	private void RemoveIsolatedDevices()
	{
	}

	public string PrintNetworkMap()
	{
		return null;
	}

	public bool IsIpAddressDuplicate(string ip, Server serverToExclude)
	{
		return false;
	}

	public void AddBrokenServer(Server server)
	{
	}

	public void AddBrokenSwitch(NetworkSwitch networkSwitch)
	{
	}

	public void RemoveBrokenServer(string serverId)
	{
	}

	public void RemoveBrokenSwitch(string switchId)
	{
	}

	public IEnumerable<Server> GetAllBrokenServers()
	{
		return null;
	}

	public IEnumerable<NetworkSwitch> GetAllBrokenSwitches()
	{
		return null;
	}

	public bool IsPatchPanelPort(string deviceName)
	{
		return false;
	}

	private string ResolveThroughPatchPanel(string patchPanelPort, string fromDevice)
	{
		return null;
	}

	public int CreateLACPGroup(string deviceA, string deviceB, List<int> cableIds)
	{
		return 0;
	}

	public void RemoveLACPGroup(int groupId)
	{
	}

	public void RemoveCableFromLACPGroups(int cableId)
	{
	}

	public LACPGroup GetLACPGroupForCable(int cableId)
	{
		return null;
	}

	public LACPGroup GetLACPGroupBetween(string deviceA, string deviceB)
	{
		return null;
	}

	public Dictionary<int, LACPGroup> GetAllLACPGroups()
	{
		return null;
	}

	public void SetLACPGroups(Dictionary<int, LACPGroup> groups)
	{
	}
}
