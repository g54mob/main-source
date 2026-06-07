using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/SanctumOfEnigmaMonsterWaveData", order = 1)]
public class SanctumOfEnigmaMonsterWaveData : ScriptableObject
{
	[SerializeField]
	private List<WaveData> list_WaveData;

	public int GetTotalWaveCount()
	{
		return 0;
	}

	public WaveData GetWaveData(int index)
	{
		return null;
	}

	public WaveInfoData GetWaveInfoData(int index)
	{
		return null;
	}
}
