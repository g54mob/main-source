using NSEipix.View.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class MedicineStorageItemView : LayoutGroupItemView
	{
		[SerializeField]
		private TMP_Text descriptionText;

		[SerializeField]
		private SoundButton dropButton;

		public SoundButton DropButton => dropButton;

		public void SetData(string text, string tooltipText, UnityAction onDropClick)
		{
			descriptionText.SetText(text);
			base.TooltipNew.ClearLines();
			base.TooltipNew.AppendLine(tooltipText);
			dropButton.onClick.RemoveAllListeners();
			dropButton.onClick.AddListener(onDropClick);
		}
	}
}
