using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIBarChart : MaskableGraphic, IPointerEnterHandler, IEventSystemHandler
{
	[SerializeField]
	public List<List<float>> Values = new List<List<float>>
	{
		new List<float> { 1f, 2f, 4f, -2f, -5f },
		new List<float> { 2f, -2f, 4f, -2f, 3f }
	};

	public List<Color> Colors = new List<Color>();

	public float spacing = 5f;

	public float BottomLineWidth = 2f;

	public Color BottomLineColor = Color.white;

	public List<UIVertex> CachedData = new List<UIVertex>();

	public Action<int> HighlightCallback;

	public bool Cached;

	public bool AbsoluteScale;

	public bool Log;

	public Color Secondary;

	public Func<int, float, float, string> ToolTipFunc;

	public int ColorOffset;

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
				UpdateCachedBars();
			}
		}
	}

	protected override void Awake()
	{
		if (Colors == null || Colors.Count == 0)
		{
			Colors = new List<Color>(HUD.GetThemeColors());
		}
	}

	public void UpdateCachedBars()
	{
		DrawBarChart(CachedData);
		SetVerticesDirty();
	}

	protected override void OnPopulateMesh(VertexHelper h)
	{
		if (!Cached)
		{
			DrawBarChart(CachedData);
		}
		if (CachedData == null || CachedData.Count == 0)
		{
			h.Clear();
			return;
		}
		h.Clear();
		Utilities.VBOToHelper(CachedData, h);
	}

	private void FindMinMax(int count, out float min, out float max, out float aMin, out float aMax)
	{
		min = (aMin = 0f);
		max = (aMax = 1f);
		for (int i = 0; i < count; i++)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			for (int j = 0; j < Values.Count; j++)
			{
				if (Values[j][i] > 0f)
				{
					num += GetValue(j, i);
				}
				else
				{
					num2 += GetValue(j, i);
				}
				if (Values[j][i] > 0f)
				{
					num3 += Values[j][i];
				}
				else
				{
					num4 += Values[j][i];
				}
			}
			min = Mathf.Min(min, num2);
			max = Mathf.Max(max, num);
			aMin = Mathf.Min(aMin, num4);
			aMax = Mathf.Max(aMax, num3);
		}
	}

	private float GetValue(List<float> vv, int i)
	{
		float num = vv[i];
		if (Log)
		{
			bool num2 = num < 0f;
			if (num2)
			{
				num = 0f - num;
			}
			num = ((num == 0f) ? 0f : Mathf.Log(num + 1f));
			if (num2)
			{
				num = 0f - num;
			}
		}
		return num;
	}

	private float GetValue(int j, int i)
	{
		return GetValue(Values[j], i);
	}

	private void DrawBarChart(List<UIVertex> vbo)
	{
		_lastHeight = base.rectTransform.rect.height;
		_lastWidth = base.rectTransform.rect.width;
		base.rectTransform.localScale = Vector3.one;
		Vector2 zero = Vector2.zero;
		Vector2 one = Vector2.one;
		zero.x -= base.rectTransform.pivot.x;
		zero.y -= base.rectTransform.pivot.y;
		one.x -= base.rectTransform.pivot.x;
		one.y -= base.rectTransform.pivot.y;
		zero.x *= base.rectTransform.rect.width;
		zero.y *= base.rectTransform.rect.height;
		one.x *= base.rectTransform.rect.width;
		one.y *= base.rectTransform.rect.height;
		vbo.Clear();
		UIVertex simpleVert = UIVertex.simpleVert;
		int num = ((Values.Count != 0) ? Values.MinSafeInt((List<float> z) => z.Count) : 0);
		float min;
		float max;
		float aMin;
		float aMax;
		FindMinMax(num, out min, out max, out aMin, out aMax);
		if (min == max)
		{
			return;
		}
		float num2 = 1f;
		float num3 = 1f;
		if (AbsoluteScale && Log)
		{
			float num4 = Mathf.Max(aMax, 0f - aMin);
			num2 = aMax / num4;
			num3 = (0f - aMin) / num4;
		}
		float num5 = 0f.MapRange(min, max, zero.y, one.y);
		int num6 = Mathf.RoundToInt(Mathf.Clamp((one.x - zero.x) / (float)num - spacing, 0f, spacing));
		float num7 = (one.x - zero.x + (float)num6) / (float)num - (float)num6;
		float num8 = zero.x;
		float[] array = Values.Select(GetRange).ToArray();
		for (int num9 = 0; num9 < num; num9++)
		{
			float num10 = num5;
			float num11 = num5;
			for (int num12 = 0; num12 < Values.Count; num12++)
			{
				Color color = ((Colors.Count == 0) ? this.color : Colors[(num12 + ColorOffset) % Colors.Count]);
				Color color2 = ((Values.Count == 1 && Values[num12][num9] < 0f) ? Secondary : color);
				if (Highlighted == num12)
				{
					color2 = new Color(Mathf.Min(1f, color2.r + 0.25f), Mathf.Min(1f, color2.g + 0.25f), Mathf.Min(1f, color2.b + 0.25f), color2.a);
					simpleVert.color = color2;
				}
				float num13 = ((Values[num12][num9] < 0f) ? num3 : num2);
				float num14 = (GetValue(num12, num9) * num13).MapRange(min, max, zero.y, one.y) - num5;
				float num15 = ((Values[num12][num9] < 0f) ? num10 : num11);
				float num16 = num15 + num14;
				simpleVert.position = new Vector2(num8, num15);
				float num17 = 0f;
				float num18 = ((Highlighted != num12) ? (array[num12] / (max - min)) : 1f);
				num18 *= one.y - zero.y;
				if (Highlighted != num12)
				{
					num17 = (simpleVert.position.y - zero.y) / num18;
					num17 = Mathf.Lerp(0.8f, 1f, num17);
					simpleVert.color = MultCol(color2, num17);
				}
				vbo.Add(simpleVert);
				simpleVert.position = new Vector2(num8, num16);
				if (Highlighted != num12)
				{
					num17 = (simpleVert.position.y - zero.y) / num18;
					num17 = Mathf.Lerp(0.8f, 1f, num17);
					simpleVert.color = MultCol(color2, num17);
				}
				vbo.Add(simpleVert);
				simpleVert.position = new Vector2(num8 + num7, num16);
				if (Highlighted != num12)
				{
					num17 = (simpleVert.position.y - zero.y) / num18;
					num17 = Mathf.Lerp(0.8f, 1f, num17);
					simpleVert.color = MultCol(color2, num17);
				}
				vbo.Add(simpleVert);
				simpleVert.position = new Vector2(num8 + num7, num15);
				if (Highlighted != num12)
				{
					num17 = (simpleVert.position.y - zero.y) / num18;
					num17 = Mathf.Lerp(0.8f, 1f, num17);
					simpleVert.color = MultCol(color2, num17);
				}
				vbo.Add(simpleVert);
				if (Values[num12][num9] < 0f)
				{
					num10 = num16;
				}
				else
				{
					num11 = num16;
				}
			}
			num8 += num7 + (float)num6;
		}
		if (max > 0f && min < 0f)
		{
			GUILineChart.DrawLine(new Vector2(zero.x, num5), new Vector2(one.x, num5), BottomLineWidth, BottomLineColor, vbo);
		}
	}

	private float GetRange(List<float> values)
	{
		float num = 0f;
		for (int i = 0; i < values.Count; i++)
		{
			num = Mathf.Max(Mathf.Abs(GetValue(values, i)), num);
		}
		if (num != 0f)
		{
			return num;
		}
		return 1f;
	}

	private Color MultCol(Color c, float t)
	{
		return new Color(c.r * t, c.g * t, c.b * t, c.a);
	}

	private void Update()
	{
		if (Cached && _lastWidth > 0f && (_lastWidth != base.rectTransform.rect.width || _lastHeight != base.rectTransform.rect.height))
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
				Highlighted = -1;
				_toolTip = false;
				return;
			}
			Vector2 localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
			int num = Values.MinSafeInt((List<float> z) => z.Count);
			int num2 = Mathf.Clamp(Mathf.FloorToInt((localPoint.x + base.rectTransform.pivot.x * base.rectTransform.rect.width) / base.rectTransform.rect.width * (float)num), 0, Mathf.Max(0, num - 1));
			float min;
			float max;
			float aMin;
			float aMax;
			FindMinMax(num, out min, out max, out aMin, out aMax);
			float num3 = 0.MapRange(min, max, (0f - base.rectTransform.rect.height) * base.rectTransform.pivot.y, base.rectTransform.rect.height * base.rectTransform.pivot.y);
			float num4 = num3;
			float num5 = num3;
			float num6 = 0f;
			int num7 = 0;
			int num8 = -1;
			int num9 = -1;
			for (; num7 < Values.Count; num7++)
			{
				if (num2 < Values[num7].Count)
				{
					float num10 = GetValue(num7, num2).MapRange(min, max, (0f - base.rectTransform.rect.height) * base.rectTransform.pivot.y, base.rectTransform.rect.height * base.rectTransform.pivot.y) - num3;
					float num11 = ((Values[num7][num2] < 0f) ? num4 : num5);
					float num12 = num11 + num10;
					if (num11 > num12)
					{
						float num13 = num11;
						num11 = num12;
						num12 = num13;
					}
					if (localPoint.y >= num11 && localPoint.y <= num12)
					{
						num6 = (num11 + num12) / 2f;
						break;
					}
					if (localPoint.y < num11)
					{
						num6 = (num11 + num12) / 2f;
						num8 = num7;
					}
					if (localPoint.y > num12)
					{
						num6 = (num11 + num12) / 2f;
						num9 = num7;
					}
					if (Values[num7][num2] < 0f)
					{
						num4 = num12;
					}
					else
					{
						num5 = num12;
					}
				}
			}
			if (num7 >= Values.Count)
			{
				num7 = ((num9 > -1) ? num9 : num8);
				if (num7 < 0 || num7 >= Values.Count)
				{
					Tooltip.Hide();
					_toolTip = false;
					return;
				}
			}
			while (num7 > 0 && (num2 >= Values[num7].Count || Values[num7][num2] == 0f))
			{
				num7--;
			}
			if (num2 >= Values[num7].Count)
			{
				Tooltip.Hide();
				_toolTip = false;
				Highlighted = -1;
			}
			else
			{
				Highlighted = num7;
				Vector2 vector = new Vector2((float)num2 * (base.rectTransform.rect.width / (float)num) - base.rectTransform.pivot.x * base.rectTransform.rect.width, num6 + 32f);
				Vector2 uIScreenPosition = base.rectTransform.GetUIScreenPosition();
				Tooltip.UpdateToolTip(ToolTipFunc(num2, Values[num7][num2], GetSum(num2)), null, new Vector2(uIScreenPosition.x / Options.UISize + vector.x, (0f - ((float)Screen.height - uIScreenPosition.y)) / Options.UISize + vector.y));
			}
		}
		else
		{
			Highlighted = -1;
			_toolTip = false;
		}
	}

	private float GetSum(int idx)
	{
		float num = 0f;
		if (Values != null)
		{
			for (int i = 0; i < Values.Count; i++)
			{
				if (idx < Values[i].Count)
				{
					num += Values[i][idx];
				}
			}
		}
		return num;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (ToolTipFunc != null && Values != null && Values.Count > 0 && Values.Any((List<float> x) => x.Count > 0))
		{
			_toolTip = true;
			Tooltip.SetToolTip("0", null, base.rectTransform);
		}
	}
}
