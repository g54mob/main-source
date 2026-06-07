using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableScoutQuest : TriggerableQuest
	{
		[Header("Scouting Settings")]
		[SerializeField]
		private WorldRegionType[] _regionTypes;

		[SerializeField]
		private WorldRegionFlags _regionExcludeFlags;

		protected override bool Trigger(AgentDescriptor actor = null)
		{
			if (!WorldManager.TryReturnCurrentRegion(out var region))
			{
				return false;
			}
			foreach (IWorldRegion neighbor in region.Neighbors)
			{
				if (_regionTypes.Contains(neighbor.Type) && (neighbor.Flags & _regionExcludeFlags) == 0)
				{
					return base.Trigger(actor);
				}
			}
			return false;
		}
	}
}
