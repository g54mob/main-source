using System.Collections.Generic;
using LightTower;
using UnityEngine;

public class GroundChunk : MonoBehaviour
{
	public Source[] GetSources()
	{
		return GetComponentsInChildren<Source>();
	}

	public Tile[] GetTiles()
	{
		return GetComponentsInChildren<Tile>();
	}

	public ICollection<Vector3> GetOccupiedPositions()
	{
		ICollection<Vector3> collection = new List<Vector3>();
		Tile[] tiles = GetTiles();
		foreach (Tile tile in tiles)
		{
			collection.Add(tile.transform.position);
		}
		return collection;
	}
}
