using UnityEngine;

namespace XCharts.Runtime
{
	internal static class MarkLineHelper
	{
		public static string GetFormatterContent(Serie serie, MarkLineData data)
		{
			LabelStyle label = data.label;
			string numericFormatter = label.numericFormatter;
			if (string.IsNullOrEmpty(label.formatter))
			{
				string text = ChartCached.NumberToStr(data.runtimeValue, numericFormatter);
				if (label.formatterFunction != null)
				{
					return label.formatterFunction(data.index, data.runtimeValue, null, text);
				}
				return text;
			}
			string content = label.formatter;
			FormatterHelper.ReplaceSerieLabelContent(ref content, numericFormatter, serie.dataCount, data.runtimeValue, 0.0, serie.serieName, data.name, data.name, Color.clear, null);
			if (label.formatterFunction != null)
			{
				return label.formatterFunction(data.index, data.runtimeValue, null, content);
			}
			return content;
		}

		public static Vector3 GetLabelPosition(MarkLineData data)
		{
			if (!data.label.show)
			{
				return Vector3.zero;
			}
			bool flag = Mathf.Abs(Vector3.Dot((data.runtimeEndPosition - data.runtimeStartPosition).normalized, Vector3.right)) == 1f;
			float num = ((data.runtimeLabel == null) ? 50f : data.runtimeLabel.GetTextWidth());
			float num2 = ((data.runtimeLabel == null) ? 20f : data.runtimeLabel.GetTextHeight());
			switch (data.label.position)
			{
			case LabelStyle.Position.Start:
				if (data.runtimeStartPosition == Vector3.zero)
				{
					return Vector3.zero;
				}
				if (flag)
				{
					return data.runtimeStartPosition + data.label.offset + num / 2f * Vector3.left;
				}
				return data.runtimeStartPosition + data.label.offset + num2 / 2f * Vector3.down;
			case LabelStyle.Position.Middle:
			{
				if (data.runtimeCurrentEndPosition == Vector3.zero)
				{
					return Vector3.zero;
				}
				Vector3 vector = (data.runtimeStartPosition + data.runtimeCurrentEndPosition) / 2f;
				if (flag)
				{
					return vector + data.label.offset + num2 / 2f * Vector3.up;
				}
				return vector + data.label.offset + num / 2f * Vector3.right;
			}
			default:
				if (data.runtimeCurrentEndPosition == Vector3.zero)
				{
					return Vector3.zero;
				}
				if (flag)
				{
					return data.runtimeCurrentEndPosition + data.label.offset + num / 2f * Vector3.right;
				}
				return data.runtimeCurrentEndPosition + data.label.offset + num2 / 2f * Vector3.up;
			}
		}
	}
}
