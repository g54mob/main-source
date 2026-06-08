using UnityEngine;

public class SpawnMarker : MonoBehaviour
{
	public TileData Tile { get; set; }

	private void OnMouseDown()
	{
		if (Tile != null)
		{
			Tile.visualComponent.TriggerOnMouseDown();
		}
	}

	private void OnMouseUp()
	{
		if (Tile != null)
		{
			Tile.visualComponent.TriggerOnMouseUp();
		}
	}

	private void OnMouseEnter()
	{
		if (Tile != null)
		{
			Tile.visualComponent.TriggerOnMouseEnter();
		}
	}

	private void OnMouseExit()
	{
		if (Tile != null)
		{
			Tile.visualComponent.TriggerOnMouseExit();
		}
	}
}
