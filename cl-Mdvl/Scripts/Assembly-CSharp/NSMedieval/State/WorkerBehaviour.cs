using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using Models.Type;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CombatAi;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.DebugEvents;
using NSMedieval.Dialogs.Data;
using NSMedieval.Dictionary;
using NSMedieval.Draft;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.StorageUniversal;
using NSMedieval.Tools;
using NSMedieval.Tools.Math;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.State
{
	[FVSerializableKey("WorkerBehaviour", "WorkerBehavior")]
	public class WorkerBehaviour : HumanoidBehaviour, ITrader
	{
		private const string FoodManageGroupId = "food_manage_group";

		private const string StimulantsManageGroupId = "stimulants_manage_group";

		[SerializeField]
		private JobType activeJobCombination;

		[SerializeField]
		private StringStringDictionary selectedManagePresets;

		[SerializeField]
		private JobTypeIntDictionary jobPriorities;

		[SerializeField]
		private HourType[] scheduleHours;

		[NonSerialized]
		private bool hasInitializedJobs;

		[NonSerialized]
		private HashSet<string> allowedToConsume = new HashSet<string>();

		[NonSerialized]
		private Dictionary<string, WorkerCombatAiAgent> combatAiAgents;

		[NonSerialized]
		private WorkerView view;

		[NonSerialized]
		private HumanoidInstance prioritiseAssistanceToHumanoid;

		[NonSerialized]
		private string equipItemOnSpawn;

		[NonSerialized]
		private bool isAttachedToStorageEvents;

		[SerializeField]
		private bool isBanished;

		[SerializeField]
		private bool isAllowedSelfTending;

		[SerializeField]
		private UnitCombatModeType combatMode;

		[SerializeField]
		private UnitCombatModeType combatModeUndraftedSaved = UnitCombatModeType.Flee;

		[SerializeField]
		private UnitCombatModeType combatModeDraftedSaved = UnitCombatModeType.DraftedDefault;

		private WorkerInstanceSocial workerSocial;

		private WorkerInstanceInteraction workerInteraction;

		public string JealousOfWorkersBedroom { get; set; }

		protected override string HumanTypeId => "worker";

		public override DamageTakingAgentType DamageAgentType => DamageTakingAgentType.Worker;

		public override DamageTakingAgentType CanAttackTypes => DamageTakingAgentType.All;

		public override BehaviourType BehaviourType => BehaviourType.Worker;

		public StatsInstance Stats => base.Humanoid.Stats;

		public Storage Storage => base.Humanoid.Storage;

		public Storage FoodStorage => base.Humanoid.FoodStorage;

		public Storage MedicineStorage => base.Humanoid.MedicineStorage;

		public WorkerCombatAiAgent CombatAgent => (WorkerCombatAiAgent)base.Humanoid.CombatAi;

		public bool IsIdle { get; private set; }

		public JobType ActiveJobCombination => activeJobCombination;

		[field: NonSerialized]
		public HourType ForcedWorkHour { get; internal set; } = HourType.None;

		public HourType[] ScheduleHours => scheduleHours;

		public bool IsDrafting => ForcedWorkHour == HourType.Draft;

		public bool IsCrazy => ForcedWorkHour == HourType.PsyhoticCrazy;

		public bool IsResting => Stats.IsEffectorActive(base.HumanType.RestEffector);

		public bool IsAllowedSelfTending => isAllowedSelfTending;

		public UnitCombatModeType CombatMode => combatMode;

		public long LastDraftOrderTime { get; set; }

		public DraftOrder LastDraftOrder { get; set; }

		public bool UseRallyPoints { get; set; } = true;

		public bool IsBanished => isBanished;

		public Worker WorkerBlueprint => base.Blueprint as Worker;

		public bool HasRoleSchedule
		{
			get
			{
				if (scheduleHours != null)
				{
					return scheduleHours.Contains(HourType.RoleJob);
				}
				return false;
			}
		}

		private HashSet<string> AllowedToConsume => allowedToConsume;

		public FactionInstance Faction => base.Humanoid.Faction;

		public StringStringDictionary SelectedManagePresets
		{
			get
			{
				if (selectedManagePresets == null)
				{
					selectedManagePresets = new StringStringDictionary();
				}
				if (selectedManagePresets.Dictionary.Count == 0)
				{
					foreach (ManageGroupPreset userPreset in Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets)
					{
						if (!selectedManagePresets.Dictionary.ContainsKey(userPreset.GroupId) && userPreset.DefaultPreset)
						{
							selectedManagePresets.Dictionary.Add(userPreset.GroupId, userPreset.GetID());
						}
					}
				}
				return selectedManagePresets;
			}
		}

		public WorkerGoapAgent WorkerGoapAgent => (WorkerGoapAgent)base.GoapAgent;

		public string EquipItemOnSpawn
		{
			get
			{
				return equipItemOnSpawn;
			}
			set
			{
				equipItemOnSpawn = value;
			}
		}

		public override bool ProximityDetection => true;

		public bool IsProtectiveAgainstPredators => WorkerProximity.IsProtectiveAgainstPredators;

		public WorkerBehaviourProximity WorkerProximity => base.ProximityBehaviour as WorkerBehaviourProximity;

		public WorkerInstanceSocial WorkerSocial => workerSocial ?? (workerSocial = new WorkerInstanceSocial(base.Humanoid));

		public WorkerInstanceInteraction WorkerInteraction => workerInteraction ?? (workerInteraction = new WorkerInstanceInteraction(base.Humanoid));

		public event Action ForcedWorkHourChangeEvent;

		public event Action<HumanoidInstance> CombatModeChangeEvent;

		protected override ProximityBehaviour GetProximityBehaviour()
		{
			return new WorkerBehaviourProximity(base.Humanoid);
		}

		public WorkerBehaviour()
		{
		}

		protected override void OnBeforeFirstActivate()
		{
			if (activeJobCombination == JobType.None && jobPriorities == null)
			{
				foreach (Job workerJob in Repository<JobRepository, Job>.Instance.GetWorkerJobs())
				{
					activeJobCombination |= workerJob.JobType;
				}
			}
			ForcedWorkHour = HourType.None;
			if (scheduleHours == null)
			{
				int[] config = base.HumanType.ScheduleConfig.Config;
				scheduleHours = new HourType[config.Length];
				Array.Copy(config, 0, scheduleHours, 0, config.Length);
			}
			WorkerGoapAgent.RefreshWorkHour();
			InitJobPriorities();
			InitJobConfig();
		}

		protected override Agent CreateGoapAgent()
		{
			return new WorkerGoapAgent(base.Humanoid);
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			base.Humanoid.SetWalkableModel(base.HumanType.WalkableModelFriendly);
			if (SelectedManagePresets.Dictionary.Count > 0)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(RebuildAllowedToConsume);
			}
			MonoSingleton<WorkerController>.Instance.EquipmentPresetUpdatedEvent += OnEquipmentPresetUpdated;
			AttachToStorageEvents();
			MonoSingleton<WorkerController>.Instance.FoodStorageChanged(base.Humanoid);
			MonoSingleton<WorkerController>.Instance.MedicineStorageChanged(base.Humanoid);
			if (!string.IsNullOrEmpty(EquipItemOnSpawn))
			{
				EquipmentInstance equipmentInstance = new EquipmentInstance(EquipItemOnSpawn, isManuallyEquiped: false);
				equipmentInstance.GetStat(StatType.Health).SetCurrent(NSMedieval.Tools.Math.Random.Range(1f, Repository<ResourceRepository, Resource>.Instance.GetByID(EquipItemOnSpawn).Hitpoints));
				base.Inventory.Equip(equipmentInstance, removeInsteadOfDrop: true);
				equipItemOnSpawn = null;
			}
			if (Storage.GetSingleResource() != null)
			{
				base.Humanoid.DropStorage();
			}
			WorkerProximity.ResetAllProximityTimeouts();
			base.Humanoid.AvailableForInteraction = true;
			base.Humanoid.Map.BeautyManager.OnOutputRetrieved += OnFirstBeautyOutputRetrieved;
			MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent += WorkerSocial.OnWorkerSpawn;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourChange;
			MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourChange;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateChange;
			WorkerGoapAgent.RefreshWorkHour();
		}

		protected override void OnDeactivate()
		{
			base.OnDeactivate();
			DetachFromStorageEvents();
		}

		public void Setup()
		{
			SetCombatMode((combatMode == UnitCombatModeType.None) ? UnitCombatModeType.Flee : combatMode, combatMode != UnitCombatModeType.None);
			if (combatMode.IsDrafted())
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					base.Humanoid.GetAgentView<WorkerView>()?.StartDraft();
				});
			}
			base.Humanoid.RecalcuateGoalPreferencesAndSkillModifiers();
			WorkerSocial.OnSetupSocial();
		}

		public override void Dispose()
		{
			base.Dispose();
			using PooledList<AnimalInstance> pooledList = ListPool<AnimalInstance>.GetJanitor(base.Humanoid.Pets);
			foreach (AnimalInstance item in pooledList)
			{
				item.AssignPetOwner(null);
			}
			if (base.GoapAgent != null)
			{
				CaravanInstance preparingForCaravan = ((IFormCaravanGoapAgent)base.GoapAgent).PreparingForCaravan;
				if (preparingForCaravan != null && MonoSingleton<CaravanFormingManager>.IsInstantiated())
				{
					MonoSingleton<CaravanFormingManager>.Instance.CancelCaravanForming(preparingForCaravan);
				}
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.EquipmentPresetUpdatedEvent -= OnEquipmentPresetUpdated;
			}
			if (base.Humanoid.DontSpawnCarcassOnDispose)
			{
				DetachFromStorageEvents();
				base.Humanoid.Inventory?.DisposeEvents();
				base.Humanoid.Inventory?.DestroyEquipmentSilent();
				Storage?.ClearAll();
				FoodStorage?.ClearAll();
				MedicineStorage?.ClearAll();
			}
			base.Humanoid.WarmthInstance?.Dispose();
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourChange;
				MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourChange;
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateChange;
			}
			if (MonoSingleton<StorageCommonManager>.IsInstantiated())
			{
				MonoSingleton<StorageCommonManager>.Instance.ReleaseAllStorageReservations(base.Humanoid);
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.SpawnWorkerEvent -= WorkerSocial.OnWorkerSpawn;
			}
		}

		public bool IsJobActive(JobType jobType)
		{
			return (ActiveJobCombination & jobType) != 0;
		}

		public void SetCombatMode(UnitCombatModeType newCombatMode, bool force = false)
		{
			if (!force && (CombatMode == newCombatMode || newCombatMode == UnitCombatModeType.None))
			{
				return;
			}
			if (CombatMode != UnitCombatModeType.None)
			{
				Worker.CombatModeSettings combatModeSettings = WorkerBlueprint.CombatModes.FirstOrDefault((Worker.CombatModeSettings item) => item.ModeType == CombatMode);
				if (combatModeSettings.ModeType != UnitCombatModeType.None)
				{
					base.Humanoid.Stats.EndEffector(combatModeSettings.Effector);
				}
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (newCombatMode.IsDrafted())
			{
				combatModeDraftedSaved = newCombatMode;
				messageBuilder = new FVLogDebugInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(" combatModeDraftedSaved = ");
					messageBuilder.AppendFormatted(combatModeDraftedSaved);
				}
				Log.Debug(messageBuilder);
			}
			else
			{
				combatModeUndraftedSaved = ((newCombatMode == UnitCombatModeType.None) ? UnitCombatModeType.Flee : newCombatMode);
				messageBuilder = new FVLogDebugInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(" combatModeUndraftedSaved = ");
					messageBuilder.AppendFormatted(combatModeUndraftedSaved);
				}
				Log.Debug(messageBuilder);
			}
			if (!newCombatMode.IsDrafted())
			{
				base.Humanoid.SetWeaponVisibility(isVisible: false);
				CombatUtils.GetWeapon(base.Humanoid)?.ConsumeFlammableProjectile();
			}
			if (CombatMode.IsDrafted() == newCombatMode.IsDrafted() && MonoSingleton<LocalizationController>.IsInstantiated() && base.Humanoid.HasView)
			{
				string text = newCombatMode.ToString();
				text = MonoSingleton<LocalizationController>.Instance.GetText("popup_worker_combat_mode_changed_" + text);
				DamagePopup.Create(base.Humanoid.GetPosition(), text);
			}
			combatMode = newCombatMode;
			messageBuilder = new FVLogDebugInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(this);
				messageBuilder.AppendLiteral(" combatMode = ");
				messageBuilder.AppendFormatted(combatMode);
			}
			Log.Debug(messageBuilder);
			this.CombatModeChangeEvent?.Invoke(base.Humanoid);
			Worker.CombatModeSettings combatModeSettings2 = WorkerBlueprint.CombatModes.FirstOrDefault((Worker.CombatModeSettings item) => item.ModeType == combatMode);
			if (combatModeSettings2.ModeType != UnitCombatModeType.None)
			{
				base.Humanoid.Stats.StartEffector(combatModeSettings2.Effector);
			}
			base.Humanoid.SetTarget(null);
			base.Humanoid.SetCombatAiAgent(combatModeSettings2.CombatAiAgent);
			view?.UpdateParticlesAndAnimationParams();
		}

		public void ForceWorkHour(HourType type)
		{
			if (isBanished || base.Humanoid.HasDisposed || type == ForcedWorkHour)
			{
				return;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(35, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(base.Humanoid);
				messageBuilder.AppendLiteral(" changed forced hour type from ");
				messageBuilder.AppendFormatted(ForcedWorkHour);
				messageBuilder.AppendLiteral(" to ");
				messageBuilder.AppendFormatted(type);
			}
			Log.Debug(messageBuilder);
			if (ForcedWorkHour == HourType.PsyhoticCrazy && type != HourType.PsyhoticCrazy)
			{
				string text = WorkerBlueprint?.AfterCrazyEffector;
				if (Stats != null && !string.IsNullOrEmpty(text) && !Stats.IsEffectorActive(text))
				{
					Stats.StartEffector(text);
				}
			}
			WorkerGoapAgent workerGoapAgent = (WorkerGoapAgent)base.Humanoid.GetGoapAgent();
			if (workerGoapAgent == null || workerGoapAgent.HasDisposed)
			{
				Log.Info("Should never happen. " + this, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
				return;
			}
			switch (type)
			{
			case HourType.Draft:
				SetCombatMode(combatModeDraftedSaved);
				break;
			default:
				SetCombatMode(combatModeUndraftedSaved);
				break;
			case HourType.PsyhoticCrazy:
				SetCombatMode(UnitCombatModeType.Flee);
				if (workerGoapAgent.PreparingForCaravan != null)
				{
					MonoSingleton<CaravanFormingManager>.Instance.CancelCaravanForming(workerGoapAgent.PreparingForCaravan);
				}
				workerGoapAgent.Abort();
				break;
			}
			if (type != HourType.Draft && workerGoapAgent.PreparingForCaravan != null)
			{
				ForcedWorkHour = HourType.Caravan;
			}
			else
			{
				ForcedWorkHour = type;
			}
			this.ForcedWorkHourChangeEvent?.Invoke();
			workerGoapAgent.RefreshWorkHour();
		}

		public bool StancesEnabled()
		{
			if (!IsCrazy)
			{
				return !IsBanished;
			}
			return false;
		}

		private void OnFoodStorageChanged(SimpleResourceCount count)
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.FoodStorageChanged(base.Humanoid);
			}
		}

		private void OnMedicineStorageChanged(SimpleResourceCount count)
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.MedicineStorageChanged(base.Humanoid);
			}
		}

		private void OnFoodStorageChanged(ResourceInstance resourceInstance)
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.FoodStorageChanged(base.Humanoid);
			}
		}

		private void OnMedicineStorageChanged(ResourceInstance resourceInstance)
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.MedicineStorageChanged(base.Humanoid);
			}
		}

		public void GoalUpdated(string goalId, bool hasStarted)
		{
			IsIdle = goalId.Equals("IdleGoal") && hasStarted;
			if (goalId.Equals("SleepGoal") && !hasStarted)
			{
				AgeDeathCategory ageDeathCategory = base.HumanType.OldAgeDeathRanges.FirstOrDefault((AgeDeathCategory category) => category.Range.InRange(base.Humanoid.Info.Age));
				if (ageDeathCategory != null && NSMedieval.Tools.Math.Random.Range(0f, 1f) <= ageDeathCategory.Chance)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("general_died_old_age", base.Humanoid));
					OnHealthDepleted(wasNaturalDeath: true);
				}
			}
		}

		public void SetSelfTendingAllowed(bool isSelfTendingAllowed)
		{
			isAllowedSelfTending = isSelfTendingAllowed;
		}

		private void InitJobPriorities()
		{
			if (hasInitializedJobs)
			{
				return;
			}
			hasInitializedJobs = true;
			if (jobPriorities == null)
			{
				jobPriorities = SerializableDictionary<JobType, int>.CreateNew<JobTypeIntDictionary>();
			}
			foreach (KeyValuePair<JobType, int> item in JobUtils.UpdatePrioritiesDictionary(jobPriorities, base.Humanoid).Dictionary)
			{
				RegisterJobPriority(item.Key, item.Value, !IsJobActive(item.Key));
			}
		}

		public void ModifyJobPriority(JobType jobType, int valueToAdd, bool removeJob)
		{
			int value = GetJobPriorityTruncated(jobType) + valueToAdd - 5;
			jobPriorities.Dictionary[jobType] = value;
			RegisterJobPriority(jobType, valueToAdd, removeJob);
		}

		private void RegisterJobPriority(JobType jobType, int jobPriority, bool removeJob)
		{
			if (removeJob)
			{
				RemoveActiveJob(jobType);
			}
			else
			{
				AddActiveJob(jobType);
			}
			((WorkerGoapAgent)base.GoapAgent).ChangeJobPriority(jobType, jobPriority);
			MonoSingleton<WorkerController>.Instance.WorkerJobPriorityChanged(base.Humanoid, jobType, GetJobPriorityTruncated(jobType));
		}

		public int GetJobPriorityTruncated(JobType jobType)
		{
			float jobPriority = ((WorkerGoapAgent)base.GoapAgent).GetJobPriority(jobType);
			return Mathf.RoundToInt((jobPriority - (float)(int)jobPriority) * 10f);
		}

		private void AddActiveJob(JobType jobType)
		{
			if (!activeJobCombination.HasFlag(jobType))
			{
				activeJobCombination |= jobType;
				UpdateJobSettings(jobType);
				MonoSingleton<GlobalWarningMessagesManager>.Instance.JobConfigUpdated(base.Humanoid);
				MonoSingleton<ProductionManager>.Instance.UpdateAllProductionStates();
			}
		}

		public void DraftedTick()
		{
			Agent agent = base.Humanoid.GetGoapAgent();
			if (agent == null || agent.CurrentGoalName != string.Empty || agent.IsGoalPreparing || (object)base.Humanoid.GetAgentView<WorkerView>() == null)
			{
				return;
			}
			IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(base.Humanoid);
			if (preferredTarget != null)
			{
				CreatureBase obj = preferredTarget as CreatureBase;
				if (obj != null && obj.HasFainted)
				{
					MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.Humanoid);
				}
			}
		}

		public void RemoveActiveJob(JobType jobType)
		{
			if (activeJobCombination.HasFlag(jobType))
			{
				activeJobCombination ^= jobType;
				((WorkerGoapAgent)base.GoapAgent).RefreshActiveJobs();
				UpdateJobSettings(jobType);
				MonoSingleton<GlobalWarningMessagesManager>.Instance.JobConfigUpdated(base.Humanoid);
				MonoSingleton<ProductionManager>.Instance.UpdateAllProductionStates();
			}
		}

		public void CannotBanish()
		{
			MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("action_banish_failed_no_path"));
			isBanished = false;
		}

		public void Banish(bool showConfirmPrompt = true)
		{
			if (!isBanished)
			{
				if (base.Humanoid.HasFainted)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("can_not_banish_while_fainted"));
					return;
				}
				if (IsCrazy)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("settler_is_rebellious"));
					return;
				}
				if (!showConfirmPrompt)
				{
					DoBanish();
					return;
				}
				List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>();
				list.Add(new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), DoBanish));
				list.Add(new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
				{
				}));
				MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("banish_worker_confirm", list));
			}
		}

		public void ShowPathDestinationLine(Vector3 dest)
		{
			base.Humanoid.GetAgentView<WorkerView>()?.ShowPathDestinationLine(dest);
		}

		public void OnRoomTypeRefreshed()
		{
			RefreshRoomSizeEffectors(base.Humanoid.Room);
		}

		public void OnRoomTypeChanged()
		{
			OnRoomChanged(base.Humanoid.Room, base.Humanoid.Room);
		}

		public override void HandleOnEquipmentDestroyed(EquipmentInstance item)
		{
			if (LoadingController.IsSceneTransition || MonoSingleton<GlobalSaveController>.IsApplicationIsQuitting())
			{
				return;
			}
			base.HandleOnEquipmentDestroyed(item);
			if (item.Blueprint.ItemType == ItemType.Weapon)
			{
				base.Humanoid.SetTarget(null);
				if (MonoSingleton<CombatTargetManager>.IsInstantiated())
				{
					MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.Humanoid);
				}
				AttackType attackType = CombatUtils.GetAttackType(base.Humanoid);
				if ((attackType == AttackType.RangeChargeBefore || attackType == AttackType.RangeChargeAfter) && MonoSingleton<GlobalWarningMessagesManager>.IsInstantiated())
				{
					MonoSingleton<GlobalWarningMessagesManager>.Instance.OnEquipmentChanged();
				}
			}
		}

		public override void OnRoomChanged(Room oldRoom, Room newRoom)
		{
			if (oldRoom != newRoom)
			{
				base.HumanoidRoleOwner.CheckRoleRoomEffectors();
			}
			if (newRoom != null && newRoom.RoomType != null && newRoom.RoomType.IsReligious)
			{
				ReligionConfig configForFaith = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(Stats.GetStat(StatType.ReligiousAlignment).Current);
				if (configForFaith != null)
				{
					if (configForFaith.RoomTypes.Contains(newRoom.RoomType.GetID()))
					{
						Stats.StartEffectors(configForFaith.GetBelieverEffectors(newRoom.Impressiveness));
					}
					else
					{
						Stats.StartEffectors(configForFaith.GetNonBelieverEffectors(newRoom.Impressiveness));
					}
				}
			}
			RefreshRoomSizeEffectors(newRoom);
			if (newRoom?.RoomType?.ResidenceEffectors != null)
			{
				RoomType roomType = newRoom.RoomType;
				if ((object)roomType != null && roomType.ResidenceEffectors.Length != 0)
				{
					Stats.StartEffectors(newRoom.RoomType?.ResidenceEffectors);
				}
			}
			if (oldRoom == null || oldRoom == newRoom || oldRoom?.RoomType?.ResidenceEffectors == null || oldRoom.RoomType.ResidenceEffectors.Length == 0)
			{
				return;
			}
			string[] array = oldRoom.RoomType?.ResidenceEffectors;
			foreach (string name in array)
			{
				if (Stats.IsEffectorActive(name))
				{
					Stats.EndEffector(name);
				}
			}
		}

		public override void AttendPlayerTriggeredEvent(string goalId)
		{
			WorkerGoapAgent.AttendPlayerTriggeredEvent(goalId);
		}

		public override void LeavePlayerTriggeredEvent(string goalId)
		{
			WorkerGoapAgent.LeavePlayerTriggeredEvent();
		}

		private void RefreshRoomSizeEffectors(Room room)
		{
			if (room != null && room.FreeSpace < 10 && room.GetBuildingTypeCount(BuildingType.Window) == 0)
			{
				if (!Stats.IsEffectorActive("SmallRoomNoWindows"))
				{
					Stats.StartEffector("SmallRoomNoWindows");
				}
			}
			else if (Stats.IsEffectorActive("SmallRoomNoWindows"))
			{
				Stats.EndEffector("SmallRoomNoWindows");
			}
			if (room != null && room.FreeSpace > 60 && room.GetBuildingTypeCount(BuildingType.Window) > 0)
			{
				if (!Stats.IsEffectorActive("BigRoomWithWindows"))
				{
					Stats.StartEffector("BigRoomWithWindows");
				}
			}
			else if (Stats.IsEffectorActive("BigRoomWithWindows"))
			{
				Stats.EndEffector("BigRoomWithWindows");
			}
		}

		private void OnFirstBeautyOutputRetrieved()
		{
			base.Humanoid.SetBeautyTarget();
			base.Humanoid.Map.BeautyManager.OnOutputRetrieved -= OnFirstBeautyOutputRetrieved;
		}

		private void OnEquipmentPresetUpdated(ManageGroupPreset preset)
		{
			KeyValuePair<string, string> keyValuePair = default(KeyValuePair<string, string>);
			foreach (KeyValuePair<string, string> item in selectedManagePresets.Dictionary)
			{
				if (item.Value.Equals(preset.GetID()))
				{
					keyValuePair = item;
				}
			}
			if (!keyValuePair.Equals(default(KeyValuePair<string, string>)))
			{
				UpdateSingleManagePreset(keyValuePair.Key, keyValuePair.Value);
			}
		}

		public void UpdateSingleManagePreset(string groupId, string presetId, bool forceAutoEquipGoal = true)
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed && base.Humanoid.Inventory != null)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Update manage preset '");
					messageBuilder.AppendFormatted(groupId);
					messageBuilder.AppendLiteral("' = '");
					messageBuilder.AppendFormatted(presetId);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
				selectedManagePresets.Dictionary[groupId] = presetId;
				RebuildAllowedToConsume();
				if (forceAutoEquipGoal)
				{
					MonoSingleton<TaskController>.Instance.OptimizedCall(this, "ForceAutoEquip", ForceAutoEquip, 1f, unscaledTime: false);
				}
			}
		}

		public void RebuildAllowedToConsume()
		{
			if (base.Humanoid == null || base.Humanoid.HasDisposed || base.Humanoid.Inventory == null || SelectedManagePresets.Dictionary.Count == 0)
			{
				return;
			}
			if (allowedToConsume == null)
			{
				allowedToConsume = new HashSet<string>();
			}
			allowedToConsume.Clear();
			foreach (KeyValuePair<string, string> item in selectedManagePresets.Dictionary)
			{
				item.Deconstruct(out var key, out var value);
				string groupId = key;
				string presetId = value;
				ManageGroupPreset manageGroupPreset = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets.FirstOrDefault((ManageGroupPreset preset) => preset.GetID() == presetId);
				List<string> list = manageGroupPreset?.GetAllowedResources(HumanoidBehaviour.DateTime);
				if (manageGroupPreset == null || list == null)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(73, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("ManageGroupPreset not found: groupId = ");
						messageBuilder.AppendFormatted(groupId);
						messageBuilder.AppendLiteral(", presetId = ");
						messageBuilder.AppendFormatted(presetId);
						messageBuilder.AppendLiteral(". Setting to default.");
					}
					Log.Info(messageBuilder);
					manageGroupPreset = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.GetAllItems().FirstOrDefault((ManageGroupPreset preset) => groupId.Equals(preset.GroupId));
					list = manageGroupPreset?.GetAllowedResources(HumanoidBehaviour.DateTime);
					if (manageGroupPreset == null || list == null)
					{
						messageBuilder = new FVLogInfoInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\WorkerBehaviour.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Failed loading default preset with group id ");
							messageBuilder.AppendFormatted(groupId);
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
						break;
					}
				}
				if (groupId.Equals("food_manage_group") || groupId.Equals("stimulants_manage_group"))
				{
					allowedToConsume.UnionWith(list);
					allowedToConsume.ExceptWith(manageGroupPreset.GetForbiddenResources(HumanoidBehaviour.DateTime));
				}
			}
		}

		private void ForceAutoEquip()
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed && base.GoapAgent != null && !base.Humanoid.HasDiedOrFainted)
			{
				base.GoapAgent.Abort();
				base.GoapAgent.ForceNextGoal("AutoEquipGoal");
			}
		}

		private void DoBanish()
		{
			if (IsDrafting)
			{
				ForceWorkHour(HourType.Working);
			}
			base.Humanoid.SetTarget(null);
			MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.Humanoid);
			if (!isBanished)
			{
				MonoSingleton<WorkerController>.Instance.BanishWorker(base.Humanoid);
			}
			isBanished = true;
			CombatAgent?.Disable();
			base.GoapAgent?.Abort();
		}

		private void UpdateJobSettings(JobType jobType)
		{
			if (!isBanished)
			{
				Job byJobType = Repository<JobRepository, Job>.Instance.GetByJobType(jobType);
				if (!activeJobCombination.HasFlag(jobType) && byJobType?.Goals?.Contains(base.GoapAgent?.CurrentGoalName) == true)
				{
					base.GoapAgent?.Abort();
				}
			}
		}

		public override void OnEquipmentDropped(EquipmentInstance instance)
		{
			base.OnEquipmentDropped(instance);
			if (instance.Blueprint.ItemType == ItemType.Weapon)
			{
				base.Humanoid.SetTarget(null);
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.Humanoid);
				CombatUtils.GetAttackType(base.Humanoid);
				MonoSingleton<GlobalWarningMessagesManager>.Instance.OnEquipmentChanged();
			}
		}

		public override void OnEquipmentEquipped(EquipmentInstance instance)
		{
			base.OnEquipmentEquipped(instance);
			if (!combatMode.IsDrafted())
			{
				base.Humanoid.SetWeaponVisibility(isVisible: false);
			}
			if (instance.Blueprint.ItemType == ItemType.Weapon)
			{
				base.Humanoid.SetTarget(null);
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.Humanoid);
				AttackType attackType = CombatUtils.GetAttackType(base.Humanoid);
				if (attackType == AttackType.RangeChargeBefore || attackType == AttackType.RangeChargeAfter)
				{
					MonoSingleton<GlobalWarningMessagesManager>.Instance.OnEquipmentChanged();
				}
			}
		}

		public void InitStorage(StorageBase storageBase)
		{
			base.Humanoid.InitStorage(storageBase);
		}

		public float GetBargainMultiplier()
		{
			return Stats.GetAttributeInstance(AttributeType.TradingBargain)?.Value ?? 0.05f;
		}

		public float GetSellMultiplier()
		{
			return Stats.GetAttributeInstance(AttributeType.TradingValue)?.Value ?? 0.6f;
		}

		public float GetBuyMultiplier()
		{
			AttributeInstance attributeInstance = Stats.GetAttributeInstance(AttributeType.TradingValue);
			if (attributeInstance != null)
			{
				return 1f / attributeInstance.Value;
			}
			return 1f;
		}

		public List<TradeResource> GetResources(ITrader otherTrader)
		{
			TraderBehaviour traderBehaviour = otherTrader as TraderBehaviour;
			List<TradeResource> allTradeResources = MonoSingleton<TradingManager>.Instance.GetAllTradeResources();
			WalkableModel walkableModel = base.Humanoid.WalkableModel;
			foreach (AnimalInstance item3 in MonoSingleton<AnimalManager>.Instance.Animals.Keys.Where((AnimalInstance animal) => animal.AnimalType == AnimalType.Domestic || animal.AnimalType == AnimalType.Pet))
			{
				TradeForbiddenReason forbidden = ((traderBehaviour != null && traderBehaviour.Humanoid != null && !PathfinderUtil.IsPathPossible(walkableModel, item3.GetNode(), traderBehaviour.Humanoid.GetNode())) ? TradeForbiddenReason.AnimalLocked : TradeForbiddenReason.None);
				TradeResource item = new TradeResource(item3, forbidden);
				allTradeResources.Add(item);
			}
			foreach (HumanoidInstance item4 in MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.IsCaptive() && npc.CaptiveNpcBehaviour.Owner == null))
			{
				TradeResource item2 = new TradeResource(item4, otherTrader.GetPrisonerTradeStatus(item4));
				allTradeResources.Add(item2);
			}
			return allTradeResources;
		}

		public string GetTraderName()
		{
			return base.Humanoid.GetFullName();
		}

		public string GetSettlementName()
		{
			return GlobalSaveController.CurrentVillageData.Name;
		}

		public Sprite GetHeraldryCrest()
		{
			return base.Humanoid.GetHeraldryCrest();
		}

		public Sprite GetHeraldryBackground()
		{
			return base.Humanoid.GetHeraldryBackground();
		}

		public void AddItemToStorage(TradeResource tradeResource, int count)
		{
			if (tradeResource.IsCreature)
			{
				if (tradeResource.Creature is AnimalInstance animalInstance)
				{
					animalInstance.AssignPetOwner(null);
					animalInstance.SetPredatorsCannotTargetForHours(3f);
					animalInstance.RopeTo(null);
					if (animalInstance.HasDisposed)
					{
						return;
					}
					animalInstance.SetAnimalType(AnimalType.Domestic);
					animalInstance.CancelLeaveMap();
					animalInstance.Stats.StartEffector("CaravanReturnedHomeAnimal");
				}
				if (tradeResource.IsCaptive() && tradeResource.Creature is HumanoidInstance humanoidInstance)
				{
					humanoidInstance.PrisonerBehaviour.Owner = null;
					humanoidInstance.RopeTo(null);
					Debug.Log($"{this} bought prisoner {humanoidInstance}");
				}
			}
			else
			{
				Vector3 position = base.Humanoid.GetPosition();
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(tradeResource.Resource, count), position);
			}
		}

		public void RemoveItemFromStorage(TradeResource tradeResource, int count)
		{
			MonoSingleton<TradingManager>.Instance.RemoveTradeResourceFromMap(tradeResource, count);
		}

		public float GetPerResourcePriceMultiplier(TradeResource resource)
		{
			return 1f;
		}

		public VillagePlace GetTraderVillagePlace()
		{
			return null;
		}

		public bool CanTradeResource(TradeResource resource)
		{
			return true;
		}

		public bool IsTraderFriendly()
		{
			return true;
		}

		public int GetStorageCapacity()
		{
			return -1;
		}

		public float GetMinimumNutrition()
		{
			return 0f;
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			return TradeForbiddenReason.None;
		}

		private void InitJobConfig()
		{
			foreach (Job workerJob in Repository<JobRepository, Job>.Instance.GetWorkerJobs())
			{
				UpdateJobSettings(workerJob.JobType);
			}
		}

		private void OnQuarterHourChange()
		{
			base.HumanoidRoleOwner.HandleQuarterHourChange();
			WorkerProximity.HandleQuarterHourChange();
		}

		private void OnHourChange()
		{
			base.HumanoidRoleOwner.HandleHourChange();
		}

		private void OnDateChange()
		{
			RebuildAllowedToConsume();
		}

		public override CombatAiAgent CreateNewCombatAiAgent(string id)
		{
			return new WorkerCombatAiAgent(base.Humanoid, id);
		}

		public override void OnFirstSpawn()
		{
			if (!(base.HumanType == null) && base.HumanType.SpawnEffectors != null && base.HumanType.SpawnEffectors.Length != 0)
			{
				string[] spawnEffectors = base.HumanType.SpawnEffectors;
				foreach (string effectorId in spawnEffectors)
				{
					Stats.StartEffector(effectorId);
				}
			}
		}

		public override void FaceObject(Vector3 objectPosition)
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.FaceObject(base.Humanoid, objectPosition);
			}
		}

		public override void HandleOnFaint()
		{
			MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("has_fainted", base.Humanoid) ?? "", base.Humanoid.GetPosition());
			if (base.Humanoid.HasFainted && IsDrafting)
			{
				MonoSingleton<DraftController>.Instance.OnEndDraft(base.Humanoid);
			}
		}

		public override bool CanConsume(DietModel dietModel, ResourcePileInstance resourcePile)
		{
			return AllowedToConsume?.Contains(resourcePile.BlueprintId) ?? true;
		}

		public override bool CanConsume(DietModel dietModel, ResourceInstance resourceInstance)
		{
			return AllowedToConsume?.Contains(resourceInstance.BlueprintId) ?? true;
		}

		public override void OnHealthDepleted(bool wasNaturalDeath = false)
		{
			DebugEventLog.Write(new CreatureDied(base.Humanoid, wasNaturalDeath));
			base.OnHealthDepleted(wasNaturalDeath);
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				List<LifeEventLogStruct> recentLifeEventLogs = GetRecentLifeEventLogs(5);
				LifeEventLogStruct lastWordsEventLog = LifeEventUtils.GetLastWordsEventLog(base.Humanoid);
				base.Humanoid.LogLifeEvent(lastWordsEventLog);
				PublishNewsOnDeath(recentLifeEventLogs, lastWordsEventLog, wasNaturalDeath);
				if (MonoSingleton<MiscLogManager>.IsInstantiated())
				{
					MonoSingleton<MiscLogManager>.Instance.LogDied(base.Humanoid);
				}
			}
		}

		private void PublishNewsOnDeath(List<LifeEventLogStruct> lastMoments, LifeEventLogStruct lastWords, bool wasNatural)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(wasNatural ? "news_death_natural_death".ToLocalized() : "news_death_unnatural_death".ToLocalized());
			stringBuilder.Append("\n");
			stringBuilder.Append(lastWords.GetLocalizedLogWithoutSprites());
			stringBuilder.Append("\n\n");
			stringBuilder.Append("news_death_last_moments".ToLocalized());
			stringBuilder.Append("\n");
			foreach (LifeEventLogStruct lastMoment in lastMoments)
			{
				stringBuilder.Append(lastMoment.GetLocalizedLogWithoutSprites());
				stringBuilder.Append("\n");
			}
			DialogContent dialogContent = new DialogContent
			{
				WindowTitle = "news_death_title",
				ContentTitle = "news_death_title",
				ShowCloseButton = true,
				ContentBodyImagePath = (wasNatural ? "event_death_natural" : "event_death_violent"),
				ContentBodyText = stringBuilder.ToString(),
				Options = new List<DialogOption>
				{
					new DialogOption
					{
						Text = "general_ok"
					},
					new DialogOption
					{
						Text = "general_jump_to_location"
					}
				}
			};
			NewsData newsData = new NewsData("news_death_title", "NewsRed", "", dialogContent, base.Humanoid.GetPosition(), 1);
			newsData.Localize();
			newsData.Format((string text) => TextFormatting.FormatText(text, base.Humanoid));
			MonoSingleton<NewsManager>.Instance.Publish(newsData);
		}

		private List<LifeEventLogStruct> GetRecentLifeEventLogs(int desiredCount)
		{
			List<LifeEventLogStruct> list = new List<LifeEventLogStruct>();
			LinkedListNode<LifeEventLogStruct> linkedListNode = base.Humanoid.LifeEventLogs.First;
			while (linkedListNode != null && list.Count < desiredCount)
			{
				list.Add(linkedListNode.Value);
				linkedListNode = linkedListNode.Next;
			}
			return list;
		}

		protected override void InvokeOnDeathEvents()
		{
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.RemoveWorker(base.Humanoid);
			}
		}

		public override void OnTendWounds()
		{
			base.OnTendWounds();
			if (!base.Humanoid.HasUntendendWounds() && !string.IsNullOrEmpty(base.HumanType.WhileUntendedEffector))
			{
				Stats?.EndEffector(base.HumanType?.WhileUntendedEffector);
			}
		}

		private void AttachToStorageEvents()
		{
			if (!isAttachedToStorageEvents)
			{
				isAttachedToStorageEvents = true;
				WorkerView workerView = (view = base.Humanoid.GetAgentView<WorkerView>());
				Storage.ResourceAddedEvent += workerView.OnStorageChange;
				Storage.ResourceTakenEvent += workerView.OnStorageChange;
				Storage.ResourceDeletedEvent += workerView.OnStorageChange;
				FoodStorage.ResourceAddedEvent += OnFoodStorageChanged;
				FoodStorage.ResourceTakenEvent += OnFoodStorageChanged;
				FoodStorage.ResourceDeletedEvent += OnFoodStorageChanged;
				MedicineStorage.ResourceAddedEvent += OnMedicineStorageChanged;
				MedicineStorage.ResourceTakenEvent += OnMedicineStorageChanged;
				MedicineStorage.ResourceDeletedEvent += OnMedicineStorageChanged;
			}
		}

		private void DetachFromStorageEvents()
		{
			if (isAttachedToStorageEvents)
			{
				isAttachedToStorageEvents = false;
				Storage.ResourceAddedEvent -= view.OnStorageChange;
				Storage.ResourceTakenEvent -= view.OnStorageChange;
				Storage.ResourceDeletedEvent -= view.OnStorageChange;
				FoodStorage.ResourceAddedEvent -= OnFoodStorageChanged;
				FoodStorage.ResourceTakenEvent -= OnFoodStorageChanged;
				FoodStorage.ResourceDeletedEvent -= OnFoodStorageChanged;
				MedicineStorage.ResourceAddedEvent -= OnMedicineStorageChanged;
				MedicineStorage.ResourceTakenEvent -= OnMedicineStorageChanged;
				MedicineStorage.ResourceDeletedEvent -= OnMedicineStorageChanged;
			}
		}

		public override string GetMultiselectName()
		{
			return "worker";
		}

		public override string GetGoapAgentId()
		{
			return "worker";
		}

		public void OnBeforeSerialize()
		{
			if (base.GoapAgent != null)
			{
				scheduleHours = ScheduleHours;
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			base.Serialize(serializer);
			serializer.WriteEnum("activeJobCombination", activeJobCombination);
			serializer.WriteEnum("combatMode", combatMode);
			serializer.WriteEnum("combatModeBeforeDraft", combatModeUndraftedSaved);
			serializer.WriteEnum("combatModeDraftedSaved", combatModeDraftedSaved);
			serializer.Write("selectedManagePresets", selectedManagePresets);
			serializer.Write("isBanished", isBanished);
			serializer.Write("isAllowedSelfTending", isAllowedSelfTending);
			serializer.Write("jobPriorities", jobPriorities);
			serializer.WriteEnum("scheduleHours", scheduleHours);
			serializer.Write("affectionEffectorsLog", WorkerSocial.AffectionEffectorsLog);
			serializer.Write("useRallyPoints", UseRallyPoints);
		}

		public WorkerBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			activeJobCombination = deserializer.ReadEnum("activeJobCombination", JobType.None);
			combatMode = deserializer.ReadEnum("combatMode", UnitCombatModeType.None);
			combatModeUndraftedSaved = deserializer.ReadEnum("combatModeBeforeDraft", UnitCombatModeType.None);
			if (combatModeUndraftedSaved == UnitCombatModeType.None)
			{
				combatModeUndraftedSaved = UnitCombatModeType.Flee;
			}
			combatModeDraftedSaved = deserializer.ReadEnum("combatModeDraftedSaved", UnitCombatModeType.None);
			if (combatModeDraftedSaved == UnitCombatModeType.None)
			{
				combatModeDraftedSaved = UnitCombatModeType.DraftedDefault;
			}
			selectedManagePresets = deserializer.ReadObject<StringStringDictionary>("selectedManagePresets");
			if (selectedManagePresets != null)
			{
				using PooledList<string> pooledList = ListPool<string>.GetJanitor();
				foreach (string key in selectedManagePresets.Dictionary.Keys)
				{
					if (Repository<ManageGroupRepository, ManageGroup>.Instance.GetByID(key) == null)
					{
						pooledList.Add(key);
					}
				}
				foreach (string item2 in pooledList)
				{
					selectedManagePresets.Dictionary.Remove(item2);
				}
				pooledList.Clear();
				foreach (KeyValuePair<string, string> item3 in selectedManagePresets.Dictionary)
				{
					var (item, presetId) = (KeyValuePair<string, string>)(ref item3);
					if (Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets.FirstOrDefault((ManageGroupPreset preset) => preset.GetID() == presetId) == null)
					{
						pooledList.Add(item);
					}
				}
				foreach (string groupId in pooledList)
				{
					selectedManagePresets.Dictionary[groupId] = Repository<ManageGroupPresetRepository, ManageGroupPreset>.Instance.UserPresets.First((ManageGroupPreset preset) => preset.GroupId == groupId).GetID();
				}
			}
			isBanished = deserializer.ReadBool("isBanished");
			isAllowedSelfTending = deserializer.ReadBool("isAllowedSelfTending");
			jobPriorities = deserializer.ReadObject<JobTypeIntDictionary>("jobPriorities");
			scheduleHours = deserializer.ReadEnumArray<HourType>("scheduleHours");
			WorkerSocial.AffectionEffectorsLog = deserializer.ReadObjectLinkedList<EffectorLogStruct>("affectionEffectorsLog");
			UseRallyPoints = deserializer.ReadBool("useRallyPoints", defaultValue: true);
		}

		public override void OnLoaded(HumanoidInstance ownerHumanoid)
		{
			base.OnLoaded(ownerHumanoid);
			WorkerProximity.SetHumanoidInstance(base.Humanoid);
			WorkerSocial.SetHumanOwner(base.Humanoid);
			WorkerInteraction.SetHumanOwner(base.Humanoid);
		}
	}
}
