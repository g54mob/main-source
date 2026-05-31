using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class LegendHandler : MainComponentHandler<Legend>
	{
		private static readonly string s_LegendObjectName = "legend";

		private static readonly char[] s_NameSplit = new char[1] { '_' };

		public override void InitComponent()
		{
			InitLegend(base.component);
		}

		public override void CheckComponent(StringBuilder sb)
		{
			Legend legend = base.component;
			if (ChartHelper.IsColorAlphaZero(legend.labelStyle.textStyle.color))
			{
				sb.AppendFormat("warning:legend{0}->textStyle->color alpha is 0\n", legend.index);
			}
			List<string> legalSerieNameList = SeriesHelper.GetLegalSerieNameList(base.chart.series);
			if (legalSerieNameList.Count == 0)
			{
				sb.AppendFormat("warning:legend{0} need serie.serieName or serieData.name not empty\n", legend.index);
			}
			foreach (string datum in legend.data)
			{
				if (!legalSerieNameList.Contains(datum))
				{
					sb.AppendFormat("warning:legend{0} [{1}] is invalid, must be one of serie.serieName or serieData.name\n", legend.index, datum);
				}
			}
		}

		public override void DrawTop(VertexHelper vh)
		{
			DrawLegend(vh);
		}

		public override void OnSerieDataUpdate(int serieIndex)
		{
			if (FormatterHelper.NeedFormat(base.component.formatter))
			{
				base.component.refreshComponent();
			}
		}

		private void InitLegend(Legend legend)
		{
			legend.painter = null;
			legend.refreshComponent = delegate
			{
				legend.OnChanged();
				GameObject gameObject = ChartHelper.AddObject(s_LegendObjectName + legend.index, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				legend.gameObject = gameObject;
				gameObject.hideFlags = base.chart.chartHideFlags;
				SeriesHelper.UpdateSerieNameList(base.chart, ref base.chart.m_LegendRealShowName);
				legend.context.background = ChartHelper.AddIcon("background", gameObject.transform, 0f, 0f);
				legend.context.background.transform.SetSiblingIndex(0);
				ChartHelper.SetBackground(legend.context.background, legend.background);
				List<string> list;
				if (legend.show && legend.data.Count > 0)
				{
					list = new List<string>();
					foreach (string datum in legend.data)
					{
						if (base.chart.m_LegendRealShowName.Contains(datum) || base.chart.IsSerieName(datum))
						{
							list.Add(datum);
						}
					}
				}
				else
				{
					list = base.chart.m_LegendRealShowName;
				}
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					if (SeriesHelper.IsLegalLegendName(list[i]))
					{
						num++;
					}
				}
				legend.RemoveButton();
				ChartHelper.HideAllObject(gameObject);
				if (legend.show)
				{
					for (int j = 0; j < list.Count; j++)
					{
						if (SeriesHelper.IsLegalLegendName(list[j]))
						{
							string name = list[j];
							string formatterContent = GetFormatterContent(legend, j, list[j]);
							int num2 = base.chart.m_LegendRealShowName.IndexOf(list[j]);
							bool active = base.chart.IsActiveByLegend(list[j]);
							Color iconColor = LegendHelper.GetIconColor(base.chart, legend, num2, list[j], active);
							iconColor.a = legend.itemOpacity;
							LegendItem item = LegendHelper.AddLegendItem(base.chart, legend, j, list[j], gameObject.transform, base.chart.theme, formatterContent, iconColor, active, num2);
							legend.SetButton(name, item, num);
							ChartHelper.ClearEventListener(item.button.gameObject);
							ChartHelper.AddEventListener(item.button.gameObject, EventTriggerType.PointerDown, delegate(BaseEventData data)
							{
								if (!(data.selectedObject == null) && legend.selectedMode != Legend.SelectedMode.None)
								{
									string[] array = data.selectedObject.name.Split(s_NameSplit, 2);
									string legendName = array[1];
									int num3 = int.Parse(array[0]);
									if (legend.selectedMode == Legend.SelectedMode.Multiple)
									{
										OnLegendButtonClick(legend, num3, legendName, !base.chart.IsActiveByLegend(legendName));
									}
									else
									{
										LegendItem[] array2 = legend.context.buttonList.Values.ToArray();
										if (array2.Length == 1)
										{
											OnLegendButtonClick(legend, 0, legendName, !base.chart.IsActiveByLegend(legendName));
										}
										else
										{
											for (int k = 0; k < array2.Length; k++)
											{
												array2[k].name.Split(s_NameSplit, 2);
												legendName = array2[k].legendName;
												int index = array2[k].index;
												OnLegendButtonClick(legend, k, legendName, (index == num3) ? true : false);
											}
										}
									}
								}
							});
							ChartHelper.AddEventListener(item.button.gameObject, EventTriggerType.PointerEnter, delegate
							{
								if (!(item.button == null))
								{
									string[] array = item.button.name.Split(s_NameSplit, 2);
									string legendName = array[1];
									int index = int.Parse(array[0]);
									OnLegendButtonEnter(legend, index, legendName);
								}
							});
							ChartHelper.AddEventListener(item.button.gameObject, EventTriggerType.PointerExit, delegate
							{
								if (!(item.button == null))
								{
									string[] array = item.button.name.Split(s_NameSplit, 2);
									string legendName = array[1];
									int index = int.Parse(array[0]);
									OnLegendButtonExit(legend, index, legendName);
								}
							});
						}
					}
					LegendHelper.ResetItemPosition(legend, base.chart.chartPosition, base.chart.chartWidth, base.chart.chartHeight);
				}
			};
			legend.refreshComponent();
		}

		private string GetFormatterContent(Legend legend, int dataIndex, string category)
		{
			if (string.IsNullOrEmpty(legend.formatter))
			{
				return category;
			}
			string text = legend.formatter.Replace("{name}", category);
			text = text.Replace("{value}", category);
			Serie serie = base.chart.GetSerie(0);
			FormatterHelper.ReplaceContent(ref text, dataIndex, legend.numericFormatter, serie, base.chart, category);
			return text;
		}

		private void OnLegendButtonClick(Legend legend, int index, string legendName, bool show)
		{
			base.chart.OnLegendButtonClick(index, legendName, show);
			if (base.chart.onLegendClick != null)
			{
				base.chart.onLegendClick(legend, index, legendName, show);
			}
		}

		private void OnLegendButtonEnter(Legend legend, int index, string legendName)
		{
			base.chart.OnLegendButtonEnter(index, legendName);
			if (base.chart.onLegendEnter != null)
			{
				base.chart.onLegendEnter(legend, index, legendName);
			}
		}

		private void OnLegendButtonExit(Legend legend, int index, string legendName)
		{
			base.chart.OnLegendButtonExit(index, legendName);
			if (base.chart.onLegendExit != null)
			{
				base.chart.onLegendExit(legend, index, legendName);
			}
		}

		private void DrawLegend(VertexHelper vh)
		{
			if (base.chart.series.Count == 0)
			{
				return;
			}
			Legend legend = base.component;
			if (!legend.show || legend.iconType == Legend.Type.Custom)
			{
				return;
			}
			foreach (KeyValuePair<string, LegendItem> button in legend.context.buttonList)
			{
				LegendItem value = button.Value;
				Rect iconRect = value.GetIconRect();
				float num = Mathf.Min(iconRect.width, iconRect.height) / 2f;
				Color iconColor = value.GetIconColor();
				Legend.Type type = legend.iconType;
				if (legend.iconType == Legend.Type.Auto)
				{
					Serie serie = base.chart.GetSerie(value.legendName);
					if (serie != null)
					{
						if (serie is Line || serie is SimplifiedLine)
						{
							Vector3 startPoint = new Vector3(iconRect.center.x - iconRect.width / 2f, iconRect.center.y);
							Vector3 endPoint = new Vector3(iconRect.center.x + iconRect.width / 2f, iconRect.center.y);
							UGL.DrawLine(vh, startPoint, endPoint, base.chart.settings.legendIconLineWidth, iconColor);
							if (!serie.symbol.show)
							{
								continue;
							}
							switch (serie.symbol.type)
							{
							case SymbolType.Circle:
								type = Legend.Type.Circle;
								break;
							case SymbolType.Diamond:
								type = Legend.Type.Diamond;
								break;
							case SymbolType.EmptyCircle:
								type = Legend.Type.EmptyCircle;
								break;
							case SymbolType.Rect:
								type = Legend.Type.Rect;
								break;
							case SymbolType.Triangle:
								type = Legend.Type.Triangle;
								break;
							case SymbolType.None:
								continue;
							}
						}
						else
						{
							type = Legend.Type.Rect;
						}
					}
					else
					{
						type = Legend.Type.Rect;
					}
				}
				switch (type)
				{
				case Legend.Type.Rect:
				{
					float[] legendIconCornerRadius = base.chart.settings.legendIconCornerRadius;
					UGL.DrawRoundRectangle(vh, iconRect.center, iconRect.width, iconRect.height, iconColor, iconColor, 0f, legendIconCornerRadius, horizontal: false, 0.5f);
					break;
				}
				case Legend.Type.Circle:
					UGL.DrawCricle(vh, iconRect.center, num, iconColor);
					break;
				case Legend.Type.Diamond:
					UGL.DrawDiamond(vh, iconRect.center, num, iconColor);
					break;
				case Legend.Type.EmptyCircle:
				{
					Color32 chartBackgroundColor = base.chart.GetChartBackgroundColor();
					UGL.DrawEmptyCricle(vh, iconRect.center, num, 2f * base.chart.settings.legendIconLineWidth, iconColor, iconColor, chartBackgroundColor, 1f);
					break;
				}
				case Legend.Type.Triangle:
					UGL.DrawTriangle(vh, iconRect.center, 1.2f * num, iconColor);
					break;
				case Legend.Type.Candlestick:
					UGL.DrawRoundRectangle(vh, iconRect.center, iconRect.width / 2f, iconRect.height / 2f, iconColor, iconColor, 0f, null, horizontal: false, 0.5f);
					UGL.DrawLine(vh, new Vector3(iconRect.center.x, iconRect.center.y - iconRect.height / 2f), new Vector3(iconRect.center.x, iconRect.center.y + iconRect.height / 2f), 1f, iconColor);
					break;
				}
			}
		}
	}
}
