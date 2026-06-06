using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class RegionNeighborCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private WorldRegionType[] _regionTypes;

		[SerializeField]
		private WorldRegionFlags _excludeFlags;

		public bool IsMet()
		{
			if (!WorldManager.TryReturnCurrentRegion(out var region))
			{
				return false;
			}
			foreach (IWorldRegion neighbor in region.Neighbors)
			{
				if (_regionTypes.Contains(neighbor.Type) && (neighbor.Flags & _excludeFlags) == 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
