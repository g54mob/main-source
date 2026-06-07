using System;
using ScriptHelpers;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;

namespace UIScripts.UIReferences.Graphs
{
	public class SingleLineGraph : BaseLineGraph
	{
		[SerializeField]
		protected GraphDataLine dataLine;

		[SerializeField]
		private TextMeshProUGUI graphTitle;

		[SerializeField]
		private TextMeshProUGUI xAxisLabel;

		[SerializeField]
		private TextMeshProUGUI xUnits;

		[SerializeField]
		private TextMeshProUGUI yUnits;

		[SerializeField]
		private TooltipTrigger titleTooltip;

		[SerializeField]
		private TooltipTrigger xUnitsTooltip;

		[SerializeField]
		private GameObject titleSection;

		[SerializeField]
		private GameObject xLabelSection;

		[SerializeField]
		private GameObject xUnitsSection;

		[SerializeField]
		private GameObject yUnitsSection;

		[NonSerialized]
		public Vector2[] values;

		[NonSerialized]
		public Vector2[] points;

		private readonly FloatValueFormat defaultFormat = new FloatValueFormat
		{
			units = "",
			precision = 2,
			precisionIsSI = true,
			SI = false
		};

		private FloatValueFormat xFormat;

		private FloatValueFormat yFormat;

		private Color lineColor;

		private bool xUnitsDisplayedOnLines;

		private bool yUnitsDisplayedOnLines;

		public override void InitGraph()
		{
			base.InitGraph();
			indicatorLine.gameObject.SetActive(value: false);
			indicatorLine.Start = Vector3.zero;
		}

		public void InitGraph(FloatValueFormat xValueFormat, FloatValueFormat yValueFormat, Color color, string title, string xLabel, string yLabelDescription, string xLabelDescription)
		{
			InitGraph();
			yUnitsDisplayedOnLines = graphTitle != null && !string.IsNullOrEmpty(title);
			titleSection.SetActive(yUnitsDisplayedOnLines);
			if (yUnitsDisplayedOnLines)
			{
				graphTitle.text = title;
				if (titleTooltip != null && !string.IsNullOrEmpty(yLabelDescription))
				{
					titleTooltip.UpdateText(title, yLabelDescription);
				}
			}
			xUnitsDisplayedOnLines = xAxisLabel != null && !string.IsNullOrEmpty(xLabel);
			xLabelSection.SetActive(yUnitsDisplayedOnLines);
			if (xUnitsDisplayedOnLines)
			{
				xAxisLabel.text = xLabel;
				if (xUnitsTooltip != null && !string.IsNullOrEmpty(xLabelDescription))
				{
					xUnitsTooltip.UpdateText(xLabel, xLabelDescription);
				}
			}
			SetFormat(xValueFormat, yValueFormat, color);
		}

		public void SetFormat(FloatValueFormat xValueFormat, FloatValueFormat yValueFormat, Color color)
		{
			xFormat = xValueFormat;
			yFormat = yValueFormat;
			lineColor = color;
			dataLine.InitLine(lineColor, yFormat);
			if (yUnitsDisplayedOnLines && yUnitsSection != null)
			{
				yUnitsSection.SetActive(!string.IsNullOrEmpty(yValueFormat.units));
				if (yUnits != null)
				{
					yUnits.text = yValueFormat.units;
				}
			}
			if (xUnitsDisplayedOnLines && xUnitsSection != null)
			{
				xUnitsSection.SetActive(!string.IsNullOrEmpty(xValueFormat.units));
				if (xUnits != null)
				{
					xUnits.text = xValueFormat.units;
				}
			}
			for (int i = 0; i < nX; i++)
			{
				xLines.activeItems[i].UpdateFormat(xFormat, xUnitsDisplayedOnLines);
			}
			for (int j = 0; j < nY; j++)
			{
				yLines.activeItems[j].UpdateFormat(yFormat, yUnitsDisplayedOnLines);
			}
		}

		public void SetCurve(Vector2[] vals)
		{
			values = vals;
			nPoints = values.Length;
			min = defaultMin;
			max = defaultMax;
			Vector2[] array = values;
			for (int i = 0; i < array.Length; i++)
			{
				Vector2 vector = array[i];
				min = new Vector2(Mathf.Min(min.x, vector.x), Mathf.Min(min.y, vector.y));
				max = new Vector2(Mathf.Max(max.x, vector.x), Mathf.Max(max.y, vector.y));
			}
			max.y = Mathf.Ceil(max.y * 10f) / 10f;
			float num = MathfE.RoundToMSD((max.y - min.y) / (float)(nY - 1), yFormat.precision);
			float num2 = MathfE.RoundToMSD((max.x - min.x) / (float)(nX - 1), xFormat.precision);
			max = new Vector2(min.x + (float)(nX - 1) * num2, min.y + (float)(nY - 1) * num);
			for (int j = 0; j < nX; j++)
			{
				xLines.activeItems[j].UpdateValue(min.x + num2 * (float)j);
			}
			for (int k = 0; k < nY; k++)
			{
				yLines.activeItems[k].UpdateValue(min.y + num * (float)k);
			}
			xLineHolder.spacing = graphRect.rect.width / (float)(nX - 1);
			yLineHolder.spacing = graphRect.rect.height / (float)(nY - 1);
			UpdateGraphData();
		}

		public override void OnGraphHolderDimensionChanged()
		{
			if (!hasInit)
			{
				InitGraph();
			}
			base.OnGraphHolderDimensionChanged();
		}

		public override void UpdateGraphData()
		{
			points = new Vector2[nPoints];
			float[] array = new float[nPoints];
			x = new float[nPoints];
			for (int i = 0; i < nPoints; i++)
			{
				points[i] = ValueToRectPos(values[i]);
				x[i] = points[i].x;
				array[i] = values[i].y;
			}
			dataLine.SetPoints(points, array);
		}

		public override void UpdateTooltip(float xInRect)
		{
			base.UpdateTooltip(xInRect);
			dataLine.UpdateTooltip(nClosest);
		}

		public override void ShowTooltip(bool show)
		{
			base.ShowTooltip(show);
			dataLine.ShowTooltip(show);
		}
	}
}
