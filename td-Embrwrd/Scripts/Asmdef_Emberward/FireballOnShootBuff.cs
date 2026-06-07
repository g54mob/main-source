using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/射擊產生火球", order = 1)]
public class FireballOnShootBuff : ABaseBuffSettingData
{
	[SerializeField]
	private GameObject prefab_Bullet;

	[SerializeField]
	[Header("要幾次攻擊才發射額外子彈")]
	private int countToShoot;

	[Header("額外子彈的傷害")]
	[SerializeField]
	private int baseDamage;

	[SerializeField]
	[Header("額外子彈的爆炸傷害")]
	private int explosionDamage;

	private TowerStats buffModifierStats;

	private int shootCount;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	public override void OnTowerShoot(ABaseTower tower, AMonsterBase targetMonster)
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
