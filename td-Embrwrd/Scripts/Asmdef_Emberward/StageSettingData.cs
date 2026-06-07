using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/StageSettingData", order = 1)]
public class StageSettingData : ABaseStageSettingData
{
	[SerializeField]
	private List<WaveData> list_WaveData;

	[SerializeField]
	[Header("是否有無盡模式專用波數")]
	private bool hasEndlessWave;

	[SerializeField]
	private List<WaveData> list_EndlessWaveData;

	[SerializeField]
	[Header("屬於哪個世界的關卡")]
	protected eWorldType worldType;

	[SerializeField]
	[Header("關卡名稱的多國key")]
	private string stageNameLoc;

	[SerializeField]
	[Header("關卡介紹的多國key")]
	private string stageDescriptionLoc;

	[SerializeField]
	[Header("關卡特殊成就的多國key")]
	private string achievementLoc;

	[SerializeField]
	private int seed;

	[Header("難度")]
	[SerializeField]
	private int difficulty;

	[SerializeField]
	[Header("總共波數")]
	private int totalWaves;

	[Header("最大路徑數量")]
	[SerializeField]
	private int maxPathCount;

	private int originalWaveCount;

	private int curEndlessWaveIndex;

	public WaveData GetWaveData(int waveIndex)
	{
		return null;
	}

	public int GetPortalCount()
	{
		return 0;
	}

	public WaveInfoData GetWaveInfoData(int waveIndex)
	{
		return null;
	}

	public WaveInfoData GetWaveInfoData(WaveData waveData)
	{
		return null;
	}

	public float GetDifficultyMultiplier(float baseDifficulty, int waveIndex)
	{
		return 0f;
	}

	public void SetBaseDifficulty(int value)
	{
	}

	public int GetTotalWaveCount()
	{
		return 0;
	}

	public void SetWaveCount(int value)
	{
	}

	public bool IsFinalWave(int waveIndex)
	{
		return false;
	}

	public void RandomSeedGenerate()
	{
	}

	public void Generate(eWorldType worldType)
	{
	}

	public List<int> GetActivePathIndex()
	{
		return null;
	}

	private int GetPathCount(int waveIndex)
	{
		return 0;
	}

	private static MonsterSettingData GetMonsterSettingDataByType(eMonsterType monsterType)
	{
		return null;
	}

	private eMonsterType GetRandomMonsterType(int difficulty, eWorldType worldType, int waveIndex, int monsterTypeIndex)
	{
		return default(eMonsterType);
	}

	public void AddExtraWaveAtEnd(WaveData waveData)
	{
	}

	public void OverrideWaveDifficulty(List<float> list_Difficulty)
	{
	}

	public void OverrideWaveDifficulty(int index, float difficultyMultiplier)
	{
	}

	public void OverrideWaveData(WaveData waveData, int index)
	{
	}

	public void AddEndlessWaveDataAtEnd(WaveData waveData)
	{
	}

	public void AddExtraWaveAtEnd_AutoGenerate()
	{
	}

	public void AddExtraWaveAtEnd_FromEndlessWave()
	{
	}

	public override string GetLocalization_Title()
	{
		return null;
	}

	public override string GetLocalization_Description()
	{
		return null;
	}
}
