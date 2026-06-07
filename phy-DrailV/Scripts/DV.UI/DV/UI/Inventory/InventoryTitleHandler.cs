using System;
using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.Inventory
{
	public class InventoryTitleHandler : ATitleHandler
	{
		private const string INVENTORY_TITLE_LOCALIZATION_KEY = "hud/inventory";

		private const int INVENTORY_TITLE_NO_BUTTON_PADDING = 28;

		private const int INVENTORY_TITLE_WITH_BUTTON_PADDING = 0;

		[SerializeField]
		[NullCheck]
		private TextMeshProUGUI titleText;

		[SerializeField]
		[NullCheck]
		private GameObject backpackAccessButton;

		private ButtonDV button;

		private InventoryItemDropZone dropZone;

		private HorizontalLayoutGroup layoutGroup;

		public ButtonDV BackpackAccessButton => button;

		public event Action BackpackAccessRequested;

		private void OnDestroy()
		{
			if (button != null)
			{
				button.Clicked -= OnButtonClicked;
			}
		}

		private void OnButtonClicked(IClickable clickable)
		{
			this.BackpackAccessRequested?.Invoke();
		}

		public override void SetTitle(string title)
		{
			if (string.IsNullOrWhiteSpace(title))
			{
				backpackAccessButton.SetActive(value: false);
				layoutGroup.padding.left = 28;
				titleText.text = LocalizationAPI.L("hud/inventory");
			}
			else
			{
				layoutGroup.padding.left = 0;
				backpackAccessButton.SetActive(value: true);
				titleText.text = title;
			}
		}

		public void Initialize(AInventoryProvider provider)
		{
			button = backpackAccessButton.GetComponent<ButtonDV>();
			button.Clicked += OnButtonClicked;
			dropZone = backpackAccessButton.GetComponent<InventoryItemDropZone>();
			layoutGroup = GetComponent<HorizontalLayoutGroup>();
			if (!(backpackAccessButton == null) && !(dropZone == null))
			{
				dropZone.SetProvider(provider);
			}
		}

		public void UpdateDragState(InventorySlotDisplayData data)
		{
			if (!(dropZone == null))
			{
				dropZone.UpdateDragState(data);
			}
		}
	}
}
