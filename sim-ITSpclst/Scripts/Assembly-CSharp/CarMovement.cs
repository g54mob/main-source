using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleArrival_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CarMovement _003C_003E4__this;

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
		public _003CHandleArrival_003Ed__14(int _003C_003E1__state)
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

	public Transform arena;

	public float navMeshSearchRadius;

	public float minMoveDistance;

	public float minSitTime;

	public float maxSitTime;

	public float sitChance;

	public float minIdleTime;

	private NavMeshAgent agent;

	private Animator animator;

	private Bounds arenaBounds;

	private bool isWaiting;

	private Vector3 lastPosition;

	private void Start()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CHandleArrival_003Ed__14))]
	private IEnumerator HandleArrival()
	{
		return null;
	}

	private void MoveToRandomPoint()
	{
	}

	private Vector3 GetRandomNavMeshPosition()
	{
		return default(Vector3);
	}
}
