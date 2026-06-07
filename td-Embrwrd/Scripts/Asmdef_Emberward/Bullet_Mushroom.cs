using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mushroom : ASingleTargetProjectile
{
	private enum eMushroomState
	{
		NONE = 0,
		FLYING = 1,
		ON_MONSTER = 2,
		ON_GROUND = 3
	}

	[Serializable]
	private class PositionAndTimeRecord
	{
		public Vector3Int position;

		public float time;
	}

	[Serializable]
	private class PoisonParticlePair
	{
		public ABaseTower.eUpgradeType upgradeType;

		public ParticleSystem particle;
	}

	[Serializable]
	private class MaterialPair
	{
		public ABaseTower.eUpgradeType upgradeType;

		public Material material;
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Renderer renderer_mushroom;

	[SerializeField]
	private List<MaterialPair> list_MushroomMaterials;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	private float poisonRange_Air;

	[SerializeField]
	private float poisonRange_Ground;

	[SerializeField]
	private float duration;

	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private float mushroomScale_Min;

	[SerializeField]
	private float mushroomScale_Max;

	[SerializeField]
	private float damageInterval;

	[SerializeField]
	private List<PoisonParticlePair> list_PoisonParticles_Air;

	[SerializeField]
	private List<PoisonParticlePair> list_PoisonParticles_Ground;

	[SerializeField]
	private eMushroomState mushroomState;

	private List<PositionAndTimeRecord> list_PositionAndTimeRecords;

	private Vector3Int lastRecordedPosition;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private float durationTimer;

	private float damageTimer;

	private Transform monsterBoneNode;

	private ABaseTower.eUpgradeType upgradeType;

	private float extraEffectDetectInterval;

	private float extraEffectDetectTimer;

	public void Setup(int damage, ABaseTower.eUpgradeType upgradeType)
	{
	}

	protected override void SpawnProc()
	{
	}

	private void LateUpdate()
	{
	}

	protected override Vector3 GetFlyTargetPosition(bool isAttackHeadPosition = true)
	{
		return default(Vector3);
	}

	private void Update()
	{
	}

	public void TogglePoisonParticle_Air(bool isOn, ABaseTower.eUpgradeType upgradeType)
	{
	}

	public void TogglePoisonParticle_Ground(bool isOn, ABaseTower.eUpgradeType upgradeType)
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
