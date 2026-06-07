using UnityEngine;

[RequireComponent(typeof(AnimatorTriggeredByButton))]
public class AnimatorByButtonStylesApplier : StylesApplierBase
{
	private AnimatorByButtonAudioEffect animatorByButtonAudio;

	public override void Initialize()
	{
		animatorByButtonAudio = GetComponent<AnimatorByButtonAudioEffect>();
		if (animatorByButtonAudio == null)
		{
			animatorByButtonAudio = base.gameObject.AddComponent<AnimatorByButtonAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		animatorByButtonAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
