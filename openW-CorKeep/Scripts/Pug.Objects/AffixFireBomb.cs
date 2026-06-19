using UnityEngine;

public class AffixFireBomb : Bomb
{
	public ParticleSystem zapSystem;

	public override void OnOccupied()
	{
		base.OnOccupied();
		AudioManager.Sfx(SfxTableID.affixFireBombSfx, base.transform.position);
		EntityUtility.TryGetComponentData<SpawnTickCD>(base.entity, base.world, out var _);
		if (HasRecentlySpawned() && zapSystem != null)
		{
			AffixVisualUtilities.TryTriggerInitialZap(zapSystem, base.entity, base.world, AffixID.AffixFireBomb);
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		zapSystem.Stop();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		zapSystem.Stop();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		AffixVisualUtilities.TryUpdateZap(zapSystem, base.entity, base.world, AffixID.AffixFireBomb);
	}
}
