using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.SnappingDemo
{
	public class SlotController : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<SlotData> _data;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView slotCellViewPrefab;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void Reload(Sprite[] sprites)
		{
		}

		public void AddVelocity(float amount)
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
