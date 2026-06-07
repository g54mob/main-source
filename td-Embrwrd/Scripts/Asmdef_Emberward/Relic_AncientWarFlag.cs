using System.Collections.Generic;
using UnityEngine;

public class Relic_AncientWarFlag : ARelicBase
{
	private struct BuffData
	{
		public float RemainingTime;
	}

	[SerializeField]
	private float buffRange;

	[SerializeField]
	private float buffDuration;

	[SerializeField]
	private float attackSpeedMultiplier;

	private readonly Dictionary<ABaseTower, BuffData> activeBuffs;

	private readonly List<ABaseTower> iterationBuffer;

	private int modifierId;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void OnTowerKillMonster(ABaseTower tower, AMonsterBase monster)
	{
	}

	private bool ApplyOrRefreshBuff(ABaseTower tower)
	{
		return false;
	}

	private void OnBuffedTowerDespawn(ABaseTower tower)
	{
	}

	private void RemoveBuff(ABaseTower tower)
	{
	}

	private void ClearAllBuffs()
	{
	}
}
