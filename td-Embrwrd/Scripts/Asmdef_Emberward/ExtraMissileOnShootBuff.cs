using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/射擊產生額外子彈", order = 1)]
public class ExtraMissileOnShootBuff : ABaseBuffSettingData
{
	[SerializeField]
	private GameObject prefab_Bullet;

	[SerializeField]
	[Header("額外子彈的傷害")]
	private int baseDamage;

	private TowerStats buffModifierStats;

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
