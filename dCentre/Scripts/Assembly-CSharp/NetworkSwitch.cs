using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class NetworkSwitch : UsableObject
{
	[CompilerGenerated]
	private sealed class _003CBrekingInProgress_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkSwitch _003C_003E4__this;

		private WaitForSeconds _003Cwait1s_003E5__2;

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
		public _003CBrekingInProgress_003Ed__27(int _003C_003E1__state)
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

	[SerializeField]
	private GameObject canvas;

	[SerializeField]
	private TextMeshProUGUI txtScreen;

	private CableLink[] cableLinkSwitchPorts;

	private string switchId;

	public int switchType;

	public bool isOn;

	public string label;

	public int currentEOLTime;

	public int defaultEOLTime;

	public bool isBroken;

	private int existingWarningSigns;

	private int existingErrorSigns;

	[SerializeField]
	private Renderer powerButton;

	private List<(int cableId, (string startDevice, string endDevice) connection)> temporarilyDisconnectedCables;

	private Coroutine breakingRoutine;

	public override void Awake()
	{
	}

	public void PowerButton(bool forceState = false)
	{
	}

	private void TurnOffCommonFunctions()
	{
	}

	private void TurnOnCommonFunction()
	{
	}

	public bool IsAnyCableConnected()
	{
		return false;
	}

	public override void InteractOnClick()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public void SwitchInsertedInRack(SwitchSaveData switchSaveData = null)
	{
	}

	public void DisconnectCablesWhenSwitchIsOff()
	{
	}

	public void HandleNewCableWhileOff(int cableId)
	{
	}

	public List<(string, int)> GetConnectedDevices()
	{
		return null;
	}

	public string GetSwitchId()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CBrekingInProgress_003Ed__27))]
	private IEnumerator BrekingInProgress()
	{
		return null;
	}

	private void UpdateScreenUI()
	{
	}

	private void ItIsBroken()
	{
	}

	private void DisconnectCables()
	{
	}

	private void ReconnectCables()
	{
	}

	public bool ValidateRackPosition()
	{
		return false;
	}

	public void ButtonShowNetworkSwitchConfig()
	{
	}

	public void ClearWarningSign()
	{
	}

	public override void OnDestroy()
	{
	}

	private void SetPowerLightMaterial(Material material)
	{
	}
}
