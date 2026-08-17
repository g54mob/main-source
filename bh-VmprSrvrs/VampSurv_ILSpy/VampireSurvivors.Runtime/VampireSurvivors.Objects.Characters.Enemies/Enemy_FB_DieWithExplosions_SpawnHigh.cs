using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_FB_DieWithExplosions_SpawnHigh : Enemy_FB_DieWithExplosions
{
	protected override void OnRecycleEnemy()
	{
		//IL_007e: Expected O, but got F4
		//IL_008c: Expected O, but got F4
		base.OnRecycleEnemy();
		object obj = UnityEngine.Random.value;
		object obj2 = UnityEngine.Random.value;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (stageData._003CisRacingStage_003Ek__BackingField)
		{
			float2 float5 = base.position;
			float2 float6 = default(float2);
			base.position = float6;
		}
	}
}
