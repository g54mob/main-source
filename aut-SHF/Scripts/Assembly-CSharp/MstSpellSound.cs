using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstSpellSound : ScriptableObject
{
	public List<MstSpellSoundEntities> mstspellsoundentities;
}
