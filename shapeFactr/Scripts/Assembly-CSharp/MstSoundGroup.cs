using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstSoundGroup : ScriptableObject
{
	public List<MstSoundGroupEntities> mstsoundgroupentities;
}
