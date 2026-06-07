using LightTower;
using UnityEngine;

public class FixTilesPositions : MonoBehaviour
{
	public void FixTilePositions()
	{
		Tile[] componentsInChildren = GetComponentsInChildren<Tile>();
		foreach (Tile tile in componentsInChildren)
		{
			tile.transform.position = new Vector3(Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.y), Mathf.RoundToInt(tile.transform.position.z));
		}
	}
}
