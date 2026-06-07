using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstChallengeData : ScriptableObject
{
	public List<MstChallengeDataEntities> mstchallengedataentities;
}
