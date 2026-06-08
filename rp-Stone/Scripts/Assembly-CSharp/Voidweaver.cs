using UnityEngine;

public class Voidweaver : Summon
{
	public UnstableStatMod unstablePrefab;

	public AsciiAnimation superAttackAnim;

	private readonly int RANGE = 30;

	public int summonDamage { get; set; }

	public int unstableDuration { get; set; }

	public float unstableArmorGain { get; set; }

	public float unstableChance { get; set; }

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState != State.Attacking || base.stateElapsedTics != 15)
		{
			return;
		}
		GameStates singleton = GameStates.Singleton;
		Hero hero = GameStates.Singleton.hero;
		base.sourceWeapon.GetComponent<WeaponActivatedAbility>();
		Damage damage = new Damage();
		damage.type = Damage.Type.Super;
		damage.amount = summonDamage;
		damage.Owner = this;
		damage.showFloatingText = true;
		damage.tags.Add("aether_talisman");
		damage.tags.Add("summon_basic");
		damage.tags.Add("AEther");
		for (int num = singleton.level.Enemies.Count - 1; num >= 0; num--)
		{
			Enemy enemy = singleton.level.Enemies[num];
			if (enemy.Alive && enemy.PositionX < hero.PositionX + RANGE)
			{
				enemy.InflictDamage(damage);
				AddDebuffUnstable(enemy, unstablePrefab);
			}
		}
	}

	public UnstableStatMod AddDebuffUnstable(Character target, UnstableStatMod unstablePrefab)
	{
		if (!target.Alive)
		{
			return null;
		}
		base.sourceWeapon.GetComponent<WeaponActivatedAbility>();
		UnstableStatMod unstableStatMod = Object.Instantiate(unstablePrefab);
		if (unstableStatMod != null)
		{
			unstableStatMod.sourceItem = base.weapon;
			unstableStatMod.character = target;
			unstableStatMod.OnDestroyed += HandleUnstableDestroyed;
			unstableStatMod.ticDuration = unstableDuration;
			unstableStatMod.element = ItemData.Element.AEther;
			unstableStatMod.statData = unstableStatMod.replacementStat;
			unstableStatMod.statData.baseValue = unstableChance;
			unstableStatMod.armorToGain = unstableArmorGain;
			unstableStatMod.Init();
			target.AddStatModifier(unstableStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + unstablePrefab?.ToString() + " for super ability " + this);
		}
		return unstableStatMod;
	}

	private void HandleUnstableDestroyed(StatModifier debuff)
	{
		debuff.OnDestroyed -= HandleUnstableDestroyed;
	}

	private void AddActivatedAbility()
	{
		DynamicActivatedAbilityProvider component = base.owner.GetComponent<DynamicActivatedAbilityProvider>();
		VoidweaverDevourAbility component2 = GetComponent<VoidweaverDevourAbility>();
		component.Add(component2);
		GameStates.Singleton.abilityActivationHUD.UpdateContents();
	}

	private void RemoveActivatedAbility()
	{
		if (base.owner != null)
		{
			DynamicActivatedAbilityProvider component = base.owner.GetComponent<DynamicActivatedAbilityProvider>();
			VoidweaverDevourAbility component2 = GetComponent<VoidweaverDevourAbility>();
			component.Remove(component2);
			GameStates.Singleton.abilityActivationHUD.UpdateContents();
		}
	}

	public override void Die(DeathReason reason)
	{
		base.Die(reason);
	}

	protected override void Start()
	{
		base.Start();
		AddActivatedAbility();
		if (base.sourceWeapon != null)
		{
			WeaponActivatedAbility component = base.sourceWeapon.GetComponent<WeaponActivatedAbility>();
			if (component != null)
			{
				summonDamage = Mathf.FloorToInt(component.ComputeStatWithId("summon_damage"));
				unstableDuration = Mathf.FloorToInt(30f * component.ComputeStatWithId("unstable_duration"));
				unstableChance = component.ComputeStatWithId("unstable_chance");
				unstableArmorGain = component.ComputeStatWithId("unstable_armor");
				VoidweaverDevourAbility component2 = GetComponent<VoidweaverDevourAbility>();
				component2.devourArmor = unstableArmorGain;
				component2.cooldown = Mathf.RoundToInt(component.ComputeStatWithId("devour_cooldown") * 30f);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
	}

	protected override void OnDestroy()
	{
		RemoveActivatedAbility();
		base.OnDestroy();
	}
}
