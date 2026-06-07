using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/角色/Merchant", order = 1)]
public class Character_Merchant : CharacterSettingData
{
	[SerializeField]
	[Header("黃金符文數量")]
	private int goldRuneCount;

	public override List<TetrisCardData> GetStartingTetrisSet(int seed)
	{
		return null;
	}

	public override List<TetrisCardData> GetStartingTetrisSet(List<eItemType> list_Preset)
	{
		return null;
	}

	public override List<eItemType> GetStartingRunes()
	{
		return null;
	}
}
