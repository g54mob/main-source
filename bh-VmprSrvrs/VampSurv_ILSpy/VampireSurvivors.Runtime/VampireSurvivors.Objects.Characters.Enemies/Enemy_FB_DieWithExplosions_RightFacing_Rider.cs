using UnityEngine;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_FB_DieWithExplosions_RightFacing_Rider : Enemy_FB_DieWithExplosions
{
	protected override void OnUpdate()
	{
		base.OnUpdate();
		bool flag = GM.Core.IsStageVisuallyInverted();
		bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		base.SetFlipX(flag2);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (stageData._003CisRacingStage_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			Transform target = base.transform;
			stage2._fancyBg.ContainWithinRacingBounds(target);
		}
	}
}
