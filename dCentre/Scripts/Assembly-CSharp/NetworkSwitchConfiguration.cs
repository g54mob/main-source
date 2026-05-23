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

	private void Awake()
	{
	}

	public void OpenConfig(NetworkSwitch networkSwitch)
	{
	}

	public void OnEndEditingInputText(string s)
	{
	}

	public void ClickPort(int i)
	{
	}

	public void CloseConfig()
	{
	}
}
