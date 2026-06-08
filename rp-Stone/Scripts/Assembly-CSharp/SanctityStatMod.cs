using System.Collections.Generic;

public class SanctityStatMod : DebuffStatMod
{
	private int sanctityCounter;

	public override void Init()
	{
		base.Init();
	}

	public override void End()
	{
		base.End();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		Hero hero = GameStates.Singleton.hero;
		sanctityCounter++;
		if (!(hero.statModController != null))
		{
			return;
		}
		int num = 10;
		if (num < 1 || sanctityCounter < num)
		{
			return;
		}
		sanctityCounter = 0;
		for (int i = 0; i < hero.statModController.debuffs.Count; i++)
		{
			List<StatModifier> list = hero.statModController.debuffs[i];
			for (int j = 0; j < list.Count; j++)
			{
				StatModifier statModifier = list[j];
				if (!statModifier.isPositiveBuff && statModifier.GetRemainingTics() > 0)
				{
					statModifier.ticDuration--;
					CrusaderShieldGoals.singleton.ReportDebuffExpired(statModifier.GetRemainingTics());
					CrusaderShieldGoals.singleton.ReportDebuffDecay();
				}
			}
		}
	}
}
