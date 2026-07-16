using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[Serializable]
public class ShopCategoryWagon : ShopCategory
{
	public Image wagonImage;

	public Image checkmarkImage;

	public TextMeshProUGUI wagonImageText;

	public EnhancementWagon wagon;

	public int shopIndex;

	public bool isBought;

	[SerializeField]
	private LocalizedString soldLocalized;

	public void Setup(EnhancementWagon newWagon, int discountValue, int index)
	{
		shopIndex = index;
		newWagon.IndexInShop = index;
		if (SaveManager.Instance.HasPurchasedWagonAtIndex(index))
		{
			wagonImage.enabled = false;
			buyButton.interactable = false;
			costText.text = "";
			buyButtonText.enabled = false;
			checkmarkImage.enabled = true;
			wagonImageText.text = "";
			return;
		}
		wagon = newWagon;
		wagonImage.sprite = wagon.Icon;
		wagonImage.SetNativeSize();
		wagonImage.enabled = true;
		wagonImageText.text = wagon.NameKey.GetLocalizedString();
		int num = Mathf.FloorToInt(wagon.Cost * (100 - discountValue) / 100);
		shopCost = num;
		if ((float)num > ResourceManager.Instance.Scrap.Value)
		{
			costText.color = ColorUtils.HexToColor("FF0800");
		}
		else
		{
			costText.color = ColorUtils.HexToColor("3BFF00");
		}
		costText.text = StringFormatHelper.ConvertToCurrency(num);
		buyButton.interactable = true;
		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener(delegate
		{
			BuyWagon(wagon);
		});
		buyButtonText.enabled = true;
		checkmarkImage.enabled = false;
		isBought = false;
	}

	public void BuyWagon(EnhancementWagon wagon)
	{
		if (ResourceManager.Instance.Scrap.TrySpend(shopCost))
		{
			DataTrackingManager.Instance.AddScrapUsedWagons((int)shopCost);
			AudioManager.Instance.PlayClipWithMixer(ShopWindow.Instance.buyClip, AMG.SFX);
			UpgradeManager.Instance.AddWagon(wagon);
			buyButton.interactable = false;
			costText.text = soldLocalized.GetLocalizedString();
			buyButtonText.enabled = false;
			checkmarkImage.enabled = true;
			isBought = true;
			ShopWindow.Instance.CheckForScrap();
			SaveManager.Instance.AddShopWagonPurchase(wagon.IndexInShop);
		}
	}
}
