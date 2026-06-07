using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_EvilSnowmanSnowball : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_FlyToTarget_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_EvilSnowmanSnowball _003C_003E4__this;

		public float flyTime;

		private float _003Ctimer_003E5__2;

		private Vector3 _003CstartPosition_003E5__3;

		private Vector3 _003CtargetPosition_003E5__4;

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
		public _003CCR_FlyToTarget_003Ed__14(int _003C_003E1__state)
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
	private GameObject node_Missile;

	[SerializeField]
	private ParticleSystem particle_Explosion;

	[SerializeField]
	private float flyHeight;

	[SerializeField]
	private float explosionRange;

	[SerializeField]
	private float flySpeed;

	[SerializeField]
	[Header("擊中時產生幾個腐化格")]
	private int spawnCorruptCount;

	[SerializeField]
	private GameObject prefab_CorruptTile;

	private Vector3 targetPosition;

	private ABaseTower targetTower;

	private AMonsterBase fromMonster;

	private float stunTime;

	private List<Vector3Int> list_PossibleCorruptPositionOnDeath;

	private Vector3Int[] list_AllPointIn5x5;

	public void Shoot(ABaseTower tower, AMonsterBase monster, float stunTime)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_FlyToTarget_003Ed__14))]
	private IEnumerator CR_FlyToTarget(float flyTime)
	{
		return null;
	}

	private void CreateCorruptTileOnHit()
	{
	}

	private void CreateCorruptTileAtPosition(Vector3Int position)
	{
	}
}
