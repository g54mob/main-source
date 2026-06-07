using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FullGameVersionPanel : MenuPanel
{
	public LabelButton storePageButton;

	public ScrollRect scrollRect;

	public LayoutGroup layoutGroup;

	public GameObject prefab;

	public TextMeshProUGUI prompt;

	private readonly Dictionary<string, TooltipIconLabelListItem> listItems = new Dictionary<string, TooltipIconLabelListItem>();

	public TooltipIconLabelListItem itemResearch;

	public TooltipIconLabelListItem itemBiomes;

	public TooltipIconLabelListItem itemRewards;

	public TooltipIconLabelListItem itemMinigames;

	public TooltipIconLabelListItem itemDeveloper;

	public TooltipIconLabelListItem itemTransfer;

	public override void Initialize()
	{
		base.Initialize();
		storePageButton.AddPointerClickTrigger(OnStorePagePressed);
		storePageButton.buttonState = CustomButtonState.Default;
		scrollRect.scrollSensitivity = 40f;
		scrollRect.verticalScrollbarSpacing = -1f;
		header.headerIcon.sprite = IconManager.Instance.friendFace;
	}

	private void OnStorePagePressed()
	{
		Application.OpenURL("https://store.steampowered.com/app/2207490");
	}

	public override void CreateItems()
	{
		base.CreateItems();
		listItems["DemoDescItems"] = itemResearch;
		listItems["DemoDescBiomes"] = itemBiomes;
		listItems["Minigames"] = itemMinigames;
		listItems["DemoDescRewards"] = itemRewards;
		listItems["DemoSupportDeveloper"] = itemDeveloper;
		listItems["DemoDescProgressTransfer"] = itemTransfer;
	}

	private void CreateItem(string localizationKey, Sprite sprite)
	{
		TooltipIconLabelListItem component = MenuManager.GetMenuObject(prefab, layoutGroup.transform).GetComponent<TooltipIconLabelListItem>();
		listItems[localizationKey] = component;
		component.iconImage.sprite = sprite;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		prompt.text = "FullVersionPrompt".Localized();
		storePageButton.label.text = "StorePage".Localized();
		foreach (KeyValuePair<string, TooltipIconLabelListItem> listItem in listItems)
		{
			listItem.Value.primaryLabel.text = listItem.Key.Localized();
		}
		if (LocalizationManager.IsEnglish())
		{
			itemTransfer.gameObject.SetActive(value: true);
			itemTransfer.primaryLabel.text = "Game progress automatically transfers";
			((RectTransform)base.gameObject.transform).SetHeight(532f);
		}
		else
		{
			itemTransfer.gameObject.SetActive(value: false);
			((RectTransform)base.gameObject.transform).SetHeight(464f);
		}
	}
}
