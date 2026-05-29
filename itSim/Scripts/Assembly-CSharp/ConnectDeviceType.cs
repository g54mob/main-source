using System;
using UnityEngine;

[Serializable]
public class ConnectDeviceType
{
	public string name;

	[Header("Device")]
	public UnityEngine.Object device;

	public void ClearDevice()
	{
	}

	public bool PortAvailable()
	{
		return false;
	}

	public bool isNull()
	{
		return false;
	}

	public bool isCard()
	{
		return false;
	}

	public bool isSwitch()
	{
		return false;
	}

	public bool isRouter()
	{
		return false;
	}

	public bool isAccessPoint()
	{
		return false;
	}

	public bool isSocketRJ()
	{
		return false;
	}

	public NetworkSwitch GetDeviceBySwitch()
	{
		return null;
	}
}
