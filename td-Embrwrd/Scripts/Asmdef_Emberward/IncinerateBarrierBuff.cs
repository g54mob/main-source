using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/IncinerateBarrierBuff", order = 2)]
public class IncinerateBarrierBuff : ABaseBuffSettingData
{
	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	public override bool IsMapBuffApplyable(Vector3 targetPos)
	{
		return false;
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
