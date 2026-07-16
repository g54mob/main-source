using System;

[Serializable]
public class AEXQueueDuration : AnomalyEffect
{
	private float waitCountMulitplier = 1f;

	public AEXQueueDuration(float multiplier, EffectType effectType)
	{
		index = 0;
		base.effectType = effectType;
		waitCountMulitplier = multiplier;
		SetName("ui_anomaly_effect_name_queueduration");
		SetMessage("ui_anomaly_effect_msg_queueduration_positive", "ui_anomaly_effect_msg_queueduration_negative");
	}

	protected override void OnEffectAction()
	{
		AnomalyManager.GetAnomalyProperties().customer_waitcount_multiplier = waitCountMulitplier;
	}

	protected override void OnEffectReverse()
	{
		AnomalyManager.GetAnomalyProperties().customer_waitcount_multiplier = AnomalyProperties.GetDefaultProperties().customer_waitcount_multiplier;
	}
}
