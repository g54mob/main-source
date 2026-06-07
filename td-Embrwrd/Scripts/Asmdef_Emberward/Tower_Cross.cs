using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Cross : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Cross _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__27(int _003C_003E1__state)
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
	private List<Collider> list_CollisionColliders;

	[SerializeField]
	private List<ParticleSystem> list_FlameParticle;

	[SerializeField]
	private List<ParticleSystem> list_IceParticles;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	private Vector3 headModelForward;

	[SerializeField]
	private bool isRotateClockwise;

	[SerializeField]
	private float rotateDegreePerSecond_Min;

	[SerializeField]
	private float rotateDegreePerSecond_Max;

	[SerializeField]
	private Transform node_CannonRotate;

	[SerializeField]
	private float attackRangeMultiplier_Min;

	[SerializeField]
	private float attackRangeMultiplier_Max;

	[SerializeField]
	private float attackRangeMultiplier;

	[SerializeField]
	private float rotateDegreePerSecond;

	[SerializeField]
	private float originalShootRange;

	private float attackAngle;

	private float lastFrameAttackRange;

	public override List<Collider> GetCollisionColliders()
	{
		return null;
	}

	protected override void CannonUpdateProc()
	{
	}

	private void UpdateParticleSize()
	{
	}

	protected void UpdateRotate()
	{
	}

	public void InverseRotateDirection()
	{
	}

	public void SetRotateClockwise(bool isClockwise)
	{
	}

	public bool GetRotateClockwise()
	{
		return false;
	}

	public void SetRotateSpeed(float t)
	{
	}

	public float GetRotateSpeed()
	{
		return 0f;
	}

	public void SetAttackRange(float t)
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__27))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	public override void TowerDormantEndProc()
	{
	}

	protected override void ShootProc()
	{
	}

	private List<AMonsterBase> GetMonstersInAngleRange(float maxAngle, List<AMonsterBase> list_monsters)
	{
		return null;
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}
}
