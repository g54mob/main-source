using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public class NetworkCustomerTransform : MonoBehaviourPunCallbacks
{
	[CompilerGenerated]
	private sealed class _003CLoop_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NetworkCustomerTransform _003C_003E4__this;

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
		public _003CLoop_003Ed__15(int _003C_003E1__state)
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

	private float m_SendDelay;

	private NavMeshAgent m_NavmeshAgent;

	private Customer m_Customer;

	private CustomerAnimator m_CustomerAnimator;

	private PhotonView m_PhotonView;

	private bool m_IsMoving;

	public PhotonView PhotonView => null;

	public Customer Customer => null;

	public NavMeshAgent NavmeshAgent => null;

	public CustomerAnimator CustomerAnimator => null;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CLoop_003Ed__15))]
	private IEnumerator Loop()
	{
		return null;
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void SyncTransform_Broadcast()
	{
	}

	public void RefrestPosition(string userID)
	{
	}

	[PunRPC]
	public void SyncTransform_RPC(Vector3 destination)
	{
	}

	[PunRPC]
	public void StopTransform_RPC(Vector3 rot, Vector3 pos)
	{
	}
}
