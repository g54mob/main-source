using UnityEngine;

public class EasterMeadowTable : Table
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			position = particleOptions.particleSpawnLocations[0].position;
		}
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, position, 8);
	}
}
