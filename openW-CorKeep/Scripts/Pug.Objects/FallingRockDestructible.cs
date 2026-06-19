using UnityEngine;

public class FallingRockDestructible : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
			Vector3 vector = new Vector3(0f, 3f, -3f);
			Manager.effects.ExploDisc(variationsParticleSpawnLocation.position + vector, 0.5f);
		}
	}
}
