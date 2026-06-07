using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/RoyalGuard_PerTowerBuff", order = 1)]
public class RoyalGuard_PerTowerBuff : ABaseBuffSettingData
{
	[CompilerGenerated]
	private sealed class _003CCR_Effect_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RoyalGuard_PerTowerBuff _003C_003E4__this;

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
		public _003CCR_Effect_003Ed__4(int _003C_003E1__state)
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

	private float duration;

	private bool isTriggered;

	protected override void ApplyEffect()
	{
	}

	private void OnTowerStunned(ABaseTower tower, float duration, AMonsterBase fromMonster)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Effect_003Ed__4))]
	private IEnumerator CR_Effect()
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
