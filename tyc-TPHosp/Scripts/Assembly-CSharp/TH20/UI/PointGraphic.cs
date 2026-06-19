using System;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class PointGraphic : MaskableGraphic
	{
		private const int _sectors = 32;

		private const float _featherScale = 0.5f;

		[SerializeField]
		private float _borderThickness = 2f;

		[SerializeField]
		private Color _borderColor = Color.black;

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			float num = ((base.canvas.renderMode != RenderMode.WorldSpace) ? (0.5f / base.canvas.scaleFactor) : 0.5f);
			Vector2 vector = new Vector2(base.rectTransform.rect.width, base.rectTransform.rect.height);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 center = new Vector2(vector.x * (0f - pivot.x + 0.5f), vector.y * (0f - pivot.y + 0.5f));
			float num2 = 0.5f * Mathf.Min(vector.x, vector.y) - num * 0.5f;
			float num3 = Mathf.Min(_borderThickness, num2);
			if (num3 > 0f)
			{
				CreateCircle(vh, center, num2 - num3 - num * 0.5f, color);
				CreateRing(vh, center, num2 - num3 - num * 0.5f, num2 - num3 + num * 0.5f, color, _borderColor);
				CreateRing(vh, center, num2 - num3 + num * 0.5f, num2, _borderColor, _borderColor);
				CreateRing(vh, center, num2, num2 + num, _borderColor, new Color(_borderColor.r, _borderColor.g, _borderColor.b, 0f));
			}
			else
			{
				CreateCircle(vh, center, num2 - num3, color);
				CreateRing(vh, center, num2, num2 + num, color, new Color(color.r, color.g, color.b, 0f));
			}
		}

		private void CreateCircle(VertexHelper vh, Vector2 center, float radius, Color circleColor)
		{
			float num = Mathf.Sin(-(float)Math.PI / 16f);
			float num2 = Mathf.Cos(-(float)Math.PI / 16f);
			Vector2 vector = Vector2.up * radius;
			int currentVertCount = vh.currentVertCount;
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.color = circleColor;
			simpleVert.position = center;
			vh.AddVert(simpleVert);
			simpleVert.position = center + vector;
			vh.AddVert(simpleVert);
			for (int i = 0; i < 31; i++)
			{
				vector = new Vector2(vector.x * num2 - vector.y * num, vector.x * num + vector.y * num2);
				simpleVert.position = center + vector;
				vh.AddVert(simpleVert);
				vh.AddTriangle(currentVertCount, vh.currentVertCount - 2, vh.currentVertCount - 1);
			}
			vh.AddTriangle(currentVertCount, vh.currentVertCount - 1, currentVertCount + 1);
		}

		private void CreateRing(VertexHelper vh, Vector2 center, float innerRadius, float outerRadius, Color innerColor, Color outerColor)
		{
			float num = Mathf.Sin(-(float)Math.PI / 16f);
			float num2 = Mathf.Cos(-(float)Math.PI / 16f);
			Vector2 vector = Vector2.up;
			int currentVertCount = vh.currentVertCount;
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.color = innerColor;
			simpleVert.position = center + vector * innerRadius;
			vh.AddVert(simpleVert);
			simpleVert.color = outerColor;
			simpleVert.position = center + vector * outerRadius;
			vh.AddVert(simpleVert);
			for (int i = 0; i < 31; i++)
			{
				vector = new Vector2(vector.x * num2 - vector.y * num, vector.x * num + vector.y * num2);
				simpleVert.color = innerColor;
				simpleVert.position = center + vector * innerRadius;
				vh.AddVert(simpleVert);
				simpleVert.color = outerColor;
				simpleVert.position = center + vector * outerRadius;
				vh.AddVert(simpleVert);
				vh.AddTriangle(vh.currentVertCount - 1, vh.currentVertCount - 2, vh.currentVertCount - 4);
				vh.AddTriangle(vh.currentVertCount - 4, vh.currentVertCount - 3, vh.currentVertCount - 1);
			}
			vh.AddTriangle(vh.currentVertCount - 2, vh.currentVertCount - 1, currentVertCount + 1);
			vh.AddTriangle(vh.currentVertCount - 2, currentVertCount + 1, currentVertCount);
		}
	}
}
