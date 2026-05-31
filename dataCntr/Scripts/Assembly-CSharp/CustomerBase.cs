using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomerBase : MonoBehaviour
{
	private class AppConnectionInfo
	{
		public int AppID;

		public float CurrentSpeed;
	}

	[CompilerGenerated]
	private sealed class _003CCheckIfAppRequirementsAreMet_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomerBase _003C_003E4__this;

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
		public _003CCheckIfAppRequirementsAreMet_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CDelayedAppDoorOpening_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomerBase _003C_003E4__this;

		public int appID;

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
		public _003CDelayedAppDoorOpening_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003CUpdateMoney_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomerBase _003C_003E4__this;

		private WaitForSeconds _003Cwait1s_003E5__2;

		private float _003CtargetXP_003E5__3;

		private float _003CtargetReputation_003E5__4;

		private float _003CmoneyBufferForXP_003E5__5;

		private float _003CmoneyBufferForReputation_003E5__6;

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
		public _003CUpdateMoney_003Ed__33(int _003C_003E1__state)
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

	public int customerBaseID;

	public int customerID;

	[SerializeField]
	private Image customerLogo;

	public CustomerItem customerItem;

	[SerializeField]
	private TextMeshProUGUI txtNumberOfServers;

	[SerializeField]
	private TextMeshProUGUI[] txtApps;

	[SerializeField]
	private TextMeshProUGUI[] txtAppsTimeInfo;

	[SerializeField]
	private Image[] appsTypes;

	[SerializeField]
	private Image[] appsLogos;

	[SerializeField]
	private float[] appsSpeedRequirements;

	[SerializeField]
	private float[] appsSpeedCurrent;

	[SerializeField]
	private TextMeshProUGUI txtCurrentSpeed;

	private Dictionary<int, string[]> usableIpsPerApp;

	private Dictionary<int, string> subnetsPerApp;

	private Dictionary<int, int> appIdToServerType;

	[SerializeField]
	private CableLink[] cableLinks;

	public float currentSpeed;

	[SerializeField]
	private int howLongToWaitBeforeFine;

	public Dictionary<int, int> appObjectiveIDs;

	public int[] appsTimeBelowRequirements;

	public bool[] appReputationAwarded;

	private MeshRenderer meshRenderer;

	private float currentTotalAppSpeeRequirements;

	private float maximumAppRequirementsSpeedTotal;

	public Animator customerBaseAnimator;

	public AudioSource audioSource;

	public AudioClip audioClipBaseOpen;

	public AudioClip audioClipAppOpen;

	private List<AppConnectionInfo> appConnections;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CCheckIfAppRequirementsAreMet_003Ed__32))]
	private IEnumerator CheckIfAppRequirementsAreMet()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CUpdateMoney_003Ed__33))]
	private IEnumerator UpdateMoney()
	{
		return null;
	}

	private bool AreAllAppRequirementsMet()
	{
		return false;
	}

	public void UpdateCustomerServerCountAndSpeed(int count, float speed)
	{
	}

	public void AddAppPerformance(int appID, float speed)
	{
	}

	public void ResetAllAppSpeeds()
	{
	}

	public bool IsIPPresent(string ip)
	{
		return false;
	}

	public int GetAppIDForIP(string ip)
	{
		return 0;
	}

	public void SetUpBase(CustomerItem customerItem, CustomerBaseSaveData saveData = null)
	{
	}

	private void SetUpApp(int appID, int difficulty, CustomerBaseSaveData saveData = null)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedAppDoorOpening_003Ed__42))]
	private IEnumerator DelayedAppDoorOpening(int appID)
	{
		return null;
	}

	private string AppText(int lastUsedApp)
	{
		return null;
	}

	private string AppText(int appID, string subnet)
	{
		return null;
	}

	private void UpdateSpeedOnCustomerBaseApp(int appID, float speed)
	{
	}

	public float[] GetAppsSpeedRequirements()
	{
		return null;
	}

	public Dictionary<int, string> GetSubnetsPerApp()
	{
		return null;
	}

	public int GetServerTypeForIP(string ip)
	{
		return 0;
	}

	public void LoadData(CustomerBaseSaveData data)
	{
	}
}
