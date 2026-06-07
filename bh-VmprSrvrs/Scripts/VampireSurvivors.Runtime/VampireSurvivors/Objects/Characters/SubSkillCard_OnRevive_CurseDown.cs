using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_OnRevive_CurseDown : CharacterSkillCard_Base
	{
		public SubSkillCard_OnRevive_CurseDown(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
		{
		}
	}
}
