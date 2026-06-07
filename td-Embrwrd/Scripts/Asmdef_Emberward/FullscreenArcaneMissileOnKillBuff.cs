using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/殺死怪物全螢幕祕法飛彈", order = 1)]
public class FullscreenArcaneMissileOnKillBuff : ABaseBuffSettingData
{
	[SerializeField]
	private GameObject prefab_Bullet;

	[Header("額外子彈的傷害")]
	[SerializeField]
	private int baseDamage;

	private float cooldown;

	private float cooldownTimer;

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
