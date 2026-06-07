using System;
using System.Collections.Generic;
using M4.Session;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[CreateAssetMenu(fileName = "Starting Scenario", menuName = "Flotsam/Scenarios/Start")]
	public class StartingScenario : ScenarioBase
	{
		[Serializable]
		public class PersistentData : PersistentDataBase
		{
			private int _triggerIndex = -1;

			public PersistentData(StartingScenario instance)
				: base(instance)
			{
				_triggerIndex = instance._triggerIndex;
			}

			public override ScenarioBase Restore(PrototypeScenario fallbackScenario = null)
			{
				if (base.Restore(fallbackScenario) is StartingScenario startingScenario)
				{
					startingScenario._triggerIndexToRestore = Mathf.Max(1, _triggerIndex);
					return startingScenario;
				}
				return null;
			}
		}

		[SerializeReference]
		[InstantiateSerializeReference]
		private List<ScenarioTriggerableBase> _triggerables = new List<ScenarioTriggerableBase>();

		[SerializeField]
		private ScenarioBase _nextScenario;

		[Header("Editor Settings")]
		[SerializeField]
		[Min(0f)]
		[Tooltip("The amount of drifters that should be spawned when the scenario starts. If 0 the new game panel is triggered.")]
		private int _startingDrifterCount = 3;

		[SerializeField]
		[Min(0f)]
		[Tooltip("The index that should be triggered when the scenario starts. Only triggers if 'Starting Drifter Count' > 0. when 'Triggerables' count <= index, 'Next scenario' will be triggered.")]
		private int _startingTriggerableIndex = 2;

		[SerializeReference]
		[InstantiateSerializeReference]
		[Tooltip("It sometimes can usefull to add triggers to the starting scenario while testing.")]
		private IScenarioTrigger[] _triggers;

		private int _triggerIndex = -1;

		private int _triggerIndexToRestore = -1;

		private ScenarioTriggerableBase _currentTriggerable;

		public override void OnFirstStart()
		{
			if (Session.Profile.ActiveRun.IsDebugRun)
			{
				IScenarioTrigger[] triggers = _triggers;
				for (int i = 0; i < triggers.Length; i++)
				{
					triggers[i].Initialize();
				}
				if (0 < _startingDrifterCount)
				{
					for (int j = 0; j < _startingDrifterCount; j++)
					{
						GameManager.AgentManager.SpawnStartingAgent(AgentDescriptor.CreateInstance());
					}
					if (_startingTriggerableIndex < _triggerables.Count)
					{
						Trigger(_startingTriggerableIndex);
					}
					else
					{
						StoryManager.StartScenario(_nextScenario);
					}
					return;
				}
			}
			else if (Session.Profile.ActiveRun.Saves.Count > 0)
			{
				StoryManager.StartScenario(_nextScenario);
				return;
			}
			GameEventDispatcher.AddListener(GameEventType.NewGamePanelClosed, OnNewGamePanelClosed);
			UnityEngine.Object.Instantiate(GameManager.Settings.SessionSettings.StartingScenario.StartMessage).Initialize();
		}

		protected override void OnStart()
		{
			if (_triggerIndexToRestore >= 0)
			{
				Trigger(_triggerIndexToRestore);
			}
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.NewGamePanelClosed, OnNewGamePanelClosed);
			GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnTriggerableScoutTowerRevealDialogueEnded);
			base.Destroy();
		}

		private void TriggerNext()
		{
			int num = _triggerIndex + 1;
			if (num < _triggerables.Count)
			{
				Trigger(num);
			}
			else
			{
				StoryManager.StartScenario(_nextScenario);
			}
		}

		private void Trigger(int index)
		{
			if (index <= _triggerIndex)
			{
				return;
			}
			_triggerIndex = index;
			_currentTriggerable = _triggerables[_triggerIndex];
			if (_currentTriggerable is TriggerableDialogue triggerableDialogue)
			{
				if (triggerableDialogue.TryTrigger())
				{
					triggerableDialogue.EndOfDialogueEvent.AddListener(OnEndOfDialogue);
				}
				else
				{
					TriggerNext();
				}
			}
		}

		private void OnNewGamePanelClosed(GameEvent gameEvent)
		{
			GameEventDispatcher.AddListener(GameEventType.NewGamePanelClosed, OnNewGamePanelClosed);
			TriggerNext();
		}

		private void OnEndOfDialogue(TriggerableDialogue triggerableDialogue)
		{
			triggerableDialogue.EndOfDialogueEvent.RemoveListener(OnEndOfDialogue);
			TriggerNext();
		}

		protected override void OnRegionEntered(GameEvent gameEvent = null)
		{
			base.OnRegionEntered(gameEvent);
			if (gameEvent != null && _currentTriggerable is TriggerableScoutTowerReveal triggerableScoutTowerReveal && triggerableScoutTowerReveal.TryTrigger())
			{
				GameEventDispatcher.RemoveListener(GameEventType.RegionEntered, OnRegionEntered);
				GameEventDispatcher.AddListener(GameEventType.DialogueEnded, OnTriggerableScoutTowerRevealDialogueEnded);
			}
		}

		private void OnTriggerableScoutTowerRevealDialogueEnded(GameEvent gameEvent)
		{
			GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnTriggerableScoutTowerRevealDialogueEnded);
			TriggerNext();
		}

		public override IScenarioPersistentData GetPersistentData()
		{
			return new PersistentData(this);
		}
	}
}
