using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Web_switch : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CUpdateDataTime_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Web_switch _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CUpdateDataTime_003Ed__60(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Components")]
	public AppBrowser appBrowser;

	[Header("UI")]
	public RectTransform website_UI;

	public RectTransform website_NoInternet;

	public RectTransform loginSite;

	public RectTransform mainSite;

	public TMP_InputField loginField;

	public TMP_InputField passwordField;

	public TMP_Text alertIncorrectLoginPassword;

	[Header("Lan UI")]
	public TMP_Text LanIpText;

	public TMP_Text LanSubnetmaskText;

	[Header("DHCP UI")]
	public Toggle DHCP_Enable;

	public RectTransform DCHP_ClientListParent;

	public RectTransform DCHP_ClientListPrefabs;

	public TMP_Text DHCP_AddressFirstOctets;

	public TMP_InputField DHCP_StartAddress;

	public TMP_InputField DHCP_EndAddress;

	public Button DHCP_ApplyButton;

	[Header("Setup UI")]
	public TMP_InputField Setup_Date;

	public TMP_InputField Setup_Time;

	public Toggle Setup_IpDomainLookupEnable;

	public Toggle Setup_TerminalHistoryEnable;

	public TMP_InputField Setup_SizeTerminalHistory;

	public RectTransform Setup_TerminalHistoryList;

	[Header("Ports UI")]
	public RectTransform Ports_ClientListParent;

	public RectTransform Ports_ClientListPrefabs;

	[Header("Serurity UI")]
	public TMP_InputField Security_CurrentLogin;

	public TMP_InputField Security_NewLogin;

	public TMP_InputField Security_CurrentPassword;

	public TMP_InputField Security_NewPassword;

	public TMP_InputField Security_ConfirmNewPassword;

	public RectTransform Security_ButtonSave;

	public TMP_Text Security_LoginAlert;

	public TMP_Text Security_PasswordAlert;

	[Header("Menu")]
	public SwitchPages[] menuPages;

	[Header("Device")]
	public NetworkSwitch openDevice;

	public string startURL;

	public string session;

	public UrlData urlData;

	private Coroutine CoroutineUpdateDataTime;

	private void Start()
	{
	}

	public void Update()
	{
	}

	public void TabSelectable()
	{
	}

	public void OpenWebsite(string address, string inputURL, UnityEngine.Object device)
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

	public void RefreshLanOption()
	{
	}

	public void RefreshClientListDHCP()
	{
	}

	private void CheckFieldLengthAndValue(TMP_InputField inputField)
	{
	}

	public void ButtonChangeDHCPPool()
	{
	}

	private void UpdateDHCPAdressPool(int mode)
	{
	}

	private TMP_InputField[] CombineInputFields()
	{
		return null;
	}

	public void RefreshSetupOption()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateDataTime_003Ed__60))]
	private IEnumerator UpdateDataTime()
	{
		return null;
	}

	private void UpdateSetupUI(bool value)
	{
	}

	public void RefreshClientListPorts()
	{
	}

	public void RefreshSecurityUI()
	{
	}

	public void SecuritySubscribeInputFields(TMP_InputField inputField)
	{
	}

	public void SecurityUpdateFields()
	{
	}

	public void SecurityButtonApply()
	{
	}
}
