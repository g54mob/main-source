using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstScoreRecord : ScriptableObject
{
	public List<MstScoreRecordEntities> mstscorerecordentities;
}
