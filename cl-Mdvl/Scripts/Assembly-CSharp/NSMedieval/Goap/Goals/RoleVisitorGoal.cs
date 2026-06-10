using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap.Goals
{
	public class RoleVisitorGoal : Goal
	{
		protected readonly HumanoidInstance NpcInstance;

		private Random random;

		protected RoleVisitorBehaviour RoleVisitorBehaviour;

		protected MapNode TargetNode;

		protected float WalkSpeed;

		protected RoleInstance RoleInstance => NpcInstance?.ActiveBehaviour.HumanoidRoleOwner.RoleInstance;

		public RoleVisitorGoal(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.Never)
			: base(id, selfAgent, interruptMode)
		{
			NpcInstance = base.AgentOwner as HumanoidInstance;
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
			bool isEnabled;
			if (NpcInstance != null)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(33, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] RoleVisitorGoal: ");
					messageBuilder.AppendFormatted(id);
					messageBuilder.AppendLiteral(" created for ");
					messageBuilder.AppendFormatted(NpcInstance.GetFullName());
				}
				Log.Info(messageBuilder);
			}
			else
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(53, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("[");
					messageBuilder2.AppendFormatted(this);
					messageBuilder2.AppendLiteral("] RoleVisitorGoal: ");
					messageBuilder2.AppendFormatted(id);
					messageBuilder2.AppendLiteral(" created for unknown NPCInstance!");
				}
				Log.Warning(messageBuilder2);
			}
		}

		public override void Start()
		{
			base.Start();
			NpcInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetRoleRoom()?.AddRolePresent(NpcInstance.ActiveBehaviour.HumanoidRoleOwner);
		}

		public override bool CanStart(bool isForced = false)
		{
			bool isEnabled;
			if (!MonoSingleton<AnimationController>.IsInstantiated())
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] AnimationController is not instantiated");
				}
				Log.Info(messageBuilder);
				return false;
			}
			if (!MonoSingleton<NPCController>.IsInstantiated())
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] NPCController is not instantiated");
				}
				Log.Info(messageBuilder);
				return false;
			}
			return true;
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is IPathfindingAgent)
			{
				return true;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("[");
				messageBuilder.AppendFormatted(this);
				messageBuilder.AppendLiteral("] AgentOwner is not IPathfindingAgent");
			}
			Log.Info(messageBuilder);
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield break;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			bool isEnabled;
			if (NpcInstance?.ActiveBehaviour.HumanoidRoleOwner.RoleInstance == null)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] EndGoalWith(");
					messageBuilder.AppendFormatted(condition);
					messageBuilder.AppendLiteral(") NpcInstance or RoleInstance is null");
				}
				Log.Info(messageBuilder);
				return;
			}
			Room roleRoom = NpcInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetRoleRoom();
			if (roleRoom == null)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(33, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] EndGoalWith(");
					messageBuilder.AppendFormatted(condition);
					messageBuilder.AppendLiteral(") RoleRoom is null");
				}
				Log.Info(messageBuilder);
			}
			else
			{
				roleRoom.RemoveRolePresent(NpcInstance.ActiveBehaviour.HumanoidRoleOwner);
			}
		}

		protected virtual Room GetRoom()
		{
			return NpcInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetRoleRoom();
		}

		protected virtual bool PrepareData()
		{
			bool isEnabled;
			if (!MonoSingleton<World>.IsInstantiated())
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] PrepareData: IdlePointManager is not instantiated");
				}
				Log.Info(messageBuilder);
				return false;
			}
			if (random == null)
			{
				random = new Random();
			}
			WalkSpeed = (float)random.NextDouble() * 0.05f + 0.575f;
			if (TargetNode != null)
			{
				RoleVisitorBehaviour.TargetNode = null;
				TargetNode = null;
				RoleVisitorBehaviour = null;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (RoleVisitorBehaviour == null && creatureBase is HumanoidInstance { ActiveBehaviour: RoleVisitorBehaviour activeBehaviour })
			{
				RoleVisitorBehaviour = activeBehaviour;
			}
			if (RoleVisitorBehaviour == null)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] PrepareData: RoleVisitorBehaviour is null");
				}
				Log.Info(messageBuilder);
				return false;
			}
			Room room = GetRoom();
			Vec3Int position = Vec3Int.zero;
			if (room != null)
			{
				room.TryGetRandomReachablePositionInRoom(creatureBase, out position);
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] PrepareData: Role room is not null, go to it");
				}
				Log.Info(messageBuilder);
			}
			else
			{
				ProductionComponentInstance nearestProductionBuilding = IdlePointManager.GetNearestProductionBuilding("camp_fire", creatureBase);
				if (nearestProductionBuilding != null)
				{
					position = nearestProductionBuilding.OwnerBuilding.GetFirstReachablePosition(creatureBase);
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("[");
						messageBuilder.AppendFormatted(this);
						messageBuilder.AppendLiteral("] PrepareData: Campfire is not null, go to it");
					}
					Log.Info(messageBuilder);
				}
			}
			if (position.Equals(Vec3Int.zero))
			{
				MapNode idlePointForTrader = creatureBase.Map.IdlePoints.GetIdlePointForTrader(creatureBase);
				if (idlePointForTrader == null)
				{
					return false;
				}
				position = idlePointForTrader.Position;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(63, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RoleVisitorGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral("] PrepareData: Room and Campfire are null, Target position is ");
					messageBuilder.AppendFormatted(position);
				}
				Log.Info(messageBuilder);
			}
			SetTarget(TargetIndex.A, new TargetObject(position));
			return true;
		}

		protected bool FailWhenUnderWater()
		{
			if (TargetNode == null)
			{
				return false;
			}
			return TargetNode.IsWater;
		}
	}
}
