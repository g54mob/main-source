using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstResearchCategory : ScriptableObject
{
	public List<MstResearchCategoryEntities> mstresearchcategoryentities;
}
