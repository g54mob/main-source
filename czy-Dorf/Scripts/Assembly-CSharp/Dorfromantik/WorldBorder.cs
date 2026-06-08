using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class WorldBorder : MonoBehaviour
	{
		public static readonly Dictionary<int, int> MaxTilesByWorldBorder = new Dictionary<int, int>
		{
			{ 1, 7 },
			{ 2, 19 },
			{ 3, 37 },
			{ 4, 61 },
			{ 5, 91 },
			{ 6, 127 },
			{ 7, 169 },
			{ 8, 217 },
			{ 9, 271 },
			{ 10, 331 },
			{ 11, 397 },
			{ 12, 469 },
			{ 13, 547 },
			{ 14, 631 },
			{ 15, 721 },
			{ 16, 817 },
			{ 17, 919 },
			{ 18, 1027 },
			{ 19, 1141 },
			{ 20, 1261 },
			{ 21, 1387 },
			{ 22, 1519 },
			{ 23, 1657 },
			{ 24, 1801 },
			{ 25, 1951 },
			{ 26, 2107 },
			{ 27, 2269 },
			{ 28, 2437 },
			{ 29, 2611 }
		};

		[SerializeField]
		private int worldBorderRadius;

		[SerializeField]
		private List<IOutlineable> edgeSlots;

		[SerializeField]
		private List<Vector2Int> edgePositions;

		[SerializeField]
		private bool spawnDebugEdgeObjects;

		[SerializeField]
		private TileSlot debugEdgeObject;

		[SerializeField]
		private List<TileSlot> debugEdgeObjects;

		private TileOutliner tileOutliner;

		private int _003CBorderRadius_003Ek__BackingField = -1;

		public int BorderRadius
		{
			get
			{
				return _003CBorderRadius_003Ek__BackingField;
			}
			private set
			{
				_003CBorderRadius_003Ek__BackingField = value;
			}
		}

		public event Action<int> OnBorderSet;

		private void ClearOutlines()
		{
			tileOutliner.ClearOutlines();
		}

		public void SetBorder(int radius)
		{
			BorderRadius = radius;
			worldBorderRadius = radius;
			this.OnBorderSet?.Invoke(BorderRadius);
			if (radius <= 0)
			{
				return;
			}
			tileOutliner = GetComponent<TileOutliner>();
			edgeSlots = new List<IOutlineable>();
			edgePositions = new List<Vector2Int>();
			Vector2Int vector2Int = new Vector2Int(radius, 0);
			edgePositions.Add(vector2Int);
			bool flag = false;
			while (!flag)
			{
				flag = true;
				Vector2Int[] neighborGridPositions = GridCalculator.GetNeighborGridPositions(vector2Int);
				foreach (Vector2Int vector2Int2 in neighborGridPositions)
				{
					if (!edgePositions.Contains(vector2Int2) && GridCalculator.Distance(Vector2Int.zero, vector2Int2) == radius)
					{
						flag = false;
						vector2Int = vector2Int2;
						edgePositions.Add(vector2Int);
						break;
					}
				}
			}
			tileOutliner.Outline(edgePositions);
			foreach (TileSlot debugEdgeObject in debugEdgeObjects)
			{
				UnityEngine.Object.Destroy(debugEdgeObject.gameObject);
			}
			debugEdgeObjects.Clear();
			if (!spawnDebugEdgeObjects)
			{
				return;
			}
			foreach (Vector2Int edgePosition in edgePositions)
			{
				TileSlot tileSlot = UnityEngine.Object.Instantiate(this.debugEdgeObject, GridCalculator.GridToWorldPos(edgePosition), Quaternion.identity, base.transform);
				debugEdgeObjects.Add(tileSlot);
				tileSlot.Initialize(edgePosition);
			}
		}

		public bool IsWithinBorder(Vector2Int gridPos)
		{
			if (BorderRadius > 0)
			{
				return GridCalculator.Distance(gridPos, Vector2Int.zero) <= BorderRadius;
			}
			return true;
		}
	}
}
