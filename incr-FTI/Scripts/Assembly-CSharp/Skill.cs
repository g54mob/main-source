using UnityEngine.Events;

public class Skill
{
	public readonly SkillType skillType;

	public EntityId skillId;

	public float skillGainRate;

	public readonly LevelStat experience;

	public double lastSkillGained;

	public Upgrade productionUpgrade;

	public Upgrade skillGainSpeedUpgrade;

	public ResearchState skillGainSpeedResearch;

	public UnityAction levelUpDelegate;

	public int level => experience.level;

	public double skillValueAccrued => experience.points;

	public float currentLevelFloor => experience.currentLevelFloor;

	public float currentLevelCeil => experience.currentLevelCeil;

	public Skill(SkillType type, EntityId id)
	{
		skillType = type;
		skillId = id.GetCopy();
		experience = new LevelStat(ItemType.SkillExperiencePoint, 100f, 0.3f, 100f);
	}

	public void Reset()
	{
		experience.Reset();
		skillGainRate = 1f;
	}

	public void Increment(double workUnits)
	{
		experience.GainPoints(workUnits * (double)skillGainRate, calcProgress: false);
		while (skillValueAccrued >= (double)currentLevelCeil)
		{
			LevelUp();
		}
	}

	public void CalcSkillGainRate()
	{
		float num = 1f;
		float multiplier = skillGainSpeedUpgrade.GetMultiplier();
		float num2 = GameManager.Instance.MultiplierForGlobalPerk(PerkType.SkillGainSpeed);
		float num3 = 1f;
		if (skillGainSpeedResearch != null)
		{
			num3 = GameManager.MultiplierForResearch(skillGainSpeedResearch.type, skillGainSpeedResearch.numCompleted);
		}
		skillGainRate = num * multiplier * num2 * num3;
	}

	public void LevelUp()
	{
		experience.GainLevel();
		levelUpDelegate?.Invoke();
	}

	public float ProductionMultiplier()
	{
		float num = 1f;
		if (productionUpgrade != null)
		{
			num = productionUpgrade.GetMultiplier();
		}
		float num2 = 0.1f;
		return 1f + (float)level * num2 * num;
	}

	public override string ToString()
	{
		return "Skill " + skillType.ToString() + " " + skillId;
	}
}
