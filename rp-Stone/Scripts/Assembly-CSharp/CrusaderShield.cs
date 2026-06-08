using UnityEngine;

public class CrusaderShield : Weapon
{
	private WeaponActivatedAbility activatedAbility;

	public DebuffStatMod sanctityBuffPrefab;

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		Hero hero = GameStates.Singleton.hero;
		if (dmg.amount > 0 && dmg.Owner != null && c == hero)
		{
			AddBuff(c, sanctityBuffPrefab);
		}
	}

	private DebuffStatMod AddBuff(Character target, DebuffStatMod debuffPrefab)
	{
		if (!target.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			Hero hero = GameStates.Singleton.hero;
			debuffStatMod.sourceItem = this;
			debuffStatMod.character = hero;
			debuffStatMod.maxStack = Mathf.FloorToInt(activatedAbility.ComputeStatWithId("sanctity_stacks"));
			debuffStatMod.ticDuration = Mathf.FloorToInt(30f * activatedAbility.ComputeStatWithId("sanctity_duration"));
			debuffStatMod.element = ItemData.Element.Vigor;
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.Init();
			target.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for super ability " + this);
		}
		return debuffStatMod;
	}

	public override void HandleEquipped()
	{
		base.HandleEquipped();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void HandleUnequipped()
	{
		base.HandleUnequipped();
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
	}

	protected override void Awake()
	{
		base.Awake();
		activatedAbility = GetComponent<WeaponActivatedAbility>();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}
}
