using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstArchiveData : ScriptableObject
{
	public List<MstArchiveDataEntities> mstarchivedataentities;
}
