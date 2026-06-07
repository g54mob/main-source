using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI.Manual
{
	public class ManualNavigationButtonViewElement : AViewElement<ManualTreeNode>
	{
		private static Color textColorNormal = new Color(1f, 1f, 1f, 1f);

		private static Color textColorTransparent = new Color(1f, 1f, 1f, 0.3f);

		public TextMeshProUGUI tmPro;

		private ManualTreeNode data;

		public override void SetData(ManualTreeNode data, AGridView<ManualTreeNode> _)
		{
			if (this.data != null)
			{
				this.data = null;
			}
			if (data != null)
			{
				this.data = data;
			}
			SetSelected(selected: false);
			UpdateView();
		}

		public override void SetSelected(bool selected)
		{
			base.SetSelected(selected);
			tmPro.color = (selected ? textColorNormal : textColorTransparent);
		}

		private void UpdateView()
		{
			tmPro.text = data?.displayData.title ?? "[NO DATA]";
		}
	}
}
