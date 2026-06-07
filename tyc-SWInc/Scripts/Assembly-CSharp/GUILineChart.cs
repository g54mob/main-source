using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUILineChart : Graphic, IPointerEnterHandler, IEventSystemHandler
{
	public List<List<float>> Values = new List<List<float>>
	{
		new List<float> { -1f, 8f, 4f, 6f },
		new List<float> { -4f, 3f, 2f }
	};

	public List<Color> Colors = new List<Color> { Color.white };

	public List<UIVertex> CachedData = new List<UIVertex>();

	public bool Cached;

	public Func<int, int, float, string> ToolTipFunc;

	public Action<int> HighlightCallback;

	public bool ForceLimits;

	public bool ForceLowerLimit;

	public bool Currency = true;

	public float LowerLimit;

	public float UpperLimit = 1f;

	[NonSerialized]
	private int _highlighted = -1;

	private float _lastHeight;

	private float _lastWidth;

	private bool _toolTip;

	public int Highlighted
	{
		get
		{
			return _highlighted;
		}
		set
		{
			if (_highlighted != value)
			{
				if (HighlightCallback != null)
				{
					HighlightCallback(value);
				}
				_highlighted = value;
				UpdateCachedLines();
			}
		}
	}

	public void UpdateCachedLines()
	{
		DrawCharts(CachedData);
		SetVerticesDirty();
	}

	protected override void OnPopulateMesh(VertexHelper h)
	{
		if (!Cached)
		{
			DrawCharts(CachedData);
		}
		if (CachedData == null || CachedData.Count == 0)
		{
			h.Clear();
			return;
		}
		h.Clear();
		Utilities.VBOToHelper(CachedData, h);
	}

	private void DrawCharts(List<UIVertex> vbo)
	{
		_lastHeight = base.rectTransform.rect.height;
		_lastWidth = base.rectTransform.rect.width;
		base.rectTransform.localScale = Vector3.one;
		if (Values == null || Values.Count == 0 || Colors == null || Colors.Count == 0)
		{
			vbo.Clear();
			return;
		}
		Vector2 zero = Vector2.zero;
		Vector2 zero2 = Vector2.zero;
		zero.x = 0f;
		zero.y = 0f;
		zero2.x = 1f;
		zero2.y = 1f;
		zero.x -= base.rectTransform.pivot.x;
		zero.y -= base.rectTransform.pivot.y;
		zero2.x -= base.rectTransform.pivot.x;
		zero2.y -= base.rectTransform.pivot.y;
		zero.x *= base.rectTransform.rect.width;
		zero.y *= base.rectTransform.rect.height;
		zero2.x *= base.rectTransform.rect.width;
		zero2.y *= base.rectTransform.rect.height;
		vbo.Clear();
		int num = Values.Select((List<float> x) => x.Count).Max() - 1;
		float width = (zero2.x - zero.x) / (float)num;
		float num2 = ((ForceLimits || ForceLowerLimit) ? LowerLimit : Values.Select((List<float> x) => (x.Count != 0) ? x.Min() : 0f).Min());
		float num3 = (ForceLimits ? UpperLimit : Values.Select((List<float> x) => (x.Count != 0) ? x.Max() : 1f).Max());
		float f = Mathf.Max(Mathf.Abs(num2), Mathf.Abs(num3));
		f = Mathf.Pow(10f, Mathf.Floor(Mathf.Log10(f)));
		if (Currency)
		{
			num2 = num2.CurrencyRoundDownToNearest(f);
			num3 = num3.CurrencyRoundUpToNearest(f);
		}
		if (num > 1 && Values[0].Count < 512)
		{
			float num4 = zero2.x - zero.x;
			int num5 = 24;
			float num6 = num4 / (float)num;
			float num7 = Mathf.Floor(Mathf.Max(1f, (float)num5 / num6)) * num6;
			for (float num8 = num7; num8 < num4; num8 += num7)
			{
				DrawLine(new Vector2(zero.x + num8, zero.y), new Vector2(zero.x + num8, zero2.y), 1f, Color.gray, vbo);
				if (vbo.Count > 40000)
				{
					return;
				}
			}
		}
		for (int num9 = 0; num9 < Values.Count; num9++)
		{
			if (num9 != Highlighted)
			{
				DrawLine(num9, zero, zero2, width, num2, num3, vbo);
			}
		}
		if (num3 > 0f && num2 < 0f)
		{
			float y = 0.MapRange(num2, num3, zero.y, zero2.y);
			DrawLine(new Vector2(zero.x, y), new Vector2(zero2.x, y), 2f, Color.white, vbo);
		}
		if (Highlighted > -1 && Highlighted < Values.Count)
		{
			DrawLine(Highlighted, zero, zero2, width, num2, num3, vbo);
		}
	}

	private void DrawLine(int j, Vector2 corner1, Vector2 corner2, float width, float min, float max, List<UIVertex> vbo)
	{
		if (vbo.Count > 40000)
		{
			return;
		}
		Color color = ((Highlighted > -1 && Highlighted != j) ? Colors[j % Colors.Count].Alpha(0.5f) : Colors[j % Colors.Count]);
		float width2 = ((Highlighted == j) ? 3f : 2f);
		List<float> list = Values[j];
		if (list.Count == 0)
		{
			return;
		}
		int num = Mathf.Max(1, Mathf.FloorToInt((float)list.Count / (corner2.x - corner1.x)));
		int num2 = 0;
		float x = list[0];
		int num3 = 0;
		float num4 = 0f;
		for (int i = 1; i < list.Count; i++)
		{
			if (i % num == 0 || i == list.Count - 1)
			{
				float num5 = list[i];
				if (num3 > 0)
				{
					num5 += num4;
					num3++;
					num5 /= (float)num3;
				}
				DrawLine(new Vector2(corner1.x + (float)num2 * width, x.MapRange(min, max, corner1.y, corner2.y)), new Vector2(corner1.x + (float)i * width, num5.MapRange(min, max, corner1.y, corner2.y)), width2, color, vbo);
				num2 = i;
				x = num5;
				num4 = 0f;
				num3 = 0;
				if (vbo.Count > 40000)
				{
					break;
				}
			}
			else
			{
				num4 += list[i];
				num3++;
			}
		}
	}

	public static void DrawLine(Vector2 p1, Vector2 p2, float width, Color color, List<UIVertex> vbo, float bottom, float top)
	{
		Vector2 normalized = new Vector2(p1.y - p2.y, p2.x - p1.x).normalized;
		UIVertex simpleVert = UIVertex.simpleVert;
		simpleVert.position = new Vector2(p1.x + normalized.x * width / 2f, p1.y + normalized.y * width / 2f);
		float num = (simpleVert.position.y - bottom) / (top - bottom);
		num = Mathf.Lerp(0.8f, 1f, 1f - num);
		simpleVert.color = MultCol(color, num);
		vbo.Add(simpleVert);
		simpleVert.position = new Vector2(p2.x + normalized.x * width / 2f, p2.y + normalized.y * width / 2f);
		num = (simpleVert.position.y - bottom) / (top - bottom);
		num = Mathf.Lerp(0.8f, 1f, 1f - num);
		simpleVert.color = MultCol(color, num);
		vbo.Add(simpleVert);
		simpleVert.position = new Vector2(p2.x - normalized.x * width / 2f, p2.y - normalized.y * width / 2f);
		num = (simpleVert.position.y - bottom) / (top - bottom);
		num = Mathf.Lerp(0.8f, 1f, 1f - num);
		simpleVert.color = MultCol(color, num);
		vbo.Add(simpleVert);
		simpleVert.position = new Vector2(p1.x - normalized.x * width / 2f, p1.y - normalized.y * width / 2f);
		num = (simpleVert.position.y - bottom) / (top - bottom);
		num = Mathf.Lerp(0.8f, 1f, 1f - num);
		simpleVert.color = MultCol(color, num);
		vbo.Add(simpleVert);
	}

	private static Color MultCol(Color c, float t)
	{
		return new Color(c.r * t, c.g * t, c.b * t, c.a);
	}

	public static void DrawLine(Vector2 p1, Vector2 p2, float width, Color color, List<UIVertex> vbo)
	{
		Vector2 normalized = new Vector2(p1.y - p2.y, p2.x - p1.x).normalized;
		UIVertex simpleVert = UIVertex.simpleVert;
		simpleVert.position = new Vector2(p1.x + normalized.x * width / 2f, p1.y + normalized.y * width / 2f);
		simpleVert.color = color;
		vbo.Add(simpleVert);
		simpleVert.position = new Vector2(p2.x + normalized.x * width / 2f, p2.y + normalized.y * width / 2f);
		simpleVert.color = color;
		vbo.Add(simpleVert);
		simpleVert.position = new Vector2(p2.x - normalized.x * width / 2f, p2.y - normalized.y * width / 2f);
		simpleVert.color = color;
		vbo.Add(simpleVert);
		simpleVert.position = new Vector2(p1.x - normalized.x * width / 2f, p1.y - normalized.y * width / 2f);
		simpleVert.color = color;
		vbo.Add(simpleVert);
	}

	private void Update()
	{
		if (Cached && _lastWidth != 0f && (_lastWidth != base.rectTransform.rect.width || _lastHeight != base.rectTransform.rect.height))
		{
			base.rectTransform.localScale = new Vector3(base.rectTransform.rect.width / _lastWidth, base.rectTransform.rect.height / _lastHeight, 1f);
		}
		if (!_toolTip)
		{
			return;
		}
		if (Tooltip.IsShowing)
		{
			if (Tooltip.CurrentRect != base.rectTransform)
			{
				_toolTip = false;
				Highlighted = -1;
				return;
			}
			if (Values.Count == 0)
			{
				Tooltip.Hide();
				_toolTip = false;
				Highlighted = -1;
				return;
			}
			Vector2 localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
			int num = 0;
			float num2 = float.MaxValue;
			float num3 = 0f;
			int b = Mathf.Clamp(Mathf.RoundToInt((localPoint.x + base.rectTransform.pivot.x * base.rectTransform.rect.width) / base.rectTransform.rect.width * (float)(Values[num].Count - 1)), 0, Values[num].Count - 1);
			b = Mathf.Max(0, b);
			float num4 = (ForceLowerLimit ? LowerLimit : Values.Select((List<float> x) => (x.Count != 0) ? x.Min() : 0f).Min());
			float num5 = Values.Select((List<float> x) => (x.Count != 0) ? x.Max() : 1f).Max();
			float f = Mathf.Max(Mathf.Abs(num4), Mathf.Abs(num5));
			f = Mathf.Pow(10f, Mathf.Floor(Mathf.Log10(f)));
			if (Currency)
			{
				num4 = num4.CurrencyRoundDownToNearest(f);
				num5 = num5.CurrencyRoundUpToNearest(f);
			}
			for (int num6 = 0; num6 < Values.Count; num6++)
			{
				if (b < Values[num6].Count)
				{
					float num7 = Values[num6][b].MapRange(num4, num5, (0f - base.rectTransform.rect.height) * base.rectTransform.pivot.y, base.rectTransform.rect.height * base.rectTransform.pivot.y);
					float num8 = Mathf.Abs(num7 - localPoint.y);
					if (num8 < num2)
					{
						num = num6;
						num2 = num8;
						num3 = num7;
					}
				}
			}
			if (b >= Values[num].Count)
			{
				Tooltip.Hide();
				_toolTip = false;
				Highlighted = -1;
			}
			else
			{
				Highlighted = num;
				Vector2 vector = new Vector2((float)b * (base.rectTransform.rect.width / (float)Mathf.Max(1, Values[num].Count - 1)) - base.rectTransform.pivot.x * base.rectTransform.rect.width, num3 + 32f);
				Vector2 uIScreenPosition = base.rectTransform.GetUIScreenPosition();
				Tooltip.UpdateToolTip(ToolTipFunc(num, b, Values[num][b]), null, new Vector2(uIScreenPosition.x / Options.UISize + vector.x, (0f - ((float)Screen.height - uIScreenPosition.y)) / Options.UISize + vector.y));
			}
		}
		else
		{
			Highlighted = -1;
			_toolTip = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (ToolTipFunc != null && Values != null && Values.Any((List<float> x) => x.Count > 0))
		{
			_toolTip = true;
			Tooltip.SetToolTip("0", null, base.rectTransform);
		}
	}
}
