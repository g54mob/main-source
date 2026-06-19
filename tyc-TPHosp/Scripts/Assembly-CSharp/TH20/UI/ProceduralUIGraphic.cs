using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class ProceduralUIGraphic : MaskableGraphic
	{
		[SerializeField]
		private List<Vector2> _sourceOutline = new List<Vector2>();

		[SerializeField]
		private float _cornerRadius;

		private float _radiansDelta;

		private float _radiansDeltaSine;

		private float _radiansDeltaCosine;

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			float num = ((base.canvas.renderMode != RenderMode.WorldSpace) ? (1f / base.canvas.scaleFactor) : 0.1f);
			_radiansDelta = 0.17453292f;
			_radiansDeltaSine = Mathf.Sin(_radiansDelta);
			_radiansDeltaCosine = Mathf.Cos(_radiansDelta);
			Vector2 vector = new Vector2(base.rectTransform.rect.width, base.rectTransform.rect.height);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 vector2 = new Vector2((0f - pivot.x) * vector.x, (0f - pivot.y) * vector.y);
			vh.Clear();
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.color = color;
			List<Vector2> list = new List<Vector2>(_sourceOutline.Count);
			List<Vector2> list2 = new List<Vector2>(_sourceOutline.Count);
			for (int i = 0; i < _sourceOutline.Count; i++)
			{
				Vector2 vector3 = _sourceOutline[i];
				_ = _sourceOutline[(i + 1) % _sourceOutline.Count];
				list.Add(new Vector2(vector3.x * vector.x + vector2.x, vector3.y * vector.y + vector2.y));
			}
			for (int j = 0; j < list.Count; j++)
			{
				Vector2 vector4 = list[(list.Count + j - 1) % list.Count];
				Vector2 vector5 = list[j];
				Vector2 vector6 = list[(j + 1) % list.Count];
				Vector2 normalized = (vector5 - vector4).normalized;
				Vector2 normalized2 = (vector6 - vector5).normalized;
				Vector2 vector7 = new Vector2(0f - normalized.y, normalized.x);
				Vector2 vector8 = new Vector2(0f - normalized2.y, normalized2.x);
				if (MathUtils.LineLineIntersection(vector4 - vector7 * _cornerRadius, p2: vector6 - vector8 * _cornerRadius, dir1: normalized, dir2: normalized2, intersection: out var intersection))
				{
					Vector2 normalized3 = (intersection - vector5).normalized;
					Vector2 p = (vector4 + vector5) * 0.5f;
					MathUtils.LineLineIntersection(vector5, normalized3, p, vector7, out var intersection2);
					if ((intersection - vector5).magnitude > (intersection2 - vector5).magnitude)
					{
						intersection = intersection2;
					}
					Vector2 p2 = (vector5 + vector6) * 0.5f;
					MathUtils.LineLineIntersection(vector5, normalized3, p2, vector8, out var intersection3);
					if ((intersection - vector5).magnitude > (intersection3 - vector5).magnitude)
					{
						intersection = intersection3;
					}
					if (list2.Count > 0 && Vector2.Distance(list2[list2.Count - 1], intersection) < num)
					{
						continue;
					}
					list2.Add(intersection);
				}
				else
				{
					list2.Add(list[j] - vector7 * _cornerRadius);
				}
				simpleVert.position = list2[list2.Count - 1];
				vh.AddVert(simpleVert);
			}
			int[] array = Triangulator.Triangulate(list2);
			for (int k = 0; k < array.Length - 2; k += 3)
			{
				vh.AddTriangle(array[k], array[k + 1], array[k + 2]);
			}
			for (int l = 0; l < list2.Count; l++)
			{
				Vector2 vector9 = list2[(list2.Count + l - 1) % list2.Count];
				Vector2 vector10 = list2[l];
				Vector2 vector11 = list2[(l + 1) % list2.Count];
				Vector2 normalized4 = (vector10 - vector9).normalized;
				Vector2 normalized5 = (vector11 - vector10).normalized;
				Vector2 vector12 = new Vector2(0f - normalized4.y, normalized4.x);
				Vector2 vector13 = new Vector2(0f - normalized5.y, normalized5.x);
				Vector2 vector14 = (vector9 + vector10) * 0.5f;
				Vector2 vector15 = (vector10 + vector11) * 0.5f;
				if (Vector2.Dot(normalized4, vector13) > 0f)
				{
					UIMeshUtils.CreateArcMeshClockwise(vh, vector10, vector13, vector12, 0f, _cornerRadius, color, color, _radiansDelta, _radiansDeltaSine, _radiansDeltaCosine);
					int currentVertCount = vh.currentVertCount;
					simpleVert.position = vector14;
					vh.AddVert(simpleVert);
					simpleVert.position = vector14 + vector12 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = vector10 + vector12 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = vector10;
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
					vh.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
					int currentVertCount2 = vh.currentVertCount;
					simpleVert.position = vector10;
					vh.AddVert(simpleVert);
					simpleVert.position = vector10 + vector13 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = vector15 + vector13 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = vector15;
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount2, currentVertCount2 + 1, currentVertCount2 + 2);
					vh.AddTriangle(currentVertCount2 + 2, currentVertCount2 + 3, currentVertCount2);
					continue;
				}
				MathUtils.LineLineIntersection(vector9 + vector12 * _cornerRadius * 2f, normalized4, vector11 + vector13 * _cornerRadius * 2f, normalized5, out var intersection4);
				Vector2 vector16 = intersection4 - vector12 * _cornerRadius * 2f;
				Vector2 vector17 = intersection4 - vector13 * _cornerRadius * 2f;
				CreateInteriorArc(vh, vector10, vector16, vector17, vector12, vector13, _cornerRadius, color);
				if (Vector2.Dot(vector14 - vector16, normalized4) < 0f)
				{
					int currentVertCount3 = vh.currentVertCount;
					simpleVert.position = vector14;
					vh.AddVert(simpleVert);
					simpleVert.position = vector14 + vector12 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = intersection4 - vector12 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = vector16;
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount3, currentVertCount3 + 1, currentVertCount3 + 2);
					vh.AddTriangle(currentVertCount3 + 2, currentVertCount3 + 3, currentVertCount3);
				}
				if (Vector2.Dot(vector17 - vector15, normalized5) < 0f)
				{
					int currentVertCount4 = vh.currentVertCount;
					simpleVert.position = vector17;
					vh.AddVert(simpleVert);
					simpleVert.position = intersection4 - vector13 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = vector15 + vector13 * _cornerRadius;
					vh.AddVert(simpleVert);
					simpleVert.position = vector15;
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount4, currentVertCount4 + 1, currentVertCount4 + 2);
					vh.AddTriangle(currentVertCount4 + 2, currentVertCount4 + 3, currentVertCount4);
				}
			}
		}

		private static void CreateInteriorArc(VertexHelper vh, Vector2 origin, Vector2 entering, Vector2 leaving, Vector2 enteringNormal, Vector2 leavingNormal, float cornerRadius, Color color)
		{
			int currentVertCount = vh.currentVertCount;
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.color = color;
			simpleVert.position = origin;
			vh.AddVert(simpleVert);
			simpleVert.position = entering;
			vh.AddVert(simpleVert);
			simpleVert.position = entering + enteringNormal * cornerRadius;
			vh.AddVert(simpleVert);
			vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
			simpleVert.position = leaving;
			vh.AddVert(simpleVert);
			simpleVert.position = leaving + leavingNormal * cornerRadius;
			vh.AddVert(simpleVert);
			vh.AddTriangle(currentVertCount, currentVertCount + 4, currentVertCount + 3);
			if (MathUtils.LineLineIntersection(entering, enteringNormal, leaving, leavingNormal, out var intersection))
			{
				float num = 0.17453292f;
				float num2 = Mathf.Sin(num);
				float num3 = Mathf.Cos(num);
				Vector2 vector = entering + enteringNormal * cornerRadius - intersection;
				int num4 = Mathf.FloorToInt(Vector2.Angle(vector, leaving + leavingNormal * cornerRadius - intersection) * ((float)Math.PI / 180f) / num);
				simpleVert.position = intersection + vector;
				vh.AddVert(simpleVert);
				for (int i = 0; i < num4; i++)
				{
					vector = new Vector2(vector.x * num3 - vector.y * num2, vector.x * num2 + vector.y * num3);
					simpleVert.position = intersection + vector;
					vh.AddVert(simpleVert);
					vh.AddTriangle(currentVertCount, vh.currentVertCount - 2, vh.currentVertCount - 1);
				}
				simpleVert.position = intersection + (leaving + leavingNormal * cornerRadius) - intersection;
				vh.AddVert(simpleVert);
				vh.AddTriangle(currentVertCount, vh.currentVertCount - 2, vh.currentVertCount - 1);
			}
		}
	}
}
