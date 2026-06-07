using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class SheetTipGraphic : MaskableGraphic, IPointerEnterHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
{
	public Texture2D Texture;

	public int SheetWidth = 1;

	public int SheetHeight = 1;

	public float SpriteSize = 24f;

	public int[] Sprites;

	public Sprite[] SpritesB;

	public int DotMask;

	public int DotMask2;

	public int DotSprite;

	public int EdSprite = 6;

	public float DotSize = 16f;

	public float EdSize = 32f;

	public Color[] Colors = new Color[0];

	public string[] Tips;

	public bool DynamicTips;

	private bool _tipping;

	public bool Highlight;

	public Color HighlightColor = new Color(1f, 1f, 1f, 0.8f);

	public Vector2 HightligtUV;

	public UnityEvent OnClick;

	public bool UseSpriteAtlas;

	public Sprite SpriteAtlas;

	public override Texture mainTexture
	{
		get
		{
			return Texture;
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (!UseSpriteAtlas && (Sprites == null || Sprites.Length == 0))
		{
			return;
		}
		if (UseSpriteAtlas)
		{
			if (SpritesB == null || SpritesB.Length == 0 || !SpriteAtlas.packed)
			{
				return;
			}
			Texture = SpriteAtlas.texture;
		}
		RectTransform rectTransform = base.rectTransform;
		Vector2 vector = new Vector2((0f - rectTransform.rect.width) * rectTransform.pivot.x, (0f - rectTransform.rect.height) * (rectTransform.pivot.y - 1f) - SpriteSize);
		if (Highlight)
		{
			Rect rect = new Rect(vector.x, vector.y, rectTransform.rect.width, rectTransform.rect.height);
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMin, rect.yMax),
					uv0 = HightligtUV
				},
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMax, rect.yMax),
					uv0 = HightligtUV
				},
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMax, rect.yMin),
					uv0 = HightligtUV
				},
				new UIVertex
				{
					color = HighlightColor,
					position = new Vector3(rect.xMin, rect.yMin),
					uv0 = HightligtUV
				}
			});
		}
		Color accentColor = HUD.GetAccentColor();
		if (UseSpriteAtlas)
		{
			for (int i = 0; i < SpritesB.Length; i++)
			{
				if (SpritesB[i] != null)
				{
					Color color = ((Colors != null && i < Colors.Length) ? (this.color * Colors[i]) : this.color);
					DrawSprite(SpritesB[i], new Rect((float)i * SpriteSize + vector.x, vector.y, SpriteSize, SpriteSize), color, vh);
				}
			}
			return;
		}
		for (int j = 0; j < Sprites.Length; j++)
		{
			if (Sprites[j] >= 0)
			{
				Color color2 = ((Colors != null && j < Colors.Length) ? (this.color * Colors[j]) : this.color);
				DrawSprite(Sprites[j], new Rect((float)j * SpriteSize + vector.x, vector.y, SpriteSize, SpriteSize), color2, vh);
			}
			if ((DotMask & (1 << j)) > 0)
			{
				bool num = (DotMask2 & (1 << j)) > 0;
				Color c = (num ? HUD.GetThemeColor(2) : accentColor);
				int sp = (num ? EdSprite : DotSprite);
				float num2 = (num ? EdSize : DotSize);
				if (Sprites[j] >= 0)
				{
					DrawSprite(sp, new Rect((float)j * SpriteSize + vector.x + SpriteSize - num2 - 2f, vector.y + SpriteSize - num2 - 2f, num2, num2), c, vh);
				}
				else
				{
					DrawSprite(sp, new Rect((float)j * SpriteSize + vector.x + SpriteSize / 2f - num2 / 2f, vector.y + SpriteSize / 2f - num2 / 2f, num2, num2), c.Alpha(0.5f), vh);
				}
			}
		}
		if ((DotMask & 0x200) > 0)
		{
			DrawSprite(DotSprite, new Rect(vector.x + DotSize / 2f, vector.y + SpriteSize - DotSize - 2f, DotSize, DotSize), HUD.GetThemeColor(5), vh);
		}
	}

	public void DrawSprite(int sp, Rect pos, Color color, VertexHelper vh)
	{
		int num = sp % SheetWidth;
		int num2 = sp / SheetWidth;
		float num3 = (float)num / (float)SheetWidth;
		float num4 = 1f - (float)num2 / (float)SheetHeight;
		float x = num3 + 1f / (float)SheetWidth;
		float y = num4 - 1f / (float)SheetHeight;
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = color,
				position = new Vector3(pos.xMin, pos.yMax),
				uv0 = new Vector2(num3, num4)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(pos.xMax, pos.yMax),
				uv0 = new Vector2(x, num4)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(pos.xMax, pos.yMin),
				uv0 = new Vector2(x, y)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(pos.xMin, pos.yMin),
				uv0 = new Vector2(num3, y)
			}
		});
	}

	public void DrawSprite(Sprite sp, Rect r, Color color, VertexHelper vh)
	{
		Rect textureRect = sp.textureRect;
		int width = sp.texture.width;
		int height = sp.texture.height;
		textureRect = new Rect(textureRect.x / (float)width, textureRect.y / (float)height, textureRect.width / (float)width, textureRect.height / (float)height);
		float num = textureRect.width / textureRect.height;
		float num2 = r.height;
		float num3 = r.height;
		if (num > 1f)
		{
			num3 = r.height / num;
		}
		else
		{
			num2 = r.height * num;
		}
		r = new Rect(r.x + (r.height - num2) / 2f, r.y + (r.height - num3) / 2f, num2, num3);
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMin, r.yMax),
				uv0 = new Vector2(textureRect.xMin, textureRect.yMax)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMax, r.yMax),
				uv0 = new Vector2(textureRect.xMax, textureRect.yMax)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMax, r.yMin),
				uv0 = new Vector2(textureRect.xMax, textureRect.yMin)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(r.xMin, r.yMin),
				uv0 = new Vector2(textureRect.xMin, textureRect.yMin)
			}
		});
	}

	private void Update()
	{
		if (_tipping)
		{
			if (Tooltip.CurrentRect != base.rectTransform)
			{
				_tipping = false;
			}
			else
			{
				UpdateTooltip();
			}
		}
	}

	private void UpdateTooltip()
	{
		Vector2 localPoint = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			int num = Mathf.FloorToInt((localPoint.x + base.rectTransform.rect.width * base.rectTransform.pivot.x) / SpriteSize);
			int num2 = (UseSpriteAtlas ? SpritesB.Length : Sprites.Length);
			if (num >= 0 && num < num2)
			{
				int num3 = (DynamicTips ? num : Sprites[num]);
				if (num3 >= 0)
				{
					Tooltip.SetToolTip(Tips[num3].Loc(), null, base.rectTransform);
					return;
				}
				Tooltip.CurrentRect = base.rectTransform;
				Tooltip.Hide();
			}
			else
			{
				Tooltip.CurrentRect = base.rectTransform;
				Tooltip.Hide();
			}
		}
		else
		{
			Tooltip.Hide();
			_tipping = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_tipping = true;
		UpdateTooltip();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		OnClick.Invoke();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
