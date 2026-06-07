using System.Text;
using UnityEngine;

namespace Mystery.Graphing
{
	public class GraphPointSample
	{
		public IPlottableGraph Graph;

		public object ValueX;

		public object ValueY;

		public string TextValue;

		public Color32 Color;

		public string Label;

		public GraphPointSample(IPlottableGraph graph, object valueX, object valueY, string value, Color32 color, string label = null)
		{
			Graph = graph;
			ValueX = valueX;
			ValueY = valueY;
			TextValue = value;
			Color = color;
			Label = label;
		}

		public int Append(StringBuilder sb)
		{
			return Append(sb, TextValue, Color, Label);
		}

		public static int Append(StringBuilder sb, string value, Color32 color, string label = null)
		{
			int num = value.Length;
			sb.Append("<color=#");
			sb.Append(color.r.ToString("X2").ToLower());
			sb.Append(color.g.ToString("X2").ToLower());
			sb.Append(color.b.ToString("X2").ToLower());
			sb.Append(">");
			if (label != null)
			{
				sb.Append(label);
				sb.Append(": ");
				num += label.Length + 2;
			}
			sb.Append(value);
			sb.Append("</color>");
			return num;
		}
	}
}
