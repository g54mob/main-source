using UnityEngine;

public class Calendar : EntityMonoBehaviour
{
	public override Vector3 center => GetCenter();

	private Vector3 GetCenter()
	{
		return objectVariants[base.variation].objectsToEnable[0].transform.position;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 2);
		Manager.effects.PlayPuff(PuffID.FireFloaters, particleOptions.particleSpawnLocations[0].position, 5);
		Manager.effects.PlayPuff(PuffID.SparksMachine, particleOptions.particleSpawnLocations[0].position, 2);
	}
}
