using System;
using System.Collections.Generic;

[Serializable]
public class NetworkDHCPServer
{
	[Serializable]
	private class DHCPServerData
	{
		public bool ServerEnable;

		public string startRange;

		public string endRange;

		public List<DHCPAssignedDeviceData> assignedIPs;
	}

	[Serializable]
	private class DHCPAssignedDeviceData
	{
		public string addressIP;

		public string deviceID;
	}

	public bool ServerEnable;

	public string startRange;

	public string endRange;

	public List<NetworkDHCPServerAssignedDeviceData> assignedIPs;

	public string SaveToString()
	{
		return null;
	}

	public static NetworkDHCPServer LoadFromString(string data)
	{
		return null;
	}
}
