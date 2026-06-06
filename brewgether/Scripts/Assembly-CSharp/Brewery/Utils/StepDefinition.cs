using Brewery.Buffs;
using Brewery.Skills;

namespace Brewery.Utils
{
	public struct StepDefinition
	{
		public string name;

		public float baseDuration;

		public SkillType skill;

		public BuffType buff;

		public StepDefinition(string name, float baseDuration, SkillType skill, BuffType buff)
		{
			this.name = null;
			this.baseDuration = 0f;
			this.skill = default(SkillType);
			this.buff = default(BuffType);
		}
	}
}
