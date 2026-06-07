using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/擊中時把怪物抓進來", order = 1)]
public class GrabMonsterOnHitBuff : ABaseBuffSettingData
{
	[SerializeField]
	private float grabRadius;

	[SerializeField]
	private int grabCount;

	[SerializeField]
	private float triggerInterval;

	[SerializeField]
	private GameObject prefab_GrabEffect;

	private float triggerTimer;

	private int triggerCount;

	private bool canProc;

	private int lastShootIndex;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	private void OnRoundEnd()
	{
	}

	protected override void TickProc(float delta)
	{
	}

	public override void OnTowerShoot(ABaseTower tower, AMonsterBase targetMonster)
	{
	}

	public override void OnTowerBulletHit(ABaseTower tower, AMonsterBase targetMonster, int shootIndex, int bulletIndex)
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
