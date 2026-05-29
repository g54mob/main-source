using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SelectionDemo
{
	public class InventoryCellView : EnhancedScrollerCellView
	{
		private InventoryData _data;

		public Image selectionPanel;

		public Text itemNameText;

		public Text itemCostText;

		public Text itemDamageText;

		public Text itemDefenseText;

		public Text itemWeightText;

		public Text itemDescriptionText;

		public Image image;

		public Color selectedColor;

		public Color unSelectedColor;

		public SelectedDelegate selected;

		public int DataIndex { get; private set; }

		private void OnDestroy()
		{
		}

		public void SetData(int dataIndex, InventoryData data, bool isVertical)
		{
		}

		private void SelectedChanged(bool selected)
		{
		}

		public void OnSelected()
		{
		}
	}
}
