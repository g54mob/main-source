using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ComputerVariables : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CcheckData_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ComputerVariables _003C_003E4__this;

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
		public _003CcheckData_003Ed__67(int _003C_003E1__state)
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

	public string nameDevice;

	public int userID;

	public string loginName;

	public string email;

	public int lengthPasswordType;

	public string howRunComputer;

	public string room;

	public bool firstRun;

	public int bootOptionStart;

	public bool systemIsInstall;

	public long sendbyte;

	public long receivedbyte;

	public bool isAdmin;

	public int monitorLighting;

	public bool sleepMode;

	public int sleepModeTimer;

	public int backgroundselectInMail;

	public bool balancedPowerOption;

	public bool enableFastStartSystem;

	public int timeout;

	public string identificator_system;

	public bool pciExpressNativePowerManagement;

	public bool nativeASPM;

	public bool hardwarePrefetcher;

	public bool adjacentCacheLinePrefetch;

	public int activePerformanceCorde;

	public int activeEfficiantCorde;

	public bool hyperThreading;

	public bool totalMemoryEncryption;

	public int bootPerformanceMode;

	public bool vtDsupported;

	public bool vtD;

	public bool controlIommuPreBootBehavior;

	public bool memoryRemap;

	public bool pcietunnelingoveripv4;

	public bool discreateThunderboltSupport;

	public bool securityDeviceSupport;

	public bool sha256PcrBank;

	public int pendingOperation;

	public bool platformHierarchy;

	public bool storageHierarchy;

	public bool endorsementHierarchy;

	public bool disableBlockSid;

	public bool above4GDecoding;

	public bool resizeBarSupport;

	public bool sriovSupport;

	public bool legacyUSBSupport;

	public int restoreACPowerLoss;

	public bool maxPowerSaving;

	public bool erPReady;

	public bool powerOnByPCIe;

	public bool powerOnByRTC;

	public int pcieBandwidthBifuracationConfiguration;

	public bool hdAudio;

	public bool frogLan;

	public bool usbPowerDeliveryInSoftOffState;

	public int m22Configuration;

	public bool gnaDevice;

	public bool fastBoot;

	public bool waitForF1IfError;

	public TextMeshProUGUI aboutPC;

	public ComputerNetwork computerNetwork;

	public Coroutine test;

	public bool stop;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetData()
	{
	}

	[IteratorStateMachine(typeof(_003CcheckData_003Ed__67))]
	private IEnumerator checkData()
	{
		return null;
	}
}
