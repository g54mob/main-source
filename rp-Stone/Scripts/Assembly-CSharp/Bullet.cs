using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Character
{
	public bool drawDebugCollision;

	public int initialDelay;

	public int multiHitCount = 1;

	public int multiHitDelay = 5;

	public float velocity = 1f;

	public bool dieOnImpact = true;

	public float chanceToMiss;

	public int pushback;

	public int aoeX;

	public int aoeZ;

	public int bonusDamage;

	public string[] bonusDamageTo;

	public List<StatModifier> statModifiersToApply;

	public float normalCamShakeAmount;

	public float criticalCamShakeAmount = 2f;

	public float normalSloMoDuration;

	public float criticalSloMoDuration = 3f;

	public float camShakeDuration = 0.1f;

	public AsciiSprite impactDeathSprite;

	public AsciiSprite lifetimeEndedSprite;

	public string impactSfx;

	public string missSfx;

	private Character owner;

	private int elapsedMoveTicsH;

	private float elapsedMovement;

	private int damageAmount;

	private List<Character> targetsToIgnore = new List<Character>();

	protected int startX;

	protected int startY;

	protected int startZ;

	private static Dictionary<string, StatModifier> _workStatMods = new Dictionary<string, StatModifier>();

	private bool hasSloMotioned;

	private bool hasLifeStolen;

	public bool isAoe { get; set; }

	public Character Owner
	{
		get
		{
			return owner;
		}
		set
		{
			owner = value;
		}
	}

	public Weapon weapon { get; set; }

	public Character target { get; set; }

	public static event Action<Bullet> OnLifetimeEnded;

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (!Alive || initialDelay-- > 0)
		{
			return;
		}
		bool flag = tags.Contains("enemy");
		elapsedMovement += velocity;
		while (elapsedMovement >= 1f)
		{
			elapsedMovement -= 1f;
			if (flag)
			{
				base.PositionX--;
			}
			else
			{
				base.PositionX++;
			}
		}
		if (flag)
		{
			TestCollisionWithHero();
		}
		else
		{
			TestCollisionWithEnemies();
		}
	}

	public virtual void TestCollision()
	{
		if (tags.Contains("enemy"))
		{
			TestCollisionWithHero();
		}
		else
		{
			TestCollisionWithEnemies();
		}
	}

	protected virtual void TestCollisionWithHero()
	{
		Hero hero = GameStates.Singleton.hero;
		if (TestCollisionWith(hero))
		{
			Damage dmg = CreateDamage();
			InflictDamageTo(dmg, hero);
			if (dieOnImpact)
			{
				MultiHitOrDie();
			}
			else
			{
				targetsToIgnore.Add(hero);
			}
		}
	}

	protected virtual void TestCollisionWithEnemies()
	{
		for (int i = 0; i < GameStates.Singleton.level.Enemies.Count; i++)
		{
			Enemy enemy = GameStates.Singleton.level.Enemies[i];
			if (!TestCollisionWith(enemy))
			{
				continue;
			}
			if (!isAoe || aoeX <= 0 || aoeZ <= 0)
			{
				Damage dmg = CreateDamage();
				InflictDamageTo(dmg, enemy);
			}
			else
			{
				List<Enemy> list = new List<Enemy>();
				for (int j = 0; j < GameStates.Singleton.level.Enemies.Count; j++)
				{
					Enemy enemy2 = GameStates.Singleton.level.Enemies[j];
					if (enemy2.Alive && !targetsToIgnore.Contains(enemy2))
					{
						int num = Mathf.Abs(enemy2.PositionX - base.PositionX);
						int num2 = Mathf.Abs(enemy2.PositionZ - base.PositionZ);
						int num3 = (enemy2.CollisionWidth + base.CollisionWidth) / 2 + aoeX;
						int num4 = (enemy2.CollisionDepth + base.CollisionDepth) / 2 + aoeZ;
						if (num < num3 && num2 < num4)
						{
							list.Add(enemy2);
						}
					}
				}
				for (int k = 0; k < list.Count; k++)
				{
					Enemy enemy3 = list[k];
					Damage damage = CreateDamage();
					damage.targetCountHit = list.Count;
					InflictDamageTo(damage, enemy3);
					if (!dieOnImpact)
					{
						targetsToIgnore.Add(enemy3);
					}
				}
			}
			if (dieOnImpact)
			{
				MultiHitOrDie();
				break;
			}
			targetsToIgnore.Add(enemy);
		}
	}

	protected bool TestCollisionWith(Character character)
	{
		if (!character.Alive)
		{
			return false;
		}
		if (targetsToIgnore.Contains(character))
		{
			return false;
		}
		if (base.PositionX + (base.CollisionWidth >> 1) >= character.PositionX && base.PositionX - (base.CollisionWidth >> 1) <= character.PositionX + character.CollisionWidth)
		{
			int num = Mathf.Abs(character.PositionZ - base.PositionZ);
			int num2 = (character.CollisionDepth + base.CollisionDepth) / 2;
			if (num < num2)
			{
				bool flag = false;
				for (int i = 0; i < character.immuneTo.Count; i++)
				{
					if (!string.IsNullOrEmpty(character.immuneTo[i]) && tags.Contains(character.immuneTo[i]))
					{
						flag = true;
						break;
					}
				}
				if (!flag && !tags.Contains("cannot_miss"))
				{
					float num3 = character.baseChanceToEvade;
					if (character.statModController != null)
					{
						num3 = character.statModController.ModChanceToEvade(num3);
					}
					num3 += chanceToMiss;
					if (num3 > 0f && UnityEngine.Random.Range(0f, 100f) <= num3)
					{
						flag = true;
						Character.FireOnEvaded(character, this);
					}
				}
				if (!flag)
				{
					return true;
				}
				targetsToIgnore.Add(character);
				SfxController.singleton.Play(missSfx);
				if (!tags.Contains("melee"))
				{
					character.ShowFloatingText(Te.xt("MISSED"));
				}
			}
		}
		return false;
	}

	protected virtual Damage CreateDamage()
	{
		Damage damage = new Damage();
		damage.Owner = owner;
		damage.bullet = this;
		damage.amount = damageAmount;
		damage.tags = tags;
		if (weapon != null)
		{
			float criticalChance = 0f;
			weapon.ForEachStatModController(delegate(StatModController controller)
			{
				criticalChance = controller.ModCriticalChance(criticalChance);
			});
			if (criticalChance > 0f && UnityEngine.Random.Range(0f, 100f) <= criticalChance)
			{
				float multiplier = 0f;
				weapon.ForEachStatModController(delegate(StatModController controller)
				{
					multiplier = controller.ModCriticalMultiplier(multiplier);
				});
				damage.isCritical = true;
				damage.criticalMultiplier = Mathf.Max(1f, multiplier);
			}
		}
		return damage;
	}

	public virtual int EstimateDamageTo(Weapon weapon, Character character)
	{
		if (character.IsInvulnerable())
		{
			return 0;
		}
		Damage dmg = new Damage();
		dmg.amount = weapon.baseDamage;
		dmg.AddBonusDamageForCharacter(character, bonusDamage, bonusDamageTo);
		if (weapon != null)
		{
			weapon.ForEachStatModController(delegate(StatModController controller)
			{
				controller.ModDamage(dmg, character);
			});
		}
		return dmg.amount;
	}

	protected virtual void InflictDamageTo(Damage dmg, Character character)
	{
		if (character.IsInvulnerable())
		{
			dmg.amount = 0;
		}
		else
		{
			dmg.AddBonusDamageForCharacter(character, bonusDamage, bonusDamageTo);
			if (weapon != null)
			{
				weapon.ForEachStatModController(delegate(StatModController controller)
				{
					controller.ModDamage(dmg, character);
				});
			}
			if (dmg.amount > 0 && dmg.isCritical)
			{
				if (character.immuneTo.Contains("critical"))
				{
					dmg.isCritical = false;
				}
				else
				{
					dmg.amount = Mathf.RoundToInt((float)dmg.amount * dmg.criticalMultiplier);
				}
			}
		}
		if (statModifiersToApply.Count > 0 && character.Alive)
		{
			for (int num = 0; num < statModifiersToApply.Count; num++)
			{
				StatModifier statModifier = statModifiersToApply[num];
				string key = statModifier.id;
				if (_workStatMods.ContainsKey(key))
				{
					_workStatMods[key].ticDuration += statModifier.ticDuration;
					continue;
				}
				StatModifier statModifier2 = UnityEngine.Object.Instantiate(statModifier);
				statModifier2.abilityData = statModifiersToApply[num].abilityData;
				statModifier2.statData = statModifiersToApply[num].statData;
				statModifier2.character = character;
				statModifier2.sourceItem = weapon;
				statModifier2.cleansable = true;
				statModifier2.Init();
				character.AddStatModifier(statModifier2);
				_workStatMods.Add(key, statModifier2);
			}
			_workStatMods.Clear();
		}
		character.InflictDamage(dmg);
		DidDamageCharacter(dmg, character);
		if (!hasSloMotioned && dmg.amount > 0)
		{
			float num2 = normalCamShakeAmount;
			float num3 = normalSloMoDuration;
			if (dmg.isCritical)
			{
				num2 = criticalCamShakeAmount;
				num3 = criticalSloMoDuration;
			}
			if (num2 > 0f)
			{
				CameraShake.singleton.ShakeCamera(num2, camShakeDuration);
			}
			if (num3 > 0f)
			{
				SlowMotion.singleton.Add(num3);
			}
			hasSloMotioned = true;
		}
		if (pushback != 0 && !character.tags.Contains("unpushable"))
		{
			int num4 = Mathf.Min(character.PositionX + pushback, GameStates.Singleton.level.GetEnemyLimitX(character));
			character.PositionX = num4;
		}
		if (dmg.amount > 0 && weapon != null && !hasLifeStolen)
		{
			float chanceToLifesteal = 0f;
			weapon.ForEachStatModController(delegate(StatModController controller)
			{
				chanceToLifesteal = controller.ModChanceToLifesteal(chanceToLifesteal);
			});
			float num5 = UnityEngine.Random.Range(0f, 100f);
			if (chanceToLifesteal > 0f && num5 <= chanceToLifesteal)
			{
				Damage damage = new Damage();
				damage.Owner = Owner;
				damage.amount = 1;
				damage.tags.Add("lifesteal");
				if (chanceToLifesteal > 100f && num5 < chanceToLifesteal - 100f)
				{
					damage.amount++;
				}
				Owner.ApplyHeal(damage);
				SfxController.singleton.Play("life_gain");
				hasLifeStolen = true;
			}
		}
		SfxController.singleton.Play(impactSfx);
	}

	private void MultiHitOrDie()
	{
		if (multiHitCount > 1)
		{
			multiHitCount--;
			initialDelay = multiHitDelay;
			base.PositionX = startX;
			base.PositionY = startY;
			base.PositionZ = startZ;
			targetsToIgnore.Clear();
		}
		else
		{
			Die(DeathReason.ProjectileImpacted);
		}
	}

	public void SetDamage(int amount)
	{
		damageAmount = amount;
	}

	protected virtual void DidDamageCharacter(Damage dmg, Character character)
	{
	}

	protected override void Awake()
	{
		base.Awake();
		if (sortTiebreaker < 0)
		{
			sortTiebreaker = 20;
		}
	}

	public override void Init()
	{
		base.Init();
		startX = base.PositionX;
		startY = base.PositionY;
		startZ = base.PositionZ;
	}

	public override void Die(DeathReason reason)
	{
		base.Die(reason);
		AsciiAnimation asciiAnimation = null;
		if (impactDeathSprite != null && reason == DeathReason.ProjectileImpacted)
		{
			impactDeathSprite.Load();
			asciiAnimation = impactDeathSprite.GetComponent<AsciiAnimation>();
			if (base.gameObject.GetComponent<AsciiSpritePPRainbow>() != null)
			{
				impactDeathSprite.gameObject.AddComponent<AsciiSpritePPRainbow>();
			}
			else
			{
				impactDeathSprite.colorOverride = base.colorTint;
			}
		}
		else if (reason == DeathReason.LifetimeEnded)
		{
			if (lifetimeEndedSprite != null)
			{
				lifetimeEndedSprite.Load();
				asciiAnimation = lifetimeEndedSprite.GetComponent<AsciiAnimation>();
			}
			if (Bullet.OnLifetimeEnded != null)
			{
				Bullet.OnLifetimeEnded(this);
			}
		}
		if (asciiAnimation != null)
		{
			asciiAnimation.Play();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (Alive)
		{
			base.Draw(r, offsetX, offsetY);
			DrawDebugCollision(r, offsetX, offsetY);
			return;
		}
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (impactDeathSprite != null && base.deathReason == DeathReason.ProjectileImpacted)
		{
			impactDeathSprite.Draw(r, offsetX, offsetY);
		}
		else if (lifetimeEndedSprite != null && base.deathReason == DeathReason.LifetimeEnded)
		{
			lifetimeEndedSprite.Draw(r, offsetX, offsetY);
		}
	}

	private void DrawDebugCollision(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!drawDebugCollision)
		{
			return;
		}
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		int num = offsetX - base.CollisionWidth / 2;
		int y = offsetY;
		for (int i = 0; i < base.CollisionWidth; i++)
		{
			AsciiCellProcedural cell = r.GetCell(num, y);
			if (cell != null)
			{
				int value = cell.GetValue();
				cell.SetValue(value, r.defaultForegroundColor, Color.magenta);
			}
			num++;
		}
	}

	private void OnDestroy()
	{
		owner = null;
		weapon = null;
		targetsToIgnore = null;
		target = null;
	}
}
