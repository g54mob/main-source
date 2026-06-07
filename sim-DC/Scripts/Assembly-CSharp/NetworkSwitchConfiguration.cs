using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NetworkSwitchConfiguration : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField inputField;

	[SerializeField]
	private Transform parentObjectForPortText;

	[SerializeField]
	private TextMeshProUGUI[] portInformation;

	private NetworkSwitch currentNetworkSwitch;

	private CableLink[] currentPorts;

	private HashSet<int> selectedPortIndices;

	private void Awake()
	{
	}

	public void OpenConfig(NetworkSwitch networkSwitch)
	{
	}

	private void RefreshPortDisplay()
	{
	}

	private string ResolveRemoteDevice(CableLink port)
	{
		return null;
	}

	public void ClickPort(int i)
	{
	}

	public void CreateLACP()
	{
	}

	public void RemoveLACP()
	{
	}

	public void OnEndEditingInputText(string s)
	{
	}

	public void CloseConfig()
	{
	}

	private string NormalizeDeviceKey(string deviceName)
	{
		return null;
	}

	private List<int> ResolveAllCableIds(CableLink port)
	{
		return null;
	}
}
