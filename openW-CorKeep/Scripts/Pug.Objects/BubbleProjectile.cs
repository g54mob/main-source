using UnityEngine;

public class BubbleProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.PlayPuff(PuffID.SlipperyPuff, position + new Vector3(0f, 0.125f, 0f), 20);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.BlueSplat2, position + new Vector3(0f, 0.5f, 0f));
	}
}
