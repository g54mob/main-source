using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.StatsSystem;

namespace NSMedieval.Repository
{
	public class SkillLevelsRepository : DynamicJsonRepository<SkillLevelsRepository, SkillLevels>
	{
		private readonly float[] emptyLevels = new float[0];

		private Dictionary<SkillType, SkillLevels> skillLevelsBySkillType;

		public float[] GetXpRequirements(SkillType skill)
		{
			TryInitCache();
			if (!skillLevelsBySkillType.ContainsKey(skill))
			{
				return emptyLevels;
			}
			return skillLevelsBySkillType[skill].Levels;
		}

		public float GetXpRequirement(SkillType skill, int level)
		{
			if (level < 0)
			{
				return 0f;
			}
			float[] xpRequirements = GetXpRequirements(skill);
			if (xpRequirements.Length > level)
			{
				return xpRequirements[level];
			}
			return 0f;
		}

		public int GetCurrentLevel(SkillType skill, float amountXp)
		{
			float[] xpRequirements = GetXpRequirements(skill);
			int result = 0;
			for (int i = 0; i < xpRequirements.Length; i++)
			{
				if (amountXp >= xpRequirements[i])
				{
					result = i;
				}
			}
			return result;
		}

		protected override string JsonFile()
		{
			return "Worker/SkillLevels.json";
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TryInitCache()
		{
			if (skillLevelsBySkillType != null)
			{
				return;
			}
			skillLevelsBySkillType = new Dictionary<SkillType, SkillLevels>();
			foreach (SkillLevels item in repository)
			{
				if (!skillLevelsBySkillType.ContainsKey(item.SkillId))
				{
					skillLevelsBySkillType.Add(item.SkillId, item);
				}
			}
		}
	}
}
