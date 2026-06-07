using UnityEngine;

[RequireComponent(typeof(GoToTarget))]
public class GoToTargetStylesApplier : StylesApplierBase
{
	private GoToTargetAudioEffect goToTargetAudio;

	public override void Initialize()
	{
		goToTargetAudio = GetComponent<GoToTargetAudioEffect>();
		if (goToTargetAudio == null)
		{
			goToTargetAudio = base.gameObject.AddComponent<GoToTargetAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		goToTargetAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
