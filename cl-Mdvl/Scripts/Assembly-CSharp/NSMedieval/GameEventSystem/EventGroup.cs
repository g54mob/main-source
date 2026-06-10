using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Dictionary;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class EventGroup : NSEipix.Base.Model
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private string difficultyOptionId;

		[SerializeField]
		private int baseValue;

		[SerializeField]
		private string[] needUniqueResources;

		[SerializeField]
		private bool skipIfAnyUniqueResourceFound;

		[SerializeField]
		private string activeObjective;

		[SerializeField]
		private NeedResource[] needResources;

		[SerializeField]
		private List<string> events = new List<string>();

		[SerializeField]
		private InterpolatedValueList daysPastMultipliers;

		[SerializeField]
		private InterpolatedValueList workerCountMultipliers;

		[SerializeField]
		private InterpolatedValueList prisonerCountMultipliers;

		[SerializeField]
		private List<string> resetCounters = new List<string>();

		[SerializeField]
		private StringKeyPair seasonMultipliers;

		[SerializeField]
		private StringKeyPair mapTypeMultipliers;

		[NonSerialized]
		private List<GameEvent> gameEvents;

		public InterpolatedValueList DaysPastMultipliers => daysPastMultipliers;

		public InterpolatedValueList WorkerCountMultipliers => workerCountMultipliers;

		public InterpolatedValueList PrisonerCountMultipliers => prisonerCountMultipliers;

		public StringKeyPair SeasonMultipliers => seasonMultipliers;

		public StringKeyPair MapTypeMultipliers => mapTypeMultipliers;

		public List<string> ResetCounters => resetCounters;

		public List<string> Events => events;

		public IEnumerable<GameEvent> GameEvents
		{
			get
			{
				if (gameEvents == null)
				{
					gameEvents = new List<GameEvent>();
				}
				if (events.Count == 0)
				{
					foreach (GameEvent gameEvent in gameEvents)
					{
						if (!gameEvent.IsLocked())
						{
							yield return gameEvent;
						}
					}
					yield break;
				}
				if (gameEvents.Count == 0)
				{
					GameEventSettingsRepository instance = Repository<GameEventSettingsRepository, GameEvent>.Instance;
					foreach (string @event in events)
					{
						GameEvent byID = instance.GetByID(@event);
						if (byID != null)
						{
							gameEvents.Add(byID);
						}
					}
				}
				foreach (GameEvent gameEvent2 in gameEvents)
				{
					if (!gameEvent2.IsLocked())
					{
						yield return gameEvent2;
					}
				}
			}
		}

		public string DifficultyOptionId => difficultyOptionId;

		public int BaseValue => baseValue;

		public string[] NeedUniqueResources => needUniqueResources;

		public bool SkipIfAnyUniqueResourceFound => skipIfAnyUniqueResourceFound;

		public string ActiveObjective => activeObjective;

		public NeedResource[] NeedResources => needResources;

		public override string GetID()
		{
			return id;
		}

		public GameEvent GetEventToStart()
		{
			if (!GameEvents.Any((GameEvent e) => e.HasAnimalType))
			{
				return GameEvents.PickRandom();
			}
			float num = 0f;
			foreach (GameEvent gameEvent in GameEvents)
			{
				num = (gameEvent.HasAnimalType ? (num + gameEvent.GetAnimalEventChance()) : (num + 1f));
			}
			float num2 = UnityEngine.Random.Range(0f, num);
			foreach (GameEvent gameEvent2 in GameEvents)
			{
				float animalEventChance = gameEvent2.GetAnimalEventChance();
				if (!(animalEventChance <= 0f))
				{
					if (num2 <= animalEventChance)
					{
						return gameEvent2;
					}
					num2 -= animalEventChance;
				}
			}
			return null;
		}
	}
}
