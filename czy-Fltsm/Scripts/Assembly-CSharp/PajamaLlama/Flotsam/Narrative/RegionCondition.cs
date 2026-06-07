using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class RegionCondition : IScenarioTriggerableCondition
	{
		private enum Mode
		{
			Current = 0,
			CurrentNeighors = 1,
			CurrentAndNeighbors = 2,
			RegionTriggers = 3
		}

		[SerializeField]
		private Mode _mode;

		[SerializeField]
		private WorldRegionType[] _regions;

		[SerializeField]
		private WorldRegionFlags _excludeFlags;

		[SerializeField]
		[Tooltip("Is this condition used for a triggerable that spawns a Landmark?")]
		private bool _isSpawnCondition = true;

		public bool IsMet()
		{
			IWorldRegion region;
			switch (_mode)
			{
			case Mode.Current:
				if (WorldManager.TryReturnCurrentRegion(out region))
				{
					return IsMatch(region);
				}
				return false;
			case Mode.CurrentNeighors:
				if (WorldManager.TryReturnCurrentRegion(out region))
				{
					return HasMatch(region.Neighbors);
				}
				return false;
			case Mode.CurrentAndNeighbors:
				if (WorldManager.TryReturnCurrentRegion(out region))
				{
					if (!IsMatch(region))
					{
						return HasMatch(region.Neighbors);
					}
					return true;
				}
				return false;
			case Mode.RegionTriggers:
				return HasMatch(RegionTriggers.Regions);
			default:
				Debug.LogException(new NotImplementedException());
				return false;
			}
		}

		private bool HasMatch(IReadOnlyList<IWorldRegion> regions)
		{
			foreach (IWorldRegion region in regions)
			{
				if (IsMatch(region))
				{
					return true;
				}
			}
			return false;
		}

		private bool IsMatch(IWorldRegion region)
		{
			if ((region.Flags & _excludeFlags) == 0 && _regions.Contains(region.Type))
			{
				if (_isSpawnCondition)
				{
					return region.HasUnscoutedDisabledLandmarks();
				}
				return true;
			}
			return false;
		}
	}
}
