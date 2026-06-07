using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Civil;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
	[CompilerGenerated]
	private sealed class _003CMoveTo_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NPC _003C_003E4__this;

		public bool isVending;

		public Vector3 target;

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
		public _003CMoveTo_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003CRestartAgent_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NPC _003C_003E4__this;

		private Vector3 _003ColdPosition_003E5__2;

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
		public _003CRestartAgent_003Ed__29(int _003C_003E1__state)
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

	private static readonly int SpeedHash;

	public bool IsInRestaurant;

	private const float m_RotationSmoothness = 5f;

	[SerializeField]
	private Animator m_Animator;

	[SerializeField]
	private NPCAnimator m_NPCAnimator;

	[SerializeField]
	private NavMeshAgent m_Agent;

	[SerializeField]
	private Transform m_HandTransform;

	private readonly int InRestaurantTrigger;

	private WaypointNavigator m_WaypointNavigator;

	private Coroutine m_WanderAroundCoroutine;

	private Coroutine m_VendingCoroutine;

	private bool m_HasUsedVendingMachine;

	private bool m_IsPlayingAnimation;

	private NetworkNPCTransformView m_NetworkNPCTransformView;

	public Vector3 CurrentTarget;

	private bool m_IsMovingToVending;

	private VendingMachine m_CurrentVendingMachine;

	private VendingSlot m_CurrentVendingSlot;

	private Product m_CurrentProduct;

	public bool HasUsedVendingMachine => false;

	public WaypointNavigator WaypointNavigator
	{
		set
		{
		}
	}

	public float Speed
	{
		set
		{
		}
	}

	public NetworkNPCTransformView NetworkNPCTransformView => null;

	public bool IsPlayingAnimation
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void ManualUpdate()
	{
	}

	private bool IsClient()
	{
		return false;
	}

	public override void OnEnable()
	{
	}

	public override void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003CRestartAgent_003Ed__29))]
	private IEnumerator RestartAgent()
	{
		return null;
	}

	public void SetDestination(Vector3 target)
	{
	}

	public void StartRestaurantSequence()
	{
	}

	public void WarpAndMoveToNPC(Vector3 target, Vector3 targetPos)
	{
	}

	public void MoveToNetwork(Vector3 target)
	{
	}

	[IteratorStateMachine(typeof(_003CMoveTo_003Ed__36))]
	private IEnumerator MoveTo(Vector3 target, bool isVending = false)
	{
		return null;
	}

	public void StartVendingSequence()
	{
	}

	public void SetCurrentProduct(Product product)
	{
	}

	public void HoldProduct()
	{
	}

	public void ReleaseProduct()
	{
	}

	public void GoToVendingMachine(VendingMachine vendingMachine)
	{
	}

	public void LeaveVendingMachine()
	{
	}

	[PunRPC]
	public void LeaveVendingOrder_RPC()
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	public void PickUpProductAnimation()
	{
	}

	public void PushButton()
	{
	}

	public void OnButtonPushed()
	{
	}

	private void OnButtonPushed_Broadcast()
	{
	}

	[PunRPC]
	public void OnButtonPushed_RPC(int vendingViewId, int slotIndex)
	{
	}
}
