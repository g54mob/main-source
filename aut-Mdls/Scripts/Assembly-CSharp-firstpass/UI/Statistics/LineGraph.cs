using System.Collections.Generic;
using TMPro;
using UI.Statistics.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Statistics
{
	public class LineGraph : MonoBehaviour
	{
		public delegate void LineCreated(int lineId, Image line);

		public delegate void DotCreated(int lineId, Image dot);

		public delegate void CriticalValuesFound(Vector2 min, Vector2 max);

		public delegate void NormalizedLineDotsCalculated(int lineId, List<Vector2> positions);

		private class Pool<T> where T : Component
		{
			private readonly Queue<T> _queue;

			private readonly List<T> _activeObjects;

			private readonly T _prefab;

			private readonly Transform _container;

			public Pool(T prefab, Transform container)
			{
				_prefab = prefab;
				_container = container;
				_queue = new Queue<T>();
				_activeObjects = new List<T>();
			}

			public T PoolObject()
			{
				T val = ((_queue.Count > 0) ? _queue.Dequeue() : Object.Instantiate(_prefab, _container));
				val.gameObject.SetActive(value: true);
				_activeObjects.Add(val);
				return val;
			}

			public void Deactivate()
			{
				foreach (T activeObject in _activeObjects)
				{
					activeObject.gameObject.SetActive(value: false);
					_queue.Enqueue(activeObject);
				}
				_activeObjects.Clear();
			}
		}

		[Header("Deps")]
		[SerializeField]
		private RectTransform graphContainer;

		[SerializeField]
		private RectTransform gridContainer;

		[SerializeField]
		private RectTransform horizontalContainer;

		[SerializeField]
		private RectTransform verticalContainer;

		[Header("Prefabs")]
		[SerializeField]
		private Image dotPrefab;

		[SerializeField]
		private Image linePrefab;

		[SerializeField]
		private Image gridLinePrefab;

		[SerializeField]
		private TMP_Text verticalTextPrefab;

		[SerializeField]
		private TMP_Text horizontalTextPrefab;

		[Header("Params")]
		[SerializeField]
		[Min(0f)]
		private float dotSize = 5f;

		[SerializeField]
		[Min(0f)]
		private float lineWidth = 5f;

		[SerializeField]
		[Min(1f)]
		private float horizontalDiscretization;

		[SerializeField]
		[Min(1f)]
		private float verticalDiscretization;

		[SerializeField]
		[Min(0f)]
		private float gridLineWidth = 1f;

		[SerializeField]
		private string prefixForHorizontalText;

		[SerializeField]
		private string prefixForVerticalText;

		[Header("Flags")]
		[SerializeField]
		private bool toDrawHorizontalGridLines = true;

		[SerializeField]
		private bool toDrawVerticalGridLines = true;

		[SerializeField]
		private bool toDrawHorizontalNumbers = true;

		[SerializeField]
		private bool toDrawVerticalNumbers = true;

		private Pool<Image> _dotsPool;

		private Pool<Image> _linesPool;

		private Pool<Image> _gridlLinesPool;

		private Pool<TMP_Text> _horizontalTextPool;

		private Pool<TMP_Text> _verticalTextPool;

		private Vector2 _max;

		private Vector2 _min;

		private LineCreated _lineCreated;

		private DotCreated _dotCreated;

		private CriticalValuesFound _criticalValuesFound;

		private NormalizedLineDotsCalculated _normalizedLineDotsCalculated;

		public Vector2 Discretization
		{
			get
			{
				return new Vector2(horizontalDiscretization, verticalDiscretization);
			}
			set
			{
				horizontalDiscretization = value.x;
				verticalDiscretization = value.y;
			}
		}

		public bool ToDrawHorizontalGridLines
		{
			get
			{
				return toDrawHorizontalGridLines;
			}
			set
			{
				toDrawHorizontalGridLines = value;
			}
		}

		public bool ToDrawVerticalGridLines
		{
			get
			{
				return toDrawVerticalGridLines;
			}
			set
			{
				toDrawVerticalGridLines = value;
			}
		}

		public bool ToDrawHorizontalNumbers
		{
			get
			{
				return toDrawHorizontalNumbers;
			}
			set
			{
				toDrawHorizontalNumbers = value;
			}
		}

		public bool ToDrawVerticalNumbers
		{
			get
			{
				return toDrawVerticalNumbers;
			}
			set
			{
				toDrawVerticalNumbers = value;
			}
		}

		public string PrefixForHorizontalText
		{
			get
			{
				return prefixForHorizontalText;
			}
			set
			{
				prefixForHorizontalText = value;
			}
		}

		public string PrefixForVerticalText
		{
			get
			{
				return prefixForVerticalText;
			}
			set
			{
				prefixForVerticalText = value;
			}
		}

		private void Awake()
		{
			_dotsPool = new Pool<Image>(dotPrefab, graphContainer);
			_linesPool = new Pool<Image>(linePrefab, graphContainer);
			_gridlLinesPool = new Pool<Image>(gridLinePrefab, gridContainer);
			_horizontalTextPool = new Pool<TMP_Text>(horizontalTextPrefab, horizontalContainer);
			_verticalTextPool = new Pool<TMP_Text>(verticalTextPrefab, verticalContainer);
		}

		public void PlotGraph(ILineGraphData dataPoints, DotCreated dotCreated = null, LineCreated lineCreated = null, CriticalValuesFound criticalValuesFound = null, NormalizedLineDotsCalculated normalizedLineDotsCalculated = null)
		{
			Clear();
			_dotCreated = dotCreated;
			_lineCreated = lineCreated;
			_criticalValuesFound = criticalValuesFound;
			_normalizedLineDotsCalculated = normalizedLineDotsCalculated;
			if (dataPoints != null && dataPoints.LinesCount != 0)
			{
				(_min, _max) = dataPoints.GetMinMaxValues();
				_criticalValuesFound?.Invoke(_min, _max);
				PlotGrid();
				for (int i = 0; i < dataPoints.LinesCount; i++)
				{
					PlotLine(dataPoints[i], i);
				}
			}
		}

		private void PlotGrid()
		{
			Vector2 size = gridContainer.rect.size;
			Vector2 vector = (_max - _min) / Discretization;
			PlotInitialGridUI(size);
			if (toDrawVerticalNumbers || toDrawHorizontalGridLines)
			{
				float num = 0f;
				float num2 = 0f;
				while (num < size.y)
				{
					if (toDrawVerticalNumbers)
					{
						DrawVerticalNumber($"{_min.y + num2 * Discretization.y:F0}", num);
					}
					if (toDrawHorizontalGridLines)
					{
						DrawHorizontalLine(num);
					}
					num += size.y / vector.y;
					num2 += 1f;
				}
			}
			if (!toDrawHorizontalNumbers && !toDrawVerticalGridLines)
			{
				return;
			}
			float num3 = 0f;
			float num4 = 0f;
			while (num3 < size.x)
			{
				if (toDrawHorizontalNumbers)
				{
					DrawHorizontalNumber($"{_min.x + num4 * Discretization.x:F0}", num3);
				}
				if (toDrawVerticalGridLines)
				{
					DrawVerticalLine(num3);
				}
				num3 += size.x / vector.x;
				num4 += 1f;
			}
		}

		private void PlotInitialGridUI(Vector2 gridSize)
		{
			DrawHorizontalLine(0f);
			DrawVerticalLine(0f);
			if (toDrawVerticalNumbers)
			{
				DrawVerticalNumber($"{_max.y:F0}", gridSize.y);
			}
			if (toDrawHorizontalNumbers)
			{
				DrawHorizontalNumber($"{_max.x:F0}", gridSize.x);
			}
		}

		private void DrawHorizontalLine(float i)
		{
			Vector2 size = gridContainer.rect.size;
			RectTransform obj = (RectTransform)_gridlLinesPool.PoolObject().transform;
			obj.sizeDelta = new Vector2(size.x, gridLineWidth);
			obj.anchorMin = new Vector2(0f, 0f);
			obj.anchorMax = new Vector2(0f, 0f);
			obj.pivot = new Vector2(0f, 0.5f);
			obj.anchoredPosition = new Vector2(0f, i);
		}

		private void DrawVerticalLine(float f)
		{
			Vector2 size = gridContainer.rect.size;
			RectTransform obj = (RectTransform)_gridlLinesPool.PoolObject().transform;
			obj.sizeDelta = new Vector2(gridLineWidth, size.y);
			obj.anchorMin = new Vector2(0f, 0f);
			obj.anchorMax = new Vector2(0f, 0f);
			obj.pivot = new Vector2(0.5f, 0f);
			obj.anchoredPosition = new Vector2(f, 0f);
		}

		private void DrawVerticalNumber(string number, float yPosition)
		{
			if (!string.IsNullOrEmpty(prefixForVerticalText))
			{
				number = prefixForVerticalText + number;
			}
			TMP_Text tMP_Text = _verticalTextPool.PoolObject();
			tMP_Text.text = number;
			tMP_Text.fontSize = gridLineWidth * 5f;
			RectTransform obj = (RectTransform)tMP_Text.transform;
			obj.anchorMin = new Vector2(1f, 0f);
			obj.anchorMax = new Vector2(1f, 0f);
			obj.pivot = new Vector2(1f, 0.5f);
			obj.anchoredPosition = new Vector2(0f, yPosition);
		}

		private void DrawHorizontalNumber(string number, float xPosition)
		{
			if (!string.IsNullOrEmpty(prefixForHorizontalText))
			{
				number = prefixForHorizontalText + number;
			}
			TMP_Text tMP_Text = _horizontalTextPool.PoolObject();
			tMP_Text.text = number;
			tMP_Text.fontSize = gridLineWidth * 5f;
			RectTransform obj = (RectTransform)tMP_Text.transform;
			obj.anchorMin = new Vector2(0f, 1f);
			obj.anchorMax = new Vector2(0f, 1f);
			obj.pivot = new Vector2(0.5f, 1f);
			obj.anchoredPosition = new Vector2(xPosition, 0f);
		}

		private void PlotLine(IEnumerable<Vector2> dataPoints, int id)
		{
			if (dataPoints == null)
			{
				return;
			}
			using IEnumerator<Vector2> enumerator = dataPoints.GetEnumerator();
			Vector2 zero = Vector2.zero;
			if (enumerator.MoveNext())
			{
				zero = enumerator.Current;
				List<Vector2> list = new List<Vector2>();
				while (enumerator.MoveNext())
				{
					Vector2 current = enumerator.Current;
					Vector2 vector = ConvertToUIPos(zero);
					Vector2 end = ConvertToUIPos(current);
					Image dot = CreatePoint(vector);
					Image line = CreateLine(vector, end);
					_dotCreated?.Invoke(id, dot);
					_lineCreated?.Invoke(id, line);
					list.Add(Normalize(zero));
					zero = current;
				}
				Vector2 anchoredPosition = ConvertToUIPos(zero);
				Image dot2 = CreatePoint(anchoredPosition);
				_dotCreated?.Invoke(id, dot2);
				list.Add(Normalize(zero));
				_normalizedLineDotsCalculated?.Invoke(id, list);
			}
		}

		public Vector2 ConvertToUIPos(Vector2 data)
		{
			return Normalize(data) * graphContainer.rect.size;
		}

		private Vector2 Normalize(Vector2 data)
		{
			return (data - _min) / (_max - _min);
		}

		private Image CreatePoint(Vector2 anchoredPosition)
		{
			Image image = _dotsPool.PoolObject();
			PositionPoint(anchoredPosition, image);
			return image;
		}

		public void PositionPoint(Vector2 anchoredPosition, Image pointObject)
		{
			RectTransform obj = (RectTransform)pointObject.transform;
			obj.SetAsLastSibling();
			obj.sizeDelta = new Vector2(dotSize, dotSize);
			obj.anchorMin = new Vector2(0f, 0f);
			obj.anchorMax = new Vector2(0f, 0f);
			obj.anchoredPosition = anchoredPosition;
		}

		private Image CreateLine(Vector2 start, Vector2 end)
		{
			Image image = _linesPool.PoolObject();
			PositionLine(start, end, image);
			return image;
		}

		public void PositionLine(Vector2 start, Vector2 end, Image lineObject)
		{
			RectTransform obj = (RectTransform)lineObject.transform;
			obj.SetAsFirstSibling();
			Vector2 normalized = (end - start).normalized;
			float num = Vector2.Distance(start, end);
			obj.sizeDelta = new Vector2(num, lineWidth);
			obj.anchorMin = new Vector2(0f, 0f);
			obj.anchorMax = new Vector2(0f, 0f);
			obj.anchoredPosition = start + 0.5f * num * normalized;
			obj.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(normalized.y, normalized.x) * 57.29578f);
		}

		public void Clear()
		{
			_dotsPool.Deactivate();
			_linesPool.Deactivate();
			_gridlLinesPool.Deactivate();
			_horizontalTextPool.Deactivate();
			_verticalTextPool.Deactivate();
		}

		public void SetMinMaxOnGraph(Vector2 min, Vector2 max)
		{
			_min = min;
			_max = max;
		}

		public void DrawHighlight(List<Vector2> positions, Color color, Image lineHighlightPrefab)
		{
			UI.Statistics.Utils.Utils.DrawHighlight(positions, color, lineHighlightPrefab, graphContainer, OnHighlightPartCreated);
		}

		private void OnHighlightPartCreated(RectTransform arg0)
		{
			arg0.SetAsFirstSibling();
		}
	}
}
