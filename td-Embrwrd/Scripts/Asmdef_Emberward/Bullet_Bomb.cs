using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet_Bomb : ASingleTargetProjectile
{
	[CompilerGenerated]
	private sealed class _003CCR_Explode_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Bullet_Bomb _003C_003E4__this;

		private int _003CexplodeRange_003E5__2;

		private List<eDirectionType> _003Clist_UpdateDir_003E5__3;

		private float _003Ctime_003E5__4;

		private float _003Cduration_003E5__5;

		private int _003Ci_003E5__6;

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
		public _003CCR_Explode_003Ed__33(int _003C_003E1__state)
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
	private ParticleSystem particle_ExplosionFraction;

	[SerializeField]
	private ParticleSystem particle_BombExplosion;

	[SerializeField]
	private ParticleSystem particle_ExplosionFraction_Poison;

	[SerializeField]
	private ParticleSystem particle_BombExplosion_Poison;

	[SerializeField]
	private GameObject node_Bomb;

	[SerializeField]
	private Renderer renderer_Bomb;

	[SerializeField]
	private Material mat_NoUpgrade;

	[SerializeField]
	private Material mat_UpgradeA;

	[SerializeField]
	private Material mat_UpgradeB;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private bool isLanded;

	private bool isExploded;

	private ABaseTower.eUpgradeType towerUpgradeType;

	private eDamageType damageType;

	private Vector3Int targetPosition;

	private List<AMonsterBase> list_DamagedMonsters;

	public static List<Bullet_Bomb> List_BombsReadyToExplode;

	private bool isDetonated;

	private List<Bullet_Bomb> list_BombsToExplodeCache;

	public Vector3Int TargetPosition => default(Vector3Int);

	private void LateUpdate()
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(int damage, Vector3 targetPosition)
	{
	}

	public void Detonate()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Explode_003Ed__33))]
	private IEnumerator CR_Explode()
	{
		return null;
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
