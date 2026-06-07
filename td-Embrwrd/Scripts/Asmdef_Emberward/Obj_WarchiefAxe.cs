using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_WarchiefAxe : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public bool moveDone;

		internal void _003CCR_ThrowWeaponBounce_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public bool jumpDone;

		internal void _003CCR_ThrowWeaponBounce_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_ThrowWeaponBounce_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_WarchiefAxe _003C_003E4__this;

		public List<ABaseTower> targetTowers;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass8_1 _003C_003E8__2;

		public float stunTime;

		public AMonsterBase fromMonster;

		private Vector3 _003CtargetPosition_003E5__2;

		private int _003Ci_003E5__3;

		private ABaseTower _003Ctower_003E5__4;

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
		public _003CCR_ThrowWeaponBounce_003Ed__8(int _003C_003E1__state)
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
	private sealed class _003CCR_WaitEffectEnd_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public Obj_WarchiefAxe _003C_003E4__this;

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
		public _003CCR_WaitEffectEnd_003Ed__9(int _003C_003E1__state)
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
	private Spin scpt_Spin;

	[SerializeField]
	private ParticleSystem particle_Hit;

	[SerializeField]
	private ParticleSystem particle_Lightning;

	[SerializeField]
	private float weaponFlightSpeed;

	[SerializeField]
	private Transform node_AxeTop;

	private Transform fromNode;

	public void ThrowWeapon(AMonsterBase fromMonster, Transform fromTransform, ABaseTower tower, float stunTime)
	{
	}

	public void ThrowWeapon(AMonsterBase fromMonster, Transform fromTransform, List<ABaseTower> targetTowers, float stunTime)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ThrowWeaponBounce_003Ed__8))]
	private IEnumerator CR_ThrowWeaponBounce(AMonsterBase fromMonster, List<ABaseTower> targetTowers, float stunTime)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_WaitEffectEnd_003Ed__9))]
	private IEnumerator CR_WaitEffectEnd(float duration)
	{
		return null;
	}

	private void ToggleSpin(bool doSpin)
	{
	}
}
