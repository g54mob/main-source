using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_HPCritical_FireBreath : CharacterSkillCard_Base
	{
		public SubSkillCard_HPCritical_FireBreath(ArcanaType type)
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
