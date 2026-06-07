using UIScripts.UIReferences.Graphs;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences
{
	public class DataStreamLinesGraph : BaseLineGraph
	{
		public GameObject dataLinePrefab;

		private ItemPool<GraphDataLine> dataLines;

		private int step;

		private int scaleIndex;

		private IDataPointStream dataStream;

		private DataStreamDescription[] descriptions;

		private bool[] curvesSelected;

		[SerializeField]
		private Button[] scaleButtons;

		[SerializeField]
		protected Transform legendHolder;

		[SerializeField]
		protected GameObject legendItem;

		private ItemPool<GraphLegendItem> legendItems;

		private IDataPoint currentData;

		public override void InitGraph()
		{
			if (!hasInit)
			{
				base.InitGraph();
				dataLines = new ItemPool<GraphDataLine>(dataLinePrefab, graphRect, 6);
				dataLinePrefab.SetActive(value: false);
				legendItems = new ItemPool<GraphLegendItem>(legendItem, legendHolder, 6);
				legendItem.SetActive(value: false);
				indicatorLine.gameObject.SetActive(value: false);
				indicatorLine.Start = Vector3.zero;
				UpdateScaleIndex(0);
				SetDataStream(DataLogger.Instance.biomassDataStreamGroup);
			}
		}

		public void SetDataStream(IDataPointStream stream)
		{
			dataStream = stream;
			descriptions = dataStream.GetStreamsDescriptions();
			legendItems.RetireAll();
			legendItems.WakeUpItems(descriptions.Length);
			for (int i = 0; i < descriptions.Length; i++)
			{
				legendItems[i].SetDescription(descriptions[i]);
				legendItems[i].transform.SetAsLastSibling();
			}
			curvesSelected = new bool[descriptions.Length];
			for (int j = 0; j < curvesSelected.Length; j++)
			{
				curvesSelected[j] = descriptions[j].state;
				legendItems[j].SetActive(curvesSelected[j]);
			}
			int num = 0;
			for (int k = 1; k < stream.nScales; k++)
			{
				if (stream.DepthHasData(k))
				{
					num = k;
				}
				scaleButtons[k].interactable = stream.DepthHasData(k);
			}
			if (scaleIndex <= num)
			{
				UpdateGraphData();
			}
			else
			{
				UpdateScaleIndex(num);
			}
		}

		public void UpdateSelectedCurves(bool[] selected)
		{
			curvesSelected = selected;
			for (int i = 0; i < selected.Length; i++)
			{
				descriptions[i].state = selected[i];
				legendItems[i].SetActive(descriptions[i].state);
			}
			UpdateGraphData();
		}

		public void UpdateScaleIndex(int index)
		{
			scaleIndex = index;
			if (dataStream != null)
			{
				nPoints = dataStream.DataSizeAtDepth(scaleIndex) + 1;
			}
			else
			{
				nPoints = DataLogger.ParallelDetailedConfig.formats[index].size + 1;
			}
			step = 1;
			for (int i = 0; i < scaleIndex; i++)
			{
				step *= DataLogger.ParallelDetailedConfig.formats[i].feedRatio;
			}
			TimeFormat timeFormat = DataLogger.ParallelDetailedConfig.TimeFormatOfParallelLogLikeScale(index, nPoints - 1);
			float val = timeFormat.val;
			for (int j = 0; j < nX; j++)
			{
				xLines.activeItems[j].UpdateLabel(timeFormat.FormattedValue(val * (float)j / (float)(nX - 1), 2, timeFormat.scale));
			}
			xLineHolder.spacing = graphRect.rect.width / (float)(nX - 1);
			UpdateGraphData();
		}

		public override void UpdateGraphData()
		{
			if (dataStream == null || !hasInit)
			{
				return;
			}
			int num = descriptions.Length;
			int num2 = 0;
			bool[] array = curvesSelected;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i])
				{
					num2++;
				}
			}
			int num3 = dataStream.DataAtDepth(scaleIndex);
			if (num2 < dataLines.activeCount)
			{
				dataLines.RetireLasts(dataLines.activeCount - num2);
			}
			else if (dataLines.activeCount < num2)
			{
				dataLines.WakeUpItems(num2 - dataLines.activeCount);
			}
			Rect rect = graphRect.rect;
			currentData = dataStream.PeekCurrentDataPoint();
			float num4 = 0f;
			for (int j = 0; j < num; j++)
			{
				if (!curvesSelected[j])
				{
					continue;
				}
				for (int k = 0; k < num3; k++)
				{
					if (dataStream[scaleIndex, k][j] > num4)
					{
						num4 = dataStream[scaleIndex, k][j];
					}
				}
				if (currentData[j] > num4)
				{
					num4 = currentData[j];
				}
			}
			if (Mathf.Approximately(num4, 0f))
			{
				num4 = 1f;
			}
			int num5 = Mathf.FloorToInt(Mathf.Log10(num4));
			num4 = Mathf.Pow(10f, num5) * (float)Mathf.CeilToInt(num4 / Mathf.Pow(10f, num5));
			int l = 0;
			for (int m = 0; m < num2; m++)
			{
				for (; l < num && !curvesSelected[l]; l++)
				{
				}
				Vector2[] array2 = new Vector2[nPoints];
				x = new float[nPoints];
				float[] array3 = new float[nPoints];
				array3[^1] = currentData[l];
				for (int n = 1; n < nPoints; n++)
				{
					if (n < num3 + 1)
					{
						array3[^(n + 1)] = dataStream[scaleIndex, n - 1][l];
					}
					else
					{
						array3[^(n + 1)] = 0f;
					}
				}
				for (int num6 = 0; num6 < nPoints; num6++)
				{
					x[num6] = rect.width * (float)num6 / (float)(nPoints - 1);
					array2[num6] = new Vector2(x[num6], rect.height * array3[num6] / num4);
				}
				dataLines.activeItems[m].SetPoints(array2, array3);
				dataLines.activeItems[m].InitLine(descriptions[l].color, dataStream.formating);
				l++;
			}
			for (int num7 = 0; num7 < nY; num7++)
			{
				yLines.activeItems[num7].UpdateFormat(dataStream.formating);
				yLines.activeItems[num7].UpdateValue((float)num7 / (float)(nY - 1) * num4);
			}
		}

		public override void UpdateTooltip(float xInRect)
		{
			base.UpdateTooltip(xInRect);
			dataLines.activeItems.ForEach(delegate(GraphDataLine l)
			{
				l.UpdateTooltip(nClosest);
			});
		}

		public override void ShowTooltip(bool show)
		{
			base.ShowTooltip(show);
			dataLines.activeItems.ForEach(delegate(GraphDataLine l)
			{
				l.ShowTooltip(show);
			});
		}

		protected override void OnShow()
		{
			base.OnShow();
			SetDataStream(dataStream);
		}
	}
}
