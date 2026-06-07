using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/殺死怪物雙倍金幣", order = 1)]
public class DoubleCoinOnKillBuff : ABaseBuffSettingData
{
	private class MonsterTriggerEntry
	{
		public AMonsterBase monster;

		public float triggerTime;
	}

	private List<MonsterTriggerEntry> list_MonsterTriggerEntry;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	private void OnTowerKillMonsterCallback(ABaseTower tower, AMonsterBase monster)
	{
	}

	protected override void TickProc(float delta)
	{
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
