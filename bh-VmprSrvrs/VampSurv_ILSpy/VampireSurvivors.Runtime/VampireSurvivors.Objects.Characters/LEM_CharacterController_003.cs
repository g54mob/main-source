using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class LEM_CharacterController_003 : LEM_CharacterController_Base
{
	private float triggerChance;

	private float bossHealthMultiplier = 0.5f;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		if (core._bossAttacksTriggerChance > triggerChance)
		{
			core._bossAttacksTriggerChance = triggerChance;
		}
		GameManager core2 = GM.Core;
		if (core2._bossHealthMultiplier > bossHealthMultiplier)
		{
			core2._bossHealthMultiplier = bossHealthMultiplier;
		}
		GiveSurvarocchi();
	}
}
