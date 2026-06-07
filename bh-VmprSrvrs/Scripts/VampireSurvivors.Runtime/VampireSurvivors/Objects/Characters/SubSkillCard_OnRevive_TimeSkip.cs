using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnRevive_TimeSkip : CharacterSkillCard_Base
	{
		public SubSkillCard_OnRevive_TimeSkip(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
		{
		}
	}
}
