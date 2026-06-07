using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

public class EnemySpecialAttackPrefabMulti : EnemySpecialAttackPrefab
{
	[CompilerGenerated]
	private sealed class _003CDoAttack_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackPrefabMulti _003C_003E4__this;

		private List<Vector3>[] _003CpositionsList_003E5__2;

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
		public _003CDoAttack_003Ed__7(int _003C_003E1__state)
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

	public bool grounded;

	public int numLines;

	public int degreesBetweenLines;

	public int numHits;

	public float hitsSpacingMultiplier;

	public float delayBetweenHits;

	private int numSpawned;

	protected override void Init()
	{
	}

	[IteratorStateMachine(typeof(_003CDoAttack_003Ed__7))]
	private IEnumerator DoAttack()
	{
		return null;
	}

	private void SpawnHitEffect(Vector3 pos)
	{
	}
}
