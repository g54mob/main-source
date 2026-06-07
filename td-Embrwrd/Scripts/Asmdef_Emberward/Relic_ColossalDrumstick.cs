using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Relic_ColossalDrumstick : ARelicBase
{
	[CompilerGenerated]
	private sealed class _003CCR_DelayedInit_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Relic_ColossalDrumstick _003C_003E4__this;

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
		public _003CCR_DelayedInit_003Ed__8(int _003C_003E1__state)
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

	private Vector3 fireSourcePos;

	private GameObject obj_ColossalDrumstick;

	private FireSourceShootModule shootModule;

	private float checkInterval;

	private float checkTimer;

	private int guid;

	private bool isInitialized;

	protected override void OnEnableProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedInit_003Ed__8))]
	private IEnumerator CR_DelayedInit()
	{
		return null;
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void UpdateEffect()
	{
	}
}
