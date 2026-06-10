using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Animation;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Resources;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class HungerGoal : Goal
	{
		private const int MaxFoodPilesToSearch = 200;

		private const float MaxFoodSearchDistance = 40f;

		private const float FoodPercentUpperMultiplier = 1.5f;

		private const float ChairMaxDist = 70f;

		private const float ChairMaxStarvingDist = 15f;

		private const float TargetFoodLevel = 0.8f;

		private const int GoAwayMaxSteps = 8;

		private IHungerAgent hungerAgent;

		private bool eatAtTable;

		private bool eatOnChair;

		private bool isStarving;

		private readonly string animationName;

		private readonly string toolItem;

		private bool isForceEatingPile;

		private bool isToolBound;

		private int dontEatAtPlaceCount;

		private Vec3Int creatureGridPosition = Vec3Int.zero;

		private CreatureBase creatureBase;

		private readonly Dictionary<WorldObject, float> nutritionCache = new Dictionary<WorldObject, float>();

		private readonly Dictionary<WorldObject, int> objectsToQueue = new Dictionary<WorldObject, int>();

		private readonly Dictionary<WorldObject, int> amountTakenByWorldObject = new Dictionary<WorldObject, int>();

		private readonly List<WorldObject> foodSelected = new List<WorldObject>();

		private Vec3Int averageFoodPosition;

		private readonly List<ResourceInstance> eatFromStorage = new List<ResourceInstance>();

		private VillageMap map;

		protected virtual bool UseFoodStorage => true;

		protected virtual DietModel DietModel => hungerAgent?.CurrentDietModel;

		protected virtual bool ShouldEatAtTable => dontEatAtPlaceCount > 0;

		protected virtual bool FireRoomEffector => true;

		protected virtual int MaxAmountToTake => 0;

		protected virtual string EatAtTableEffector => (base.AgentOwner as HumanoidInstance)?.CurrentHumanType.EatAtTableEffector;

		protected virtual string EatWithoutTableEffector => (base.AgentOwner as HumanoidInstance)?.CurrentHumanType.EatWithoutTableEffector;

		protected virtual bool IsConsumingAllowed => ((IHungerAgent)base.AgentOwner).IsFoodAllowed;

		public HungerGoal(Agent selfAgent)
			: this("HungerGoal", selfAgent, "Eat", "eating_bread_item")
		{
			map = VillageManager.ActiveVillage.Map;
			creatureBase = base.AgentOwner as CreatureBase;
			hungerAgent = base.AgentOwner as IHungerAgent;
		}

		protected HungerGoal(string id, Agent selfAgent, string animationName, string toolItem)
			: base(id, selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			creatureBase = base.AgentOwner as CreatureBase;
			hungerAgent = base.AgentOwner as IHungerAgent;
			AddInitStep(new ThreadSequenceStep(CheckForceEating, FindPileTargets));
			AddInitStep(new ThreadSequenceStep(OnStartChairSearch, FindChairToSitOn));
			this.animationName = animationName;
			this.toolItem = toolItem;
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			creatureBase = null;
			hungerAgent = null;
			nutritionCache.Clear();
			objectsToQueue.Clear();
			amountTakenByWorldObject.Clear();
			foodSelected.Clear();
			eatFromStorage.Clear();
		}

		public override void Start()
		{
			base.Start();
			foreach (TargetObject item in GetTargetQueue(TargetIndex.A))
			{
				if (item.ObjectInstance is WorldObject reservableObject)
				{
					MonoSingleton<ReservationManager>.Instance.TryReserveObject(reservableObject, base.AgentOwner);
				}
			}
			ChairComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>();
			if (objectAs != null && objectAs.OwnerBuilding.OwnedByPlayer() && CommonGoalMethods.CheckPrisonConditions(base.AgentOwner as HumanoidInstance, objectAs.GetRoom()))
			{
				MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner);
			}
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHungerAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			IHungerAgent hungerAgent = (IHungerAgent)base.AgentOwner;
			if (!IsConsumingAllowed && hungerAgent.ForceEatPile == null && hungerAgent.ForceEatResource == null)
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
			if (hungerAgent.ForceEatResource != null)
			{
				return DietModel.CanConsume(hungerAgent.ForceEatResource);
			}
			return true;
		}

		public override void HandleConsecutiveFail()
		{
			if (!GetTarget(TargetIndex.A).IsInitialized)
			{
				return;
			}
			ResourcePileInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ResourcePileInstance>();
			if (objectAs != null)
			{
				if (objectAs.InstanceStorage == null)
				{
					objectAs.IsForbidden = true;
					string localizedResourcePileName = ResourceUtils.GetLocalizedResourcePileName(objectAs.Blueprint.GetID());
					string messageText = MonoSingleton<LocalizationController>.Instance.GetText("error_autoforbid_message").Replace("<object>", localizedResourcePileName);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, objectAs.WorldPosition);
				}
				else if (objectAs.InstanceStorage.GetOwner is ShelfComponentInstance shelfComponentInstance)
				{
					shelfComponentInstance.SetForbidden(isForbidden: true);
				}
			}
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			TargetObject target = GetTarget(TargetIndex.B);
			if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				foreach (ResourceInstance resource in humanoidInstance.Storage.Resources)
				{
					if (resource.Blueprint.Category.HasFlag(ResourceCategory.CtgEdible))
					{
						humanoidInstance.FoodStorage.Add(resource);
						humanoidInstance.Storage.DeleteResource(resource);
					}
				}
			}
			OverrideBoneAnimation overrideBoneAnimation = base.AgentOwner?.GetTransform()?.GetComponent<OverrideBoneAnimation>();
			bool isEnabled;
			if (overrideBoneAnimation != null)
			{
				overrideBoneAnimation.EndOverrideAnimation();
			}
			else
			{
				Transform transform = base.AgentOwner?.GetTransform();
				if (transform != null)
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("OverrideBoneAnimation is missing for ");
						messageBuilder.AppendFormatted(transform.name);
					}
					Log.Warning(messageBuilder);
				}
				else
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("OverrideBoneAnimation is missing for ");
						messageBuilder.AppendFormatted(base.AgentOwner);
					}
					Log.Warning(messageBuilder);
				}
			}
			base.EndGoalWith(condition);
			if (!string.IsNullOrEmpty(toolItem) && base.AgentOwner is IToolAgent toolAgent)
			{
				toolAgent.HideTool();
			}
			if (condition != GoalCondition.Succeeded || !(base.AgentOwner is CreatureBase { HasDisposed: false } creatureBase))
			{
				return;
			}
			if (FireRoomEffector)
			{
				Room room = creatureBase.Room;
				List<string> list = room?.RoomType?.GetEatEffectors(room.Impressiveness);
				if (list != null && list.Count > 0)
				{
					FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(36, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Humanoid ");
						messageBuilder2.AppendFormatted(creatureBase);
						messageBuilder2.AppendLiteral(" ate in ");
						messageBuilder2.AppendFormatted(room.RoomType?.NameLocalized);
						messageBuilder2.AppendLiteral(". Firing effectors ");
						messageBuilder2.AppendFormatted(string.Join(", ", list));
					}
					Log.Info(messageBuilder2);
					creatureBase.Stats.StartEffectors(list);
				}
			}
			if (eatAtTable && !string.IsNullOrEmpty(EatAtTableEffector))
			{
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(base.AgentOwner);
					messageBuilder2.AppendLiteral(" ate on chair, at a table. Firing effector ");
					messageBuilder2.AppendFormatted(EatAtTableEffector);
				}
				Log.Info(messageBuilder2);
				creatureBase.Stats.StartEffector(EatAtTableEffector);
			}
			if (eatOnChair && !string.IsNullOrEmpty(EatWithoutTableEffector))
			{
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(base.AgentOwner);
					messageBuilder2.AppendLiteral(" ate on chair, no table nearby. Firing effector ");
					messageBuilder2.AppendFormatted(EatWithoutTableEffector);
				}
				Log.Info(messageBuilder2);
				creatureBase.Stats.StartEffector(EatWithoutTableEffector);
			}
			if (!eatAtTable && !eatOnChair)
			{
				return;
			}
			HumanoidInstance humanoidInstance2 = base.AgentOwner as HumanoidInstance;
			humanoidInstance2?.WorkerBehaviour?.WorkerInteraction.FireInteractionEvent("ate_at_table");
			ChairComponentInstance objectAs = target.GetObjectAs<ChairComponentInstance>();
			ChairComponentBlueprint chairComponentBlueprint = objectAs?.Blueprint;
			if (!(chairComponentBlueprint != null))
			{
				return;
			}
			foreach (string workerEffector in chairComponentBlueprint.WorkerEffectors)
			{
				if (!string.IsNullOrEmpty(workerEffector))
				{
					humanoidInstance2?.Stats.EndEffector(workerEffector);
					FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(18, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Ending ");
						messageBuilder2.AppendFormatted(chairComponentBlueprint.GetID());
						messageBuilder2.AppendLiteral(" effector: ");
						messageBuilder2.AppendFormatted(workerEffector);
					}
					Log.Info(messageBuilder2);
				}
			}
			humanoidInstance2?.WorkerBehaviour?.WorkerInteraction.FireChairInteractionEvent(objectAs);
		}

		protected virtual bool CanCreatureConsume(IHungerAgent hungerAgent, ResourcePileInstance resourcePile)
		{
			if (resourcePile.Blueprint == null || (resourcePile.Blueprint.Nutrition <= 0f && resourcePile.Blueprint.NutritionPerHp <= 0f))
			{
				return false;
			}
			if (!CommonGoalMethods.CheckPrisonConditions(hungerAgent as HumanoidInstance, resourcePile.GetRoom()))
			{
				return false;
			}
			return hungerAgent.CanConsume(hungerAgent.CurrentDietModel, resourcePile);
		}

		protected virtual bool CanCreatureConsume(IHungerAgent hungerAgent, PlantMapResourceInstance resourcePile)
		{
			if (resourcePile.Blueprint == null || resourcePile.Blueprint.NutritionPerHp <= 0f)
			{
				return false;
			}
			if (!CommonGoalMethods.CheckPrisonConditions(hungerAgent as HumanoidInstance, resourcePile.GetRoom()))
			{
				return false;
			}
			return hungerAgent.CanConsume(hungerAgent.CurrentDietModel, resourcePile);
		}

		protected virtual StatInstance GetHungerStat()
		{
			return hungerAgent.Stats.GetStat(StatType.Hunger);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			bool checkForbidden = !isForceEatingPile;
			isToolBound = false;
			GoapAction end = GeneralActions.Instant("End");
			if (eatFromStorage.Any() && base.AgentOwner is CreatureBase creatureBase)
			{
				foreach (ResourceInstance item in eatFromStorage)
				{
					creatureBase.Storage.Add(item, item.Amount);
					creatureBase.FoodStorage.DeleteResource(item);
				}
			}
			else
			{
				GoapAction gotoChair = GeneralActions.Instant("Goto chair");
				GoapAction pickupPile = GeneralActions.Instant("Pickup pile");
				GoapAction beginCollectPiles = GeneralActions.Instant("Begin collect piles");
				yield return beginCollectPiles;
				yield return JumpActions.JumpIfNoTargetsInQueue(end, TargetIndex.A);
				yield return GoalUtilActions.SelectClosestTargetFromQueue(TargetIndex.A);
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).JumpIfTargetDisposedForbiddenOrNull(beginCollectPiles, TargetIndex.A, checkForbidden).JumpIfTargetReservationReleases(beginCollectPiles, TargetIndex.A)
					.JumpIf(beginCollectPiles, delegate
					{
						if (!(GetTarget(TargetIndex.A).ObjectInstance is ResourcePileInstance resourcePileInstance))
						{
							return false;
						}
						return resourcePileInstance.Blueprint.NutritionPerHp <= 0f && resourcePileInstance.GetStoredResource() == null;
					});
				yield return JumpActions.ConditionalJump(pickupPile, () => !ShouldEatAtPlace(TargetIndex.A));
				yield return GeneralActions.Instant("Pick up pile").TriggerAnimation("PickUpPile", ActionAnimationMode.WaitForCompletion).JumpIfTargetDisposedForbiddenOrNull(beginCollectPiles, TargetIndex.A, checkForbidden)
					.JumpIfTargetReservationReleases(beginCollectPiles, TargetIndex.A);
				yield return ConsumeFoodAction(isEatingInPlace: true);
				yield return JumpActions.JumpIfHaveTargetsInQueue(beginCollectPiles, TargetIndex.A);
				yield return JumpActions.Jump(gotoChair);
				yield return pickupPile;
				yield return GeneralActions.Instant("Trigger pickup pile anim").TriggerAnimation("PickUpPile", ActionAnimationMode.WaitForCompletion).SkipIfTargetDisposedForbiddenOrNull(TargetIndex.A, checkForbidden)
					.SkipIfTargetReservationReleases(TargetIndex.A);
				yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, (Resource blueprint) => GetPickupAmount(TargetIndex.A, blueprint), delegate
				{
				}, onlySameResourceType: false).SkipIfTargetDisposedForbiddenOrNull(TargetIndex.A, checkForbidden);
				yield return JumpActions.JumpIfHaveTargetsInQueue(beginCollectPiles, TargetIndex.A);
				yield return gotoChair;
			}
			if (dontEatAtPlaceCount != 0)
			{
				if (!isForceEatingPile)
				{
					if (GetTarget(TargetIndex.B).IsInitialized)
					{
						yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B).SkipIfTargetReservationReleases(TargetIndex.B)
							.FailAtCondition(FailChairCondition);
						yield return SitAction();
					}
					else
					{
						int stepsCounter = 0;
						Vec3Int prevGridPos = this.creatureBase.GetGridPosition();
						yield return SearchStandingPosition(TargetIndex.B);
						GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.NeverFail);
						Vec3Int gridPos;
						goapAction.OnTick = delegate
						{
							gridPos = this.creatureBase.GetGridPosition();
							if (gridPos != prevGridPos)
							{
								prevGridPos = gridPos;
								stepsCounter++;
							}
							if (stepsCounter >= 8)
							{
								bool isEnabled;
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("HungerGoal: aborting go to target for ");
									messageBuilder.AppendFormatted(this.creatureBase);
									messageBuilder.AppendLiteral(" after ");
									messageBuilder.AppendFormatted(stepsCounter);
									messageBuilder.AppendLiteral(" steps.");
								}
								Log.Info(messageBuilder);
								this.creatureBase.PathDriver.Abort();
							}
						};
						yield return goapAction.WithMovementSpeedMultiplier(0.5f);
					}
				}
				yield return ConsumeFoodAction(isEatingInPlace: false);
			}
			yield return end;
		}

		private static bool ShouldEatAtPlace(WorldObject worldObject)
		{
			if ((worldObject.GridDataType & GridDataType.PlantMapResource) != GridDataType.None)
			{
				return true;
			}
			if ((worldObject.GridDataType & GridDataType.ResourcePile) != GridDataType.None)
			{
				Resource blueprint = ((ResourcePileInstance)worldObject).Blueprint;
				if ((object)blueprint == null)
				{
					return false;
				}
				return blueprint.NutritionPerHp > 0f;
			}
			return false;
		}

		private static float GetNutrition(WorldObject targetFood, float nutritionBeforeEating, float nutritionEaten, float nutritionMax, out int amountToTake)
		{
			float b = 0f;
			amountToTake = 1;
			if ((targetFood.GridDataType & GridDataType.ResourcePile) != GridDataType.None)
			{
				ResourcePileInstance resourcePileInstance = (ResourcePileInstance)targetFood;
				if (resourcePileInstance.Blueprint.NutritionPerHp > 0f)
				{
					b = resourcePileInstance.Blueprint.NutritionPerHp * resourcePileInstance.GetStatValue(StatType.Health);
				}
				else
				{
					float num = nutritionBeforeEating + nutritionEaten;
					float nutrition = resourcePileInstance.Blueprint.Nutrition;
					int amount = resourcePileInstance.GetStoredResource().Amount;
					int val = Mathf.RoundToInt((nutritionMax - num) / nutrition);
					amountToTake = Math.Min(amount, val);
					if (num + (float)amountToTake * nutrition > nutritionMax * 1.5f)
					{
						amountToTake--;
					}
					b = (float)amountToTake * nutrition;
				}
			}
			if ((targetFood.GridDataType & GridDataType.PlantMapResource) != GridDataType.None)
			{
				PlantMapResourceInstance plantMapResourceInstance = (PlantMapResourceInstance)targetFood;
				b = plantMapResourceInstance.Blueprint.NutritionPerHp * plantMapResourceInstance.GetStatValue(StatType.Health);
			}
			return Mathf.Min(nutritionMax, b);
		}

		private short GetChairScore(ChairComponentInstance chair)
		{
			short num = (short)(chair.TablesNearby.Any((TableComponentInstance item) => !item.HasDisposed) ? 10 : 0);
			if (chair.Map.TemperatureManager.GetNodeTemperaturePriority(creatureBase, chair.GetNode()) == 0)
			{
				num += 500;
			}
			Room room = chair.OwnerBuilding.GetRoom();
			if (room != null && room.RoomType != null)
			{
				if (room.RoomType != null && room.RoomType.IsGreatHall)
				{
					return (short)(200 + num);
				}
				return (short)(100 + num);
			}
			MapNode node = chair.GetNode();
			if (node == null)
			{
				return num;
			}
			if (node.Coverage == CoverageType.Roofed)
			{
				return (short)(25 + num);
			}
			return num;
		}

		private bool CheckChair(WorldObject worldObject, Room creatureRoom)
		{
			ChairComponentInstance componentInstance = map.ChairComponentManager.GetComponentInstance(worldObject);
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				return false;
			}
			if (!CommonGoalMethods.CheckPrisonConditions(base.AgentOwner as HumanoidInstance, componentInstance.GetRoom()))
			{
				return false;
			}
			if (isStarving)
			{
				if (creatureRoom == null || worldObject.GetRoom() != creatureRoom)
				{
					if (creatureRoom == null)
					{
						return Vec3Int.Distance(worldObject.GridDataPosition, in averageFoodPosition) < 15f;
					}
					return false;
				}
				return true;
			}
			return Vec3Int.Distance(worldObject.GridDataPosition, in averageFoodPosition) < 70f;
		}

		private GoapAction SitAction()
		{
			bool hasTable = false;
			bool hasChair = false;
			GoapAction sitAction = GeneralActions.Instant().TriggerAnimation("ChairSit", ActionAnimationMode.WaitForCompletion).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B)
				.SkipIfTargetReservationReleases(TargetIndex.B);
			sitAction.OnPreInit = delegate
			{
				if (!sitAction.HasCompleted)
				{
					if (!string.IsNullOrEmpty(toolItem) && base.AgentOwner is IToolAgent toolAgent)
					{
						toolAgent.SetTool(toolItem);
						isToolBound = true;
					}
					ChairComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>();
					TableComponentInstance tableComponentInstance = objectAs?.TablesNearby?.FirstOrDefault(delegate(TableComponentInstance item)
					{
						if (!item.HasDisposed)
						{
							BaseBuildingInstance ownerBuilding = item.OwnerBuilding;
							if (ownerBuilding != null && !ownerBuilding.HasDisposed)
							{
								return item.OwnerBuilding.OwnedByPlayer();
							}
						}
						return false;
					});
					hasTable = tableComponentInstance != null;
					hasChair = objectAs != null;
					if (objectAs != null && base.AgentOwner is IPathfindingAgent pathfindingAgent)
					{
						pathfindingAgent.PathDriver.Teleport(objectAs.GridDataPosition);
						OverrideBoneAnimation component = base.AgentOwner.GetTransform().GetComponent<OverrideBoneAnimation>();
						ChairComponent component2 = objectAs.Map.ChairComponentManager.GetComponent(objectAs);
						component.OverridePosition = component2.ChairSitPosition;
						component.StartOverrideAnimation();
					}
					if (tableComponentInstance == null)
					{
						if (objectAs != null)
						{
							Vector3 objectPosition = base.Agent.GetView().transform.position + Quaternion.Euler(0f, objectAs.Angle, 0f) * Vector3.right;
							base.Agent.GetView().FaceObject(objectPosition);
						}
					}
					else
					{
						Vec3Int gridPos = Vec3Int.zero;
						float num = 0f;
						foreach (Vec3Int position in tableComponentInstance.Positions)
						{
							Vec3Int a = position;
							if (gridPos.Equals(Vec3Int.zero) || Vec3Int.Distance(in a, objectAs.GridDataPosition) < num)
							{
								num = Vec3Int.Distance(in a, objectAs.GridDataPosition);
								gridPos = a;
							}
						}
						base.Agent.GetView().FaceObject(GridUtils.GetWorldPosition(gridPos));
					}
				}
			};
			sitAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					eatAtTable = hasTable && hasChair;
					eatOnChair = !hasTable && hasChair;
					ChairComponentBlueprint chairComponentBlueprint = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>()?.Blueprint;
					if (chairComponentBlueprint != null)
					{
						HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
						foreach (string workerEffector in chairComponentBlueprint.WorkerEffectors)
						{
							if (!string.IsNullOrEmpty(workerEffector))
							{
								humanoidInstance?.Stats.StartEffector(workerEffector);
								bool isEnabled;
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Starting ");
									messageBuilder.AppendFormatted(chairComponentBlueprint.GetID());
									messageBuilder.AppendLiteral(" effector: ");
									messageBuilder.AppendFormatted(workerEffector);
								}
								Log.Info(messageBuilder);
							}
						}
					}
				}
			};
			sitAction.SetMinimumDurationTime(1f);
			return sitAction;
		}

		private GoapAction ConsumeFoodAction(bool isEatingInPlace)
		{
			GoapAction consumeAction = new GoapAction(isEatingInPlace ? "ConsumeInPlace" : "ConsumeStorage");
			consumeAction.OnInit = delegate
			{
				base.Agent.GetView().EatParticles();
				if (!ShouldEatAtPlace(TargetIndex.A) && !isToolBound && !string.IsNullOrEmpty(toolItem) && base.AgentOwner is IToolAgent toolAgent)
				{
					isToolBound = true;
					toolAgent.SetTool(toolItem);
				}
			};
			consumeAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (hungerAgent != null && !base.Agent.HasDisposed && !base.AgentOwner.HasDisposed)
				{
					hungerAgent.ForceEatPile = null;
					hungerAgent.ForceEatResource = null;
					base.Agent?.GetView()?.StopEatParticles();
					if (status != ActionCompletionStatus.Success)
					{
						hungerAgent?.DropStorage();
					}
					else
					{
						StatInstance hungerStat = GetHungerStat();
						if (hungerStat.Current < 0f)
						{
							hungerStat.AddCurrent(0f - hungerStat.Current);
						}
						if (isEatingInPlace)
						{
							WorldObject objectAs = GetTarget(TargetIndex.A).GetObjectAs<WorldObject>();
							if (objectAs != null && (objectAs.GridDataType & GridDataType.PlantMapResource) != GridDataType.None)
							{
								PlantMapResourceInstance plantMapResourceInstance = (PlantMapResourceInstance)objectAs;
								float num = nutritionCache[plantMapResourceInstance];
								hungerStat.AddCurrent(num);
								OnAtePlantMapResource(plantMapResourceInstance, num);
							}
							if (objectAs != null && (objectAs.GridDataType & GridDataType.ResourcePile) != GridDataType.None)
							{
								ResourcePileInstance resourcePileInstance = (ResourcePileInstance)objectAs;
								float num2 = nutritionCache[resourcePileInstance];
								hungerStat.AddCurrent(num2);
								OnAteResourcePileAtPlace(resourcePileInstance, num2);
							}
						}
						else
						{
							foreach (ResourceInstance resource in hungerAgent.Storage.Resources)
							{
								float num3 = resource.GetNutrition() * (float)resource.Amount;
								hungerStat.AddCurrent(num3);
								OnAteResourceInstance(resource, num3);
							}
							hungerAgent.ConsumeStorage();
							hungerAgent.Stats.Update();
						}
					}
				}
			};
			float duration = (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour * hungerAgent.Stats.GetAttributeInstance(AttributeType.ConsumptionSpeed).Value;
			consumeAction.CompleteAfterTimeExpires(duration);
			consumeAction.TriggerAnimation(animationName, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			consumeAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => consumeAction.TotalTickingTime / duration);
			return consumeAction;
		}

		private bool ShouldEatAtPlace(TargetIndex targetIndex)
		{
			TargetObject target = GetTarget(targetIndex);
			if (!target.IsInitialized)
			{
				return false;
			}
			return ShouldEatAtPlace(target.GetObjectAs<WorldObject>());
		}

		private GoapAction SearchStandingPosition(TargetIndex targetIndex)
		{
			return new GoapAction("SearchStandingPosition")
			{
				OnInit = delegate
				{
					MapNode randomPoint = creatureBase.Map.IdlePoints.GetRandomPoint(creatureBase, creatureBase.GetGridPosition(), 10f, skipOutOfRangeTemperatures: false, getClosestNode: true);
					SetTarget(targetIndex, new TargetObject(randomPoint.Position));
				}
			};
		}

		private int GetPickupAmount(TargetIndex targetIndex, Resource resourcePile)
		{
			ResourcePileInstance objectAs = GetTarget(targetIndex).GetObjectAs<ResourcePileInstance>();
			if (objectAs == null || objectAs.HasDisposed)
			{
				return 0;
			}
			if (!amountTakenByWorldObject.ContainsKey(objectAs))
			{
				return 1;
			}
			return Math.Min(amountTakenByWorldObject[objectAs], objectAs.GetStoredResource().Amount);
		}

		private void OnAteResourceInstance(ResourceInstance resourceInstance, float nutrition)
		{
			if (resourceInstance.Blueprint.NutritionPerHp > 0f)
			{
				float num = nutrition / resourceInstance.Blueprint.NutritionPerHp;
				resourceInstance.GetStat(StatType.Health).AddCurrent(0f - num);
				OnConsumedResource(resourceInstance);
			}
			else
			{
				OnConsumedResource(resourceInstance);
			}
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

		private void OnAteResourcePileAtPlace(ResourcePileInstance resourcePile, float nutritionAdded)
		{
			if (resourcePile.Blueprint.NutritionPerHp > 0f)
			{
				float num = nutritionAdded / resourcePile.Blueprint.NutritionPerHp;
				resourcePile.GetStat(StatType.Health).AddCurrent(0f - num);
				OnConsumedResource(resourcePile.GetStorage().GetSingleResource());
			}
		}

		protected virtual void OnConsumedResource(ResourceInstance resourceInstance)
		{
			MonoSingleton<ResourceCommonController>.Instance.OnAteResource(resourceInstance, base.Agent);
		}

		private bool CheckForceEating()
		{
			IHungerAgent hungerAgent = (IHungerAgent)base.AgentOwner;
			isForceEatingPile = false;
			if (hungerAgent.ForceEatPile != null && hungerAgent.ForceEatPile.Blueprint != null && DietModel.CanConsume(hungerAgent.ForceEatPile))
			{
				isForceEatingPile = true;
			}
			if (hungerAgent.ForceEatResource != null && hungerAgent.ForceEatResource.Blueprint != null && DietModel.CanConsume(hungerAgent.ForceEatResource))
			{
				isForceEatingPile = true;
			}
			return true;
		}

		private bool FindPileTargets()
		{
			eatFromStorage.Clear();
			dontEatAtPlaceCount = 0;
			objectsToQueue.Clear();
			foodSelected.Clear();
			amountTakenByWorldObject.Clear();
			nutritionCache.Clear();
			bool isEnabled;
			if (isForceEatingPile)
			{
				ResourcePileInstance forceEatPile = hungerAgent.ForceEatPile;
				if (forceEatPile != null && MonoSingleton<ReservationManager>.Instance.CanReserve(forceEatPile, base.AgentOwner))
				{
					dontEatAtPlaceCount++;
					ClearTargetsQueue(TargetIndex.A);
					QueueTarget(TargetIndex.A, new TargetObject(forceEatPile));
					return true;
				}
				if (hungerAgent.ForceEatResource != null)
				{
					dontEatAtPlaceCount++;
					eatFromStorage.Add(hungerAgent.ForceEatResource);
					averageFoodPosition = ((CreatureBase)base.AgentOwner).GetGridPosition();
					return true;
				}
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(104, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\HungerGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Agent ");
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral(" could not reserve preferred target pile at ");
					messageBuilder.AppendFormatted(forceEatPile?.GridDataPosition);
					messageBuilder.AppendLiteral(" for consumption. Continuing looking for food as usual");
				}
				Log.Warning(messageBuilder);
			}
			CreatureBase creature = (CreatureBase)base.AgentOwner;
			creatureGridPosition = ((CreatureBase)base.AgentOwner).GetGridPosition();
			GridDataType gridDataType = GridDataType.ResourcePile;
			if (DietModel.HasPlants)
			{
				gridDataType |= GridDataType.PlantMapResource;
			}
			StatInstance hungerStat = GetHungerStat();
			float currentHunger = Mathf.Max(0f, hungerStat.Current);
			float num = hungerStat.Max - currentHunger;
			ClearTargets();
			int pilesToSearch = 200;
			float foodGoodEnoughPriority = DietModel.MaxPriority * 0.7f;
			float foodSelectedNutrition = 0f;
			int totalAmountTaken = 0;
			if (UseFoodStorage && creature.FoodStorage != null)
			{
				foreach (ResourceInstance resource in creature.FoodStorage.Resources)
				{
					if (resource != null && !(resource.Blueprint == null) && !resource.HasDisposed && hungerAgent.CanConsume(hungerAgent.CurrentDietModel, resource) && CommonGoalMethods.GetFoodScore(resource, creature.CurrentDietModel) >= foodGoodEnoughPriority)
					{
						dontEatAtPlaceCount++;
						eatFromStorage.Add(resource);
						averageFoodPosition = creature.GetGridPosition();
						isEnabled = true;
						return isEnabled;
					}
				}
			}
			PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = gridDataType,
				DoQuickSearch = true,
				Condition = delegate(WorldObject obj)
				{
					if (obj is IForbidable { IsForbidden: not false })
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
					if ((foodSelected.Any() || objectsToQueue.Any()) && Vec3Int.Distance(in pos, in creatureGridPosition) > 40f)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					if (currentHunger + foodSelectedNutrition >= hungerStat.Max * 0.8f)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					pilesToSearch--;
					int amountToTake2;
					float nutrition2 = GetNutrition(item, currentHunger, foodSelectedNutrition, hungerStat.Max, out amountToTake2);
					if (MaxAmountToTake > 0)
					{
						amountToTake2 = Mathf.Clamp(amountToTake2, 0, Math.Max(0, MaxAmountToTake - totalAmountTaken));
					}
					if (amountToTake2 == 0)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
					}
					SetNutritionCache(item, nutrition2);
					SetAmountTakenCache(item, amountToTake2);
					float foodScore = CommonGoalMethods.GetFoodScore(item, pos, DietModel);
					if (foodScore >= foodGoodEnoughPriority)
					{
						foodSelected.Add(item);
						foodSelectedNutrition += nutrition2;
						if (MaxAmountToTake > 0)
						{
							totalAmountTaken += amountToTake2;
							if (totalAmountTaken >= MaxAmountToTake)
							{
								return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
							}
						}
					}
					else
					{
						int value = (int)(100f * foodScore);
						objectsToQueue.Add(item, value);
						MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
					}
					return (pilesToSearch > 0 && !(currentHunger + foodSelectedNutrition >= hungerStat.Max * 0.8f)) ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
			if (!objectsToQueue.Any() & !foodSelected.Any())
			{
				if (UseFoodStorage && creature.FoodStorage != null && creature.FoodStorage.Resources.Any())
				{
					dontEatAtPlaceCount++;
					foreach (ResourceInstance resource2 in creature.FoodStorage.Resources)
					{
						if (resource2 != null && !(resource2.Blueprint == null) && !resource2.HasDisposed && hungerAgent.CanConsume(hungerAgent.CurrentDietModel, resource2))
						{
							eatFromStorage.Add(creature.FoodStorage.FirstResource);
							averageFoodPosition = creature.GetGridPosition();
							isEnabled = true;
							return isEnabled;
						}
					}
				}
				return false;
			}
			if (currentHunger + foodSelectedNutrition < hungerStat.Max * 0.8f)
			{
				List<WorldObject> list = objectsToQueue.Keys.ToList();
				list.Sort((WorldObject a, WorldObject b) => objectsToQueue[b] - objectsToQueue[a]);
				foreach (WorldObject item in list)
				{
					int amountToTake;
					float nutrition = GetNutrition(item, currentHunger, foodSelectedNutrition, hungerStat.Max, out amountToTake);
					if (MaxAmountToTake > 0)
					{
						amountToTake = Mathf.Clamp(amountToTake, 0, Math.Max(0, MaxAmountToTake - totalAmountTaken));
					}
					SetAmountTakenCache(item, amountToTake);
					SetNutritionCache(item, nutrition);
					if (amountToTake == 0)
					{
						continue;
					}
					if (currentHunger + foodSelectedNutrition + nutrition > hungerStat.Max * 1.5f)
					{
						break;
					}
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(item, base.AgentOwner))
					{
						continue;
					}
					foodSelectedNutrition += nutrition;
					foodSelected.Add(item);
					if (MaxAmountToTake > 0)
					{
						totalAmountTaken += amountToTake;
						if (totalAmountTaken >= MaxAmountToTake)
						{
							break;
						}
					}
					if (foodSelectedNutrition >= num || foodSelectedNutrition + currentHunger >= hungerStat.Max * 0.8f)
					{
						break;
					}
				}
			}
			averageFoodPosition = Vec3Int.zero;
			foreach (WorldObject item2 in foodSelected)
			{
				if (amountTakenByWorldObject.ContainsKey(item2))
				{
					if (!ShouldEatAtPlace(item2))
					{
						dontEatAtPlaceCount++;
					}
					QueueTarget(TargetIndex.A, new TargetObject(item2));
					averageFoodPosition += item2.GridDataPosition;
				}
			}
			if (foodSelected.Count > 0)
			{
				averageFoodPosition /= foodSelected.Count;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetAmountTakenCache(WorldObject worldObject, int amountTaken)
		{
			if (!amountTakenByWorldObject.ContainsKey(worldObject))
			{
				amountTakenByWorldObject.Add(worldObject, amountTaken);
			}
			else
			{
				amountTakenByWorldObject[worldObject] = amountTaken;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetNutritionCache(WorldObject item, float nutrition)
		{
			if (!nutritionCache.ContainsKey(item))
			{
				nutritionCache.Add(item, nutrition);
			}
			else
			{
				nutritionCache[item] = nutrition;
			}
		}

		private bool OnStartChairSearch()
		{
			if (!ShouldEatAtTable)
			{
				return true;
			}
			StatInstance hungerStat = GetHungerStat();
			if (hungerStat == null)
			{
				return false;
			}
			isStarving = hungerStat.Current < 10f;
			return true;
		}

		private bool FindChairToSitOn()
		{
			eatAtTable = false;
			if (dontEatAtPlaceCount <= 0)
			{
				return true;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			IEnumerable<WorldObject> enumerable = map.ChairComponentManager.IterateComponentWorldObjects((ChairComponentInstance x) => !x.OwnerBuilding.UnderWater());
			if (enumerable == null || !enumerable.Any())
			{
				return true;
			}
			ChairComponentInstance optimalChair = null;
			short optimalChairScore = 0;
			int chairsSearched = 0;
			int maxSearchLimit = 100;
			Room creatureRoom = creatureBase.Room;
			TemperatureManager temperatureManager = creatureBase.Map.TemperatureManager;
			PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = GridDataType.Furniture,
				Condition = (WorldObject obj) => CheckChair(obj, creatureRoom),
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					ChairComponentInstance componentInstance = map.ChairComponentManager.GetComponentInstance(item);
					if (componentInstance == null || componentInstance.OwnerBuilding.UnderWater() || componentInstance.IsOnFire || !componentInstance.OwnerBuilding.OwnedByPlayer())
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					MapNode node = item.GetNode();
					if (temperatureManager.IsNodeTemperatureOutOfRange(node))
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue;
					}
					short chairScore = GetChairScore(componentInstance);
					bool flag = false;
					bool flag2 = false;
					if (optimalChair == null || chairScore > optimalChairScore)
					{
						flag2 = chairScore >= 210;
						if (optimalChair != null)
						{
							MonoSingleton<ReservationManager>.Instance.ReleaseObject(optimalChair, base.AgentOwner);
						}
						optimalChairScore = chairScore;
						optimalChair = componentInstance;
						flag = true;
						SetTarget(TargetIndex.B, new TargetObject(optimalChair));
					}
					if (flag2 || chairsSearched++ >= maxSearchLimit)
					{
						return P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
					}
					return flag ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Skip;
				}
			});
			return true;
		}

		private bool FailChairCondition()
		{
			ChairComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>();
			if (objectAs != null && !objectAs.HasDisposed && !objectAs.OwnerBuilding.UnderWater())
			{
				return objectAs.IsOnFire;
			}
			return true;
		}
	}
}
