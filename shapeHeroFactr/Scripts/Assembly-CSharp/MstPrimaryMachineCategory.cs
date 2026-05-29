using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstPrimaryMachineCategory : ScriptableObject
{
	public List<MstPrimaryMachineCategoryEntities> mstprimarymachinecategoryentities;
}
