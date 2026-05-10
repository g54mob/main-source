using Player.Toolbar.Concrete;
using UnityEngine;

namespace Views.Toolbar
{
	public class ToolbarView : MonoBehaviour
	{
		public readonly struct SlotDrawData
		{
			public readonly string itemName;

			public readonly bjo iconData;

			public SlotDrawData(string itemName, bjo iconData)
			{
				this.itemName = null;
				this.iconData = null;
			}
		}

		private class ev
		{
			public readonly SlotDrawData ptd;

			public readonly ToolbarItemSlotView pte;

			public ev(SlotDrawData a, ToolbarItemSlotView b)
			{
			}
		}

		[SerializeField]
		private SelectedItemNameDisplay m_selectedItemNameDisplay;

		[SerializeField]
		private ToolbarItemSlotView[] m_slotsViews;

		private ToolbarItemSlotView ptf;

		private ev[] ptg;

		private GodToolbarService pth;

		private int wwa => 0;

		public void dti()
		{
		}

		public void dtj(SlotDrawData a, int b)
		{
		}

		public void dtk(int a)
		{
		}

		public void dtl(int a, bool b)
		{
		}

		public void dtm(int a)
		{
		}

		private void dtn()
		{
		}
	}
}
