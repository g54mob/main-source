using System;
using UnityEngine;

[Serializable]
public class PreplacedTileData_002 : PreplacedTileData_base
{
	public int sectionGridPosX;

	public int sectionGridPosY;

	public QuestTileId preplacedTileId;

	public PreplacedTileData_002(Vector2Int sectionGridPos, QuestTileId preplacedTileId)
	{
		version = 2;
		sectionGridPosX = sectionGridPos.x;
		sectionGridPosY = sectionGridPos.y;
		this.preplacedTileId = preplacedTileId;
	}

	public PreplacedTileData_002(PreplacedTileData oldData)
	{
		version = 2;
		sectionGridPosX = oldData.sectionGridPosX;
		sectionGridPosY = oldData.sectionGridPosY;
		if (!string.IsNullOrWhiteSpace(oldData.preplacedTileId))
		{
			preplacedTileId = QuestTileData_001.questTileIdByName[oldData.preplacedTileId];
		}
	}
}
