using System;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class GridXZ<TGridObjectXZ>
	{
		public class OnGridObjectChangedEventArgs : EventArgs
		{
			public int x;

			public int z;
		}

		public class OnEdgeObjectChangedEventArgs : EventArgs
		{
			public int x;

			public int z;
		}

		private int width;

		private int length;

		private float cellSize;

		private Vector3 originPosition;

		private TGridObjectXZ[,] gridArray;

		private Transform nodeParent;

		private bool showRuntimeGridText;

		private Color32 gridTextColor;

		private float gridTextSizeMultiplier;

		private bool showCellValueText;

		private string gridTextPrefix;

		private string gridTextSuffix;

		private Vector3 gridTextLocalOffset;

		private bool showRuntimeNodeGrid;

		private GameObject[] node;

		private float gridNodeMarginPercentage;

		private Vector3 gridNodeLocalOffset;

		public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;

		public event EventHandler<OnEdgeObjectChangedEventArgs> OnEdgeObjectChanged;

		public GridXZ(int width, int length, float cellSize, Vector3 originPosition, Func<GridXZ<TGridObjectXZ>, int, int, TGridObjectXZ> createGridObject, bool showRuntimeNodeGrid, bool showRuntimeGridText, Color32 gridTextColor, float gridTextSizeMultiplier, bool showCellValueText, string gridTextPrefix, string gridTextSuffix, Vector3 gridTextLocalOffset, Transform nodeParent, GameObject[] node, float gridNodeMarginPercentage, Vector3 gridNodeLocalOffset)
		{
			GridXZ<TGridObjectXZ> gridXZ = this;
			this.width = width;
			this.length = length;
			this.cellSize = cellSize;
			this.originPosition = originPosition;
			this.nodeParent = nodeParent;
			this.showRuntimeGridText = showRuntimeGridText;
			this.gridTextColor = gridTextColor;
			this.gridTextSizeMultiplier = gridTextSizeMultiplier;
			this.showCellValueText = showCellValueText;
			this.gridTextPrefix = gridTextPrefix;
			this.gridTextSuffix = gridTextSuffix;
			this.gridTextLocalOffset = gridTextLocalOffset;
			this.showRuntimeNodeGrid = showRuntimeNodeGrid;
			this.node = node;
			this.gridNodeMarginPercentage = gridNodeMarginPercentage;
			this.gridNodeLocalOffset = gridNodeLocalOffset;
			gridArray = new TGridObjectXZ[width, length];
			for (int i = 0; i < gridArray.GetLength(0); i++)
			{
				for (int j = 0; j < gridArray.GetLength(1); j++)
				{
					gridArray[i, j] = createGridObject(this, i, j);
				}
			}
			if (showRuntimeNodeGrid)
			{
				GameObject gameObject = new GameObject("Node Grid");
				gameObject.transform.parent = nodeParent;
				for (int k = 0; k < gridArray.GetLength(0); k++)
				{
					for (int l = 0; l < gridArray.GetLength(1); l++)
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate(node[UnityEngine.Random.Range(0, node.Length)], GetWorldPosition(k, l) + new Vector3(cellSize, 0f, cellSize) * 0.5f, Quaternion.identity);
						gameObject2.transform.parent = gameObject.transform;
						float num = cellSize / 100f * gridNodeMarginPercentage;
						gameObject2.transform.localScale = new Vector3(num, gameObject2.transform.localScale.y, num);
						gameObject2.transform.position = new Vector3(gameObject2.transform.position.x + gridNodeLocalOffset.x, gameObject2.transform.position.y + gridNodeLocalOffset.y, gameObject2.transform.position.z + gridNodeLocalOffset.z);
					}
				}
			}
			if (!showRuntimeGridText)
			{
				return;
			}
			GameObject gameObject3 = new GameObject("Text Grid");
			gameObject3.transform.parent = nodeParent;
			TextMesh[,] debugTextArray = new TextMesh[width, length];
			for (int m = 0; m < gridArray.GetLength(0); m++)
			{
				for (int n = 0; n < gridArray.GetLength(1); n++)
				{
					string text = "";
					if (showCellValueText)
					{
						text = gridArray[m, n]?.ToString();
					}
					debugTextArray[m, n] = CreateWorldText(gridTextPrefix + "\n" + text + gridTextSuffix, null, GetWorldPosition(m, n) + new Vector3(cellSize, 0f, cellSize) * 0.5f, Mathf.RoundToInt(1.5f * cellSize * gridTextSizeMultiplier), gridTextColor, TextAnchor.MiddleCenter, TextAlignment.Center);
					debugTextArray[m, n].transform.position = new Vector3(debugTextArray[m, n].transform.position.x + gridTextLocalOffset.x, debugTextArray[m, n].transform.position.y + gridTextLocalOffset.y, debugTextArray[m, n].transform.position.z + gridTextLocalOffset.z);
					debugTextArray[m, n].transform.eulerAngles = new Vector3(90f, 0f, 0f);
					debugTextArray[m, n].transform.parent = gameObject3.transform;
				}
			}
			OnGridObjectChanged += delegate(object sender, OnGridObjectChangedEventArgs eventArgs)
			{
				debugTextArray[eventArgs.x, eventArgs.z].text = gridXZ.gridArray[eventArgs.x, eventArgs.z]?.ToString();
			};
		}

		public int GetWidth()
		{
			return width;
		}

		public int GetLength()
		{
			return length;
		}

		public float GetCellSize()
		{
			return cellSize;
		}

		public Vector3 GetWorldPosition(int x, int z)
		{
			return new Vector3(x, 0f, z) * cellSize + originPosition;
		}

		public void GetXZ(Vector3 worldPosition, out int x, out int z)
		{
			x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
			z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
		}

		public void SetGridObjectXZ(int x, int z, TGridObjectXZ value)
		{
			if (x >= 0 && z >= 0 && x < width && z < length)
			{
				gridArray[x, z] = value;
				TriggerGridObjectChanged(x, z);
			}
		}

		public void TriggerGridObjectChanged(int x, int z)
		{
			this.OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs
			{
				x = x,
				z = z
			});
		}

		public void TriggerEdgeObjectChanged(int x, int z)
		{
			this.OnEdgeObjectChanged?.Invoke(this, new OnEdgeObjectChangedEventArgs
			{
				x = x,
				z = z
			});
		}

		public void SetGridObjectXZ(Vector3 worldPosition, TGridObjectXZ value)
		{
			GetXZ(worldPosition, out var x, out var z);
			SetGridObjectXZ(x, z, value);
		}

		public TGridObjectXZ GetGridObjectXZ(int x, int z)
		{
			if (x >= 0 && z >= 0 && x < width && z < length)
			{
				return gridArray[x, z];
			}
			return default(TGridObjectXZ);
		}

		public TGridObjectXZ GetGridObjectXZ(Vector3 worldPosition)
		{
			GetXZ(worldPosition, out var x, out var z);
			return GetGridObjectXZ(x, z);
		}

		public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
		{
			return new Vector2Int(Mathf.Clamp(gridPosition.x, 0, width - 1), Mathf.Clamp(gridPosition.y, 0, length - 1));
		}

		public bool IsValidGridPosition(Vector2Int gridPosition)
		{
			int x = gridPosition.x;
			int y = gridPosition.y;
			if (x >= 0 && y >= 0 && x < width && y < length)
			{
				return true;
			}
			return false;
		}

		public bool IsValidGridPositionWithMargin(Vector2Int gridPosition)
		{
			Vector2Int vector2Int = new Vector2Int(2, 2);
			int x = gridPosition.x;
			int y = gridPosition.y;
			if (x >= vector2Int.x && y >= vector2Int.y && x < width - vector2Int.x && y < length - vector2Int.y)
			{
				return true;
			}
			return false;
		}

		public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
		{
			if (!color.HasValue)
			{
				color = Color.green;
			}
			return CreateWorldText(parent, text, localPosition, fontSize, color.Value, textAnchor, textAlignment, sortingOrder);
		}

		public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
		{
			GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
			Transform transform = gameObject.transform;
			transform.SetParent(parent, worldPositionStays: false);
			transform.localPosition = localPosition;
			TextMesh component = gameObject.GetComponent<TextMesh>();
			component.anchor = textAnchor;
			component.alignment = textAlignment;
			component.text = text;
			component.fontSize = fontSize;
			component.color = color;
			component.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
			return component;
		}
	}
}
