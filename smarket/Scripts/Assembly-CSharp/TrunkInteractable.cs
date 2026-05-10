using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TrunkInteractable : MonoBehaviour, IInteractable
{
	[CompilerGenerated]
	private sealed class _003CResetInteractionDelayed_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TrunkInteractable _003C_003E4__this;

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
		public _003CResetInteractionDelayed_003Ed__43(int _003C_003E1__state)
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

	private static Collider[] m_OverlapCache;

	[SerializeField]
	private Vector3 m_StartEulerAngles;

	[SerializeField]
	private Vector3 m_TargetEulerAngles;

	private bool m_State;

	[SerializeField]
	private Collider m_BoundCollider;

	[SerializeField]
	private VehicleInteract m_VehicleInteract;

	[SerializeField]
	private bool m_ApplyStuckFix;

	[SerializeField]
	private Vector3 m_ShakeAxis;

	[SerializeField]
	private bool m_AllowClosingIfOccupied;

	[SerializeField]
	private Collider m_TrunkCloseCheckCollider;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction { get; }

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair { get; set; }

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool State
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Awake()
	{
	}

	public bool InstantInteract()
	{
		return false;
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

	private void Toggle()
	{
	}

	public void Toggle_Network(bool isOpen)
	{
	}

	private void PlayInvalidClose()
	{
	}

	private bool CheckIfAreaValidToClose()
	{
		return false;
	}

	private void TryPush()
	{
	}

	[IteratorStateMachine(typeof(_003CResetInteractionDelayed_003Ed__43))]
	private IEnumerator ResetInteractionDelayed()
	{
		return null;
	}
}
