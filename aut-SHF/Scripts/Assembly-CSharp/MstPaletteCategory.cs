using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstPaletteCategory : ScriptableObject
{
	public List<MstPaletteCategoryEntities> mstpalettecategoryentities;
}
