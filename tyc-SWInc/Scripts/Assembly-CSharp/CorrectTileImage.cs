using UnityEngine;
using UnityEngine.UI;

public class CorrectTileImage : MaskableGraphic
{
	public Sprite MainTex;

	public override Texture mainTexture
	{
		get
		{
			return MainTex.texture;
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Vector2 vector = Vector2.zero - base.rectTransform.pivot;
		Vector2 vector2 = Vector2.one - base.rectTransform.pivot;
		vector = new Vector2(vector.x * base.rectTransform.rect.width, vector.y * base.rectTransform.rect.height);
		vector2 = new Vector2(vector2.x * base.rectTransform.rect.width, vector2.y * base.rectTransform.rect.height);
		float x = base.rectTransform.rect.width / (float)MainTex.texture.width;
		float y = base.rectTransform.rect.height / (float)MainTex.texture.height;
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				position = vector,
				color = color,
				uv0 = new Vector2(0f, y)
			},
			new UIVertex
			{
				position = new Vector3(vector.x, vector2.y),
				color = color,
				uv0 = new Vector2(0f, 0f)
			},
			new UIVertex
			{
				position = vector2,
				color = color,
				uv0 = new Vector2(x, 0f)
			},
			new UIVertex
			{
				position = new Vector3(vector2.x, vector.y),
				color = color,
				uv0 = new Vector2(x, y)
			}
		});
	}
}
