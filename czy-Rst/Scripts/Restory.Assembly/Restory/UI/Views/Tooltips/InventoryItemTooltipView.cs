using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public sealed class InventoryItemTooltipView : TooltipView
	{
		[SerializeField]
		private TextMeshProUGUI titleText;

		[SerializeField]
		private TextMeshProUGUI descText;

		public string Title
		{
			get
			{
				return titleText.text;
			}
			set
			{
				titleText.text = value;
			}
		}

		public string Desc
		{
			get
			{
				return descText.text;
			}
			set
			{
				descText.text = value;
			}
		}
	}
}
