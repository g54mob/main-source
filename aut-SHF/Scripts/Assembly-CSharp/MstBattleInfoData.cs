using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstBattleInfoData : ScriptableObject
{
	public List<MstBattleInfoDataEntities> mstbattleinfodataentities;
}
