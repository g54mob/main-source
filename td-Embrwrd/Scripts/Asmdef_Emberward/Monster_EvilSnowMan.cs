using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_EvilSnowMan : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_AttackPlayerTower_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_EvilSnowMan _003C_003E4__this;

		private ABaseTower _003CtargetTower_003E5__2;

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
		public _003CCR_AttackPlayerTower_003Ed__8(int _003C_003E1__state)
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
	private GameObject prefab_Snoiwball;

	[SerializeField]
	private Transform node_HandBone;

	private bool isSkillUsed;

	[Header("移動多少格會發動一次效果")]
	[SerializeField]
	private int triggerEffectMoveRange;

	private int moveCount;

	private Vector3Int lastPosition;

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_AttackPlayerTower_003Ed__8))]
	private IEnumerator CR_AttackPlayerTower()
	{
		return null;
	}
}
