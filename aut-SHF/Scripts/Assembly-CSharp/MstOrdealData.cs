using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstOrdealData : ScriptableObject
{
	public List<MstOrdealDataEntities> mstordealdataentities;
}
