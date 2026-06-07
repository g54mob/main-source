using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/EndlessExtraWaveSettingData", order = 1)]
public class EndlessExtraWaveSettingData : ScriptableObject
{
	[SerializeField]
	private List<WaveData> list_WaveData_World1;

	[SerializeField]
	private List<WaveData> list_WaveData_World2;

	[SerializeField]
	private List<WaveData> list_WaveData_World3;

	[SerializeField]
	private List<WaveData> list_WaveData_World4;

	public List<WaveData> GetWaveDataListByWorld(eWorldType worldType)
	{
		return null;
	}
}
