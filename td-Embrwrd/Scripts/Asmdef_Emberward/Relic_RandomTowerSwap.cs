using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Relic_RandomTowerSwap : RelicTemplate_RoundBased
{
	[CompilerGenerated]
	private sealed class _003CCR_SwapTower_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<ABaseTower> list_Towers;

		public Relic_RandomTowerSwap _003C_003E4__this;

		public float interval;

		public int changeCount;

		private int _003CfinalChangedCount_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CCR_SwapTower_003Ed__4(int _003C_003E1__state)
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

	private List<TowerIngameData> list_PlayerLoadoutTowers;

	private List<TowerSettingData> list_loadoutTowerSettingData;

	private int changeTowerCount;

	protected override void OnRoundStartProc(int round, int totalRound)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SwapTower_003Ed__4))]
	private IEnumerator CR_SwapTower(List<ABaseTower> list_Towers, int changeCount, float interval)
	{
		return null;
	}
}
