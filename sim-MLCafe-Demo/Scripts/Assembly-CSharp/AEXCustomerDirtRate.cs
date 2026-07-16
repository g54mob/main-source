using System;

[Serializable]
public class AEXCustomerDirtRate : AnomalyEffect
{
	private float customerDirtRateMulitplier = 1f;

	public AEXCustomerDirtRate(float multiplier, EffectType effectType)
	{
		index = 2;
		base.effectType = effectType;
		customerDirtRateMulitplier = multiplier;
		SetName("ui_anomaly_effect_name_customerdirtrate");
		SetMessage("ui_anomaly_effect_msg_customerdirtrate_positive", "ui_anomaly_effect_msg_customerdirtrate_negative");
	}

	protected override void OnEffectAction()
	{
		AnomalyManager.GetAnomalyProperties().customer_dirt_rate = customerDirtRateMulitplier;
	}

	protected override void OnEffectReverse()
	{
		AnomalyManager.GetAnomalyProperties().customer_dirt_rate = AnomalyProperties.GetDefaultProperties().customer_dirt_rate;
	}
}
