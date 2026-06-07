using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstEnemySpawnPosition : ScriptableObject
{
	public List<MstEnemySpawnPositionEntities> mstenemyspawnpositionentities;
}
