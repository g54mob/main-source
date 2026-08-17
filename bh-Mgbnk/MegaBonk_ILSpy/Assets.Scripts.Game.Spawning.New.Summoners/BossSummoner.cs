using System.Collections.Generic;
using Actors.Enemies;

namespace Assets.Scripts.Game.Spawning.New.Summoners;

public class BossSummoner : BaseSummoner
{
	public BossSummoner(int id, List<EEnemy> defaultEnemies)
		: base(id, defaultEnemies)
	{
	}

	protected override void Init()
	{
	}

	protected override List<EEnemy> GetEnemies()
	{
		return null;
	}

	public override float GetSummonInterval()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override float GetBaseCreditsPerSecond()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override float GetInitialCredits()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override int GetNumTargetEnemies()
	{
		return 0;
	}

	protected override bool UseDirectionBias()
	{
		return false;
	}

	protected override bool ForceSpawn()
	{
		return true;
	}
}
