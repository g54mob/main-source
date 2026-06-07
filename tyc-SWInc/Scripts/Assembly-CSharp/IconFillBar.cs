using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class IconFillBar : MaskableGraphic, IPointerDownHandler, IEventSystemHandler
{
	public Texture IconTexture;

	public Vector2 IconSize = new Vector2(16f, 16f);

	public Vector2 Offset;

	public float IconSpacing = 4f;

	public bool Fade;

	public bool FromCenter;

	public List<float> Values = new List<float> { 6f, 3f };

	public List<Color> Colors = new List<Color>
	{
		Color.gray,
		Color.white
	};

	[NonSerialized]
	private List<float> _cutOff = new List<float>();

	public bool Highlight;

	public Color HighlightColor = new Color(1f, 1f, 1f, 0.8f);

	public Vector2 HightlightUV;

	public UnityEvent OnClick;

	public override Texture mainTexture
	{
		get
		{
			return IconTexture;
		}
	}

	public float this[int i]
	{
		get
		{
			return Values[i];
		}
		set
		{
			Values[i] = value;
			SetVerticesDirty();
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		int num = Mathf.Min(Values.Count, Colors.Count);
		float a = 0f;
		Vector2 vector = new Vector2((0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (1f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
		if (Highlight)
		{
			Rect rect = new Rect(vector.x, vector.y - base.rectTransform.rect.height, base.rectTransform.rect.width, base.rectTransform.rect.height);
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMin, rect.yMax),
					uv0 = HightlightUV
				},
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMax, rect.yMax),
					uv0 = HightlightUV
				},
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMax, rect.yMin),
					uv0 = HightlightUV
				},
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMin, rect.yMin),
					uv0 = HightlightUV
				}
			});
		}
		if (FromCenter)
		{
			int num2 = Mathf.CeilToInt(Values.MaxSafe((float x) => x));
			vector += new Vector2(base.rectTransform.rect.width / 2f - (IconSize.x * (float)num2 + IconSpacing * (float)Mathf.Max(0, num2 - 1)) / 2f, base.rectTransform.rect.height / 2f - IconSize.y / 2f);
		}
		vector += Offset;
		if (_cutOff.Count < num + 1)
		{
			for (int num3 = _cutOff.Count; num3 < num + 1; num3++)
			{
				_cutOff.Add(0f);
			}
		}
		for (int num4 = num - 1; num4 > -1; num4--)
		{
			float num5 = (_cutOff[num4] = Mathf.Max(a, Values[num4]));
			a = num5;
		}
		for (int num7 = 0; num7 < num; num7++)
		{
			float num8 = _cutOff[num7 + 1];
			float num9 = _cutOff[num7];
			if (Mathf.Approximately(num8, num9))
			{
				continue;
			}
			int num10 = Mathf.CeilToInt(num8);
			int num11 = Mathf.FloorToInt(num8);
			int num12 = Mathf.FloorToInt(num9);
			float num13 = num8 - (float)num11;
			float num14 = num9 - (float)num12;
			if (num11 == num12)
			{
				if (Fade && num7 == num - 1)
				{
					DrawIcon(vector.x + (float)num11 * (IconSize.x + IconSpacing), vector.y, num13, 1f, Colors[num7] * new Color(1f, 1f, 1f, num14), vh);
				}
				else
				{
					DrawIcon(vector.x + (float)num11 * (IconSize.x + IconSpacing), vector.y, num13, num14, Colors[num7], vh);
				}
				continue;
			}
			if (!Mathf.Approximately(num13, 0f))
			{
				DrawIcon(vector.x + (float)num11 * (IconSize.x + IconSpacing), vector.y, num13, 1f, Colors[num7], vh);
			}
			for (int num15 = num10; num15 < num12; num15++)
			{
				DrawIcon(vector.x + (float)num15 * (IconSize.x + IconSpacing), vector.y, 0f, 1f, Colors[num7], vh);
			}
			if (!Mathf.Approximately(num14, 0f))
			{
				if (Fade && num7 == num - 1)
				{
					DrawIcon(vector.x + (float)num12 * (IconSize.x + IconSpacing), vector.y, 0f, 1f, Colors[num7] * new Color(1f, 1f, 1f, num14), vh);
				}
				else
				{
					DrawIcon(vector.x + (float)num12 * (IconSize.x + IconSpacing), vector.y, 0f, num14, Colors[num7], vh);
				}
			}
		}
	}

	private void DrawIcon(float x, float y, float startP, float endP, Color col, VertexHelper vh)
	{
		Color color = col * this.color;
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				position = new Vector3(x + startP * IconSize.x, y, 0f),
				uv0 = new Vector2(startP, 1f),
				color = color
			},
			new UIVertex
			{
				position = new Vector3(x + endP * IconSize.x, y, 0f),
				uv0 = new Vector2(endP, 1f),
				color = color
			},
			new UIVertex
			{
				position = new Vector3(x + endP * IconSize.x, y - IconSize.y, 0f),
				uv0 = new Vector2(endP, 0f),
				color = color
			},
			new UIVertex
			{
				position = new Vector3(x + startP * IconSize.x, y - IconSize.y, 0f),
				uv0 = new Vector2(startP, 0f),
				color = color
			}
		});
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		OnClick.Invoke();
	}
}
