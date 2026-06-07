using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstGuideCategory : ScriptableObject
{
	public List<MstGuideCategoryEntities> mstguidecategoryentities;
}
