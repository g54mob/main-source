using UnityEngine;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	public static class ChartDrawer
	{
		public static void DrawSymbol(VertexHelper vh, SymbolType type, float symbolSize, float tickness, Vector3 pos, Color32 color, Color32 toColor, float gap, float[] cornerRadius, Color32 emptyColor, Color32 backgroundColor, Color32 borderColor, float smoothness, Vector3 startPos)
		{
			switch (type)
			{
			case SymbolType.Circle:
				if (gap > 0f)
				{
					UGL.DrawDoughnut(vh, pos, symbolSize, symbolSize + gap, backgroundColor, backgroundColor, color, smoothness);
				}
				else if (tickness > 0f)
				{
					UGL.DrawDoughnut(vh, pos, symbolSize, symbolSize + tickness, borderColor, borderColor, color, smoothness);
				}
				else
				{
					UGL.DrawCricle(vh, pos, symbolSize, color, toColor, smoothness);
				}
				break;
			case SymbolType.EmptyCircle:
				if (gap > 0f)
				{
					UGL.DrawCricle(vh, pos, symbolSize + gap, backgroundColor, smoothness);
					UGL.DrawEmptyCricle(vh, pos, symbolSize, tickness, color, color, emptyColor, smoothness);
				}
				else
				{
					UGL.DrawEmptyCricle(vh, pos, symbolSize, tickness, color, color, emptyColor, smoothness);
				}
				break;
			case SymbolType.Rect:
				if (gap > 0f)
				{
					UGL.DrawSquare(vh, pos, symbolSize + gap, backgroundColor);
					UGL.DrawSquare(vh, pos, symbolSize, color, toColor);
				}
				else if (tickness > 0f)
				{
					UGL.DrawRoundRectangle(vh, pos, symbolSize * 2f, symbolSize * 2f, color, color, 0f, cornerRadius, horizontal: true);
					UGL.DrawBorder(vh, pos, symbolSize, symbolSize, tickness, borderColor, 0f, cornerRadius);
				}
				else
				{
					UGL.DrawRoundRectangle(vh, pos, symbolSize * 2f, symbolSize * 2f, color, color, 0f, cornerRadius, horizontal: true);
				}
				break;
			case SymbolType.EmptyRect:
				if (gap > 0f)
				{
					UGL.DrawSquare(vh, pos, symbolSize + gap, backgroundColor);
					UGL.DrawBorder(vh, pos, symbolSize * 2f, symbolSize * 2f, tickness, color);
				}
				else
				{
					UGL.DrawBorder(vh, pos, symbolSize * 2f - tickness * 2f, symbolSize * 2f - tickness * 2f, tickness, color);
				}
				break;
			case SymbolType.Triangle:
			case SymbolType.EmptyTriangle:
				if (gap > 0f)
				{
					UGL.DrawEmptyTriangle(vh, pos, symbolSize * 1.4f + gap * 2f, gap * 2f, backgroundColor);
				}
				if (type == SymbolType.EmptyTriangle)
				{
					UGL.DrawEmptyTriangle(vh, pos, symbolSize * 1.4f, tickness * 2f, color, emptyColor);
				}
				else
				{
					UGL.DrawTriangle(vh, pos, symbolSize * 1.4f, color, toColor);
				}
				break;
			case SymbolType.Diamond:
			case SymbolType.EmptyDiamond:
			{
				float num = symbolSize * 1.5f;
				if (gap > 0f)
				{
					UGL.DrawEmptyDiamond(vh, pos, symbolSize + gap, num + gap, gap, backgroundColor);
				}
				if (type == SymbolType.EmptyDiamond)
				{
					UGL.DrawEmptyDiamond(vh, pos, symbolSize, num, tickness, color, emptyColor);
				}
				else
				{
					UGL.DrawDiamond(vh, pos, symbolSize, num, color, toColor);
				}
				break;
			}
			case SymbolType.Arrow:
			case SymbolType.EmptyArrow:
			{
				float num2 = symbolSize * 2f;
				float num3 = num2 * 1.5f;
				int num4 = 0;
				float num5 = num2 / 3.3f;
				if (gap > 0f)
				{
					num2 = (symbolSize + gap) * 2f;
					num3 = num2 * 1.5f;
					num4 = 0;
					num5 = num2 / 3.3f;
					Vector3 normalized = (pos - startPos).normalized;
					Vector3 arrowPoint = pos + gap * normalized;
					UGL.DrawArrow(vh, startPos, arrowPoint, num2, num3, num4, num5, backgroundColor);
				}
				num2 = symbolSize * 2f;
				num3 = num2 * 1.5f;
				num4 = 0;
				num5 = num2 / 3.3f;
				UGL.DrawArrow(vh, startPos, pos, num2, num3, num4, num5, color);
				if (type == SymbolType.EmptyArrow)
				{
					num2 = (symbolSize - tickness) * 2f;
					num3 = num2 * 1.5f;
					num4 = 0;
					num5 = num2 / 3.3f;
					Vector3 normalized2 = (pos - startPos).normalized;
					Vector3 arrowPoint2 = pos - tickness * normalized2;
					UGL.DrawArrow(vh, startPos, arrowPoint2, num2, num3, num4, num5, backgroundColor);
				}
				break;
			}
			case SymbolType.Plus:
				if (gap > 0f)
				{
					UGL.DrawPlus(vh, pos, symbolSize + gap, tickness + gap, backgroundColor);
				}
				UGL.DrawPlus(vh, pos, symbolSize, tickness, color);
				break;
			case SymbolType.Minus:
				if (gap > 0f)
				{
					UGL.DrawMinus(vh, pos, symbolSize + gap, tickness + gap, backgroundColor);
				}
				UGL.DrawMinus(vh, pos, symbolSize, tickness, color);
				break;
			case SymbolType.None:
			case SymbolType.Custom:
				break;
			}
		}

		public static void DrawLineStyle(VertexHelper vh, LineStyle lineStyle, Vector3 startPos, Vector3 endPos, Color32 defaultColor, float themeWidth, LineStyle.Type themeType)
		{
			LineStyle.Type type = lineStyle.GetType(themeType);
			float width = lineStyle.GetWidth(themeWidth);
			Color32 color = lineStyle.GetColor(defaultColor);
			DrawLineStyle(vh, type, width, startPos, endPos, color, color);
		}

		public static void DrawLineStyle(VertexHelper vh, LineStyle lineStyle, Vector3 startPos, Vector3 endPos, float themeWidth, LineStyle.Type themeType, Color32 defaultColor, Color32 defaultToColor)
		{
			LineStyle.Type type = lineStyle.GetType(themeType);
			float width = lineStyle.GetWidth(themeWidth);
			Color32 color = lineStyle.GetColor(defaultColor);
			Color32 toColor = (ChartHelper.IsClearColor(defaultToColor) ? color : defaultToColor);
			DrawLineStyle(vh, type, width, startPos, endPos, color, toColor);
		}

		public static void DrawLineStyle(VertexHelper vh, LineStyle.Type lineType, float lineWidth, Vector3 startPos, Vector3 endPos, Color32 color)
		{
			DrawLineStyle(vh, lineType, lineWidth, startPos, endPos, color, color);
		}

		public static void DrawLineStyle(VertexHelper vh, LineStyle.Type lineType, float lineWidth, Vector3 startPos, Vector3 endPos, Color32 color, Color32 toColor)
		{
			switch (lineType)
			{
			case LineStyle.Type.Dashed:
				UGL.DrawDashLine(vh, startPos, endPos, lineWidth, color, toColor);
				break;
			case LineStyle.Type.Dotted:
				UGL.DrawDotLine(vh, startPos, endPos, lineWidth, color, toColor);
				break;
			case LineStyle.Type.Solid:
				UGL.DrawLine(vh, startPos, endPos, lineWidth, color, toColor);
				break;
			case LineStyle.Type.DashDot:
				UGL.DrawDashDotLine(vh, startPos, endPos, lineWidth, color);
				break;
			case LineStyle.Type.DashDotDot:
				UGL.DrawDashDotDotLine(vh, startPos, endPos, lineWidth, color);
				break;
			}
		}
	}
}
