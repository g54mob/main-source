using System.Collections.Generic;
using UnityEngine;
using WorldGen;

public class Chunk : MonoBehaviour
{
	public Vector2Int coord;

	public float size;

	public IslandWorldGenerator generator;

	private List<GameObject> islands = new List<GameObject>();

	internal void Initialize(Vector2Int coord, float size, IslandWorldGenerator generator)
	{
		this.coord = coord;
		this.size = size;
		this.generator = generator;
		base.transform.position = new Vector3((float)coord.x * size, 0f, (float)coord.y * size);
		generator.PopulateChunk(this);
	}

	internal Vector3 GetWorldPosition(Vector3 localPos)
	{
		return base.transform.position + localPos;
	}

	internal void RegisterIsland(GameObject island)
	{
		islands.Add(island);
	}

	internal void DestroyChunk()
	{
		foreach (GameObject island in islands)
		{
			if (island != null)
			{
				Object.Destroy(island);
			}
		}
		islands.Clear();
		Object.Destroy(base.gameObject);
	}
}
