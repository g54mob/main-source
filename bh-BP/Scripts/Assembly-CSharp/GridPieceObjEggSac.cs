using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GridPieceObjEggSac : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_SpawnBabies_003Ed__6 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjEggSac _003C_003E4__this;

		public GridPieceInst inst;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_SpawnBabies_003Ed__6(int _003C_003E1__state)
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

	public GridPieceType SpawnedType;

	public int MinSpawned;

	public int MaxSpawned;

	public float SpawnRange;

	private List<Vector3> _spawnPos;

	public override void Die(bool runDeathAnim)
	{
	}

	[IteratorStateMachine(typeof(_003C_SpawnBabies_003Ed__6))]
	private IEnumerator<float> _SpawnBabies(GridPieceInst inst)
	{
		return null;
	}

	public override void PlayBreakSFX()
	{
	}
}
