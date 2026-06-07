using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableWorldTile : ScenarioTriggerableBase
	{
		[SerializeField]
		private TileGeneratorBase _tile;

		[SerializeField]
		[Min(0f)]
		private int _indexOffset;

		[SerializeField]
		private int _minimumIndex;

		protected override bool Trigger(AgentDescriptor actorDescriptor)
		{
			if ((bool)_tile)
			{
				StoryManager.QueueWorldTile(_tile, _indexOffset, _minimumIndex);
				Debug.Log($"WorldTile '{_tile.name}' was queued with index offset {_indexOffset}");
				return true;
			}
			return false;
		}
	}
}
