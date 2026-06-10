using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("TraderBodyguardBehaviour", "TraderBodyguardBehavior")]
	public class TraderBodyguardBehaviour : HumanoidBehaviour
	{
		protected override string HumanTypeId => "enemy";

		public override string IndicatorPrefabName => "trader_bodyguard_indicator";

		public override BehaviourType BehaviourType => BehaviourType.TraderBodyguard;

		public TraderBodyguardBehaviour()
		{
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			base.Humanoid.SetWalkableModel(base.Humanoid.CurrentHumanType.WalkableModelFriendly);
			base.Humanoid.SetCombatAiAgent("TraderBodyguardAgent");
			base.Humanoid.CombatAi.SetState(CombatAiState.IsAggressive, false);
		}

		public override void OnSpawn()
		{
			base.OnSpawn();
			if (GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				return;
			}
			List<EquipmentInstance> list = new List<EquipmentInstance>();
			list.AddRange(base.Inventory.GetEquipments());
			foreach (EquipmentInstance item in list)
			{
				MonoSingleton<NPCController>.Instance.EquipItem(item, base.Inventory);
			}
		}

		protected override Agent CreateGoapAgent()
		{
			return new TraderBodyguardGoapAgent(base.Humanoid);
		}

		public override void OnGoapAttendPlayerTriggeredEvent(string goalId)
		{
			base.OnGoapAttendPlayerTriggeredEvent(goalId);
			base.Humanoid.CombatAi.GoalScheduler.DisableGoal("BodyguardFollowTraderAiActionGoal");
		}

		public override void OnGoapLeavePlayerTriggeredEvent(string goalId)
		{
			base.OnGoapLeavePlayerTriggeredEvent(goalId);
			base.Humanoid.CombatAi.GoalScheduler.EnableGoal("BodyguardFollowTraderAiActionGoal");
		}

		public override string GetGoapAgentId()
		{
			return "enemy";
		}

		public override string GetMultiselectName()
		{
			return "bodyguard";
		}

		public override void AttendPlayerTriggeredEvent(string goalId)
		{
			base.GoapAgent.GoalScheduler.EnableGoal(goalId);
			base.Humanoid.CombatAi.GoalScheduler.DisableGoal("BodyguardFollowTraderAiActionGoal");
		}

		public override void LeavePlayerTriggeredEvent(string goalId)
		{
			if (!base.Humanoid.HasDied && !base.Humanoid.HasDisposed && !base.GoapAgent.HasDisposed && !base.Humanoid.CombatAi.HasDisposed)
			{
				base.GoapAgent.GoalScheduler.DisableGoal(goalId);
				base.Humanoid.CombatAi.GoalScheduler.EnableGoal("BodyguardFollowTraderAiActionGoal");
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
		}

		public TraderBodyguardBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
