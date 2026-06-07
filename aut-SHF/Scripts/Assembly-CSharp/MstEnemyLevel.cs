using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstEnemyLevel : ScriptableObject
{
	public List<MstEnemyLevelEntities> mstenemylevelentities;
}
