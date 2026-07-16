using System;
using UnityEngine;

public class ModuleFactory : Module
{
	[SerializeField]
	[Range(0f, 1f)]
	private float gainPercentLossIfBroken;

	private bool canFillCoal;

	[NonSerialized]
	public float gainModifier = 1f;

	[field: SerializeField]
	public float AmmoGain { get; set; } = 20f;

	[field: SerializeField]
	public float ScrapGain { get; set; } = 20f;

	public bool CanFillCoalOncePerLevel { get; set; }

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		return canFillCoal;
	}

	protected override void HandleLevelStarted()
	{
		base.HandleLevelStarted();
		canFillCoal = CanFillCoalOncePerLevel;
	}

	protected override void HandleLevelCompleted()
	{
		base.HandleLevelCompleted();
		if (!LevelManager.Instance.DestinationReachedOnLoad)
		{
			if (base.IsFullyBroken)
			{
				AddResource(AmmoGain * gainModifier * gainPercentLossIfBroken, ResourceTypes.Ammo);
				AddResource(ScrapGain * gainModifier * gainPercentLossIfBroken, ResourceTypes.Scrap);
			}
			else
			{
				AddResource(AmmoGain * gainModifier, ResourceTypes.Ammo);
				AddResource(ScrapGain * gainModifier, ResourceTypes.Scrap);
			}
			SaveManager.Instance.SaveJourney();
		}
	}

	protected override void OnInteractStart(Interactor interactor)
	{
		base.OnInteractStart(interactor);
		canFillCoal = false;
		Train.Instance.CoalSeconds = Train.Instance.CoalSecondsCapacity;
	}

	protected override void OnFix(HealthChangeInfo info)
	{
		base.OnFix(info);
		anim.Play("On");
	}

	protected override void OnFullyBroken()
	{
		base.OnFullyBroken();
		anim.Play("Off");
	}

	public override void AddResource(float amount, ResourceTypes resourceType)
	{
		UpdateMainStat(amount);
		base.AddResource(amount, resourceType);
	}
}
