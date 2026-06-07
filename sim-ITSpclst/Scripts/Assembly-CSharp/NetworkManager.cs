using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
	public static NetworkManager Instance;

	public bool findDevices;

	public NetworkSwitch[] switchs;

	public NetworkRouter[] routers;

	public NetworkAccessPoint[] accessPoints;

	public NetworkCard[] cards;

	public NetworkPatchPanel[] patchPanels;

	public NetworkSocketRJ[] networkSocketRJs;

	[HideInInspector]
	public string fromIp;

	[HideInInspector]
	public string toIp;

	[HideInInspector]
	public List<NetworkTree> visited;

	public static readonly int PING_OK;

	public static readonly int PING_NOT_OK;

	public bool DebugLog;

	private void Awake()
	{
	}

	[ContextMenu("Clear All Device Connection !!!")]
	public void ClearAllDevices()
	{
	}

	public List<ResultPing> UnityEditorRunPing()
	{
		return null;
	}

	public List<ResultPing> UnityEditorRunPingDuplicatePCTool(Object FromDevice, string toIp)
	{
		return null;
	}

	public List<ResultPing> Ping(Object FromDevice, string toIp)
	{
		return null;
	}

	public List<ResultPing> Ping(Object FromDevice, Object toDevice)
	{
		return null;
	}

	private List<ResultPing> RunPing(Object FromDevice, string toIp, Object ToDevice)
	{
		return null;
	}

	public string ConvertVisitedListToString(List<NetworkTree> visited)
	{
		return null;
	}

	public bool IsConnectedDevices(Object FromDevice, Object ToDevice)
	{
		return false;
	}

	private List<NetworkTree> FindDevices(string ip)
	{
		return null;
	}

	private NetworkTree FindDevice(string ip)
	{
		return null;
	}

	public Object FindDeviceByID(string id)
	{
		return null;
	}

	public static List<NetworkTree> StaticFindDevice(string ip)
	{
		return null;
	}

	private NetworkTree IsConnected(NetworkTree fromDevice, NetworkTree toDevice, List<NetworkTree> visited, bool cableCheck)
	{
		return null;
	}

	private IEnumerable<NetworkPort> GetConnectedPorts(NetworkTree device)
	{
		return null;
	}

	private void CheckNetworkTree(List<NetworkTree> visited, List<ResultPing> resultPings)
	{
	}

	private int IsValidNetworkTransition(NetworkTree fromDevice, NetworkTree toDevice)
	{
		return 0;
	}

	private IPAddress GetSubnetAddress(IPAddress ip, IPAddress mask)
	{
		return null;
	}

	public static int InterpretResult(List<ResultPing> resultPings)
	{
		return 0;
	}

	public static bool IsIpInSubnet(string ip, string subnetIp, string subnetMask)
	{
		return false;
	}

	public static bool IsValidIp(string ip)
	{
		return false;
	}

	private static bool IsValidSubnetMask(string subnetMask)
	{
		return false;
	}

	public string GetDHCPData(Object mainDevice, Object askDevice)
	{
		return null;
	}

	public void GetAssignedIPsFromRange(Object device, NetworkDHCPServer dhcp)
	{
	}

	private bool DeviceWithDHCP(Object device)
	{
		return false;
	}

	private bool IpIsMyDevice(Object mainDevice, string newIp, Object askDevice)
	{
		return false;
	}

	private int ConvertIpToInt(string ip)
	{
		return 0;
	}

	private string ConvertIntToIp(int ipInt)
	{
		return null;
	}

	public static string GenerateRandomMacAddress()
	{
		return null;
	}

	public static bool IsExistDeviceWithMac(string mac)
	{
		return false;
	}

	public static void FindConflictAddress()
	{
	}

	private void LocalFindConflictAddress()
	{
	}

	private void SetAddressConflict(NetworkTree tree, bool hasConflict)
	{
	}
}
