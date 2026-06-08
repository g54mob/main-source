public class AnimationTimeCameraShake : AAnimationTimeEffect
{
	public float shakeAmount = 2f;

	public float shakeDuration = 0.2f;

	public override void ExecuteEffect(AsciiAnimation animation, AsciiSprite sprite, AsciiRenderProcedural r)
	{
		CameraShake.singleton.ShakeCamera(shakeAmount, shakeDuration);
	}
}
