using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientPanel : MaskableGraphic
{
	public List<KeyValuePair<Color, bool>> Gradients = new List<KeyValuePair<Color, bool>>();

	public float GradientHeight = 24f;

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		base.OnPopulateMesh(vh);
		vh.Clear();
		if (Gradients == null || Gradients.Count <= 0)
		{
			return;
		}
		Vector2 vector = new Vector2((0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width, (0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height);
		for (int i = 0; i < Gradients.Count; i++)
		{
			KeyValuePair<Color, bool> keyValuePair = Gradients[i];
			bool flag = i == 0 || !Gradients[i - 1].Value;
			bool num = !keyValuePair.Value;
			bool flag2 = i == Gradients.Count - 1 || !Gradients[i + 1].Value;
			if (num || (flag && flag2))
			{
				AddQuad(new Rect(vector + new Vector2(0f, (float)i * GradientHeight + 1f), new Vector2(base.rectTransform.rect.width, GradientHeight - 2f)), keyValuePair.Key, keyValuePair.Key, vh);
				continue;
			}
			AddQuad(new Rect(vector + new Vector2(0f, (float)i * GradientHeight + (float)(flag ? 1 : 0)), new Vector2(base.rectTransform.rect.width, GradientHeight / 2f)), keyValuePair.Key, keyValuePair.Key, vh);
			AddQuad(new Rect(vector + new Vector2(0f, (float)i * GradientHeight + GradientHeight / 2f), new Vector2(base.rectTransform.rect.width, GradientHeight / 2f - (float)(flag2 ? 1 : 0))), keyValuePair.Key, flag2 ? keyValuePair.Key : Gradients[i + 1].Key, vh);
		}
	}

	private void AddQuad(Rect pos, Color c1, Color c2, VertexHelper vh)
	{
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				position = new Vector3(pos.xMin, 0f - pos.yMin, 0f),
				color = c1
			},
			new UIVertex
			{
				position = new Vector3(pos.xMax, 0f - pos.yMin, 0f),
				color = c1
			},
			new UIVertex
			{
				position = new Vector3(pos.xMax, 0f - pos.yMax, 0f),
				color = c2
			},
			new UIVertex
			{
				position = new Vector3(pos.xMin, 0f - pos.yMax, 0f),
				color = c2
			}
		});
	}
}
