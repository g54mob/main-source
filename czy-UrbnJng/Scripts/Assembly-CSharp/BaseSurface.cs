using System.Collections.Generic;
using UnityEngine;

public class BaseSurface : MonoBehaviour
{
	private List<Collider> collidersOnSurface;

	private List<Vector2Int> occupiedCells;

	private int i;

	private void Awake()
	{
		collidersOnSurface = new List<Collider>();
		occupiedCells = new List<Vector2Int>();
		i = 0;
	}

	private void OnTriggerEnter(Collider other)
	{
		collidersOnSurface.Add(other);
	}

	private void Update()
	{
		if (collidersOnSurface.Count > 0 && i < collidersOnSurface.Count)
		{
			SetOccupiedCells(GridManager.Instance.GetCellPosition(collidersOnSurface[i].bounds.min), GridManager.Instance.GetCellPosition(collidersOnSurface[i].bounds.max));
			i++;
		}
	}

	private void SetOccupiedCells(Vector3Int min, Vector3Int max)
	{
		for (int i = min.x; i <= max.x; i++)
		{
			for (int j = min.z; j <= max.z; j++)
			{
				occupiedCells.Add(new Vector2Int(i, j));
			}
		}
	}

	public List<Vector2Int> GetOccupiedCells()
	{
		return occupiedCells;
	}
}
