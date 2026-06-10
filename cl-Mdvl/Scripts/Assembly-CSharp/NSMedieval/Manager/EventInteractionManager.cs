using System;
using System.Collections.Generic;
using System.Reflection;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.State;
using Social;

namespace NSMedieval.Manager
{
	public class EventInteractionManager : MonoSingleton<EventInteractionManager>
	{
		private Dictionary<EventInteractionType, EventInteraction> typeInteractionDictionary;

		private Dictionary<EventInteractionType, EventInteraction> TypeInteractionDictionary
		{
			get
			{
				if (typeInteractionDictionary == null)
				{
					typeInteractionDictionary = new Dictionary<EventInteractionType, EventInteraction>();
					Type[] types = Assembly.GetAssembly(typeof(EventInteraction)).GetTypes();
					foreach (Type type in types)
					{
						if (type.IsSubclassOf(typeof(EventInteraction)))
						{
							EventInteraction eventInteraction = (EventInteraction)Activator.CreateInstance(type);
							typeInteractionDictionary.Add(eventInteraction.InteractionType, eventInteraction);
						}
					}
				}
				return typeInteractionDictionary;
			}
		}

		public void InitializeGlobalChances()
		{
			foreach (EventInteractionTypeFloatPair eventInteractionGlobalChance in Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings().EventInteractionGlobalChances)
			{
				if (!GlobalSaveController.CurrentVillageData.InteractionTypeGlobalChance.ContainsKey(eventInteractionGlobalChance.Key))
				{
					GlobalSaveController.CurrentVillageData.InteractionTypeGlobalChance.Add(eventInteractionGlobalChance.Key, eventInteractionGlobalChance.Value);
				}
			}
		}

		public bool AttemptBeliefChange(string eventId, CreatureBase agent)
		{
			if (!GetEventData(eventId, out var data, out var eventInteraction))
			{
				return false;
			}
			if (!eventInteraction.IsPossible(agent))
			{
				return false;
			}
			return eventInteraction.Execute(agent, data);
		}

		public bool AttemptInteraction(string eventId, CreatureBase agent)
		{
			if (!GetEventData(eventId, out var data, out var eventInteraction))
			{
				return false;
			}
			if (!eventInteraction.IsPossible(agent, out var target))
			{
				return false;
			}
			return eventInteraction.Execute(agent, target, data);
		}

		public bool AttemptInteraction(string eventId, CreatureBase agent, CreatureBase target)
		{
			if (!GetEventData(eventId, out var data, out var eventInteraction))
			{
				return false;
			}
			if (!eventInteraction.IsPossible(agent, target))
			{
				return false;
			}
			return eventInteraction.Execute(agent, target, data);
		}

		public bool AttemptInteraction(string eventId, CreatureBase agent, ProducedItemData producedItemData)
		{
			if (!GetEventData(eventId, out var data, out var eventInteraction))
			{
				return false;
			}
			if (!eventInteraction.IsPossible(agent, producedItemData.ProducerUniqueId, out var target))
			{
				return false;
			}
			return eventInteraction.Execute(agent, target, data, producedItemData.ItemName);
		}

		private bool GetEventData(string eventId, out EventInteractionData data, out EventInteraction eventInteraction)
		{
			eventInteraction = null;
			if (!Repository<EventInteractionDataRepository, EventInteractionData>.Instance.TryGetValue(eventId, out data))
			{
				return false;
			}
			eventInteraction = TypeInteractionDictionary[data.InteractionType];
			if (eventInteraction == null)
			{
				return false;
			}
			return true;
		}
	}
}
