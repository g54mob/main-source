using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class FillFoodStorageGoal : Goal
	{
		private const float MaxFoodSearchDistance = 40f;

		private readonly IHungerAgent hungerAgent;

		private readonly CreatureBase creature;

		private static bool CanCreatureConsume(IHungerAgent hungerAgent, ResourcePileInstance resourcePile)
		{
			if (resourcePile.Blueprint == null || resourcePile.Blueprint.Nutrition <= 0f || resourcePile.Blueprint.NutritionPerHp > 0f)
			{
				return false;
			}
			if ((resourcePile.Blueprint.Category & ResourceCategory.CtgMeal) == 0)
			{
				return false;
			}
			return hungerAgent.CanConsume(hungerAgent.CurrentDietModel, resourcePile);
		}

		public FillFoodStorageGoal(Agent selfAgent)
			: this("FillFoodStorageGoal", selfAgent)
		{
			hungerAgent = base.AgentOwner as IHungerAgent;
			creature = base.AgentOwner as CreatureBase;
		}

		private FillFoodStorageGoal(string id, Agent selfAgent)
			: base(id, selfAgent)
		{
			hungerAgent = base.AgentOwner as IHungerAgent;
			creature = base.AgentOwner as CreatureBase;
			AddInitStep(new ThreadSequenceStep(null, FindFoodPile));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHungerAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (creature == null || creature.HasDisposed || creature.HasDied)
			{
				return false;
			}
			return creature.FoodStorage.IsEmpty();
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			Log.Info($"Agent '{base.AgentOwner}' GOAL END: " + condition, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FillFoodStorageGoal.cs");
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailIfTargetResourcePileInstanceFailsPrisonConditions(TargetIndex.A)
				.WithDebugLog("*** fill food: goto pile");
			yield return GeneralActions.Instant().TriggerAnimation("PickUpPile", ActionAnimationMode.WaitForCompletion).FailIfTargetDisposedForbidenOrNull(TargetIndex.A)
				.FailIfTargetReservationReleases(TargetIndex.A);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, (Resource blueprint) => 1, delegate(Resource blueprint, int amount)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(23, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FillFoodStorageGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Agent '");
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral("' picked up ");
					messageBuilder.AppendFormatted(amount);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(blueprint.GetID());
				}
				Log.Info(messageBuilder);
			}, onlySameResourceType: false, creature.FoodStorage).SkipIfTargetDisposedForbidenOrNull(TargetIndex.A);
		}

		private bool FindFoodPile()
		{
			int pilesToSearch = 100;
			ResourcePileInstance optimalPile = null;
			float optimalFoodScore = 0f;
			float foodGoodEnoughPriority = hungerAgent.CurrentDietModel.MaxPriority * 0.7f;
			Vec3Int workerPosition = creature.GetGridPosition();
			PathfinderMedieval.ExploreForObjects(new ExploreRequest
			{
				Agent = (IPathfindingAgent)base.AgentOwner,
				GridData = GridDataType.ResourcePile,
				Condition = delegate(WorldObject obj)
				{
					if ((obj.GetNode().DataType & (GridDataType.Stockpile | GridDataType.Furniture)) == 0)
					{
						return false;
					}
					if (Vec3Int.Distance(in workerPosition, obj.GridDataPosition) > 40f)
					{
						return false;
					}
					ResourcePileInstance resourcePileInstance = (ResourcePileInstance)obj;
					if (resourcePileInstance.IsForbidden)
					{
						return false;
					}
					if (resourcePileInstance.Blueprint == null || resourcePileInstance.Blueprint.NutritionPerHp > 0f)
					{
						return false;
					}
					if (obj.IsOnFire)
					{
						return false;
					}
					Room room = resourcePileInstance.GetRoom();
					return (room == null || !room.RoomType.Prison) && CanCreatureConsume(hungerAgent, resourcePileInstance);
				},
				OnFound = delegate(WorldObject item, Vec3Int pos)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(item, base.AgentOwner);
					pilesToSearch--;
					float foodScore = CommonGoalMethods.GetFoodScore(item, pos, hungerAgent.CurrentDietModel);
					if (optimalPile == null || foodScore > optimalFoodScore)
					{
						optimalFoodScore = foodScore;
						optimalPile = (ResourcePileInstance)item;
					}
					return (pilesToSearch > 0 && !(foodScore >= foodGoodEnoughPriority)) ? P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Continue : P2RegionReservableWoExplorerPath.RegionExplorerCallbackResult.Finish;
				}
			});
			if (optimalPile != null)
			{
				MonoSingleton<ReservationManager>.Instance.TryReserveObject(optimalPile, base.AgentOwner);
				SetTarget(TargetIndex.A, new TargetObject(optimalPile));
			}
			return optimalPile != null;
		}
	}
}
