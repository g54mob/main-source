using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using TMPro;
using UnityEngine;

public class GridPieceObjAlly : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_RunArcher_003Ed__9 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjAlly _003C_003E4__this;

		private float _003CnextShootTime_003E5__2;

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
		public _003C_RunArcher_003Ed__9(int _003C_003E1__state)
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
	private sealed class _003C_RunGold_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjAlly _003C_003E4__this;

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
		public _003C_RunGold_003Ed__11(int _003C_003E1__state)
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
	private sealed class _003C_RunHealer_003Ed__10 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjAlly _003C_003E4__this;

		private float _003CturnLen_003E5__2;

		private float _003ChealthPerTurn_003E5__3;

		private float _003CstartTime_003E5__4;

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
		public _003C_RunHealer_003Ed__10(int _003C_003E1__state)
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

	private PassiveInst _tgtPassive;

	private CoroutineHandle _activeRoutine;

	[Header("Archer")]
	public ArrowType TgtArrow;

	public float MinShootCycle;

	public float MaxShootCycle;

	[Header("Gold")]
	public TextMeshPro TxtNumGold;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override void Reset()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunArcher_003Ed__9))]
	private IEnumerator<float> _RunArcher()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunHealer_003Ed__10))]
	private IEnumerator<float> _RunHealer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunGold_003Ed__11))]
	private IEnumerator<float> _RunGold()
	{
		return null;
	}

	private void RefreshGoldInd()
	{
	}

	public override void DropDeathStuff()
	{
	}
}
