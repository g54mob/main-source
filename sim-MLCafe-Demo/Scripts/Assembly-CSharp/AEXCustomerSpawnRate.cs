using System;

[Serializable]
public class AEXCustomerSpawnRate : AnomalyEffect
{
	private float customerSpawnRateMulitplier = 1f;

	public AEXCustomerSpawnRate(float multiplier, EffectType effectType)
	{
		index = 1;
		base.effectType = effectType;
		customerSpawnRateMulitplier = multiplier;
		SetName("ui_anomaly_effect_name_customerspawnrate");
		SetMessage("ui_anomaly_effect_msg_customerspawnrate_positive", "ui_anomaly_effect_msg_customerspawnrate_negative");
	}

	protected override void OnEffectAction()
	{
		AnomalyManager.GetAnomalyProperties().customer_spawnrate_multiplier = customerSpawnRateMulitplier;
	}

	protected override void OnEffectReverse()
	{
		AnomalyManager.GetAnomalyProperties().customer_spawnrate_multiplier = AnomalyProperties.GetDefaultProperties().customer_spawnrate_multiplier;
	}
}
