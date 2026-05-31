using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppFirewall : PTSMonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public AppBase AppBase;

	public ComputerNetwork computerNetwork;

	public NotifiSystemManager notifiSystemManager;

	[HideInInspector]
	public bool isOpen;

	[Header("Statusy")]
	public Image[] colorbox;

	public TextMeshProUGUI connectedStatusText;

	public TextMeshProUGUI connectedStatusPrivateText;

	public TextMeshProUGUI privateNetworkName;

	public TextMeshProUGUI[] firewallStatusText;

	public TextMeshProUGUI[] firewallStatusBlockText;

	public TextMeshProUGUI[] firewallStatusNotifyText;

	[Header("Checkboxy")]
	public GameObject SettingsFirewallView;

	public GameObject[] checkPrivateFirewall;

	public GameObject[] checkPublicFirewall;

	public GameObject[] checkBlockAllConnections;

	public GameObject[] checkNotify;

	[Header("Variables")]
	public bool privateFirewallEnabled;

	[Header("Variables")]
	public bool publicFirewallEnabled;

	public bool privateFirewallBlockAllConnections;

	public bool publicFirewallBlockAllConnections;

	public bool privateFirewallNotify;

	public bool publicFirewallNotify;

	[Header("Colors")]
	private string hexColorGreen;

	private string hexColorRed;

	private Color newColorGreen;

	private Color newColorRed;

	public void SetPaletteCollor()
	{
	}

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void RefreshMainView()
	{
	}

	public void OpenSettingsFirewall()
	{
	}

	public void SetPrivateFirewall(bool status)
	{
	}

	public void SetPublicFirewall(bool status)
	{
	}

	public void SetPrivateFirewallBlock()
	{
	}

	public void SetPublicFirewallBlock()
	{
	}

	public void SetPrivateNotify()
	{
	}

	public void SetPublicNotify()
	{
	}

	public void RefreshSettingsView()
	{
	}

	public void CloseSettingsFirewall()
	{
	}
}
