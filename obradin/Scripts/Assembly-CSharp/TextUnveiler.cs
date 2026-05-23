using UnityEngine;
using UnityEngine.UI;

public class TextUnveiler : BaseMeshEffect
{
	public Text text;

	public float unveilT = 1f;

	protected TextUnveiler()
	{
	}

	public override void ModifyMesh(VertexHelper vh)
	{
		if (!IsActive())
		{
			return;
		}
		if (text == null)
		{
			text = GetComponent<Text>();
		}
		UIVertex vertex = default(UIVertex);
		TextGenerator cachedTextGenerator = text.cachedTextGenerator;
		Color32 color = new Color32(0, 0, 0, 0);
		for (int i = 0; i < vh.currentVertCount; i += 4)
		{
			float num = (float)(i / 4) / (float)(vh.currentVertCount / 4);
			float num2 = Util.SmoothStepEdges(num, num + 0.2f, unveilT * 1.2f);
			color.a = (byte)Mathf.RoundToInt(num2 * 255f);
			for (int j = 0; j < 4; j++)
			{
				vh.PopulateUIVertex(ref vertex, i + j);
				vertex.color = color;
				vh.SetUIVertex(vertex, i + j);
			}
		}
	}
}
