using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnSkip_CooldownDown : CharacterSkillCard_Base
	{
		public SubSkillCard_OnSkip_CooldownDown(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerLevelUpSkipped()
		{
		}
	}
}
