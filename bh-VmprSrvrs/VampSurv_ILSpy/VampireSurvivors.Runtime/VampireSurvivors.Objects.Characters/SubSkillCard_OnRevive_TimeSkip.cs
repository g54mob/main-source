using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnRevive_TimeSkip : CharacterSkillCard_Base
{
	public SubSkillCard_OnRevive_TimeSkip(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		base.OnOwnerRevived(percentage, instantRevival);
		GameManager core = GM.Core;
		float num = core._003CSurvivedSeconds_003Ek__BackingField + 60f;
		core._003CSurvivedSeconds_003Ek__BackingField = num;
		GameManager core2 = GM.Core;
		core2._stage.CheckMinute();
	}
}
