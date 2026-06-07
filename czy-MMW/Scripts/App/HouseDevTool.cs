using Motorways;
using Motorways.Models;
using UnityEngine;

public class HouseDevTool : MotorwaysModelDevTool<HouseModel, HouseDevTool>
{
	public HouseDevTool()
	{
		_toolModelType = ToolModelType.House;
	}

	protected override bool TryGetModelAtCoordinates(Vector2Int modelCoordinates, out HouseModel foundModel)
	{
		foundModel = null;
		Tile tile = gameScope.Get<TilemapModel>().GetTile(modelCoordinates);
		if (tile != null && tile.ContentType == TileContentType.House)
		{
			foundModel = (HouseModel)tile.ContentModel;
			return true;
		}
		return false;
	}
}
