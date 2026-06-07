using UnityEngine;

[RequireComponent(typeof(MultiThruster))]
public class MultiThrusterStylesApplier : StylesApplierBase
{
	private MultiThrusterAudioEffect multiThrusterAudioEffect;

	private MultiThrusterVisualEffect multiThrusterVisualEffect;

	public override void Initialize()
	{
		if (multiThrusterAudioEffect == null)
		{
			multiThrusterAudioEffect = base.gameObject.AddComponent<MultiThrusterAudioEffect>();
		}
		if (multiThrusterVisualEffect == null)
		{
			multiThrusterVisualEffect = base.gameObject.AddComponent<MultiThrusterVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		multiThrusterAudioEffect.SetAudiosByGameStyleData(gameStylesData);
		multiThrusterVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
