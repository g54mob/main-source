using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstShopData : ScriptableObject
{
	public List<MstShopDataEntities> mstshopdataentities;
}
