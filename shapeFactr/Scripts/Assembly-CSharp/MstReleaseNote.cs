using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstReleaseNote : ScriptableObject
{
	public List<MstReleaseNoteEntities> mstreleasenoteentities;
}
