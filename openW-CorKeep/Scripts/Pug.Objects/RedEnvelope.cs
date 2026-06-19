using UnityEngine;

public class RedEnvelope : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, particleSpawnLocation.position, 5);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f);
		}
	}
}
