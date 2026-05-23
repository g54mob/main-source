using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SelectionDemo
{
	public class SelectionDemo : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<InventoryData> _data;

		public EnhancedScroller vScroller;

		public EnhancedScroller hScroller;

		public EnhancedScrollerCellView vCellViewPrefab;

		public EnhancedScrollerCellView hCellViewPrefab;

		public Image selectedImage;

		public Text selectedImageText;

		public string resourcePath;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Reload()
		{
		}

		private void CellViewSelected(EnhancedScrollerCellView cellView)
		{
		}

		public void MaskToggle_OnValueChanged(bool val)
		{
		}

		public void LoopToggle_OnValueChanged(bool val)
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
