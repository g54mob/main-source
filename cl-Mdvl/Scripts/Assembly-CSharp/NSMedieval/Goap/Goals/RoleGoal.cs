using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class RoleGoal : Goal
	{
		protected bool AtPosition;

		protected string AllowedRoleId { get; set; }

		protected HumanoidInstance HumanoidInstance => (HumanoidInstance)base.AgentOwner;

		protected RoleGoal(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.Never)
			: base(id, selfAgent, interruptMode)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!(base.AgentOwner is CreatureBase creatureBase))
			{
				return false;
			}
			if (creatureBase is AnimalInstance)
			{
				return false;
			}
			if (!(creatureBase is HumanoidInstance humanoidInstance) || !humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.AssignedRole)
			{
				return false;
			}
			return humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleInstance.Blueprint.GetID().Equals(AllowedRoleId);
		}

		public override void Start()
		{
			base.Start();
			HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetRoleRoom()?.AddRolePresent(HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner);
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (HumanoidInstance?.ActiveBehaviour.HumanoidRoleOwner.RoleInstance != null)
			{
				HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetRoleRoom()?.RemoveRolePresent(HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner);
			}
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield break;
		}

		protected virtual bool PrepareData()
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase is AnimalInstance)
			{
				return false;
			}
			if (!(creatureBase is HumanoidInstance humanoidInstance) || !humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.AssignedRole)
			{
				return false;
			}
			RoleInstance roleInstance = humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance;
			if (roleInstance == null || !roleInstance.Blueprint.GetID().Equals(AllowedRoleId))
			{
				return false;
			}
			Room roleRoom = roleInstance.GetRoleRoom();
			if (roleRoom == null)
			{
				return false;
			}
			AssignGoToTarget(roleRoom);
			return true;
		}

		protected virtual void AssignGoToTarget(Room room)
		{
			room.TryGetRandomReachablePositionInRoom((CreatureBase)base.AgentOwner, out var position);
			SetTarget(TargetIndex.A, new TargetObject(position));
		}

		protected bool RoleNotAssigned()
		{
			return !HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.AssignedRole;
		}

		protected bool HumanoidDisposed()
		{
			if (HumanoidInstance != null && !HumanoidInstance.HasDied)
			{
				return HumanoidInstance.HasDisposed;
			}
			return true;
		}

		protected void EquipProp(bool equipped)
		{
			if (!HumanoidDisposed() && base.Agent is WorkerGoapAgent workerGoapAgent && MonoSingleton<WorkerManager>.Instance.GetView(HumanoidInstance).BodyPreview is WorkerBodyPreview workerBodyPreview)
			{
				if (workerGoapAgent.CurrentHourType != HourType.RoleJob)
				{
					OnPropEquipCall(workerBodyPreview, equipped: false);
				}
				else
				{
					OnPropEquipCall(workerBodyPreview, equipped);
				}
			}
		}

		protected virtual void OnPropEquipCall(WorkerBodyPreview workerBodyPreview, bool equipped)
		{
		}
	}
}
