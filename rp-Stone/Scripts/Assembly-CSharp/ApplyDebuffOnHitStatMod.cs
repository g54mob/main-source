using UnityEngine;

public class ApplyDebuffOnHitStatMod : StatModifier
{
	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (dmg.bullet != null && dmg.bullet.weapon == base.sourceItem)
		{
			ApplyTo(this, c);
		}
	}

	public static void ApplyTo(StatModifier instigator, Character target)
	{
		if (!target.Alive)
		{
			return;
		}
		if (instigator == null)
		{
			Utils.LogError("[1] Something is wrong with ApplyDebuffOnHitStatMod");
			return;
		}
		if (instigator.statData == null)
		{
			Utils.LogError("[2] Something is wrong with ApplyDebuffOnHitStatMod, " + instigator, instigator.gameObject);
			return;
		}
		if (instigator.statData.customParams == null || instigator.statData.customParams.Length == 0)
		{
			Utils.LogError("Missing custom params to specify which debuff to apply.");
			return;
		}
		string text = "Weapons/StatModifiers/" + instigator.statData.customParams[0];
		GameObject gameObject = Utils.InstantiatePrefab(text);
		if (gameObject == null)
		{
			return;
		}
		DebuffStatMod component = gameObject.GetComponent<DebuffStatMod>();
		if (component != null)
		{
			component.abilityData = instigator.abilityData;
			component.sourceItem = instigator.sourceItem;
			component.character = target;
			if (component.howToApplyParent == DebuffStatMod.HowToApplyParent.CopyStats)
			{
				component.replacementStat.baseValue = instigator.statData.baseValue;
				component.replacementStat.levelMult = instigator.statData.levelMult;
				component.replacementStat.minValue = instigator.statData.minValue;
				component.replacementStat.floorResult = instigator.statData.floorResult;
			}
			else if (component.howToApplyParent == DebuffStatMod.HowToApplyParent.ComputeAsDuration)
			{
				float num = ItemFactory.GetLevelDisplayValueForItem(instigator.sourceItem);
				if (component.abilityData != null && component.abilityData.applyRarity)
				{
					num += (float)component.sourceItem.GetRarityBonus();
				}
				component.ticDuration = Mathf.CeilToInt(instigator.abilityData.stat.Compute(num, 30f));
			}
			component.statData = component.replacementStat;
			component.Init();
			target.AddStatModifier(component);
		}
		else
		{
			Utils.LogError(instigator.id + " could not apply debuff " + text);
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.End();
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.OnDestroy();
	}
}
