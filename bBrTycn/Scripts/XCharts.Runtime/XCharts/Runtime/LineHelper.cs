using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	internal static class LineHelper
	{
		private static List<Vector3> s_CurvesPosList = new List<Vector3>();

		public static int GetDataAverageRate(Serie serie, GridCoord grid, int maxCount, bool isYAxis)
		{
			float sampleDist = serie.sampleDist;
			int num = 0;
			float num2 = (isYAxis ? grid.context.height : grid.context.width);
			if (sampleDist > 0f)
			{
				num = (int)((float)(maxCount - serie.minShow) / (num2 / sampleDist));
			}
			if (num < 1)
			{
				num = 1;
			}
			return num;
		}

		public static void DrawSerieLineArea(VertexHelper vh, Serie serie, Serie lastStackSerie, ThemeStyle theme, VisualMap visualMap, bool isY, Axis axis, Axis relativedAxis, GridCoord grid)
		{
			if (!SerieHelper.GetAreaColor(out var color, out var toColor, out var innerFill, out var toTop, serie, null, theme, serie.context.colorIndex))
			{
				return;
			}
			if (innerFill)
			{
				UGL.DrawPolygon(vh, serie.context.dataPoints, color);
				return;
			}
			float num = (isY ? grid.context.x : grid.context.y);
			if (lastStackSerie == null)
			{
				DrawSerieLineNormalArea(vh, serie, isY, num + relativedAxis.context.offset, num, num + (isY ? grid.context.width : grid.context.height), color, toColor, visualMap, axis, relativedAxis, grid, toTop);
			}
			else
			{
				DrawSerieLineStackArea(vh, serie, lastStackSerie, isY, num + relativedAxis.context.offset, num, num + (isY ? grid.context.width : grid.context.height), color, toColor, visualMap, toTop);
			}
		}

		private static void DrawSerieLineNormalArea(VertexHelper vh, Serie serie, bool isY, float zero, float min, float max, Color32 areaColor, Color32 areaToColor, VisualMap visualMap, Axis axis, Axis relativedAxis, GridCoord grid, bool toTop)
		{
			List<PointInfo> drawPoints = serie.context.drawPoints;
			int count = drawPoints.Count;
			if (count < 2)
			{
				return;
			}
			bool flag = false;
			Vector3 p = Vector3.zero;
			bool flag2 = VisualMapHelper.IsNeedAreaGradient(visualMap);
			bool flag3 = !ChartHelper.IsValueEqualsColor(areaColor, areaToColor);
			Vector3 p2 = (isY ? new Vector3(zero, drawPoints[0].position.y) : new Vector3(drawPoints[0].position.x, zero));
			Vector3 p3 = (isY ? new Vector3(zero, drawPoints[count - 1].position.y) : new Vector3(drawPoints[count - 1].position.x, zero));
			bool flag4 = false;
			for (int i = 0; i < drawPoints.Count; i++)
			{
				PointInfo pointInfo = drawPoints[i];
				Vector3 pos = pointInfo.position;
				if (serie.clip)
				{
					grid.Clamp(ref pos);
				}
				bool isIgnoreBreak = pointInfo.isIgnoreBreak;
				Color32 color = areaColor;
				Color32 color2 = areaToColor;
				bool flag5 = flag3;
				if (serie.animation.CheckDetailBreak(pos, isY))
				{
					flag = true;
					float currDetail = serie.animation.GetCurrDetail();
					Vector3 intersection = Vector3.zero;
					Vector3 p4 = (isY ? new Vector3(-10000f, currDetail) : new Vector3(currDetail, -10000f));
					Vector3 p5 = (isY ? new Vector3(10000f, currDetail) : new Vector3(currDetail, 10000f));
					if (UGLHelper.GetIntersection(p, pos, p4, p5, ref intersection))
					{
						pos = intersection;
					}
				}
				Vector3 vector = (isY ? new Vector3(zero, pos.y) : new Vector3(pos.x, zero));
				if (flag2)
				{
					color = VisualMapHelper.GetLineGradientColor(visualMap, vector, grid, axis, relativedAxis, areaColor);
					color2 = VisualMapHelper.GetLineGradientColor(visualMap, pos, grid, axis, relativedAxis, areaToColor);
					flag5 = true;
				}
				if (i > 0 && ((p.y - zero > 0f && pos.y - zero < 0f) || (p.y - zero < 0f && pos.y - zero > 0f)))
				{
					Vector3 intersection2 = Vector3.zero;
					if (UGLHelper.GetIntersection(p, pos, p2, p3, ref intersection2))
					{
						if (flag5)
						{
							AddVertToVertexHelperWithLerpColor(vh, intersection2, intersection2, color, color2, isY, min, max, i > 0, toTop);
						}
						else
						{
							if (flag4)
							{
								UGL.AddVertToVertexHelper(vh, intersection2, intersection2, ColorUtil.clearColor32);
							}
							UGL.AddVertToVertexHelper(vh, intersection2, intersection2, color2, color, i > 0);
							if (isIgnoreBreak)
							{
								UGL.AddVertToVertexHelper(vh, intersection2, intersection2, ColorUtil.clearColor32);
							}
						}
					}
				}
				if (flag5)
				{
					AddVertToVertexHelperWithLerpColor(vh, pos, vector, color, color2, isY, min, max, i > 0, toTop);
				}
				else
				{
					if (flag4)
					{
						UGL.AddVertToVertexHelper(vh, pos, vector, ColorUtil.clearColor32);
					}
					UGL.AddVertToVertexHelper(vh, pos, vector, color2, color, i > 0);
					if (isIgnoreBreak)
					{
						UGL.AddVertToVertexHelper(vh, pos, vector, ColorUtil.clearColor32);
					}
				}
				p = pos;
				flag4 = isIgnoreBreak;
				if (flag)
				{
					break;
				}
			}
		}

		private static void DrawSerieLineStackArea(VertexHelper vh, Serie serie, Serie lastStackSerie, bool isY, float zero, float min, float max, Color32 color, Color32 toColor, VisualMap visualMap, bool toTop)
		{
			if (lastStackSerie == null)
			{
				return;
			}
			List<PointInfo> drawPoints = serie.context.drawPoints;
			List<PointInfo> drawPoints2 = lastStackSerie.context.drawPoints;
			int count = drawPoints.Count;
			int count2 = drawPoints2.Count;
			if (count <= 0 || count2 <= 0)
			{
				return;
			}
			bool flag = !ChartHelper.IsValueEqualsColor(color, toColor);
			Vector3 vector = drawPoints[0].position;
			Vector3 vector2 = drawPoints2[0].position;
			if (flag)
			{
				AddVertToVertexHelperWithLerpColor(vh, vector, vector2, color, toColor, isY, min, max, needTriangle: false, toTop);
			}
			else
			{
				UGL.AddVertToVertexHelper(vh, vector, vector2, color, needTriangle: false);
			}
			int num = 1;
			int num2 = 1;
			bool flag2 = false;
			bool flag3 = false;
			while (num < count || num2 < count2)
			{
				Vector3 vector3 = ((num < count) ? drawPoints[num].position : drawPoints[count - 1].position);
				Vector3 vector4 = ((num2 < count2) ? drawPoints2[num2].position : drawPoints2[count2 - 1].position);
				Vector3 vector5 = ((num + 1 < count) ? drawPoints[num + 1].position : drawPoints[count - 1].position);
				Vector3 vector6 = ((num2 + 1 < count2) ? drawPoints2[num2 + 1].position : drawPoints2[count2 - 1].position);
				if (serie.animation.CheckDetailBreak(vector3, isY))
				{
					flag2 = true;
					float currDetail = serie.animation.GetCurrDetail();
					Vector3 intersection = Vector3.zero;
					vector3 = ((!UGLHelper.GetIntersection(vector, vector3, new Vector3(currDetail, -10000f), new Vector3(currDetail, 10000f), ref intersection)) ? new Vector3(currDetail, vector3.y) : intersection);
				}
				if (serie.animation.CheckDetailBreak(vector4, isY))
				{
					flag3 = true;
					float currDetail2 = serie.animation.GetCurrDetail();
					Vector3 intersection2 = Vector3.zero;
					vector4 = ((!UGLHelper.GetIntersection(vector2, vector4, new Vector3(currDetail2, -10000f), new Vector3(currDetail2, 10000f), ref intersection2)) ? new Vector3(currDetail2, vector4.y) : intersection2);
				}
				if (flag)
				{
					AddVertToVertexHelperWithLerpColor(vh, vector3, vector4, color, toColor, isY, min, max, needTriangle: true, toTop);
				}
				else
				{
					UGL.AddVertToVertexHelper(vh, vector3, vector4, color);
				}
				num++;
				num2++;
				if (vector4.x < vector3.x && vector6.x < vector3.x)
				{
					num--;
				}
				if (vector3.x < vector4.x && vector5.x < vector4.x)
				{
					num2--;
				}
				vector = vector3;
				vector2 = vector4;
				if (flag2 && flag3)
				{
					break;
				}
			}
		}

		private static void AddVertToVertexHelperWithLerpColor(VertexHelper vh, Vector3 tp, Vector3 bp, Color32 color, Color32 toColor, bool isY, float min, float max, bool needTriangle, bool toTop)
		{
			if (toTop)
			{
				float num = max - min;
				Color32 topColor = Color32.Lerp(color, toColor, ((isY ? tp.x : tp.y) - min) / num);
				Color32 bottomColor = Color32.Lerp(color, toColor, ((isY ? bp.x : bp.y) - min) / num);
				UGL.AddVertToVertexHelper(vh, tp, bp, topColor, bottomColor, needTriangle);
			}
			else
			{
				UGL.AddVertToVertexHelper(vh, tp, bp, toColor, color, needTriangle);
			}
		}

		internal static void DrawSerieLine(VertexHelper vh, ThemeStyle theme, Serie serie, VisualMap visualMap, GridCoord grid, Axis axis, Axis relativedAxis, float lineWidth)
		{
			if (!serie.lineStyle.show || serie.lineStyle.type == LineStyle.Type.None)
			{
				return;
			}
			List<PointInfo> drawPoints = serie.context.drawPoints;
			int count = drawPoints.Count;
			if (count < 2)
			{
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
			bool flag = false;
			bool flag2 = axis is YAxis;
			bool visualMapGradient = VisualMapHelper.IsNeedLineGradient(visualMap);
			bool lineStyleGradient = serie.lineStyle.IsNeedGradient();
			Color32 lineColor = SerieHelper.GetLineColor(serie, null, theme, serie.context.colorIndex);
			bool lastIgnore = drawPoints[0].isIgnoreBreak;
			bool flag3 = serie.lineType == LineType.Smooth;
			int num = ((!serie.clip) ? 1 : (-1));
			for (int i = 1; i < count; i++)
			{
				PointInfo pointInfo = drawPoints[i];
				bool flag4 = pointInfo.isIgnoreBreak;
				Vector3 vector = pointInfo.position;
				Vector3 position = drawPoints[i - 1].position;
				Vector3 np = ((i == count - 1) ? vector : drawPoints[i + 1].position);
				if (serie.animation.CheckDetailBreak(vector, flag2))
				{
					flag = true;
					Vector3 ip = Vector3.zero;
					float currDetail = serie.animation.GetCurrDetail();
					if (AnimationStyleHelper.GetAnimationPosition(serie.animation, flag2, position, vector, currDetail, ref ip))
					{
						vector = (np = ip);
					}
				}
				serie.context.lineEndPostion = vector;
				serie.context.lineEndValue = AxisHelper.GetAxisPositionValue(grid, relativedAxis, vector);
				bool flag5 = false;
				bool flag6 = false;
				if (serie.clip)
				{
					if (!grid.Contains(vector))
					{
						flag6 = true;
					}
					else if (num <= 0)
					{
						num = i;
					}
					if (flag6)
					{
						flag4 = true;
					}
				}
				if (!flag3)
				{
					switch (serie.lineStyle.type)
					{
					case LineStyle.Type.Dashed:
						UGL.DrawDashLine(vh, position, vector, lineWidth, lineColor, lineColor);
						flag5 = true;
						break;
					case LineStyle.Type.Dotted:
						UGL.DrawDotLine(vh, position, vector, lineWidth, lineColor, lineColor);
						flag5 = true;
						break;
					case LineStyle.Type.DashDot:
						UGL.DrawDashDotLine(vh, position, vector, lineWidth, lineColor);
						flag5 = true;
						break;
					case LineStyle.Type.DashDotDot:
						UGL.DrawDashDotDotLine(vh, position, vector, lineWidth, lineColor);
						flag5 = true;
						break;
					case LineStyle.Type.None:
						flag5 = true;
						break;
					}
				}
				if (flag5)
				{
					lastIgnore = flag4;
					if (flag)
					{
						break;
					}
					continue;
				}
				bool bitp = true;
				bool bibp = true;
				UGLHelper.GetLinePoints(position, vector, np, lineWidth, ref ltp, ref lbp, ref ntp, ref nbp, ref itp, ref ibp, ref clp, ref crp, ref bitp, ref bibp, i);
				if (i == 1)
				{
					if (flag6)
					{
						lastIgnore = true;
					}
					AddLineVertToVertexHelper(vh, ltp, lbp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: false, lastIgnore, flag4);
					if (count == 2 || flag)
					{
						AddLineVertToVertexHelper(vh, clp, crp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
						serie.context.lineEndPostion = vector;
						serie.context.lineEndValue = AxisHelper.GetAxisPositionValue(grid, relativedAxis, vector);
						break;
					}
				}
				if (bitp == bibp)
				{
					if (bitp)
					{
						AddLineVertToVertexHelper(vh, itp, ibp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
					}
					else
					{
						AddLineVertToVertexHelper(vh, ltp, clp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
						AddLineVertToVertexHelper(vh, ltp, crp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
					}
				}
				else if (bitp)
				{
					AddLineVertToVertexHelper(vh, itp, clp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
					AddLineVertToVertexHelper(vh, itp, crp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
				}
				else if (bibp)
				{
					AddLineVertToVertexHelper(vh, clp, ibp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
					AddLineVertToVertexHelper(vh, crp, ibp, lineColor, visualMapGradient, lineStyleGradient, visualMap, serie.lineStyle, grid, axis, relativedAxis, needTriangle: true, lastIgnore, flag4);
				}
				lastIgnore = flag4;
				if (flag)
				{
					break;
				}
			}
		}

		public static float GetLineWidth(ref bool interacting, Serie serie, float defaultWidth)
		{
			float value = 0f;
			if (!serie.interact.TryGetValue(ref value, ref interacting, serie.animation.GetInteractionDuration()))
			{
				value = serie.lineStyle.GetWidth(defaultWidth);
				serie.interact.SetValue(ref interacting, value);
			}
			return value;
		}

		private static void AddLineVertToVertexHelper(VertexHelper vh, Vector3 tp, Vector3 bp, Color32 lineColor, bool visualMapGradient, bool lineStyleGradient, VisualMap visualMap, LineStyle lineStyle, GridCoord grid, Axis axis, Axis relativedAxis, bool needTriangle, bool lastIgnore, bool ignore)
		{
			if (lastIgnore && needTriangle)
			{
				UGL.AddVertToVertexHelper(vh, tp, bp, ColorUtil.clearColor32);
			}
			if (visualMapGradient)
			{
				Color32 lineGradientColor = VisualMapHelper.GetLineGradientColor(visualMap, tp, grid, axis, relativedAxis, lineColor);
				Color32 lineGradientColor2 = VisualMapHelper.GetLineGradientColor(visualMap, bp, grid, axis, relativedAxis, lineColor);
				UGL.AddVertToVertexHelper(vh, tp, bp, lineGradientColor, lineGradientColor2, needTriangle);
			}
			else if (lineStyleGradient)
			{
				Color32 lineStyleGradientColor = VisualMapHelper.GetLineStyleGradientColor(lineStyle, tp, grid, axis, lineColor);
				Color32 lineStyleGradientColor2 = VisualMapHelper.GetLineStyleGradientColor(lineStyle, bp, grid, axis, lineColor);
				UGL.AddVertToVertexHelper(vh, tp, bp, lineStyleGradientColor, lineStyleGradientColor2, needTriangle);
			}
			else
			{
				UGL.AddVertToVertexHelper(vh, tp, bp, lineColor, needTriangle);
			}
			if (lastIgnore && !needTriangle)
			{
				UGL.AddVertToVertexHelper(vh, tp, bp, ColorUtil.clearColor32, needTriangle: false);
			}
			if (ignore && needTriangle)
			{
				UGL.AddVertToVertexHelper(vh, tp, bp, ColorUtil.clearColor32, needTriangle: false);
			}
		}

		internal static void UpdateSerieDrawPoints(Serie serie, Settings setting, ThemeStyle theme, VisualMap visualMap, float lineWidth, bool isY = false)
		{
			serie.context.drawPoints.Clear();
			_ = Vector3.zero;
			switch (serie.lineType)
			{
			case LineType.Smooth:
				UpdateSmoothLineDrawPoints(serie, setting, isY);
				break;
			case LineType.StepStart:
			case LineType.StepMiddle:
			case LineType.StepEnd:
				UpdateStepLineDrawPoints(serie, setting, theme, isY, lineWidth);
				break;
			default:
				UpdateNormalLineDrawPoints(serie, setting, visualMap);
				break;
			}
		}

		private static void UpdateNormalLineDrawPoints(Serie serie, Settings setting, VisualMap visualMap)
		{
			if (VisualMapHelper.IsNeedGradient(visualMap) || serie.clip)
			{
				List<Vector3> dataPoints = serie.context.dataPoints;
				if (dataPoints.Count > 1)
				{
					Vector3 vector = dataPoints[0];
					for (int i = 1; i < dataPoints.Count; i++)
					{
						Vector3 vector2 = dataPoints[i];
						bool ignore = serie.context.dataIgnores[i];
						Vector3 normalized = (vector2 - vector).normalized;
						float num = Vector3.Distance(vector, vector2);
						int num2 = (int)(num / setting.lineSegmentDistance);
						serie.context.drawPoints.Add(new PointInfo(vector, ignore));
						for (int j = 1; j < num2; j++)
						{
							Vector3 pos = vector + normalized * num * j / num2;
							serie.context.drawPoints.Add(new PointInfo(pos, ignore));
						}
						vector = vector2;
						if (i == dataPoints.Count - 1)
						{
							serie.context.drawPoints.Add(new PointInfo(vector2, ignore));
						}
					}
				}
				else
				{
					serie.context.drawPoints.Add(new PointInfo(dataPoints[0], serie.context.dataIgnores[0]));
				}
			}
			else
			{
				for (int k = 0; k < serie.context.dataPoints.Count; k++)
				{
					serie.context.drawPoints.Add(new PointInfo(serie.context.dataPoints[k], serie.context.dataIgnores[k]));
				}
			}
		}

		private static void UpdateSmoothLineDrawPoints(Serie serie, Settings setting, bool isY)
		{
			List<Vector3> dataPoints = serie.context.dataPoints;
			float lineSmoothness = setting.lineSmoothness;
			for (int i = 0; i < dataPoints.Count - 1; i++)
			{
				Vector3 vector = dataPoints[i];
				Vector3 vector2 = dataPoints[i + 1];
				Vector3 lsp = ((i > 0) ? dataPoints[i - 1] : vector);
				Vector3 nep = ((i < dataPoints.Count - 2) ? dataPoints[i + 2] : vector2);
				bool ignore = serie.context.dataIgnores[i];
				if (isY)
				{
					UGLHelper.GetBezierListVertical(ref s_CurvesPosList, vector, vector2, lineSmoothness, setting.lineSmoothStyle);
				}
				else
				{
					UGLHelper.GetBezierList(ref s_CurvesPosList, vector, vector2, lsp, nep, lineSmoothness, setting.lineSmoothStyle, serie.smoothLimit);
				}
				for (int j = 1; j < s_CurvesPosList.Count; j++)
				{
					serie.context.drawPoints.Add(new PointInfo(s_CurvesPosList[j], ignore));
				}
			}
		}

		private static void UpdateStepLineDrawPoints(Serie serie, Settings setting, ThemeStyle theme, bool isY, float lineWidth)
		{
			List<Vector3> dataPoints = serie.context.dataPoints;
			Vector3 pos = dataPoints[0];
			serie.context.drawPoints.Clear();
			serie.context.drawPoints.Add(new PointInfo(pos, serie.context.dataIgnores[0]));
			for (int i = 1; i < dataPoints.Count; i++)
			{
				Vector3 vector = dataPoints[i];
				bool ignore = serie.context.dataIgnores[i];
				if ((isY && Mathf.Abs(pos.x - vector.x) <= lineWidth) || (!isY && Mathf.Abs(pos.y - vector.y) <= lineWidth))
				{
					serie.context.drawPoints.Add(new PointInfo(vector, ignore));
					pos = vector;
					continue;
				}
				switch (serie.lineType)
				{
				case LineType.StepStart:
					serie.context.drawPoints.Add(new PointInfo(isY ? new Vector3(vector.x, pos.y) : new Vector3(pos.x, vector.y), ignore));
					break;
				case LineType.StepMiddle:
					serie.context.drawPoints.Add(new PointInfo(isY ? new Vector3(pos.x, (pos.y + vector.y) / 2f) : new Vector3((pos.x + vector.x) / 2f, pos.y), ignore));
					serie.context.drawPoints.Add(new PointInfo(isY ? new Vector3(vector.x, (pos.y + vector.y) / 2f) : new Vector3((pos.x + vector.x) / 2f, vector.y), ignore));
					break;
				case LineType.StepEnd:
					serie.context.drawPoints.Add(new PointInfo(isY ? new Vector3(pos.x, vector.y) : new Vector3(vector.x, pos.y), ignore));
					break;
				}
				serie.context.drawPoints.Add(new PointInfo(vector, ignore));
				pos = vector;
			}
		}
	}
}
