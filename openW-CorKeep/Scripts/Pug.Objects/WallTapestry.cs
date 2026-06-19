using UnityEngine;

public class WallTapestry : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	public override Vector3 center => GetCenter();

	private Vector3 GetCenter()
	{
		return objectVariants[base.variation].objectsToEnable[0].transform.position;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 4);
	}
}
