using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IceCreamHelper : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CDoWork_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IceCreamHelper _003C_003E4__this;

		private IceCreamRequest _003Crequest_003E5__2;

		private IceCreamFlavour _003Cflavour_003E5__3;

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
		public _003CDoWork_003Ed__37(int _003C_003E1__state)
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

	private IceCreamStand m_BoundStand;

	private Coroutine m_WorkCoroutine;

	private bool m_IsWorking;

	private IceCreamCone m_Cone;

	private Customer m_CurrentCustomer;

	[SerializeField]
	private IceCreamCone[] m_ConePrefabs;

	[SerializeField]
	private Transform m_ConeContainer;

	private NetworkIceCreamHelper m_NetworkHelper;

	[SerializeField]
	private IceCreamHelperAnimationController m_AnimationController;

	private float m_LastSpeechSpawnTime;

	private const float k_SpeechSpawnInterval = 20f;

	[Header("Boost")]
	[SerializeField]
	private BoostIndicator m_BoostIndicator;

	[SerializeField]
	private float m_BoostAmount;

	[SerializeField]
	private float m_BoostCost;

	private int m_CurrentBoostLevel;

	private readonly List<float> m_PerActionIntervals;

	private List<float> m_HelperAnimationSpeeds;

	private float m_CurrentActionDelayInterval;

	public int ID { get; set; }

	public BoostIndicator BoostIndicator => null;

	public NetworkIceCreamHelper NetworkHelper => null;

	public GameObject CurrentSpeechObject { get; set; }

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	private void Start()
	{
	}

	public void AssignStand(IceCreamStand stand)
	{
	}

	public void Unassign()
	{
	}

	public void StartWork()
	{
	}

	public void EndWork()
	{
	}

	private void OnQueueUpdated()
	{
	}

	private IceCreamFlavour GetUnmetFlavour(IceCreamRequest request)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDoWork_003Ed__37))]
	private IEnumerator DoWork()
	{
		return null;
	}

	public void DestroyCone()
	{
	}

	public void CreateCone(int coneId)
	{
	}

	public void ResetWork()
	{
	}

	public void AddFlavour(IceCreamFlavour flavour)
	{
	}

	public void AddTopping(IceCreamTopping topping)
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public void BoostHelper_Order()
	{
	}

	public void SetBoostHelperNetwork(float m_BoostAmount)
	{
	}

	private void SetHelperBoost(int boostLevel)
	{
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}
}
