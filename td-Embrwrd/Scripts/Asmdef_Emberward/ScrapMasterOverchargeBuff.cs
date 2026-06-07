using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/ScrapMasterOverchargeBuff", order = 1)]
public class ScrapMasterOverchargeBuff : ABaseBuffSettingData
{
	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
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
