public class SpriteFrameSfx : ASpriteFrameEffect
{
	public string sfxId;

	public float delay;

	public override void ExecuteEffect(AsciiSprite sprite, AsciiRenderProcedural r)
	{
		SfxController.singleton.Play(sfxId, ignoreDuplicateSfxInSameFrame: true, delay);
	}
}
