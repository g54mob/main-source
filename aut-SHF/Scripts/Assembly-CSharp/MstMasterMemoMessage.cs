using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstMasterMemoMessage : ScriptableObject
{
	public List<MstMasterMemoMessageEntities> mstmastermemomessageentities;
}
