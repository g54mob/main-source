using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class FormatterHelper
	{
		public const string PH_NN = "\n";

		private static Regex s_Regex = new Regex("{([a-h|.]\\d*)(:\\d+(-\\d+)?)?(:[c-g|x|p|r]\\d*|:0\\.#*)?}", RegexOptions.IgnoreCase);

		private static Regex s_RegexSub = new Regex("(0\\.#*)|(\\d+-\\d+)|(\\w+)|(\\.)", RegexOptions.IgnoreCase);

		private static Regex s_RegexN = new Regex("^\\d+", RegexOptions.IgnoreCase);

		private static Regex s_RegexN_N = new Regex("\\d+-\\d+", RegexOptions.IgnoreCase);

		private static Regex s_RegexFn = new Regex("[c-g|x|p|r]\\d*|0\\.#*", RegexOptions.IgnoreCase);

		private static Regex s_RegexNewLine = new Regex("[\\\\|/]+n|</br>|<br>|<br/>", RegexOptions.IgnoreCase);

		private static Regex s_RegexForAxisLabel = new Regex("{value(:[c-g|x|p|r]\\d*)?}", RegexOptions.IgnoreCase);

		private static Regex s_RegexSubForAxisLabel = new Regex("(value)|([c-g|x|p|r]\\d*)", RegexOptions.IgnoreCase);

		private static Regex s_RegexForSerieLabel = new Regex("{[a-h|\\.]\\d*(:[c-g|x|p|r]\\d*)?}", RegexOptions.IgnoreCase);

		private static Regex s_RegexSubForSerieLabel = new Regex("(\\.)|([a-h]\\d*)|([c-g|x|p|r]\\d*)", RegexOptions.IgnoreCase);

		public static bool NeedFormat(string content)
		{
			return content.IndexOf('{') >= 0;
		}

		public static bool ReplaceContent(ref string content, int dataIndex, string numericFormatter, Serie serie, BaseChart chart, string colorName = null)
		{
			bool result = false;
			foreach (object item in s_Regex.Matches(content))
			{
				string oldValue = item.ToString();
				MatchCollection matchCollection = s_RegexSub.Matches(item.ToString());
				int count = matchCollection.Count;
				if (count <= 0)
				{
					continue;
				}
				int index = 0;
				char serieIndex = GetSerieIndex(matchCollection[0].ToString(), ref index);
				if (index >= 0)
				{
					serie = chart.GetSerie(index);
					if (serie == null)
					{
						continue;
					}
				}
				else if (serie != null)
				{
					index = serie.index;
				}
				else
				{
					serie = chart.GetSerie(0);
					index = 0;
				}
				if (serie == null)
				{
					continue;
				}
				switch (serieIndex)
				{
				case '.':
				case 'H':
				case 'h':
				{
					int index3 = dataIndex;
					if (count >= 2)
					{
						string text2 = matchCollection[1].ToString();
						if (s_RegexN.IsMatch(text2))
						{
							index3 = int.Parse(text2);
						}
					}
					Color color = (string.IsNullOrEmpty(colorName) ? ((Color)chart.GetMarkColor(serie, serie.GetSerieData(index3))) : SeriesHelper.GetNameColor(chart, index3, colorName));
					if (serieIndex == '.')
					{
						content = content.Replace(oldValue, ChartCached.ColorToDotStr(color));
						result = true;
					}
					else
					{
						content = content.Replace(oldValue, "#" + ChartCached.ColorToStr(color));
					}
					continue;
				}
				case 'A':
				case 'a':
					if (count == 1)
					{
						content = content.Replace(oldValue, serie.serieName);
					}
					continue;
				case 'B':
				case 'E':
				case 'b':
				case 'e':
				{
					int index2 = dataIndex;
					if (count >= 2)
					{
						string text = matchCollection[1].ToString();
						if (s_RegexN.IsMatch(text))
						{
							index2 = int.Parse(text);
						}
					}
					if (serieIndex != 'e' && serieIndex != 'E' && serie.defaultColorBy != SerieColorBy.Data)
					{
						string tooltipCategory = chart.GetTooltipCategory(dataIndex, serie);
						content = content.Replace(oldValue, tooltipCategory);
					}
					else
					{
						SerieData serieData = serie.GetSerieData(index2);
						content = content.Replace(oldValue, serieData.name);
					}
					continue;
				}
				case 'G':
				case 'g':
					content = content.Replace(oldValue, ChartCached.NumberToStr(serie.dataCount, ""));
					continue;
				default:
					if (serieIndex != 'f')
					{
						continue;
					}
					break;
				case 'C':
				case 'D':
				case 'c':
				case 'd':
				case 'f':
					break;
				}
				bool flag = serieIndex == 'd' || serieIndex == 'D';
				bool flag2 = serieIndex == 'f' || serieIndex == 'f';
				int index4 = dataIndex;
				int num = -1;
				if (count >= 2)
				{
					string text3 = matchCollection[1].ToString();
					if (s_RegexFn.IsMatch(text3))
					{
						numericFormatter = text3;
					}
					else if (s_RegexN_N.IsMatch(text3))
					{
						string[] array = text3.Split('-');
						index4 = int.Parse(array[0]);
						num = int.Parse(array[1]);
					}
					else
					{
						if (!s_RegexN.IsMatch(text3))
						{
							Debug.LogError("unmatch:" + text3);
							continue;
						}
						num = int.Parse(text3);
					}
				}
				if (count >= 3)
				{
					numericFormatter = matchCollection[2].ToString();
				}
				if (num == -1)
				{
					num = 1;
				}
				if (numericFormatter == string.Empty)
				{
					numericFormatter = SerieHelper.GetNumericFormatter(serie, serie.GetSerieData(index4), "");
				}
				double data = serie.GetData(index4, num);
				if (flag)
				{
					double value = ((serie.GetDataTotal(num, serie.GetSerieData(index4)) == 0.0) ? 0.0 : (data / serie.yTotal * 100.0));
					content = content.Replace(oldValue, ChartCached.FloatToStr(value, numericFormatter));
				}
				else if (flag2)
				{
					double dataTotal = serie.GetDataTotal(num, serie.GetSerieData(index4));
					content = content.Replace(oldValue, ChartCached.FloatToStr(dataTotal, numericFormatter));
				}
				else
				{
					content = content.Replace(oldValue, ChartCached.FloatToStr(data, numericFormatter));
				}
			}
			content = s_RegexNewLine.Replace(content, "\n");
			return result;
		}

		public static void ReplaceSerieLabelContent(ref string content, string numericFormatter, int dataCount, double value, double total, string serieName, string category, string dataName, Color color, SerieData serieData)
		{
			foreach (object item in s_RegexForSerieLabel.Matches(content))
			{
				string text = item.ToString();
				MatchCollection matchCollection = s_RegexSubForSerieLabel.Matches(text);
				int count = matchCollection.Count;
				if (count <= 0)
				{
					continue;
				}
				string text2 = matchCollection[0].ToString();
				char c = text2.ElementAt(0);
				int result = -1;
				if (text2.Length > 1)
				{
					int.TryParse(text2.Substring(1, text2.Length - 1), out result);
				}
				if (count >= 2)
				{
					numericFormatter = matchCollection[1].ToString();
				}
				switch (c)
				{
				case '.':
					content = content.Replace(text, ChartCached.ColorToDotStr(color));
					continue;
				case 'A':
				case 'a':
					content = content.Replace(text, serieName);
					continue;
				case 'B':
				case 'b':
					content = content.Replace(text, category);
					continue;
				case 'E':
				case 'e':
					content = content.Replace(text, dataName);
					continue;
				case 'D':
				case 'd':
				{
					double value2 = ((result < 0 || serieData == null) ? ((total == 0.0) ? 0.0 : (value / total * 100.0)) : ((value == 0.0) ? 0.0 : (serieData.GetData(result) / value * 100.0)));
					content = content.Replace(text, ChartCached.NumberToStr(value2, numericFormatter));
					continue;
				}
				case 'C':
				case 'c':
					if (result >= 0 && serieData != null)
					{
						content = content.Replace(text, ChartCached.NumberToStr(serieData.GetData(result), numericFormatter));
					}
					else
					{
						content = content.Replace(text, ChartCached.NumberToStr(value, numericFormatter));
					}
					continue;
				default:
					switch (c)
					{
					case 'f':
						break;
					case 'G':
					case 'g':
						content = content.Replace(text, ChartCached.NumberToStr(dataCount, numericFormatter));
						continue;
					case 'H':
					case 'h':
						content = content.Replace(text, "#" + ChartCached.ColorToStr(color));
						continue;
					default:
						continue;
					}
					break;
				case 'f':
					break;
				}
				content = content.Replace(text, ChartCached.NumberToStr(total, numericFormatter));
			}
			content = TrimAndReplaceLine(content);
		}

		private static char GetSerieIndex(string strType, ref int index)
		{
			index = -1;
			if (strType.Length > 1 && !int.TryParse(strType.Substring(1), out index))
			{
				index = -1;
			}
			return strType.ElementAt(0);
		}

		public static string TrimAndReplaceLine(StringBuilder sb)
		{
			return TrimAndReplaceLine(sb.ToString());
		}

		public static string TrimAndReplaceLine(string content)
		{
			return s_RegexNewLine.Replace(content.Trim(), "\n");
		}

		public static void ReplaceAxisLabelContent(ref string content, string numericFormatter, double value)
		{
			foreach (object item in s_RegexForAxisLabel.Matches(content))
			{
				string oldValue = item.ToString();
				MatchCollection matchCollection = s_RegexSubForAxisLabel.Matches(item.ToString());
				int count = matchCollection.Count;
				if (count > 0)
				{
					if (count >= 2)
					{
						numericFormatter = matchCollection[1].ToString();
					}
					content = content.Replace(oldValue, ChartCached.FloatToStr(value, numericFormatter));
				}
			}
			content = TrimAndReplaceLine(content);
		}

		public static void ReplaceAxisLabelContent(ref string content, string value)
		{
			foreach (object item in s_RegexForAxisLabel.Matches(content))
			{
				string oldValue = item.ToString();
				if (s_RegexSubForAxisLabel.Matches(item.ToString()).Count > 0)
				{
					content = content.Replace(oldValue, value);
				}
			}
			content = TrimAndReplaceLine(content);
		}
	}
}
