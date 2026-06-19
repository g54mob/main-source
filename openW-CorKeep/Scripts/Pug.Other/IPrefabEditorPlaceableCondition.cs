using System.Collections.Generic;
using PugTilemap;
using UnityEngine;

public interface IPrefabEditorPlaceableCondition
{
	bool CanBePlaced(IEnumerable<MonoBehaviour> componentsAtPosition, TileType tileTypeAtPosition);
}
