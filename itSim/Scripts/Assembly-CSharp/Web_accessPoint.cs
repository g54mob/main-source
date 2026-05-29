using TMPro;
using UnityEngine;

public class Web_accessPoint : MonoBehaviour
{
	[Header("Components")]
	public AppBrowser appBrowser;

	[Header("UI")]
	public RectTransform website_UI;

	public RectTransform website_NoInternet;

	public RectTransform loginSite;

	public RectTransform mainSite;

	public TMP_InputField Lan_ip;

	public TMP_InputField loginField;

	public TMP_InputField passwordField;

	public TMP_Text alertIncorrectLoginPassword;

	[Header("Menu")]
	public SwitchPages[] menuPages;

	[Header("Device")]
	public NetworkAccessPoint openDevice;

	public string startURL;

	public string session;

	public UrlData urlData;

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
}
