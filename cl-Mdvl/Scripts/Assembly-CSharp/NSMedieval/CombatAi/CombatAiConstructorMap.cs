using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public static class CombatAiConstructorMap
	{
		private static Dictionary<string, ConstructorInfo> constructorGoals;

		private static Dictionary<string, ConstructorInfo> constructorReactions;

		private static Dictionary<string, ConstructorInfo> constructorSensors;

		public static Dictionary<string, ConstructorInfo> Goals
		{
			get
			{
				if (constructorGoals == null)
				{
					constructorGoals = new Dictionary<string, ConstructorInfo>();
					constructorGoals.Add("AttackAiActionGoal", typeof(AttackAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("AttackFleeAiActionGoal", typeof(AttackFleeAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("EnemyRetreatAiActionGoal", typeof(EnemyRetreatAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("VisitorRetreatAiActionGoal", typeof(VisitorRetreatAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("FollowAiActionGoal", typeof(FollowAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("FleeAiActionGoal", typeof(FleeAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("EnemyTargetDoorsAiPlanGoal", typeof(EnemyTargetDoorsAiPlanGoal).GetConstructors()[0]);
					constructorGoals.Add("EnemyTargetProductionAiPlanGoal", typeof(EnemyTargetProductionAiPlanGoal).GetConstructors()[0]);
					constructorGoals.Add("EnemyTargetWorkersAiPlanGoal", typeof(EnemyTargetWorkersAiPlanGoal).GetConstructors()[0]);
					constructorGoals.Add("WorkerRangedDraftAiPlanGoal", typeof(WorkerRangedDraftAiPlanGoal).GetConstructors()[0]);
					constructorGoals.Add("WorkerMeleeDraftAiPlanGoal", typeof(WorkerMeleeDraftAiPlanGoal).GetConstructors()[0]);
					constructorGoals.Add("EnemyProvideBackupActionGoal", typeof(EnemyProvideBackupActionGoal).GetConstructors()[0]);
					constructorGoals.Add("TraderIdleAiActionGoal", typeof(TraderIdleAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("BodyguardFollowTraderAiActionGoal", typeof(BodyguardFollowTraderAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("AnimalFollowOwnerAiActionGoal", typeof(AnimalFollowOwnerAiActionGoal).GetConstructors()[0]);
					constructorGoals.Add("MeleeEnemyTargetGlobalWorkersAiPlanGoal", typeof(MeleeEnemyTargetGlobalWorkersAiPlanGoal).GetConstructors()[0]);
					constructorGoals.Add("AnimalAttackHungerAiPlanGoal", typeof(AnimalAttackHungerAiPlanGoal).GetConstructors()[0]);
					constructorGoals.Add("FollowOrdersAiActionGoal", typeof(FollowOrdersAiActionGoal).GetConstructors()[0]);
				}
				return constructorGoals;
			}
		}

		public static Dictionary<string, ConstructorInfo> Reactions
		{
			get
			{
				if (constructorReactions == null)
				{
					constructorReactions = new Dictionary<string, ConstructorInfo>();
					constructorReactions.Add("EnemyChargeAiReaction", typeof(EnemyChargeAiReaction).GetConstructors()[0]);
					constructorReactions.Add("OnHostileReallyCloseAggressiveAiReaction", typeof(OnHostileReallyCloseAggressiveAiReaction).GetConstructors()[0]);
					constructorReactions.Add("OnHitAiReaction", typeof(OnHitAiReaction).GetConstructors()[0]);
					constructorReactions.Add("OnMissAiReaction", typeof(OnMissAiReaction).GetConstructors()[0]);
					constructorReactions.Add("AttackFirstTargetInPerceptionAiReaction", typeof(AttackFirstTargetInPerceptionAiReaction).GetConstructors()[0]);
					constructorReactions.Add("PetAttackAiReaction", typeof(PetAttackAiReaction).GetConstructors()[0]);
					constructorReactions.Add("LoadFlammableRoundAiReaction", typeof(LoadFlammableRoundAiReaction).GetConstructors()[0]);
					constructorReactions.Add("MaintainHoldGroundAiReaction", typeof(MaintainHoldGroundAiReaction).GetConstructors()[0]);
					constructorReactions.Add("EnemyMaintainHoldGroundAiReaction", typeof(EnemyMaintainHoldGroundAiReaction).GetConstructors()[0]);
					constructorReactions.Add("FaceHostileInPerceptionAiReaction", typeof(FaceHostileInPerceptionAiReaction).GetConstructors()[0]);
					constructorReactions.Add("RemoveInvalidAndBehindDoorTargetsReaction", typeof(RemoveInvalidAndBehindDoorTargetsReaction).GetConstructors()[0]);
					constructorReactions.Add("AttackClosestHostileInPerceptionAiReaction", typeof(AttackClosestHostileInPerceptionAiReaction).GetConstructors()[0]);
					constructorReactions.Add("OnHitAiAlertReaction", typeof(OnHitAiAlertReaction).GetConstructors()[0]);
				}
				return constructorReactions;
			}
		}

		public static Dictionary<string, ConstructorInfo> Sensors
		{
			get
			{
				if (constructorSensors == null)
				{
					constructorSensors = new Dictionary<string, ConstructorInfo>();
					constructorSensors.Add("CoreCombatSensor", typeof(CoreCombatSensor).GetConstructors()[0]);
					constructorSensors.Add("EnemyFollowSensor", typeof(EnemyFollowSensor).GetConstructors()[0]);
					constructorSensors.Add("HostileProximitySensor", typeof(HostileProximitySensor).GetConstructors()[0]);
					constructorSensors.Add("ClosestAttackableProximitySensor", typeof(ClosestAttackableProximitySensor).GetConstructors()[0]);
					constructorSensors.Add("HoldGroundCombatSensor", typeof(HoldGroundCombatSensor).GetConstructors()[0]);
				}
				return constructorSensors;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			constructorGoals = null;
			constructorReactions = null;
			constructorSensors = null;
		}
	}
}
