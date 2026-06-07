using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Relic_ScrapRecyclingSystem : RelicTemplate_TowerBased
{
	[CompilerGenerated]
	private sealed class _003CCR_CreateScrapTower_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Relic_ScrapRecyclingSystem _003C_003E4__this;

		public ABaseTower originTower;

		public int count;

		private List<Vector3> _003Clist_CreateTowerPos_003E5__2;

		private List<Vector3>.Enumerator _003C_003E7__wrap2;

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
		public _003CCR_CreateScrapTower_003Ed__4(int _003C_003E1__state)
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

	private Vector3Int[] array_OffsetIn5x5;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void OnTowerPlacedProc(ABaseTower tower)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CreateScrapTower_003Ed__4))]
	private IEnumerator CR_CreateScrapTower(int count, ABaseTower originTower)
	{
		return null;
	}
}
