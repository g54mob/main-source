using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/GearSettingData", order = 1)]
public class GearSettingData : AItemSettingData
{
	[SerializeField]
	private float param_1;

	[SerializeField]
	private bool isPercentage;

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
