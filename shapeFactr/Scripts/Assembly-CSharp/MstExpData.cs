using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstExpData : ScriptableObject
{
	public List<MstExpDataEntities> mstexpdataentities;
}
