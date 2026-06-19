using Affixes.Components;
using UnityEngine;

public class AffixElectricOrb : BirdBossBeam
{
	public GameObject projectileSprite;

	public ParticleSystem zapSystem;

	private bool _shouldDisplayZap;

	public override void OnOccupied()
	{
		base.OnOccupied();
		projectileSprite.SetActive(value: false);
		EntityUtility.TryGetComponentData<SpawnTickCD>(base.entity, base.world, out var _);
		EntityUtility.TryGetComponentData<AffixCD>(base.entity, base.world, out var value2);
		_shouldDisplayZap = value2.dispalyConnectionToOwner;
		if (_shouldDisplayZap && HasRecentlySpawned() && zapSystem != null)
		{
			AffixVisualUtilities.TryTriggerInitialZap(zapSystem, base.entity, base.world, AffixID.AffixElectricOrb);
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

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1587601938)
		{
			projectileSprite.SetActive(value: true);
		}
		if (animID == 16528305)
		{
			projectileSprite.SetActive(value: false);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (_shouldDisplayZap)
		{
			AffixVisualUtilities.TryUpdateZap(zapSystem, base.entity, base.world, AffixID.AffixElectricOrb);
		}
	}
}
