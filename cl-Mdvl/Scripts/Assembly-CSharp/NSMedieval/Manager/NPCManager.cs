using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using JetBrains.Annotations;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.DebugEvents;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.View;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class NPCManager : MonoSingleton<NPCManager>, IObserver
	{
		private Cooldown debugEventCooldown;

		private readonly ConcurrentDictionary<HumanoidInstance, NPCView> npcViews = new ConcurrentDictionary<HumanoidInstance, NPCView>();

		public HumanoidInstance SpawnEnemy(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, FactionInstance factionInstance, int raidId = 0, int? randomSeed = null, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(109, 7, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning enemy with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("', faction: ");
				messageBuilder.AppendFormatted(factionInstance?.BlueprintId);
				messageBuilder.AppendLiteral(", raidId: ");
				messageBuilder.AppendFormatted(raidId);
				messageBuilder.AppendLiteral(", randomSeed: ");
				messageBuilder.AppendFormatted(randomSeed);
			}
			Log.Info(messageBuilder);
			HumanoidInstance humanoidInstance = SpawnNPC<EnemyBehaviour>(blueprintId, bodyType, position, originVillage, factionInstance, null, "", randomSeed, fromEvent);
			humanoidInstance.EnemyBehaviour.RaidId = raidId;
			return humanoidInstance;
		}

		public HumanoidInstance SpawnTrader(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, FactionInstance factionInstance, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(75, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning trader with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			return SpawnNPC<TraderBehaviour>(blueprintId, bodyType, position, originVillage, factionInstance, null, "", null, fromEvent);
		}

		public HumanoidInstance SpawnTraderBodyguard(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, FactionInstance factionInstance, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(84, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning traderBodyguard with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			return SpawnNPC<TraderBodyguardBehaviour>(blueprintId, bodyType, position, originVillage, factionInstance, null, "", null, fromEvent);
		}

		public HumanoidInstance SpawnVisitorPriest(string blueprintId, BodyType bodyType, Vector3 position, string roleId, VillagePlace originVillage, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(102, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning priest visitor priest with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", roleId: '");
				messageBuilder.AppendFormatted(roleId);
				messageBuilder.AppendLiteral("', originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			HumanoidInstance humanoidInstance = SpawnNPC<PriestVisitorBehaviour>(blueprintId, bodyType, position, originVillage, originVillage.FactionInstance, null, roleId, null, fromEvent);
			float num = UnityEngine.Random.Range(91f, 100f);
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(68, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("[ReligiousAlignment] SpawnVisitorPriest '");
				messageBuilder2.AppendFormatted(humanoidInstance.Info?.GetFullName());
				messageBuilder2.AppendLiteral("': overriding alignment to ");
				messageBuilder2.AppendFormatted(num, "F2");
			}
			Log.Trace(messageBuilder2);
			SetReligiousAlignmentBypassingRoleLock(humanoidInstance, num);
			return humanoidInstance;
		}

		public HumanoidInstance SpawnShamanVisitor(string blueprintId, BodyType bodyType, Vector3 position, string roleId, VillagePlace originVillage, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(102, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning shaman visitor shaman with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", roleId: '");
				messageBuilder.AppendFormatted(roleId);
				messageBuilder.AppendLiteral("', originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			HumanoidInstance humanoidInstance = SpawnNPC<ShamanVisitorBehaviour>(blueprintId, bodyType, position, originVillage, originVillage.FactionInstance, null, roleId, null, fromEvent);
			float num = UnityEngine.Random.Range(0f, 10f);
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(68, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("[ReligiousAlignment] SpawnShamanVisitor '");
				messageBuilder2.AppendFormatted(humanoidInstance.Info?.GetFullName());
				messageBuilder2.AppendLiteral("': overriding alignment to ");
				messageBuilder2.AppendFormatted(num, "F2");
			}
			Log.Trace(messageBuilder2);
			SetReligiousAlignmentBypassingRoleLock(humanoidInstance, num);
			return humanoidInstance;
		}

		private void SetReligiousAlignmentBypassingRoleLock(HumanoidInstance npc, float alignment)
		{
			RoleInstance roleInstance = npc.ActiveBehaviour?.HumanoidRoleOwner?.RoleInstance;
			if (roleInstance == null)
			{
				npc.SetReligiousAlignment(alignment);
				return;
			}
			RoleLevel[] roleLevels = roleInstance.Blueprint.RoleLevels;
			string[] onAssignEffectorIds;
			for (int i = 0; i < roleLevels.Length; i++)
			{
				onAssignEffectorIds = roleLevels[i].OnAssignEffectorIds;
				foreach (string text in onAssignEffectorIds)
				{
					npc.Stats.EndEffector(text);
				}
			}
			npc.SetReligiousAlignment(alignment);
			onAssignEffectorIds = roleInstance.GetOnAssignEffectorIds();
			foreach (string effectorId in onAssignEffectorIds)
			{
				npc.Stats.StartEffector(effectorId);
			}
		}

		public HumanoidInstance SpawnBardVisitor(string blueprintId, BodyType bodyType, Vector3 position, string roleId, VillagePlace originVillage, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(98, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning bard visitor bard with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", roleId: '");
				messageBuilder.AppendFormatted(roleId);
				messageBuilder.AppendLiteral("', originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			return SpawnNPC<BardVisitorBehaviour>(blueprintId, bodyType, position, originVillage, originVillage.FactionInstance, null, roleId, null, fromEvent);
		}

		public HumanoidInstance SpawnBlank(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, FactionInstance factionInstance, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(78, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning blank NPC with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			return SpawnNPC<BlankBehaviour>(blueprintId, bodyType, position, originVillage, factionInstance, null, "", null, fromEvent);
		}

		public HumanoidInstance SpawnNegotiator(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, int? randomSeed = null, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(93, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning negotiator with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("', randomSeed: ");
				messageBuilder.AppendFormatted(randomSeed);
			}
			Log.Info(messageBuilder);
			return SpawnNPC<NegotiatorBehaviour>(blueprintId, bodyType, position, originVillage, originVillage.FactionInstance, null, "", randomSeed, fromEvent);
		}

		public HumanoidInstance SpawnBeggar(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, FactionInstance factionInstance, int? randomSeed = null, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(89, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning beggar with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("', randomSeed: ");
				messageBuilder.AppendFormatted(randomSeed);
			}
			Log.Info(messageBuilder);
			return SpawnNPC<BeggarBehaviour>(blueprintId, bodyType, position, originVillage, factionInstance, null, "", randomSeed, fromEvent);
		}

		public HumanoidInstance SpawnPilgrimVisitor(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, FactionInstance factionInstance, int? randomSeed = null, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(98, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning pilgrim visitor with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("', randomSeed: ");
				messageBuilder.AppendFormatted(randomSeed);
			}
			Log.Info(messageBuilder);
			return SpawnNPC<PilgrimVisitorBehaviour>(blueprintId, bodyType, position, originVillage, factionInstance, null, "", randomSeed, fromEvent);
		}

		public HumanoidInstance SpawnPrisoner(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, HumanoidInstance owner, int? randomSeed = null, GameEventInstance fromEvent = null)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(91, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning prisoner with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("', randomSeed: ");
				messageBuilder.AppendFormatted(randomSeed);
			}
			Log.Info(messageBuilder);
			HumanoidInstance humanoidInstance = SpawnNPC<PrisonerBehaviour>(blueprintId, bodyType, position, originVillage, originVillage.FactionInstance, null, "", randomSeed, fromEvent);
			((PrisonerBehaviour)humanoidInstance.ActiveBehaviour).Owner = owner;
			humanoidInstance.RopeTo(owner);
			return humanoidInstance;
		}

		public void SpawnTestNPC(Type humanoidBehaviour, string blueprintId, BodyType bodyType, Vector3 position, VillagePlace originVillage, FactionInstance factionInstance, int? randomSeed = null, string roleId = "")
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(97, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning npc of type '");
				messageBuilder.AppendFormatted(humanoidBehaviour.Name);
				messageBuilder.AppendLiteral("' with blueprint '");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral("', body type ");
				messageBuilder.AppendFormatted(bodyType);
				messageBuilder.AppendLiteral(", position ");
				messageBuilder.AppendFormatted(position);
				messageBuilder.AppendLiteral(", originVillage: '");
				messageBuilder.AppendFormatted(originVillage?.Name);
				messageBuilder.AppendLiteral("', randomSeed: ");
				messageBuilder.AppendFormatted(randomSeed);
			}
			Log.Info(messageBuilder);
			GetType().GetMethod("SpawnNPC", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(humanoidBehaviour).Invoke(this, new object[9] { blueprintId, bodyType, position, originVillage, factionInstance, null, roleId, randomSeed, null });
		}

		public static void ApplyEquipmentForWorker(HumanoidInstance humanoid, HumanPreset humanPreset)
		{
			if (humanPreset == null)
			{
				return;
			}
			foreach (EquipmentInstance item in GenerateEquipment(humanPreset, null))
			{
				item.SetIsManuallyEquipped(value: true);
				humanoid.Inventory.Equip(item);
			}
		}

		public HumanoidInstance GetByCreationID(int id)
		{
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (key.UniqueId.Equals(id))
				{
					return key;
				}
			}
			return null;
		}

		public IEnumerable<HumanoidInstance> IterateNPCs(Predicate<HumanoidInstance> filter = null)
		{
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (filter == null || filter(key))
				{
					yield return key;
				}
			}
		}

		public IEnumerable<T> IterateNPCs<T>(Predicate<T> filter = null) where T : HumanoidBehaviour
		{
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (key.ActiveBehaviour is T val && (filter == null || filter(val)))
				{
					yield return val;
				}
			}
		}

		[MustDisposeResource]
		public PooledList<HumanoidInstance> GetNPCsPooled(Predicate<HumanoidInstance> filter = null)
		{
			return ListPool<HumanoidInstance>.GetJanitor(IterateNPCs(filter));
		}

		[MustDisposeResource]
		public PooledList<T> GetNPCsPooled<T>(Predicate<T> filter = null) where T : HumanoidBehaviour
		{
			return ListPool<T>.GetJanitor(IterateNPCs(filter));
		}

		public bool HasHostileNPCs()
		{
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (key.IsEnemy())
				{
					return true;
				}
			}
			return false;
		}

		public HumanoidInstance PickRandom(Predicate<HumanoidInstance> filter = null)
		{
			if (filter == null)
			{
				return npcViews.Keys.PickRandom();
			}
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor();
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (filter(key))
				{
					pooledList.Add(key);
				}
			}
			return pooledList.PickRandom();
		}

		public HumanoidInstance GetFirstOrDefault(Predicate<HumanoidInstance> filter = null)
		{
			if (filter == null)
			{
				return npcViews.Keys.FirstOrDefault();
			}
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (filter(key))
				{
					return key;
				}
			}
			return null;
		}

		public int CountNPCs(Func<HumanoidInstance, bool> filter = null)
		{
			int num = 0;
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (filter == null || filter(key))
				{
					num++;
				}
			}
			return num;
		}

		public bool AnyNpc(Predicate<HumanoidInstance> filter)
		{
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (filter(key))
				{
					return true;
				}
			}
			return false;
		}

		public NPCView GetView(HumanoidInstance instance)
		{
			npcViews.TryGetValue(instance, out var value);
			return value;
		}

		public IEnumerable<HumanoidInstance> GetByRaidId(int raidId)
		{
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				if (key.IsRaiderOfRaid(raidId))
				{
					yield return key;
				}
			}
		}

		private void Start()
		{
			MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent += OnNpcSpawned;
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += OnNpcRemoved;
			MonoSingleton<NPCController>.Instance.ShowToolEvent += OnShowTool;
			MonoSingleton<NPCController>.Instance.HideToolEvent += OnHideTool;
			MonoSingleton<AnimationController>.Instance.TriggerAnimationEvent += OnTriggerAnimation;
			MonoSingleton<AnimationController>.Instance.ResetTriggersAnimationEvent += OnTriggersReset;
			MonoSingleton<AnimationController>.Instance.ForeQuitAnimationEvent += OnTriggerAnimation;
			MonoSingleton<LifeController>.Instance.OnFaintEvent += OnNPCFainted;
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFactionFriendlinessChanged;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
			MonoSingleton<CombatController>.Instance.OnAgentKilledEvent += OnAgentKilled;
			MonoSingleton<CombatController>.Instance.DealGateDamageEvent += OnDealGateDamage;
			MonoSingleton<CombatController>.Instance.DealDrawbridgeDamageEvent += OnDealDrawbridgeDamage;
			MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent += OnRoomAdded;
			MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent += OnRoomRemoved;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCSpawnedEvent -= OnNpcSpawned;
				MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent -= OnNpcRemoved;
				MonoSingleton<NPCController>.Instance.ShowToolEvent -= OnShowTool;
				MonoSingleton<NPCController>.Instance.HideToolEvent -= OnHideTool;
			}
			if (MonoSingleton<AnimationController>.IsInstantiated())
			{
				MonoSingleton<AnimationController>.Instance.TriggerAnimationEvent -= OnTriggerAnimation;
				MonoSingleton<AnimationController>.Instance.ResetTriggersAnimationEvent -= OnTriggersReset;
				MonoSingleton<AnimationController>.Instance.ForeQuitAnimationEvent -= OnTriggerAnimation;
			}
			if (MonoSingleton<LifeController>.IsInstantiated())
			{
				MonoSingleton<LifeController>.Instance.OnFaintEvent -= OnNPCFainted;
			}
			if (MonoSingleton<FactionsController>.IsInstantiated())
			{
				MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent -= OnFactionFriendlinessChanged;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
				MonoSingleton<CombatController>.Instance.OnAgentKilledEvent -= OnAgentKilled;
				MonoSingleton<CombatController>.Instance.DealGateDamageEvent -= OnDealGateDamage;
				MonoSingleton<CombatController>.Instance.DealDrawbridgeDamageEvent -= OnDealDrawbridgeDamage;
			}
			if (MonoSingleton<RoomDetectionController>.IsInstantiated())
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent -= OnRoomAdded;
				MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent -= OnRoomRemoved;
			}
			npcViews.Clear();
			base.OnDestroy();
		}

		private HumanoidInstance SpawnNPC<TBehaviour>(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace village, FactionInstance factionInstance, HumanPreset overrideEquipment = null, string roleId = "", int? randomSeed = null, GameEventInstance fromEvent = null) where TBehaviour : HumanoidBehaviour, new()
		{
			System.Random rnd = (randomSeed.HasValue ? new System.Random(randomSeed.Value) : new System.Random());
			HumanoidInstance humanoidInstance = CreateInstance(blueprintId, bodyType, position, village, factionInstance, rnd);
			humanoidInstance.CustomWarningMessage = fromEvent?.Blueprint.CustomNpcWarningMessage;
			humanoidInstance.SetActiveBehaviour<TBehaviour>();
			if (!string.IsNullOrEmpty(roleId))
			{
				humanoidInstance.ActiveBehaviour.HumanoidRoleOwner.SetRole(roleId, 1);
			}
			CreateViewAndSetup(humanoidInstance, forceRegenerateEquipment: true, overrideEquipment, rnd);
			if (fromEvent != null && fromEvent.Blueprint.CountNpcs)
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.AddToNpcArrivedByEvent(humanoidInstance, fromEvent);
			}
			return humanoidInstance;
		}

		public HumanoidInstance CreateInstance(string blueprintId, BodyType bodyType, Vector3 position, VillagePlace village, FactionInstance faction, System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			NPC byID = Repository<NPCRepository, NPC>.Instance.GetByID(blueprintId);
			if (byID == null)
			{
				throw new Exception("Humanoid blueprint with ID '" + blueprintId + "' not found");
			}
			HumanoidInstance humanoidInstance = new HumanoidInstance(byID.GetID(), position, producedFromGenerator: false, village, faction);
			float height = rnd.Range(byID.Height.Min, byID.Height.Max);
			float weightCoefficient = byID.WeightCoefficient.Random(rnd);
			int age = rnd.Next(byID.Age.Min, byID.Age.Max);
			List<WorkerCharacteristicType> physicalIgnoreTypes = HumanoidUtils.GetPhysicalIgnoreTypes(new List<WorkerCharacteristicType>(), bodyType, height, weightCoefficient);
			IntRange intRange = humanoidInstance.Faction?.Blueprint?.FactionType?.FaithRange;
			float num = ((intRange != null && intRange.Max != 0) ? rnd.Next(intRange.Min, intRange.Max + 1) : rnd.Next(25, 75));
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(49, 3, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning NPC ");
				messageBuilder.AppendFormatted(blueprintId);
				messageBuilder.AppendLiteral(", with faith: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(", faithrange is null: ");
				messageBuilder.AppendFormatted(intRange == null);
			}
			Log.Debug(messageBuilder);
			if (intRange != null)
			{
				messageBuilder = new FVLogDebugInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("-----faithrange min ");
					messageBuilder.AppendFormatted(intRange.Min);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(intRange.Max);
				}
				Log.Debug(messageBuilder);
			}
			Background background = Repository<BackgroundRepository, Background>.Instance.GetBackground(physicalIgnoreTypes, Mathf.RoundToInt(num));
			BackStory background2 = Repository<BackStoryRepository, BackStory>.Instance.GetBackground(physicalIgnoreTypes, Mathf.RoundToInt(num));
			humanoidInstance.SetInfo(new HumanoidInfo(bodyType, age, HumanoidUtils.GetBirthday(), height, weightCoefficient, village?.Name, background.GetID(), background2.GetID(), num / 100f));
			humanoidInstance.Info.SetIgnoredTypes(physicalIgnoreTypes);
			humanoidInstance = HumanoidUtils.SetBackground(humanoidInstance, background);
			humanoidInstance = HumanoidUtils.SetBackStory(humanoidInstance, background2);
			humanoidInstance = HumanoidUtils.SetPseudonym(humanoidInstance);
			humanoidInstance.Info.ReligiousAlignment = Mathf.Clamp01(num / 100f);
			List<SerializableIdValuePair> list = new List<SerializableIdValuePair>();
			foreach (Perk allItem in Repository<PerkRepository, Perk>.Instance.GetAllItems())
			{
				if (allItem.ForbidForNpc)
				{
					list.Add(new SerializableIdValuePair(allItem.GetID(), 0f));
				}
			}
			humanoidInstance = HumanoidUtils.SetPerks(humanoidInstance, list);
			humanoidInstance.RecalcuateGoalPreferencesAndSkillModifiers();
			HumanoidUtils.GenerateSkillLevels(humanoidInstance, isNpc: true);
			FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(111, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Created NPC instance with uniqueId: ");
				messageBuilder2.AppendFormatted(humanoidInstance.UniqueId);
				messageBuilder2.AppendLiteral(", blueprint: '");
				messageBuilder2.AppendFormatted(blueprintId);
				messageBuilder2.AppendLiteral("', bodyType: ");
				messageBuilder2.AppendFormatted(bodyType);
				messageBuilder2.AppendLiteral(", position: ");
				messageBuilder2.AppendFormatted(position);
				messageBuilder2.AppendLiteral(", originVillage: '");
				messageBuilder2.AppendFormatted(village?.Name);
				messageBuilder2.AppendLiteral("', randomIsGiven: ");
				messageBuilder2.AppendFormatted(rnd != null);
			}
			Log.Info(messageBuilder2);
			return humanoidInstance;
		}

		public HumanoidBehaviour CreateViewAndSetup(HumanoidInstance instance, bool forceRegenerateEquipment, HumanPreset overrideEquipment = null, System.Random rnd = null, bool randomizeAppearance = true)
		{
			if (instance.ActiveBehaviour == null || instance.ActiveBehaviour.Blueprint == null)
			{
				Log.Error("Tried to create NPC with no behaviour or blueprint", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
				return null;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(87, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating NPC view and setting it up for instance ");
				messageBuilder.AppendFormatted(instance);
				messageBuilder.AppendLiteral(", overrideEquipment: ");
				messageBuilder.AppendFormatted(overrideEquipment != null);
				messageBuilder.AppendLiteral(", randomIsGiven: ");
				messageBuilder.AppendFormatted(rnd != null);
			}
			Log.Info(messageBuilder);
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			instance.InitStorages();
			NPCView nPCView = GenerateNPCView(instance, instance.Info.BodyType, instance.GetPosition(), rnd);
			HumanPreset humanPreset = ((overrideEquipment != null) ? overrideEquipment : Repository<NPCPresetRepository, HumanPreset>.Instance.GetByID(instance.ActiveBehaviour.NpcBlueprint.EquipmentID));
			List<WorkerSkill> skills = GenerateSkills(humanPreset, instance.ActiveBehaviour.NpcBlueprint.BannedSkills, rnd);
			instance.SetSkills(skills);
			nPCView.Setup(instance, randomizeAppearance, rnd);
			npcViews[nPCView.HumanoidInstance] = nPCView;
			instance.Spawn();
			MonoSingleton<NPCController>.Instance.OnNPCSpawned(nPCView.HumanoidInstance);
			if (forceRegenerateEquipment)
			{
				foreach (EquipmentInstance item in GenerateEquipment(humanPreset, nPCView.HumanoidInstance.ActiveBehaviour.NpcBlueprint.BannedEquipment, rnd))
				{
					item.SetIsManuallyEquipped(value: true);
					nPCView.HumanoidInstance.Inventory.Equip(item, removeInsteadOfDrop: true);
				}
			}
			return instance.ActiveBehaviour;
		}

		public void SpawnProfileNPCs()
		{
			foreach (HumanoidInstance item in new List<HumanoidInstance>(GlobalSaveController.CurrentVillageData.NPCs))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder;
				if (item.HasDied)
				{
					messageBuilder = new FVLogInfoInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("NPC dead: ");
						messageBuilder.AppendFormatted(item);
						messageBuilder.AppendLiteral(", skip loading it.");
					}
					Log.Info(messageBuilder);
					GlobalSaveController.CurrentVillageData.NPCs.Remove(item);
					continue;
				}
				messageBuilder = new FVLogInfoInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loading ");
					messageBuilder.AppendFormatted(item);
				}
				Log.Info(messageBuilder);
				if (!ValidateNPCAfterLoading(item))
				{
					FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(89, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Humanoid '");
						messageBuilder2.AppendFormatted(item.Id);
						messageBuilder2.AppendLiteral("' could not be loaded. Probably removed from repository, but still in save file");
					}
					Log.Warning(messageBuilder2);
					GlobalSaveController.CurrentVillageData.NPCs.Remove(item);
				}
				else
				{
					LoadSavedNPC(item);
				}
			}
		}

		private void LoadSavedNPC(HumanoidInstance instance)
		{
			instance.InitStorages();
			NPCView nPCView = GenerateNPCView(instance, instance.Info.BodyType, instance.GetPosition());
			npcViews[instance] = nPCView;
			nPCView.Setup(instance, randomizeAppearance: false);
			instance.Spawn();
			MonoSingleton<NPCController>.Instance.OnNPCSpawned(nPCView.HumanoidInstance);
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "animal_update", UpdatePetOwners);
		}

		public void RepositionStuckNPCs()
		{
			IEnumerable<HumanoidInstance> source = GlobalSaveController.CurrentVillageData.NPCs.Where((HumanoidInstance e) => e.GetGridPosition() == Vec3Int.zero || (e.GetGridPosition() == Vec3Int.up && !e.GetNode().IsWalkable));
			if (source.Any())
			{
				Log.Info("Repositioning NPCs stuck @ Vec3Int.zero.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
				NPCStartPositionManager.SetStartPositionsForAgents(Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoors(), source.ToList());
			}
		}

		protected override void Awake()
		{
			base.Awake();
			debugEventCooldown = new Cooldown(TutorialManager.IsTutorialActive);
		}

		private void LateUpdate()
		{
			using (ProfilerSampleJanitor.Begin("NPCManager.LateTick"))
			{
				if (!debugEventCooldown.HasEnded || !DebugEventLog.IsInitialized)
				{
					return;
				}
				debugEventCooldown = Cooldown.FromNowMinutes(1, TutorialManager.IsTutorialActive);
				foreach (HumanoidInstance key in npcViews.Keys)
				{
					DebugEventLog.SampleCreatureState(key);
				}
			}
		}

		private bool ValidateNPCAfterLoading(HumanoidInstance humanoid)
		{
			return humanoid.ActiveBehaviour.NpcBlueprint != null;
		}

		private NPCView GenerateNPCView(HumanoidInstance humanoidInstance, BodyType bodyType, Vector3 position, System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			return UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetByAddress(humanoidInstance.CurrentHumanType.GetPrefab(bodyType)), position, Quaternion.Euler(new Vector3(0f, rnd.Next(0, 360), 0f)), base.transform).GetComponent<NPCView>();
		}

		private static List<EquipmentInstance> GenerateEquipment(HumanPreset humanPreset, List<string> bannedEquipment, System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			List<EquipmentInstance> list = new List<EquipmentInstance>();
			if (humanPreset == null)
			{
				return list;
			}
			foreach (NPCItemGroup itemGroup in humanPreset.ItemGroups)
			{
				if (itemGroup.IsNoneRandom(rnd))
				{
					continue;
				}
				List<string> list2 = null;
				list2 = ((bannedEquipment == null) ? itemGroup.Equipment : itemGroup.Equipment.Where((string item) => !bannedEquipment.Contains(item)).ToList());
				string text = list2.PickRandom(rnd);
				if (Repository<EquipmentRepository, Equipment>.Instance.GetByID(text) == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(72, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\NPCManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Tried to spawn Humanoid with equipment id ");
						messageBuilder.AppendFormatted(text);
						messageBuilder.AppendLiteral(" not defined in equipment.json");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					EquipmentInstance equipmentInstance = new EquipmentInstance(text, isManuallyEquiped: false);
					StatInstance stat = equipmentInstance.Stats.GetStat(StatType.Health);
					stat?.SetCurrent(stat.Current * itemGroup.HitPointsRange.Random(rnd));
					list.Add(equipmentInstance);
				}
			}
			return list;
		}

		private List<WorkerSkill> GenerateSkills(HumanPreset humanPreset, List<SkillType> bannedSkills, System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			List<WorkerSkill> list = new List<WorkerSkill>();
			if (humanPreset == null)
			{
				return list;
			}
			foreach (NPCSkillGroup skillGroup in humanPreset.SkillGroups)
			{
				List<WorkerSkill> list2 = null;
				list2 = ((bannedSkills == null) ? skillGroup.Skills : skillGroup.Skills.Where((WorkerSkill item) => !bannedSkills.Contains(item.Id)).ToList());
				int num = list2.Count;
				if (skillGroup.CanBeNone)
				{
					num++;
				}
				int num2 = rnd.Next(0, num);
				if (num2 < list2.Count)
				{
					list.Add(skillGroup.Skills[num2]);
				}
			}
			return list;
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitinfo)
		{
			if (take is HumanoidInstance { WorkerBehaviour: null } humanoidInstance && deal is HumanoidInstance { WorkerBehaviour: not null } && humanoidInstance.IsFriendlyFaction() && !humanoidInstance.HasDisposed)
			{
				humanoidInstance.Faction?.HitFromFriendly(-20f);
			}
		}

		private void OnAgentKilled(IDamageDealAgent deal, IDamageTakingAgent take)
		{
			if (take is HumanoidInstance { WorkerBehaviour: null } humanoidInstance)
			{
				humanoidInstance.OnKilled(deal);
			}
		}

		private void OnFactionFriendlinessChanged(FactionFriendliness friendliness, FactionInstance factionInstance)
		{
			if (friendliness != FactionFriendliness.Hostile && friendliness != FactionFriendliness.PermanentlyHostile)
			{
				return;
			}
			foreach (HumanoidInstance item in IterateNPCs())
			{
				if (item.Faction == factionInstance)
				{
					item.OnFriendlinessStateChanged();
				}
			}
		}

		private void OnNpcSpawned(HumanoidInstance instance)
		{
			if (!GlobalSaveController.CurrentVillageData.NPCs.Contains(instance))
			{
				GlobalSaveController.CurrentVillageData.NPCs.Add(instance);
				DebugEventLog.SampleCreatureState(instance);
			}
		}

		public void DestroyView(HumanoidInstance instance)
		{
			if (npcViews.ContainsKey(instance))
			{
				npcViews[instance].Dispose(disposeInstance: false);
				npcViews.Remove(instance);
			}
		}

		private void OnNpcRemoved(HumanoidInstance instance)
		{
			if (npcViews.ContainsKey(instance))
			{
				DebugEventLog.Write(new CreatureDied(instance, isNaturalDeath: false));
				if (instance.Stats.GetStat(StatType.Health).Current <= 1f)
				{
					string messageText = "<style=DefaultYellow>" + MonoSingleton<LocalizationController>.Instance.GetText(instance.ActiveBehaviour.Blueprint.GetID(), instance.Info) + "</style> " + MonoSingleton<LocalizationController>.Instance.GetText("has_died", instance.Info);
					MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, instance.GetPosition());
				}
				npcViews[instance].Dispose();
				npcViews.Remove(instance);
				MonoSingleton<HumanoidIconManager>.Instance.OnHumanoidRemoved(instance);
				GlobalSaveController.CurrentVillageData.NPCs.Remove(instance);
			}
		}

		private void OnTriggersReset(IGoapAgentOwner agentOwner)
		{
			if (agentOwner is HumanoidInstance key && npcViews.ContainsKey(key))
			{
				npcViews[key].ResetTriggers();
			}
		}

		private void OnTriggerAnimation(IGoapAgentOwner agentOwner, string trigger)
		{
			if (agentOwner is HumanoidInstance key && npcViews.ContainsKey(key))
			{
				npcViews[key].OnTriggerAnimation(trigger);
			}
		}

		private void OnNPCFainted(StatsInstance stats)
		{
			if (stats.Owner is HumanoidInstance { WorkerBehaviour: null } humanoidInstance)
			{
				string messageText = "<style=DefaultYellow>" + MonoSingleton<LocalizationController>.Instance.GetText(humanoidInstance.ActiveBehaviour.Blueprint.GetID()) + "</style> " + MonoSingleton<LocalizationController>.Instance.GetText("has_fainted", humanoidInstance.Info);
				MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, humanoidInstance.GetPosition());
			}
		}

		private void UpdatePetOwners()
		{
			foreach (AnimalInstance animal in GlobalSaveController.CurrentVillageData.Animals)
			{
				if (animal.AnimalType != AnimalType.Pet && animal.AnimalType != AnimalType.DomesticNpc)
				{
					continue;
				}
				int id = animal.UniqueId;
				HumanoidInstance humanoidInstance = npcViews.Keys.FirstOrDefault((HumanoidInstance item) => item.PetsIDs != null && item.PetsIDs.Contains(id));
				if (humanoidInstance != null)
				{
					animal.AssignPetOwner(humanoidInstance);
					if (animal.AnimalType == AnimalType.DomesticNpc)
					{
						animal.RopeTo(humanoidInstance);
					}
				}
			}
		}

		private void OnShowTool(HumanoidInstance humanoid, string toolID, Transform socket)
		{
			if (npcViews.ContainsKey(humanoid))
			{
				npcViews[humanoid].ShowTool(toolID, socket);
			}
		}

		private void OnHideTool(HumanoidInstance humanoid)
		{
			if (npcViews.ContainsKey(humanoid))
			{
				npcViews[humanoid].HideTool();
			}
		}

		private void OnRoomRemoved(Room room)
		{
			UpdateRequiredNPCRooms(room);
		}

		private void OnRoomAdded(Room newRoom, RoomType previousRoomType)
		{
			UpdateRequiredNPCRooms(newRoom);
		}

		private void UpdateRequiredNPCRooms(Room room)
		{
			foreach (HumanoidInstance item in IterateNPCs())
			{
				if (!CombatUtils.IsNullOrDisposed(item))
				{
					Region region = item.GetNode().Region;
					if (room.Regions.Contains(region))
					{
						item.ForceCheckRoomChange();
					}
				}
			}
		}

		private void OnDealGateDamage(DoorComponentInstance doorComponentInstance)
		{
			if (doorComponentInstance == null || doorComponentInstance.HasDisposed || doorComponentInstance.OwnerBuilding == null || doorComponentInstance.OwnerBuilding.HasDisposed)
			{
				return;
			}
			int y = doorComponentInstance.OwnerBuilding.GridDataPosition.y;
			using PooledHashSet<Vec3Int> pooledHashSet = HashSetPool<Vec3Int>.GetJanitor();
			foreach (Vec3Int position in doorComponentInstance.OwnerBuilding.Positions)
			{
				if (position.y == y)
				{
					pooledHashSet.Add(position);
				}
			}
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor();
			foreach (HumanoidInstance key in npcViews.Keys)
			{
				Vec3Int gridPosition = key.GetGridPosition();
				if (pooledHashSet.Contains(gridPosition))
				{
					pooledList.Add(key);
				}
			}
			foreach (HumanoidInstance item in pooledList)
			{
				CombatHitManager.DealGateDamage(item, doorComponentInstance);
			}
		}

		private void OnDealDrawbridgeDamage(DrawbridgeComponent drawbridgeComponent)
		{
			if (drawbridgeComponent == null)
			{
				return;
			}
			DoorComponentInstance componentInstance = drawbridgeComponent.DoorComponent.ComponentInstance;
			if (componentInstance == null || componentInstance.HasDisposed || componentInstance.OwnerBuilding == null || componentInstance.OwnerBuilding.HasDisposed)
			{
				return;
			}
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor(npcViews.Keys);
			for (int num = pooledList.Count - 1; num >= 0; num--)
			{
				Vec3Int gridPosition = pooledList[num].GetGridPosition();
				if (drawbridgeComponent.DrawbridgePositions.Contains(gridPosition))
				{
					CombatHitManager.DealGateDamage(pooledList[num], componentInstance);
				}
			}
		}
	}
}
