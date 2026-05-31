using UnityEngine;

namespace XCharts.Runtime
{
	public static class SerieLabelHelper
	{
		public static Color GetLabelColor(Serie serie, ThemeStyle theme, int index)
		{
			if (serie.label != null && !ChartHelper.IsClearColor(serie.label.textStyle.color))
			{
				return serie.label.textStyle.color;
			}
			return theme.GetColor(index);
		}

		public static bool CanShowLabel(Serie serie, SerieData serieData, LabelStyle label, int dimesion)
		{
			if (serie.show && serieData.context.canShowLabel)
			{
				return !serie.IsIgnoreValue(serieData, dimesion);
			}
			return false;
		}

		public static string GetFormatterContent(Serie serie, SerieData serieData, double dataValue, double dataTotal, LabelStyle serieLabel, Color color)
		{
			if (serieLabel == null)
			{
				serieLabel = SerieHelper.GetSerieLabel(serie, serieData);
			}
			string text = ((serieLabel == null) ? "" : serieLabel.numericFormatter);
			string serieName = serie.serieName;
			string text2 = serieData?.name;
			if (string.IsNullOrEmpty(serieLabel.formatter))
			{
				string text3 = ChartCached.NumberToStr(dataValue, text);
				if (serieLabel.formatterFunction == null)
				{
					return text3;
				}
				return serieLabel.formatterFunction(serieData.index, dataValue, null, text3);
			}
			string content = serieLabel.formatter;
			FormatterHelper.ReplaceSerieLabelContent(ref content, text, serie.dataCount, dataValue, dataTotal, serieName, text2, text2, color, serieData);
			if (serieLabel.formatterFunction == null)
			{
				return content;
			}
			return serieLabel.formatterFunction(serieData.index, dataValue, null, content);
		}

		public static void SetGaugeLabelText(Serie serie)
		{
			SerieData serieData = serie.GetSerieData(0);
			if (serieData == null || serieData.labelObject == null)
			{
				return;
			}
			LabelStyle serieLabel = SerieHelper.GetSerieLabel(serie, serieData);
			if (serieLabel != null)
			{
				double data = serieData.GetData(1);
				float max = serie.max;
				string formatterContent = GetFormatterContent(serie, serieData, data, max, null, Color.clear);
				serieData.labelObject.SetText(formatterContent);
				serieData.labelObject.SetPosition(serie.context.center + serieLabel.offset);
				if (!ChartHelper.IsClearColor(serieLabel.textStyle.color))
				{
					serieData.labelObject.text.SetColor(serieLabel.textStyle.color);
				}
			}
		}
	}
}
