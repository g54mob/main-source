using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugTilemap.Workshop
{
	public class Select : Tool
	{
		private struct TempData
		{
			public List<TileData> tiles;

			public List<GameObject> prefabs;
		}

		private SpriteRenderer floatingPiece;

		private Vector2Int origin;

		private RectInt selectRect;

		private Dictionary<Vector3Int, TempData> selectRectData = new Dictionary<Vector3Int, TempData>();

		private bool movingSelectRect;

		private Vector2Int movingSelectRectPos;

		private bool hasSelection { get; set; }

		public Select(Workshop ed)
			: base(ed, "Select")
		{
		}

		public override void OnEnable()
		{
			floatingPiece = ed.CreateFloatingPiece();
			floatingPiece.sprite = ed.sprites["editor dirt"];
			floatingPiece.color = new Color(1f, 1f, 1f, 0.3f);
			floatingPiece.gameObject.SetActive(value: false);
			floatingPiece.transform.eulerAngles = new Vector3(90f, 0f, 0f);
		}

		public override void OnDisable()
		{
			if (floatingPiece != null)
			{
				UnityEngine.Object.DestroyImmediate(floatingPiece.gameObject);
			}
		}

		public void UpdateFloatingPiece()
		{
			floatingPiece.gameObject.SetActive(value: true);
			Vector2 vector = selectRect.center - Vector2.one / 2f;
			floatingPiece.transform.localPosition = new Vector3(vector.x, 0.001f, vector.y);
			floatingPiece.transform.localScale = (Vector2)selectRect.size;
		}

		public override void OnMouseDown()
		{
			if (hasSelection && selectRect.Contains(ed.tileMouse))
			{
				if (!movingSelectRect)
				{
					movingSelectRect = true;
				}
				movingSelectRectPos = ed.tileMouse;
			}
			else
			{
				foreach (IEntityMonoBehaviourData @object in ed.multiMap.GetObjects())
				{
					if (!@object.GameObject.activeSelf)
					{
						UnityEngine.Object.DestroyImmediate(@object.GameObject);
					}
				}
				origin = ed.tileMouse;
				hasSelection = false;
				selectRect = new RectInt(ed.tileMouse, Vector2Int.one);
			}
			UpdateFloatingPiece();
		}

		public override void OnMouseDrag()
		{
			Vector2Int tileMouse = ed.tileMouse;
			if (movingSelectRect)
			{
				if (movingSelectRectPos != tileMouse)
				{
					selectRect.position += tileMouse - movingSelectRectPos;
					movingSelectRectPos = tileMouse;
				}
			}
			else if (!hasSelection)
			{
				int xMin = Math.Min(origin.x, tileMouse.x);
				int yMin = Math.Min(origin.y, tileMouse.y);
				int width = 1 + Math.Abs(tileMouse.x - origin.x);
				int height = 1 + Math.Abs(tileMouse.y - origin.y);
				selectRect = new RectInt(xMin, yMin, width, height);
			}
			else
			{
				Vector2Int vector2Int = tileMouse - origin;
				selectRect.position += vector2Int;
				origin = tileMouse;
			}
			UpdateFloatingPiece();
		}

		public override void OnMouseUp()
		{
			UpdateFloatingPiece();
			hasSelection = true;
			movingSelectRect = false;
		}

		public override void Draw()
		{
		}

		public void Delete()
		{
		}

		public void Copy()
		{
			if (!hasSelection)
			{
				Debug.LogWarning("Can't Copy without a selection");
			}
			else
			{
				Yank(cut: false);
			}
		}

		public void Cut()
		{
			if (!hasSelection)
			{
				Debug.LogWarning("Can't Cut without a selection");
			}
			else
			{
				Yank(cut: true);
			}
		}

		public void Paste()
		{
		}

		private static GameObject CloneYankable(GameObject child)
		{
			Debug.Log("Component not added to prefab instance");
			GameObject gameObject = UnityEngine.Object.Instantiate(child);
			gameObject.name = child.name;
			gameObject.SetActive(value: false);
			return gameObject;
		}

		public void Yank(bool cut)
		{
		}

		private void SetSurroundingTilesDirty(Vector3Int pos)
		{
			for (int i = pos.x - 1; i <= pos.x + 1; i++)
			{
				for (int j = pos.z - 1; j <= pos.z + 1; j++)
				{
					ed.multiMap.SetDirty(new Vector3Int(i, 0, j));
				}
			}
		}

		public void Flip(bool flipX, bool flipY)
		{
		}

		private void ClearAndFlip(Vector3Int pos, Vector3Int flippedPos, Vector3Int relativeRectPos, Vector3Int flippedRelativeRectPos)
		{
		}
	}
}
