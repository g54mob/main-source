using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Map;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class VisitorPilgrimIdleGoal : Goal
	{
		private bool alreadyInTargetRoom;

		public VisitorPilgrimIdleGoal(Agent selfAgent)
			: base("VisitorPilgrimIdleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			Log.Trace("VisitorPilgrimIdleGoal: GetNextAction", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\VisitorPilgrimIdleGoal.cs");
			bool flag = false;
			MonoSingleton<AnimationController>.Instance.GenerateNewAnimationRnd(base.AgentOwner);
			string animationTrigger = "Bored";
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				string idleAnimationTrigger = humanoidInstance.ActiveBehaviour.IdleAnimationTrigger;
				flag = humanoidInstance.ActiveBehaviour.StandInPlace;
				if (!string.IsNullOrEmpty(idleAnimationTrigger))
				{
					animationTrigger = idleAnimationTrigger;
				}
			}
			if (!flag || !alreadyInTargetRoom)
			{
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.4f);
			}
			GoapAction goapAction = GeneralActions.Wait(1f);
			goapAction.OnInit = delegate
			{
				if (GetTarget(TargetIndex.B).ObjectInstance != null)
				{
					(base.AgentOwner as CreatureBase)?.FaceObject(GetTarget(TargetIndex.B).ObjectInstance.GetPosition());
				}
			};
			yield return goapAction;
			yield return GeneralActions.Instant().TriggerAnimation(animationTrigger, ActionAnimationMode.WaitForCompletion);
			yield return GeneralActions.Wait(0.5f + Random.value);
		}

		private bool PrepareData()
		{
			if (LoadingController.IsSceneTransition || !MonoSingleton<World>.IsInstantiated())
			{
				return false;
			}
			alreadyInTargetRoom = false;
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			string roomTypeId = null;
			string idleAroundRelic = null;
			if (creatureBase is HumanoidInstance humanoidInstance && humanoidInstance.IsNpc())
			{
				roomTypeId = humanoidInstance.ActiveBehaviour.NpcBlueprint.VisitorIdleInRoom;
				idleAroundRelic = humanoidInstance.ActiveBehaviour.NpcBlueprint.VisitorIdleAroundRelic;
			}
			ClearTargets();
			MapNode ilePointInRoomWithResource = creatureBase.Map.IdlePoints.GetIlePointInRoomWithResource(creatureBase, roomTypeId, idleAroundRelic);
			SetTarget(TargetIndex.A, new TargetObject(ilePointInRoomWithResource.Position));
			Room room = ilePointInRoomWithResource.Map.RoomDetection.GetRoom(ilePointInRoomWithResource);
			if (room != null)
			{
				WorldObject targetObj = room.IterateRoomContent().FirstOrDefault((WorldObject content) => content?.BlueprintId == idleAroundRelic);
				SetTarget(TargetIndex.B, new TargetObject(targetObj));
			}
			alreadyInTargetRoom = creatureBase.Room != null && creatureBase.Room == room;
			return true;
		}
	}
}
