using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ElementShieldBot : Monster_Basic
{
	[Serializable]
	public class ElementToMaterial
	{
		public eDamageType element;

		public Material material_normal;

		public Material material_corrupted;

		public Material material_shield;
	}

	[SerializeField]
	private ParticleSystem particle_Shield;

	[SerializeField]
	private ParticleSystem particle_ShieldChangeShine;

	[SerializeField]
	private List<ElementToMaterial> list_ElementToMaterials;

	[SerializeField]
	private float shieldRange;

	private float shieldChangeInterval;

	private float shieldChangeTimer;

	private float monsterDetectInterval;

	private float monsterDetectTimer;

	private eDamageType shieldType;

	private Dictionary<eDamageType, int> damageRecord;

	private bool isShieldOn;

	private bool isHardModeActive;

	private float finalShieldRange;

	private Vector3 shieldParticleOriginalScale;

	private List<AMonsterBase> list_ProtectedMonsters;

	protected override void Awake()
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	private void DetectMonster()
	{
	}

	private void UpdateShield()
	{
	}

	public void SetParticleColor(Color color)
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool fromTower)
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}
}
