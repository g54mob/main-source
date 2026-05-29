using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstSteamAchiveData : ScriptableObject
{
	public List<MstSteamAchiveDataEntities> mststeamachivedataentities;
}
