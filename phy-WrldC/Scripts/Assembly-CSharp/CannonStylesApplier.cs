using UnityEngine;

[RequireComponent(typeof(Cannon))]
public class CannonStylesApplier : StylesApplierBase
{
	private CannonAudioEffect cannonAudio;

	private CannonVisualEffect cannonVisual;

	public override void Initialize()
	{
		if (cannonAudio == null)
		{
			cannonAudio = base.gameObject.AddComponent<CannonAudioEffect>();
		}
		if (cannonVisual == null)
		{
			cannonVisual = base.gameObject.AddComponent<CannonVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		cannonAudio.SetAudiosByGameStyleData(gameStylesData);
		cannonVisual.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
