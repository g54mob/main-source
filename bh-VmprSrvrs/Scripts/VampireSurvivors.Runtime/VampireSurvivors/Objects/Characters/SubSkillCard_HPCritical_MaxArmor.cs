using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_HPCritical_MaxArmor : CharacterSkillCard_Base
	{
		public SubSkillCard_HPCritical_MaxArmor(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}

		public override void OnOwnerCriticalHPTreshold(float rawDamage)
		{
		}
	}
}
