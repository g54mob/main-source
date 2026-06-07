using Shapes;
using UIScripts.InfoHandles;
using UnityEngine;
using Utility;

namespace UIScripts.UIReferences
{
	public class GraphBackgroundLineLabel : PoolableItem<GraphBackgroundLineLabel>
	{
		public LineDirection direction;

		public Line line;

		public Vector2 startOffset;

		public float lineRecess;

		public FloatValueTextHandle label;

		public override void Initialize()
		{
			base.Initialize();
			if (direction == LineDirection.Horizontal)
			{
				line.Start = startOffset - Vector2.right * lineRecess;
			}
			else
			{
				line.Start = startOffset - Vector2.up * lineRecess;
			}
		}

		public void UpdateLineLength(float length)
		{
			if (direction == LineDirection.Horizontal)
			{
				line.End = startOffset + Vector2.right * length;
			}
			else
			{
				line.End = startOffset + Vector2.up * length;
			}
		}

		public void UpdateFormat(FloatValueFormat format, bool overrideUnits = false)
		{
			label.InitFromSetup(format, overrideUnits);
		}

		public void UpdateValue(float val)
		{
			label.UpdateValue(val, check: false);
		}

		public void UpdateLabel(string text)
		{
			label.text.text = text;
		}
	}
}
