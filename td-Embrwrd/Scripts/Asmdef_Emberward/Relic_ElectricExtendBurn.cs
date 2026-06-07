using System.Collections.Generic;

public class Relic_ElectricExtendBurn : RelicTemplate_MonsterHitBased
{
	private class MonsterTriggerRecord
	{
		public int monsterID;

		public float lastTriggerTime;
	}

	private List<MonsterTriggerRecord> monsterTriggerRecords;

	protected override void OnMonsterHitProc(AMonsterBase monster, int value, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}
}
