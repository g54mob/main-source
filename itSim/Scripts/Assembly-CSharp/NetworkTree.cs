using System;
using UnityEngine;

[Serializable]
public class NetworkTree
{
	public string name;

	public string ID;

	public string addressIP;

	public string subnetMask;

	public string gateway;

	public long timeChangeSettings;

	public UnityEngine.Object device;

	public NetworkTree(UnityEngine.Object device)
	{
	}

	public bool DeviceAvaliable()
	{
		return false;
	}
}
