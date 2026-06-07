using UnityEngine;
using UnityEngine.UI;

public class SkinToneGraph : Graphic
{
	public Texture Sprite;

	public int SkinColors = 32;

	public int Row;

	public override Texture mainTexture
	{
		get
		{
			return Sprite;
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Vector2 vector = Vector2.zero - base.rectTransform.pivot;
		Vector2 vector2 = Vector2.one - base.rectTransform.pivot;
		vector = new Vector2(vector.x * base.rectTransform.rect.width, vector.y * base.rectTransform.rect.height);
		vector2 = new Vector2(vector2.x * base.rectTransform.rect.width, vector2.y * base.rectTransform.rect.height);
		float x = 1f / (float)Sprite.width;
		float x2 = ((float)SkinColors - 1f) / (float)Sprite.width;
		float y = (float)Row / (float)Sprite.height;
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				position = new Vector3(vector.x, vector.y, 0f),
				color = Color.white,
				uv0 = new Vector2(x2, y)
			},
			new UIVertex
			{
				position = new Vector3(vector2.x, vector.y, 0f),
				color = Color.white,
				uv0 = new Vector2(x2, y)
			},
			new UIVertex
			{
				position = new Vector3(vector2.x, vector2.y, 0f),
				color = Color.white,
				uv0 = new Vector2(x, y)
			},
			new UIVertex
			{
				position = new Vector3(vector.x, vector2.y, 0f),
				color = Color.white,
				uv0 = new Vector2(x, y)
			}
		});
	}
}
