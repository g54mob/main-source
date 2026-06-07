using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TownWeightTrigger : IScenarioTrigger
	{
		[SerializeField]
		private ScenarioTriggerableBase[] _triggerables;

		public void Initialize()
		{
			ScenarioTriggerableBase[] triggerables = _triggerables;
			for (int i = 0; i < triggerables.Length; i++)
			{
				if (!triggerables[i].WasTriggered)
				{
					GameEventDispatcher.AddListener(GameEventType.WeightTierUpdated, OnWeightTierUpdated);
					break;
				}
			}
		}

		public void Uninitialize()
		{
			GameEventDispatcher.RemoveListener(GameEventType.WeightTierUpdated, OnWeightTierUpdated);
		}

		private void TryUninitialize()
		{
			ScenarioTriggerableBase[] triggerables = _triggerables;
			for (int i = 0; i < triggerables.Length; i++)
			{
				if (!triggerables[i].WasTriggered)
				{
					return;
				}
			}
			GameEventDispatcher.AddListener(GameEventType.WeightTierUpdated, OnWeightTierUpdated);
		}

		private void OnWeightTierUpdated(GameEvent gameEvent)
		{
			if (!(gameEvent is WeightEvent))
			{
				return;
			}
			ScenarioTriggerableBase[] triggerables = _triggerables;
			for (int i = 0; i < triggerables.Length; i++)
			{
				if (triggerables[i].TryTrigger())
				{
					TryUninitialize();
				}
			}
		}
	}
}
