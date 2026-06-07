using UnityEngine;

[CreateAssetMenu(fileName = "PowerGridSettingData", menuName = "設定檔/PowerGridSettingData", order = 1)]
public class PowerGridSettingData : ScriptableObject, ILocalizationDataSource
{
	[SerializeField]
	private ePowerGridType type;

	[SerializeField]
	private TowerStats buffStat;

	public ePowerGridType PowerGridType => default(ePowerGridType);

	public TowerStats BuffStat => null;

	public string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public string GetLocStatsString()
	{
		return null;
	}
}
