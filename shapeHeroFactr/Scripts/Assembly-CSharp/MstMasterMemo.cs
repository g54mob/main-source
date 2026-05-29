using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstMasterMemo : ScriptableObject
{
	public List<MstMasterMemoEntities> mstmastermemoentities;
}
