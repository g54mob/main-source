using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstBlendData : ScriptableObject
{
	public List<MstBlendDataEntities> mstblenddataentities;
}
