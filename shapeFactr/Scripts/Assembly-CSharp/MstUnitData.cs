using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstUnitData : ScriptableObject
{
	public List<MstUnitDataEntities> mstunitdataentities;
}
