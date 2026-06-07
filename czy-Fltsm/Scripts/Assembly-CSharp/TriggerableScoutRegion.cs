using System;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[Serializable]
public class TriggerableScoutRegion : ScenarioTriggerableBase
{
	private enum Mode
	{
		Current = 0,
		CurrentAndNeighbors = 1,
		CurrentTypeInTile = 2,
		CurrentAndTypeInTile = 3
	}

	[SerializeField]
	private Mode _mode;

	[SerializeField]
	[ConditionalEnumHide("_mode", 3, true)]
	private WorldRegionType _region;

	protected override bool Trigger(AgentDescriptor actorDescriptor)
	{
		if (!WorldManager.TryReturnCurrentRegion(out var region))
		{
			return false;
		}
		switch (_mode)
		{
		case Mode.Current:
			region.Scout(null, scoutNeighbors: false);
			break;
		case Mode.CurrentAndNeighbors:
			region.Scout(null);
			break;
		case Mode.CurrentTypeInTile:
			foreach (IWorldRegion region2 in region.WorldTile.Regions)
			{
				if (region2.Type == region.Type)
				{
					region2.Scout(null, scoutNeighbors: false);
				}
			}
			break;
		case Mode.CurrentAndTypeInTile:
			foreach (IWorldRegion region3 in region.WorldTile.Regions)
			{
				if (region3 == region || region3.Type == _region)
				{
					region3.Scout(null, scoutNeighbors: false);
				}
			}
			break;
		}
		return true;
	}
}
