using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class ProximityInteractionManager : MonoSingleton<ProximityInteractionManager>
	{
		private readonly IEnumerable<ProximityInteraction> proximityInteractions = new List<ProximityInteraction>
		{
			new ConversationProximityInteraction()
		};

		private Dictionary<ProximityInteractionType, ProximityInteraction> typeInteractionDictionary;

		public Dictionary<ProximityInteractionType, ProximityInteraction> TypeInteractionDictionary
		{
			get
			{
				if (typeInteractionDictionary == null)
				{
					typeInteractionDictionary = new Dictionary<ProximityInteractionType, ProximityInteraction>();
					foreach (ProximityInteraction proximityInteraction in proximityInteractions)
					{
						typeInteractionDictionary.Add(proximityInteraction.InteractionType, proximityInteraction);
					}
				}
				return typeInteractionDictionary;
			}
		}

		public bool AttemptInteraction(ProximityInteractionType proximityInteractionType, CreatureBase agent, CreatureBase target)
		{
			ProximityInteraction proximityInteraction = TypeInteractionDictionary[proximityInteractionType];
			if (proximityInteraction == null)
			{
				return false;
			}
			if (!proximityInteraction.InteractionType.Equals(proximityInteractionType))
			{
				return false;
			}
			if (!proximityInteraction.IsPossible(agent, target))
			{
				return false;
			}
			return proximityInteraction.Execute(agent, target);
		}

		public bool AttemptInteractionSimulation(ProximityInteractionType proximityInteractionType, CreatureBase agent, CreatureBase target)
		{
			ProximityInteraction proximityInteraction = TypeInteractionDictionary[proximityInteractionType];
			if (proximityInteraction == null)
			{
				return false;
			}
			if (!proximityInteraction.InteractionType.Equals(proximityInteractionType))
			{
				return false;
			}
			return proximityInteraction.Execute(agent, target);
		}

		public void SimulateInteractions(List<CreatureBase> creatures, float periodInHours)
		{
			List<HumanoidInstance> list = new List<HumanoidInstance>();
			foreach (CreatureBase creature in creatures)
			{
				if (creature is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					list.Add(humanoidInstance);
				}
			}
			if (list.Count <= 1)
			{
				return;
			}
			foreach (HumanoidInstance item in list)
			{
				int num = (int)(periodInHours / item.WorkerBehaviour.WorkerProximity.GetInteractionTimeoutDefault(ProximityInteractionType.Conversation));
				for (int i = 1; i < num; i++)
				{
					HumanoidInstance randomOtherThan = list.GetRandomOtherThan(item);
					if (randomOtherThan == null)
					{
						continue;
					}
					float value = randomOtherThan.Stats.GetAttributeInstance(AttributeType.ConversationAvailabilityChance).Value;
					float num2 = Random.Range(0f, 1f);
					if (!(num2 > value))
					{
						HumanoidInstance target = randomOtherThan;
						HumanoidInstance agent = item;
						if (num2 > 0.5f)
						{
							target = item;
							agent = randomOtherThan;
						}
						AttemptInteractionSimulation(ProximityInteractionType.Conversation, agent, target);
					}
				}
			}
		}
	}
}
