using UnityEngine;

[RequireComponent(typeof(LinearStage))]
public class LinearStageStylesApplier : StylesApplierBase
{
	private LinearStageAudioEffect linearStageAudio;

	public override void Initialize()
	{
		if (linearStageAudio == null)
		{
			linearStageAudio = base.gameObject.AddComponent<LinearStageAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		linearStageAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
