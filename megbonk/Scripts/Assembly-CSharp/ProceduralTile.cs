using System;
using System.Collections.Generic;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using UnityEngine;

[Serializable]
public class ProceduralTile : MonoBehaviour
{
	public List<TileEdge> edges;

	public Renderer renderer;

	private Vector2Int[] globalDirections;

	public int posY;

	public bool isFlat;

	public Vector3 dir { get; private set; }

	public Vector3 parentDir { get; private set; }

	public TileEdge GetEdge(Vector2Int globalDirection)
	{
		return null;
	}

	public void SetGlobalRotation(Vector2Int direction)
	{
	}

	public Vector2Int GlobalToLocalDirection(Vector2Int dir)
	{
		return default(Vector2Int);
	}

	public void SetPosY(int y, StageData stageData, bool isFlat, Vector3 dir, Vector3 parentDir)
	{
	}

	public int GetY()
	{
		return 0;
	}
}
