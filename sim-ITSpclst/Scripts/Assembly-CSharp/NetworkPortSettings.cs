using System;

[Serializable]
public class NetworkPortSettings
{
	[Serializable]
	private class NetworkPortSettingsWrapper
	{
		public NetworkPortSettings[] ports;
	}

	public string portName;

	public bool portEnable;

	public string ipAddress;

	public string subnetMask;

	public static string SaveToString(NetworkPortSettings[] ports)
	{
		return null;
	}

	public static NetworkPortSettings[] LoadFromString(string jsonString)
	{
		return null;
	}
}
