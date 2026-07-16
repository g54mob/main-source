using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class ShopCategoryCores : ShopCategory
{
	[SerializeField]
	private LocalizedString buyCoresLocalized;

	public void Setup(int cost, int quantity)
	{
		cost = LootManager.Instance.ApplyCostModifier(cost, ShopItemType.Cores);
		costText.text = StringFormatHelper.ConvertToCurrency(cost);
		shopCost = cost;
		buyCoresLocalized.Arguments = new object[1] { quantity };
		buyCoresLocalized.StringChanged += delegate(string value)
		{
			buyButtonText.text = value;
		};
		buyCoresLocalized.RefreshString();
		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener(delegate
		{
			BuyCores(cost, quantity);
		});
	}

	private void BuyCores(int cost, int quantity)
	{
		if (ResourceManager.Instance.Scrap.TrySpend(cost))
		{
			ShopWindow.Instance.coresCostModifier++;
			ShopWindow.Instance.UpdatePrices();
			AudioManager.Instance.PlayClipWithMixer(ShopWindow.Instance.buyClip, AMG.SFX);
			ResourceManager.Instance.LootCores(quantity);
			ShopWindow.Instance.CheckForScrap();
			SaveManager.Instance.SaveJourney();
		}
	}
}
