using UnityEngine;

public class NatureBones : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
			Manager.effects.PlayPuff(PuffID.SmallWhitePuff, variationsParticleSpawnLocation.position, 15);
		}
	}
}
