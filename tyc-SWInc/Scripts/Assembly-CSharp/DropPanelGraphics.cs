using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropPanelGraphics : MaskableGraphic, IPointerDownHandler, IEventSystemHandler, IScrollHandler
{
	[Serializable]
	public class SelectEvent : UnityEvent<int>
	{
	}

	public Texture Tex;

	public Text Label;

	public RectTransform Highlight;

	public Color OtherRow;

	[NonSerialized]
	public int CurrentHighlight;

	[NonSerialized]
	private float _lineHeight = -1f;

	public SelectEvent OnSelect;

	public SelectEvent OnScrolling;

	public float LineHeight
	{
		get
		{
			if (_lineHeight == -1f)
			{
				_lineHeight = Label.GetLineHeightFloat();
				Highlight.sizeDelta = new Vector2(Highlight.sizeDelta.x, _lineHeight);
			}
			return _lineHeight;
		}
	}

	public override Texture mainTexture
	{
		get
		{
			return Tex;
		}
	}

	private void Update()
	{
		Vector2 localPoint = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
		int num = Mathf.FloorToInt((0f - localPoint.y) / LineHeight);
		if (num >= 0 && num < Mathf.FloorToInt(base.rectTransform.rect.height / LineHeight))
		{
			CurrentHighlight = num;
			Highlight.gameObject.SetActive(true);
			Highlight.anchoredPosition = new Vector2(0f, (float)(-num) * LineHeight);
		}
		else
		{
			CurrentHighlight = -1;
			Highlight.gameObject.SetActive(false);
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		Vector2 vector = Vector2.zero - base.rectTransform.pivot;
		Vector2 vector2 = Vector2.one - base.rectTransform.pivot;
		vector = new Vector2(vector.x * base.rectTransform.rect.width, vector.y * base.rectTransform.rect.height);
		vector2 = new Vector2(vector2.x * base.rectTransform.rect.width, vector2.y * base.rectTransform.rect.height);
		vh.Clear();
		float lineHeight = LineHeight;
		int num = Mathf.FloorToInt(base.rectTransform.rect.height / lineHeight);
		if ((float)num * lineHeight == base.rectTransform.rect.height && num > 0)
		{
			num--;
		}
		float x = vector.x;
		float x2 = vector2.x;
		for (int i = 0; i < num; i++)
		{
			float num2 = vector2.y - (float)i * lineHeight;
			float y = num2 - lineHeight;
			Color color = (((i & 1) == 0) ? this.color : (OtherRow * this.color));
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(x, num2),
					color = color,
					uv0 = new Vector2(0f, 0.5f)
				},
				new UIVertex
				{
					position = new Vector3(x2, num2),
					color = color,
					uv0 = new Vector2(1f, 0.5f)
				},
				new UIVertex
				{
					position = new Vector3(x2, y),
					color = color,
					uv0 = new Vector2(1f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(x, y),
					color = color,
					uv0 = new Vector2(0f, 1f)
				}
			});
		}
		float num3 = Mathf.Min(lineHeight, base.rectTransform.rect.height - (float)num * lineHeight);
		if (num3 > 0f)
		{
			float num4 = vector2.y - (float)num * lineHeight;
			float y2 = num4 - num3;
			Color color2 = (((num & 1) == 0) ? this.color : (OtherRow * this.color));
			float y3 = num3 / (lineHeight * 2f);
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(x, num4),
					color = color2,
					uv0 = new Vector2(0f, y3)
				},
				new UIVertex
				{
					position = new Vector3(x + 16f, num4),
					color = color2,
					uv0 = new Vector2(0.25f, y3)
				},
				new UIVertex
				{
					position = new Vector3(x + 16f, y2),
					color = color2,
					uv0 = new Vector2(0.25f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(x, y2),
					color = color2,
					uv0 = new Vector2(0f, 0f)
				}
			});
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(x2 - 16f, num4),
					color = color2,
					uv0 = new Vector2(0.75f, y3)
				},
				new UIVertex
				{
					position = new Vector3(x2, num4),
					color = color2,
					uv0 = new Vector2(1f, y3)
				},
				new UIVertex
				{
					position = new Vector3(x2, y2),
					color = color2,
					uv0 = new Vector2(1f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(x2 - 16f, y2),
					color = color2,
					uv0 = new Vector2(0.75f, 0f)
				}
			});
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(x + 16f, num4),
					color = color2,
					uv0 = new Vector2(0f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(x2 - 16f, num4),
					color = color2,
					uv0 = new Vector2(1f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(x2 - 16f, y2),
					color = color2,
					uv0 = new Vector2(1f, 0.5f)
				},
				new UIVertex
				{
					position = new Vector3(x + 16f, y2),
					color = color2,
					uv0 = new Vector2(0f, 0.5f)
				}
			});
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		OnSelect.Invoke(CurrentHighlight);
	}

	public void OnScroll(PointerEventData eventData)
	{
		OnScrolling.Invoke(-Mathf.RoundToInt(eventData.scrollDelta.y));
	}
}
