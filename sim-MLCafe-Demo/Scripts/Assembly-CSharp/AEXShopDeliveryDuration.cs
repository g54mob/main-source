using System;

[Serializable]
public class AEXShopDeliveryDuration : AnomalyEffect
{
	private float deliveryDurationMulitplier = 1f;

	public AEXShopDeliveryDuration(float multiplier, EffectType effectType)
	{
		index = 4;
		base.effectType = effectType;
		deliveryDurationMulitplier = multiplier;
		SetName("ui_anomaly_effect_name_shopdeliveryduration");
		SetMessage("ui_anomaly_effect_msg_shopdeliveryduration_positive", "ui_anomaly_effect_msg_shopdeliveryduration_negative");
	}

	protected override void OnEffectAction()
	{
		AnomalyManager.GetAnomalyProperties().shop_delivery_duration = deliveryDurationMulitplier;
	}

	protected override void OnEffectReverse()
	{
		AnomalyManager.GetAnomalyProperties().shop_delivery_duration = AnomalyProperties.GetDefaultProperties().shop_delivery_duration;
	}
}
