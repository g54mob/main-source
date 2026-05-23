using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstInitialArchiveData : ScriptableObject
{
	public List<MstInitialArchiveDataEntities> mstinitialarchivedataentities;
}
