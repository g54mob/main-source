using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkRouter : PTSMonoBehaviour
{
	private class returnPathCordData
	{
		public NetworkPatchPanel patchPanel;

		public int port;
	}

	[CompilerGenerated]
	private sealed class _003CBlinkDiode_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkRouter _003C_003E4__this;

		public int index;

		private Image _003Cdiode_003E5__2;

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
		public _003CBlinkDiode_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003CFadeAlert_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkRouter _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private Color _003CstartColor_003E5__3;

		private Color _003CendColor_003E5__4;

		private float _003Celapsed_003E5__5;

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
		public _003CFadeAlert_003Ed__81(int _003C_003E1__state)
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
	private sealed class _003CIE_RestartDevice_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkRouter _003C_003E4__this;

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
		public _003CIE_RestartDevice_003Ed__62(int _003C_003E1__state)
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

	public static NetworkRouter instance;

	[Header("Unique Device ID")]
	public string deviceID;

	public string MAC;

	[Header("Network")]
	public bool isConnectToNet;

	[Header("Web Session")]
	public string webSession;

	[Header("Device Settings")]
	public string routerName;

	public string routerIP;

	public string subnetMask;

	public string gateway;

	public long timeChangeSettings;

	public bool ipDomainLookup;

	public bool terminalHistory;

	public int sizeTerminalHistory;

	public string login;

	public string password;

	public DeviceDataTime deviceDataTime;

	[Header("LTE Settings")]
	public bool routerLTEWorking;

	public string routerLTEName;

	public string routerLTEIP;

	public string routerLTEsubnetMask;

	public string routerLTEmode;

	[Header("Operator Network")]
	public bool routerOperatorWorking;

	public string routerOperatorName;

	public string routerOperatorIP;

	public string routerOperatorsubnetMask;

	[Header("Device Default Settings")]
	public string defaultIP;

	public string defaultSubnetMask;

	public string defaultGateway;

	public bool defaultIpDomainLookup;

	public bool defaultTerminalHistory;

	public int defaultSizeTerminalHistory;

	public string defaultLogin;

	public string defaultPassword;

	[Header("Device Mode")]
	public bool validateNetworkSettings;

	public bool addressConflict;

	public bool deviceRestore;

	public bool deviceRestart;

	public bool deviceSuspended;

	[Header("Task Data")]
	public string taskDataRoom;

	[Header("Materials")]
	public Material materialSelectedPatchcord;

	public Material materialPatchcordYellow;

	public Material materialSelectedExistingPatchcord;

	public Material materialPatchcord;

	[Header("Ports")]
	public NetworkPort[] ports;

	public NetworkPortSettings[] portsSettings;

	[Header("PatchPanels")]
	public NetworkPatchPanel[] myPatchPanels;

	[Header("UI")]
	public Button buttonConnectPathcord;

	public Button buttonDisconnectPathcord;

	public TMP_Text alertUI;

	[Header("Audio Settings")]
	public AudioSource audioSource;

	public AudioClip clip;

	public float clipStartTime;

	private Coroutine currentCoroutineAlert;

	public Button routerButton;

	public Button patchpanelButton;

	public bool existingPatchcord;

	public int selectedPortRouter;

	public NetworkPatchPanel selectedPatchPanel;

	public int selectedPatchPanelPort;

	public float malyradius;

	private void Start()
	{
	}

	protected override void PTSOnValidateInspector()
	{
	}

	protected override void PTSOnValidateFromMenu()
	{
	}

	public void StartDiodeBlinking()
	{
	}

	[IteratorStateMachine(typeof(_003CBlinkDiode_003Ed__57))]
	private IEnumerator BlinkDiode(int index)
	{
		return null;
	}

	public void Close()
	{
	}

	public void ButtonRestoreFactorySettings()
	{
	}

	public void SetNewNetworkSettings(string _ip, string _subnetmask, string _gateway)
	{
	}

	public void RestartDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CIE_RestartDevice_003Ed__62))]
	private IEnumerator IE_RestartDevice()
	{
		return null;
	}

	public bool DeviceIsAvaliable()
	{
		return false;
	}

	public void UpdateUIAndPathcord()
	{
	}

	public void SelectRouterPort(Button button)
	{
	}

	private returnPathCordData switchIsConnectToPathpanel(int switchPort)
	{
		return null;
	}

	public void SelectRouterPathpanel(Button button)
	{
	}

	private int patchpanelIsConnectedToRouter(NetworkPatchPanel patchPanel, int patchpanelPort)
	{
		return 0;
	}

	public void UpdateUI()
	{
	}

	public void ConnectPathcord()
	{
	}

	public void DisconnectPathcord()
	{
	}

	public void SetAlert(string des)
	{
	}

	[IteratorStateMachine(typeof(_003CFadeAlert_003Ed__81))]
	private IEnumerator FadeAlert()
	{
		return null;
	}

	public void AssignAddressToDevices()
	{
	}

	public void DisabledPort(int idPort)
	{
	}

	public void EnabledPort(int idPort)
	{
	}

	public void ConnectSwitchToPatchpanel(int switchPort, NetworkPatchPanel patchPanel, int patchPanelPort)
	{
	}

	public void DisconnectSwitchToPatchpanel(int switchPort, NetworkPatchPanel patchPanel, int patchPanelPort)
	{
	}
}
