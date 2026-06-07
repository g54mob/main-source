using System;
using Pathfinding;
using UnityEngine;

[Serializable]
public class Spawn
{
	public float delay;

	public GameObject enemyPrefab;

	public bool eliteEnemies;

	public int count;

	public float interval;

	public Transform spawnLine;

	public int goldCoins;

	private int[] goldCoinsPerEnemy;

	[HideInInspector]
	public float waitBeforeNextSpawn;

	private int spawnedUnits;

	private bool finished;

	private bool tauntTheTiger;

	private bool tauntTheTurtle;

	private bool tauntTheFalcon;

	private bool antiAirTelescope;

	private bool prayToWarGods;

	private bool godOfChaos;

	private bool tauntTheGrowth;

	private bool tauntTheRange;

	private bool godOfAfterlife;

	private float addDmgGrowthDiffPerWave;

	private float addHpGrowthDiffPerWave;

	private Hp hpTemp;

	public int SpawnedUnits => spawnedUnits;

	public bool Finished => finished;

	public Spawn()
	{
	}

	public Spawn(GameObject _enemyPrefab, Transform _spawnLine, int _count = 1, float _interval = 0.5f, int _goldCoins = 0, float _delay = 0f, bool _eliteEnemies = false)
	{
		enemyPrefab = _enemyPrefab;
		spawnLine = _spawnLine;
		count = _count;
		interval = _interval;
		goldCoins = _goldCoins;
		delay = _delay;
		eliteEnemies = _eliteEnemies;
	}

	public void Reset(bool _resetGold = true)
	{
		tauntTheTiger = PerkManager.IsEquipped(PerkManager.instance.tigerGodPerk);
		tauntTheTurtle = PerkManager.IsEquipped(PerkManager.instance.turtleGodPerk);
		tauntTheFalcon = PerkManager.IsEquipped(PerkManager.instance.falconGodPerk);
		antiAirTelescope = PerkManager.IsEquipped(PerkManager.instance.antiAirTelescope);
		prayToWarGods = PerkManager.IsEquipped(PerkManager.instance.prayToWarGods);
		godOfChaos = PerkManager.instance.GodOfChaosEquipped;
		tauntTheGrowth = PerkManager.instance.GrowthGodEquipped;
		tauntTheRange = PerkManager.instance.RangeGodEquipped;
		godOfAfterlife = PerkManager.instance.GodOfAfterlifeEquipped;
		addDmgGrowthDiffPerWave = Mathf.Pow(PerkManager.instance.growthGodMaxDamageMulti, 1f / (float)Mathf.Max(1, EnemySpawner.instance.WaveCount - 1));
		addHpGrowthDiffPerWave = Mathf.Pow(PerkManager.instance.growthGodMaxHpMulti, 1f / (float)Mathf.Max(1, EnemySpawner.instance.WaveCount - 1));
		waitBeforeNextSpawn = delay;
		spawnedUnits = 0;
		finished = false;
		goldCoinsPerEnemy = new int[count];
		int num = goldCoins;
		for (int i = 0; i < num; i++)
		{
			goldCoinsPerEnemy[UnityEngine.Random.Range(0, goldCoinsPerEnemy.Length)] = 0;
		}
		if (_resetGold)
		{
			for (int j = 0; j < num; j++)
			{
				goldCoinsPerEnemy[UnityEngine.Random.Range(0, goldCoinsPerEnemy.Length)]++;
			}
		}
	}

