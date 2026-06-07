using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/RoyalGuardBuff", order = 2)]
public class RoyalGuardBuff : ABaseBuffSettingData
{
	[CompilerGenerated]
	private sealed class _003CCR_Effect_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ABaseTower tower;

		public AMonsterBase fromMonster;

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
		public _003CCR_Effect_003Ed__8(int _003C_003E1__state)
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

	private bool isTriggered;

	private GameObject vfx_Shield;

	private float triggerInterval;

	private float triggerTimer;

	protected override void ApplyEffect()
	{
	}

	private void OnTowerStunned(ABaseTower tower, float duration, AMonsterBase fromMonster)
	{
	}

	private void Update()
	{
	}

	protected override void TickProc(float delta)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Effect_003Ed__8))]
	private IEnumerator CR_Effect(ABaseTower tower, AMonsterBase fromMonster)
	{
		return null;
	}

	protected override void RemoveEffect()
	{
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
