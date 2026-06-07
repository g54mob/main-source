using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.GridSelection
{
	public class RowCellView : MonoBehaviour
	{
		public GameObject container;

		public Text text;

		public Image selectionPanel;

		public Color selectedColor;

		public Color unSelectedColor;

		public SelectedDelegate selected;

		private Data _data;

		public int DataIndex { get; private set; }

		private void OnDestroy()
		{
		}

		public void SetData(int dataIndex, Data data, SelectedDelegate selected)
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
