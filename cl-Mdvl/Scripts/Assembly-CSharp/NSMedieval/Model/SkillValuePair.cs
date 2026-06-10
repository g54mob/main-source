using System;
using NSMedieval.StatsSystem;

namespace NSMedieval.Model
{
	[Serializable]
	public class SkillValuePair : SerializablePair<SkillType, float>
	{
		public SkillValuePair()
		{
		}

		public SkillValuePair(SkillType skill, float value)
			: base(skill, value)
		{
		}
	}
}
