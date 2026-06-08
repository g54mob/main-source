using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyApplyDebuffOnDeath : MonoBehaviour
{
	public DebuffStatMod debuffToApply;

	public int deathDelayApply;

	public int minRange = -2;

	public int maxRange = 10;

	public int baseDuration;

	public int durationPerLevel;

	public string sfxOnApply;

	private Enemy myCharacter;

	private int elapsedDeathTics;

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage damage)
	{
		Hero hero = GameStates.Singleton.hero;
		if (c == myCharacter && hero.Alive && (reason == Character.DeathReason.DamageTaken || reason == Character.DeathReason.Custom))
		{
			if (deathDelayApply <= 0)
			{
				TryApplyDebuff();
			}
			else
			{
				myCharacter.OnUpdateTic += HandleDeathUpdateTic;
			}
		}
	}

	private void HandleDeathUpdateTic(Character c)
	{
		elapsedDeathTics++;
		if (elapsedDeathTics == deathDelayApply)
		{
			myCharacter.OnUpdateTic -= HandleDeathUpdateTic;
			TryApplyDebuff();
		}
	}

	private void TryApplyDebuff()
	{
		Hero hero = GameStates.Singleton.hero;
		if (hero.Alive)
		{
			int num = myCharacter.PositionX - hero.PositionX;
			if (num >= minRange && num <= maxRange)
			{
				int duration = baseDuration + durationPerLevel * myCharacter.level;
				ApplyDebuff(debuffToApply, hero, duration);
			}
		}
	}

	private DebuffStatMod ApplyDebuff(DebuffStatMod debuffPrefab, Character target, int duration)
	{
		DebuffStatMod debuffStatMod = Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.character = target;
			debuffStatMod.element = myCharacter.GetElement();
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.ticDuration = duration;
			debuffStatMod.Init();
			target.AddStatModifier(debuffStatMod);
			FloatingText floatingText = target.ShowFloatingText(ItemData.CharForElement(debuffStatMod.element).ToString());
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.red;
			}
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for " + this);
		}
		return debuffStatMod;
	}

	private void Awake()
	{
		myCharacter = GetComponent<Enemy>();
		Character.OnCharacterDied += HandleCharacterDied;
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
		myCharacter.OnUpdateTic -= HandleDeathUpdateTic;
	}
}
