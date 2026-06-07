using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class ArchiveCategory : ScriptableObject
{
	public List<ArchiveCategoryEntities> archivecategoryentities;
}
