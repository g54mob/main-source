using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstCredit : ScriptableObject
{
	public List<MstCreditEntities> mstcreditentities;
}
