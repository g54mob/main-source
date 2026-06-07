using System.Collections.Generic;

public class Relic_MagicDust : RelicTemplate_MonsterHitBased
{
	private List<AMonsterBase> hitMonsters;

	protected override void OnEnableProc()
	{
	}

	private void Update()
	{
	}

	protected override void OnMonsterHitProc(AMonsterBase monster, int value, eDamageType damageType, bool isCrit, ABaseTower tower)
	{
	}
}
