using UnityEngine;

[RequireComponent(typeof(SteerableBlock))]
public class SteerableBlockStylesApplier : StylesApplierBase
{
	private SteerableBlockAudioEffect steerableBlockAudio;

	public override void Initialize()
	{
		if (steerableBlockAudio == null)
		{
			steerableBlockAudio = base.gameObject.AddComponent<SteerableBlockAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		steerableBlockAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
