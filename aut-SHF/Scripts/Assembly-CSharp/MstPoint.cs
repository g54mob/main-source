using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstPoint : ScriptableObject
{
	public List<MstPointEntities> mstpointentities;
}
