using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstEnemySound : ScriptableObject
{
	public List<MstEnemySoundEntities> mstenemysoundentities;
}
