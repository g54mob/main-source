using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Passive_Disable(ArcanaType type) : CharacterSkillCard_Base(type)
{
	private float triggerChance = 0.5f;

	public override void InitialActivate()
	{
		base.InitialActivate();
		GameManager core = GM.Core;
		float bossAttacksTriggerChance = core._bossAttacksTriggerChance;
		if (core._bossAttacksTriggerChance > triggerChance)
		{
			bossAttacksTriggerChance = triggerChance;
		}
		if (core._bossAttacksTriggerChance > bossAttacksTriggerChance)
		{
			core._bossAttacksTriggerChance = bossAttacksTriggerChance;
		}
	}
}
