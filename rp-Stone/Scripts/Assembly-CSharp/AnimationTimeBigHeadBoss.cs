public class AnimationTimeBigHeadBoss : AAnimationTimeEffect
{
	public float seeingBossDuration = 2f;

	public override void ExecuteEffect(AsciiAnimation animation, AsciiSprite sprite, AsciiRenderProcedural r)
	{
		BigHead.seeingBossTime = seeingBossDuration;
	}
}
