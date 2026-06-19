using UnityEngine;

public class ExcavationBrokenRobotDecorationPatroller : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.MetalBreakGold, particleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.MetalBreak, particleSpawnLocation.position, 6);
	}
}
