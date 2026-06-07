using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Transmute : ABaseTower
{
	private class AttackedMonsterRecord
	{
		public AMonsterBase monster;

		public int monsterID;

		public float recordStartTime;

		public float moveDistance;

		public float totalMoveDistance;

		public float upgradeATimer;

		public Vector3 lastUpdatePosition;
	}

	[CompilerGenerated]
	private sealed class _003CCR_SpawnProc_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Transmute _003C_003E4__this;

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
		public _003CCR_SpawnProc_003Ed__28(int _003C_003E1__state)
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
	[Header("柱子Collider")]
	private List<BoxCollider> list_PillarColliders;

	[Header("怪物偵測")]
	[SerializeField]
	protected Obj_AreaMonsterDetector detector;

	[Header("閃電效果的Line renderer")]
	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	[Header("閃電效果起終點的範圍A")]
	private Transform lineStartPointRange_A;

	[SerializeField]
	[Header("閃電效果起終點的範圍B")]
	private Transform lineStartPointRange_B;

	[SerializeField]
	[Header("模型Mesh Filter")]
	private MeshFilter meshFilter_Model;

	[SerializeField]
	[Header("升級A的Mesh")]
	private Mesh mesh_UpgradeA;

	[SerializeField]
	[Header("依照升級狀況開啟的物件")]
	private GameObject node_NoUpgrade_AdditionalPart;

	[SerializeField]
	private GameObject node_UpgradeA_AdditionalPart;

	[SerializeField]
	private GameObject node_UpgradeB_AdditionalPart;

	[SerializeField]
	[Header("奧術擊中效果")]
	private ParticleSystem particle_UpgradeAHitEffect;

	[SerializeField]
	[Header("依照升級狀況切換的Line renderer材質")]
	private Material mat_LineRenderer_Normal;

	[SerializeField]
	private Material mat_LineRenderer_UpgradeA;

	[SerializeField]
	private Material mat_LineRenderer_UpgradeB;

	[SerializeField]
	private ParticleSystem particle_ElectricEffect_Normal;

	[SerializeField]
	private List<ParticleSystem> particle_ElectricEffect_UpgradeA;

	[SerializeField]
	private ParticleSystem particle_ElectricEffect_UpgradeB;

	private List<AttackedMonsterRecord> list_AttackedMonsters;

	private float vfxUpdateTimer;

	private float vfxUpdateInterval;

	private List<AMonsterBase> list_MonstersInArea_Detection;

	public Obj_AreaMonsterDetector Detector => null;

	private void Start()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SpawnProc_003Ed__28))]
	private IEnumerator CR_SpawnProc()
	{
		return null;
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	private bool IsMonsterAttacked(AMonsterBase monster)
	{
		return false;
	}

	public override void TowerStunProc()
	{
	}

	public override void TowerStunEndProc()
	{
	}

	protected override void ShootProc()
	{
	}

	public override void TowerDormantEndProc()
	{
	}

	private void UpdateVFX()
	{
	}
}
