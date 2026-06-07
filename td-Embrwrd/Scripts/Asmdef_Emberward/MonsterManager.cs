using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : Singleton<MonsterManager>
{
	public class MonsterAggroEffect
	{
		public AMonsterBase monster;

		public float range;

		public float time;

		public int id;
	}

	[SerializeField]
	private ParticleSystem particle_BurnEffect;

	[SerializeField]
	private List<AMonsterBase> list_MonsterOnField;

	[SerializeField]
	private List<AMonsterBase> list_MonsterAttackable;

	private List<MonsterSpawner> list_MonsterSpawners;

	[SerializeField]
	private AMonsterBase focusFireMonster;

	private int focusFireMonsterID;

	[SerializeField]
	private List<MonsterAggroEffect> list_MonsterAggroEffects;

	private int monsterIDCounter;

	public Action<AMonsterBase, int, eDamageType, bool, ABaseTower> OnMonsterHit_Global;

	public Action<AMonsterBase> OnMonsterKilled_Global;

	private float burnEffectUpdateInterval;

	private float burnEffectUpdateTimer;

	[SerializeField]
	private float missingReferenceDeleteTimer;

	[SerializeField]
	private float missingReferenceDeleteInterval;

	protected override void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestSetFocusFireMonster(AMonsterBase monster)
	{
	}

	private void OnInitializeEnvSceneBindings(GameSceneReferenceHandler refHandler)
	{
	}

	public int GetNewMonsterID()
	{
		return 0;
	}

	public void AddMonsterAggroEffect(AMonsterBase monster, float range, float time, int id)
	{
	}

	public void RemoveMonsterAggroEffect(int id)
	{
	}

	private void Update()
	{
	}

	public AMonsterBase SpawnMonster(eMonsterType type, Vector3 spawnPosition, bool isCorrupted, int spawnerIndex = 0, bool startWithIdle = false)
	{
		return null;
	}

	private void OnMonsterDamaged(AMonsterBase monster, int value, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}

	private void OnMonsterSpawn(AMonsterBase monster)
	{
	}

	private void OnMonsterImpendingDeath(AMonsterBase monster)
	{
	}

	private void OnMonsterImpendingDeathRemoved(AMonsterBase monster)
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	private void OnMonsterDespawn(AMonsterBase monster)
	{
	}

	public int GetMonsterOnFieldCount()
	{
		return 0;
	}

	public List<AMonsterBase> GetMonstersOnField()
	{
		return null;
	}

	public AMonsterBase GetBossMonster()
	{
		return null;
	}

	public int GetMonsterOnFieldCountWithoutPersistentMonsters()
	{
		return 0;
	}

	public List<AMonsterBase> GetAttackableMonstersInRange(Vector3 center, float range, float minRange = 0f, bool ignoreVision = false)
	{
		return null;
	}

	public bool HasAnyAttackableMonstersInRange(Vector3 center, float range, float minRange = 0f)
	{
		return false;
	}

	public bool IsAnyMonsterInGrid(Vector3Int pos, bool ignoreVision = false)
	{
		return false;
	}

	public List<AMonsterBase> GetMonstersInGrid(Vector3Int pos, bool ignoreVision = false)
	{
		return null;
	}

	public AMonsterBase GetMostProgressMonster(bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetHighestHPMonster(AMonsterBase excludeMonster = null, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetHighestHPMonster(List<AMonsterBase> list_Exclude = null, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetTargetByTowerPriority(eTowerTargetPriority type, Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetClosestMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false, bool ignoreVision = false)
	{
		return null;
	}

	public AMonsterBase GetFarthestMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetMostProgressMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetLeastProgressMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetHighestHPMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetLowestHPMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false)
	{
		return null;
	}

	public AMonsterBase GetRandomAttackableMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false)
	{
		return null;
	}

	public bool IsAnyMonsterInRange(Vector3 center, float range, float minRange = 0f, bool excludeFullPoison = false, bool ignoreVision = false)
	{
		return false;
	}

	public bool IsMonsterInVision(AMonsterBase monster)
	{
		return false;
	}
}
