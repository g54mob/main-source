using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_CorruptElemental : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CDeathProc_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_CorruptElemental _003C_003E4__this;

		public int damage;

		public bool isKilled;

		public bool playAnimation;

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
		public _003CDeathProc_003Ed__10(int _003C_003E1__state)
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
	private GameObject prefab_CorruptTile;

	private bool isSkillUsed;

	[SerializeField]
	[Header("移動多少格會發動一次效果")]
	private int triggerEffectMoveRange;

	[Header("死亡時產生幾個腐化格")]
	[SerializeField]
	private int spawnCorruptCount;

	private int moveCount;

	private Vector3Int lastPosition;

	private List<Vector3Int> list_PossibleCorruptPositionOnDeath;

	private bool isHardModeActive;

	private Vector3Int[] list_AllPointIn5x5;

	protected override void SpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CDeathProc_003Ed__10))]
	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void CreateCorruptTileAtPosition(Vector3Int position)
	{
	}
}
