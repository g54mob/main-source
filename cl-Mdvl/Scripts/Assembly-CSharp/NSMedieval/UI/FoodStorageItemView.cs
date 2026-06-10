using NSEipix.View.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class FoodStorageItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text descriptionText;

		[SerializeField]
		private SoundButton dropButton;

		[SerializeField]
		private SoundButton eatButton;

		public SoundButton DropButton => dropButton;

		public SoundButton EatButton => eatButton;

		public void SetData(string text, string tooltipText, UnityAction onDropClick, UnityAction onEatClick)
		{
			descriptionText.SetText(text);
			base.TooltipNew.ClearLines();
			base.TooltipNew.AppendLine(tooltipText);
			dropButton.onClick.RemoveAllListeners();
			dropButton.onClick.AddListener(onDropClick);
			eatButton.onClick.RemoveAllListeners();
			eatButton.onClick.AddListener(onEatClick);
		}
	}
}
