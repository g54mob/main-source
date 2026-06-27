using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.Tooltips
{
	public abstract class GUI_SingleItemStackTooltipBase : GUI_SingleCursorDetectorTooltipBase
	{
		[Header("Item stack view settings")]
		[SerializeField]
		protected GameObject itemView;

		[SerializeField]
		protected Image itemIcon;

		[SerializeField]
		protected GameObject itemCount;

		[SerializeField]
		protected TextMeshProUGUI itemCountValue;

		[SerializeField]
		protected Image operandImage;

		[SerializeField]
		protected Sprite addSprite;

		[SerializeField]
		protected Sprite subtractSprite;

		protected override void InitializeDescriptionOnly(string message, bool isActivatable)
		{
			base.InitializeDescriptionOnly(message, isActivatable);
			if ((bool)itemView)
			{
				itemView.SetActive(value: false);
			}
		}
	}
}
