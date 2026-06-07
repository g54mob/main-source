using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstRelicData : ScriptableObject
{
	public List<MstRelicDataEntities> mstrelicdataentities;
}
