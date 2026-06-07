using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstRouteEvent : ScriptableObject
{
	public List<MstRouteEventEntities> mstrouteevententities;
}
