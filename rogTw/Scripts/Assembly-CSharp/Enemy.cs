using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
	[SerializeField]
	private Renderer renderer;

	[SerializeField]
	private Pathfinder pathfinder;

	[SerializeField]
	private HealthBar healthBar;

	public GameObject deathObjectSpawn;

	[SerializeField]
	private BattleCry[] battleCries;

	[SerializeField]
	private GameObject treasureObject;

	[SerializeField]
	private Vector2 spawnRange;

	[SerializeField]
	private new string name = "";

	public int level = 1;

	public int damageToTower = 1;

	[SerializeField]
	private int bonusGoldDrop;

	[SerializeField]
	private bool dropsGold = true;

	[SerializeField]
	private int hpScaleDegree = 1;

	public int baseHealth;

	public int baseArmor;

	public int baseShield;

	public float baseSpeed;

	public int healthRegen;

	public int armorRegen;

	public int shieldRegen;

	public bool bleedImmune;

	public bool burnImmune;

	public bool poisonImmune;

	public bool slowImmune;

	private float timeSinceRegen;

	private float currentSpeed;

	private float currentSlowPercentage;

	private float hastePercentage;

	private float freezeTime;

	private float maxFreeze = 1f;

	private float fortifiedTime;

	private bool fortified;

	private int bleed;

	private int burn;

	private int poison;

	public bool bleeding;

	public bool burning;

	public bool poisoned;

	private float timeSinceBleed;

	private float timeSinceBurn;

	private float timeSincePoison;

	private float dotTick;

	private HashSet<TowerType> typesOfTowers = new HashSet<TowerType>();

	public Lookout mark;

	private bool dead;

	public int health { get; private set; }

	public int armor { get; private set; }

	public int shield { get; private set; }

	private void Start()
	{
		CheckBattleCries(BattleCry.BattleCryTrigger.Spawn);
		healthBar.UpdateFortified(fortifiedTime);
		healthBar.UpdateHaste(hastePercentage);
		healthBar.SetName(name);
		healthBar.SetImmunities(bleedImmune, burnImmune, poisonImmune);
		if (bonusGoldDrop == 0)
		{
			bonusGoldDrop = ResourceManager.instance.enemyBonusGoldDrop;
		}
		else
		{
			bonusGoldDrop += ResourceManager.instance.enemyBonusGoldDrop;
		}
	}

	public void SetStats()
	{
		SetStats(1);
	}

	public void SetStats(int multiplier)
	{
		health = (int)((float)(baseHealth * multiplier) * (1f + MonsterManager.instance.extraHealthPercentage));
		armor = (int)((float)(baseArmor * multiplier) * (1f + MonsterManager.instance.extraArmorPercentage));
		shield = (int)((float)(baseShield * multiplier) * (1f + MonsterManager.instance.extraShieldPercentage));
		currentSpeed = baseSpeed + MonsterManager.instance.speedBonus;
		pathfinder.speed = currentSpeed;
		healthBar.SetHealth(health + armor + shield, health, armor, shield, hpScaleDegree);
	}

	public void SetName(string _name)
	{
		name = _name;
		healthBar.SetName(_name);
	}

	public void SetFirstSpawnPoint(Waypoint point)
	{
		pathfinder.currentWaypoint = point;
	}

	private void Update()
	{
		if (fortifiedTime > 0f)
		{
			FortifiedUpdate();
		}
		if (currentSlowPercentage > 0f || hastePercentage > 0f || freezeTime > 0f)
		{
			SpeedUpdate();
		}
		DOTUpdate();
		RegenUpdate();
	}

	private void SpeedUpdate()
	{
		float num = freezeTime;
		freezeTime = Mathf.Max(0f, freezeTime - Time.deltaTime);
		currentSlowPercentage = Mathf.Max(0f, currentSlowPercentage - Time.deltaTime * 0.05f);
		hastePercentage = Mathf.Max(0f, hastePercentage - Time.deltaTime * 0.05f);
		if (freezeTime > 0f)
		{
			currentSpeed = 1E-06f;
		}
		else
		{
			currentSpeed = (baseSpeed + MonsterManager.instance.speedBonus) * (1f - currentSlowPercentage + hastePercentage);
		}
		pathfinder.speed = currentSpeed;
		if (freezeTime <= 0f && num > 0f && renderer != null)
		{
			renderer.material.color = Color.white;
		}
		healthBar.UpdateSlow(currentSlowPercentage);
		healthBar.UpdateHaste(hastePercentage);
	}

	public void CheckBattleCries(BattleCry.BattleCryTrigger cryType)
	{
		if (battleCries.Length != 0)
		{
			BattleCry[] array = battleCries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CheckBattleCry(cryType);
			}
		}
	}

	private void AddSlow(float newPercentage)
	{
		if (slowImmune)
		{
			currentSlowPercentage = 0f;
		}
		else
		{
			currentSlowPercentage = Mathf.Clamp(currentSlowPercentage + newPercentage, 0f, 0.6f + MonsterManager.instance.slowCapModifier);
		}
	}

	public void AddHaste(float amount)
	{
		hastePercentage = Mathf.Clamp(hastePercentage + amount, 0f, 0.6f + MonsterManager.instance.hasteCapModifier);
		if (OptionsMenu.instance.showConditionText)
		{
			DamageNumber component = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
			component.SetText("HASTED", "Grey", 1f);
			component.SetHoldTime(0.5f);
		}
	}

	public void Freeze()
	{
		freezeTime = maxFreeze;
		maxFreeze *= 0.8f;
		if (renderer != null)
		{
			renderer.material.color = Color.blue;
		}
		if (OptionsMenu.instance.showConditionText)
		{
			DamageNumber component = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
			component.SetText("FROZEN", "Grey", 1f);
			component.SetHoldTime(0.5f);
		}
	}

	private void FortifiedUpdate()
	{
		fortifiedTime = Mathf.Max(fortifiedTime - Time.deltaTime, 0f);
		if (fortifiedTime <= 0f)
		{
			fortified = false;
		}
		healthBar.UpdateFortified(fortifiedTime);
	}

	public void Fortify(float time)
	{
		fortifiedTime = Mathf.Clamp(fortifiedTime + time, 0f, 12f);
		healthBar.UpdateFortified(fortifiedTime);
		fortified = true;
		if (OptionsMenu.instance.showConditionText)
		{
			DamageNumber component = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
			component.SetText("FORTIFIED", "Grey", 1f);
			component.SetHoldTime(0.5f);
		}
	}

	private void RegenUpdate()
	{
		if (timeSinceRegen >= 1f)
		{
			if (healthRegen > 0 && health > 0)
			{
				HealHealth(healthRegen);
			}
			if (armorRegen > 0 && armor > 0)
			{
				HealArmor(armorRegen);
			}
			if (shieldRegen > 0 && shield > 0)
			{
				HealShield(shieldRegen);
			}
			timeSinceRegen = 0f;
		}
		else
		{
			timeSinceRegen += Time.deltaTime;
		}
	}

	public void HealHealth(int amount)
	{
		if (health >= baseHealth || bleeding)
		{
			if (bleeding && !bleedImmune)
			{
				DamageTracker.instance.AddDamage(TowerType.DOT, amount, 0, 0);
			}
			return;
		}
		if (health + amount >= baseHealth)
		{
			if (OptionsMenu.instance.showDamageNumbers)
			{
				DamageNumber component = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
				component.SetText("+" + (baseHealth - health), "Green", 1f);
				component.SetHoldTime(0.5f);
			}
			health = baseHealth;
		}
		else
		{
			health += amount;
			if (OptionsMenu.instance.showDamageNumbers)
			{
				DamageNumber component2 = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
				component2.SetText("+" + amount, "Green", 1f);
				component2.SetHoldTime(0.5f);
			}
		}
		if (healthBar != null)
		{
			healthBar.UpdateHealth(health, armor, shield, currentSlowPercentage, bleeding, burning, poisoned, bleed, burn, poison);
		}
	}

	public void HealArmor(int amount)
	{
		if (armor >= baseArmor || burning)
		{
			if (burning && !burnImmune)
			{
				DamageTracker.instance.AddDamage(TowerType.DOT, 0, amount, 0);
			}
			return;
		}
		if (armor + amount >= baseArmor)
		{
			if (OptionsMenu.instance.showDamageNumbers)
			{
				DamageNumber component = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
				component.SetText("+" + (baseArmor - armor), "Yellow", 1f);
				component.SetHoldTime(0.5f);
			}
			armor = baseArmor;
		}
		else
		{
			armor += amount;
			if (OptionsMenu.instance.showDamageNumbers)
			{
				DamageNumber component2 = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
				component2.SetText("+" + amount, "Yellow", 1f);
				component2.SetHoldTime(0.5f);
			}
		}
		if (healthBar != null)
		{
			healthBar.UpdateHealth(health, armor, shield, currentSlowPercentage, bleeding, burning, poisoned, bleed, burn, poison);
		}
	}

	public void HealShield(int amount)
	{
		if (shield >= baseShield || poisoned)
		{
			if (poisoned && !poisonImmune)
			{
				DamageTracker.instance.AddDamage(TowerType.DOT, 0, 0, amount);
			}
			return;
		}
		if (shield + amount >= baseShield)
		{
			if (OptionsMenu.instance.showDamageNumbers)
			{
				DamageNumber component = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
				component.SetText("+" + (baseShield - shield), "Blue", 1f);
				component.SetHoldTime(0.5f);
			}
			shield = baseShield;
		}
		else
		{
			shield += amount;
			if (OptionsMenu.instance.showDamageNumbers)
			{
				DamageNumber component2 = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
				component2.SetText("+" + amount, "Blue", 1f);
				component2.SetHoldTime(0.5f);
			}
		}
		if (healthBar != null)
		{
			healthBar.UpdateHealth(health, armor, shield, currentSlowPercentage, bleeding, burning, poisoned, bleed, burn, poison);
		}
	}

	public void ClenseBleed(int amount)
	{
		bleed = Mathf.Max(bleed - amount, 0);
		BleedCheck();
	}

	public void ClenseBurn(int amount)
	{
		burn = Mathf.Max(burn - amount, 0);
		BurnCheck();
	}

	public void ClensePoison(int amount)
	{
		poison = Mathf.Max(poison - amount, 0);
		PoisonCheck();
	}

	private void DOTUpdate()
	{
		if (dead)
		{
			return;
		}
		BleedCheck();
		BurnCheck();
		PoisonCheck();
		if (poisoned && timeSincePoison <= 0f && dotTick <= 0f)
		{
			int num = poison;
			poison = Mathf.Max(poison - (int)GameManager.instance.dotTick.z, 0);
			num -= poison;
			if (!poisonImmune)
			{
				int num2 = Mathf.Max(num / 2, 1);
				TakeDamage(TowerType.DOT, -999, num2, num2, num, 0f, 0f, 0f, 0f, 0f, 0f);
			}
			timeSincePoison = 1f;
			dotTick = 0.1f;
		}
		if (burning && timeSinceBurn <= 0f && dotTick <= 0f)
		{
			int num3 = burn;
			burn = Mathf.Max(burn - (int)(GameManager.instance.dotTick.y * Mathf.Max(1f + MonsterManager.instance.burnSpeedDamagePercentBonus * currentSlowPercentage, 1f)), 0);
			num3 -= burn;
			if (!burnImmune)
			{
				int num4 = num3 / 2;
				TakeDamage(TowerType.DOT, -999, num4, num3, num4, 0f, 0f, 0f, 0f, 0f, 0f);
			}
			timeSinceBurn = 1f;
			dotTick = 0.1f;
		}
		if (bleeding && timeSinceBleed <= 0f && dotTick <= 0f)
		{
			int num5 = bleed;
			bleed = Mathf.Max(bleed - (int)GameManager.instance.dotTick.x, 0);
			num5 -= bleed;
			if (!bleedImmune)
			{
				int num6 = num5 / 2;
				TakeDamage(TowerType.DOT, -999, num5, num6, num6, 0f, 0f, 0f, 0f, 0f, 0f);
			}
			timeSinceBleed = 1f;
			dotTick = 0.1f;
		}
		timeSinceBleed -= Time.deltaTime;
		timeSinceBurn -= Time.deltaTime;
		timeSincePoison -= Time.deltaTime;
		dotTick -= Time.deltaTime;
		healthBar.UpdateBleed(bleeding, bleed);
		healthBar.UpdateBurn(burning, burn);
		healthBar.UpdatePoison(poisoned, poison);
	}

	private int FortifiedCheck()
	{
		if (fortified)
		{
			return 5 + MonsterManager.instance.fortificationBonus;
		}
		return 0;
	}

	private int BleedCheck()
	{
		if (bleed > 0)
		{
			bleeding = true;
			if (!bleedImmune)
			{
				return 1 + MonsterManager.instance.bonusDamageOnBleed;
			}
			return 0;
		}
		bleeding = false;
		return 0;
	}

	private int BurnCheck()
	{
		if (burn > 0)
		{
			burning = true;
			if (!burnImmune)
			{
				return 1 + MonsterManager.instance.bonusDamageOnBurn;
			}
			return 0;
		}
		burning = false;
		return 0;
	}

	private int PoisonCheck()
	{
		if (poison > 0)
		{
			poisoned = true;
			if (!poisonImmune)
			{
				return 1 + MonsterManager.instance.bonusDamageOnPoison;
			}
			return 0;
		}
		poisoned = false;
		return 0;
	}

	private int FreezeDmgCheck()
	{
		if (freezeTime > 0f)
		{
			return MonsterManager.instance.bonusDamageOnStun;
		}
		return 0;
	}

	public float CurrentHealth()
	{
		return (float)(health + armor + shield) / (float)(baseHealth + baseArmor + baseShield);
	}

	public void TakeDamage(TowerType whoHitMe, int _baseDmg, int healthDmg, int armorDmg, int shieldDmg, float slowPercentage, float bleedPercentage, float burnPercentage, float poisonPercentage, float critChance, float stunChance)
	{
		if (dead)
		{
			Debug.Log("Dead enemy taking damage");
			return;
		}
		typesOfTowers.Add(whoHitMe);
		if (Random.Range(0f, 1f) < stunChance && freezeTime <= 0f)
		{
			Freeze();
		}
		float num = critChance;
		float num2 = critChance;
		if (_baseDmg > -1 && BleedCheck() > 0)
		{
			num += MonsterManager.instance.bleedingCritChance;
			num2 += MonsterManager.instance.bleedingCritChance;
			if (mark != null)
			{
				num += mark.critChance;
			}
		}
		int num3 = _baseDmg;
		string text = "";
		float num4 = 1f;
		float num5 = Random.Range(0f, 1f);
		float num6 = Random.Range(0f, 1f);
		float num7 = Random.Range(0f, 1f);
		if (num7 < Mathf.Min(num - 1f, 0.5f))
		{
			num3 *= 4;
			text = "!!!";
			num4 = 2.5f;
			SFXManager.instance.PlaySound(Sound.CritBig, base.transform.position);
		}
		else if (num6 < Mathf.Min(num - 0.5f, 0.5f))
		{
			num3 *= 3;
			text = "!!";
			num4 = 2f;
			SFXManager.instance.PlaySound(Sound.CritBig, base.transform.position);
		}
		else if (num5 < Mathf.Min(num, 0.5f))
		{
			num3 *= 2;
			text = "!";
			num4 = 1.5f;
			SFXManager.instance.PlaySound(Sound.CritBig, base.transform.position);
		}
		int num8 = _baseDmg;
		if (num7 < Mathf.Min(num2 - 1f, 0.5f))
		{
			num8 *= 4;
		}
		else if (num6 < Mathf.Min(num2, 0.5f))
		{
			num8 *= 3;
		}
		else if (num5 < Mathf.Min(num2, 0.5f))
		{
			num8 *= 2;
		}
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		string color;
		if (shield > 0)
		{
			num10 = Mathf.Max(num8 - FortifiedCheck() + FreezeDmgCheck(), 1) * (shieldDmg + PoisonCheck());
			num9 = Mathf.Max(num3 - FortifiedCheck() + (int)MarkCheck().x + FreezeDmgCheck(), 1) * (shieldDmg + PoisonCheck() + (int)MarkCheck().w);
			if (num9 > shield)
			{
				num11 = (int)((float)(num9 - shield) / (float)shieldDmg);
			}
			shield -= num9;
			color = "Blue";
			if (num9 - num10 > 0)
			{
				DamageTracker.instance.AddDamage(TowerType.Lookout, 0, 0, num9 - num10);
				DamageTracker.instance.AddDamage(whoHitMe, 0, 0, num10);
			}
			else
			{
				DamageTracker.instance.AddDamage(whoHitMe, 0, 0, num9);
			}
			shield = Mathf.Max(shield, 0);
			if (shield == 0)
			{
				CheckBattleCries(BattleCry.BattleCryTrigger.ShieldBreak);
			}
		}
		else if (armor > 0)
		{
			num10 = Mathf.Max(num8 - FortifiedCheck() + FreezeDmgCheck(), 1) * (armorDmg + BurnCheck());
			num9 = Mathf.Max(num3 - FortifiedCheck() + (int)MarkCheck().x + FreezeDmgCheck(), 1) * (armorDmg + BurnCheck() + (int)MarkCheck().z);
			if (num9 > armor)
			{
				num11 = (int)((float)(num9 - armor) / (float)armorDmg);
			}
			armor -= num9;
			color = "Yellow";
			if (num9 - num10 > 0)
			{
				DamageTracker.instance.AddDamage(TowerType.Lookout, 0, num9 - num10, 0);
				DamageTracker.instance.AddDamage(whoHitMe, 0, num10, 0);
			}
			else
			{
				DamageTracker.instance.AddDamage(whoHitMe, 0, num9, 0);
			}
			armor = Mathf.Max(armor, 0);
			if (armor == 0)
			{
				CheckBattleCries(BattleCry.BattleCryTrigger.ArmorBreak);
			}
		}
		else
		{
			num10 = Mathf.Max(num8 - FortifiedCheck() + FreezeDmgCheck(), 1) * (healthDmg + BleedCheck());
			num9 = Mathf.Max(num3 - FortifiedCheck() + (int)MarkCheck().x + FreezeDmgCheck(), 1) * (healthDmg + BleedCheck() + (int)MarkCheck().y);
			if (num9 >= health)
			{
				if (num9 - num10 > 0 && num10 < health)
				{
					DamageTracker.instance.AddDamage(TowerType.Lookout, Mathf.Max(health - num10, 0), 0, 0);
					DamageTracker.instance.AddDamage(whoHitMe, num10, 0, 0);
				}
				else
				{
					DamageTracker.instance.AddDamage(whoHitMe, health, 0, 0);
				}
			}
			else if (num9 - num10 > 0)
			{
				DamageTracker.instance.AddDamage(TowerType.Lookout, num9 - num10, 0, 0);
				DamageTracker.instance.AddDamage(whoHitMe, num10, 0, 0);
			}
			else
			{
				DamageTracker.instance.AddDamage(whoHitMe, num9, 0, 0);
			}
			health -= num9;
			color = "Red";
		}
		if (OptionsMenu.instance.showDamageNumbers)
		{
			DamageNumber component = ObjectPool.instance.SpawnObject(ObjectPool.ObjectType.DamageNumber, base.transform.position, Quaternion.identity).GetComponent<DamageNumber>();
			component.SetText(num9 + text, color, num4);
			component.SetHoldTime(0.25f);
		}
		if (health <= 0)
		{
			Die();
			return;
		}
		bleed += (int)((float)num9 * bleedPercentage);
		burn += (int)((float)num9 * burnPercentage);
		poison += (int)((float)num9 * poisonPercentage);
		if (slowPercentage > 0f)
		{
			AddSlow((float)num9 * slowPercentage / 100f);
		}
		if (poisonPercentage > 0f)
		{
			AddSlow(MonsterManager.instance.poisonSlowPercent * poisonPercentage * (float)num9 / 100f);
		}
		if (num4 > 1f && _baseDmg > -1 && MonsterManager.instance.bleedPop > 0f && !dead)
		{
			int num12 = (int)((float)bleed * MonsterManager.instance.bleedPop);
			bleed -= num12;
			TakeDamage(TowerType.DOT, -999, num12, num12 / 2, num12 / 2, 0f, 0f, 0f, 0f, 0f, 0f);
		}
		if (num4 > 1f && _baseDmg > -1 && MonsterManager.instance.burnPop > 0f && !dead)
		{
			int num13 = (int)((float)burn * MonsterManager.instance.burnPop);
			burn -= num13;
			TakeDamage(TowerType.DOT, -999, num13 / 2, num13, num13 / 2, 0f, 0f, 0f, 0f, 0f, 0f);
		}
		if (num4 > 1f && _baseDmg > -1 && MonsterManager.instance.poisonPop > 0f && !dead)
		{
			int num14 = (int)((float)poison * MonsterManager.instance.poisonPop);
			poison -= num14;
			TakeDamage(TowerType.DOT, -999, num14 / 2, num14 / 2, num14, 0f, 0f, 0f, 0f, 0f, 0f);
		}
		if (healthBar != null)
		{
			healthBar.UpdateHealth(health, armor, shield, currentSlowPercentage, bleeding, burning, poisoned, bleed, burn, poison);
		}
		if (num11 > 0 && !dead)
		{
			TakeDamage(whoHitMe, num11, healthDmg, armorDmg, shieldDmg, slowPercentage, bleedPercentage, burnPercentage, poisonPercentage, 0f, 0f);
		}
	}

	private Vector4 MarkCheck()
	{
		Vector4 zero = Vector4.zero;
		if (mark != null)
		{
			zero.x = mark.damage;
			zero.y = mark.healthDamage;
			zero.z = mark.armorDamage;
			zero.w = mark.shieldDamage;
		}
		return zero;
	}

	public Vector3 GetFuturePosition(float t)
	{
		float distance = currentSpeed * t;
		return pathfinder.GetFuturePosition(distance);
	}

	public void AtEnd()
	{
		GameManager.instance.TakeDamage(damageToTower + MonsterManager.instance.extraTowerDamage);
		SpawnManager.instance.currentEnemies.Remove(this);
		Object.Destroy(base.gameObject);
	}

	private void Die()
	{
		if (dead)
		{
			return;
		}
		dead = true;
		if (deathObjectSpawn != null)
		{
			Object.Instantiate(deathObjectSpawn, base.transform.position, Quaternion.identity);
		}
		if (treasureObject != null && spawnRange.y > 0f)
		{
			int numberOfDrops = Random.Range((int)spawnRange.x, (int)spawnRange.y + GameManager.instance.gameMode);
			Object.Instantiate(treasureObject, base.transform.position, Quaternion.identity).GetComponent<TreasureChest>().numberOfDrops = numberOfDrops;
		}
		CheckBattleCries(BattleCry.BattleCryTrigger.Death);
		typesOfTowers.Remove(TowerType.DOT);
		if (dropsGold)
		{
			int num = level + typesOfTowers.Count + bonusGoldDrop + MonsterManager.instance.extraGoldDrop + MonsterManager.instance.goldDropPenalty;
			if (num < 0)
			{
				num = 0;
			}
			ResourceManager.instance.AddMoney(num);
			ResourceManager.instance.AddManaPercentMax(MonsterManager.instance.manaDropOnDeath);
			DamageTracker.instance.AddIncome(DamageTracker.IncomeType.Monster, Mathf.Max(num - MonsterManager.instance.extraGoldDrop, 0));
			DamageTracker.instance.AddIncome(DamageTracker.IncomeType.Penalty, MonsterManager.instance.goldDropPenalty);
			DamageTracker.instance.AddIncome(DamageTracker.IncomeType.Bonus, MonsterManager.instance.extraGoldDrop);
		}
		SpawnManager.instance.currentEnemies.Remove(this);
		SFXManager.instance.PlaySound(Sound.CoinLong, base.transform.position);
		AchievementManager.instance.EnemyKilled();
		Object.Destroy(base.gameObject);
	}
}
