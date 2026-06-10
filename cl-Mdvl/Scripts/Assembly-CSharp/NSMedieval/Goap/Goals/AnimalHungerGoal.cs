using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class AnimalHungerGoal : Goal
	{
		private readonly string animationName;

		private bool isForceEatingPile;

		private bool isEatingPlant;

		private bool isEatingCarcass;

		[NonSerialized]
		private readonly AnimalInstance animal;

		private Vec3Int creatureGridPosition = Vec3Int.zero;

		private DietModel DietModel => (base.AgentOwner as IHungerAgent)?.CurrentDietModel;

		private bool IsConsumingAllowed => ((IHungerAgent)base.AgentOwner).IsFoodAllowed;

		private static bool CanCreatureConsume(IHungerAgent hungerAgent, ResourcePileInstance resourcePile)
		{
			if (resourcePile.Blueprint == null || (resourcePile.Blueprint.Nutrition <= 0f && resourcePile.Blueprint.NutritionPerHp <= 0f))
			{
				return false;
			}
			return hungerAgent.CanConsume(hungerAgent.CurrentDietModel, resourcePile);
		}

		private static bool CanCreatureConsume(IHungerAgent hungerAgent, PlantMapResourceInstance resourcePile)
		{
			if (resourcePile.Blueprint == null || resourcePile.Blueprint.NutritionPerHp <= 0f)
			{
				return false;
			}
			return hungerAgent.CanConsume(hungerAgent.CurrentDietModel, resourcePile);
		}

		public AnimalHungerGoal(Agent selfAgent)
			: this("AnimalHungerGoal", selfAgent, "Eat", "eating_bread_item")
		{
		}

		protected AnimalHungerGoal(string id, Agent selfAgent, string animationName, string toolItem)
			: base(id, selfAgent)
		{
			animal = base.AgentOwner as AnimalInstance;
			AddInitStep(new ThreadSequenceStep(CheckForceEating, FindPileTargets));
			this.animationName = animationName;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHungerAgent;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (condition != GoalCondition.Succeeded)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(53, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AnimalHungerGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Hunger goal failed with condition ");
					messageBuilder.AppendFormatted(condition);
					messageBuilder.AppendLiteral(" Action: ");
					messageBuilder.AppendFormatted(base.CurrentAction?.Id);
					messageBuilder.AppendLiteral(" Status: ");
					messageBuilder.AppendFormatted(base.CurrentAction?.CompletionStatus);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(base.AgentOwner);
				}
				Log.Debug(messageBuilder);
			}
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
			base.EndGoalWith(condition);
		}

		public override bool CanStart(bool isForced = false)
		{
			IHungerAgent hungerAgent = (IHungerAgent)base.AgentOwner;
			if (!IsConsumingAllowed && hungerAgent.ForceEatPile == null)
			{
				return false;
			}
			if (DietModel == null || DietModel.DietResources == null || DietModel.DietResources.Count == 0)
			{
				return false;
			}
			if (hungerAgent.ForceEatPile != null)
			{
				return DietModel.CanConsume(hungerAgent.ForceEatPile);
			}
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			IHungerAgent agent = (IHungerAgent)base.AgentOwner;
			if (!isEatingPlant)
			{
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A).FailIfResourcePileHasNoResources(TargetIndex.A)
					.FailIfTargetReservationReleases(TargetIndex.A);
			}
			else
			{
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A);
			}
			GoapAction consumeAction = new GoapAction("Consume");
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B).SkipIfTargetReservationReleases(TargetIndex.B);
			consumeAction.OnInit = delegate
			{
				base.Agent.GetView().EatParticles();
				if (!isEatingPlant && !isEatingCarcass)
				{
					agent.ConsumeStorage();
				}
			};
			consumeAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				agent.ForceEatPile = null;
				if (status == ActionCompletionStatus.Success)
				{
					WorldObject objectAs = GetTarget(TargetIndex.A).GetObjectAs<WorldObject>();
					StatInstance stat = agent.Stats.GetStat(StatType.Hunger);
					float nutrition = GetNutrition(objectAs, stat);
					float num = nutrition;
					if (stat.Current < 0f)
					{
						num -= stat.Current;
					}
					stat.AddCurrent(num);
					if (isEatingPlant)
					{
						OnAtePlantMapResource(objectAs as PlantMapResourceInstance, nutrition);
					}
					else
					{
						ResourcePileInstance resourcePileInstance = objectAs as ResourcePileInstance;
						OnAteResourcePile(resourcePileInstance, nutrition);
						ResourcePileInstance objectAs2 = GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>();
						if (objectAs2 != null && resourcePileInstance != null && resourcePileInstance.Blueprint.NutritionPerHp <= 0f)
						{
							ResourceInstance storedResource = objectAs2.GetStoredResource();
							if (storedResource != null)
							{
								objectAs2.GetStorage().Consume(storedResource.Blueprint, 1);
							}
						}
					}
					base.Agent.GetView().StopEatParticles();
					agent.Stats.Update();
				}
			};
			float duration = (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour * agent.Stats.GetAttributeInstance(AttributeType.ConsumptionSpeed).Value;
			consumeAction.CompleteAfterTimeExpires(duration);
			consumeAction.FailIfTargetReservationReleases(TargetIndex.A);
			consumeAction.FailIfTargetDisposed(TargetIndex.A);
			consumeAction.TriggerAnimation(animationName, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			consumeAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => consumeAction.TotalTickingTime / duration);
			yield return consumeAction;
		}

		private static float GetNutrition(WorldObject targetFood, StatInstance hungerStat)
		{
			float b = 0f;
			float a = hungerStat.Max - Mathf.Max(hungerStat.Current, 0f);
			if (targetFood is ResourcePileInstance resourcePileInstance)
			{
				b = ((!(resourcePileInstance.Blueprint.NutritionPerHp > 0f)) ? resourcePileInstance.Blueprint.Nutrition : (resourcePileInstance.Blueprint.NutritionPerHp * resourcePileInstance.GetStatValue(StatType.Health)));
			}
			if (targetFood is PlantMapResourceInstance plantMapResourceInstance)
			{
				b = plantMapResourceInstance.Blueprint.NutritionPerHp * plantMapResourceInstance.GetStatValue(StatType.Health);
			}
			return Mathf.Min(a, b);
		}

		private void OnAtePlantMapResource(PlantMapResourceInstance plant, float nutritionAdded)
		{
			if (plant != null)
			{
				float num = nutritionAdded / plant.Blueprint.NutritionPerHp;
				plant.GetStat(StatType.Health).AddCurrent(0f - num);
				MonoSingleton<ResourceCommonController>.Instance.OnAtePlantMapResource(plant, base.Agent);
			}
		}

		private void OnAteResourcePile(ResourcePileInstance resourcePile, float nutritionAdded)
		{
			if (resourcePile.Blueprint.NutritionPerHp > 0f)
			{
				float num = nutritionAdded / resourcePile.Blueprint.NutritionPerHp;
				resourcePile.GetStat(StatType.Health).AddCurrent(0f - num);
				MonoSingleton<ResourceCommonController>.Instance.OnAteResource(resourcePile.Blueprint, base.Agent);
			}
			else
			{
				ResourceInstance resourceInstance = new ResourceInstance(resourcePile.Blueprint, 1);
				MonoSingleton<ResourceCommonController>.Instance.OnAteResource(resourceInstance.Blueprint, base.Agent);
			}
		}

		private bool CheckForceEating()
		{
			IHungerAgent hungerAgent = (IHungerAgent)base.AgentOwner;
			isForceEatingPile = false;
			if (hungerAgent.ForceEatPile != null && hungerAgent.ForceEatPile.Blueprint != null && DietModel.CanConsume(hungerAgent.ForceEatPile))
			{
				isForceEatingPile = true;
			}
			return true;
		}

		private static bool CheckIsCarcass(WorldObject worldObject)
		{
			if (worldObject is ResourcePileInstance resourcePileInstance)
			{
				return resourcePileInstance.GetStoredCarcass() != null;
			}
			return false;
		}

		private bool FindPileTargets()
		{
			bool isEnabled;
			if (isForceEatingPile)
			{
				ResourcePileInstance forceEatPile = ((IHungerAgent)base.AgentOwner).ForceEatPile;
				if (forceEatPile.Map.WaterManager.GetWaterLevelAsDepth(forceEatPile.GridDataPosition) != WaterDepthLevel.High && !forceEatPile.IsOnFire && MonoSingleton<ReservationManager>.Instance.TryReserveObject(forceEatPile, base.AgentOwner))
				{
					SetTarget(TargetIndex.A, new TargetObject(forceEatPile));
					return true;
				}
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(104, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AnimalHungerGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Agent ");
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral(" could not reserve preferred target pile at ");
					messageBuilder.AppendFormatted(forceEatPile.GridDataPosition);
					messageBuilder.AppendLiteral(" for consumption. Continuing looking for food as usual");
				}
				Log.Warning(messageBuilder);
			}
			CreatureBase creature = (CreatureBase)base.AgentOwner;
			int foodPileSearchLimit = 16;
			float foodScoreUpperLimit = DietModel.MaxPriority * 0.7f;
			float optimalFoodScore = 0f;
			int foodPilesFound = 0;
			creatureGridPosition = ((CreatureBase)base.AgentOwner).GetGridPosition();
			WorldObject optimalFoodObject = null;
			GridDataType gridDataType = GridDataType.ResourcePile;
			if (DietModel.HasPlants)
			{
				gridDataType |= GridDataType.PlantMapResource;
			}
			ReservationManager reservationManager = MonoSingleton<ReservationManager>.Instance;
			bool num = PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = gridDataType,
				DoQuickSearch = true,
				Condition = delegate(WorldObject obj)
				{
					if (reservationManager.IsReserved(obj))
					{
						return false;
					}
					if (obj.Map.WaterManager.GetWaterLevelAsDepth(obj.GridDataPosition) == WaterDepthLevel.High)
					{
						return false;
					}
					if (obj.IsOnFire)
					{
						return false;
					}
					if ((obj.GridDataType & GridDataType.ResourcePile) != GridDataType.None)
					{
						ResourcePileInstance resourcePile = (ResourcePileInstance)obj;
						return CanCreatureConsume(creature, resourcePile);
					}
					if ((obj.GridDataType & GridDataType.PlantMapResource) != GridDataType.None)
					{
						PlantMapResourceInstance resourcePile2 = (PlantMapResourceInstance)obj;
						return CanCreatureConsume(creature, resourcePile2);
					}
					return false;
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					float foodScore = GetFoodScore(item, pos);
					bool flag = false;
					bool flag2 = false;
					if (optimalFoodObject == null || foodScore > optimalFoodScore)
					{
						flag2 = foodScore >= foodScoreUpperLimit;
						if (optimalFoodObject != null)
						{
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(optimalFoodObject, base.AgentOwner);
						}
						optimalFoodScore = foodScore;
						optimalFoodObject = item;
						flag = true;
						isEatingPlant = (item.GridDataType & GridDataType.PlantMapResource) != 0;
						isEatingCarcass = CheckIsCarcass(item);
						SetTarget(TargetIndex.A, new TargetObject(optimalFoodObject));
					}
					if (flag2 || foodPilesFound++ >= foodPileSearchLimit)
					{
						bool isEnabled2;
						FVLogDebugInterpolationHandler messageBuilder3 = new FVLogDebugInterpolationHandler(54, 4, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AnimalHungerGoal.cs");
						if (isEnabled2)
						{
							messageBuilder3.AppendLiteral("Found best food score (");
							messageBuilder3.AppendFormatted(foodScore);
							messageBuilder3.AppendLiteral(" / ");
							messageBuilder3.AppendFormatted(foodScoreUpperLimit);
							messageBuilder3.AppendLiteral(") after ");
							messageBuilder3.AppendFormatted(foodPilesFound);
							messageBuilder3.AppendLiteral(" iterations. Agent: ");
							messageBuilder3.AppendFormatted(base.AgentOwner);
						}
						Log.Debug(messageBuilder3);
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					return flag ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
				}
			});
			if (num)
			{
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(animal);
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\AnimalHungerGoal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Animal ");
					messageBuilder2.AppendFormatted(base.AgentOwner);
					messageBuilder2.AppendLiteral(" could not path - find any food.");
				}
				Log.Debug(messageBuilder2);
			}
			return num;
		}

		private float GetFoodScore(WorldObject worldObject, Vec3Int gridPosition)
		{
			bool isWildAnimal = animal.AnimalType == AnimalType.Wild || animal.AnimalType == AnimalType.WildAggressive;
			bool isInHomeArea = worldObject.Map.HomeArea.IsHomeArea(gridPosition);
			float result = 0f;
			if ((worldObject.GridDataType & GridDataType.ResourcePile) != GridDataType.None)
			{
				ResourcePileInstance resourcePile = (ResourcePileInstance)worldObject;
				result = DietModel.GetPriority(resourcePile, isInHomeArea, isWildAnimal);
			}
			else if ((worldObject.GridDataType & GridDataType.PlantMapResource) != GridDataType.None)
			{
				PlantMapResourceInstance plantMapResource = (PlantMapResourceInstance)worldObject;
				result = DietModel.GetPriority(plantMapResource, isInHomeArea, isWildAnimal);
			}
			return result;
		}
	}
}
