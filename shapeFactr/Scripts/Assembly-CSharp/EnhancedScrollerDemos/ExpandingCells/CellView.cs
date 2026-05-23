using System;
using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.ExpandingCells
{
	public class CellView : EnhancedScrollerCellView
	{
		private Tween tween;

		private LayoutElement layoutElement;

		private Data data;

		public Text dataIndexText;

		public Text headerText;

		public Text descriptionText;

		public Action<int, int> initializeTween;

		public Action<int, int, float, float> updateTween;

		public Action<int, int> endTween;

		private void Start()
		{
		}

		public void SetData(Data data, int dataIndex, float collapsedSize, float expandedSize, Action<int, int> initializeTween, Action<int, int, float, float> updateTween, Action<int, int> endTween)
		{
		}

		public void CellButton_Clicked()
		{
		}

		public void BeginTween()
		{
		}

		private void TweenUpdated(float newValue, float delta)
		{
		}

		private void TweenCompleted()
		{
		}
	}
}
