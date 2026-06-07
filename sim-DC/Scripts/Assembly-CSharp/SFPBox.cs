using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SFPBox : UsableObject
{
	[CompilerGenerated]
	private sealed class _003CParentTheObjectWithDelay_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform uo;

		public SFPBox _003C_003E4__this;

		public int index;

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
		public _003CParentTheObjectWithDelay_003Ed__6(int _003C_003E1__state)
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

	public int sfpBoxType;

	private int[] usedPositions;

	[SerializeField]
	private Transform[] sfpPositions;

	public override void Awake()
	{
	}

	public override void InteractOnClick()
	{
	}

	private void InsertSFPBackIntoBox()
	{
	}

	[IteratorStateMachine(typeof(_003CParentTheObjectWithDelay_003Ed__6))]
	private IEnumerator ParentTheObjectWithDelay(Transform uo, int index)
	{
		return null;
	}

	private int GetFreeSpaceInTheBox()
	{
		return 0;
	}

	public void RemoveSFPFromBox(int position)
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public void LoadSFPsFromSave()
	{
	}

	public SFPModule TakeSFPFromBox()
	{
		return null;
	}

	public bool CanAcceptSFP(int sfpType)
	{
		return false;
	}

	public bool ReturnSFPDirectly(SFPModule sfpmodule)
	{
		return false;
	}
}
