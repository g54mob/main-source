using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_CorruptBall : Monster_Basic
{
	[CompilerGenerated]
	private sealed class _003CCR_CreateCorruptTiles_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_CorruptBall _003C_003E4__this;

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
		public _003CCR_CreateCorruptTiles_003Ed__5(int _003C_003E1__state)
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
	private sealed class _003CCreateCorruptTileAtPosition_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public Vector3Int position;

		public Monster_CorruptBall _003C_003E4__this;

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
		public _003CCreateCorruptTileAtPosition_003Ed__6(int _003C_003E1__state)
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
	private ParticleSystem particle_Explode;

	[SerializeField]
	private GameObject prefab_CorruptTile;

	private bool isSkillUsed;

	protected override void SpawnProc()
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_CreateCorruptTiles_003Ed__5))]
	private IEnumerator CR_CreateCorruptTiles()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCreateCorruptTileAtPosition_003Ed__6))]
	private IEnumerator CreateCorruptTileAtPosition(Vector3Int position, float delay)
	{
		return null;
	}
}
