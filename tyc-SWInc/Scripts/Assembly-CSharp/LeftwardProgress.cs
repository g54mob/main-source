using UnityEngine;
using UnityEngine.UI;

public class LeftwardProgress : MaskableGraphic
{
	public Sprite MainTex;

	public override Texture mainTexture
	{
		get
		{
			if (!(MainTex != null))
			{
				return base.mainTexture;
			}
			return MainTex.texture;
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Vector2 a = new Vector2((0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
		Vector2 b = new Vector2((1f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (1f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
		if (MainTex == null)
		{
			DrawRect(a, b, Vector2.zero, Vector2.one, vh);
			return;
		}
		float num = b.x - a.x;
		Vector4 border = MainTex.border;
		Vector4 vector = new Vector4(border.x / (float)MainTex.texture.width, border.y / (float)MainTex.texture.height, border.z / (float)MainTex.texture.width, border.w / (float)MainTex.texture.height);
		if (num < border.x)
		{
			DrawLeft(a, b, vector.x * (num / border.x), vector.y, border.y, vector.w, border.w, vh);
			return;
		}
		DrawLeft(a, new Vector2(a.x + border.x, b.y), vector.x, vector.y, border.y, vector.w, border.w, vh);
		DrawRect(new Vector2(a.x + border.x, a.y), b, new Vector2(vector.x, 0f), Vector2.one, vh);
	}

	private void DrawLeft(Vector2 a, Vector2 b, float left, float bottom, float bottomMargin, float top, float topMargin, VertexHelper vh)
	{
		if (b.y - a.y - (bottomMargin + topMargin) > 0f)
		{
			DrawRect(new Vector2(a.x, a.y + topMargin), b - new Vector2(0f, bottomMargin), new Vector2(0f, top), new Vector2(left, 1f - bottom), vh);
		}
		DrawRect(a, new Vector2(b.x, a.y + topMargin), new Vector2(0f, 0f), new Vector2(left, top), vh);
		DrawRect(new Vector2(a.x, b.y - bottomMargin), b, new Vector2(0f, 1f - bottom), new Vector2(left, 1f), vh);
	}

	private void DrawRect(Vector2 a, Vector2 b, Vector2 uv1, Vector2 uv2, VertexHelper vh)
	{
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = color,
				position = new Vector3(a.x, a.y, 0f),
				uv0 = new Vector2(uv1.x, uv1.y)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(a.x, b.y, 0f),
				uv0 = new Vector2(uv1.x, uv2.y)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(b.x, b.y, 0f),
				uv0 = new Vector2(uv2.x, uv2.y)
			},
			new UIVertex
			{
				color = color,
				position = new Vector3(b.x, a.y, 0f),
				uv0 = new Vector2(uv2.x, uv1.y)
			}
		});
	}
}
