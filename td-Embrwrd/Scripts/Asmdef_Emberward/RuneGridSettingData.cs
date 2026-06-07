using UnityEngine;

[CreateAssetMenu(fileName = "RuneGridSettingData", menuName = "設定檔/RuneGridSettingData", order = 1)]
public class RuneGridSettingData : ScriptableObject
{
	[SerializeField]
	private ePowerGridType type;

	public ePowerGridType PowerGridType => default(ePowerGridType);
}
