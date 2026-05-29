using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TabletDeviceWiFiAdapter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEnumInstantRefreshWiFi_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletDeviceWiFiAdapter _003C_003E4__this;

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
		public _003CEnumInstantRefreshWiFi_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003CRefreshDevices_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletDeviceWiFiAdapter _003C_003E4__this;

		private DevicesAccessPoint _003CclosestRememberedAP_003E5__2;

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
		public _003CRefreshDevices_003Ed__16(int _003C_003E1__state)
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

	public static TabletDeviceWiFiAdapter Instance;

	[Header("Components")]
	public TabletAppSettings_Wifi tabletAppSettings_Wifi;

	public TabletAppSettings tabletAppSettings;

	[Header("WiFi")]
	public List<DevicesAccessPoint> accessPoints;

	public List<RememberedNetwork> rememberedNetworks;

	public float refreshInterval;

	private PlayerManager playerManager;

	private NetworkManager networkManager;

	public DevicesAccessPoint currentConnectedAP;

	[Header("UI")]
	public Image wifiIconBar;

	public Sprite[] wifiIcons;

	public Coroutine coroutineRefreshDevices;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void InstantRefreshWiFi()
	{
	}

	[IteratorStateMachine(typeof(_003CEnumInstantRefreshWiFi_003Ed__15))]
	private IEnumerator EnumInstantRefreshWiFi()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRefreshDevices_003Ed__16))]
	private IEnumerator RefreshDevices()
	{
		return null;
	}

	public float GetNetwork()
	{
		return 0f;
	}

	private void ConnectToAccessPoint(DevicesAccessPoint ap)
	{
	}

	private void DisconnectFromAccessPoint()
	{
	}

	private float CalculateSignalPower(float distance, float wifiDistance)
	{
		return 0f;
	}

	public string RememberedNetworksToJson()
	{
		return null;
	}

	public void JsonToRememberedNetworks(string json)
	{
	}
}
