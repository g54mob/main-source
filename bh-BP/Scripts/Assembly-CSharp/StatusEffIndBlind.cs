using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class StatusEffIndBlind : StatusEffInd
{
	[CompilerGenerated]
	private sealed class _003C_DetachAndRemove_003Ed__7 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public StatusEffIndBlind _003C_003E4__this;

		private float _003CfadeLen_003E5__2;

		private float _003CstartTime_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_DetachAndRemove_003Ed__7(int _003C_003E1__state)
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

	private CoroutineHandle _updateAnim;

	public Transform Orb1;

	public Transform Orb2;

	private float _defaultScale;

	public override void Init(GridPieceObj p, StatusEffect ef)
	{
	}

	public override void OnAboutToRemove()
	{
	}

	private void MyUpdate()
	{
	}

	[IteratorStateMachine(typeof(_003C_DetachAndRemove_003Ed__7))]
	protected override IEnumerator<float> _DetachAndRemove()
	{
		return null;
	}
}
