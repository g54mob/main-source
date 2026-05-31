using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Web_router : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CUpdateDataTime_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Web_router _003C_003E4__this;

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
		public _003CUpdateDataTime_003Ed__73(int _003C_003E1__state)
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

	[Header("Home")]
	public TextMeshProUGUI homeOperatorText;

	public TextMeshProUGUI homeLanIP;

	public TextMeshProUGUI homeLanMask;

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

	public Toggle Ports_ActiveEnable;

	public TMP_InputField Ports_IpAddress;

	public TMP_InputField Ports_Subnetmask;

	public TMP_Text Ports_Name;

	public RectTransform Ports_ButtonApply;

	[Header("Serurity UI")]
	public TMP_InputField Security_CurrentLogin;

	public TMP_InputField Security_NewLogin;

	public TMP_InputField Security_CurrentPassword;

	public TMP_InputField Security_NewPassword;

	public TMP_InputField Security_ConfirmNewPassword;

	public RectTransform Security_ButtonSave;

	public TMP_Text Security_LoginAlert;

	public GameObject Security_LoginAlertObjet;

	public TMP_Text Security_LoginSuccessAlert;

	public GameObject Security_LoginSuccessAlertObjet;

	public TMP_Text Security_PasswordAlert;

	public GameObject Security_PasswordAlertObjet;

	public TMP_Text Security_PasswordSuccessAlert;

	public GameObject Security_PasswordSuccessAlertObjet;

	[Header("Reports")]
	public GameObject Reports_irregularities_BFD;

	public TextMeshProUGUI Reports_Data;

	public TextMeshProUGUI Reports_BFD_Sessions;

	public TextMeshProUGUI[] Reports_IF_Status;

	public TextMeshProUGUI[] Reports_IF_IP_address;

	public TextMeshProUGUI[] Reports_IF_mask;

	public TextMeshProUGUI[] Reports_IF_rx;

	public TextMeshProUGUI[] Reports_IF_tx;

	public TextMeshProUGUI Reports_LTE_mode;

	public TextMeshProUGUI Reports_LTE_RSSI;

	public TextMeshProUGUI Reports_LTE_RSRP;

	public TextMeshProUGUI Reports_LTE_RSRQ;

	[HideInInspector]
	public int bfdCounter;

	[Header("Menu")]
	public SwitchPages[] menuPages;

	[Header("Device")]
	public NetworkRouter openDevice;

	public string startURL;

	public string session;

	public UrlData urlData;

	private Coroutine CoroutineUpdateDataTime;

	private NetworkPortSettings openPort;

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

	public bool CheckConnectionComputerToRouter()
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

	public void RefreshSetupOption()
	{
	}

	private void UpdateSetupUI(bool value)
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateDataTime_003Ed__73))]
	private IEnumerator UpdateDataTime()
	{
		return null;
	}

	public void RefreshPortsList()
	{
	}

	public void OpenPortSettings(int port)
	{
	}

	private void UpdatePortUI(NetworkPortSettings port)
	{
	}

	public void PortApply()
	{
	}

	private void EditPort(NetworkPortSettings networkPortSettings)
	{
	}

	public void RefreshMainView()
	{
	}

	public void RefreshReports()
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
