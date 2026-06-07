using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/AreaDeployScrapTowerBuff", order = 2)]
public class AreaDeployScrapTowerBuff : ABaseBuffSettingData
{
	[CompilerGenerated]
	private sealed class _003CCR_CreateScrapTowers_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<Vector3Int> list_CandidatePos;

		public AreaDeployScrapTowerBuff _003C_003E4__this;

		private List<Vector3>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_CreateScrapTowers_003Ed__4(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private TowerStats buffModifierStats;

	[SerializeField]
	private int deployCount;

	[SerializeField]
	private float deployRange;

	protected override void ApplyEffect()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CreateScrapTowers_003Ed__4))]
	private IEnumerator CR_CreateScrapTowers(List<Vector3Int> list_CandidatePos)
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
