using UnityEngine;

[RequireComponent(typeof(DynamicSpring))]
public class DynamicSpringStylerApplier : StylesApplierBase
{
	private DynamicSpringAudioEffect dynamicSpringAudioEffect;

	private DynamicSpringVisualEffect dynamicSpringVisualEffect;

	public override void Initialize()
	{
		if (dynamicSpringAudioEffect == null)
		{
			dynamicSpringAudioEffect = base.gameObject.AddComponent<DynamicSpringAudioEffect>();
		}
		if (dynamicSpringVisualEffect == null)
		{
			dynamicSpringVisualEffect = base.gameObject.AddComponent<DynamicSpringVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		dynamicSpringAudioEffect.SetAudiosByGameStyleData(gameStylesData);
		dynamicSpringVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
