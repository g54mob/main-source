using NSEipix.View.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ToggleButtonItemView : LayoutGroupItemView
	{
		private int iconCollapsedIndex;

		private int iconExpandedIndex = 1;

		private int textIndex = 2;

		private int buttonIndex = 3;

		private bool isExpanded;

		private SoundButton button;

		private TMP_Text textObject;

		private Image imageObject;

		private Image buttonIcon;

		public void Initialize(UnityAction<bool> callback)
		{
			if (!button)
			{
				button = base.GroupItems[buttonIndex].GetComponent<SoundButton>();
			}
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(ToggleState);
			button.onClick.AddListener(delegate
			{
				callback(isExpanded);
			});
			isExpanded = false;
			UpdateVisuals();
		}

		private void ToggleState()
		{
			isExpanded = !isExpanded;
			UpdateVisuals();
		}

		private void UpdateVisuals()
		{
			base.GroupItems[iconCollapsedIndex].SetActive(!isExpanded);
			base.GroupItems[iconExpandedIndex].SetActive(isExpanded);
		}
	}
}
