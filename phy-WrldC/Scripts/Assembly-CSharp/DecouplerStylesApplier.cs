using UnityEngine;

[RequireComponent(typeof(Decoupler))]
public class DecouplerStylesApplier : StylesApplierBase
{
	private DecouplerAudioEffect decouplerAudio;

	private DecouplerVisualEffect decouplerVisualEffect;

	public override void Initialize()
	{
		if (decouplerAudio == null)
		{
			decouplerAudio = base.gameObject.AddComponent<DecouplerAudioEffect>();
		}
		if (decouplerVisualEffect == null)
		{
			decouplerVisualEffect = base.gameObject.AddComponent<DecouplerVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		decouplerAudio.SetAudiosByGameStyleData(gameStylesData);
		decouplerVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
