using UnityEngine;

[RequireComponent(typeof(SolidRocket))]
public class SolidRocketStylesApplier : StylesApplierBase
{
	private SolidRocketAudioEffect solidRocketAudioEffect;

	private SolidRocketVisualEffect solidRocketVisualEffect;

	public override void Initialize()
	{
		if (solidRocketAudioEffect == null)
		{
			solidRocketAudioEffect = base.gameObject.AddComponent<SolidRocketAudioEffect>();
		}
		if (solidRocketVisualEffect == null)
		{
			solidRocketVisualEffect = base.gameObject.AddComponent<SolidRocketVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		solidRocketAudioEffect.SetAudiosByGameStyleData(gameStylesData);
		solidRocketVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
