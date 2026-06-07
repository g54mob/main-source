using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstRouteEventData : ScriptableObject
{
	public List<MstRouteEventDataEntities> mstrouteeventdataentities;
}
