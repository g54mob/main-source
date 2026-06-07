using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;

public class PetObjMole : PetObj
{
	[CompilerGenerated]
	private sealed class _003C_RunMole_003Ed__14 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PetObjMole _003C_003E4__this;

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
		public _003C_RunMole_003Ed__14(int _003C_003E1__state)
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

	private CoroutineHandle _runAnim;

	private float _lastCollectTime;

	private PetUpgradeInst _healInst;

	private PetUpgradeInst _magnetInst;

	private PetUpgradeInst _quakeInst;

	private float _lastQuakeTime;

	private PetUpgradeInst _speedInst;

	public List<BallObj> TouchingBalls;

	public List<BallObj> TouchedBallsThisFrame;

	public override void Init(int idx, PetBattleInst p)
	{
	}

	public override void RefreshProperties()
	{
	}

	public override void InitPlacement(int idx)
	{
	}

	protected override void MyUpdate()
	{
	}

	public bool IsHiding()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_RunMole_003Ed__14))]
	private IEnumerator<float> _RunMole()
	{
		return null;
	}

	public override bool ShouldScrollWithBoard()
	{
		return false;
	}
}
