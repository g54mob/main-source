using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstWaveTierData : ScriptableObject
{
	public List<MstWaveTierDataEntities> mstwavetierdataentities;
}
