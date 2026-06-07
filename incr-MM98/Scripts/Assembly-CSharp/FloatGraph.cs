using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class FloatGraph : Graphic
{
	[SerializeField]
	private int maxSamples = 60;

	[SerializeField]
	private float minVisibleMax = 100f;

	[SerializeField]
	private float lineThickness = 3f;

	[SerializeField]
	private int smoothingWindow = 5;

	[SerializeField]
	private Color backgroundColor = Color.black;

	[SerializeField]
	private Color gridColor = Color.green;

	[SerializeField]
	private float gridLineThickness = 2f;

	[SerializeField]
	private int horizontalGridLines = 5;

	[SerializeField]
	private int verticalGridLines = 10;

	private readonly List<float> _samples = new List<float>();

	private float _currentVisibleMax;

	private int _totalSamplesAdded;

	private float _lastSmoothedValue;

	private bool _hasSmoothedValue;

	protected override void Awake()
	{
		base.Awake();
		_currentVisibleMax = minVisibleMax;
		if (!material)
		{
			material = Graphic.defaultGraphicMaterial;
		}
	}

	public void AddSample(double value)
	{
		AddSample((float)value);
	}

	public void AddSample(float value)
	{
		if ((bool)this)
		{
			if (_samples.Count >= maxSamples)
			{
				_samples.RemoveAt(0);
			}
			_samples.Add(AverageValue(Mathf.Max(0f, value)));
			_totalSamplesAdded++;
			if (_totalSamplesAdded > maxSamples * 2)
			{
				_totalSamplesAdded -= maxSamples;
			}
			UpdateVisibleMax();
			SetVerticesDirty();
		}
	}

	public void Clear()
	{
		_currentVisibleMax = minVisibleMax;
		_samples.Clear();
		SetVerticesDirty();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Rect rect = base.rectTransform.rect;
		float width = rect.width;
		float height = rect.height;
		DrawBackground(vh, width, height);
		DrawGrid(vh, width, height);
		DrawSamples(vh, width, height);
	}

	private float AverageValue(float value)
	{
		int num = Mathf.Min(smoothingWindow - 1, _samples.Count);
		if (num <= 0)
		{
			return value;
		}
		float num2 = value;
		for (int i = 0; i < num; i++)
		{
			num2 += _samples[_samples.Count - 1 - i];
		}
		return num2 / (float)(num + 1);
	}

	private void DrawBackground(VertexHelper vh, float width, float height)
	{
		int currentVertCount = vh.currentVertCount;
		vh.AddVert(new Vector3(0f, 0f), backgroundColor, Vector2.zero);
		vh.AddVert(new Vector3(0f, height), backgroundColor, Vector2.zero);
		vh.AddVert(new Vector3(width, height), backgroundColor, Vector2.zero);
		vh.AddVert(new Vector3(width, 0f), backgroundColor, Vector2.zero);
		vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		vh.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
	}

	private void DrawGrid(VertexHelper vh, float width, float height)
	{
		if (horizontalGridLines > 0)
		{
			float num = height / (float)(horizontalGridLines + 1);
			for (int i = 1; i <= horizontalGridLines; i++)
			{
				float y = num * (float)i;
				DrawLineSegment(vh, new Vector2(0f, y), new Vector2(width, y), gridLineThickness, gridColor);
			}
		}
		if (verticalGridLines > 0 && maxSamples > 0)
		{
			float num2 = width / (float)(maxSamples - 1);
			int num3 = Mathf.CeilToInt((float)maxSamples / (float)verticalGridLines);
			if (num3 < 1)
			{
				num3 = 1;
			}
			int num4 = Mathf.Max(-1, _totalSamplesAdded - 1) % num3;
			if (num4 < 0)
			{
				num4 += num3;
			}
			for (int num5 = maxSamples - 1 - num4; num5 >= 0; num5 -= num3)
			{
				float x = (float)num5 * num2;
				DrawLineSegment(vh, new Vector2(x, 0f), new Vector2(x, height), gridLineThickness, gridColor);
			}
		}
	}

	private void DrawSamples(VertexHelper vh, float width, float height)
	{
		if (maxSamples > 1 && _samples.Count > 1)
		{
			float num = width / (float)(maxSamples - 1);
			int num2 = maxSamples - _samples.Count;
			for (int i = 0; i < _samples.Count - 1; i++)
			{
				float x = num * (float)(i + num2);
				float x2 = num * (float)(i + 1 + num2);
				float y = NormalizeSample(_samples[i]) * height;
				float y2 = NormalizeSample(_samples[i + 1]) * height;
				DrawLineSegment(vh, new Vector2(x, y), new Vector2(x2, y2), lineThickness, color);
			}
		}
	}

	private float NormalizeSample(float value)
	{
		if (_currentVisibleMax < 0.0001f)
		{
			return 0f;
		}
		return Mathf.Clamp01(value / _currentVisibleMax);
	}

	private void UpdateVisibleMax()
	{
		float num = minVisibleMax;
		foreach (float sample in _samples)
		{
			if (sample > num)
			{
				num = sample;
			}
		}
		_currentVisibleMax = num;
	}

	private void DrawLineSegment(VertexHelper vh, Vector2 start, Vector2 end, float thickness, Color lineColor)
	{
		Vector2 normalized = (end - start).normalized;
		Vector2 vector = new Vector2(0f - normalized.y, normalized.x) * (thickness * 0.5f);
		Vector2 vector2 = start + vector;
		Vector2 vector3 = start - vector;
		Vector2 vector4 = end - vector;
		Vector2 vector5 = end + vector;
		int currentVertCount = vh.currentVertCount;
		vh.AddVert(vector2, lineColor, Vector2.zero);
		vh.AddVert(vector3, lineColor, Vector2.zero);
		vh.AddVert(vector4, lineColor, Vector2.zero);
		vh.AddVert(vector5, lineColor, Vector2.zero);
		vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		vh.AddTriangle(currentVertCount, currentVertCount + 2, currentVertCount + 3);
	}
}
