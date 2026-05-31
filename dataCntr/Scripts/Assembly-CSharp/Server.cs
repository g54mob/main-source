using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Server : UsableObject
{
	[CompilerGenerated]
	private sealed class _003CBrekingInProgress_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Server _003C_003E4__this;

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
		public _003CBrekingInProgress_003Ed__45(int _003C_003E1__state)
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
	private TextMeshProUGUI txtIP;

	[SerializeField]
	private TextMeshProUGUI txtServerScreen;

	public float maxProcessingSpeed;

	public float currentProcessingSpeed;

	private float previousProcessingSpeed;

	private List<CableLink> activeLinks;

	public CableLink[] cablelinks;

	public string ServerID;

	public int appID;

	public string IP;

	public int serverType;

	public int currentEOLTime;

	public int defaultEOLTime;

	public bool isBroken;

	private int existingWarningSigns;

	private int existingErrorSigns;

	[SerializeField]
	private Image customerLogo;

	[SerializeField]
	private Image appLogo;

	public bool isOn;

	[SerializeField]
	private Renderer powerButton;

	private Coroutine breakingRoutine;

	private bool hasInitialized;

	public override void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnLoadingStarted()
	{
	}

	private void OnLoadingComplete()
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

	public void ServerInsertedInRack(ServerSaveData serverSaveData = null)
	{
	}

	public void RegisterLink(CableLink link)
	{
	}

	public void UnregisterLink(CableLink link)
	{
	}

	private void UpdateLinkSpeeds()
	{
	}

	private void UpdateServerScreenUI()
	{
	}

	public void ButtonClickChangeCustomer(bool forward)
	{
	}

	private int GetNextCustomerID(int currentCustomerID, bool forward)
	{
		return 0;
	}

	public void ButtonClickChangeIP()
	{
	}

	public void SetIP(string _ip)
	{
	}

	public int GetCustomerID()
	{
		return 0;
	}

	public void UpdateCustomer(int newCustomerID)
	{
	}

	public void UpdateAppID(int _appID)
	{
	}

	[IteratorStateMachine(typeof(_003CBrekingInProgress_003Ed__45))]
	private IEnumerator BrekingInProgress()
	{
		return null;
	}

	private void ItIsBroken()
	{
	}

	public bool ValidateRackPosition()
	{
		return false;
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
