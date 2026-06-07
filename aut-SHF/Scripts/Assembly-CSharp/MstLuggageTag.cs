using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstLuggageTag : ScriptableObject
{
	public List<MstLuggageTagEntities> mstluggagetagentities;
}
