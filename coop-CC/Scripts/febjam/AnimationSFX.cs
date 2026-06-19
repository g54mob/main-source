using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class AnimationSFX : EntityBehaviourBase
{
	private Transform _transform;

	public PlayerUpgrades playerUpgrades;

	public StudioEventEmitter forkGrabSFX;

	public StudioEventEmitter forkGrabSFXUpgraded;

	private void Awake()
	{
		_transform = base.transform;
	}

	public void PlaySpatialSFX(string ev)
	{
		AudioManager.PlaySfx(RuntimeManager.PathToEventReference(ev), _transform);
	}

	public void PlaySFX(string ev)
	{
		AudioManager.PlaySfx(RuntimeManager.PathToEventReference(ev));
	}

	public void PlayForkGrabSFX()
	{
		if (!playerUpgrades.HasUpgrade(PlayerUpgrade.StrongGrabbers))
		{
			forkGrabSFX.Play();
		}
		else
		{
			forkGrabSFXUpgraded.Play();
		}
	}
}
