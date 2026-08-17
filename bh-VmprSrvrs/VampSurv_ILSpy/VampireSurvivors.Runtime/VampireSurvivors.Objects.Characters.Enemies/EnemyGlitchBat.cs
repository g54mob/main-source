using System;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyGlitchBat : EnemyController
{
	protected override void Die()
	{
		base.Die();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			BackgroundManager fancyBg2 = stage2._fancyBg;
			if (fancyBg2._003CxxlBatsDefeated_003Ek__BackingField >= 0)
			{
				GameManager core3 = GM.Core;
				Stage stage3 = core3._stage;
				BackgroundManager fancyBg3 = stage3._fancyBg;
				int num = fancyBg3._003CxxlBatsDefeated_003Ek__BackingField + 1;
				fancyBg3._003CxxlBatsDefeated_003Ek__BackingField = num;
			}
		}
	}
}
