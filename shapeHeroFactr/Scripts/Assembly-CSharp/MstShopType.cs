using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstShopType : ScriptableObject
{
	public List<MstShopTypeEntities> mstshoptypeentities;
}
