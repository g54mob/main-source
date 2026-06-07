using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstResultComment : ScriptableObject
{
	public List<MstResultCommentEntities> mstresultcommententities;
}
