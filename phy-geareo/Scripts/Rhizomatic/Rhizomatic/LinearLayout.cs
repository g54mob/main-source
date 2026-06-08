using UnityEngine;

namespace Rhizomatic
{
	public abstract class LinearLayout : ScrollableLayout
	{
		protected override void SetupItem(LayoutItem item, LayoutItem nextItem, LayoutItem previousItem)
		{
		}

		protected abstract void SetupItem(RectTransform r, float axisSize, float crossAxisSize, float start);
	}
}
