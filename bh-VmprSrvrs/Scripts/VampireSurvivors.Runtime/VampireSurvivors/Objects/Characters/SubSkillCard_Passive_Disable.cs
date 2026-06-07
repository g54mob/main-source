using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_Passive_Disable : CharacterSkillCard_Base
	{
		private float triggerChance;

		public SubSkillCard_Passive_Disable(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}
	}
}
