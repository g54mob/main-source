using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/角色/Chunk", order = 1)]
public class Character_Chunk : CharacterSettingData
{
	[Header("巨大化符文數量")]
	[SerializeField]
	private int megaRuneCount;

	public override List<TetrisCardData> GetStartingTetrisSet(int seed)
	{
		return null;
	}

	public override List<TetrisCardData> GetStartingTetrisSet(List<eItemType> list_Preset)
	{
		return null;
	}

	public override List<TowerSettingData> GetStartingTowerSet(List<eItemType> list_ExcludeTowers)
	{
		return null;
	}

	private List<TowerSettingData> GetChunkRandomTowerSet(List<eItemType> list_ExcludeTowers)
	{
		return null;
	}

	public override List<eItemType> GetStartingRunes()
	{
		return null;
	}
}
