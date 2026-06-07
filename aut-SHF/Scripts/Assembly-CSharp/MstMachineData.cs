using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstMachineData : ScriptableObject
{
	public List<MstMachineDataEntities> mstmachinedataentities;
}
