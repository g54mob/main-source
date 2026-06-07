using System.Collections.Generic;
using SettingScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences
{
	public class BarGraph : BaseGraph
	{
		public GameObject dataBarPrefab;

		private List<GraphDataBar> bars = new List<GraphDataBar>();

		private int nBars;

		private GenesBucketsStreamGroup dataStream;

		private GeneSetting description;

		[SerializeField]
		private Transform barHolder;

		[SerializeField]
		private LayoutElement leftBarSpacer;

		[SerializeField]
		private LayoutElement rightBarSpacer;

		private int dataSelected;

		private int timeSelected = -1;

		public override void InitGraph()
		{
			if (!hasInit)
			{
				base.InitGraph();
				nBars = 20;
				dataBarPrefab.SetActive(value: true);
				for (int i = 0; i < nBars; i++)
				{
					bars.Add(Object.Instantiate(dataBarPrefab, barHolder).GetComponent<GraphDataBar>());
				}
				dataBarPrefab.SetActive(value: false);
				dataStream = DataLogger.Instance.genesStreamGroup;
				UpdateSelectedData(16);
			}
		}

		public void UpdateTime(int i)
		{
			timeSelected = i;
			UpdateGraphData();
		}

		public void UpdateSelectedData(int i)
		{
			dataSelected = i;
			description = BibiteEditorSettings.SettingOfGene(i);
			float minValue = description.minValue;
			float span = description.span;
			FloatValueFormat formatting = description.formatting;
			for (int j = 0; j < nX; j++)
			{
				xLines.activeItems[j].UpdateFormat(formatting);
				xLines.activeItems[j].UpdateValue(minValue + span * (float)j / (float)(nX - 1));
			}
			for (int k = 0; k < nBars; k++)
			{
				bars[k].UpdateFormat(formatting);
			}
			UpdateGraphData();
		}

		public override void UpdateGraphData()
		{
			if (dataStream == null || !hasInit)
			{
				return;
			}
			Rect rect = graphRect.rect;
			GenesBucketPoint genesBucketPoint = ((timeSelected < 0) ? dataStream.PeekCurrentData() : dataStream[timeSelected])[dataSelected];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < nBars; i++)
			{
				num2 += genesBucketPoint[i];
				if (genesBucketPoint[i] > num)
				{
					num = genesBucketPoint[i];
				}
			}
			if (Mathf.Approximately(num, 0f))
			{
				num = 1;
			}
			float p = Mathf.Max(1f, Mathf.FloorToInt(Mathf.Log10(num)));
			num = (int)Mathf.Pow(10f, p) * Mathf.CeilToInt((float)num / Mathf.Pow(10f, p));
			float num3 = (float)Mathf.Max(1, Mathf.CeilToInt(5f * (genesBucketPoint.max - genesBucketPoint.min) / description.span)) / 100f * description.span;
			for (int j = 0; j < nBars; j++)
			{
				float num4 = (int)genesBucketPoint[j];
				Vector2 minMax = new Vector2(genesBucketPoint.min + num3 * (float)j, genesBucketPoint.min + num3 * (float)(j + 1));
				bars[j].UpdateValue(num4 / (float)num * rect.height, (int)num4, num4 / (float)num2, minMax);
			}
			leftBarSpacer.flexibleWidth = (genesBucketPoint.min - description.minValue) / num3;
			rightBarSpacer.flexibleWidth = (description.maxValue - (genesBucketPoint.min + num3 * (float)nBars)) / num3;
			for (int k = 0; k < nY; k++)
			{
				yLines.activeItems[k].UpdateValue((float)k / (float)(nY - 1) * (float)num);
			}
		}

		public override void OnGraphHolderDimensionChanged()
		{
			if (dataStream != null && hasInit)
			{
				base.OnGraphHolderDimensionChanged();
			}
		}
	}
}
