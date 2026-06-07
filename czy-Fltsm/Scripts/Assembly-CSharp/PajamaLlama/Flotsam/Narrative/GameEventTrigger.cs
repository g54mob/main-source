using System;
using PajamaLlama.Attributes;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class GameEventTrigger : IScenarioTrigger
	{
		[SerializeField]
		[SearchablePopup]
		private GameEventType _gameEvent;

		[SerializeReference]
		[InstantiateSerializeReference]
		private ScenarioTriggerableBase _triggerable;

		public void Initialize()
		{
			if (!_triggerable.WasTriggered)
			{
				GameEventDispatcher.AddListener(_gameEvent, OnGameEvent);
			}
		}

		public void Uninitialize()
		{
			GameEventDispatcher.RemoveListener(_gameEvent, OnGameEvent);
		}

		private void OnGameEvent(GameEvent gameEvent)
		{
			if (_triggerable.TryTrigger())
			{
				Uninitialize();
			}
		}
	}
}
