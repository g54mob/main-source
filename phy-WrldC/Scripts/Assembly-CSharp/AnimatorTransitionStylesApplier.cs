using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorTransitionStylesApplier : StylesApplierBase
{
	private AnimatorTransitionAudioEffect animatorTransitionAudio;

	public override void Initialize()
	{
		animatorTransitionAudio = GetComponent<AnimatorTransitionAudioEffect>();
		if (animatorTransitionAudio == null)
		{
			animatorTransitionAudio = base.gameObject.AddComponent<AnimatorTransitionAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		animatorTransitionAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
