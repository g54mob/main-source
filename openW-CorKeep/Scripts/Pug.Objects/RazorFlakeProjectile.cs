using UnityEngine;

public class RazorFlakeProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
		Manager.effects.PlayPuff(PuffID.DirtItemDust, vector + SRPivot.localPosition + vector2, 5);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		Manager.effects.ExploDisc(SRPivot.position, 0.25f);
	}
}
