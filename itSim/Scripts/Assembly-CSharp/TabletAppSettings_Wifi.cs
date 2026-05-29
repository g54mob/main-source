using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppSettings_Wifi : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAirplaneModeCoroutine_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool closedNow;

		public TabletAppSettings_Wifi _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003CAirplaneModeCoroutine_003Ed__18(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimCloseConnectionWindow_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppSettings_Wifi _003C_003E4__this;

		private float _003CdurationUI_003E5__2;

		private float _003CdurationBackground_003E5__3;

		private float _003CdelayAfterUI_003E5__4;

		private Vector2 _003CstartPos_003E5__5;

		private Vector2 _003CendPos_003E5__6;

		private float _003CstartAlpha_003E5__7;

		private float _003CendAlpha_003E5__8;

		private Color _003CstartColor_003E5__9;

		private Color _003CendColor_003E5__10;

		private float _003Ctime_003E5__11;

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
		public _003CAnimCloseConnectionWindow_003Ed__44(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimCloseInfoWindow_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppSettings_Wifi _003C_003E4__this;

		private float _003CdurationUI_003E5__2;

		private float _003CdurationBackground_003E5__3;

		private float _003CdelayAfterUI_003E5__4;

		private Vector2 _003CstartPos_003E5__5;

		private Vector2 _003CendPos_003E5__6;

		private float _003CstartAlpha_003E5__7;

		private float _003CendAlpha_003E5__8;

		private Color _003CstartColor_003E5__9;

		private Color _003CendColor_003E5__10;

		private float _003Ctime_003E5__11;

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
		public _003CAnimCloseInfoWindow_003Ed__59(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimOpenConnectionWindow_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppSettings_Wifi _003C_003E4__this;

		public DevicesAccessPoint accessPoint;

		private bool _003CisRemembered_003E5__2;

		private float _003CdurationBackground_003E5__3;

		private float _003CdurationUI_003E5__4;

		private float _003CdelayBeforeUI_003E5__5;

		private Color _003CstartColor_003E5__6;

		private Color _003CendColor_003E5__7;

		private Vector2 _003CstartPos_003E5__8;

		private Vector2 _003CendPos_003E5__9;

		private float _003Ctime_003E5__10;

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
		public _003CAnimOpenConnectionWindow_003Ed__42(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CAnimOpenInfoWindow_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppSettings_Wifi _003C_003E4__this;

		public DevicesAccessPoint accessPoint;

		private float _003CdurationBackground_003E5__2;

		private float _003CdurationUI_003E5__3;

		private float _003CdelayBeforeUI_003E5__4;

		private Color _003CstartColor_003E5__5;

		private Color _003CendColor_003E5__6;

		private Vector2 _003CstartPos_003E5__7;

		private Vector2 _003CendPos_003E5__8;

		private float _003Ctime_003E5__9;

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
		public _003CAnimOpenInfoWindow_003Ed__57(int _003C_003E1__state)
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
	public TabletAppSettings settings;

	public TabletDeviceWiFiAdapter tabletDeviceWiFiAdapter;

	public RectTransform This_Settings;

	public GameObject This_Settings_View;

	[Header("UI")]
	public Image bgDotWiFIEnableMode;

	public RectTransform dotWiFiEnableMode;

	public RectTransform CurrentWiFIWindow;

	public RectTransform OtherWiFIWindow;

	public RectTransform conectedWiFiElementList;

	public TMP_Text conectedWiFiElementListName;

	[HideInInspector]
	public bool WiFiStatusEnableMode;

	[HideInInspector]
	public bool isCoroutineEnded;

	[HideInInspector]
	public Coroutine turnonofWiFIEnableCoroutine;

	public RectTransform otherWiFiParent;

	public RectTransform otherWiFiAdapter;

	public List<TabletAppSettingsWiFiNetworksData> listWiFi;

	public Image ConnectWiFiBackground;

	public CanvasGroup ConnectWiFiWindowAlpha;

	public RectTransform ConnectWiFiWindowRect;

	public TMP_Text ConnectWiFiWindow_SSID;

	public RectTransform ConnectWiFiWindow_FailedAlert;

	public RectTransform ConnectWiFiWindow_Login;

	public TMP_Dropdown ConnectWiFiWindow_DropdownEAP;

	public TMP_Dropdown ConnectWiFiWindow_DropdownAuthentication;

	public RectTransform[] ConnectWiFiWindow_Authentication;

	public RectTransform UIShowAdvancedOptions;

	public RectTransform UIHideAdvancedOptions;

	public RectTransform ConnectWiFiWindow_Advanced;

	public TMP_InputField ConnectWiFiWindow_user;

	public TMP_InputField ConnectWiFiWindow_password;

	public TMP_InputField ConnectWiFiWindow_PACWebAddress;

	public bool isAnimation;

	private DevicesAccessPoint devicesAccessPoint;

	public int NowSelectedEAP;

	public int NowSelectedAuthentication;

	public Image InfoWiFiBackground;

	public CanvasGroup InfoWiFiWindowAlpha;

	public RectTransform InfoWiFiWindowRect;

	public TMP_Text InfoWiFiWindow_SSID;

	public DevicesAccessPoint InfoAccessPoint;

	public bool isInfoAnimation;

	private void Start()
	{
	}

	private void SetDefaultWiFiAtON()
	{
	}

	public void OpenThisView()
	{
	}

	public void CloseThisView()
	{
	}

	public void TurnOnOrOffWiFiEnabledMode()
	{
	}

	[IteratorStateMachine(typeof(_003CAirplaneModeCoroutine_003Ed__18))]
	public IEnumerator AirplaneModeCoroutine(RectTransform obj, float fromX, float toX, float time, bool closedNow = false)
	{
		return null;
	}

	public void RefreshOtherWiFiList()
	{
	}

	public void RefreshCurrentWiFi()
	{
	}

	private bool isRememberedWiFi(string ssid)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CAnimOpenConnectionWindow_003Ed__42))]
	public IEnumerator AnimOpenConnectionWindow(DevicesAccessPoint accessPoint)
	{
		return null;
	}

	public void CloseConnectionWindowBackground()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimCloseConnectionWindow_003Ed__44))]
	public IEnumerator AnimCloseConnectionWindow()
	{
		return null;
	}

	public void ConnectionWindowDropdown_EAP(int value)
	{
	}

	public void ConnectionWindowDropdown_Authentication(int value)
	{
	}

	private void RefreshUI()
	{
	}

	public void ButtonConnect()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimOpenInfoWindow_003Ed__57))]
	public IEnumerator AnimOpenInfoWindow(DevicesAccessPoint accessPoint)
	{
		return null;
	}

	public void CloseInfoWindowBackground()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimCloseInfoWindow_003Ed__59))]
	public IEnumerator AnimCloseInfoWindow()
	{
		return null;
	}

	public void ButtonForgetThisNetwork()
	{
	}
}
