using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EPOOutline;
using PolyStang;
using UnityEngine;

public class TrolleyLoadingBay : Interact
{
	[CompilerGenerated]
	private sealed class _003CParentTheObjectWithDelay_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UsableObject uo;

		public TrolleyLoadingBay _003C_003E4__this;

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
		public _003CParentTheObjectWithDelay_003Ed__10(int _003C_003E1__state)
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
	private Transform temporaryTransformToStoreInCorrectSpot;

	[SerializeField]
	private Transform[] positionsOnTrolley;

	private int[] usedPositions;

	private Outlinable outlineEffect;

	[SerializeField]
	private Vector3[] additionalPositions;

	[SerializeField]
	private Vector3[] additionalRotations;

	private CarController carController;

	public override void Awake()
	{
	}

	public void Start()
	{
	}

	public override void InteractOnClick()
	{
	}

	[IteratorStateMachine(typeof(_003CParentTheObjectWithDelay_003Ed__10))]
	private IEnumerator ParentTheObjectWithDelay(UsableObject uo)
	{
		return null;
	}

	public void FreeTrolleySlot(int startIdx, int sizeInU)
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}
}
