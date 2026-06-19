public class PlumeTree : Tree
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f);
		}
	}
}
