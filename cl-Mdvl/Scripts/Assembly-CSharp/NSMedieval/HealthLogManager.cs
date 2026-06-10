using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval
{
	public class HealthLogManager : MonoSingleton<HealthLogManager>
	{
		public void LogDeath(CreatureBase creatureBase, string woundEffectorId)
		{
			LifeEventLogStruct healthWoundingEventLog = LifeEventUtils.GetHealthWoundingEventLog(creatureBase, woundEffectorId);
			creatureBase.LogLifeEvent(healthWoundingEventLog);
		}

		public void LogLastWords(CreatureBase creatureBase, string woundEffectorId)
		{
			LifeEventLogStruct healthWoundingEventLog = LifeEventUtils.GetHealthWoundingEventLog(creatureBase, woundEffectorId);
			creatureBase.LogLifeEvent(healthWoundingEventLog);
		}

		public void LogWounding(CreatureBase creatureBase, string woundEffectorId)
		{
			LifeEventLogStruct healthWoundingEventLog = LifeEventUtils.GetHealthWoundingEventLog(creatureBase, woundEffectorId);
			creatureBase.LogLifeEvent(healthWoundingEventLog);
		}

		public void LogCarrying(IGoapAgentOwner agentOwner, HumanoidInstance target)
		{
			if (agentOwner is HumanoidInstance humanoidInstance)
			{
				LifeEventLogStruct healthCarryingEventLog = LifeEventUtils.GetHealthCarryingEventLog(humanoidInstance, target);
				humanoidInstance.LogLifeEvent(healthCarryingEventLog);
				target.LogLifeEvent(healthCarryingEventLog);
				target.Stats.StartAffectionEffector("AffectionCarryToBed", humanoidInstance);
			}
		}

		public void LogHealing(HumanoidInstance agent, CreatureBase creatureInstance)
		{
			if (creatureInstance is HumanoidInstance humanoidInstance && agent != humanoidInstance && HasActiveWound(humanoidInstance, out var activeWoundId))
			{
				LifeEventLogStruct healthHealingEventLog = LifeEventUtils.GetHealthHealingEventLog(agent, humanoidInstance, activeWoundId);
				agent.LogLifeEvent(healthHealingEventLog);
				humanoidInstance.LogLifeEvent(healthHealingEventLog);
				humanoidInstance.Stats.StartAffectionEffector("AffectionTendWounds", agent);
			}
		}

		private bool HasActiveWound(HumanoidInstance creature, out string activeWoundId)
		{
			activeWoundId = string.Empty;
			HashSet<string> hashSet = new HashSet<string>();
			foreach (ActiveEffectorInfo activeEffector in creature.Stats.GetActiveEffectors())
			{
				if (activeEffector.WoundInfo != null)
				{
					hashSet.Add(activeEffector.WoundInfo.Blueprint.GetID());
				}
			}
			if (hashSet.Count <= 0)
			{
				return false;
			}
			activeWoundId = hashSet.PickRandom();
			return true;
		}
	}
}
