using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/砲塔周圍減速", order = 1)]
public class AreaSlowAroundTowerBuff : ABaseBuffSettingData
{
	[SerializeField]
	private float range;

	[SerializeField]
	private float speedMultiplier;

	[SerializeField]
	private float speedMultiplierDuration;

	private float detectInterval;

	private float detectTimer;

	private GameObject obj_VFX;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
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
