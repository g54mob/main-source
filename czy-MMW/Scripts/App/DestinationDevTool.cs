using Motorways;
using Motorways.Models;
using UnityEngine;

public class DestinationDevTool : MotorwaysModelDevTool<DestinationModel, DestinationDevTool>
{
	public DestinationDevTool()
	{
		_toolModelType = ToolModelType.Destination;
	}

	protected override bool TryGetModelAtCoordinates(Vector2Int modelCoordinates, out DestinationModel foundModel)
	{
		foundModel = null;
		Tile tile = gameScope.Get<TilemapModel>().GetTile(modelCoordinates);
		if (tile != null && tile.ContentType == TileContentType.Destination)
		{
			foundModel = (DestinationModel)tile.ContentModel;
			return true;
		}
		if (tile != null && tile.ContentType == TileContentType.Carpark)
		{
			foundModel = ((CarparkModel)tile.ContentModel).destinations[0];
			return true;
		}
		return false;
	}
}
