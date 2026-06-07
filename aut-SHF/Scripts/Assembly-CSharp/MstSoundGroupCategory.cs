using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstSoundGroupCategory : ScriptableObject
{
	public List<MstSoundGroupCategoryEntities> mstsoundgroupcategoryentities;
}
