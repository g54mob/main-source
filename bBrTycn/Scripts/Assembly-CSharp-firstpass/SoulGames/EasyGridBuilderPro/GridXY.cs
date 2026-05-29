using System;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class GridXY<TGridObjectXY>
	{
		public class OnGridObjectChangedEventArgs : EventArgs
		{
			public int x;

			public int y;
		}

		public class OnEdgeObjectChangedEventArgs : EventArgs
		{
			public int x;

			public int y;
		}

		private int width;

		private int length;

		private float cellSize;

		private Vector3 originPosition;

		private TGridObjectXY[,] gridArray;

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

		public GridXY(int width, int length, float cellSize, Vector3 originPosition, Func<GridXY<TGridObjectXY>, int, int, TGridObjectXY> createGridObject, bool showRuntimeNodeGrid, bool showRuntimeGridText, Color32 gridTextColor, float gridTextSizeMultiplier, bool showCellValueText, string gridTextPrefix, string gridTextSuffix, Vector3 gridTextLocalOffset, Transform nodeParent, GameObject[] node, float gridNodeMarginPercentage, Vector3 gridNodeLocalOffset)
		{
			GridXY<TGridObjectXY> gridXY = this;
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
			gridArray = new TGridObjectXY[width, length];
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
						gameObject2.transform.position = new Vector3(gameObject2.transform.position.x + gridNodeLocalOffset.x, gameObject2.transform.position.y + cellSize / 2f + gridNodeLocalOffset.y, gameObject2.transform.position.z - cellSize / 2f + gridNodeLocalOffset.z);
						gameObject2.transform.eulerAngles = new Vector3(90f, 0f, 0f);
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
					debugTextArray[m, n].transform.position = new Vector3(debugTextArray[m, n].transform.position.x + gridTextLocalOffset.x, debugTextArray[m, n].transform.position.y + cellSize / 2f + gridTextLocalOffset.y, debugTextArray[m, n].transform.position.z - cellSize / 2f + gridTextLocalOffset.z);
					debugTextArray[m, n].transform.eulerAngles = new Vector3(0f, 0f, 0f);
					debugTextArray[m, n].transform.parent = gameObject3.transform;
				}
			}
			OnGridObjectChanged += delegate(object sender, OnGridObjectChangedEventArgs eventArgs)
			{
				debugTextArray[eventArgs.x, eventArgs.y].text = gridXY.gridArray[eventArgs.x, eventArgs.y]?.ToString();
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

		public Vector3 GetWorldPosition(int x, int y)
		{
			return new Vector3(x, y, 0f) * cellSize + originPosition;
		}

		public void GetXY(Vector3 worldPosition, out int x, out int y)
		{
			x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
			y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
		}

		public void SetGridObjectXY(int x, int y, TGridObjectXY value)
		{
			if (x >= 0 && y >= 0 && x < width && y < length)
			{
				gridArray[x, y] = value;
				TriggerGridObjectChanged(x, y);
			}
		}

		public void TriggerGridObjectChanged(int x, int y)
		{
			this.OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs
			{
				x = x,
				y = y
			});
		}

		public void TriggerEdgeObjectChanged(int x, int y)
		{
			this.OnEdgeObjectChanged?.Invoke(this, new OnEdgeObjectChangedEventArgs
			{
				x = x,
				y = y
			});
		}

		public void SetGridObjectXY(Vector3 worldPosition, TGridObjectXY value)
		{
			GetXY(worldPosition, out var x, out var y);
			SetGridObjectXY(x, y, value);
		}

		public TGridObjectXY GetGridObjectXY(int x, int y)
		{
			if (x >= 0 && y >= 0 && x < width && y < length)
			{
				return gridArray[x, y];
			}
			return default(TGridObjectXY);
		}

		public TGridObjectXY GetGridObjectXY(Vector3 worldPosition)
		{
			GetXY(worldPosition, out var x, out var y);
			return GetGridObjectXY(x, y);
		}

		public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
		{
			return new Vector2Int(Mathf.Clamp(gridPosition.x, width - 1, 0), Mathf.Clamp(gridPosition.y, length - 1, 0));
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
				color = Color.white;
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
