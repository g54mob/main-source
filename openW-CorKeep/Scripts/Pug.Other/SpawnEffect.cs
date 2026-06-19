using UnityEngine;

public class SpawnEffect : PoolableSimple
{
	public Transform xScaler;

	public override void OnOccupied()
	{
		WaterSim.AddImpulse(xScaler.position, 3f);
	}
}
