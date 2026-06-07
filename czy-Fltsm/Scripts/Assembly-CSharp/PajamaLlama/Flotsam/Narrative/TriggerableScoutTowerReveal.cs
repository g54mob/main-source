using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableScoutTowerReveal : ScenarioTriggerableBase
	{
		[SerializeField]
		private DialogueTrigger _prePanDialogue;

		[SerializeField]
		private DialogueTrigger _postPanDialogue;

		protected override bool Trigger(AgentDescriptor actorDescriptor)
		{
			if (WorldManager.TryReturnCurrentRegion(out var region) && region.TryReturnScoutingLandmark(out var scoutingLandmark))
			{
				RevealSpawnerEvent.Dispatch(scoutingLandmark, _prePanDialogue, _postPanDialogue);
				return true;
			}
			return false;
		}
	}
}
