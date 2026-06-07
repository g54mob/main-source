using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using TMPro;

public class GridPieceObjGold : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_MyUpdate_003Ed__6 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjGold _003C_003E4__this;

		private float _003CsecPerGold_003E5__2;

		private float _003CcurTime_003E5__3;

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
		public _003C_MyUpdate_003Ed__6(int _003C_003E1__state)
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

	public int MinGold;

	public int MaxGold;

	public TextMeshPro TxtNumGold;

	private CoroutineHandle _update;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__6))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}

	public override void AttackPlayer()
	{
	}

	public override void AttackTortoise(PetObjTortoise tortoise)
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override void DropDeathStuff()
	{
	}

	private void RefreshGoldInd()
	{
	}
}
