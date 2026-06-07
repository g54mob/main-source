using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstWaveGroupData : ScriptableObject
{
	public List<MstWaveGroupDataEntities> mstwavegroupdataentities;
}
