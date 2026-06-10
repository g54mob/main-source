using System;
using NSMedieval.StatsSystem;

namespace NSMedieval.Model
{
	[Serializable]
	public class SkillLevelPair : SerializablePair<SkillType, int>
	{
		public SkillLevelPair()
		{
		}

		public SkillLevelPair(SkillType skill, int value)
			: base(skill, value)
		{
		}
	}
}
