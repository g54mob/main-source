using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_Familiar_Brownie : CharacterSkillCard_Base
	{
		public CharacterType followerType;

		public SubSkillCard_Familiar_Brownie(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}
	}
}
