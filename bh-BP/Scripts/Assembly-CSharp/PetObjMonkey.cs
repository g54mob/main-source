using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class PetObjMonkey : PetObj
{
	[CompilerGenerated]
	private sealed class _003C_RunAttackingEnemy_003Ed__17 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PetObjMonkey _003C_003E4__this;

		private float _003CnextAttackTime_003E5__2;

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
		public _003C_RunAttackingEnemy_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003C_RunJump_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PetObjMonkey _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

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
		public _003C_RunJump_003Ed__16(int _003C_003E1__state)
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

	public MonkeyState CurState;

	private GridPieceInst _tgt;

	private float _speed;

	private CoroutineHandle _curAnim;

	private PetUpgradeInst _slowInst;

	private PetUpgradeInst _stealInst;

	private PetUpgradeInst _healInst;

	private float _attackCooldown;

	private const float kJumpDist = 1f;

	public override void Init(int idx, PetBattleInst p)
	{
	}

	public override void InitPlacement(int idx)
	{
	}

	public override void RefreshProperties()
	{
	}

	protected override void MyUpdate()
	{
	}

	private void PickTarget()
	{
	}

	public void SetState(MonkeyState st)
	{
	}

	private Vector3 GetPosOnEnemy()
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003C_RunJump_003Ed__16))]
	private IEnumerator<float> _RunJump()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunAttackingEnemy_003Ed__17))]
	private IEnumerator<float> _RunAttackingEnemy()
	{
		return null;
	}
}
