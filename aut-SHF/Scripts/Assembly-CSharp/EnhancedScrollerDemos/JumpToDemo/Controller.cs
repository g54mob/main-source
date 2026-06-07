using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.JumpToDemo
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private List<Data> _data;

		public EnhancedScroller vScroller;

		public EnhancedScroller hScroller;

		public InputField jumpIndexInput;

		public Toggle useSpacingToggle;

		public Slider scrollerOffsetSlider;

		public Slider cellOffsetSlider;

		public EnhancedScrollerCellView cellViewPrefab;

		public EnhancedScroller.TweenType vScrollerTweenType;

		public float vScrollerTweenTime;

		public EnhancedScroller.TweenType hScrollerTweenType;

		public float hScrollerTweenTime;

		private void Start()
		{
		}

		public void JumpButton_OnClick()
		{
		}

		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			return 0;
		}

		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 0f;
		}

		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			return null;
		}
	}
}
