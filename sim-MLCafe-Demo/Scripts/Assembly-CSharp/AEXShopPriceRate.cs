using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class AEXShopPriceRate : AnomalyEffect
{
	private float shopPriceMulitplier = 1f;

	public AEXShopPriceRate(float multiplier, EffectType effectType)
	{
		index = 3;
		base.effectType = effectType;
		shopPriceMulitplier = multiplier;
		SetName("ui_anomaly_effect_name_shoppricerate");
		SetMessage("ui_anomaly_effect_msg_shoppricerate_positive", "ui_anomaly_effect_msg_shoppricerate_negative");
	}

	protected override void OnEffectAction()
	{
		AnomalyManager.GetAnomalyProperties().shop_item_price_multiplier = shopPriceMulitplier;
		UnityEngine.Object.FindObjectsByType<ShopMenu>(FindObjectsSortMode.InstanceID).ToList().ForEach(delegate(ShopMenu menu)
		{
			menu.ReloadShopOptions(-1);
		});
	}

	protected override void OnEffectReverse()
	{
		AnomalyManager.GetAnomalyProperties().shop_item_price_multiplier = AnomalyProperties.GetDefaultProperties().shop_item_price_multiplier;
		UnityEngine.Object.FindObjectsByType<ShopMenu>(FindObjectsSortMode.InstanceID).ToList().ForEach(delegate(ShopMenu menu)
		{
			menu.ReloadShopOptions(-1);
		});
	}
}
