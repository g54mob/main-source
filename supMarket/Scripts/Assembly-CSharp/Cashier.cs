using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Cashier : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CMoveTo_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 target;

		public Cashier _003C_003E4__this;

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
		public _003CMoveTo_003Ed__56(int _003C_003E1__state)
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

	private const float m_RotationSmoothness = 5f;

	private const float m_RotatingTime = 0.3f;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private CashierAnimationController m_Animation;

	[SerializeField]
	private Animator m_Animator;

	[SerializeField]
	private BoostIndicator m_BoostIndicator;

	[SerializeField]
	private float m_BoostAmount;

	[SerializeField]
	private float m_BoostCost;

	private int m_CashierID;

	private int m_CurrentBoostLevel;

	private List<float> m_CashierScanIntervals;

	private List<float> m_CashierAnimationSpeeds;

	private List<float> m_CashierWalkingSpeeds;

	private NetworkCashier m_NetworkCashier;

	public ScanAnimationHandler ScanStateMachine;

	public float ScanningInterval;

	public int CashierID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float CurrentScanSpeed => 0f;

	public BoostIndicator BoostIndicator => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public NetworkCashier NetworkCashier => null;

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Start()
	{
	}

	public void ManualUpdate()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public void BoostCashier_Order()
	{
	}

	public void SetBoostCashierNetwork(float m_BoostAmount)
	{
	}

	public bool HasEnoughMoneyForBoost()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	private void SetCashierBoost(int boostLevel)
	{
	}

	public void StartHelping(Vector3 targetDestination)
	{
	}

	public void StopHelping()
	{
	}

	[IteratorStateMachine(typeof(_003CMoveTo_003Ed__56))]
	private IEnumerator MoveTo(Vector3 target)
	{
		return null;
	}

	public void ScanAnimation()
	{
	}

	public void TakePaymentAnimation()
	{
	}
}
