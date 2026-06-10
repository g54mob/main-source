using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;

namespace NSMedieval.Goap.Goals
{
	public class FollowDigOrderGoal : FollowOrderBaseGoal<DigVoxelOrder>
	{
		private VillageMap map;

		private HumanoidInstance humanoid;

		private DigMarkerResourceInstance digMarker;

		public FollowDigOrderGoal(Agent selfAgent)
			: base(selfAgent, "FollowDigOrderGoal")
		{
			map = VillageManager.ActiveVillage.Map;
			humanoid = base.AgentOwner as HumanoidInstance;
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			humanoid = null;
			digMarker = null;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
			if (view != null)
			{
				view.TrySetParameter("IsCombatAlert", value: true);
			}
			if (condition != GoalCondition.Succeeded)
			{
				digMarker?.Cancel();
				digMarker = null;
			}
		}

		protected override bool CanStartFollowingOrder()
		{
			return MonoSingleton<GroundManager>.Instance.GroundExists(base.CurrentOrder.VoxelPosition + Vec3Int.down);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
			GoapAction placeDigMarker = new GoapAction("EnemyPlaceDigMarker")
			{
				CompleteMode = ActionCompleteMode.Instant
			};
			placeDigMarker.OnInit = delegate
			{
				humanoid.FaceObject(base.CurrentOrder.VoxelPosition.ToVector3World());
				NPCView view = MonoSingleton<NPCManager>.Instance.GetView(base.AgentOwner as HumanoidInstance);
				if (view != null)
				{
					view.TrySetParameter("IsCombatAlert", value: false);
				}
				string text = map.GetNode(base.CurrentOrder.VoxelPosition + Vec3Int.down).VoxelType.DigMarker;
				MapPropType byID = Repository<MapPropTypeRepository, MapPropType>.Instance.GetByID(text);
				DigMarkerResource byID2 = Repository<DigMarkerResourceRepository, DigMarkerResource>.Instance.GetByID(byID.Model);
				if (!(byID2 == null))
				{
					string prefabId = byID2.PrefabIDs.PickRandom();
					digMarker = MonoSingleton<DigMarkerResourceManager>.Instance.CreateEnemyDigMarker(byID2.GetID(), prefabId, base.CurrentOrder.VoxelPosition.ToVector3World());
					if (digMarker == null)
					{
						placeDigMarker.Complete(ActionCompletionStatus.Fail);
					}
					else if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(digMarker, base.AgentOwner))
					{
						SetTarget(TargetIndex.B, new TargetObject(digMarker, base.CurrentOrder.StandingPosition));
					}
				}
			};
			yield return placeDigMarker;
			GoapAction goapAction = MapResourceActions.StartObtaining(TargetIndex.B, OrderType.Digging);
			goapAction.OnInit = delegate
			{
				string miningTool = GetTarget(TargetIndex.B).GetObjectAs<DigMarkerResourceInstance>().Blueprint.MiningTool;
				((IToolAgent)base.AgentOwner).SetTool(miningTool);
			};
			goapAction.FailAtCondition(() => FailCondition(digMarker));
			goapAction.OnComplete = delegate
			{
				((IToolAgent)base.AgentOwner).HideTool();
			};
			goapAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			goapAction.TriggerAnimation("Mining", ActionAnimationMode.Interrupt);
			yield return goapAction;
			yield return MapResourceActions.SpawnHarvestedResources(TargetIndex.B, OrderType.Digging, forbidPile: true);
		}

		private bool PrepareData()
		{
			SetTarget(TargetIndex.A, new TargetObject(base.CurrentOrder.StandingPosition));
			return true;
		}

		private bool FailCondition(DigMarkerResourceInstance digMarkerResourceInstance)
		{
			if (digMarkerResourceInstance == null || digMarkerResourceInstance.HasDisposed)
			{
				return true;
			}
			if (digMarkerResourceInstance.IsOnFire)
			{
				return true;
			}
			if (digMarkerResourceInstance.FactionOwnership == FactionOwnership.Player)
			{
				return true;
			}
			WaterDepthLevel waterDepthLevel = digMarkerResourceInstance.WaterDepthLevel;
			if (waterDepthLevel != WaterDepthLevel.Medium)
			{
				return waterDepthLevel == WaterDepthLevel.High;
			}
			return true;
		}
	}
}
