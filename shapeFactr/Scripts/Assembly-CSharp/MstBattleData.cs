using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstBattleData : ScriptableObject
{
	public List<MstBattleDataEntities> mstbattledataentities;
}
