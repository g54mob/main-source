public class AssetManagementDeviceLineData
{
	public string deviceType;

	public string deviceSubtype;

	public string deviceNameText;

	public string deviceEOL;

	public bool isBroken;

	public string deviceState;

	public bool isWarningCleared;

	public NetworkSwitch networkSwitch;

	public Server server;

	public AssetManagementDeviceLineData(string type, NetworkSwitch device)
	{
	}

	public AssetManagementDeviceLineData(string type, Server device)
	{
	}
}
