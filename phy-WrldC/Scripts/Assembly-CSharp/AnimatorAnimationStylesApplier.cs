public class AnimatorAnimationStylesApplier : StylesApplierBase
{
	private AnimatorAnimationAudioEffect animatorAnimationAudio;

	public override void Initialize()
	{
		animatorAnimationAudio = GetComponent<AnimatorAnimationAudioEffect>();
		if (animatorAnimationAudio == null)
		{
			animatorAnimationAudio = base.gameObject.AddComponent<AnimatorAnimationAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		animatorAnimationAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
