using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GUIPieChart : Graphic
{
	public List<float> Values = new List<float> { 1f };

	public List<Color> Colors = new List<Color> { Color.white };

	public List<UIVertex> CachedData = new List<UIVertex>();

	public AnimationCurve DarkCurve;

	public AnimationCurve TransparentCurve;

	public bool Cached;

	public static int PieSections = 20;

	public Text LabelPrefab;

	[NonSerialized]
	private List<Text> _labels = new List<Text>();

	private Vector2 _lastSize;

	public void UpdateCachedPie()
	{
		DrawPieChart(CachedData);
		SetVerticesDirty();
		UpdateLabelPosition();
	}

	protected override void OnRectTransformDimensionsChange()
	{
		base.OnRectTransformDimensionsChange();
		if (Application.isPlaying && (_lastSize - base.rectTransform.rect.size).sqrMagnitude > 64f)
		{
			UpdateLabelPosition();
			_lastSize = base.rectTransform.rect.size;
		}
	}

	public void SetLabels(IEnumerable<string> labels)
	{
		int i = 0;
		foreach (string label in labels)
		{
			if (i < _labels.Count)
			{
				_labels[i].text = label;
			}
			else
			{
				Text text = UnityEngine.Object.Instantiate(LabelPrefab);
				text.text = label;
				text.transform.SetParent(base.transform, false);
				text.transform.SetSiblingIndex(0);
				_labels.Add(text);
			}
			i++;
		}
		for (int count = _labels.Count; i < count; i++)
		{
			UnityEngine.Object.Destroy(_labels[_labels.Count - 1].gameObject);
			_labels.RemoveAt(_labels.Count - 1);
		}
		UpdateLabelPosition();
	}

	private void UpdateLabelPosition()
	{
		if (_labels.Count > 0 && Values.Count == 1)
		{
			_labels[0].rectTransform.anchoredPosition = Vector2.zero;
			Vector3 vector = Utilities.RGBToHSV(Colors[0]);
			_labels[0].color = Utilities.HSVToRGBA(vector.x, vector.y, 1f);
			for (int i = 0; i < _labels.Count; i++)
			{
				_labels[i].gameObject.SetActive(i == 0);
			}
			return;
		}
		float num = Values.SumSafe((float x) => x);
		if (num == 0f)
		{
			for (int num2 = 0; num2 < _labels.Count; num2++)
			{
				_labels[num2].gameObject.SetActive(false);
			}
			return;
		}
		float num3 = 0f;
		for (int num4 = 0; num4 < _labels.Count; num4++)
		{
			Text text = _labels[num4];
			if (num4 < Values.Count && Values[num4] > 0f)
			{
				float num5 = Values[num4] / num * (float)Math.PI * 2f;
				float f = num3 + num5 / 2f;
				text.rectTransform.anchoredPosition = new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height) * 0.33f;
				num3 += num5;
				text.gameObject.SetActive(true);
				Vector3 vector2 = Utilities.RGBToHSV(Colors[num4 % Colors.Count]);
				text.color = Utilities.HSVToRGBA(vector2.x, vector2.y, 1f);
			}
			else
			{
				text.gameObject.SetActive(false);
			}
		}
		FixLabelOverlap();
	}

	private Rect GetLabelRect(Text label)
	{
		return GetLabelRect(label, label.rectTransform.anchoredPosition);
	}

	private Rect GetLabelRect(Text label, Vector2 pos)
	{
		float width = label.rectTransform.rect.width;
		float height = label.rectTransform.rect.height;
		return new Rect(pos.x - width / 2f, pos.y - height / 2f, width, height);
	}

	private void FixLabelOverlap()
	{
		bool flag = true;
		Rect[] array = _labels.SelectInPlace(GetLabelRect);
		while (flag)
		{
			flag = false;
			for (int i = 0; i < _labels.Count; i++)
			{
				Text text = _labels[i];
				if (!text.gameObject.activeSelf)
				{
					continue;
				}
				for (int j = i + 1; j < _labels.Count; j++)
				{
					Text text2 = _labels[j];
					if (text2.gameObject.activeSelf && array[i].Overlaps(array[j]))
					{
						int num = ((text.rectTransform.anchoredPosition.y > text2.rectTransform.anchoredPosition.y) ? 1 : (-1));
						float num2 = array[i].height / 2f + array[j].height / 2f;
						float num3 = (text.rectTransform.anchoredPosition.y + text2.rectTransform.anchoredPosition.y) * 0.5f;
						text.rectTransform.anchoredPosition = new Vector2(text.rectTransform.anchoredPosition.x, (float)num * num2 + num3);
						text2.rectTransform.anchoredPosition = new Vector2(text2.rectTransform.anchoredPosition.x, (float)(-num) * num2 + num3);
						array[i] = GetLabelRect(text);
						array[j] = GetLabelRect(text2);
						flag = true;
					}
				}
			}
		}
		float num4 = Values.SumSafe((float x) => x);
		float num5 = 0f;
		for (int num6 = 0; num6 < _labels.Count; num6++)
		{
			Text text3 = _labels[num6];
			if (!text3.gameObject.activeSelf)
			{
				continue;
			}
			float num7 = Values[num6] / num4 * (float)Math.PI * 2f;
			float f = num5 + num7 / 2f;
			Vector2 vector = new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height) * 0.33f;
			Rect labelRect = GetLabelRect(text3, vector);
			bool flag2 = false;
			for (int num8 = 0; num8 < _labels.Count; num8++)
			{
				Text text4 = _labels[num8];
				if (num8 != num6 && text4.gameObject.activeSelf && labelRect.Overlaps(array[num8]))
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				text3.rectTransform.anchoredPosition = vector;
				array[num6] = labelRect;
			}
			num5 += num7;
		}
		Rect rect = base.rectTransform.rect;
		for (int num9 = 0; num9 < _labels.Count; num9++)
		{
			Text text5 = _labels[num9];
			Rect labelRect2 = GetLabelRect(text5);
			float num10 = (rect.width - labelRect2.width) / 2f;
			float num11 = (rect.height - labelRect2.height) / 2f;
			text5.rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(text5.rectTransform.anchoredPosition.x, 0f - num10, num10), Mathf.Clamp(text5.rectTransform.anchoredPosition.y, 0f - num11, num11));
		}
	}

	protected override void OnPopulateMesh(VertexHelper h)
	{
		if (!Cached)
		{
			DrawPieChart(CachedData);
		}
		if (CachedData == null || CachedData.Count == 0)
		{
			h.Clear();
			return;
		}
		h.Clear();
		Utilities.VBOToHelper(CachedData, h);
	}

	private void DrawPieChart(List<UIVertex> vbo)
	{
		Vector2 vector = Vector2.zero - base.rectTransform.pivot;
		Vector2 vector2 = Vector2.one - base.rectTransform.pivot;
		vector = new Vector2(vector.x * base.rectTransform.rect.width, vector.y * base.rectTransform.rect.height);
		vector2 = new Vector2(vector2.x * base.rectTransform.rect.width, vector2.y * base.rectTransform.rect.height);
		Vector2 center = new Vector2(vector.x + (vector2.x - vector.x) / 2f, vector.y + (vector2.y - vector.y) / 2f);
		float num = Mathf.Min(vector2.x - vector.x, vector2.y - vector.y) / 2f;
		vbo.Clear();
		float num2 = Values.Sum();
		if (!(num2 <= 0f))
		{
			float num3 = 0f;
			for (int i = 0; i < Values.Count; i++)
			{
				float num4 = Values[i] / num2;
				float num5 = num4 * (float)Math.PI * 2f;
				int sections = Mathf.Max(1, Mathf.RoundToInt(num4 * (float)PieSections));
				DrawArc(num3, num3 + num5, sections, center, num, Colors[i % Colors.Count], vbo, center.y - num, center.y + num);
				num3 += num5;
			}
		}
	}

	private void DrawArc(float start, float end, int sections, Vector2 center, float radius, Color color, List<UIVertex> vbo, float top, float bottom)
	{
		UIVertex simpleVert = UIVertex.simpleVert;
		float num = (end - start) / (float)sections;
		float num2 = top - bottom;
		if (num2 == 0f)
		{
			num2 = 1f;
		}
		for (int i = 0; i < sections; i++)
		{
			simpleVert.position = new Vector2(center.x, center.y);
			float time = (simpleVert.position.y - bottom) / num2;
			simpleVert.color = MultCol(color, DarkCurve.Evaluate(time), TransparentCurve.Evaluate(time));
			vbo.Add(simpleVert);
			float f = start + (float)i * num;
			simpleVert.position = new Vector2(center.x + Mathf.Cos(f) * radius, center.y + Mathf.Sin(f) * radius);
			time = (simpleVert.position.y - bottom) / num2;
			simpleVert.color = MultCol(color, DarkCurve.Evaluate(time), TransparentCurve.Evaluate(time));
			vbo.Add(simpleVert);
			f = start + (float)i * num + num / 2f;
			simpleVert.position = new Vector2(center.x + Mathf.Cos(f) * radius, center.y + Mathf.Sin(f) * radius);
			time = (simpleVert.position.y - bottom) / num2;
			simpleVert.color = MultCol(color, DarkCurve.Evaluate(time), TransparentCurve.Evaluate(time));
			vbo.Add(simpleVert);
			f = start + (float)i * num + num;
			simpleVert.position = new Vector2(center.x + Mathf.Cos(f) * radius, center.y + Mathf.Sin(f) * radius);
			time = (simpleVert.position.y - bottom) / num2;
			simpleVert.color = MultCol(color, DarkCurve.Evaluate(time), TransparentCurve.Evaluate(time));
			vbo.Add(simpleVert);
		}
	}

	private Color MultCol(Color c, float t, float t2)
	{
		return new Color(c.r * t, c.g * t, c.b * t, c.a * t2);
	}
}
