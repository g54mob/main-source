using System;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public static class UIMeshUtils
	{
		public static void CreateArcMeshClockwise(VertexHelper vh, Vector2 origin, Vector2 startDir, Vector2 endDir, float innerRadius, float outerRadius, Color innerColor, Color outerColor, float radiansDelta, float radiansDeltaSine, float radiansDeltaCosine)
		{
			float num = Vector2.Angle(startDir, endDir) * ((float)Math.PI / 180f);
			if (Vector2.Dot(new Vector2(0f - startDir.y, startDir.x), endDir) < 0f)
			{
				num = (float)Math.PI * 2f - num;
			}
			int num2 = Mathf.FloorToInt(num / radiansDelta);
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.position = origin + startDir * innerRadius;
			simpleVert.color = innerColor;
			vh.AddVert(simpleVert);
			simpleVert.position = origin + startDir * outerRadius;
			simpleVert.color = outerColor;
			vh.AddVert(simpleVert);
			Vector2 vector = startDir;
			for (int i = 0; i < num2; i++)
			{
				vector = new Vector2(vector.x * radiansDeltaCosine - vector.y * radiansDeltaSine, vector.x * radiansDeltaSine + vector.y * radiansDeltaCosine);
				simpleVert.position = origin + vector * innerRadius;
				simpleVert.color = innerColor;
				vh.AddVert(simpleVert);
				simpleVert.position = origin + vector * outerRadius;
				simpleVert.color = outerColor;
				vh.AddVert(simpleVert);
				vh.AddTriangle(vh.currentVertCount - 4, vh.currentVertCount - 3, vh.currentVertCount - 1);
				vh.AddTriangle(vh.currentVertCount - 4, vh.currentVertCount - 1, vh.currentVertCount - 2);
			}
			simpleVert.position = origin + endDir * innerRadius;
			simpleVert.color = innerColor;
			vh.AddVert(simpleVert);
			simpleVert.position = origin + endDir * outerRadius;
			simpleVert.color = outerColor;
			vh.AddVert(simpleVert);
			vh.AddTriangle(vh.currentVertCount - 4, vh.currentVertCount - 3, vh.currentVertCount - 1);
			vh.AddTriangle(vh.currentVertCount - 4, vh.currentVertCount - 1, vh.currentVertCount - 2);
		}
	}
}
