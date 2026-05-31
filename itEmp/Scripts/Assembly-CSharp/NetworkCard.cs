using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NetworkCard : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CIE_RestartDevice_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkCard _003C_003E4__this;

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
		public _003CIE_RestartDevice_003Ed__39(int _003C_003E1__state)
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

	[Header("Device Settings")]
	public string nameCard;

	[SerializeField]
	private string cardIP;

	[SerializeField]
	private string subnetMask;

	[SerializeField]
	private string gateway;

	public long timeChangeSettings;

	[Header("Network")]
	private bool isInternet;

	private bool isConnectedToRouter;

	public bool DHCP;

	[Header("Device Mode")]
	public bool validateNetworkSettings;

	public bool addressConflict;

	public bool deviceRestart;

	public bool devicePowerOn;

	public bool deviceSuspended;

	[Header("Device Type")]
	public NetworkCardDeviceType deviceType;

	[Header("My Socket")]
	public NetworkSocketRJ[] MySocketRJ;

	[Header("Port")]
	public UnityEngine.Object RJ45;

	public NetworkPort port;

	public string CardIP => null;

	public string SubnetMask => null;

	public string Gateway => null;

	public bool GetIsInternet => false;

	public bool GetIsConnectedToRouter => false;

	public void SetData(bool isInternet, bool isConnectedToRouter)
	{
	}

	protected override void PTSOnValidateInspector()
	{
	}

	protected override void PTSOnValidateFromMenu()
	{
	}

	public void GenerateNewDeviceIDAndMACAddress()
	{
	}

	[ContextMenu("Clear")]
	public void Clear()
	{
	}

	public void SetPowerDevice(bool mode)
	{
	}

	public void SetNetworkData(string ip, string subnetMask, string gateway, bool updateTime = true)
	{
	}

	public void RunAskDHCP(bool findConflictAddress)
	{
	}

	public NetworkStatus GetStatus()
	{
		return null;
	}

	public void RestartDevice()
	{
	}

	[IteratorStateMachine(typeof(_003CIE_RestartDevice_003Ed__39))]
	private IEnumerator IE_RestartDevice()
	{
		return null;
	}

	public bool DeviceIsAvaliable()
	{
		return false;
	}

	public void SetupComponent(UnityEngine.Object obj)
	{
	}

	public void DisconnectComputerFromPatchPanel()
	{
	}

	public void ConnectComputerToPatchPanel(NetworkSocketRJ networkSocket)
	{
	}
}
