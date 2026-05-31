using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NetworkAccessPoint : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CIE_RestartDevice_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkAccessPoint _003C_003E4__this;

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
		public _003CIE_RestartDevice_003Ed__30(int _003C_003E1__state)
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

	[Header("Unique Device ID")]
	public string deviceID;

	public string MAC;

	[Header("Web Session")]
	public string webSession;

	[Header("Device Settings")]
	public string accessPointName;

	public string accessPointIP;

	public string subnetMask;

	public string gateway;

	public long timeChangeSettings;

	public string loginDevice;

	public string passwordDevice;

	public DeviceDataTime deviceDataTime;

	[Header("Device Default Settings")]
	public string defaultIP;

	public string defaultSubnetMask;

	public string defaultGateway;

	[Header("Device Mode")]
	public bool validateNetworkSettings;

	public bool addressConflict;

	public bool deviceRestart;

	public bool deviceSuspended;

	[Header("Materials")]
	public Material materialSelectedPatchcord;

	public Material materialPatchcordYellow;

	public Material materialSelectedExistingPatchcord;

	public Material materialPatchcord;

	[Header("Ports")]
	public NetworkPort[] ports;

	[Header("Sockets")]
	public NetworkSocketRJ[] mySocket;

	[Header("WiFi Settings")]
	public float WiFiDistance;

	public string ssid;

	public string user;

	public string password;

	private void OnValidate()
	{
	}

	public void RestartDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CIE_RestartDevice_003Ed__30))]
	private IEnumerator IE_RestartDevice()
	{
		return null;
	}

	public bool DeviceIsAvaliable()
	{
		return false;
	}

	public void DisconnectAccessPointFromSocket(int accessPointPort)
	{
	}

	public void ConnectAccessPointToSocket(int accessPointPort, NetworkSocketRJ networkSocket)
	{
	}
}
