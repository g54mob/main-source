using UnityEngine;
using UnityEngine.UI;

public class TextJustifier : BaseMeshEffect
{
	[Readonly]
	public Text text;

	protected TextJustifier()
	{
	}

	public override void ModifyMesh(VertexHelper vh)
	{
		if (!IsActive())
		{
			return;
		}
		float num = 0.75f;
		if (this.text == null)
		{
			this.text = GetComponent<Text>();
		}
		UIVertex vertex = default(UIVertex);
		TextGenerator cachedTextGenerator = this.text.cachedTextGenerator;
		string text = this.text.text;
		for (int i = 0; i < cachedTextGenerator.lines.Count - 1; i++)
		{
			UILineInfo uILineInfo = cachedTextGenerator.lines[i];
			UILineInfo uILineInfo2 = cachedTextGenerator.lines[i + 1];
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			float num4 = 0f;
			float num5 = 0f;
			int num6 = 0;
			float charWidth;
			for (int j = uILineInfo.startCharIdx; j < uILineInfo2.startCharIdx; num4 += charWidth, j++)
			{
				char c = text[j];
				charWidth = cachedTextGenerator.characters[j].charWidth;
				switch (c)
				{
				case ' ':
					num2++;
					num6++;
					num5 += charWidth;
					continue;
				case '\n':
					break;
				default:
					num3++;
					num5 = 0f;
					num6 = 0;
					continue;
				}
				flag = true;
				break;
			}
			if (flag || num3 == 0)
			{
				continue;
			}
			num2 -= num6;
			float num7 = cachedTextGenerator.rectExtents.xMax - (num4 - num5);
			float num8 = num7 * ((num2 == 0) ? 0f : num);
			float num9 = num7 - num8;
			float num10 = num8 / (float)((num2 != 0) ? num2 : 0);
			float num11 = num9 / (float)num3;
			float num12 = 0f;
			for (int k = uILineInfo.startCharIdx; k < uILineInfo2.startCharIdx; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					int i2 = k * 4 + l;
					vh.PopulateUIVertex(ref vertex, i2);
					vertex.position.x += Mathf.FloorToInt(num12);
					vh.SetUIVertex(vertex, i2);
				}
				char c2 = text[k];
				num12 = ((c2 != ' ') ? (num12 + num11) : (num12 + num10));
			}
		}
	}
}
