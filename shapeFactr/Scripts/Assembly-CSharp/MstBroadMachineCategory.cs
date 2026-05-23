using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstBroadMachineCategory : ScriptableObject
{
	public List<MstBroadMachineCategoryEntities> mstbroadmachinecategoryentities;
}
