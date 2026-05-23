using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstResearchTreeData : ScriptableObject
{
	public List<MstResearchTreeDataEntities> mstresearchtreedataentities;
}
