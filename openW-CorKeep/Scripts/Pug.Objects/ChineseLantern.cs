using UnityEngine;

public class ChineseLantern : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			position = particleOptions.particleSpawnLocations[0].position;
		}
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 3);
		Manager.effects.PlayPuff(PuffID.FireFloaters, position, 5);
		Manager.effects.PlayPuff(PuffID.Sparks, position, 5);
	}
}
