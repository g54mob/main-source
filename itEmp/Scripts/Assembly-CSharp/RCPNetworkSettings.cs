using UnityEngine;

public class RCPNetworkSettings : PTSMonoBehaviour
{
	[Header("Components")]
	public SimpleRCP simpleRCP;

	public void SetNetworkSettings(string ip, string mask, string gateway)
	{
	}

	public NetworkAddressData GetNetworkSettings()
	{
		return null;
	}
}
