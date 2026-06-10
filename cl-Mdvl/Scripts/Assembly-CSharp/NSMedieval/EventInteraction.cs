using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using Social;

namespace NSMedieval
{
	public abstract class EventInteraction
	{
		private readonly Random random = new Random();

		public EventInteractionType InteractionType { get; protected set; }

		private float GlobalChance
		{
			get
			{
				Dictionary<EventInteractionType, float> interactionTypeGlobalChance = GlobalSaveController.CurrentVillageData.InteractionTypeGlobalChance;
				if (interactionTypeGlobalChance.ContainsKey(InteractionType))
				{
					float result = interactionTypeGlobalChance[InteractionType];
					interactionTypeGlobalChance[InteractionType] = 0f;
					return result;
				}
				return 0f;
			}
		}

		public virtual bool IsPossible(CreatureBase agent, int agentUniqueId, out CreatureBase target)
		{
			target = null;
			return false;
		}

		public virtual bool IsPossible(CreatureBase agent, out CreatureBase target)
		{
			target = null;
			return false;
		}

		public virtual bool IsPossible(CreatureBase agent, CreatureBase target)
		{
			return false;
		}

		public virtual bool IsPossible(CreatureBase agent)
		{
			return false;
		}

		public virtual bool Execute(CreatureBase agent, EventInteractionData eventInteractionData)
		{
			return false;
		}

		public virtual bool Execute(CreatureBase agent, CreatureBase target, EventInteractionData eventInteractionData)
		{
			if (!(agent is HumanoidInstance humanoidInstance) || !(target is HumanoidInstance targetInstance))
			{
				return false;
			}
			if (!HasChanceToFireEvent(eventInteractionData))
			{
				return false;
			}
			if (!GetWeightedOutcome(eventInteractionData, out var weightedOutcome))
			{
				return false;
			}
			LifeEventLogStruct eventLog = LifeEventUtils.GetEventLog(weightedOutcome.LogId, humanoidInstance, targetInstance);
			humanoidInstance.LogLifeEvent(eventLog);
			foreach (string item in weightedOutcome.EffectorId)
			{
				humanoidInstance.Stats.StartAffectionEffector(item, target);
			}
			return false;
		}

		public virtual bool Execute(CreatureBase agent, CreatureBase target, EventInteractionData eventInteractionData, string localizedItemId)
		{
			if (!(agent is HumanoidInstance humanoidInstance) || !(target is HumanoidInstance targetInstance))
			{
				return false;
			}
			if (!HasChanceToFireEvent(eventInteractionData))
			{
				return false;
			}
			if (!GetWeightedOutcome(eventInteractionData, out var weightedOutcome))
			{
				return false;
			}
			foreach (string item in weightedOutcome.EffectorId)
			{
				humanoidInstance.Stats.StartAffectionEffector(item, target);
			}
			LifeEventLogStruct producedItemEventLog = LifeEventUtils.GetProducedItemEventLog(weightedOutcome.LogId, humanoidInstance, targetInstance, localizedItemId);
			humanoidInstance.LogLifeEvent(producedItemEventLog);
			return false;
		}

		private bool GetWeightedOutcome(EventInteractionData eventInteractionData, out WeightedOutcome weightedOutcome)
		{
			weightedOutcome = null;
			float num = eventInteractionData.WeightedOutcomes.Sum((WeightedOutcome weightedOutcome2) => weightedOutcome2.Weight);
			float num2 = (float)random.NextDouble() * num;
			float num3 = 0f;
			foreach (WeightedOutcome weightedOutcome2 in eventInteractionData.WeightedOutcomes)
			{
				num3 += (float)weightedOutcome2.Weight;
				if (num3 >= num2)
				{
					weightedOutcome = weightedOutcome2;
					return true;
				}
			}
			return false;
		}

		protected bool GetBeliefOutcome(EventInteractionData eventInteractionData, string belief, out WeightedOutcome weightedOutcome)
		{
			weightedOutcome = eventInteractionData.WeightedOutcomes.FirstOrDefault((WeightedOutcome weightedOutcome2) => weightedOutcome2.Belief.Equals(belief));
			return weightedOutcome != null;
		}

		protected bool HasChanceToFireEvent(EventInteractionData eventInteractionData)
		{
			float globalChance = GlobalChance;
			globalChance = ((globalChance > 0f) ? globalChance : eventInteractionData.ChanceToFire);
			return random.NextDouble() < (double)globalChance;
		}
	}
}
