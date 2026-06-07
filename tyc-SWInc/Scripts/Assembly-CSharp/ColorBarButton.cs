using UnityEngine;
using UnityEngine.UI;

public class ColorBarButton : MaskableGraphic
{
	public Color[] colors;

	public void Refresh()
	{
		if (this != null && base.gameObject != null)
		{
			SetVerticesDirty();
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		Vector2 p = Vector2.zero - base.rectTransform.pivot;
		Vector2 p2 = Vector2.one - base.rectTransform.pivot;
		p = new Vector2(p.x * base.rectTransform.rect.width, p.y * base.rectTransform.rect.height);
		p2 = new Vector2(p2.x * base.rectTransform.rect.width, p2.y * base.rectTransform.rect.height);
		vh.Clear();
		if (colors == null || colors.Length == 0)
		{
			DrawRect(p, p2, color, vh);
			return;
		}
		float num = (p2.y - p.y) * 0.8f;
		DrawRect(p, new Vector2(p2.x, p.y + num), color, vh);
		float num2 = (p2.x - p.x) / (float)colors.Length;
		for (int i = 0; i < colors.Length; i++)
		{
			Color col = colors[i];
			DrawRect(new Vector2(p.x + num2 * (float)i, p.y + num), new Vector2(p.x + num2 * (float)i + num2, p2.y), col, vh);
		}
	}

	public static void DrawRect(Rect rect, Color col, VertexHelper vh)
	{
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = col,
				position = new Vector3(rect.xMin, rect.yMin, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(rect.xMax, rect.yMin, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(rect.xMax, rect.yMax, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(rect.xMin, rect.yMax, 0f)
			}
		});
	}

	public static void DrawRectUV(Rect r, Color col, VertexHelper vh)
	{
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = col,
				position = new Vector3(r.xMin, r.yMin, 0f),
				uv0 = new Vector2(0f, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(r.xMax, r.yMin, 0f),
				uv0 = new Vector2(1f, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(r.xMax, r.yMax, 0f),
				uv0 = new Vector2(1f, 1f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(r.xMin, r.yMax, 0f),
				uv0 = new Vector2(0f, 1f)
			}
		});
	}

	public static void DrawRect(Vector2 p1, Vector2 p2, Color col, VertexHelper vh)
	{
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = col,
				position = new Vector3(p1.x, p1.y, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(p2.x, p1.y, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(p2.x, p2.y, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(p1.x, p2.y, 0f)
			}
		});
	}

	public static void DrawRectUV(Vector2 p1, Vector2 p2, Color col, VertexHelper vh)
	{
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = col,
				position = new Vector3(p1.x, p1.y, 0f),
				uv0 = new Vector2(0f, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(p2.x, p1.y, 0f),
				uv0 = new Vector2(1f, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(p2.x, p2.y, 0f),
				uv0 = new Vector2(1f, 1f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(p1.x, p2.y, 0f),
				uv0 = new Vector2(0f, 1f)
			}
		});
	}
}
