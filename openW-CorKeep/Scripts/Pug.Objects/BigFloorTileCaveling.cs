using UnityEngine;

public class BigFloorTileCaveling : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			position = particleOptions.particleSpawnLocations[0].position;
		}
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, position, 12);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, position, 4);
	}
}
