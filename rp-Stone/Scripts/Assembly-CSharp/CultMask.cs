using UnityEngine;

public class CultMask : Weapon
{
	private WeaponActivatedAbility activatedAbility;

	private int extendCounter;

	public override void HandleEquipped()
	{
		base.HandleEquipped();
		Cosmetic cosmetic = GetCosmetic();
		if (cosmetic == null || cosmetic.AllowsRarityColor(this))
		{
			ItemData.Rarity.Type rarityType = GetRarityType();
			GameStates.Singleton.hero.baseBodyColor = ItemData.Rarity.GetColorForRarity(rarityType);
		}
	}

	public override void HandleUnequipped()
	{
		base.HandleUnequipped();
		GameStates.Singleton.hero.baseBodyColor = Color.white;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		Hero hero = GameStates.Singleton.hero;
		int positionX = hero.PositionX;
		for (int i = 0; i < GameStates.Singleton.level.Enemies.Count; i++)
		{
			Enemy enemy = GameStates.Singleton.level.Enemies[i];
			if (enemy.tags != null && enemy.PositionX - positionX <= 60 && enemy.tags.Contains("cult"))
			{
				enemy.wakeupDistance = 1;
			}
		}
		extendCounter++;
		if (!(hero.statModController != null))
		{
			return;
		}
		int num = Mathf.FloorToInt(activatedAbility.ComputeStatWithId("extend_buffs"));
		if (num >= 1 && extendCounter >= num)
		{
			extendCounter = 0;
			StatModifier oldestBuff = hero.statModController.GetOldestBuff();
			if (oldestBuff != null && oldestBuff.ticDuration > 0)
			{
				oldestBuff.ticDuration++;
				CultMaskGoals.singleton.ReportBuffExtended();
			}
		}
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (!(base.Owner != null) || dmg == null || !(dmg.Owner == GameStates.Singleton.hero))
		{
			return;
		}
		Enemy enemy = c as Enemy;
		if (!(enemy != null) || enemy.wakeupDistance != 1 || enemy.tags == null || !enemy.tags.Contains("cult"))
		{
			return;
		}
		GameStates singleton = GameStates.Singleton;
		int positionX = singleton.hero.PositionX;
		for (int i = 0; i < singleton.level.Enemies.Count; i++)
		{
			Enemy enemy2 = singleton.level.Enemies[i];
			if (enemy2.tags != null && enemy2.PositionX - positionX <= 50 && enemy2.tags.Contains("cult"))
			{
				enemy2.WakeUp();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		activatedAbility = GetComponent<WeaponActivatedAbility>();
		Character.OnCharacterDied += HandleCharacterDied;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
		base.OnDestroy();
	}
}
