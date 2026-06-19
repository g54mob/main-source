using UnityEngine;

public class RuinsPiece1 : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		if (particleOptions.particleSpawnLocations.Count > 0)
		{
			position = particleOptions.particleSpawnLocations[0].position;
		}
		Manager.effects.PlayPuff(PuffID.PotDebris, position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, position, 25);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebrisBox, position, 25);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, position, 15);
	}
}
