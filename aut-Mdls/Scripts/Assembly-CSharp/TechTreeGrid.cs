#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class TechTreeGrid : MonoBehaviour
{
	[SerializeField]
	private bool _showGrid = true;

	[SerializeField]
	private float _cellSize = 100f;

	[SerializeField]
	private float _gridLineThickness = 1f;

	[SerializeField]
	private Color _gridLineColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);

	[SerializeField]
	private UILineRenderer _lineRenderer;

	[SerializeField]
	private ScrollRect _targetScrollView;

	private int _columns;

	private int _rows;

	private RectTransform _contentRect;

	public float CellSize => _cellSize;

	private void Awake()
	{
		if (_targetScrollView == null)
		{
			this.LogError("No Scroll View assigned!", "Awake", 24);
			return;
		}
		_contentRect = _targetScrollView.content;
		RectTransform component = _lineRenderer.GetComponent<RectTransform>();
		component.anchorMin = new Vector2(0f, 1f);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchoredPosition = Vector2.zero;
		UpdateGridSize();
	}

	private void UpdateGridSize()
	{
		if (!(_contentRect == null))
		{
			float x = _contentRect.localScale.x;
			float num = _cellSize * x;
			_columns = Mathf.CeilToInt(_contentRect.rect.width / num) * 10;
			_rows = Mathf.CeilToInt(_contentRect.rect.height / num) * 10;
		}
	}

	public void ShowGrid()
	{
		if (_showGrid && !(_contentRect == null))
		{
			UpdateGridSize();
			_lineRenderer.ClearLineSegments();
			List<UILine> list = new List<UILine>();
			for (int i = 0; i <= _columns; i++)
			{
				Vector2 start = GridToCanvasPositionTopLeft(new Vector2Int(i, 0));
				Vector2 end = GridToCanvasPositionTopLeft(new Vector2Int(i, _rows));
				list.Add(new UILine(start, end, _gridLineColor, _gridLineThickness));
			}
			for (int j = 0; j <= _rows; j++)
			{
				Vector2 start2 = GridToCanvasPositionTopLeft(new Vector2Int(0, j));
				Vector2 end2 = GridToCanvasPositionTopLeft(new Vector2Int(_columns, j));
				list.Add(new UILine(start2, end2, _gridLineColor, _gridLineThickness));
			}
			_lineRenderer.AddLineSegment(list);
		}
	}

	public Vector2 GridToCanvasPositionTopLeft(Vector2Int gridPosition)
	{
		if (_contentRect == null)
		{
			return Vector2.zero;
		}
		float x = _contentRect.localScale.x;
		float num = _cellSize * x;
		float x2 = (float)gridPosition.x * num;
		float y = (float)(-gridPosition.y) * num;
		return new Vector2(x2, y);
	}

	public Vector2 GridToCanvasPositionCenter(Vector2Int gridPosition)
	{
		if (_contentRect == null)
		{
			return Vector3.zero;
		}
		float x = (float)gridPosition.x * _cellSize;
		float y = (float)(-gridPosition.y) * _cellSize - _cellSize * 0.5f;
		return new Vector2(x, y);
	}
}
