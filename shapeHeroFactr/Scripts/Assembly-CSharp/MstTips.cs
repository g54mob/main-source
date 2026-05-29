using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstTips : ScriptableObject
{
	public List<MstTipsEntities> msttipsentities;
}
