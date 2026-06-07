using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class NetworkPort
{
	[Serializable]
	private class PortDataWrapper
	{
		public PortData[] ports;
	}

	[Serializable]
	private class PortData
	{
		public string name;

		public string deviceID;
	}

	[Header("Device")]
	public ConnectDeviceType connectDevice;

	[Header("Objects")]
	public Button button;

	public Transform pathcord;

	public Image diode;

	public static string NetworkPortsSaveToString(NetworkPort[] ports)
	{
		return null;
	}

	public static NetworkPort[] NetworkPortLoadFromString(NetworkPort[] orginal, string data)
	{
		return null;
	}
}
