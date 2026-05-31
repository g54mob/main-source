using UnityEngine;

public class NetworkPatchPanel : PTSMonoBehaviour
{
	[Header("Unique Device ID")]
	public string deviceID;

	[Header("Device Settings")]
	public string patchpanelName;

	[Header("Device")]
	public Object myDevice;

	[Header("Ports")]
	public NetworkPatchPanelPort[] portsData;

	protected override void PTSOnValidateInspector()
	{
	}

	protected override void PTSOnValidateFromMenu()
	{
	}
}
