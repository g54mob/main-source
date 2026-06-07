using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstEnemyData : ScriptableObject
{
	public List<MstEnemyDataEntities> mstenemydataentities;
}
