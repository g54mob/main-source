using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstUnlockData : ScriptableObject
{
	public List<MstUnlockDataEntities> mstunlockdataentities;
}
