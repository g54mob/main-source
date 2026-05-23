using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstStaffroll : ScriptableObject
{
	public List<MstStaffrollEntities> mststaffrollentities;
}
