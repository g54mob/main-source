using EnhancedUI.EnhancedScroller;

namespace EnhancedScrollerDemos.ExpandingCells
{
	public class Data
	{
		public bool isExpanded;

		public string headerText;

		public string descriptionText;

		public float collapsedSize;

		public float expandedSize;

		public Tween.TweenType tweenType;

		public float tweenTimeExpand;

		public float tweenTimeCollapse;

		public float Size => 0f;

		public float SizeDifference => 0f;
	}
}
