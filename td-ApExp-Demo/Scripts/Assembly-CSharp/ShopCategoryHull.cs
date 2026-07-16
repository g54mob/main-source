using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class ShopCategoryHull : ShopCategory
{
	[SerializeField]
	private LocalizedString buyHullLocalized;

	public void Setup(int cost, int quantity)
	{
		cost = LootManager.Instance.ApplyCostModifier(cost, ShopItemType.Hull);
		costText.text = StringFormatHelper.ConvertToCurrency(cost);
		shopCost = cost;
		buyHullLocalized.Arguments = new object[1] { quantity };
		buyHullLocalized.StringChanged += delegate(string value)
		{
			buyButtonText.text = value;
		};
		buyHullLocalized.RefreshString();
		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener(delegate
		{
			BuyHull(cost, quantity);
		});
	}

	private void BuyHull(int cost, int quantity)
	{
		if (ResourceManager.Instance.Scrap.TrySpend(cost))
		{
			AudioManager.Instance.PlayClipWithMixer(ShopWindow.Instance.buyClip, AMG.SFX);
			Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(null, Train.Instance.HealthComponent, quantity, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
			DataTrackingManager.Instance.AddScrapUsedRepair(cost);
			ShopWindow.Instance.CheckForScrap();
			SaveManager.Instance.SaveJourney();
		}
	}
}
