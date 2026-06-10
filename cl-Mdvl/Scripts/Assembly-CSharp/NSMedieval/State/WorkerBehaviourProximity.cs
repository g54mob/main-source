using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.State
{
	public class WorkerBehaviourProximity : HumanoidProximityBehaviour
	{
		private IEnumerable<ProximityInteractionType> allowedInteractionTypes;

		private Dictionary<ProximityInteractionType, float> proximityHourTimeouts;

		private object random;

		public bool IsProtectiveAgainstPredators
		{
			get
			{
				if (!HumanoidInstance.IsSleeping && !HumanoidInstance.HasFainted)
				{
					return !HumanoidInstance.IsInIncognitoMode();
				}
				return false;
			}
		}

		public WorkerBehaviourProximity(HumanoidInstance humanoidInstance)
			: base(humanoidInstance)
		{
		}

		public override void HandleOnCreatureEnterProximity(CreatureBase creature)
		{
			OnWorkerEnterProximity(creature);
		}

		public void OnProducedQualityItem(ResourceInstance resourceInstance, ProductQuality quality)
		{
			switch (quality)
			{
			case ProductQuality.Flimsy:
				HumanoidInstance.HumanoidBelief.FireBeliefEvent("belief_flimsy_item");
				{
					foreach (WorkerBehaviour proximityWorker in HumanoidInstance.ProximityWorkers)
					{
						proximityWorker.WorkerProximity.HandleProductionLowQualityEvent(HumanoidInstance, resourceInstance);
					}
					break;
				}
			case ProductQuality.Flawless:
				HumanoidInstance.HumanoidBelief.FireBeliefEvent("belief_flawless_item");
				{
					foreach (WorkerBehaviour proximityWorker2 in HumanoidInstance.ProximityWorkers)
					{
						proximityWorker2.WorkerProximity.HandleProductionHighQualityEvent(HumanoidInstance, resourceInstance);
					}
					break;
				}
			}
		}

		private void HandleProductionLowQualityEvent(HumanoidInstance target, ResourceInstance resourceInstance)
		{
			float attributeValue = HumanoidInstance.GetAttributeValue(AttributeType.ProductionLowQualityNegativeChance);
			bool flag = UnityEngine.Random.Range(0f, 1f) < attributeValue;
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(flag ? "saw_flimsy_production_negative" : "saw_flimsy_production", HumanoidInstance, target);
		}

		private void HandleProductionHighQualityEvent(HumanoidInstance target, ResourceInstance resourceInstance)
		{
			float attributeValue = HumanoidInstance.GetAttributeValue(AttributeType.ProductionHighQualityNegativeChance);
			bool flag = UnityEngine.Random.Range(0f, 1f) < attributeValue;
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(flag ? "saw_flawless_production_negative" : "saw_flawless_production", HumanoidInstance, target);
		}

		public void OnConstructionFailed()
		{
			foreach (WorkerBehaviour proximityWorker in HumanoidInstance.ProximityWorkers)
			{
				proximityWorker.WorkerProximity.HandleConstructionFailedEvent(HumanoidInstance);
			}
		}

		public void OnChopFailed()
		{
			Log.Info("Chop failed", "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\WorkerBehaviourProximity.cs");
			foreach (WorkerBehaviour proximityWorker in HumanoidInstance.ProximityWorkers)
			{
				proximityWorker.WorkerProximity.HandleChopFailedEvent(HumanoidInstance);
			}
		}

		public void OnHarvestFailed()
		{
			foreach (WorkerBehaviour proximityWorker in HumanoidInstance.ProximityWorkers)
			{
				proximityWorker.WorkerProximity.HandleConstructionFailedEvent(HumanoidInstance);
			}
		}

		public void OnDiggingFailed()
		{
			foreach (WorkerBehaviour proximityWorker in HumanoidInstance.ProximityWorkers)
			{
				proximityWorker.WorkerProximity.HandleDiggingFailedEvent(HumanoidInstance);
			}
		}

		private void OnWorkerEnterProximity(CreatureBase creature)
		{
			if (creature is HumanoidInstance target && !IsInteractionWithTimeout(target) && !IsInebriatedInteraction(target))
			{
				IsEatingHumanInteraction(target);
			}
		}

		private bool IsEatingHumanInteraction(HumanoidInstance target)
		{
			if (target.GetGoapAgent()?.CurrentGoalName == "HungerGoal" && target.Storage.Resources.Any((ResourceInstance res) => res.Blueprint.IsHumanSource))
			{
				return MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(HumanoidInstance.IsCannibal() ? "saw_cannibal_eating_positive" : "saw_cannibal_eating_negative", HumanoidInstance, target);
			}
			return false;
		}

		private bool IsInebriatedInteraction(HumanoidInstance target)
		{
			if (target.Stats.IsEffectorActive("InebriatedVeryHigh") || target.Stats.IsEffectorActive("InebriatedHigh"))
			{
				bool flag = HumanoidInstance.Stats.GetActiveEffectors().Any((ActiveEffectorInfo eff) => !string.IsNullOrEmpty(eff.Category) && eff.Category.Equals("Inebriated"));
				return MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(flag ? "saw_drunk_settler_positive" : "saw_drunk_settler_negative", HumanoidInstance, target);
			}
			return false;
		}

		private bool IsInteractionWithTimeout(HumanoidInstance target)
		{
			foreach (ProximityInteractionType allowedInteractionType in allowedInteractionTypes)
			{
				if (proximityHourTimeouts[allowedInteractionType] <= 0f && MonoSingleton<ProximityInteractionManager>.Instance.AttemptInteraction(allowedInteractionType, HumanoidInstance, target))
				{
					ResetInteractionTimer(allowedInteractionType);
					target.WorkerBehaviour?.WorkerProximity.ResetInteractionTimer(allowedInteractionType);
					return true;
				}
			}
			return false;
		}

		public float GetInteractionTimeoutDefault(ProximityInteractionType interactionType)
		{
			return interactionType switch
			{
				ProximityInteractionType.Conversation => HumanoidInstance.Stats.GetAttributeInstance(AttributeType.ConversationInteractionHoursCooldown).Value, 
				ProximityInteractionType.Pet => HumanoidInstance.Stats.GetAttributeInstance(AttributeType.PetInteractionHoursCooldown).Value, 
				ProximityInteractionType.Beauty => HumanoidInstance.Stats.GetAttributeInstance(AttributeType.BeautyInteractionHoursCooldown).Value, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		private void ResetInteractionTimer(ProximityInteractionType interactionType)
		{
			Dictionary<ProximityInteractionType, float> dictionary = proximityHourTimeouts;
			dictionary[interactionType] = interactionType switch
			{
				ProximityInteractionType.Conversation => GetInteractionTimeoutDefault(interactionType), 
				ProximityInteractionType.Pet => GetInteractionTimeoutDefault(interactionType), 
				ProximityInteractionType.Beauty => GetInteractionTimeoutDefault(interactionType), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public void ResetAllProximityTimeouts()
		{
			allowedInteractionTypes = new ProximityInteractionType[1] { ProximityInteractionType.Conversation };
			proximityHourTimeouts = new Dictionary<ProximityInteractionType, float>();
			foreach (ProximityInteractionType allowedInteractionType in allowedInteractionTypes)
			{
				ResetInteractionTimer(allowedInteractionType);
			}
		}

		private void HandleDiggingFailedEvent(HumanoidInstance target)
		{
			float attributeValue = HumanoidInstance.GetAttributeValue(AttributeType.MiningFailNegativityChance);
			bool flag = UnityEngine.Random.Range(0f, 1f) < attributeValue;
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(flag ? "saw_failed_mining_negative" : "saw_failed_mining", HumanoidInstance, target);
		}

		private void HandleHarvestFailedEvent(HumanoidInstance target)
		{
			float attributeValue = HumanoidInstance.GetAttributeValue(AttributeType.HarvestFailNegativityChance);
			bool flag = UnityEngine.Random.Range(0f, 1f) < attributeValue;
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(flag ? "saw_failed_harvest_negative" : "saw_failed_harvest", HumanoidInstance, target);
		}

		private void HandleChopFailedEvent(HumanoidInstance target)
		{
			float attributeValue = HumanoidInstance.GetAttributeValue(AttributeType.HarvestFailNegativityChance);
			bool flag = UnityEngine.Random.Range(0f, 1f) < attributeValue;
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(flag ? "saw_failed_chopping_negative" : "saw_failed_chopping", HumanoidInstance, target);
		}

		private void HandleConstructionFailedEvent(HumanoidInstance target)
		{
			float attributeValue = HumanoidInstance.GetAttributeValue(AttributeType.ConstructionFailNegativityChance);
			bool flag = UnityEngine.Random.Range(0f, 1f) < attributeValue;
			MonoSingleton<EventInteractionManager>.Instance.AttemptInteraction(flag ? "saw_failed_construction_negative" : "saw_failed_construction", HumanoidInstance, target);
		}

		public void HandleQuarterHourChange()
		{
			if (allowedInteractionTypes == null)
			{
				return;
			}
			foreach (ProximityInteractionType allowedInteractionType in allowedInteractionTypes)
			{
				proximityHourTimeouts[allowedInteractionType] -= 0.25f;
			}
		}
	}
}
