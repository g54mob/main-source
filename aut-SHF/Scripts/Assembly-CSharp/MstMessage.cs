using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstMessage : ScriptableObject
{
	public List<MstMessageEntities> mstmessageentities;
}
