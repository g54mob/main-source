using System;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class ItemDisablerGrid : SingletonBehaviour<ItemDisablerGrid>
	{
		public const float MIN_ACTIVE_RANGE = 192f;

		private const float CELL_SIZE = 128f;

		private Vector2Int currentPosition;

		public event Action PositionUpdated;

		public new static string AllowAutoCreate()
		{
			return "[ItemDisablerGrid]";
		}

		private void Update()
		{
			if (!(PlayerManager.ActiveCamera == null))
			{
				Vector2Int gridCoords = GetGridCoords(PlayerManager.ActiveCamera.transform.position);
				if (gridCoords.x != currentPosition.x || gridCoords.y != currentPosition.y)
				{
					currentPosition = gridCoords;
					this.PositionUpdated?.Invoke();
				}
			}
		}

		public bool IsCoordActive(Vector2Int coord)
		{
			Vector2Int vector2Int = currentPosition - coord;
			if (Mathf.Abs(vector2Int.x) <= 1)
			{
				return Mathf.Abs(vector2Int.y) <= 1;
			}
			return false;
		}

		public Vector2Int GetGridCoords(Vector3 worldPosition)
		{
			worldPosition -= WorldMover.currentMove;
			int x = Mathf.FloorToInt(worldPosition.x / 128f);
			int y = Mathf.FloorToInt(worldPosition.z / 128f);
			return new Vector2Int(x, y);
		}

		private void OnDrawGizmosSelected()
		{
			Vector3 cubeSize = new Vector3(128f, 0f, 128f);
			Vector2Int vector2Int = currentPosition - new Vector2Int(1, 1);
			DrawCube(vector2Int, Color.green);
			Vector2Int vector2Int2 = vector2Int + new Vector2Int(1, 0);
			DrawCube(vector2Int2, Color.green);
			Vector2Int vector2Int3 = vector2Int2 + new Vector2Int(1, 0);
			DrawCube(vector2Int3, Color.green);
			Vector2Int vector2Int4 = vector2Int3 + new Vector2Int(0, 1);
			DrawCube(vector2Int4, Color.green);
			Vector2Int vector2Int5 = vector2Int4 + new Vector2Int(0, 1);
			DrawCube(vector2Int5, Color.green);
			Vector2Int vector2Int6 = vector2Int5 - new Vector2Int(1, 0);
			DrawCube(vector2Int6, Color.green);
			Vector2Int vector2Int7 = vector2Int6 - new Vector2Int(1, 0);
			DrawCube(vector2Int7, Color.green);
			DrawCube(vector2Int7 - new Vector2Int(0, 1), Color.green);
			DrawCube(currentPosition, Color.red);
			void DrawCube(Vector2Int cellPosition, Color color)
			{
				Gizmos.color = color;
				Gizmos.DrawWireCube(new Vector3((float)cellPosition.x * 128f + 64f, 110f, (float)cellPosition.y * 128f + 64f) + WorldMover.currentMove, cubeSize);
			}
		}
	}
}
