using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstWriterData : ScriptableObject
{
	public List<MstWriterDataEntities> mstwriterdataentities;
}
