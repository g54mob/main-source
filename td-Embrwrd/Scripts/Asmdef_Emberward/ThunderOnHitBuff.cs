using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/攻擊到的目標打雷", order = 1)]
public class ThunderOnHitBuff : ABaseBuffSettingData
{
	[SerializeField]
	private int damage;

	[SerializeField]
	private float stunDuration;

	[SerializeField]
	private float triggerInterval;

	private float triggerTimer;

	private bool canProc;

	private int lastShootIndex;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
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
