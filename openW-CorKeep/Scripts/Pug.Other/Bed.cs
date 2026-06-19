using Pug.UnityExtensions;
using UnityEngine;

public class Bed : EntityMonoBehaviour
{
	public Transform visualSleepPosition;

	public Transform sleepPosition;

	public Transform particleSpawnLocation;

	[HideInInspector]
	public int rotationIndex;

	public override void OnOccupied()
	{
		base.OnOccupied();
		rotationIndex = DirectionBasedOnVariationCD.GetVariationFromDirection(base.direction.RoundToInt2());
	}

	public Transform GetSleepingTransform()
	{
		return visualSleepPosition;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 8);
		Manager.effects.PlayPuff(PuffID.WhiteFur, particleSpawnLocation.position, 8);
	}
}
