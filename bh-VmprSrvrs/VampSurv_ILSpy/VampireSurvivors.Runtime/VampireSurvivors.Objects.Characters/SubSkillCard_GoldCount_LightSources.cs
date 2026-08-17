using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_GoldCount_LightSources : CharacterSkillCard_Base
{
	protected override int[] bonusTresholds => new int[3] { 500, 1000, 2000 };

	public SubSkillCard_GoldCount_LightSources(ArcanaType type)
		: base(type)
	{
	}

	public override void Update()
	{
		base.Update();
		Update_CountGold();
	}

	protected override void OnGoldCountReached()
	{
		GameManager core = GM.Core;
		core._stage.DebugSpawnDestructibles();
	}
}
