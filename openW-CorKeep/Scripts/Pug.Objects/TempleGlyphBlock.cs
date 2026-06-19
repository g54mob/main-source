using UnityEngine;

public class TempleGlyphBlock : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, particleSpawnLocation.position, 12);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, particleSpawnLocation.position, 4);
	}
}
