public class RequiredSkillLevel : Requirement
{
	public Skill skill;

	public SkillType skillType;

	public EntityId skillId;

	public int targetLevel;

	public RequiredSkillLevel(SkillType type, EntityId id, int level)
	{
		skillType = type;
		skillId = id;
		targetLevel = level;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredSkillLevel(skillType, skillId.GetCopy(), targetLevel);
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		if (town.townSkills.TryGetValue(skillType, out var value) && value.TryGetValue(skillId, out var value2))
		{
			skill = value2;
		}
	}

	public override bool IsMet()
	{
		return CurrentCount() >= targetLevel;
	}

	public int CurrentCount()
	{
		Skill skill = this.skill;
		if (skill == null && GameManager.Instance.activeTown.townSkills.TryGetValue(skillType, out var value) && value.TryGetValue(skillId, out var value2))
		{
			skill = value2;
		}
		return skill?.level ?? 0;
	}

	public override string ToString()
	{
		return "Required Skill level " + skillType.ToString() + " for " + skillId.ToString() + " level " + targetLevel;
	}
}
