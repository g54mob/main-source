using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using Unity.Collections;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[CreateAssetMenu(fileName = "Tutorial Scenario", menuName = "Flotsam/Scenarios/Tutorial")]
	public class TutorialScenario : ScenarioBase
	{
		[Serializable]
		public class PersistentData : PersistentDataBase
		{
			private readonly int _questsCompletedCount;

			public PersistentData(TutorialScenario instance)
				: base(instance)
			{
				_questsCompletedCount = instance._questsCompletedCount;
			}

			public void Restore(ScenarioBase scenario)
			{
				if (scenario is TutorialScenario tutorialScenario)
				{
					tutorialScenario._questsCompletedCount = _questsCompletedCount;
				}
			}
		}

		[SerializeReference]
		[InstantiateSerializeReference]
		private List<IScenarioTrigger> _triggers = new List<IScenarioTrigger>();

		[SerializeField]
		[Tooltip("This list does not handle triggering them, it's only used to see if we completed them all. To trigger them, please use the Triggers list.")]
		private List<QuestProperties> _tutorialsToComplete = new List<QuestProperties>();

		[SerializeField]
		private ScenarioBase _nextScenario;

		[SerializeField]
		private List<AgentProfile> _firstDriftersPool = new List<AgentProfile>();

		[SerializeField]
		[Tooltip("The maximum durationof the tutorial in days. After the Max Duration the next scenario will be triggered")]
		private int _maxDuration = 25;

		[NonSerialized]
		private int _questsCompletedCount;

		public override void OnFirstStart()
		{
			SpawnTownheartAndStartingResources();
			base.WorldTileProvider.QueueStartTiles();
			SpawnStartingDrifters();
		}

		protected override void OnStart()
		{
			if (AreTutorialQuestsCompleted())
			{
				StartNextScenario();
				return;
			}
			GameEventDispatcher.AddListener(GameEventType.CompletedQuestsUpdated, OnCompletedQuestsUpdated);
			GameEventDispatcher.AddListener(GameEventType.DayEnded, OnDayEnded);
			foreach (IScenarioTrigger trigger in _triggers)
			{
				trigger.Initialize();
			}
			if (!base.Restored)
			{
				GameEventDispatcher.Dispatch(GameEventType.NarrativeStart);
			}
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.RegionEntered, OnRegionEntered);
			GameEventDispatcher.RemoveListener(GameEventType.QuestCompleted, OnCompletedQuestsUpdated);
			GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnDayEnded);
			base.Destroy();
		}

		public override void QueueWorldTile(TileGeneratorBase worldTile, int indexOffset = 0, int minimumIndex = 0)
		{
			base.WorldTileProvider.QueueWorldTile(worldTile, indexOffset, minimumIndex);
		}

		private void SpawnStartingDrifters()
		{
			int i = 0;
			int inhabitants = GameManager.Settings.SessionSettings.StartingScenario.Inhabitants;
			if (!_firstDriftersPool.IsNullOrEmpty())
			{
				i = Mathf.Min(_firstDriftersPool.Count, inhabitants);
				if (_firstDriftersPool.Count <= inhabitants)
				{
					SpawnAllDrifters();
				}
				else
				{
					SpawnRandomDrifters(inhabitants);
				}
			}
			for (; i < inhabitants; i++)
			{
				GameManager.AgentManager.SpawnStartingAgent(AgentDescriptor.CreateInstance());
			}
		}

		private void SpawnAllDrifters()
		{
			foreach (AgentProfile item in _firstDriftersPool)
			{
				GameManager.AgentManager.SpawnStartingAgent(item.GetDescriptor());
			}
		}

		private void SpawnRandomDrifters(int count)
		{
			using ListPool<AgentProfile>.List list = ListPool<AgentProfile>.Get(_firstDriftersPool);
			for (int i = 0; i < count; i++)
			{
				int randomIndex = list.GetRandomIndex();
				AgentProfile agentProfile = list[randomIndex];
				GameManager.AgentManager.SpawnStartingAgent(agentProfile.GetDescriptor());
				list.RemoveAtSwapBack(randomIndex);
			}
		}

		private void OnCompletedQuestsUpdated(GameEvent gameEvent)
		{
			if (AreTutorialQuestsCompleted())
			{
				StartNextScenario();
			}
		}

		private void OnDayEnded(GameEvent gameEvent)
		{
			if (gameEvent is DayEvent dayEvent && dayEvent.Days.Count > _maxDuration)
			{
				Debug.LogException(new Exception($"The tutorial surpassed its maximum duarion of {_maxDuration} days."));
				StartNextScenario();
			}
			else
			{
				OnCompletedQuestsUpdated(null);
			}
		}

		private void StartNextScenario()
		{
			Destroy();
			if (_nextScenario != null)
			{
				StoryManager.StartScenario(_nextScenario);
			}
			else
			{
				Debug.LogException(new Exception("Unable to start next scenario because its is NULL"));
			}
		}

		private bool AreTutorialQuestsCompleted()
		{
			if (_tutorialsToComplete.IsNullOrEmpty())
			{
				return true;
			}
			foreach (QuestProperties item in _tutorialsToComplete)
			{
				if (!StoryManager.IsQuestCompleted(item))
				{
					return false;
				}
			}
			return true;
		}

		public override IScenarioPersistentData GetPersistentData()
		{
			return new PersistentData(this);
		}
	}
}
