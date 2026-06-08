using UnityEngine;

namespace Rhizomatic
{
	public class GridScrollableLayout : ScrollableLayout
	{
		public int columns;

		public GridAxisSizeMode sizeMode;

		public float ratio;

		public float height;

		private float containerWidth;

		private float itemWidth;

		private float itemHeight;

		protected override bool GetInvertedScroll()
		{
			return false;
		}

		protected override float GetAxis(Vector2 vector)
		{
			return 0f;
		}

		protected override float GetCrossAxis(Vector2 vector)
		{
			return 0f;
		}

		protected override Vector2 GetVector(float axis, float crossAxis)
		{
			return default(Vector2);
		}

		protected override float GetStart(LayoutItem item)
		{
			return 0f;
		}

		protected override float GetEnd(LayoutItem item)
		{
			return 0f;
		}

		protected override float GetContentStart(LayoutItem item)
		{
			return 0f;
		}

		protected override float GetContentEnd(LayoutItem item)
		{
			return 0f;
		}

		protected override float GetExtraMargin()
		{
			return 0f;
		}

		protected override void BuildLayout()
		{
		}

		protected override void SetupItem(LayoutItem item, LayoutItem nextItem, LayoutItem previousItem)
		{
		}

		protected override void MoveAll(float value)
		{
		}
	}
}
