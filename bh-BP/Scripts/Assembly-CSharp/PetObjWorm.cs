using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class PetObjWorm : PetObj
{
	[CompilerGenerated]
	private sealed class _003C_RunWorm_003Ed__14 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PetObjWorm _003C_003E4__this;

		private float _003ClastStateTime_003E5__2;

		private int _003CburstSize_003E5__3;

		private int _003CarcSize_003E5__4;

		private int _003Ci_003E5__5;

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
		public _003C_RunWorm_003Ed__14(int _003C_003E1__state)
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

	private BallObj _attachedBall;

	public Vector2 AimDir;

	private float _lastShootTime;

	private CoroutineHandle _runAnim;

	private PetUpgradeInst _burstInst;

	private PetUpgradeInst _arcInst;

	private PetUpgradeInst _magnetInst;

	private PetUpgradeInst _goldInst;

	public override void Init(int idx, PetBattleInst p)
	{
	}

	public override void Reset()
	{
	}

	public override void RefreshProperties()
	{
	}

	public override void InitPlacement(int idx)
	{
	}

	public bool IsHiding()
	{
		return false;
	}

	protected override void MyUpdate()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunWorm_003Ed__14))]
	private IEnumerator<float> _RunWorm()
	{
		return null;
	}
}
