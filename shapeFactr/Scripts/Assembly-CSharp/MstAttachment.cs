using System.Collections.Generic;
using UnityEngine;
using ymLib;

[ExcelAsset(AssetPath = "MasterData/ScriptableObjects")]
public class MstAttachment : ScriptableObject
{
	public List<MstAttachmentEntities> mstattachmententities;
}
