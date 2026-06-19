using UnityEngine;

public class CherryTreeWhite : EntityMonoBehaviour
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
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, position, 8);
			Manager.effects.PlayPuff(PuffID.CherryWhiteLeafDebris, position + new Vector3(0f, 2f, 0f));
			Manager.effects.PlayPuff(PuffID.CherryWhiteLeafBlockDebrisBox, position + new Vector3(0f, 2f, 0f), 20);
			Manager.effects.PlayPuff(PuffID.WoodDebris, position);
		}
	}
}
