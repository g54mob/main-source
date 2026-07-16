using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class ShopCategoryAmmo : ShopCategory
{
	[SerializeField]
	private LocalizedString buyAmmoLocalized;

	public void Setup(int cost, int quantity)
	{
		cost = LootManager.Instance.ApplyCostModifier(cost, ShopItemType.Ammo);
		costText.text = StringFormatHelper.ConvertToCurrency(cost);
		shopCost = cost;
		buyAmmoLocalized.Arguments = new object[1] { quantity };
		buyAmmoLocalized.StringChanged += delegate(string value)
		{
			buyButtonText.text = value;
		};
		buyAmmoLocalized.RefreshString();
		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener(delegate
		{
			BuyAmmo(cost, quantity);
		});
	}

	private void BuyAmmo(int cost, int quantity)
	{
		if (ResourceManager.Instance.Scrap.TrySpend(cost))
		{
			AudioManager.Instance.PlayClipWithMixer(ShopWindow.Instance.buyClip, AMG.SFX);
			ResourceManager.Instance.Ammo.AddValue(quantity);
			DataTrackingManager.Instance.AddScrapUsedAmmo(cost);
			ShopWindow.Instance.CheckForScrap();
			SaveManager.Instance.SaveJourney();
		}
	}
}