	public void Update(float difficultyMulti = 1f)
	{
		if (finished)
		{
			return;
		}
		waitBeforeNextSpawn -= Time.deltaTime;
		if (waitBeforeNextSpawn > 0f)
		{
			return;
		}
		waitBeforeNextSpawn = interval;
		TaggedObject componentInChildren = enemyPrefab.GetComponentInChildren<TaggedObject>();
		if (componentInChildren == null)
		{
			enemyPrefab.SetActive(value: true);
			finished = true;
			return;
		}
		bool flag = componentInChildren.Tags.Contains(TagManager.ETag.Flying);
		NNConstraint constraint = (componentInChildren.Tags.Contains(TagManager.ETag.LargeUnit) ? EnemySpawner.instance.groundConstraintLarge : (flag ? EnemySpawner.instance.flyingConstraint : EnemySpawner.instance.groundConstraint));
		Vector3 vector = GetRandomPointOnSpawnLine(flag, constraint);
		bool flag2 = godOfChaos & !componentInChildren.Tags.Contains(TagManager.ETag.Exploding);
		if (flag2)
		{
			Vector3 vector2 = (flag ? (Vector3.up * 5f) : Vector3.zero);
			vector = Vector3.Lerp(vector, CastleCenter.CastleCenterPosition + vector2, (float)(spawnedUnits % 5) / 5f);
		}
		GameObject gameObject;
		TaggedObject taggedObject;
		if (enemyPrefab.scene.isLoaded)
		{
			gameObject = enemyPrefab;
			taggedObject = enemyPrefab.GetComponentInChildren<TaggedObject>();
			gameObject.SetActive(value: true);
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate(enemyPrefab, vector, Quaternion.identity);
			taggedObject = gameObject.GetComponent<TaggedObject>();
			EnemySpawnManager instance = EnemySpawnManager.instance;
			if ((bool)instance.weaponOnSpawn)
			{
				instance.weaponOnSpawn.Attack(gameObject.transform.position + Vector3.up * instance.weaponAttackHeight, null, Vector3.forward, taggedObject);
			}
		}
		if (goldCoinsPerEnemy.Length > spawnedUnits)
		{
			gameObject.GetComponentInChildren<Hp>().coinCount = goldCoinsPerEnemy[spawnedUnits];
		}
		Hp componentInChildren2 = gameObject.GetComponentInChildren<Hp>();
		float num = difficultyMulti;
		float num2 = Mathf.Lerp(1f, difficultyMulti, 0.5f);
		float num3 = 1f;
		float num4 = 1f;
		float num5 = 1f;
		float num6 = 1f;
		if (eliteEnemies)
		{
			num *= 4f;
			num2 *= 3f;
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (meshRenderer.sharedMaterial.name == "Enemy")
				{
					meshRenderer.sharedMaterial = ColorAndLightManager.EliteEnemyMaterial;
				}
			}
			componentInChildren2.Elite = true;
		}
		if (tauntTheTurtle)
		{
			num *= PerkManager.instance.tauntTheTurtle_hpMultiplyer;
		}
		if (tauntTheTiger)
		{
			num2 *= PerkManager.instance.tauntTheTiger_damageMultiplyer;
		}
		if (tauntTheFalcon)
		{
			num4 *= PerkManager.instance.tauntTheFalcon_speedMultiplyer;
			num5 *= PerkManager.instance.tauntTheFalcon_chasePlayerTimeMultiplyer;
		}
		if (antiAirTelescope && taggedObject.Tags.Contains(TagManager.ETag.Flying))
		{
			num *= PerkManager.instance.antiAir_helathMultiplyer;
			num2 *= PerkManager.instance.antiAir_damageMultiplyer;
		}
		if (godOfAfterlife && spawnedUnits % 2 == 0 && taggedObject.Tags.Contains(TagManager.ETag.Humanoid))
		{
			componentInChildren2.enemyToSpawnOnDeath = PerkManager.instance.godOfAfterlifeEnemy;
		}
		if (prayToWarGods)
		{
			num2 *= PerkManager.instance.prayWarGods_dmgMulti;
			num *= PerkManager.instance.prayWarGods_hpMulti;
		}
		if (tauntTheGrowth)
		{
			num2 *= Mathf.Pow(addDmgGrowthDiffPerWave, EnemySpawner.instance.Wavenumber);
			num *= Mathf.Pow(addHpGrowthDiffPerWave, EnemySpawner.instance.Wavenumber);
		}
		if (tauntTheRange && taggedObject.Tags.Contains(TagManager.ETag.RangedFighter) && !taggedObject.Tags.Contains(TagManager.ETag.Flying))
		{
			num *= PerkManager.instance.rangeGodHealthMultiplyer;
			num2 *= PerkManager.instance.rangeGodDamageMultiplyer;
			num3 *= PerkManager.instance.rangeGodAttackCooldownMultiplyer;
			num4 *= PerkManager.instance.rangeGodMoveSpeedMultiplyer;
			num6 *= PerkManager.instance.rangeGodRangeMultiplyer;
		}
		componentInChildren2.HpOriginal = componentInChildren2.maxHp;
		if (num != 1f && componentInChildren2 != null)
		{
			componentInChildren2.maxHp *= num;
			componentInChildren2.SetHpToMaxHp();
		}
		if (num2 != 1f || num3 != 1f || num6 != 1f || godOfChaos)
		{
			AutoAttack[] componentsInChildren2 = gameObject.GetComponentsInChildren<AutoAttack>();
			foreach (AutoAttack autoAttack in componentsInChildren2)
			{
				if (flag2)
				{
					autoAttack.SetCooldownTo(3f);
				}
				autoAttack.DamageMultiplyer *= num2;
				autoAttack.cooldownDuration *= num3;
				if (num6 == 1f)
				{
					continue;
				}
				if (autoAttack.GetType() == typeof(AutoAttackWithWarning))
				{
					((AutoAttackWithWarning)autoAttack).breakTargetingDistance *= num6;
				}
				foreach (TargetPriority targetPriority in autoAttack.targetPriorities)
				{
					targetPriority.range *= num6;
				}
			}
		}
		if (num4 != 1f || num5 != 1f || num6 != 1f)
		{
			PathfindMovementEnemy[] componentsInChildren3 = gameObject.GetComponentsInChildren<PathfindMovementEnemy>();
			foreach (PathfindMovementEnemy obj in componentsInChildren3)
			{
				obj.movementSpeed *= num4;
				obj.agroTimeWhenAttackedByPlayer *= num5;
				obj.keepDistanceOf *= num6;
			}
		}
		EnemySpawner.totalEnemiesSpawnedThisWave++;
		spawnedUnits++;
		if (spawnedUnits >= count)
		{
			finished = true;
		}
	}

	public Vector3 GetRandomPointOnSpawnLine(bool flying, NNConstraint constraint)
	{
		float num = GetTotalSpawnLineLength() * UnityEngine.Random.value;
		Vector3 vector = (flying ? (Vector3.up * 5f) : Vector3.zero);
		float num2 = 0f;
		for (int i = 0; i < spawnLine.childCount - 1; i++)
		{
			float magnitude = (spawnLine.GetChild(i).position - spawnLine.GetChild(i + 1).position).magnitude;
			if (magnitude != 0f)
			{
				if (magnitude + num2 >= num)
				{
					num -= num2;
					float t = num / magnitude;
					return Vector3.Lerp(spawnLine.GetChild(i).position, spawnLine.GetChild(i + 1).position, t) + vector;
				}
				num2 += magnitude;
			}
		}
		if (spawnLine.childCount > 0)
		{
			return spawnLine.GetChild(0).position + vector;
		}
		return spawnLine.position;
	}

	public float GetTotalSpawnLineLength()
	{
		float num = 0f;
		for (int i = 0; i < spawnLine.childCount - 1; i++)
		{
			num += (spawnLine.GetChild(i).position - spawnLine.GetChild(i + 1).position).magnitude;
		}
		return num;
	}

	public static void AdjustEnemyParametersAfterSpawn(GameObject enemy, bool elite)
	{
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		float num4 = 1f;
		float num5 = 1f;
		float num6 = 1f;
		TaggedObject componentInChildren = enemy.GetComponentInChildren<TaggedObject>();
		Hp componentInChildren2 = enemy.GetComponentInChildren<Hp>();
		bool num7 = PerkManager.IsEquipped(PerkManager.instance.turtleGodPerk);
		bool flag = PerkManager.IsEquipped(PerkManager.instance.tigerGodPerk);
		bool flag2 = PerkManager.IsEquipped(PerkManager.instance.falconGodPerk);
		bool flag3 = PerkManager.IsEquipped(PerkManager.instance.antiAirTelescope);
		bool flag4 = PerkManager.IsEquipped(PerkManager.instance.prayToWarGods);
		bool growthGodEquipped = PerkManager.instance.GrowthGodEquipped;
		bool rangeGodEquipped = PerkManager.instance.RangeGodEquipped;
		if (num7)
		{
			num *= PerkManager.instance.tauntTheTurtle_hpMultiplyer;
		}
		if (flag)
		{
			num2 *= PerkManager.instance.tauntTheTiger_damageMultiplyer;
		}
		if (flag2)
		{
			num4 *= PerkManager.instance.tauntTheFalcon_speedMultiplyer;
			num5 *= PerkManager.instance.tauntTheFalcon_chasePlayerTimeMultiplyer;
		}
		if (flag3 && componentInChildren.Tags.Contains(TagManager.ETag.Flying))
		{
			num *= PerkManager.instance.antiAir_helathMultiplyer;
			num2 *= PerkManager.instance.antiAir_damageMultiplyer;
		}
		if (flag4)
		{
			num2 *= PerkManager.instance.prayWarGods_dmgMulti;
			num *= PerkManager.instance.prayWarGods_hpMulti;
		}
		if (growthGodEquipped)
		{
			float f = Mathf.Pow(PerkManager.instance.growthGodMaxDamageMulti, 1f / (float)Mathf.Max(1, EnemySpawner.instance.WaveCount - 1));
			float f2 = Mathf.Pow(PerkManager.instance.growthGodMaxHpMulti, 1f / (float)Mathf.Max(1, EnemySpawner.instance.WaveCount - 1));
			num2 *= Mathf.Pow(f, EnemySpawner.instance.Wavenumber);
			num *= Mathf.Pow(f2, EnemySpawner.instance.Wavenumber);
		}
		if (rangeGodEquipped && componentInChildren.Tags.Contains(TagManager.ETag.RangedFighter) && !componentInChildren.Tags.Contains(TagManager.ETag.Flying))
		{
			num *= PerkManager.instance.rangeGodHealthMultiplyer;
			num2 *= PerkManager.instance.rangeGodDamageMultiplyer;
			num3 *= PerkManager.instance.rangeGodAttackCooldownMultiplyer;
			num4 *= PerkManager.instance.rangeGodMoveSpeedMultiplyer;
			num6 *= PerkManager.instance.rangeGodRangeMultiplyer;
		}
		if (elite)
		{
			num *= 4f;
			num2 *= 3f;
			MeshRenderer[] componentsInChildren = enemy.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (meshRenderer.sharedMaterial.name == "Enemy")
				{
					meshRenderer.sharedMaterial = ColorAndLightManager.EliteEnemyMaterial;
				}
			}
			componentInChildren2.Elite = true;
		}
		if (componentInChildren2 != null)
		{
			componentInChildren2.HpOriginal = componentInChildren2.maxHp;
			componentInChildren2.maxHp *= num;
			componentInChildren2.SetHpToMaxHp();
		}
		AutoAttack[] componentsInChildren2 = enemy.GetComponentsInChildren<AutoAttack>();
		foreach (AutoAttack autoAttack in componentsInChildren2)
		{
			autoAttack.DamageMultiplyer *= num2;
			autoAttack.cooldownDuration *= num3;
			if (num6 == 1f)
			{
				continue;
			}
			if (autoAttack is AutoAttackWithWarning autoAttackWithWarning)
			{
				autoAttackWithWarning.breakTargetingDistance *= num6;
			}
			foreach (TargetPriority targetPriority in autoAttack.targetPriorities)
			{
				targetPriority.range *= num6;
			}
		}
		PathfindMovementEnemy[] componentsInChildren3 = enemy.GetComponentsInChildren<PathfindMovementEnemy>();
		foreach (PathfindMovementEnemy obj in componentsInChildren3)
		{
			obj.movementSpeed *= num4;
			obj.agroTimeWhenAttackedByPlayer *= num5;
			obj.keepDistanceOf *= num6;
		}
	}
}
