using System.Collections.Generic;

public class RequiredSkillLevelCount : Requirement
{
	public SkillType skillType;

	public int targetLevel;

	public int targetCount;

	private Town debugCachedTown;

	private Dictionary<SkillType, Dictionary<EntityId, Skill>> cachedSkillDictionary;

	public RequiredSkillLevelCount(SkillType type, int targetLevel, int targetCount)
	{
		skillType = type;
		this.targetLevel = targetLevel;
		this.targetCount = targetCount;
		TryAddToProcessingQueue();
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		cachedSkillDictionary = town.townSkills;
		debugCachedTown = town;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= targetCount;
	}

	public int CurrentCount()
	{
		int num = 0;
		Dictionary<SkillType, Dictionary<EntityId, Skill>> townSkills = cachedSkillDictionary;
		if (townSkills == null)
		{
			townSkills = GameManager.Instance.activeTown.townSkills;
		}
		if (townSkills != null)
		{
			if (skillType == SkillType.None)
			{
				foreach (KeyValuePair<SkillType, Dictionary<EntityId, Skill>> item in townSkills)
				{
					foreach (KeyValuePair<EntityId, Skill> item2 in item.Value)
					{
						if (item2.Value.level >= targetLevel)
						{
							num++;
						}
					}
				}
			}
			else
			{
				bool flag = false;
				if (townSkills.TryGetValue(skillType, out var value))
				{
					foreach (KeyValuePair<EntityId, Skill> item3 in value)
					{
						if (item3.Value.level >= targetLevel)
						{
							num++;
						}
					}
				}
			}
		}
		return num;
	}
}
