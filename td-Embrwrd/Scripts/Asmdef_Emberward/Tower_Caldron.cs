using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public class Tower_Caldron : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_AbsorbMonster_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AMonsterBase monster;

		public Tower_Caldron _003C_003E4__this;

		public int damageOnAbsorb;

		private LineRenderer _003ClineRenderer_003E5__2;

		private float _003Ctime_003E5__3;

		private float _003Cduration_003E5__4;

		private Vector3 _003CstartPos_003E5__5;

		private Vector3 _003CendPos_003E5__6;

		private float _003CshrinkScale_003E5__7;

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
		public _003CCR_AbsorbMonster_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CCR_SpawnSingleTargetBullet_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AMonsterBase targetMonster;

		public Tower_Caldron _003C_003E4__this;

		public Transform spawnNode;

		public int damage;

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
		public _003CCR_SpawnSingleTargetBullet_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003CCR_SummonPoisonElemental_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Caldron _003C_003E4__this;

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
		public _003CCR_SummonPoisonElemental_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003CSpawnProc_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Caldron _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__29(int _003C_003E1__state)
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

	private static List<int> list_AbsorbingMonsterIDs;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	protected ParticleSystem particle_PoisonSplash_Small;

	[SerializeField]
	protected ParticleSystem particle_PoisonCloud;

	[SerializeField]
	private Animator animator_Cauldron;

	[SerializeField]
	private Animator animator_PoisonElemental;

	[SerializeField]
	private Transform node_PoisonElemental;

	[SerializeField]
	private LineRenderer lineRenderer_Absorb;

	[SerializeField]
	private Transform node_LineRendererStart;

	[SerializeField]
	private List<Transform> list_PoisonElementalAttackPoints;

	[SerializeField]
	private TMP_Text text_Counter;

	[SerializeField]
	private GameObject node_CounterText;

	[SerializeField]
	private int lineSegmentCount;

	private bool isPoisonElementReady;

	[SerializeField]
	private GameObject prefab_PoisonElementalSingleMissile;

	[SerializeField]
	private GameObject prefab_PoisonElementalAOEBullet;

	private List<LineRenderer> list_LineRenderers;

	private List<Obj_SlimeBomb> list_CreatedSlimeBombs;

	private int absorbedMonsterCount;

	private int maxAbsorbedMonsterCount;

	private Vector3 linePos;

	private int attackCount;

	private TweenerCore<Vector3, Vector3, VectorOptions> tween;

	private bool isTextShown;

	private float hideTextTimer;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_AbsorbMonster_003Ed__23))]
	private IEnumerator CR_AbsorbMonster(AMonsterBase monster, int damageOnAbsorb = 0)
	{
		return null;
	}

	private Vector3 UpdateLine(LineRenderer line, Vector3 start, Vector3 end, int showNode)
	{
		return default(Vector3);
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__29))]
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

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SummonPoisonElemental_003Ed__34))]
	private IEnumerator CR_SummonPoisonElemental()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_SpawnSingleTargetBullet_003Ed__35))]
	private IEnumerator CR_SpawnSingleTargetBullet(Transform spawnNode, AMonsterBase targetMonster, int damage)
	{
		return null;
	}

	private void CreateBuffTile()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void OnMouseEnterProc()
	{
	}

	protected override void OnMouseOverProc()
	{
	}

	protected override void OnMouseExitProc()
	{
	}

	private void UpdateCounterText()
	{
	}

	private void ToggleCounterText(bool isShow)
	{
	}
}
