using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/角色/Tiny", order = 1)]
public class Character_Tiny : CharacterSettingData
{
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

	public override List<eItemType> GetAvailableTetrisTypes()
	{
		return null;
	}
}
