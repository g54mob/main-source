using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using GOAP.Action;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class TendWoundsGoal : Goal
	{
		private const int WoundedSearchLimit = 10;

		private const float XpRewardSeverityMultiplier = 2f;

		private const float MedicineMaxDistance = 100f;

		private bool hasMedicineInStorage;

		private CreatureBase patient;

		private VillageMap map;

		public TendWoundsGoal(Agent selfAgent)
			: base("TendWoundsGoal", selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<CreatureBase>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(CheckIfHasMedicine, FindWounded));
		}

		public override void Dispose()
		{
			base.Dispose();
			patient = null;
			map = null;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.HasFainted || creatureBase.IsOnFire)
			{
				return false;
			}
			HashSet<CreatureBase> woundedCreatures = MonoSingleton<CreatureManager>.Instance.WoundedCreatures;
			if (((HumanoidInstance)base.AgentOwner).IsReceivingWoundTreatman)
			{
				return false;
			}
			if (woundedCreatures.Count <= 0)
			{
				return false;
			}
			if (woundedCreatures.Any(delegate(CreatureBase item)
			{
				if (item == (CreatureBase)base.AgentOwner)
				{
					return false;
				}
				if (!item.HasUntendendWounds())
				{
					return false;
				}
				if (item.IsOnFire)
				{
					return false;
				}
				if (item.IsReceivingWoundTreatman)
				{
					return false;
				}
				if (CheckIfPatientAlreadyReservedByDoctor(item))
				{
					return false;
				}
				return item.CanReceiveWoundTreatment ? true : false;
			}))
			{
				return true;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.PreferredReservableHandler?.SetPreferLastReserved(value: true);
			base.PreferredReservableHandler?.ClearTarget();
			if (patient != null && !patient.HasDied && !patient.HasDisposed)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(86, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\TendWoundsGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TendWounds goal ended, patient IsReceivingWoundTreatment: ");
					messageBuilder.AppendFormatted(patient.IsReceivingWoundTreatman);
					messageBuilder.AppendLiteral(", CanReceiveWoundTreatment: ");
					messageBuilder.AppendFormatted(patient.CanReceiveWoundTreatment);
				}
				Log.Debug(messageBuilder);
				patient.IsReceivingWoundTreatman = false;
				if (patient is AnimalInstance animalInstance)
				{
					animalInstance.GetGoapAgent()?.StartTicker();
					animalInstance.CanReceiveWoundTreatment = false;
				}
				patient = null;
			}
			base.EndGoalWith(condition);
		}

		public static GoapAction TreatWounds(HumanoidInstance doctor, CreatureBase wounded)
		{
			float treatmentTime = (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour * doctor.GetAttribute(AttributeType.TendingSpeed).Value;
			float num = doctor.GetAttributeValue(AttributeType.Clumsiness);
			if (num == 0f)
			{
				num = 1f;
			}
			float num2 = Random.Range(0f, 1f) / num;
			bool shouldFail = num2 <= doctor.GetAttributeValue(AttributeType.TendingFailChance);
			float failAtProgress = Random.Range(0.3f, 0.6f);
			GoapAction treatWounds = new GoapAction("TreatWounds");
			treatWounds.OnInit = delegate
			{
				doctor.FaceObject(wounded.GetPosition());
				wounded.IsReceivingWoundTreatman = true;
				((IToolAgent)doctor).SetTool("bandage_item", doctor.GetAgentView<WorkerView>().BodyPreview.RightHandSocket);
			};
			treatWounds.OnTick = delegate
			{
				if (wounded.IsOnFire || doctor.IsOnFire)
				{
					DamagePopup.Create(wounded.GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("wound_tending_fail"), Color.red);
					treatWounds.Complete(ActionCompletionStatus.Fail);
				}
				else if (shouldFail && !(treatWounds.TotalTickingTime / treatmentTime < failAtProgress))
				{
					DamagePopup.Create(wounded.GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("wound_tending_fail"), Color.red);
					treatWounds.Complete(ActionCompletionStatus.Fail);
				}
			};
			float time = -1f;
			treatWounds.CompleteAfterTimeExpires(treatmentTime);
			treatWounds.FailAtCondition(delegate
			{
				if (wounded.CanReceiveWoundTreatment)
				{
					time = -1f;
					return false;
				}
				if (time < 0f)
				{
					time = Time.time;
					return false;
				}
				return Time.time - time > 0.65f;
			});
			string triggerName = ((doctor != wounded) ? "TreatWounds" : "TreatSelf");
			treatWounds.OnComplete = delegate
			{
				((IToolAgent)doctor).HideTool();
			};
			treatWounds.TriggerAnimation(triggerName, ActionAnimationMode.Interrupt);
			treatWounds.WithProgressBar(TargetIndex.A, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => treatWounds.TotalTickingTime / treatmentTime);
			return treatWounds;
		}

		public static void ApplyWoundTreatment(HumanoidInstance doctor, CreatureBase wounded, Resource medKitResource, float additionalHealingMultiplier = 1f)
		{
			float num = doctor.GetAttribute(AttributeType.TendingQuality).Value;
			if (medKitResource != null && medKitResource.Healing > 1f)
			{
				num *= medKitResource.Healing * additionalHealingMultiplier;
			}
			wounded.TendWounds(num);
			MonoSingleton<HealthLogManager>.Instance.LogHealing(doctor, wounded);
			DamagePopup.Create(wounded.GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("wound_tending_completed"), Color.green);
		}

		public static void RewardMedicalExperience(HumanoidInstance doctor, CreatureBase patient, float additionalXpMultiplier = 1f)
		{
			List<ActiveEffectorInfo> tendedWounds = patient.GetTendedWounds();
			if (tendedWounds == null || tendedWounds.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (ActiveEffectorInfo item in tendedWounds)
			{
				if (item.WoundInfo != null)
				{
					num += item.WoundInfo.CurrentSeverity;
				}
			}
			num *= 2f * additionalXpMultiplier;
			doctor.AddExperience(SkillType.Medicine, num);
		}

		public static bool IsBedAvailableForMedicalTending(BedComponentInstance bed, HumanoidInstance patient)
		{
			if (bed == null)
			{
				return false;
			}
			if (!CommonGoalMethods.CheckPrisonConditions(patient, bed.GetRoom()))
			{
				return false;
			}
			bool num = !bed.HasDisposed && bed.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished;
			bool flag = bed.OwnerBuilding.BuildingOwnershipInfo == null || !bed.OwnerBuilding.BuildingOwnershipInfo.Occupied || bed.OwnerBuilding.BuildingOwnershipInfo.IsOwner(patient);
			if (num && flag && !bed.Underwater)
			{
				return !bed.IsOnFire;
			}
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			CreatureBase creaturePatient = GetTarget(TargetIndex.A).GetObjectAs<CreatureBase>();
			HumanoidInstance humanoidDoctor = (HumanoidInstance)base.AgentOwner;
			GoapAction goToWorkerPatient = GoToActions.GoToTarget(TargetIndex.C, PathCompleteMode.Touch).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.C)
				.FailAtCondition(() => !creaturePatient.CanReceiveWoundTreatment || creaturePatient.IsOnFire, spamLogs: true);
			GoapAction goToAnimalPatient = GoToActions.GoToCreatureTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailAtCondition(() => !creaturePatient.CanReceiveWoundTreatment || creaturePatient.IsOnFire);
			if (GetTarget(TargetIndex.B).IsInitialized)
			{
				Log.Debug("Medpack exists - doctor is going to pick that up", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\TendWoundsGoal.cs");
				yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.Touch).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
				yield return ResourceActions.PickupResourceFromPile(TargetIndex.B, 1).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			}
			if (patient is AnimalInstance)
			{
				yield return goToAnimalPatient;
			}
			else
			{
				yield return goToWorkerPatient;
			}
			if (creaturePatient is AnimalInstance)
			{
				yield return TreatWounds(humanoidDoctor, creaturePatient).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).StopAnimalTickerWhenInRange(TargetIndex.A).RestoreAnimalTickerOnFail(TargetIndex.A);
			}
			else
			{
				yield return TreatWounds(humanoidDoctor, creaturePatient).FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			}
			GoapAction goapAction = new GoapAction("ApplyWoundTreatment");
			goapAction.OnInit = delegate
			{
				if (hasMedicineInStorage)
				{
					ResourceInstance resourceInstance = humanoidDoctor.MedicineStorage.Resources.FirstOrDefault();
					if (resourceInstance != null)
					{
						humanoidDoctor.Storage.Add(resourceInstance);
						humanoidDoctor.MedicineStorage.DeleteResource(resourceInstance);
					}
				}
				Resource resource = (humanoidDoctor.Storage.IsEmpty() ? null : humanoidDoctor.Storage.FirstResource.Blueprint);
				ApplyWoundTreatment(humanoidDoctor, creaturePatient, resource);
				if (resource != null)
				{
					humanoidDoctor.DestroyStorage();
				}
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					RewardMedicalExperience(humanoidDoctor, creaturePatient);
				}
			};
			yield return goapAction;
		}

		private bool CheckIfPatientAlreadyReservedByDoctor(CreatureBase creaturePatient)
		{
			List<IGoapAgentOwner> reservers = MonoSingleton<ReservationManager>.Instance.GetReservers(creaturePatient);
			if (reservers == null || reservers.Count == 0)
			{
				return false;
			}
			foreach (IGoapAgentOwner item in reservers)
			{
				if (item != base.AgentOwner && item is HumanoidInstance humanoidInstance && humanoidInstance.GoapAgent.CurrentGoalName == "TendWoundsGoal")
				{
					return true;
				}
			}
			return false;
		}

		private bool FindWounded()
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			ReservationManager instance = MonoSingleton<ReservationManager>.Instance;
			List<BedComponentInstance> list = new List<BedComponentInstance>();
			if (base.PreferredReservableHandler.HasTarget())
			{
				CreatureBase objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<CreatureBase>();
				if (objectAs != null && !objectAs.HasDisposed && objectAs.IsWounded && !objectAs.IsReceivingWoundTreatman && !objectAs.IsOnFire && !CheckIfPatientAlreadyReservedByDoctor(objectAs) && instance.TryReserveObject(objectAs, base.AgentOwner) && base.Agent.LastForceStartedGoal == this)
				{
					BaseBuildingInstance baseBuildingInstance = (BaseBuildingInstance)(instance.GetReservedBy(objectAs)?.FirstOrDefault((IReservable item) => item is BaseBuildingInstance));
					SetTarget(TargetIndex.A, new TargetObject(objectAs));
					SetTarget(TargetIndex.C, (baseBuildingInstance != null) ? new TargetObject(baseBuildingInstance) : new TargetObject(objectAs));
					patient = objectAs;
					patient.CanReceiveWoundTreatment = true;
					MonoSingleton<ReservationManager>.Instance.ClearPreferedReservable(creatureBase);
					FindAndTargetMedicine();
					return true;
				}
			}
			using PooledList<CreatureBase> pooledList = ListPool<CreatureBase>.GetJanitor(MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.Where((HumanoidInstance item) => item.HasUntendendWounds() && !item.IsOnFire));
			if (pooledList.Count == 0)
			{
				IEnumerable<CreatureBase> collection = MonoSingleton<CreatureManager>.Instance.WoundedCreatures.Where(delegate(CreatureBase item)
				{
					if (item is AnimalInstance { AnimalType: AnimalType.Domestic })
					{
						return true;
					}
					return (item is HumanoidInstance humanoidInstance && humanoidInstance.IsCaptive() && humanoidInstance.CaptiveNpcBehaviour.IsInPrisonCell) ? true : false;
				});
				pooledList.Clear();
				pooledList.AddRange(collection);
				if (pooledList.Count == 0)
				{
					return false;
				}
			}
			CreatureBase creatureBase2 = null;
			BedComponentInstance targetObj = null;
			float num = 0f;
			int num2 = 0;
			foreach (BedComponentInstance componentInstance in map.BedComponentManager.ComponentInstances)
			{
				if (componentInstance == null || componentInstance.HasDisposed || componentInstance.IsOnFire)
				{
					continue;
				}
				IGoapAgentOwner singleReserver = instance.GetSingleReserver(componentInstance);
				if (singleReserver == null)
				{
					list.Add(componentInstance);
				}
				if (singleReserver == null || singleReserver == creatureBase)
				{
					continue;
				}
				CreatureBase creatureBase3 = (CreatureBase)singleReserver;
				if (creatureBase3.IsWounded && !creatureBase3.IsReceivingWoundTreatman && creatureBase3.CanReceiveWoundTreatment && PathfinderUtil.IsPathPossible(creatureBase, componentInstance) && MonoSingleton<ReservationManager>.Instance.CanReserve(creatureBase3, base.AgentOwner) && !MonoSingleton<ReservationManager>.Instance.IsReserved(creatureBase3))
				{
					float scoreWounded = GetScoreWounded(creatureBase3);
					if (creatureBase2 == null || scoreWounded > num)
					{
						num = scoreWounded;
						creatureBase2 = creatureBase3;
						targetObj = componentInstance;
					}
					num2++;
					if (num2 >= 10)
					{
						break;
					}
				}
			}
			if (creatureBase2 != null && MonoSingleton<ReservationManager>.Instance.TryReserveObject(creatureBase2, base.AgentOwner))
			{
				SetTarget(TargetIndex.A, new TargetObject(creatureBase2));
				SetTarget(TargetIndex.C, new TargetObject(targetObj));
				FindAndTargetMedicine();
				patient = creatureBase2;
				return true;
			}
			using PooledList<CreatureBase> pooledList2 = ListPool<CreatureBase>.GetJanitor(pooledList.Where((CreatureBase item) => item.HasFainted && !item.IsBeingCarried && !item.IsOnFire && (item.GetGoapAgent()?.CurrentGoalName.Equals("FaintGoal") ?? false)));
			if (!pooledList2.Any())
			{
				return false;
			}
			foreach (BedComponentInstance bed in list)
			{
				if (pooledList2.Any((CreatureBase faintedPatient) => faintedPatient is HumanoidInstance humanoidInstance && IsBedAvailableForMedicalTending(bed, humanoidInstance)))
				{
					return false;
				}
			}
			float num3 = 0f;
			CreatureBase creatureBase4 = null;
			foreach (CreatureBase item in pooledList2)
			{
				if (PathfinderUtil.IsPathPossible((IPathfindingAgent)base.AgentOwner, item.GetGridPosition()))
				{
					float num4 = Vector3.Distance(item.GetPosition(), creatureBase.GetPosition());
					if ((creatureBase4 == null || num4 < num3) && MonoSingleton<ReservationManager>.Instance.CanReserve(item, base.AgentOwner) && !item.IsReceivingWoundTreatman)
					{
						num3 = num4;
						creatureBase4 = item;
					}
				}
			}
			if (creatureBase4 != null)
			{
				SetTarget(TargetIndex.A, new TargetObject(creatureBase4));
				SetTarget(TargetIndex.C, new TargetObject(creatureBase4));
				FindAndTargetMedicine();
				patient = creatureBase4;
				return true;
			}
			return false;
		}

		private bool CheckIfHasMedicine()
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			hasMedicineInStorage = !humanoidInstance.MedicineStorage.IsEmpty();
			return true;
		}

		private void FindAndTargetMedicine()
		{
			if (!hasMedicineInStorage)
			{
				ResourcePileInstance resourcePileInstance = CommonGoalMethods.FindMedicine((HumanoidInstance)base.AgentOwner, GetTarget(TargetIndex.A).ReachablePosition);
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(resourcePileInstance, base.AgentOwner))
				{
					SetTarget(TargetIndex.B, new TargetObject(resourcePileInstance));
				}
			}
		}

		private float GetScoreWounded(IDamageCommonAgent creature)
		{
			float num = 0f;
			foreach (ActiveEffectorInfo activeEffector in creature.Stats.GetActiveEffectors())
			{
				if (activeEffector.WoundInfo != null)
				{
					num += activeEffector.WoundInfo.CurrentSeverity;
				}
			}
			return num;
		}
	}
}
