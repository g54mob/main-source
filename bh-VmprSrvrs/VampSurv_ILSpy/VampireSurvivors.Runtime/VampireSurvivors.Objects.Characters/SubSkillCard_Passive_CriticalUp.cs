using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Passive_CriticalUp : CharacterSkillCard_Base
{
	public SubSkillCard_Passive_CriticalUp(ArcanaType type)
		: base(type)
	{
	}

	public override void InitialActivate()
	{
		base.InitialActivate();
		float critMul = ArcanaManager.CritMul + 1f;
		ArcanaManager.CritMul = critMul;
	}
}
