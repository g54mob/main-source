using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstPlayerBuff : ScriptableObject
{
	public List<MstPlayerBuffEntities> mstplayerbuffentities;
}
