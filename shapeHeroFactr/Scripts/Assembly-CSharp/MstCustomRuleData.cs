using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstCustomRuleData : ScriptableObject
{
	public List<MstCustomRuleDataEntities> mstcustomruledataentities;
}
