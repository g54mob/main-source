public class AnimationTimeSfx : AAnimationTimeEffect
{
	public string sfxId;

	public float delay;

	public override void ExecuteEffect(AsciiAnimation animation, AsciiSprite sprite, AsciiRenderProcedural r)
	{
		SfxController.singleton.Play(sfxId, ignoreDuplicateSfxInSameFrame: true, delay);
	}
}
