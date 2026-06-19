using UnityEngine;

public class ExcavationBrokenRobotDecorationSwarmer : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.MetalBreakSmallGold, particleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.MetalBreakSmall, particleSpawnLocation.position, 6);
	}
}
