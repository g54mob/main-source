using UnityEngine;

public class ExcavationDestructibleWIndSteelIndustrialBox : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Vector3 position = base.transform.position;
			if (particleOptions.particleSpawnLocations.Capacity > 0)
			{
				position = particleOptions.particleSpawnLocations[0].position;
			}
			Manager.effects.PlayPuff(PuffID.MetalBreak, position, 20);
			Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, position, 15);
		}
	}
}
