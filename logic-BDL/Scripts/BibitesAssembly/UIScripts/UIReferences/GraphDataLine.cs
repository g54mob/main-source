using System;
using Shapes;
using UIScripts.InfoHandles;
using UnityEngine;
using Utility;

namespace UIScripts.UIReferences
{
	public class GraphDataLine : PoolableItem<GraphDataLine>
	{
		[SerializeField]
		private Polyline graphLine;

		[SerializeField]
		private Disc dot;

		private Transform indicator;

		[SerializeField]
		private FloatValueTextHandle value;

		[NonSerialized]
		public float[] values;

		[NonSerialized]
		public Vector2[] points;

		public void InitLine(Color color, FloatValueFormat format, bool overrideUnits = false)
		{
			indicator = dot.transform;
			indicator.gameObject.SetActive(value: false);
			graphLine.Color = color;
			dot.Color = color;
			value.InitFromSetup(format, overrideUnits);
		}

		public void SetPoints(Vector2[] newPoints, float[] vals)
		{
			points = newPoints;
			graphLine.SetPoints(points);
			values = vals;
		}

		public void UpdateTooltip(int n)
		{
			indicator.localPosition = graphLine.points[n].point;
			value.UpdateValue(values[n], check: false);
		}

		public void ShowTooltip(bool show)
		{
			indicator.gameObject.SetActive(show);
		}
	}
}
