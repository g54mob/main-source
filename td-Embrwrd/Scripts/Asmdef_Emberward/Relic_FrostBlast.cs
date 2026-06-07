using UnityEngine;

public class Relic_FrostBlast : RelicTemplate_MonsterKillBased
{
	[SerializeField]
	private float freezeDuration;

	protected override void OnMonsterKilledProc(AMonsterBase targetMonster)
	{
	}
}
