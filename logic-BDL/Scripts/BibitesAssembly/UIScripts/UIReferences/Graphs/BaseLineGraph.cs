using ScriptHelpers;
using Shapes;
using UnityEngine;

namespace UIScripts.UIReferences.Graphs
{
	public abstract class BaseLineGraph : BaseGraph
	{
		[SerializeField]
		protected Line indicatorLine;

		protected int nClosest;

		protected float xClosest;

		protected float[] x;

		protected int nPoints;

		public abstract override void UpdateGraphData();

		public override void OnGraphHolderDimensionChanged()
		{
			base.OnGraphHolderDimensionChanged();
			Rect rect = graphRect.rect;
			indicatorLine.End = Vector3.up * rect.height;
		}

		public virtual void UpdateTooltip(float xInRect)
		{
			nClosest = x.IndexOfClosest(xInRect);
			nClosest = Mathf.Clamp(nClosest, 0, x.Length);
			xClosest = x[nClosest];
			indicatorLine.transform.localPosition = xClosest * Vector2.right;
		}

		public virtual void ShowTooltip(bool show)
		{
			indicatorLine.gameObject.SetActive(show);
		}
	}
}
