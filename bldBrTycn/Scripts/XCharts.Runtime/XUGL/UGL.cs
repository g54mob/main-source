using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XUGL
{
	public static class UGL
	{
		public enum Direction
		{
			XAxis = 0,
			YAxis = 1,
			Random = 2
		}

		private static readonly Color32 s_ClearColor32 = new Color32(0, 0, 0, 0);

		private static readonly Vector2 s_ZeroVector2 = Vector2.zero;

		private static UIVertex[] s_Vertex = new UIVertex[4];

		private static List<Vector3> s_CurvesPosList = new List<Vector3>();

		public static void DrawArrow(VertexHelper vh, Vector3 startPoint, Vector3 arrowPoint, float width, float height, float offset, float dent, Color32 color)
		{
			Vector3 normalized = (arrowPoint - startPoint).normalized;
			Vector3 vector = arrowPoint + (offset + height / 4f) * normalized;
			Vector3 p = vector + (dent - height) * normalized;
			Vector3 vector2 = Vector3.Cross(normalized, Vector3.forward).normalized * width / 2f;
			Vector3 p2 = vector - height * normalized + vector2;
			Vector3 p3 = vector - height * normalized - vector2;
			DrawTriangle(vh, p, vector, p2, color);
			DrawTriangle(vh, p, vector, p3, color);
		}

		public static void DrawLine(VertexHelper vh, Vector3 startPoint, Vector3 endPoint, float width, Color32 color)
		{
			DrawLine(vh, startPoint, endPoint, width, color, color);
		}

		public static void DrawLine(VertexHelper vh, Vector3 startPoint, Vector3 endPoint, float width, Color32 color, Color32 toColor)
		{
			if (!(startPoint == endPoint))
			{
				Vector3 vector = Vector3.Cross(endPoint - startPoint, Vector3.forward).normalized * width;
				s_Vertex[0].position = startPoint - vector;
				s_Vertex[1].position = endPoint - vector;
				s_Vertex[2].position = endPoint + vector;
				s_Vertex[3].position = startPoint + vector;
				for (int i = 0; i < 4; i++)
				{
					s_Vertex[i].color = ((i == 0 || i == 3) ? color : toColor);
					s_Vertex[i].uv0 = s_ZeroVector2;
				}
				vh.AddUIVertexQuad(s_Vertex);
			}
		}

		public static void DrawLine(VertexHelper vh, Vector3 startPoint, Vector3 middlePoint, Vector3 endPoint, float width, Color32 color)
		{
			Vector3 normalized = (middlePoint - startPoint).normalized;
			Vector3 normalized2 = (endPoint - middlePoint).normalized;
			Vector3 normalized3 = Vector3.Cross(normalized, Vector3.forward).normalized;
			Vector3 normalized4 = Vector3.Cross(normalized2, Vector3.forward).normalized;
			Vector3 normalized5 = (normalized + normalized2).normalized;
			bool flag = Vector3.Cross(normalized, normalized2).z <= 0f;
			float f = (180f - Vector3.Angle(normalized, normalized2)) * (MathF.PI / 180f) / 2f;
			float num = width / Mathf.Sin(f);
			Vector3 normalized6 = Vector3.Cross(normalized5, Vector3.forward).normalized;
			Vector3 vector = middlePoint + (flag ? normalized6 : (-normalized6)) * num;
			Vector3 vector2 = middlePoint + (flag ? (-normalized3) : normalized3) * width;
			Vector3 vector3 = middlePoint + (flag ? (-normalized4) : normalized4) * width;
			Vector3 p = startPoint - normalized3 * width;
			Vector3 p2 = startPoint + normalized3 * width;
			Vector3 p3 = endPoint - normalized4 * width;
			Vector3 p4 = endPoint + normalized4 * width;
			if (flag)
			{
				DrawQuadrilateral(vh, p2, p, vector2, vector, color);
				DrawQuadrilateral(vh, vector, vector3, p3, p4, color);
				DrawTriangle(vh, vector, vector2, vector3, color);
			}
			else
			{
				DrawQuadrilateral(vh, p2, p, vector, vector2, color);
				DrawQuadrilateral(vh, vector3, vector, p3, p4, color);
				DrawTriangle(vh, vector, vector2, vector3, color);
			}
		}

		public static void DrawLine(VertexHelper vh, List<Vector3> points, float width, Color32 color, bool smooth, bool closepath = false)
		{
			for (int num = points.Count - 1; num >= 1; num--)
			{
				if (UGLHelper.IsValueEqualsVector3(points[num], points[num - 1]))
				{
					points.RemoveAt(num);
				}
			}
			if (points.Count < 2)
			{
				return;
			}
			if (points.Count <= 2)
			{
				DrawLine(vh, points[0], points[1], width, color);
				return;
			}
			if (smooth)
			{
				DrawCurves(vh, points, width, color, 2f, 2f, Direction.XAxis, float.NaN, closepath);
				return;
			}
			Vector3 ltp = Vector3.zero;
			Vector3 lbp = Vector3.zero;
			Vector3 ntp = Vector3.zero;
			Vector3 nbp = Vector3.zero;
			Vector3 itp = Vector3.zero;
			Vector3 ibp = Vector3.zero;
			Vector3 clp = Vector3.zero;
			Vector3 crp = Vector3.zero;
			if (closepath && !UGLHelper.IsValueEqualsVector3(points[points.Count - 1], points[0]))
			{
				points.Add(points[0]);
			}
			for (int i = 1; i < points.Count - 1; i++)
			{
				bool bitp = true;
				bool bibp = true;
				UGLHelper.GetLinePoints(points[i - 1], points[i], points[i + 1], width, ref ltp, ref lbp, ref ntp, ref nbp, ref itp, ref ibp, ref clp, ref crp, ref bitp, ref bibp);
				if (i == 1)
				{
					vh.AddVert(ltp, color, Vector2.zero);
					vh.AddVert(lbp, color, Vector2.zero);
				}
				if (bitp == bibp)
				{
					AddVertToVertexHelper(vh, itp, ibp, color);
				}
				else if (bitp)
				{
					AddVertToVertexHelper(vh, itp, clp, color);
					AddVertToVertexHelper(vh, itp, crp, color);
				}
				else
				{
					AddVertToVertexHelper(vh, clp, ibp, color);
					AddVertToVertexHelper(vh, crp, ibp, color);
				}
			}
			AddVertToVertexHelper(vh, ntp, nbp, color);
		}

		public static void AddVertToVertexHelper(VertexHelper vh, Vector3 top, Vector3 bottom, Color32 color, bool needTriangle = true)
		{
			AddVertToVertexHelper(vh, top, bottom, color, color, needTriangle);
		}

		public static void AddVertToVertexHelper(VertexHelper vh, Vector3 top, Vector3 bottom, Color32 topColor, Color32 bottomColor, bool needTriangle = true)
		{
			int currentVertCount = vh.currentVertCount;
			vh.AddVert(top, topColor, Vector2.zero);
			vh.AddVert(bottom, bottomColor, Vector2.zero);
			if (needTriangle)
			{
				int num = currentVertCount;
				int num2 = num + 1;
				int num3 = num - 2;
				int idx = num3 + 1;
				vh.AddTriangle(num3, num2, idx);
				vh.AddTriangle(num3, num, num2);
			}
		}

		public static void DrawDashLine(VertexHelper vh, Vector3 startPoint, Vector3 endPoint, float width, Color32 color, Color32 toColor, float lineLength = 0f, float gapLength = 0f, List<Vector3> posList = null)
		{
			float num = Vector3.Distance(startPoint, endPoint);
			if (!(num < 0.1f))
			{
				if (lineLength == 0f)
				{
					lineLength = 12f * width;
				}
				if (gapLength == 0f)
				{
					gapLength = 3f * width;
				}
				int num2 = Mathf.CeilToInt(num / (lineLength + gapLength));
				Vector3 normalized = (endPoint - startPoint).normalized;
				Vector3 vector = startPoint;
				bool flag = !color.Equals(toColor);
				posList?.Clear();
				for (int i = 1; i <= num2; i++)
				{
					posList?.Add(vector);
					Vector3 vector2 = startPoint + normalized * num * i / num2;
					Vector3 endPoint2 = vector2 - normalized * gapLength;
					DrawLine(vh, vector, endPoint2, width, flag ? Color32.Lerp(color, toColor, (float)i * 1f / (float)num2) : color);
					vector = vector2;
				}
				posList?.Add(endPoint);
				DrawLine(vh, vector, endPoint, width, toColor);
			}
		}

		public static void DrawDotLine(VertexHelper vh, Vector3 startPoint, Vector3 endPoint, float width, Color32 color, Color32 toColor, float lineLength = 0f, float gapLength = 0f, List<Vector3> posList = null)
		{
			float num = Vector3.Distance(startPoint, endPoint);
			if (!(num < 0.1f))
			{
				if (lineLength == 0f)
				{
					lineLength = 3f * width;
				}
				if (gapLength == 0f)
				{
					gapLength = 3f * width;
				}
				int num2 = Mathf.CeilToInt(num / (lineLength + gapLength));
				Vector3 normalized = (endPoint - startPoint).normalized;
				Vector3 vector = startPoint;
				_ = Vector3.zero;
				bool flag = !color.Equals(toColor);
				posList?.Clear();
				for (int i = 1; i <= num2; i++)
				{
					posList?.Add(vector);
					Vector3 vector2 = startPoint + normalized * num * i / num2;
					Vector3 endPoint2 = vector2 - normalized * gapLength;
					DrawLine(vh, vector, endPoint2, width, flag ? Color32.Lerp(color, toColor, (float)i * 1f / (float)num2) : color);
					vector = vector2;
				}
				posList?.Add(endPoint);
				DrawLine(vh, vector, endPoint, width, toColor);
			}
		}

		public static void DrawDashDotLine(VertexHelper vh, Vector3 startPoint, Vector3 endPoint, float width, Color32 color, float dashLength = 0f, float dotLength = 0f, float gapLength = 0f, List<Vector3> posList = null)
		{
			float num = Vector3.Distance(startPoint, endPoint);
			if (!(num < 0.1f))
			{
				if (dashLength == 0f)
				{
					dashLength = 15f * width;
				}
				if (dotLength == 0f)
				{
					dotLength = 3f * width;
				}
				if (gapLength == 0f)
				{
					gapLength = 5f * width;
				}
				int num2 = Mathf.CeilToInt(num / (dashLength + 2f * gapLength + dotLength));
				Vector3 normalized = (endPoint - startPoint).normalized;
				Vector3 vector = startPoint;
				posList?.Clear();
				for (int i = 1; i <= num2; i++)
				{
					posList?.Add(vector);
					Vector3 vector2 = startPoint + normalized * num * i / num2;
					Vector3 vector3 = vector2 - normalized * (2f * gapLength + dotLength);
					DrawLine(vh, vector, vector3, width, color);
					posList?.Add(vector3);
					Vector3 vector4 = vector3 + gapLength * normalized;
					Vector3 endPoint2 = vector4 + dotLength * normalized;
					DrawLine(vh, vector4, endPoint2, width, color);
					posList?.Add(vector4);
					vector = vector2;
				}
				posList?.Add(endPoint);
				DrawLine(vh, vector, endPoint, width, color);
			}
		}

		public static void DrawDashDotDotLine(VertexHelper vh, Vector3 startPoint, Vector3 endPoint, float width, Color32 color, float dashLength = 0f, float dotLength = 0f, float gapLength = 0f, List<Vector3> posList = null)
		{
			float num = Vector3.Distance(startPoint, endPoint);
			if (!(num < 0.1f))
			{
				if (dashLength == 0f)
				{
					dashLength = 15f * width;
				}
				if (dotLength == 0f)
				{
					dotLength = 3f * width;
				}
				if (gapLength == 0f)
				{
					gapLength = 5f * width;
				}
				int num2 = Mathf.CeilToInt(num / (dashLength + 3f * gapLength + 2f * dotLength));
				Vector3 normalized = (endPoint - startPoint).normalized;
				Vector3 vector = startPoint;
				posList?.Clear();
				for (int i = 1; i <= num2; i++)
				{
					posList?.Add(vector);
					Vector3 vector2 = startPoint + normalized * num * i / num2;
					Vector3 vector3 = vector2 - normalized * (3f * gapLength + 2f * dotLength);
					DrawLine(vh, vector, vector3, width, color);
					posList?.Add(vector3);
					Vector3 vector4 = vector3 + gapLength * normalized;
					Vector3 vector5 = vector4 + dotLength * normalized;
					DrawLine(vh, vector4, vector5, width, color);
					posList?.Add(vector5);
					Vector3 vector6 = vector5 + gapLength * normalized;
					Vector3 vector7 = vector6 + dotLength * normalized;
					DrawLine(vh, vector6, vector7, width, color);
					posList?.Add(vector7);
					vector = vector2;
				}
				posList?.Add(endPoint);
				DrawLine(vh, vector, endPoint, width, color);
			}
		}

		public static void DrawZebraLine(VertexHelper vh, Vector3 startPoint, Vector3 endPoint, float width, float zebraWidth, float zebraGap, Color32 color, Color32 toColor, float maxDistance)
		{
			float num = Vector3.Distance(startPoint, endPoint);
			if (num < 0.1f)
			{
				return;
			}
			if (zebraWidth == 0f)
			{
				zebraWidth = 3f * width;
			}
			if (zebraGap == 0f)
			{
				zebraGap = 3f * width;
			}
			int num2 = Mathf.CeilToInt(num / (zebraWidth + zebraGap)) + 1;
			Vector3 normalized = (endPoint - startPoint).normalized;
			Vector3 vector = startPoint;
			Vector3 zero = Vector3.zero;
			bool flag = !color.Equals(toColor);
			float num3 = 0f;
			for (int i = 0; i <= num2; i++)
			{
				if (num3 + zebraWidth + zebraGap <= num)
				{
					num3 += zebraWidth + zebraGap;
					zero = vector + normalized * zebraWidth;
					DrawLine(vh, vector, zero, width, flag ? Color32.Lerp(color, toColor, num3 / maxDistance) : color);
					vector = zero + normalized * zebraGap;
					continue;
				}
				if (num3 + zebraWidth <= num)
				{
					num3 += zebraWidth;
					zero = vector + normalized * zebraWidth;
					DrawLine(vh, vector, zero, width, flag ? Color32.Lerp(color, toColor, num3 / maxDistance) : color);
					if (num - num3 > 6f)
					{
						DrawLine(vh, endPoint - normalized * 2f, endPoint, width, flag ? Color32.Lerp(color, toColor, num / maxDistance) : color);
					}
				}
				else
				{
					DrawLine(vh, vector, endPoint, width, flag ? Color32.Lerp(color, toColor, num / maxDistance) : color);
				}
				break;
			}
		}

		public static void DrawDiamond(VertexHelper vh, Vector3 center, float size, Color32 color)
		{
			DrawDiamond(vh, center, size, color, color);
		}

		public static void DrawDiamond(VertexHelper vh, Vector3 center, float size, Color32 color, Color32 toColor)
		{
			DrawDiamond(vh, center, size, size, color, toColor);
		}

		public static void DrawDiamond(VertexHelper vh, Vector3 center, float xRadius, float yRadius, Color32 color, Color32 toColor)
		{
			Vector2 vector = new Vector2(center.x - xRadius, center.y);
			Vector2 vector2 = new Vector2(center.x, center.y + yRadius);
			Vector2 vector3 = new Vector2(center.x + xRadius, center.y);
			Vector2 vector4 = new Vector2(center.x, center.y - yRadius);
			DrawTriangle(vh, vector4, vector, vector2, color, color, toColor);
			DrawTriangle(vh, vector3, vector4, vector2, color, color, toColor);
		}

		public static void DrawEmptyDiamond(VertexHelper vh, Vector3 center, float xRadius, float yRadius, float tickness, Color32 color)
		{
			DrawEmptyDiamond(vh, center, xRadius, yRadius, tickness, color, s_ClearColor32);
		}

		public static void DrawEmptyDiamond(VertexHelper vh, Vector3 center, float xRadius, float yRadius, float tickness, Color32 color, Color32 emptyColor)
		{
			Vector2 vector = new Vector2(center.x - xRadius, center.y);
			Vector2 vector2 = new Vector2(center.x, center.y + yRadius);
			Vector2 vector3 = new Vector2(center.x + xRadius, center.y);
			Vector2 vector4 = new Vector2(center.x, center.y - yRadius);
			float num = xRadius - tickness;
			float num2 = yRadius - tickness * 1.5f;
			Vector2 vector5 = new Vector2(center.x - num, center.y);
			Vector2 vector6 = new Vector2(center.x, center.y + num2);
			Vector2 vector7 = new Vector2(center.x + num, center.y);
			Vector2 vector8 = new Vector2(center.x, center.y - num2);
			if (!UGLHelper.IsClearColor(emptyColor))
			{
				DrawQuadrilateral(vh, vector5, vector6, vector7, vector8, emptyColor);
			}
			AddVertToVertexHelper(vh, vector, vector5, color, needTriangle: false);
			AddVertToVertexHelper(vh, vector2, vector6, color);
			AddVertToVertexHelper(vh, vector3, vector7, color);
			AddVertToVertexHelper(vh, vector4, vector8, color);
			AddVertToVertexHelper(vh, vector, vector5, color);
		}

		public static void DrawSquare(VertexHelper vh, Vector3 center, float radius, Color32 color)
		{
			DrawSquare(vh, center, radius, color, color);
		}

		public static void DrawSquare(VertexHelper vh, Vector3 center, float radius, Color32 color, Color32 toColor, bool vertical = true)
		{
			Vector3 p;
			Vector3 p2;
			Vector3 p3;
			Vector3 p4;
			if (vertical)
			{
				p = new Vector3(center.x + radius, center.y - radius);
				p2 = new Vector3(center.x - radius, center.y - radius);
				p3 = new Vector3(center.x - radius, center.y + radius);
				p4 = new Vector3(center.x + radius, center.y + radius);
			}
			else
			{
				p = new Vector3(center.x - radius, center.y - radius);
				p2 = new Vector3(center.x - radius, center.y + radius);
				p3 = new Vector3(center.x + radius, center.y + radius);
				p4 = new Vector3(center.x + radius, center.y - radius);
			}
			DrawQuadrilateral(vh, p, p2, p3, p4, color, toColor);
		}

		public static void DrawRectangle(VertexHelper vh, Vector3 p1, Vector3 p2, float radius, Color32 color)
		{
			DrawRectangle(vh, p1, p2, radius, color, color);
		}

		public static void DrawRectangle(VertexHelper vh, Vector3 p1, Vector3 p2, float radius, Color32 color, Color32 toColor)
		{
			Vector3 normalized = Vector3.Cross((p2 - p1).normalized, Vector3.forward).normalized;
			Vector3 p3 = p1 + normalized * radius;
			Vector3 p4 = p1 - normalized * radius;
			Vector3 p5 = p2 - normalized * radius;
			Vector3 p6 = p2 + normalized * radius;
			DrawQuadrilateral(vh, p3, p4, p5, p6, color, toColor);
		}

		public static void DrawRectangle(VertexHelper vh, Vector3 p, float xRadius, float yRadius, Color32 color, bool vertical = true)
		{
			DrawRectangle(vh, p, xRadius, yRadius, color, color, vertical);
		}

		public static void DrawRectangle(VertexHelper vh, Vector3 p, float xRadius, float yRadius, Color32 color, Color32 toColor, bool vertical = true)
		{
			Vector3 p2;
			Vector3 p3;
			Vector3 p4;
			Vector3 p5;
			if (vertical)
			{
				p2 = new Vector3(p.x + xRadius, p.y - yRadius);
				p3 = new Vector3(p.x - xRadius, p.y - yRadius);
				p4 = new Vector3(p.x - xRadius, p.y + yRadius);
				p5 = new Vector3(p.x + xRadius, p.y + yRadius);
			}
			else
			{
				p2 = new Vector3(p.x - xRadius, p.y - yRadius);
				p3 = new Vector3(p.x - xRadius, p.y + yRadius);
				p4 = new Vector3(p.x + xRadius, p.y + yRadius);
				p5 = new Vector3(p.x + xRadius, p.y - yRadius);
			}
			DrawQuadrilateral(vh, p2, p3, p4, p5, color, toColor);
		}

		public static void DrawRectangle(VertexHelper vh, Rect rect, Color32 color)
		{
			DrawRectangle(vh, rect.center, rect.width / 2f, rect.height / 2f, color, color);
		}

		public static void DrawRectangle(VertexHelper vh, Rect rect, Color32 color, Color32 toColor)
		{
			DrawRectangle(vh, rect.center, rect.width / 2f, rect.height / 2f, color, toColor);
		}

		public static void DrawRectangle(VertexHelper vh, Rect rect, float border, Color32 color)
		{
			DrawRectangle(vh, rect, border, color, color);
		}

		public static void DrawRectangle(VertexHelper vh, Rect rect, float border, Color32 color, Color32 toColor)
		{
			DrawRectangle(vh, rect.center, rect.width / 2f - border, rect.height / 2f - border, color, toColor);
		}

		public static void DrawQuadrilateral(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Color32 color)
		{
			DrawQuadrilateral(vh, p1, p2, p3, p4, color, color);
		}

		public static void DrawQuadrilateral(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Color32 startColor, Color32 toColor)
		{
			DrawQuadrilateral(vh, p1, p2, p3, p4, startColor, startColor, toColor, toColor);
		}

		public static void DrawQuadrilateral(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Color32 color1, Color32 color2, Color32 color3, Color32 color4)
		{
			s_Vertex[0].position = p1;
			s_Vertex[1].position = p2;
			s_Vertex[2].position = p3;
			s_Vertex[3].position = p4;
			s_Vertex[0].color = color1;
			s_Vertex[1].color = color2;
			s_Vertex[2].color = color3;
			s_Vertex[3].color = color4;
			for (int i = 0; i < 4; i++)
			{
				s_Vertex[i].uv0 = s_ZeroVector2;
			}
			vh.AddUIVertexQuad(s_Vertex);
		}

		public static void InitCornerRadius(float[] cornerRadius, float width, float height, bool horizontal, bool invert, ref float brLt, ref float brRt, ref float brRb, ref float brLb, ref bool needRound)
		{
			if (cornerRadius == null || cornerRadius.Length == 0)
			{
				return;
			}
			if (invert)
			{
				if (horizontal)
				{
					brLt = ((cornerRadius.Length != 0) ? cornerRadius[1] : 0f);
					brRt = ((cornerRadius.Length > 1) ? cornerRadius[0] : 0f);
					brRb = ((cornerRadius.Length > 2) ? cornerRadius[3] : 0f);
					brLb = ((cornerRadius.Length > 3) ? cornerRadius[2] : 0f);
				}
				else
				{
					brLt = ((cornerRadius.Length != 0) ? cornerRadius[3] : 0f);
					brRt = ((cornerRadius.Length > 1) ? cornerRadius[2] : 0f);
					brRb = ((cornerRadius.Length > 2) ? cornerRadius[1] : 0f);
					brLb = ((cornerRadius.Length > 3) ? cornerRadius[0] : 0f);
				}
			}
			else
			{
				brLt = ((cornerRadius.Length != 0) ? cornerRadius[0] : 0f);
				brRt = ((cornerRadius.Length > 1) ? cornerRadius[1] : 0f);
				brRb = ((cornerRadius.Length > 2) ? cornerRadius[2] : 0f);
				brLb = ((cornerRadius.Length > 3) ? cornerRadius[3] : 0f);
			}
			needRound = brLb != 0f || brRt != 0f || brRb != 0f || brLb != 0f;
			if (!needRound)
			{
				return;
			}
			float num = Mathf.Min(width, height);
			if (brLt == 1f && brRt == 1f && brRb == 1f && brLb == 1f)
			{
				brLt = (brRt = (brRb = (brLb = num / 2f)));
				return;
			}
			if (brLt > 0f && brLt <= 1f)
			{
				brLt *= num;
			}
			if (brRt > 0f && brRt <= 1f)
			{
				brRt *= num;
			}
			if (brRb > 0f && brRb <= 1f)
			{
				brRb *= num;
			}
			if (brLb > 0f && brLb <= 1f)
			{
				brLb *= num;
			}
			if (horizontal)
			{
				if (brLb + brLt >= height)
				{
					float num2 = brLb + brLt;
					brLb = height * (brLb / num2);
					brLt = height * (brLt / num2);
				}
				if (brRt + brRb >= height)
				{
					float num3 = brRt + brRb;
					brRt = height * (brRt / num3);
					brRb = height * (brRb / num3);
				}
				if (brLt + brRt >= width)
				{
					float num4 = brLt + brRt;
					brLt = width * (brLt / num4);
					brRt = width * (brRt / num4);
				}
				if (brRb + brLb >= width)
				{
					float num5 = brRb + brLb;
					brRb = width * (brRb / num5);
					brLb = width * (brLb / num5);
				}
			}
			else
			{
				if (brLt + brRt >= width)
				{
					float num6 = brLt + brRt;
					brLt = width * (brLt / num6);
					brRt = width * (brRt / num6);
				}
				if (brRb + brLb >= width)
				{
					float num7 = brRb + brLb;
					brRb = width * (brRb / num7);
					brLb = width * (brLb / num7);
				}
				if (brLb + brLt >= height)
				{
					float num8 = brLb + brLt;
					brLb = height * (brLb / num8);
					brLt = height * (brLt / num8);
				}
				if (brRt + brRb >= height)
				{
					float num9 = brRt + brRb;
					brRt = height * (brRt / num9);
					brRb = height * (brRb / num9);
				}
			}
		}

		public static void DrawRoundRectangle(VertexHelper vh, Rect rect, Color32 color, Color32 toColor, float rotate = 0f, float[] cornerRadius = null, bool isYAxis = false, float smoothness = 2f, bool invert = false)
		{
			DrawRoundRectangle(vh, rect.center, rect.width, rect.height, color, toColor, rotate, cornerRadius, isYAxis, smoothness, invert);
		}

		public static void DrawRoundRectangle(VertexHelper vh, Vector3 center, float rectWidth, float rectHeight, Color32 color, Color32 toColor, float rotate = 0f, float[] cornerRadius = null, bool horizontal = false, float smoothness = 2f, bool invert = false)
		{
			if (invert)
			{
				Color32 color2 = toColor;
				toColor = color;
				color = color2;
			}
			bool flag = !UGLHelper.IsValueEqualsColor(color, toColor);
			float num = rectWidth / 2f;
			float num2 = rectHeight / 2f;
			float brLt = 0f;
			float brRt = 0f;
			float brRb = 0f;
			float brLb = 0f;
			bool needRound = false;
			InitCornerRadius(cornerRadius, rectWidth, rectHeight, horizontal, invert, ref brLt, ref brRt, ref brRb, ref brLb, ref needRound);
			_ = Vector3.zero;
			Vector3 vector = new Vector3(center.x - num, center.y - num2);
			Vector3 vector2 = new Vector3(center.x - num, center.y + num2);
			Vector3 vector3 = new Vector3(center.x + num, center.y + num2);
			Vector3 vector4 = new Vector3(center.x + num, center.y - num2);
			if (needRound)
			{
				Vector3 vector5 = vector;
				Vector3 vector6 = vector2;
				Vector3 vector7 = vector3;
				Vector3 vector8 = vector4;
				Vector3 vector9 = vector;
				Vector3 vector10 = vector2;
				Vector3 vector11 = vector3;
				Vector3 vector12 = vector4;
				if (brLt > 0f)
				{
					vector10 = new Vector3(center.x - num + brLt, center.y + num2 - brLt);
					vector2 = vector10 + brLt * Vector3.left;
					vector6 = vector10 + brLt * Vector3.up;
				}
				if (brRt > 0f)
				{
					vector11 = new Vector3(center.x + num - brRt, center.y + num2 - brRt);
					vector3 = vector11 + brRt * Vector3.up;
					vector7 = vector11 + brRt * Vector3.right;
				}
				if (brRb > 0f)
				{
					vector12 = new Vector3(center.x + num - brRb, center.y - num2 + brRb);
					vector4 = vector12 + brRb * Vector3.right;
					vector8 = vector12 + brRb * Vector3.down;
				}
				if (brLb > 0f)
				{
					vector9 = new Vector3(center.x - num + brLb, center.y - num2 + brLb);
					vector = vector9 + brLb * Vector3.left;
					vector5 = vector9 + brLb * Vector3.down;
				}
				if (horizontal)
				{
					float num3 = Mathf.Max(brLt, brLb);
					float num4 = Mathf.Max(brRt, brRb);
					Vector3 vector13 = vector2 + num3 * Vector3.right;
					Vector3 vector14 = vector + num3 * Vector3.right;
					Vector3 p = vector7 + num4 * Vector3.left;
					Vector3 p2 = vector4 + num4 * Vector3.left;
					Vector3 p3 = vector9 + (num3 - brLb) * Vector3.right;
					Vector3 p4 = vector5 + (num3 - brLb) * Vector3.right;
					if (p3.x > vector12.x)
					{
						p3.x = vector12.x;
					}
					if (p4.x > vector12.x)
					{
						p4.x = vector12.x;
					}
					Vector3 p5 = vector6 + (num3 - brLt) * Vector3.right;
					Vector3 p6 = vector10 + (num3 - brLt) * Vector3.right;
					if (p5.x > vector11.x)
					{
						p5.x = vector11.x;
					}
					if (p6.x > vector11.x)
					{
						p6.x = vector11.x;
					}
					Vector3 p7 = vector11 + (num4 - brRt) * Vector3.left;
					Vector3 p8 = vector3 + (num4 - brRt) * Vector3.left;
					if (p7.x < vector10.x)
					{
						p7.x = vector10.x;
					}
					if (p8.x < vector10.x)
					{
						p8.x = vector10.x;
					}
					Vector3 p9 = vector8 + (num4 - brRb) * Vector3.left;
					Vector3 p10 = vector12 + (num4 - brRb) * Vector3.left;
					if (p9.x < vector9.x)
					{
						p9.x = vector9.x;
					}
					if (p10.x < vector9.x)
					{
						p10.x = vector9.x;
					}
					if (!flag)
					{
						DrawSector(vh, vector10, brLt, color, color, 270f, 360f, 1, horizontal, smoothness);
						DrawSector(vh, vector11, brRt, toColor, toColor, 0f, 90f, 1, horizontal, smoothness);
						DrawSector(vh, vector12, brRb, toColor, toColor, 90f, 180f, 1, horizontal, smoothness);
						DrawSector(vh, vector9, brLb, color, color, 180f, 270f, 1, horizontal, smoothness);
						DrawQuadrilateral(vh, vector2, vector13, vector14, vector, color, color);
						DrawQuadrilateral(vh, vector5, vector9, p3, p4, color, color);
						DrawQuadrilateral(vh, vector10, vector6, p5, p6, color, color);
						DrawQuadrilateral(vh, p2, p, vector7, vector4, toColor, toColor);
						DrawQuadrilateral(vh, p7, p8, vector3, vector11, toColor, toColor);
						DrawQuadrilateral(vh, p9, p10, vector12, vector8, toColor, toColor);
						Vector3 p11 = new Vector3(center.x - num + num3, center.y + num2);
						Vector3 p12 = new Vector3(center.x + num - num4, center.y + num2);
						Vector3 p13 = new Vector3(center.x + num - num4, center.y - num2);
						Vector3 p14 = new Vector3(center.x - num + num3, center.y - num2);
						if (p12.x > p11.x)
						{
							DrawQuadrilateral(vh, p14, p11, p12, p13, color, toColor);
						}
						return;
					}
					Color32 color3 = Color32.Lerp(color, toColor, num3 / rectWidth);
					Color32 color4 = Color32.Lerp(color, color3, brLt / num3);
					Color32 color5 = Color32.Lerp(color, color3, brLb / num3);
					Color32 color6 = Color32.Lerp(color, toColor, (rectWidth - num4) / rectWidth);
					Color32 color7 = Color32.Lerp(color6, toColor, (num4 - brRt) / num4);
					Color32 color8 = Color32.Lerp(color6, toColor, (num4 - brRb) / num4);
					DrawSector(vh, vector10, brLt, color, color4, 270f, 360f, 1, horizontal, smoothness);
					DrawSector(vh, vector11, brRt, color7, toColor, 0f, 90f, 1, horizontal, smoothness);
					DrawSector(vh, vector12, brRb, color8, toColor, 90f, 180f, 1, horizontal, smoothness);
					DrawSector(vh, vector9, brLb, color, color5, 180f, 270f, 1, horizontal, smoothness);
					DrawQuadrilateral(vh, vector, vector2, vector13, vector14, color, color3);
					DrawQuadrilateral(vh, vector5, vector9, p3, p4, color5, (p3.x == vector12.x) ? color8 : color3);
					DrawQuadrilateral(vh, vector10, vector6, p5, p6, color4, (p5.x == vector11.x) ? color7 : color3);
					DrawQuadrilateral(vh, p2, p, vector7, vector4, color6, toColor);
					DrawQuadrilateral(vh, p7, p8, vector3, vector11, (p7.x == vector10.x) ? color4 : color6, color7);
					DrawQuadrilateral(vh, p9, p10, vector12, vector8, (p9.x == vector9.x) ? color5 : color6, color8);
					Vector3 p15 = new Vector3(center.x - num + num3, center.y + num2);
					Vector3 p16 = new Vector3(center.x + num - num4, center.y + num2);
					Vector3 p17 = new Vector3(center.x + num - num4, center.y - num2);
					Vector3 p18 = new Vector3(center.x - num + num3, center.y - num2);
					if (p16.x > p15.x)
					{
						DrawQuadrilateral(vh, p18, p15, p16, p17, color3, color6);
					}
					return;
				}
				float num5 = Mathf.Max(brLt, brRt);
				float num6 = Mathf.Max(brLb, brRb);
				Vector3 p19 = new Vector3(center.x - num, center.y + num2 - num5);
				Vector3 p20 = new Vector3(center.x + num, center.y + num2 - num5);
				Vector3 p21 = new Vector3(center.x + num, center.y - num2 + num6);
				Vector3 p22 = new Vector3(center.x - num, center.y - num2 + num6);
				Vector3 vector15 = vector5 + num6 * Vector3.up;
				Vector3 vector16 = vector8 + num6 * Vector3.up;
				Vector3 p23 = vector3 + num5 * Vector3.down;
				Vector3 p24 = vector6 + num5 * Vector3.down;
				Vector3 p25 = vector10 + (num5 - brLt) * Vector3.down;
				Vector3 p26 = vector2 + (num5 - brLt) * Vector3.down;
				if (p25.y < vector9.y)
				{
					p25.y = vector9.y;
				}
				if (p26.y < vector9.y)
				{
					p26.y = vector9.y;
				}
				Vector3 p27 = vector7 + (num5 - brRt) * Vector3.down;
				Vector3 p28 = vector11 + (num5 - brRt) * Vector3.down;
				if (p27.y < vector12.y)
				{
					p27.y = vector12.y;
				}
				if (p28.y < vector12.y)
				{
					p28.y = vector12.y;
				}
				Vector3 vector17 = vector + (num6 - brLb) * Vector3.up;
				Vector3 vector18 = vector9 + (num6 - brLb) * Vector3.up;
				if (vector17.y > vector10.y)
				{
					vector17.y = vector10.y;
				}
				if (vector18.y > vector10.y)
				{
					vector18.y = vector10.y;
				}
				Vector3 vector19 = vector12 + (num6 - brRb) * Vector3.up;
				Vector3 vector20 = vector4 + (num6 - brRb) * Vector3.up;
				if (vector19.y > vector11.y)
				{
					vector19.y = vector11.y;
				}
				if (vector20.y > vector11.y)
				{
					vector20.y = vector11.y;
				}
				if (!flag)
				{
					DrawSector(vh, vector10, brLt, toColor, toColor, 270f, 360f, 1, horizontal, smoothness);
					DrawSector(vh, vector11, brRt, toColor, toColor, 0f, 90f, 1, horizontal, smoothness);
					DrawSector(vh, vector12, brRb, color, color, 90f, 180f, 1, horizontal, smoothness);
					DrawSector(vh, vector9, brLb, color, color, 180f, 270f, 1, horizontal, smoothness);
					DrawQuadrilateral(vh, vector6, vector3, p23, p24, toColor, toColor);
					DrawQuadrilateral(vh, vector2, vector10, p25, p26, toColor, toColor);
					DrawQuadrilateral(vh, vector11, vector7, p27, p28, toColor, toColor);
					DrawQuadrilateral(vh, vector5, vector15, vector16, vector8, color, color);
					DrawQuadrilateral(vh, vector, vector17, vector18, vector9, color, color);
					DrawQuadrilateral(vh, vector12, vector19, vector20, vector4, color, color);
					if (p19.y > p22.y)
					{
						DrawQuadrilateral(vh, p19, p20, p21, p22, toColor, color);
					}
					return;
				}
				Color32 color9 = Color32.Lerp(color, toColor, (rectHeight - num5) / rectHeight);
				Color32 color10 = Color32.Lerp(color9, toColor, (num5 - brLt) / num5);
				Color32 color11 = Color32.Lerp(color9, toColor, (num5 - brRt) / num5);
				Color32 color12 = Color32.Lerp(color, toColor, num6 / rectHeight);
				Color32 color13 = Color32.Lerp(color, color12, brLb / num6);
				Color32 color14 = Color32.Lerp(color, color12, brRb / num6);
				DrawSector(vh, vector10, brLt, color10, toColor, 270f, 360f, 1, horizontal, smoothness);
				DrawSector(vh, vector11, brRt, color11, toColor, 0f, 90f, 1, horizontal, smoothness);
				DrawSector(vh, vector12, brRb, color14, color, 90f, 180f, 1, horizontal, smoothness);
				DrawSector(vh, vector9, brLb, color13, color, 180f, 270f, 1, horizontal, smoothness);
				DrawQuadrilateral(vh, vector6, vector3, p23, p24, toColor, color9);
				DrawQuadrilateral(vh, vector2, vector10, p25, p26, color10, (p25.y == vector9.y) ? color13 : color9);
				DrawQuadrilateral(vh, vector11, vector7, p27, p28, color11, (p27.y == vector12.y) ? color14 : color9);
				DrawQuadrilateral(vh, vector8, vector5, vector15, vector16, color, color12);
				DrawQuadrilateral(vh, vector9, vector, vector17, vector18, color13, (vector17.y == vector10.y) ? color10 : color12);
				DrawQuadrilateral(vh, vector4, vector12, vector19, vector20, color14, (vector19.y == vector11.y) ? color11 : color12);
				if (p19.y > p22.y)
				{
					DrawQuadrilateral(vh, p19, p20, p21, p22, color9, color12);
				}
			}
			else if (horizontal)
			{
				DrawQuadrilateral(vh, vector, vector2, vector3, vector4, color, toColor);
			}
			else
			{
				DrawQuadrilateral(vh, vector4, vector, vector2, vector3, color, toColor);
			}
		}

		public static void DrawBorder(VertexHelper vh, Vector3 center, float rectWidth, float rectHeight, float borderWidth, Color32 color, float rotate = 0f, float[] cornerRadius = null, bool horizontal = false, float smoothness = 1f, bool invertCorner = false, float extWidth = 0f)
		{
			DrawBorder(vh, center, rectWidth, rectHeight, borderWidth, color, s_ClearColor32, rotate, cornerRadius, horizontal, smoothness, invertCorner, extWidth);
		}

		public static void DrawBorder(VertexHelper vh, Rect rect, float borderWidth, Color32 color, float rotate = 0f, float[] cornerRadius = null, bool horizontal = false, float smoothness = 1f, bool invertCorner = false, float extWidth = 0f)
		{
			DrawBorder(vh, rect.center, rect.width, rect.height, borderWidth, color, s_ClearColor32, rotate, cornerRadius, horizontal, smoothness, invertCorner, extWidth);
		}

		public static void DrawBorder(VertexHelper vh, Vector3 center, float rectWidth, float rectHeight, float borderWidth, Color32 color, Color32 toColor, float rotate = 0f, float[] cornerRadius = null, bool horizontal = false, float smoothness = 1f, bool invertCorner = false, float extWidth = 0f)
		{
			if (borderWidth == 0f || UGLHelper.IsClearColor(color))
			{
				return;
			}
			float num = rectWidth / 2f;
			float num2 = rectHeight / 2f;
			Vector3 vector = new Vector3(center.x - num - extWidth, center.y - num2 - extWidth);
			Vector3 vector2 = new Vector3(center.x - num - borderWidth - extWidth, center.y - num2 - borderWidth - extWidth);
			Vector3 vector3 = new Vector3(center.x - num - extWidth, center.y + num2 + extWidth);
			Vector3 vector4 = new Vector3(center.x - num - borderWidth - extWidth, center.y + num2 + borderWidth + extWidth);
			Vector3 vector5 = new Vector3(center.x + num + extWidth, center.y + num2 + extWidth);
			Vector3 vector6 = new Vector3(center.x + num + borderWidth + extWidth, center.y + num2 + borderWidth + extWidth);
			Vector3 vector7 = new Vector3(center.x + num + extWidth, center.y - num2 - extWidth);
			Vector3 vector8 = new Vector3(center.x + num + borderWidth + extWidth, center.y - num2 - borderWidth - extWidth);
			float brLt = 0f;
			float brRt = 0f;
			float brRb = 0f;
			float brLb = 0f;
			bool needRound = false;
			InitCornerRadius(cornerRadius, rectWidth, rectHeight, horizontal, invertCorner, ref brLt, ref brRt, ref brRb, ref brLb, ref needRound);
			Vector3 zero = Vector3.zero;
			if (UGLHelper.IsClearColor(toColor))
			{
				toColor = color;
			}
			if (needRound)
			{
				Vector3 vector9 = vector;
				Vector3 vector10 = vector2;
				Vector3 vector11 = vector3;
				Vector3 vector12 = vector4;
				Vector3 vector13 = vector5;
				Vector3 vector14 = vector6;
				Vector3 vector15 = vector7;
				Vector3 vector16 = vector8;
				zero = new Vector3(center.x - num + brLt, center.y + num2 - brLt);
				brLt += extWidth;
				DrawDoughnut(vh, zero, brLt, brLt + borderWidth, horizontal ? color : toColor, s_ClearColor32, 270f, 360f, smoothness);
				vector3 = zero + brLt * Vector3.left;
				vector4 = zero + (brLt + borderWidth) * Vector3.left;
				vector11 = zero + brLt * Vector3.up;
				vector12 = zero + (brLt + borderWidth) * Vector3.up;
				zero = new Vector3(center.x + num - brRt, center.y + num2 - brRt);
				brRt += extWidth;
				DrawDoughnut(vh, zero, brRt, brRt + borderWidth, toColor, s_ClearColor32, 0f, 90f, smoothness);
				vector5 = zero + brRt * Vector3.up;
				vector6 = zero + (brRt + borderWidth) * Vector3.up;
				vector13 = zero + brRt * Vector3.right;
				vector14 = zero + (brRt + borderWidth) * Vector3.right;
				zero = new Vector3(center.x + num - brRb, center.y - num2 + brRb);
				brRb += extWidth;
				DrawDoughnut(vh, zero, brRb, brRb + borderWidth, horizontal ? toColor : color, s_ClearColor32, 90f, 180f, smoothness);
				vector7 = zero + brRb * Vector3.right;
				vector8 = zero + (brRb + borderWidth) * Vector3.right;
				vector15 = zero + brRb * Vector3.down;
				vector16 = zero + (brRb + borderWidth) * Vector3.down;
				zero = new Vector3(center.x - num + brLb, center.y - num2 + brLb);
				brLb += extWidth;
				DrawDoughnut(vh, zero, brLb, brLb + borderWidth, color, s_ClearColor32, 180f, 270f, smoothness);
				vector = zero + brLb * Vector3.left;
				vector2 = zero + (brLb + borderWidth) * Vector3.left;
				vector9 = zero + brLb * Vector3.down;
				vector10 = zero + (brLb + borderWidth) * Vector3.down;
				if (horizontal)
				{
					DrawQuadrilateral(vh, vector, vector2, vector4, vector3, color, color);
					DrawQuadrilateral(vh, vector11, vector12, vector6, vector5, color, toColor);
					DrawQuadrilateral(vh, vector13, vector14, vector8, vector7, toColor, toColor);
					DrawQuadrilateral(vh, vector15, vector16, vector10, vector9, toColor, color);
				}
				else
				{
					DrawQuadrilateral(vh, vector, vector2, vector4, vector3, color, toColor);
					DrawQuadrilateral(vh, vector11, vector12, vector6, vector5, toColor, toColor);
					DrawQuadrilateral(vh, vector13, vector14, vector8, vector7, toColor, color);
					DrawQuadrilateral(vh, vector15, vector16, vector10, vector9, color, color);
				}
			}
			else
			{
				if (rotate > 0f)
				{
					vector = UGLHelper.RotateRound(vector, center, Vector3.forward, rotate);
					vector2 = UGLHelper.RotateRound(vector2, center, Vector3.forward, rotate);
					vector3 = UGLHelper.RotateRound(vector3, center, Vector3.forward, rotate);
					vector4 = UGLHelper.RotateRound(vector4, center, Vector3.forward, rotate);
					vector5 = UGLHelper.RotateRound(vector5, center, Vector3.forward, rotate);
					vector6 = UGLHelper.RotateRound(vector6, center, Vector3.forward, rotate);
					vector7 = UGLHelper.RotateRound(vector7, center, Vector3.forward, rotate);
					vector8 = UGLHelper.RotateRound(vector8, center, Vector3.forward, rotate);
				}
				if (horizontal)
				{
					DrawQuadrilateral(vh, vector, vector2, vector4, vector3, color, color);
					DrawQuadrilateral(vh, vector3, vector4, vector6, vector5, color, toColor);
					DrawQuadrilateral(vh, vector5, vector6, vector8, vector7, toColor, toColor);
					DrawQuadrilateral(vh, vector7, vector8, vector2, vector, toColor, color);
				}
				else
				{
					DrawQuadrilateral(vh, vector, vector2, vector4, vector3, color, toColor);
					DrawQuadrilateral(vh, vector3, vector4, vector6, vector5, toColor, toColor);
					DrawQuadrilateral(vh, vector5, vector6, vector8, vector7, toColor, color);
					DrawQuadrilateral(vh, vector7, vector8, vector2, vector, color, color);
				}
			}
		}

		public static void DrawTriangle(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Color32 color)
		{
			DrawTriangle(vh, p1, p2, p3, color, color, color);
		}

		public static void DrawTriangle(VertexHelper vh, Vector3 pos, float size, Color32 color)
		{
			DrawTriangle(vh, pos, size, color, color);
		}

		public static void DrawTriangle(VertexHelper vh, Vector3 pos, float size, Color32 color, Color32 toColor)
		{
			float num = size * Mathf.Cos(MathF.PI / 6f);
			float num2 = size * Mathf.Sin(MathF.PI / 6f);
			Vector2 vector = new Vector2(pos.x - num, pos.y - num2);
			Vector2 vector2 = new Vector2(pos.x, pos.y + size);
			DrawTriangle(p3: new Vector2(pos.x + num, pos.y - num2), vh: vh, p1: vector, p2: vector2, color: color, color2: toColor, color3: color);
		}

		public static void DrawTriangle(VertexHelper vh, Vector3 p1, Vector3 p2, Vector3 p3, Color32 color, Color32 color2, Color32 color3)
		{
			UIVertex v = new UIVertex
			{
				position = p1,
				color = color,
				uv0 = s_ZeroVector2
			};
			UIVertex v2 = new UIVertex
			{
				position = p2,
				color = color2,
				uv0 = s_ZeroVector2
			};
			UIVertex v3 = new UIVertex
			{
				position = p3,
				color = color3,
				uv0 = s_ZeroVector2
			};
			int currentVertCount = vh.currentVertCount;
			vh.AddVert(v);
			vh.AddVert(v2);
			vh.AddVert(v3);
			vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		}

		public static void DrawEmptyTriangle(VertexHelper vh, Vector3 pos, float size, float tickness, Color32 color)
		{
			DrawEmptyTriangle(vh, pos, size, tickness, color, s_ClearColor32);
		}

		public static void DrawEmptyTriangle(VertexHelper vh, Vector3 pos, float size, float tickness, Color32 color, Color32 backgroundColor)
		{
			float num = Mathf.Cos(MathF.PI / 6f);
			float num2 = Mathf.Sin(MathF.PI / 6f);
			float num3 = size * num;
			float num4 = size * num2;
			Vector2 vector = new Vector2(pos.x - num3, pos.y - num4);
			Vector2 vector2 = new Vector2(pos.x, pos.y + size);
			Vector2 vector3 = new Vector2(pos.x + num3, pos.y - num4);
			float num5 = size - tickness;
			float num6 = num5 * num;
			float num7 = num5 * num2;
			Vector2 vector4 = new Vector2(pos.x - num6, pos.y - num7);
			Vector2 vector5 = new Vector2(pos.x, pos.y + num5);
			Vector2 vector6 = new Vector2(pos.x + num6, pos.y - num7);
			if (!UGLHelper.IsClearColor(backgroundColor))
			{
				DrawTriangle(vh, vector4, vector5, vector6, backgroundColor, backgroundColor, backgroundColor);
			}
			AddVertToVertexHelper(vh, vector, vector4, color, needTriangle: false);
			AddVertToVertexHelper(vh, vector2, vector5, color);
			AddVertToVertexHelper(vh, vector3, vector6, color);
			AddVertToVertexHelper(vh, vector, vector4, color);
		}

		public static void DrawCricle(VertexHelper vh, Vector3 center, float radius, Color32 color, float smoothness = 2f)
		{
			DrawCricle(vh, center, radius, color, color, 0f, s_ClearColor32, smoothness);
		}

		public static void DrawCricle(VertexHelper vh, Vector3 center, float radius, Color32 color, Color32 toColor, float smoothness = 2f)
		{
			DrawSector(vh, center, radius, color, toColor, 0f, 360f, 0f, s_ClearColor32, smoothness);
		}

		public static void DrawCricle(VertexHelper vh, Vector3 center, float radius, Color32 color, Color32 toColor, float borderWidth, Color32 borderColor, float smoothness = 2f)
		{
			DrawSector(vh, center, radius, color, toColor, 0f, 360f, borderWidth, borderColor, smoothness);
		}

		public static void DrawCricle(VertexHelper vh, Vector3 center, float radius, Color32 color, float borderWidth, Color32 borderColor, float smoothness = 2f)
		{
			DrawCricle(vh, center, radius, color, color, borderWidth, borderColor, smoothness);
		}

		public static void DrawEmptyCricle(VertexHelper vh, Vector3 center, float radius, float tickness, Color32 color, Color32 emptyColor, float smoothness = 2f)
		{
			DrawDoughnut(vh, center, radius - tickness, radius, color, color, emptyColor, 0f, 360f, 0f, s_ClearColor32, 0f, smoothness);
		}

		public static void DrawEmptyCricle(VertexHelper vh, Vector3 center, float radius, float tickness, Color32 color, Color32 emptyColor, float borderWidth, Color32 borderColor, float smoothness = 2f)
		{
			DrawDoughnut(vh, center, radius - tickness, radius, color, color, emptyColor, 0f, 360f, borderWidth, borderColor, 0f, smoothness);
		}

		public static void DrawEmptyCricle(VertexHelper vh, Vector3 center, float radius, float tickness, Color32 color, Color32 toColor, Color32 emptyColor, float smoothness = 2f)
		{
			DrawDoughnut(vh, center, radius - tickness, radius, color, toColor, emptyColor, 0f, 360f, 0f, s_ClearColor32, 0f, smoothness);
		}

		public static void DrawEmptyCricle(VertexHelper vh, Vector3 center, float radius, float tickness, Color32 color, Color32 toColor, Color32 emptyColor, float borderWidth, Color32 borderColor, float smoothness = 2f)
		{
			DrawDoughnut(vh, center, radius - tickness, radius, color, toColor, emptyColor, 0f, 360f, borderWidth, borderColor, 0f, smoothness);
		}

		public static void DrawSector(VertexHelper vh, Vector3 center, float radius, Color32 color, float startDegree, float toDegree, float smoothness = 2f)
		{
			DrawSector(vh, center, radius, color, color, startDegree, toDegree, 0f, s_ClearColor32, smoothness);
		}

		public static void DrawSector(VertexHelper vh, Vector3 center, float radius, Color32 color, Color32 toColor, float startDegree, float toDegree, int gradientType = 0, bool isYAxis = false, float smoothness = 2f)
		{
			DrawSector(vh, center, radius, color, toColor, startDegree, toDegree, 0f, s_ClearColor32, 0f, smoothness, gradientType, isYAxis);
		}

		public static void DrawSector(VertexHelper vh, Vector3 center, float radius, Color32 color, float startDegree, float toDegree, float borderWidth, Color32 borderColor, float smoothness = 2f)
		{
			DrawSector(vh, center, radius, color, color, startDegree, toDegree, borderWidth, borderColor, smoothness);
		}

		public static void DrawSector(VertexHelper vh, Vector3 center, float radius, Color32 color, Color32 toColor, float startDegree, float toDegree, float borderWidth, Color32 borderColor, float smoothness = 2f)
		{
			DrawSector(vh, center, radius, color, toColor, startDegree, toDegree, borderWidth, borderColor, 0f, smoothness);
		}

		public static void DrawSector(VertexHelper vh, Vector3 center, float radius, Color32 color, Color32 toColor, float startDegree, float toDegree, float borderWidth, Color32 borderColor, float gap, float smoothness, int gradientType = 0, bool isYAxis = false)
		{
			if (radius == 0f)
			{
				return;
			}
			bool flag = Mathf.Abs(toDegree - startDegree) >= 360f;
			if (gap > 0f && flag)
			{
				gap = 0f;
			}
			radius -= borderWidth;
			smoothness = ((smoothness < 0f) ? 2f : smoothness);
			int num = (int)(MathF.PI * 2f * radius * (Mathf.Abs(toDegree - startDegree) / 360f) / smoothness);
			if (num < 1)
			{
				num = 1;
			}
			float num2 = startDegree * (MathF.PI / 180f);
			float num3 = toDegree * (MathF.PI / 180f);
			float num4 = num2;
			float num5 = num3;
			float num6 = (num3 - num2) / 2f;
			float num7 = 0f;
			float num8 = 0f;
			Vector3 vector = center + radius * UGLHelper.GetDire(num2);
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			Vector3 vector2 = center;
			Vector3 vector3 = center;
			Vector3 p = center;
			Color32 startColor = color;
			bool flag2 = borderWidth != 0f;
			bool flag3 = gap != 0f;
			float num9 = (flag3 ? borderWidth : (borderWidth / 2f));
			_ = Vector3.zero;
			Vector3 dire = UGLHelper.GetDire(num2 + num6);
			if (flag2 || flag3)
			{
				float num10 = 0f;
				float num11 = 0f;
				if (flag3)
				{
					num10 = gap / Mathf.Sin(num6);
					vector2 = center + num10 * dire;
					vector3 = vector2;
					num8 = 2f * Mathf.Asin(gap / (2f * radius));
					num4 = num2 + num8;
					num5 = num3 - num8;
					if (num5 < num4)
					{
						num5 = num4;
					}
					vector = UGLHelper.GetPos(center, radius, num4);
				}
				if (flag2 && !flag)
				{
					num11 = num9 / Mathf.Sin(num6);
					vector3 += num11 * dire;
					num7 = 2f * Mathf.Asin(num9 / (2f * radius));
					num4 += num7;
					num5 -= num7;
					if (num5 < num4)
					{
						num5 = num4;
						vector = UGLHelper.GetPos(center, radius, num4);
					}
					else
					{
						Vector3 pos = UGLHelper.GetPos(center, radius, num4);
						DrawQuadrilateral(vh, vector3, vector2, vector, pos, borderColor);
						vector = pos;
						Vector3 pos2 = UGLHelper.GetPos(center, radius, num5);
						Vector3 pos3 = UGLHelper.GetPos(center, radius, num3 - num8);
						DrawQuadrilateral(vh, vector3, pos2, pos3, vector2, borderColor);
					}
				}
			}
			float num12 = (num5 - num4) / (float)num;
			bool flag4 = startDegree >= 180f;
			for (int i = 0; i <= num; i++)
			{
				float angle = num4 + (float)i * num12;
				zero = center + radius * UGLHelper.GetDire(angle);
				switch (gradientType)
				{
				case 1:
					if (isYAxis)
					{
						zero2 = new Vector3(zero.x, vector3.y);
						float num13 = zero2.x - vector3.x;
						Color32 color3 = Color32.Lerp(color, toColor, (num13 >= 0f) ? (num13 / radius) : (Mathf.Min(radius + num13, radius) / radius));
						if (flag4 && (i == num || i == 0))
						{
							color3 = toColor;
						}
						DrawQuadrilateral(vh, p, vector, zero, zero2, startColor, color3);
						p = zero2;
						startColor = color3;
					}
					else
					{
						zero2 = new Vector3(vector3.x, zero.y);
						Color32 color4 = Color32.Lerp(color, toColor, Mathf.Abs(zero2.y - vector3.y) / radius);
						DrawQuadrilateral(vh, p, vector, zero, zero2, startColor, color4);
						p = zero2;
						startColor = color4;
					}
					break;
				case 2:
				{
					Color32 color2 = Color32.Lerp(color, toColor, i / num);
					DrawQuadrilateral(vh, vector3, vector, zero, vector3, startColor, color2);
					startColor = color2;
					break;
				}
				default:
					AddVertToVertexHelper(vh, zero, vector3, color, toColor, i > 0);
					break;
				}
				vector = zero;
			}
			if ((flag2 || flag3) && num5 > num4)
			{
				Vector3 p2 = center + radius * UGLHelper.GetDire(num5);
				DrawTriangle(vh, vector3, vector, p2, toColor, color, color);
				if (flag2)
				{
					float startDegree2 = (num4 - num7) * 57.29578f;
					float toDegree2 = (num5 + num7) * 57.29578f;
					DrawDoughnut(vh, center, radius, radius + borderWidth, borderColor, s_ClearColor32, startDegree2, toDegree2, smoothness);
				}
			}
		}

		public static void DrawRoundCap(VertexHelper vh, Vector3 center, float width, float radius, float angle, bool clockwise, Color32 color, bool end)
		{
			float x = Mathf.Sin(angle * (MathF.PI / 180f)) * radius;
			float y = Mathf.Cos(angle * (MathF.PI / 180f)) * radius;
			Vector3 center2 = new Vector3(x, y) + center;
			if (end)
			{
				if (clockwise)
				{
					DrawSector(vh, center2, width, color, angle, angle + 180f, 0f, s_ClearColor32);
				}
				else
				{
					DrawSector(vh, center2, width, color, angle, angle - 180f, 0f, s_ClearColor32);
				}
			}
			else if (clockwise)
			{
				DrawSector(vh, center2, width, color, angle + 180f, angle + 360f, 0f, s_ClearColor32);
			}
			else
			{
				DrawSector(vh, center2, width, color, angle - 180f, angle - 360f, 0f, s_ClearColor32);
			}
		}

		public static void DrawDoughnut(VertexHelper vh, Vector3 center, float insideRadius, float outsideRadius, Color32 color, Color32 emptyColor, float smoothness = 2f)
		{
			DrawDoughnut(vh, center, insideRadius, outsideRadius, color, color, emptyColor, 0f, 360f, 0f, s_ClearColor32, 0f, smoothness);
		}

		public static void DrawDoughnut(VertexHelper vh, Vector3 center, float insideRadius, float outsideRadius, Color32 color, Color32 emptyColor, float startDegree, float toDegree, float smoothness = 1f)
		{
			DrawDoughnut(vh, center, insideRadius, outsideRadius, color, color, emptyColor, startDegree, toDegree, 0f, s_ClearColor32, 0f, smoothness);
		}

		public static void DrawDoughnut(VertexHelper vh, Vector3 center, float insideRadius, float outsideRadius, Color32 color, Color32 emptyColor, float startDegree, float toDegree, float borderWidth, Color32 borderColor, float smoothness = 2f)
		{
			DrawDoughnut(vh, center, insideRadius, outsideRadius, color, color, emptyColor, startDegree, toDegree, borderWidth, borderColor, 0f, smoothness);
		}

		public static void DrawDoughnut(VertexHelper vh, Vector3 center, float insideRadius, float outsideRadius, Color32 color, Color32 toColor, Color32 emptyColor, float smoothness = 2f)
		{
			DrawDoughnut(vh, center, insideRadius, outsideRadius, color, toColor, emptyColor, 0f, 360f, 0f, s_ClearColor32, 0f, smoothness);
		}

		public static void DrawDoughnut(VertexHelper vh, Vector3 center, float insideRadius, float outsideRadius, Color32 color, Color32 toColor, Color32 emptyColor, float startDegree, float toDegree, float borderWidth, Color32 borderColor, float gap, float smoothness, bool roundCap = false, bool clockwise = true)
		{
			if (toDegree - startDegree == 0f)
			{
				return;
			}
			if (gap > 0f && Mathf.Abs(toDegree - startDegree) >= 360f)
			{
				gap = 0f;
			}
			if (insideRadius <= 0f)
			{
				DrawSector(vh, center, outsideRadius, color, toColor, startDegree, toDegree, borderWidth, borderColor, gap, smoothness);
				return;
			}
			outsideRadius -= borderWidth;
			insideRadius += borderWidth;
			smoothness = ((smoothness < 0f) ? 2f : smoothness);
			bool flag = Mathf.Abs(toDegree - startDegree) >= 360f;
			bool flag2 = borderWidth != 0f;
			bool flag3 = gap != 0f;
			float num = Mathf.Abs(toDegree - startDegree) * (MathF.PI / 180f);
			int num2 = (int)(MathF.PI * 2f * outsideRadius * (num * 57.29578f / 360f) / smoothness);
			if (num2 < 1)
			{
				num2 = 1;
			}
			float num3 = startDegree * (MathF.PI / 180f);
			float num4 = toDegree * (MathF.PI / 180f);
			float num5 = num3;
			float num6 = num4;
			float num7 = num3;
			float num8 = num4;
			float num9 = (num4 - num3) / 2f;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			float num13 = 0f;
			float num14 = 0f;
			float num15 = 0f;
			Vector3 vector = center;
			Vector3 normalized = new Vector3(Mathf.Sin(num3), Mathf.Cos(num3)).normalized;
			Vector3 normalized2 = new Vector3(Mathf.Sin(num4), Mathf.Cos(num4)).normalized;
			Vector3 normalized3 = new Vector3(Mathf.Sin(num3 + num9), Mathf.Cos(num3 + num9)).normalized;
			Vector3 vector2 = center + insideRadius * normalized;
			Vector3 vector3 = center + outsideRadius * normalized;
			Vector3 p = center + insideRadius * normalized2;
			Vector3 p2 = center + outsideRadius * normalized2;
			if (roundCap)
			{
				float num16 = (outsideRadius - insideRadius) / 2f;
				float num17 = insideRadius + num16;
				float num18 = Mathf.Atan(num16 / num17);
				if (num < 2f * num18)
				{
					roundCap = false;
				}
			}
			if (flag2 || flag3)
			{
				if (flag3)
				{
					float f = gap / Mathf.Sin(num9);
					vector = center + Mathf.Abs(f) * normalized3;
					num13 = 2f * Mathf.Asin(gap / (2f * outsideRadius));
					num14 = 2f * Mathf.Asin(gap / (2f * insideRadius));
					num15 = 2f * Mathf.Asin(gap / (2f * (insideRadius + (outsideRadius - insideRadius) / 2f)));
					if (clockwise)
					{
						vector2 = UGLHelper.GetPos(center, insideRadius, num3 + num14);
						p = UGLHelper.GetPos(center, insideRadius, num4 - num14);
						num5 = num3 + num13;
						num6 = num4 - num13;
						num7 = num3 + num14;
						num8 = num4 - num14;
					}
					else
					{
						vector2 = UGLHelper.GetPos(center, insideRadius, num3 - num14);
						p = UGLHelper.GetPos(center, insideRadius, num4 + num14);
						num5 = num3 - num13;
						num6 = num4 + num13;
						num7 = num3 - num14;
						num6 = num4 + num14;
					}
					vector3 = UGLHelper.GetPos(center, outsideRadius, num5);
					p2 = UGLHelper.GetPos(center, outsideRadius, num6);
				}
				if (flag2 && !flag)
				{
					float f2 = borderWidth / Mathf.Sin(num9);
					vector += Mathf.Abs(f2) * normalized3;
					num10 = 2f * Mathf.Asin(borderWidth / (2f * outsideRadius));
					num11 = 2f * Mathf.Asin(borderWidth / (2f * insideRadius));
					num12 = 2f * Mathf.Asin(borderWidth / (2f * (insideRadius + (outsideRadius - insideRadius) / 2f)));
					if (clockwise)
					{
						num5 += num10;
						num6 -= num10;
						num7 = num3 + num14 + num11;
						num8 = num4 - num14 - num11;
						Vector3 pos = UGLHelper.GetPos(center, insideRadius, num3 + num14 + num11);
						Vector3 pos2 = UGLHelper.GetPos(center, outsideRadius, num5);
						if (!roundCap)
						{
							DrawQuadrilateral(vh, pos2, pos, vector2, vector3, borderColor);
						}
						vector2 = pos;
						vector3 = pos2;
						if (num4 - num14 - 2f * num11 > num5)
						{
							Vector3 pos3 = UGLHelper.GetPos(center, insideRadius, num4 - num14 - num11);
							Vector3 pos4 = UGLHelper.GetPos(center, outsideRadius, num6);
							if (!roundCap)
							{
								DrawQuadrilateral(vh, pos4, p2, p, pos3, borderColor);
							}
							p = pos3;
							p2 = pos4;
						}
					}
					else
					{
						num5 -= num10;
						num6 += num10;
						num7 = num3 - num14 - num11;
						num8 = num4 + num14 + num11;
						Vector3 pos5 = UGLHelper.GetPos(center, insideRadius, num3 - num14 - num11);
						Vector3 pos6 = UGLHelper.GetPos(center, outsideRadius, num5);
						if (!roundCap)
						{
							DrawQuadrilateral(vh, pos6, pos5, vector2, vector3, borderColor);
						}
						vector2 = pos5;
						vector3 = pos6;
						if (num4 + num14 + 2f * num11 < num5)
						{
							Vector3 pos7 = UGLHelper.GetPos(center, insideRadius, num4 + num14 + num11);
							Vector3 pos8 = UGLHelper.GetPos(center, outsideRadius, num6);
							if (!roundCap)
							{
								DrawQuadrilateral(vh, pos8, p2, p, pos7, borderColor);
							}
							p = pos7;
							p2 = pos8;
						}
					}
				}
			}
			if (roundCap)
			{
				float num19 = (outsideRadius - insideRadius) / 2f;
				float num20 = insideRadius + num19;
				float num21 = Mathf.Atan(num19 / num20);
				if (clockwise)
				{
					num5 = num3 + 2f * num15 + num12 + num21;
					num7 = num3 + 2f * num15 + num12 + num21;
				}
				else
				{
					num5 = num3 - 2f * num15 - num12 - num21;
					num7 = num3 - 2f * num15 - num12 - num21;
				}
				float num22 = num5 * 57.29578f;
				Vector3 center2 = center + num20 * UGLHelper.GetDire(num5);
				float startDegree2 = (clockwise ? (num22 + 180f) : num22);
				float toDegree2 = (clockwise ? (num22 + 360f) : (num22 + 180f));
				DrawSector(vh, center2, num19, color, startDegree2, toDegree2, smoothness / 2f);
				if (flag2)
				{
					DrawDoughnut(vh, center2, num19, num19 + borderWidth, borderColor, s_ClearColor32, startDegree2, toDegree2, smoothness / 2f);
				}
				vector2 = UGLHelper.GetPos(center, insideRadius, num5);
				vector3 = UGLHelper.GetPos(center, outsideRadius, num5);
				if (clockwise)
				{
					num6 = num4 - 2f * num15 - num12 - num21;
					num8 = num4 - 2f * num15 - num12 - num21;
					if (num6 < num5)
					{
						num6 = num5;
					}
				}
				else
				{
					num6 = num4 + 2f * num15 + num12 + num21;
					num8 = num4 + 2f * num15 + num12 + num21;
					if (num6 > num5)
					{
						num6 = num5;
					}
				}
				num22 = num6 * 57.29578f;
				center2 = center + num20 * UGLHelper.GetDire(num6);
				startDegree2 = (clockwise ? num22 : (num22 + 180f));
				toDegree2 = (clockwise ? (num22 + 180f) : (num22 + 360f));
				DrawSector(vh, center2, num19, toColor, startDegree2, toDegree2, smoothness / 2f);
				if (flag2)
				{
					DrawDoughnut(vh, center2, num19, num19 + borderWidth, borderColor, s_ClearColor32, startDegree2, toDegree2, smoothness / 2f);
				}
				p = UGLHelper.GetPos(center, insideRadius, num6);
				p2 = UGLHelper.GetPos(center, outsideRadius, num6);
			}
			float num23 = (num8 - num7) / (float)num2;
			bool flag4 = !UGLHelper.IsValueEqualsColor(color, toColor);
			for (int i = 0; i <= num2; i++)
			{
				float f3 = num7 + (float)i * num23;
				Vector3 vector4 = new Vector3(center.x + outsideRadius * Mathf.Sin(f3), center.y + outsideRadius * Mathf.Cos(f3));
				Vector3 vector5 = new Vector3(center.x + insideRadius * Mathf.Sin(f3), center.y + insideRadius * Mathf.Cos(f3));
				if (flag4)
				{
					Color32 color2 = Color32.Lerp(color, toColor, (float)i * 1f / (float)num2);
					if (i == 0 && (flag3 || flag2))
					{
						DrawTriangle(vh, vector2, vector3, vector4, color, color2, color2);
					}
					AddVertToVertexHelper(vh, vector4, vector5, color2, color2, i > 0);
				}
				else
				{
					if (i == 0 && (flag3 || flag2))
					{
						DrawTriangle(vh, vector2, vector3, vector4, color);
					}
					AddVertToVertexHelper(vh, vector4, vector5, color, color, i > 0);
				}
				vector2 = vector5;
				vector3 = vector4;
			}
			if (!UGLHelper.IsClearColor(emptyColor))
			{
				for (int j = 0; j <= num2; j++)
				{
					float f4 = num7 + (float)j * num23;
					AddVertToVertexHelper(bottom: new Vector3(center.x + insideRadius * Mathf.Sin(f4), center.y + insideRadius * Mathf.Cos(f4)), vh: vh, top: center, topColor: emptyColor, bottomColor: emptyColor, needTriangle: j > 0);
				}
			}
			if (!(flag2 || flag3 || roundCap))
			{
				return;
			}
			if (clockwise)
			{
				bool flag5 = num4 - num14 - 2f * num11 > num5;
				if (flag5)
				{
					DrawQuadrilateral(vh, vector3, p2, p, vector2, color, toColor);
				}
				else
				{
					DrawTriangle(vh, vector3, p2, vector2, color, color, toColor);
				}
				if (flag2)
				{
					float num24 = (num5 - (roundCap ? 0f : num10)) * 57.29578f;
					float num25 = (num6 + (roundCap ? 0f : num10)) * 57.29578f;
					if (num25 < num5)
					{
						num25 = num5;
					}
					float num26 = (roundCap ? num24 : ((num3 + num14) * 57.29578f));
					float num27 = (roundCap ? num25 : ((num4 - num14) * 57.29578f));
					if (num27 < num26)
					{
						num27 = num26;
					}
					if (flag5)
					{
						DrawDoughnut(vh, center, insideRadius - borderWidth, insideRadius, borderColor, s_ClearColor32, num26, num27, smoothness);
					}
					DrawDoughnut(vh, center, outsideRadius, outsideRadius + borderWidth, borderColor, s_ClearColor32, num24, num25, smoothness);
				}
				return;
			}
			bool flag6 = num4 + num14 + 2f * num11 < num5;
			if (flag6)
			{
				DrawQuadrilateral(vh, vector3, p2, p, vector2, color, toColor);
			}
			else
			{
				DrawTriangle(vh, vector3, p2, vector2, color, color, toColor);
			}
			if (flag2)
			{
				float num28 = (num5 + (roundCap ? 0f : num10)) * 57.29578f;
				float num29 = (num6 - (roundCap ? 0f : num10)) * 57.29578f;
				float num30 = (roundCap ? num28 : ((num3 - num14) * 57.29578f));
				float num31 = (roundCap ? num29 : ((num4 + num14) * 57.29578f));
				if (num31 > num30)
				{
					num31 = num30;
				}
				if (flag6)
				{
					DrawDoughnut(vh, center, insideRadius - borderWidth, insideRadius, borderColor, s_ClearColor32, num30, num31, smoothness);
				}
				DrawDoughnut(vh, center, outsideRadius, outsideRadius + borderWidth, borderColor, s_ClearColor32, num28, num29, smoothness);
			}
		}

		public static void DrawCurves(VertexHelper vh, Vector3 sp, Vector3 ep, Vector3 cp1, Vector3 cp2, float lineWidth, Color32 lineColor, float smoothness, Direction dire = Direction.XAxis)
		{
			int segment = (int)(Vector3.Distance(sp, ep) / ((smoothness <= 0f) ? 2f : smoothness));
			UGLHelper.GetBezierList2(ref s_CurvesPosList, sp, ep, segment, cp1, cp2);
			DrawCurvesInternal(vh, s_CurvesPosList, lineWidth, lineColor, dire);
		}

		public static void DrawCurves(VertexHelper vh, List<Vector3> points, float width, Color32 color, float smoothStyle, float smoothness, Direction dire, float currProgress = float.NaN, bool closed = false)
		{
			int count = points.Count;
			int num = (closed ? count : (count - 1));
			if (closed)
			{
				dire = Direction.Random;
			}
			for (int i = 0; i < num; i++)
			{
				Vector3 vector = points[i];
				Vector3 vector2 = ((!closed) ? points[i + 1] : ((i == num - 1) ? points[0] : points[i + 1]));
				Vector3 lsp = ((i > 0) ? points[i - 1] : (closed ? points[count - 1] : vector));
				Vector3 nep = ((i < points.Count - 2) ? points[i + 2] : (closed ? points[(i + 2) % count] : vector2));
				float smoothness2 = smoothness;
				if (currProgress != float.NaN)
				{
					switch (dire)
					{
					case Direction.XAxis:
						smoothness2 = ((vector2.x <= currProgress) ? smoothness : (smoothness * 0.5f));
						break;
					case Direction.YAxis:
						smoothness2 = ((vector2.y <= currProgress) ? smoothness : (smoothness * 0.5f));
						break;
					case Direction.Random:
						smoothness2 = smoothness * 0.5f;
						break;
					}
				}
				if (dire == Direction.YAxis)
				{
					UGLHelper.GetBezierListVertical(ref s_CurvesPosList, vector, vector2, smoothness2, smoothStyle);
				}
				else
				{
					UGLHelper.GetBezierList(ref s_CurvesPosList, vector, vector2, lsp, nep, smoothness2, smoothStyle, limit: false, dire == Direction.Random);
				}
				DrawCurvesInternal(vh, s_CurvesPosList, width, color, dire, currProgress);
			}
		}

		private static void DrawCurvesInternal(VertexHelper vh, List<Vector3> curvesPosList, float lineWidth, Color32 lineColor, Direction dire, float currProgress = float.NaN)
		{
			if (curvesPosList.Count <= 1)
			{
				return;
			}
			Vector3 vector = curvesPosList[0];
			Vector3 zero = Vector3.zero;
			Vector3 vector2 = Vector3.Cross(curvesPosList[1] - vector, Vector3.forward).normalized * lineWidth;
			Vector3 top = vector - vector2;
			Vector3 bottom = vector + vector2;
			Vector3 vector3 = Vector3.zero;
			Vector3 vector4 = Vector3.zero;
			_ = vh.currentVertCount;
			AddVertToVertexHelper(vh, top, bottom, lineColor, needTriangle: false);
			for (int i = 1; i < curvesPosList.Count; i++)
			{
				zero = curvesPosList[i];
				if (currProgress != float.NaN && ((dire == Direction.YAxis && zero.y > currProgress) || (dire == Direction.XAxis && zero.x > currProgress)))
				{
					break;
				}
				vector2 = Vector3.Cross(zero - vector, Vector3.forward).normalized * lineWidth;
				vector3 = zero - vector2;
				vector4 = zero + vector2;
				AddVertToVertexHelper(vh, vector3, vector4, lineColor);
				top = vector3;
				bottom = vector4;
				vector = zero;
			}
			AddVertToVertexHelper(vh, vector3, vector4, lineColor);
		}

		public static void DrawSvgPath(VertexHelper vh, string path)
		{
			SVG.DrawPath(vh, path);
		}

		public static void DrawEllipse(VertexHelper vh, Vector3 center, float w, float h, Color32 color, float smoothness = 1f)
		{
			DrawEllipse(vh, center, w, h, color, smoothness, 0f, s_ClearColor32, 0f, 360f);
		}

		public static void DrawEllipse(VertexHelper vh, Vector3 center, float w, float h, Color32 color, float smoothness, float borderWidth, Color32 borderColor, float startAngle, float endAngle)
		{
			startAngle = (startAngle + 360f) % 360f;
			endAngle = (endAngle + 360f) % 360f;
			if (endAngle < startAngle)
			{
				endAngle += 360f;
			}
			if (endAngle <= startAngle)
			{
				return;
			}
			float num = startAngle;
			_ = Vector2.zero;
			bool flag = color.a != 0;
			bool flag2 = borderWidth != 0f && borderColor.a != 0;
			if (!flag && !flag2)
			{
				return;
			}
			int currentVertCount = vh.currentVertCount;
			if (flag)
			{
				vh.AddVert(center, color, Vector2.zero);
			}
			if (smoothness < 0.5f)
			{
				smoothness = 0.5f;
			}
			int num2 = 0;
			for (; num <= endAngle; num += smoothness)
			{
				float f = num * (MathF.PI / 180f);
				float x = center.x + w * Mathf.Cos(f);
				float y = center.y + h * Mathf.Sin(f);
				Vector3 vector = new Vector3(x, y);
				vh.AddVert(vector, color, Vector2.zero);
				if (flag2)
				{
					Vector3 vector2 = (vector - center).normalized * borderWidth;
					Vector3 position = vector + vector2;
					vh.AddVert(vector, borderColor, Vector2.zero);
					vh.AddVert(position, borderColor, Vector2.zero);
					if (num2 > 0)
					{
						int num3 = currentVertCount + num2 * 3 + 2;
						vh.AddTriangle(num3 - 3, num3 + 1, num3 - 2);
						vh.AddTriangle(num3 - 3, num3, num3 + 1);
						if (flag)
						{
							vh.AddTriangle(currentVertCount, num3 - 1, num3 - 4);
						}
					}
				}
				else if (num2 > 0 && flag)
				{
					int num4 = currentVertCount + num2;
					vh.AddTriangle(currentVertCount, num4 + 1, num4);
				}
				num2++;
			}
		}

		public static void DrawPolygon(VertexHelper vh, List<Vector3> points, Color32 color)
		{
			if (points.Count < 3 || UGLHelper.IsClearColor(color))
			{
				return;
			}
			int currentVertCount = vh.currentVertCount;
			foreach (Vector3 point in points)
			{
				vh.AddVert(point, color, Vector2.zero);
			}
			for (int i = 2; i < points.Count; i++)
			{
				vh.AddTriangle(currentVertCount, currentVertCount + i - 1, currentVertCount + i);
			}
		}

		public static void DrawPlus(VertexHelper vh, Vector3 center, float radius, float tickness, Color32 color)
		{
			Vector3 startPoint = new Vector3(center.x - radius, center.y);
			Vector3 endPoint = new Vector3(center.x + radius, center.y);
			Vector3 startPoint2 = new Vector3(center.x, center.y - radius);
			Vector3 endPoint2 = new Vector3(center.x, center.y + radius);
			DrawLine(vh, startPoint, endPoint, tickness, color);
			DrawLine(vh, startPoint2, endPoint2, tickness, color);
		}

		public static void DrawMinus(VertexHelper vh, Vector3 center, float radius, float tickness, Color32 color)
		{
			Vector3 startPoint = new Vector3(center.x - radius, center.y);
			Vector3 endPoint = new Vector3(center.x + radius, center.y);
			DrawLine(vh, startPoint, endPoint, tickness, color);
		}
	}
}
