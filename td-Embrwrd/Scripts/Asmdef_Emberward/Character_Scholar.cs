using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/角色/Scholar", order = 1)]
public class Character_Scholar : CharacterSettingData
{
	public override List<TetrisCardData> GetStartingTetrisSet(int seed)
	{
		return null;
	}

	public override List<TetrisCardData> GetStartingTetrisSet(List<eItemType> list_Preset)
	{
		return null;
	}

	protected void AddSpecialRuneToBlock(TetrisCardData cardData, eItemType runeType)
	{
	}

	public override List<eItemType> GetStartingRunes()
	{
		return null;
	}
}
