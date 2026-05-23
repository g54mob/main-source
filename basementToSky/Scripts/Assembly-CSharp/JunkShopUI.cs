using System;
using RainbowArt.CleanFlatUI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class JunkShopUI : MonoBehaviour
{
	private LocalizedString basementString = new LocalizedString("MyTable", "Basement");

	private LocalizedString backyardString = new LocalizedString("MyTable", "Backyard");

	[SerializeField]
	private TextMeshProUGUI title;

	[SerializeField]
	private TextMeshProUGUI description;

	[SerializeField]
	private Image mainImage;

	[SerializeField]
	private JunkShopItem[] items;

	[SerializeField]
	private TabView tabViewUI;

	[SerializeField]
	private GameObject tabCloseUI;

	[SerializeField]
	private TextMeshProUGUI buyBtnText;

	[SerializeField]
	private GameObject block;

	private JunkShopItem currentSelectedFurniture;

	private void Start()
	{
		ItemSelected(items[0]);
		GameManager.S.OnPartTimeUnlocked += S_OnPartTimeUnlocked;
		GameManager.S.OnTearDownUnlocked += S_OnTearDownUnlocked;
		if (QuestManager.S.currentQuestIndex >= 19)
		{
			items[4].isUnlocked = true;
		}
		if (QuestManager.S.currentQuestIndex >= 17)
		{
			items[3].isUnlocked = true;
		}
	}

	private void S_OnTearDownUnlocked()
	{
		items[4].isUnlocked = true;
	}

	private void OnDestroy()
	{
		GameManager.S.OnPartTimeUnlocked -= S_OnPartTimeUnlocked;
		GameManager.S.OnTearDownUnlocked -= S_OnTearDownUnlocked;
	}

	private void S_OnPartTimeUnlocked()
	{
		items[3].isUnlocked = true;
	}

	private void Update()
	{
	}

	public void ItemSelected(JunkShopItem item)
	{
		Furniture component = item.furnitureGO.GetComponent<Furniture>();
		mainImage.sprite = component.mainImage;
		title.text = component.itemNameTemp.GetLocalizedString();
		description.text = component.description.GetLocalizedString();
		int num = LayerMask.NameToLayer("Terrain");
		int num2 = LayerMask.NameToLayer("Basement");
		bool flag = (component.installableLayerMask.value & (1 << num)) != 0;
		bool flag2 = (component.installableLayerMask.value & (1 << num2)) != 0;
		string text = ((flag && flag2) ? (backyardString.GetLocalizedString() + basementString.GetLocalizedString()) : ((!flag) ? basementString.GetLocalizedString() : backyardString.GetLocalizedString()));
		component.description.Arguments = new object[1] { text };
		description.text = component.description.GetLocalizedString();
		buyBtnText.text = $"$ {component.value}";
		currentSelectedFurniture = item;
		if (!item.isUnlocked)
		{
			block.SetActive(value: true);
		}
		else
		{
			block.SetActive(value: false);
		}
	}

	public void OpenUI()
	{
		ItemSelected(items[0]);
		tabViewUI.gameObject.SetActive(value: true);
		tabCloseUI.gameObject.SetActive(value: true);
		GameManager.S.OnPlayerPressTab += S_OnPlayerPressTab;
		if (QuestManager.S.currentQuestIndex >= 19)
		{
			items[4].isUnlocked = true;
		}
		if (QuestManager.S.currentQuestIndex >= 17)
		{
			items[3].isUnlocked = true;
		}
	}

	public void OffUI()
	{
		GameManager.S.EndConversation();
		FirstPersonController.S.canControl = true;
		tabViewUI.gameObject.SetActive(value: false);
		tabCloseUI.gameObject.SetActive(value: false);
	}

	private void S_OnPlayerPressTab(object sender, EventArgs e)
	{
		GameManager.S.OnPlayerPressTab -= S_OnPlayerPressTab;
		OffUI();
	}

	private void OnDisable()
	{
		GameManager.S.OnPlayerPressTab -= S_OnPlayerPressTab;
	}

	public void Buy()
	{
		Furniture component = currentSelectedFurniture.furnitureGO.GetComponent<Furniture>();
		if (FirstPersonController.S.money >= component.value)
		{
			FirstPersonController.S.MoneyUpdated(0f - component.value);
			UnityEngine.Object.Instantiate(currentSelectedFurniture.furnitureGO, FirstPersonController.S.transform.position + Vector3.up * 0.2f + FirstPersonController.S.transform.forward * 0.2f, Quaternion.identity).GetComponent<Furniture>().Interact();
			AudioManager.S.PlaySFX(AudioManager.S.money);
		}
		else
		{
			AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
		}
	}
}
