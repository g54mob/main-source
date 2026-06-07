using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_GoldenStatue : ABaseTower
{
	private class GoldifyMonsterData
	{
		public AMonsterBase monster;

		public int accumulatedDamage;

		public float timer;

		public bool isEventRegistered;

		public int hitCount;

		public GoldifyMonsterData(AMonsterBase monster, float timer)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShootEffect_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_GoldenStatue _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_ShootEffect_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003CSpawnProc_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_GoldenStatue _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__16(int _003C_003E1__state)
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

	private Vector3 headModelForward;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private ParticleSystem particle_HitEffect;

	[SerializeField]
	private float goldifyDuration;

	[SerializeField]
	private float shootEffectDuration;

	[SerializeField]
	private float lineRendererMaxWidth;

	[SerializeField]
	private AnimationCurve curve_ShootEffectSize;

	[Header("升級A的黃金特效")]
	[SerializeField]
	protected ParticleSystem particle_AreaGoldifyEffect;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	private List<GoldifyMonsterData> list_GoldifyMonstersData;

	private Dictionary<AMonsterBase, GoldifyMonsterData> dict_GoldifyMonstersData;

	private float timeAfterShoot;

	private int goldGained;

	private Vector3 headAimTargetPosition;

	private float checkNewTargetTimer;

	private Vector3 lastHitPosition;

	private void Start()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__16))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected override void CannonUpdateProc()
	{
	}

	private void UpdateGoldifyMonsterList()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShootEffect_003Ed__24))]
	private IEnumerator CR_ShootEffect()
	{
		return null;
	}

	private void GoldifyMonster(AMonsterBase target, float duration)
	{
	}

	private void OnGoldifyMonsterDamaged(AMonsterBase monster, int damage, eDamageType damageType, bool isCrit, ABaseTower fromTower)
	{
	}

	private void UpdateLinePosition()
	{
	}

	public override string GetExtraTowerControlRecord()
	{
		return null;
	}
}
