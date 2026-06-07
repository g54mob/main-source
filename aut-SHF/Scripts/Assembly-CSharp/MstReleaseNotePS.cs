using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstReleaseNotePS : ScriptableObject
{
	public List<MstReleaseNotePSEntities> mstreleasenotepsentities;
}
