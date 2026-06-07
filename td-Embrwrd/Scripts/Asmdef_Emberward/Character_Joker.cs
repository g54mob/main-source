using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/角色/Joker", order = 1)]
public class Character_Joker : CharacterSettingData
{
	public override List<TetrisCardData> GetStartingTetrisSet(int seed)
	{
		return null;
	}
}
