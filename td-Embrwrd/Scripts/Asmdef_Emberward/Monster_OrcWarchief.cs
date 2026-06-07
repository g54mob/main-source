using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_OrcWarchief : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_Cast_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_OrcWarchief _003C_003E4__this;

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
		public _003CCR_Cast_003Ed__9(int _003C_003E1__state)
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
	private float skillInterval;

	[SerializeField]
	private float skillRange;

	[SerializeField]
	private float skillSpeedModifier;

	[SerializeField]
	private ParticleSystem particle_Roar;

	[SerializeField]
	private float skillSpeedModifierDuration;

	[SerializeField]
	private float skillTimer;

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void Skill_SpeedUpSurroundingMonster()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Cast_003Ed__9))]
	private IEnumerator CR_Cast()
	{
		return null;
	}
}
