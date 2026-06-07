using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Web_rcp : MonoBehaviour
{
	[Header("Components")]
	public AppBrowser appBrowser;

	public SimpleRCP rcp;

	[Header("UI")]
	public RectTransform website_UI;

	public RectTransform website_NoInternet;

	public RectTransform loginSite;

	public RectTransform mainSite;

	public TMP_InputField loginField;

	public TMP_InputField passwordField;

	public TMP_Text alertIncorrectLoginPassword;

	[Header("Not private")]
	public GameObject viewNetErrCert;

	public GameObject secoundButton;

	public TextMeshProUGUI buttonAdvancedNotPrivate;

	[Header("Menu")]
	public SwitchPages[] menuPages;

	[Header("Device")]
	public NetworkCard openDevice;

	private string login;

	private string password;

	public string startURL;

	public string session;

	public UrlData urlData;

	[Header("Administration")]
	public Image administration_reboot;

	public Image administration_rebootAlpha;

	[Header("Host")]
	public TMP_InputField host_ipAddress;

	public TMP_InputField host_port;

	public TMP_InputField host_groupID;

	public TMP_InputField host_deviceID;

	public GameObject host_checkboxEnabledEncryption;

	public GameObject host_checkboxEnabledHostRegistration;

	[Header("Date and Time")]
	public TextMeshProUGUI dateAndTime_CurrentTime;

	public GameObject dateAndTime_checkboxUseLocalTime;

	[Header("Display")]
	public TMP_InputField display_ReducedBrightnessTimeout;

	public TMP_InputField display_StandbyTimeout;

	public TMP_InputField display_ReaderIlluminationPulseFrequency;

	public GameObject display_checkboxStandbyTimeout;

	[Header("User Management")]
	public GameObject userManagment_notify;

	private string hexColorBlue;

	private string hexColorBlueAlpha;

	private string hexColorGray;

	private string hexColorGrayAlpha;

	private Color newColorBlue;

	private Color newColorBlueAlpha;

	private Color newColorGray;

	private Color newColorGrayAlpha;

	public string Login { get; set; }

	public string Password { get; set; }

	public string HexColorBlue { get; set; }

	public string HexColorBlueAlpha { get; set; }

	public string HexColorGray { get; set; }

	public string HexColorGrayAlpha { get; set; }

	private void Start()
	{
	}

	public void Update()
	{
	}

	public void TabSelectable()
	{
	}

	public void OpenWebsite(string address, string inputURL, Object device)
	{
	}

	public void CloseWebsite()
	{
	}

	public bool CheckConnectionComputerToSwitch()
	{
		return false;
	}

	public void OpenLoginHTML(UrlData urlData)
	{
	}

	public void OpenIndexHTML(UrlData urlData)
	{
	}

	public void OpenLoginPHP(UrlData urlData)
	{
	}

	public void ButtonLogin()
	{
	}

	public void Logout()
	{
	}

	public void OpenLoginSite()
	{
	}

	public void OpenMainPage(UrlData urlData)
	{
	}

	public void ButtonOpenListMenu(string page)
	{
	}

	public void OpenAdministration()
	{
	}

	public void Administration_RebootRCP()
	{
	}

	public void OpenHost()
	{
	}

	public void Host_HostIPAddress()
	{
	}

	public void Host_HostPort()
	{
	}

	public void Host_GroupID()
	{
	}

	public void Host_DeviceID()
	{
	}

	public void HostChangeBoolEnabledEncryption()
	{
	}

	public void HostChangeBoolEnabledHostRegistration()
	{
	}

	public void OpenDateAndTime()
	{
	}

	public void DateAndTime_ChangeBoolUseLocalTime()
	{
	}

	public void OpenDisplay()
	{
	}

	public void Display_ChangeReducedBrightnessTimeout()
	{
	}

	public void Display_ChangeStandbyTimeout()
	{
	}

	public void Display_ChangeReaderIlluminationPulseFrequency()
	{
	}

	public void DisplayChangeBoolStandbyTimeout()
	{
	}

	public void NotSaftyConnected()
	{
	}

	public void ShowAdvancedNotSafty()
	{
	}

	public void ShowNotSaftySide()
	{
	}

	public void OpenUserManagement()
	{
	}

	public void ChangePassword()
	{
	}
}
