using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstEnemyChoiceData : ScriptableObject
{
	public List<MstEnemyChoiceDataEntities> mstenemychoicedataentities;
}
