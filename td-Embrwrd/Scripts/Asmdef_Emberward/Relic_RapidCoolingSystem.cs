using UnityEngine;

public class Relic_RapidCoolingSystem : ARelicBase
{
	[SerializeField]
	private float triggerChance;

	private float cooldownTimer;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void HandleTowerKillMonster(ABaseTower tower, AMonsterBase monster)
	{
	}
}
