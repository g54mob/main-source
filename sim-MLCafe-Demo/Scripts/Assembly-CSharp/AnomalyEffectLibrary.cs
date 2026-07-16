using System;

[Serializable]
public class AnomalyEffectLibrary
{
	private AnomalyEffect[] positiveEffects = new AnomalyEffect[0];

	private AnomalyEffect[] negativeEffects = new AnomalyEffect[0];

	public AnomalyEffectLibrary()
	{
		positiveEffects = new AnomalyEffect[5]
		{
			new AEXQueueDuration(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_positive_waitduration"), AnomalyEffect.EffectType.Positive),
			new AEXCustomerSpawnRate(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_positive_customer_spawnrate"), AnomalyEffect.EffectType.Positive),
			new AEXCustomerDirtRate(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_positive_customer_dirtrate"), AnomalyEffect.EffectType.Positive),
			new AEXShopPriceRate(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_positive_shop_pricerate"), AnomalyEffect.EffectType.Positive),
			new AEXShopDeliveryDuration(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_positive_shop_deliveryduration"), AnomalyEffect.EffectType.Positive)
		};
		negativeEffects = new AnomalyEffect[5]
		{
			new AEXQueueDuration(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_negative_waitduration"), AnomalyEffect.EffectType.Negative),
			new AEXCustomerSpawnRate(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_negative_customer_spawnrate"), AnomalyEffect.EffectType.Negative),
			new AEXCustomerDirtRate(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_negative_customer_dirtrate"), AnomalyEffect.EffectType.Negative),
			new AEXShopPriceRate(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_negative_shop_pricerate"), AnomalyEffect.EffectType.Negative),
			new AEXShopDeliveryDuration(GameModeManager.GetGameModeValue<float>("gm_anomaly_effect_negative_shop_deliveryduration"), AnomalyEffect.EffectType.Negative)
		};
	}

	public AnomalyEffect[] GetPositiveEffects()
	{
		return positiveEffects;
	}

	public AnomalyEffect[] GetNegativeEffects()
	{
		return negativeEffects;
	}
}
