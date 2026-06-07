using UnityEngine;

[RequireComponent(typeof(Buzzer))]
public class BuzzerStylesApplier : StylesApplierBase
{
	private BuzzerAudioEffect buzzerAudioEffect;

	public override void Initialize()
	{
		if (buzzerAudioEffect == null)
		{
			buzzerAudioEffect = base.gameObject.AddComponent<BuzzerAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		buzzerAudioEffect.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
