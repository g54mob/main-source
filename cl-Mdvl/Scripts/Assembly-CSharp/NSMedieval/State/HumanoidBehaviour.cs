using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.Tools.Math;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.State
{
	[FVSerializableKey("HumanoidBehaviour", "HumanoidBehavior, BaseNPCBehavior")]
	public abstract class HumanoidBehaviour : IFVSerializable
	{
		[NonSerialized]
		private HumanoidBlueprint blueprint;

		[NonSerialized]
		private HumanType humanType;

		[NonSerialized]
		private Agent goapAgent;

		[NonSerialized]
		private StatEffector lastStartedEffector;

		private HumanoidRoleOwner humanoidRoleOwner;

		private ProximityBehaviour proximityBehaviour;

		private bool isActivated;

		private bool isFirstActivate = true;

		public virtual BehaviourType BehaviourType => BehaviourType.None;

		public virtual DamageTakingAgentType DamageAgentType => DamageTakingAgentType.NPC;

		public virtual DamageTakingAgentType CanAttackTypes => DamageTakingAgentType.Animal | DamageTakingAgentType.Worker | DamageTakingAgentType.Building;

		public Agent GoapAgent
		{
			get
			{
				if (this == Humanoid.ActiveBehaviour)
				{
					return GoapAgentUnchecked;
				}
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(137, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\HumanoidBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to access GOAP agent of behaviour '");
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral("', but it is not currently active. ");
					messageBuilder.AppendLiteral("Returning GOAP agent of currently active behaviour '");
					messageBuilder.AppendFormatted(Humanoid.ActiveBehaviour?.GetType().Name);
					messageBuilder.AppendLiteral("' instead");
				}
				Log.Warning(messageBuilder);
				return Humanoid.GetGoapAgent();
			}
		}

		public Agent GoapAgentUnchecked
		{
			get
			{
				if (!MonoSingleton<GoapController>.IsInstantiated())
				{
					return null;
				}
				return goapAgent ?? (goapAgent = CreateGoapAgent());
			}
		}

		public HumanoidInstance Humanoid { get; private set; }

		public NPC NpcBlueprint => Blueprint as NPC;

		protected InventoryInstance Inventory => Humanoid.Inventory;

		protected static WorldDate DateTime
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return null;
				}
				return GlobalSaveController.CurrentVillageData.DateAndTime;
			}
		}

		public HumanoidBlueprint Blueprint
		{
			get
			{
				if (blueprint != null)
				{
					return blueprint;
				}
				if (this is WorkerBehaviour)
				{
					blueprint = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker;
				}
				else
				{
					blueprint = Repository<NPCRepository, NPC>.Instance.GetByID(Humanoid.Id);
					if (blueprint == null)
					{
						blueprint = Repository<NPCRepository, NPC>.Instance.GetFirst();
					}
				}
				return blueprint;
			}
		}

		public HumanType HumanType
		{
			get
			{
				if (humanType == null)
				{
					humanType = Repository<HumanTypeRepository, HumanType>.Instance.GetByID(HumanTypeId);
					if (humanType == null)
					{
						throw new Exception("HumanType with id '" + HumanTypeId + "' not found");
					}
				}
				return humanType;
			}
		}

		public ProximityBehaviour ProximityBehaviour => proximityBehaviour ?? (proximityBehaviour = GetProximityBehaviour());

		public HumanoidRoleOwner HumanoidRoleOwner => humanoidRoleOwner ?? (humanoidRoleOwner = new HumanoidRoleOwner(Humanoid));

		public virtual bool ProximityDetection => false;

		protected abstract string HumanTypeId { get; }

		public virtual float RopedFollowRange => 1f;

		public virtual bool RopedAllowedToIdle => false;

		public virtual bool RopedShouldAlwaysWalk => false;

		public virtual string IndicatorPrefabName => null;

		public virtual string OverheadBillboardPrefabName => null;

		public string IdleAnimationTrigger { get; set; }

		public bool StandInPlace { get; set; }

		protected HumanoidBehaviour()
		{
		}

		public abstract string GetGoapAgentId();

		protected abstract Agent CreateGoapAgent();

		public abstract string GetMultiselectName();

		public virtual string GetSingleSelectName()
		{
			if (!string.IsNullOrEmpty(Blueprint.SelectionName))
			{
				return MonoSingleton<LocalizationController>.Instance.GetText(Blueprint.SelectionName, Humanoid.Info.BodyType);
			}
			return MonoSingleton<LocalizationController>.Instance.GetText("general_" + GetMultiselectName(), Humanoid.Info.BodyType);
		}

		public void Initialize(HumanoidInstance ownerHumanoid)
		{
			Humanoid = ownerHumanoid;
			isFirstActivate = true;
		}

		public void Activate()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (isActivated)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(102, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\HumanoidBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to activate behaviour '");
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral("' again. Not necessarily an issue, but might be a sign of something fishy");
				}
				Log.Info(messageBuilder);
				return;
			}
			isActivated = true;
			messageBuilder = new FVLogInfoInterpolationHandler(56, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\HumanoidBehaviour.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Activating humanoid behaviour '");
				messageBuilder.AppendFormatted(GetType().Name);
				messageBuilder.AppendLiteral("' for '");
				messageBuilder.AppendFormatted(Humanoid);
				messageBuilder.AppendLiteral("' (firstTime = '");
				messageBuilder.AppendFormatted(isFirstActivate);
				messageBuilder.AppendLiteral("')");
			}
			Log.Info(messageBuilder);
			if (MonoSingleton<CombatTargetManager>.IsInstantiated())
			{
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(Humanoid);
			}
			if (isFirstActivate)
			{
				isFirstActivate = false;
				OnBeforeFirstActivate();
			}
			AttachToStatsEvents();
			GoapAgent.StartTicker();
			OnActivate();
			InvokeOnActivateEvents();
		}

		public void Deactivate()
		{
			if (!isActivated)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(104, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\HumanoidBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to deactivate behaviour '");
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral("' again. Not necessarily an issue, but might be a sign of something fishy");
				}
				Log.Info(messageBuilder);
			}
			else
			{
				isActivated = false;
				DetachFromStatsEvents();
				GoapAgent.StopTicker();
				OnDeactivate();
				InvokeOnDeactivateEvents();
			}
		}

		protected virtual void OnBeforeFirstActivate()
		{
		}

		public void InitIncognitoAfterLoad()
		{
			OnBeforeFirstActivate();
		}

		public virtual void OnTrapTriggered(TrapComponentInstance trap)
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual void OnTendWounds()
		{
		}

		public virtual void OnGoapAttendPlayerTriggeredEvent(string goalId)
		{
		}

		public virtual void OnGoapLeavePlayerTriggeredEvent(string goalId)
		{
		}

		public virtual void OnFirstSpawn()
		{
		}

		public virtual void OnSpawn()
		{
		}

		public virtual void OnAfterSpawn()
		{
		}

		public virtual void OnLoaded(HumanoidInstance ownerHumanoid)
		{
			Humanoid = ownerHumanoid;
			Humanoid.HumanoidBelief.SetHumanOwner(Humanoid);
			HumanoidRoleOwner.SetHumanOwner(Humanoid);
		}

		public StatsModel GetStatsModel()
		{
			return HumanType.StatsModel;
		}

		public DietModel GetDietModel()
		{
			return HumanType.DietModel;
		}

		public DietModel GetDrinkDietModel()
		{
			return HumanType.DrinkDietModel;
		}

		public virtual void HandleOnFaint()
		{
		}

		public virtual void AttendPlayerTriggeredEvent(string goalId)
		{
			GoapAgent.GoalScheduler.EnableGoal(goalId);
		}

		public virtual void LeavePlayerTriggeredEvent(string goalId)
		{
			GoapAgent.GoalScheduler.DisableGoal(goalId);
		}

		public virtual void HandleOnEquipmentDestroyed(EquipmentInstance item)
		{
			Humanoid.GetAgentView<HumanoidView>()?.DropItem(item);
			item.EndEquipEffects(Humanoid.Stats);
		}

		public virtual void OnEquipmentDropped(EquipmentInstance instance)
		{
			instance.EndEquipEffects(Humanoid.Stats);
		}

		public virtual void OnEquipmentEquipped(EquipmentInstance instance)
		{
			instance.StartEquipEffects(Humanoid.Stats);
		}

		public virtual void OnRoomChanged(Room oldRoom, Room newRoom)
		{
		}

		public virtual void UpdatePosition(MapNode oldNode, MapNode currentNode)
		{
			if (currentNode != oldNode)
			{
				Humanoid.SetBeautyTarget();
			}
		}

		public virtual void FaceObject(Vector3 objectPosition)
		{
			if (!Humanoid.HasDisposed && !Humanoid.HasDied && !Humanoid.PathDriver.IsClimbing)
			{
				NPCView agentView = Humanoid.GetAgentView<NPCView>();
				if (agentView != null)
				{
					agentView.FaceObject(objectPosition);
				}
			}
		}

		public virtual void FaceAway(Vector3 objectPosition)
		{
			if (!Humanoid.HasDisposed && !Humanoid.HasDied)
			{
				NPCView agentView = Humanoid.GetAgentView<NPCView>();
				if (agentView != null)
				{
					agentView.FaceAway(objectPosition);
				}
			}
		}

		public virtual bool CanConsume(DietModel dietModel, ResourcePileInstance resourcePile)
		{
			return true;
		}

		public virtual bool CanConsume(DietModel dietModel, ResourceInstance resourceInstance)
		{
			return true;
		}

		public virtual void OnHealthDepleted(bool wasNaturalDeath = false)
		{
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<CombatAttackTracker>.Instance.AttackPathFailed(Humanoid);
				Humanoid.LogLifeEvent(LifeEventUtils.GetHealthDeathEventLog(Humanoid));
				InvokeOnDeathEvents();
				if (!Humanoid.DontSpawnCarcassOnDispose && MonoSingleton<ResourcePileManager>.IsInstantiated())
				{
					MonoSingleton<ResourcePileManager>.Instance.SpawnPile(Humanoid);
				}
			}
		}

		protected virtual void InvokeOnDeathEvents()
		{
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.RemoveNPC(Humanoid);
				MonoSingleton<NPCController>.Instance.OnNPCDied(Humanoid);
			}
		}

		protected virtual void OnActivate()
		{
		}

		protected virtual void OnDeactivate()
		{
		}

		private void InvokeOnActivateEvents()
		{
			if (MonoSingleton<HumanoidController>.IsInstantiated())
			{
				MonoSingleton<HumanoidController>.Instance.OnActivateBehaviour(this);
			}
			if (!(this is WorkerBehaviour))
			{
				Humanoid.GetAgentView<NPCView>()?.OnNPCBehaviourChanged();
			}
			HumanoidRoleOwner.OnSetupRole();
		}

		private void InvokeOnDeactivateEvents()
		{
			if (MonoSingleton<HumanoidController>.IsInstantiated())
			{
				MonoSingleton<HumanoidController>.Instance.OnDeactivateBehaviour(this);
			}
		}

		public virtual void OnKilled(IDamageDealAgent killer)
		{
			if (Humanoid.Faction != null && !Humanoid.Faction.IsHostile())
			{
				Humanoid.Faction.HitFromFriendly(-150f);
			}
		}

		public virtual CombatAiAgent CreateNewCombatAiAgent(string id)
		{
			return new NPCCombatAiAgent(Humanoid, id);
		}

		protected virtual ProximityBehaviour GetProximityBehaviour()
		{
			return null;
		}

		public void AttachToStatsEvents()
		{
			Humanoid.Stats.OnInstantEffectorStartEvent += OnEffectorStarted;
			Humanoid.Stats.OnEffectorStartEvent += OnEffectorStarted;
			Humanoid.Stats.OnEffectorStartEvent += MoodEffectorStartCheck;
			Humanoid.Stats.OnEffectorStackEvent += MoodEffectorStartCheck;
		}

		public void DetachFromStatsEvents()
		{
			Humanoid.Stats.OnInstantEffectorStartEvent -= OnEffectorStarted;
			Humanoid.Stats.OnEffectorStartEvent -= OnEffectorStarted;
			Humanoid.Stats.OnEffectorStartEvent -= MoodEffectorStartCheck;
			Humanoid.Stats.OnEffectorStackEvent -= MoodEffectorStartCheck;
		}

		private void OnEffectorStarted(StatEffector effector)
		{
			if (effector.UIGroup.HasFlag(EffectorUiGroup.MiscLog))
			{
				string message = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(effector.LocKeys)) + " (" + UiUtils.GetWorkerLink(Humanoid) + ") ";
				Humanoid.LogLifeEvent(LifeEventUtils.GetMiscLog(message));
			}
			if (string.IsNullOrEmpty(effector.BubbleIcon))
			{
				return;
			}
			lastStartedEffector = effector;
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "effectorBubble", delegate
			{
				if (!Humanoid.HasDisposed && MonoSingleton<FloatingOverlayManager>.IsInstantiated())
				{
					if (lastStartedEffector == null || string.IsNullOrEmpty(lastStartedEffector.BubbleIcon))
					{
						lastStartedEffector = null;
					}
					else
					{
						float num = (Humanoid.Stats.GetModifierInstanceStack(ModifierType.MoodBasic)?.Instances?.FirstOrDefault((ModifierInstance item) => item.Tag.Equals(lastStartedEffector.GetID())) as MoodBasicModifierInstance)?.CalculateValue() ?? 0f;
						string icon = string.Empty;
						if (Math.Abs(num) > 1E-05f)
						{
							icon = ((num < 0f) ? "mood_low" : ((num > 0f) ? "mood_high" : string.Empty));
						}
						if (!(Humanoid.GetAgentView<AnimatedAgentView>() == null))
						{
							FloatingElementFactory.ProduceThoughtBubbleElement(Humanoid.GetAgentView<AnimatedAgentView>().GetGuiOverlayHookTransform(), lastStartedEffector.BubbleIcon, icon);
							lastStartedEffector = null;
						}
					}
				}
			});
		}

		private void MoodEffectorStartCheck(StatEffector effector)
		{
			if (effector.Effects == null || effector.Effects.Length == 0)
			{
				return;
			}
			EffectDetailsHolder effectDetailsHolder = effector.Effects.FirstOrDefault((EffectDetailsHolder effect) => effect.Type == EffectorType.MoodModify);
			if (effectDetailsHolder == null)
			{
				return;
			}
			List<ActiveEffectorInfo> activeEffectors = Humanoid.Stats.GetActiveEffectors();
			StatEffector statEffector = null;
			StatEffector statEffector2 = null;
			if (HumanType.InspiredEffectors != null && HumanType.InspiredEffectors.Count > 0)
			{
				statEffector = Repository<EffectorRepository, StatEffector>.Instance.GetByLongestDuration(HumanType.InspiredEffectors);
			}
			if (HumanType.BreakdownEffectors != null && HumanType.BreakdownEffectors.Count > 0)
			{
				statEffector2 = Repository<EffectorRepository, StatEffector>.Instance.GetByLongestDuration(HumanType?.BreakdownEffectors);
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (ActiveEffectorInfo item in activeEffectors)
			{
				if (item.Name == "AgentInspiredPossible")
				{
					flag = true;
				}
				if (statEffector != null && item.Name != statEffector.GetID())
				{
					flag2 = true;
				}
				if (item.Name == "AgentBreakdownPossible")
				{
					flag3 = true;
				}
				if (statEffector2 != null && item.Name != statEffector2.GetID())
				{
					flag4 = true;
				}
			}
			bool flag5 = flag && flag2;
			bool flag6 = flag3 && flag4;
			if ((flag5 || flag6) && int.TryParse(effectDetailsHolder.Parameters.FirstOrDefault((KeyValuePair<string, string> param) => param.Key.Equals("BaseValue")).Value, out var result) && result != 0)
			{
				float num = NSMedieval.Tools.Math.Random.Value();
				if (flag6 && result < 0 && num < HumanType.BreakdownChance)
				{
					Humanoid.Stats.StartEffectors(HumanType.BreakdownEffectors);
					string text = MonoSingleton<LocalizationController>.Instance.GetText("worker_low_mood_message", Humanoid);
					text = LifeEventUtils.AppendEffectorReason(text, effector.GetID(), Humanoid.Info.BodyType);
					AnimatedAgentView agentView = Humanoid.GetAgentView<AnimatedAgentView>();
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(text, agentView, follow: true);
				}
				else if (flag5 && result > 0 && num < HumanType.InspiredChance)
				{
					Humanoid.Stats.StartEffectors(HumanType.InspiredEffectors);
				}
			}
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			SerializeRoleInstanceDict("roleInstanceDictionary", HumanoidRoleOwner.RoleInstanceDictionary, serializer);
			serializer.Write("roleInstance", HumanoidRoleOwner.RoleInstance);
			serializer.Write("IdleAnimationTrigger", IdleAnimationTrigger);
			serializer.Write("StandInPlace", StandInPlace);
		}

		protected static void SerializeRoleInstanceDict(string key, Dictionary<Role, RoleInstance> dictionary, FVSerializer serializer)
		{
			List<string> value = null;
			List<RoleInstance> value2 = null;
			if (dictionary != null)
			{
				List<KeyValuePair<Role, RoleInstance>> source = dictionary.ToList();
				value = source.Select((KeyValuePair<Role, RoleInstance> pair) => pair.Key.GetID()).ToList();
				value2 = source.Select((KeyValuePair<Role, RoleInstance> pair) => pair.Value).ToList();
			}
			serializer.Write(key + "_keys", value);
			serializer.Write(key + "_values", value2);
		}

		public HumanoidBehaviour(FVDeserializer deserializer)
		{
			HumanoidRoleOwner.RoleInstanceDictionary = DeserializeRoleInstanceDict("roleInstanceDictionary", deserializer);
			HumanoidRoleOwner.RoleInstance = deserializer.ReadObject<RoleInstance>("roleInstance");
			IdleAnimationTrigger = deserializer.ReadString("IdleAnimationTrigger");
			StandInPlace = deserializer.ReadBool("StandInPlace");
		}

		protected static Dictionary<Role, RoleInstance> DeserializeRoleInstanceDict(string key, FVDeserializer deserializer)
		{
			List<string> list = deserializer.ReadStringList(key + "_keys", new List<string>());
			if (list == null)
			{
				return null;
			}
			List<RoleInstance> list2 = deserializer.ReadObjectList(key + "_values", new List<RoleInstance>());
			if (list.Count != list2.Count)
			{
				throw new Exception($"Corrupted save data, keys and values must be of same length (keys is {list.Count}, values is {list2.Count})");
			}
			Dictionary<Role, RoleInstance> dictionary = new Dictionary<Role, RoleInstance>();
			for (int i = 0; i < list.Count; i++)
			{
				Role byID = Repository<RoleRepository, Role>.Instance.GetByID(list[i]);
				RoleInstance value = list2[i];
				dictionary[byID] = value;
			}
			return dictionary;
		}
	}
}
