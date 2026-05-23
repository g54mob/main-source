using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstFeatureData : ScriptableObject
{
	public List<MstFeatureDataEntities> mstfeaturedataentities;
}
