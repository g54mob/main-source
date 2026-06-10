using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.Goap;
using NSMedieval.Heraldry;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.View;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("NegotiationPhase", "")]
	public class NegotiationPhase : GameEventBranchingPhaseBase
	{
		private enum NegotiationState
		{
			None = 0,
			Waiting = 1,
			NegotiatorLeaving = 2,
			NegotiatorKilled = 3
		}

		private readonly NegotiationPhaseConfig config;

		private NegotiationState negotiationState;

		private NegotiationEndResult negotiationEndResult;

		private int negotiatorNPCId;

		private Vector3 campfirePosition;

		private Vector3 bannerPosition;

		private float bannerYRotation;

		private CountdownWithWarningMessage countdown;

		private bool negotiatorLeftMap;

		private GameObject campfireProp;

		private GameObject bannerProp;

		private INegotiator negotiator;

		private readonly HashSet<int> npcsRemainingToLeaveMap = new HashSet<int>();

		private Cooldown negotiatorLeaveTimeout;

		private IRaidPhaseDataHolder RaidDataHolder => base.EventInstance as IRaidPhaseDataHolder;

		private RaiderBlueprintId[] EnemyBlueprintIds => RaidDataHolder.EnemyBlueprintIds;

		private INegotiationPhaseHolder NegotiationPhaseHolder => base.EventInstance as INegotiationPhaseHolder;

		private HumanoidInstance NegotiatorNPC
		{
			get
			{
				return NegotiationPhaseHolder.Negotiator;
			}
			set
			{
				NegotiationPhaseHolder.Negotiator = value;
			}
		}

		public VillagePlace RaiderVillagePlace
		{
			get
			{
				object obj = RaidDataHolder?.RaiderOriginVillage;
				if (obj == null)
				{
					HumanoidInstance humanoidInstance = NegotiationPhaseHolder.Negotiator;
					if (humanoidInstance == null)
					{
						return null;
					}
					VillagePlaceReference originVillage = humanoidInstance.OriginVillage;
					if (originVillage == null)
					{
						return null;
					}
					obj = originVillage.VillageValue;
				}
				return (VillagePlace)obj;
			}
		}

		public FactionInstance RaiderFactionInstance
		{
			get
			{
				object obj = RaidDataHolder?.RaiderFactionInstance;
				if (obj == null)
				{
					HumanoidInstance humanoidInstance = NegotiationPhaseHolder.Negotiator;
					if (humanoidInstance == null)
					{
						return null;
					}
					obj = humanoidInstance.Faction;
				}
				return (FactionInstance)obj;
			}
		}

		public NegotiationPhase(in NegotiationPhaseConfig config)
		{
			this.config = config;
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
			DisposeUIAndProps();
			negotiator = null;
		}

		public override bool OnStart()
		{
			VerifyEventImplements<INegotiationPhaseHolder>();
			if (config.UseExistingNegotiatorNPC == null)
			{
				VerifyEventImplements<IRaidPhaseDataHolder>();
			}
			negotiatorLeftMap = false;
			negotiationState = NegotiationState.Waiting;
			negotiationEndResult = NegotiationEndResult.None;
			negotiatorNPCId = int.MaxValue;
			int countdownDurationMinutes = config.CountdownDurationMinutes;
			countdown = new CountdownWithWarningMessage(config.CountdownText, config.CountdownTooltip, config.CountdownIcon, countdownDurationMinutes, RaiderFactionInstance?.BlueprintId, null, config.CountdownText != null);
			if (!InitNegotiationParty())
			{
				GameEventPhaseBase.Logger.Error("Can't start NegotiationPhase: failed to spawn negotiator");
				return false;
			}
			Subscribe();
			MonoSingleton<GameSpeedManager>.Instance.SetSpeedPause();
			MonoSingleton<NewsManager>.Instance.Publish(config.NewsMessage);
			FVLogger logger = GameEventPhaseBase.Logger;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Started NegotiationPhase with countdownMinutes=");
				messageBuilder.AppendFormatted(countdownDurationMinutes);
			}
			logger.Info(in messageBuilder);
			return true;
		}

		public override void OnLoaded(bool fromSave)
		{
			countdown?.OnLoaded();
			if (!InitNegotiationParty())
			{
				GameEventPhaseBase.Logger.Error("Failed to init negotiation party on load. This should not happen, force-ending the event");
				base.EventInstance.ForceEnd();
			}
			else
			{
				Subscribe();
			}
		}

		public override void OnEnd()
		{
			DisposeUIAndProps();
			Unsubscribe();
		}

		private void Subscribe()
		{
			if (countdown != null)
			{
				countdown.OnClick = delegate
				{
					JumpToNegotiator();
				};
			}
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent += OnNPCDied;
			MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent += OnNPCRemoved;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
			MonoSingleton<NewsManager>.Instance.OnDialogClosed += OnNewsDialogClosed;
			negotiator.InteractedWithEvent += OnInteractedWithNegotiator;
			INegotiationPhaseHolder negotiationPhaseHolder = NegotiationPhaseHolder;
			negotiationPhaseHolder.NegotiationFinishedEvent = (Action<NegotiationEndResult>)Delegate.Combine(negotiationPhaseHolder.NegotiationFinishedEvent, new Action<NegotiationEndResult>(OnNegotiationEndedFromOutside));
		}

		private void Unsubscribe()
		{
			if (countdown != null)
			{
				countdown.OnClick = null;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCDiedEvent -= OnNPCDied;
				MonoSingleton<NPCController>.Instance.OnNPCRemovedEvent -= OnNPCRemoved;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
			}
			if (MonoSingleton<NewsManager>.IsInstantiated())
			{
				MonoSingleton<NewsManager>.Instance.OnDialogClosed -= OnNewsDialogClosed;
			}
			if (negotiator != null)
			{
				negotiator.InteractedWithEvent -= OnInteractedWithNegotiator;
			}
			if (NegotiationPhaseHolder != null)
			{
				INegotiationPhaseHolder negotiationPhaseHolder = NegotiationPhaseHolder;
				negotiationPhaseHolder.NegotiationFinishedEvent = (Action<NegotiationEndResult>)Delegate.Remove(negotiationPhaseHolder.NegotiationFinishedEvent, new Action<NegotiationEndResult>(OnNegotiationEndedFromOutside));
			}
			if (MonoSingleton<ChatGraphManager>.IsInstantiated())
			{
				MonoSingleton<ChatGraphManager>.Instance.BeforeShowDialogEvent -= OnBeforeShowChatDialog;
				MonoSingleton<ChatGraphManager>.Instance.ChatOptionChosenEvent -= OnChatOptionChosen;
			}
		}

		private void OnNewsDialogClosed(uint newsId, int chosenOptionIndex)
		{
			if (newsId == config.NewsMessage.Id && chosenOptionIndex == 1)
			{
				JumpToNegotiator();
			}
		}

		private void JumpToNegotiator()
		{
			MonoSingleton<RtsCamera>.Instance.JumpTo(NegotiatorNPC.GetPosition());
		}

		private void DisposeUIAndProps()
		{
			if (countdown == null)
			{
				return;
			}
			countdown?.Dispose();
			countdown = null;
			if (MonoSingleton<NewsManager>.IsInstantiated())
			{
				MonoSingleton<NewsManager>.Instance.Remove(config.NewsMessage.Id);
			}
			if (!config.SpawnCampfire)
			{
				return;
			}
			Transform transform = campfireProp?.transform.Find("Flame");
			if (transform != null)
			{
				transform.gameObject.SetActive(value: false);
			}
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(15f).Then(delegate
			{
				if (campfireProp != null)
				{
					UnityEngine.Object.Destroy(campfireProp);
				}
				if (bannerProp != null)
				{
					UnityEngine.Object.Destroy(bannerProp);
				}
			});
		}

		private void OnInteractedWithNegotiator(HumanoidInstance worker)
		{
			if (negotiationState == NegotiationState.Waiting)
			{
				MonoSingleton<ChatGraphManager>.Instance.BeforeShowDialogEvent -= OnBeforeShowChatDialog;
				MonoSingleton<ChatGraphManager>.Instance.ChatOptionChosenEvent -= OnChatOptionChosen;
				MonoSingleton<ChatGraphManager>.Instance.BeforeShowDialogEvent += OnBeforeShowChatDialog;
				MonoSingleton<ChatGraphManager>.Instance.ChatOptionChosenEvent += OnChatOptionChosen;
				MonoSingleton<ChatGraphManager>.Instance.StartNew(config.ChatGraphId, worker, negotiator.Humanoid);
			}
		}

		private void OnBeforeShowChatDialog(string chatGraphId, string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (!(chatGraphId != config.ChatGraphId) && chatTarget == negotiator.Humanoid)
			{
				NegotiationPhaseHolder.FormatChatDialogContent(dialogName, dialogContent, chatInitiator, chatTarget);
			}
		}

		private void OnChatOptionChosen(string chatGraphId, string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (!(chatGraphId != config.ChatGraphId) && chatTarget == negotiator.Humanoid)
			{
				NegotiationPhaseHolder.OnNegotiationChatOptionChosen(dialogName, optionIndex, chatInitiator, chatTarget);
			}
		}

		private void OnNegotiationEndedFromOutside(NegotiationEndResult endResult)
		{
			if (negotiationState == NegotiationState.Waiting)
			{
				FVLogger logger = GameEventPhaseBase.Logger;
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Negotiations ended from outside, result: ");
					messageBuilder.AppendFormatted(endResult);
				}
				logger.Info(in messageBuilder);
				negotiationState = NegotiationState.NegotiatorLeaving;
				negotiationEndResult = endResult;
				DisposeUIAndProps();
				MakeNegotiatorPartyLeaveMap();
			}
		}

		protected override int TickNextPhaseIndex()
		{
			FVLogInfoInterpolationHandler messageBuilder;
			bool isEnabled;
			switch (negotiationState)
			{
			case NegotiationState.Waiting:
				if (NegotiationPhaseHolder.TickShouldCancelNegotiations())
				{
					negotiationState = NegotiationState.NegotiatorLeaving;
					negotiationEndResult = NegotiationEndResult.Cancelled;
					DisposeUIAndProps();
					MakeNegotiatorPartyLeaveMap();
					FVLogger logger2 = GameEventPhaseBase.Logger;
					messageBuilder = new FVLogInfoInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Negotiations cancelled, negotiator leaving, state=");
						messageBuilder.AppendFormatted(negotiationState);
					}
					logger2.Info(in messageBuilder);
				}
				else if (countdown.TimeInterval.HasEnded)
				{
					negotiationState = NegotiationState.NegotiatorLeaving;
					negotiationEndResult = NegotiationEndResult.FailTimedOut;
					DisposeUIAndProps();
					MakeNegotiatorPartyLeaveMap();
					FVLogger logger3 = GameEventPhaseBase.Logger;
					messageBuilder = new FVLogInfoInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Time's up, negotiator leaving, state=");
						messageBuilder.AppendFormatted(negotiationState);
					}
					logger3.Info(in messageBuilder);
				}
				break;
			case NegotiationState.NegotiatorLeaving:
				if (negotiatorLeftMap)
				{
					FVLogger logger = GameEventPhaseBase.Logger;
					messageBuilder = new FVLogInfoInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Negotiator left map, returning ");
						messageBuilder.AppendFormatted(negotiationEndResult);
						messageBuilder.AppendLiteral(" phase");
					}
					logger.Info(in messageBuilder);
					if (negotiationEndResult == NegotiationEndResult.FailNegotiatorAttacked && config.UseExistingNegotiatorNPC == null)
					{
						RaidDataHolder.OverrideRaidSpawnPositions = FindRaiderSpawnPoints(negotiator.Humanoid.GetNode(), RaidDataHolder.EnemyBlueprintIds.Length);
					}
					return (int)negotiationEndResult;
				}
				if (negotiatorLeaveTimeout.TimeEndMinutes != 0L && negotiatorLeaveTimeout.HasEnded)
				{
					negotiationEndResult = NegotiationEndResult.FailTimedOut;
					NegotiatorNPC.RetreatFromMap();
					npcsRemainingToLeaveMap.Clear();
					npcsRemainingToLeaveMap.Add(NegotiatorNPC.UniqueId);
					if (config.UseExistingNegotiatorNPC == null)
					{
						RaidDataHolder.OverrideRaidSpawnPositions = FindRaiderSpawnPoints(negotiator.Humanoid.GetNode(), RaidDataHolder.EnemyBlueprintIds.Length);
					}
					negotiatorLeaveTimeout = Cooldown.FromNowHours(100000);
					GameEventPhaseBase.Logger.Info("Negotiator leave timeout");
				}
				break;
			case NegotiationState.NegotiatorKilled:
				GameEventPhaseBase.Logger.Info("Negotiator killed, returning fail killed phase");
				return (int)negotiationEndResult;
			}
			return -1;
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (negotiationState == NegotiationState.Waiting && take.DamageAgentType == DamageTakingAgentType.NPC && take == negotiator.Humanoid)
			{
				negotiationState = NegotiationState.NegotiatorLeaving;
				negotiationEndResult = NegotiationEndResult.FailNegotiatorAttacked;
				DisposeUIAndProps();
				MakeNegotiatorPartyLeaveMap();
				FVLogger logger = GameEventPhaseBase.Logger;
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Negotiator took damage, state=");
					messageBuilder.AppendFormatted(negotiationState);
				}
				logger.Info(in messageBuilder);
			}
		}

		private void OnNPCDied(HumanoidInstance npc)
		{
			if (npc != negotiator.Humanoid || negotiationState == NegotiationState.NegotiatorKilled)
			{
				return;
			}
			negotiationState = NegotiationState.NegotiatorKilled;
			negotiationEndResult = NegotiationEndResult.FailNegotiatorKilled;
			DisposeUIAndProps();
			foreach (AnimalInstance item in negotiator.Humanoid.Pets.ToList())
			{
				if (!item.HasDisposed)
				{
					item.AssignPetOwner(null);
					item.RopeTo(null);
					item.SetAnimalType(AnimalType.Domestic);
				}
			}
			FVLogger logger = GameEventPhaseBase.Logger;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Negotiator NPC died, negotiationState=");
				messageBuilder.AppendFormatted(negotiationState);
			}
			logger.Info(in messageBuilder);
		}

		private void OnNPCRemoved(HumanoidInstance npc)
		{
			if (negotiationState != NegotiationState.NegotiatorLeaving || negotiatorLeftMap)
			{
				return;
			}
			if (npc.HasDied && npc != NegotiatorNPC && npcsRemainingToLeaveMap.Remove(npc.UniqueId))
			{
				negotiationEndResult = NegotiationEndResult.FailNegotiatorAttacked;
				NegotiatorNPC.RetreatFromMap();
				npcsRemainingToLeaveMap.Clear();
				npcsRemainingToLeaveMap.Add(NegotiatorNPC.UniqueId);
				negotiatorLeaveTimeout = Cooldown.FromNowHours(6);
			}
			else if (!npc.HasDied)
			{
				npcsRemainingToLeaveMap.Remove(npc.UniqueId);
				if (npcsRemainingToLeaveMap.Count == 1)
				{
					NegotiatorNPC.RetreatFromMap();
				}
				else if (npcsRemainingToLeaveMap.Count == 0)
				{
					negotiatorLeftMap = true;
					GameEventPhaseBase.Logger.Info("Negotiator party has left the map");
				}
			}
		}

		private bool InitNegotiationParty()
		{
			bool isEnabled;
			if (negotiatorNPCId == int.MaxValue)
			{
				if (config.UseExistingNegotiatorNPC != null)
				{
					NegotiatorNPC = config.UseExistingNegotiatorNPC;
				}
				else if (NegotiatorNPC == null)
				{
					HumanoidInstance humanoidInstance = (NegotiatorNPC = GenerateNegotiatorInstance(EnemyBlueprintIds, RaiderVillagePlace, RaidDataHolder.RaiderFactionInstance));
				}
				if (!InitNegotiator())
				{
					return false;
				}
				NegotiatorNPC.InitStorage(new StorageBase(200, ignoreWeigth: true, infinite: true));
			}
			else if (config.UseExistingNegotiatorNPC != null)
			{
				NegotiatorNPC = config.UseExistingNegotiatorNPC;
			}
			else
			{
				NegotiatorNPC = MonoSingleton<NPCManager>.Instance.GetByCreationID(negotiatorNPCId);
				if (NegotiatorNPC == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(66, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Cannot initialize negotiation party, failed to find NPC with ID '");
						messageBuilder.AppendFormatted(negotiatorNPCId);
						messageBuilder.AppendLiteral("'");
					}
					Log.Error(messageBuilder);
					return false;
				}
			}
			negotiator = NegotiatorNPC.ActiveBehaviour as INegotiator;
			if (negotiator == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to cast negotiator NPC behaviour, ");
					messageBuilder.AppendFormatted(NegotiatorNPC);
				}
				Log.Error(messageBuilder);
				return false;
			}
			SetupPropsAndViews();
			if (negotiationState == NegotiationState.NegotiatorLeaving)
			{
				MakeNegotiatorPartyLeaveMap();
			}
			return true;
		}

		public static HumanoidInstance GenerateNegotiatorInstance(RaiderBlueprintId[] enemyBlueprintIds, VillagePlace raiderVillagePlace, FactionInstance faction)
		{
			RaiderBlueprintId raiderBlueprintId = (from raiderBlueprintId2 in enemyBlueprintIds
				where raiderBlueprintId2.Type == RaiderBlueprintId.RaiderType.NPC
				orderby raiderBlueprintId2.FindBlueprint().GetPrice()
				select raiderBlueprintId2).First();
			BodyType bodyType = faction?.GetRandomBodyType() ?? BodyType.Male;
			System.Random rnd = new System.Random((raiderBlueprintId.RandomSeed = new System.Random().Next()).Value);
			return MonoSingleton<NPCManager>.Instance.CreateInstance(raiderBlueprintId.Id, bodyType, Vector3.zero, raiderVillagePlace, faction, rnd);
		}

		private bool InitNegotiator()
		{
			if (!TryFindNegotiatorSpawnPoints(out var negotiatorNode, out var campfireNode, out var bannerNode))
			{
				GameEventPhaseBase.Logger.Error("Failed to find negotiator spawn points");
				return false;
			}
			if (MonoSingleton<NPCManager>.Instance.GetView(NegotiatorNPC) == null)
			{
				NegotiatorBehaviour negotiatorBehaviour = NegotiatorNPC.SetActiveBehaviour<NegotiatorBehaviour>();
				MonoSingleton<NPCManager>.Instance.CreateViewAndSetup(NegotiatorNPC, forceRegenerateEquipment: true);
				NegotiatorNPC.UpdatePosition(negotiatorNode.WorldPosition);
				if (config.WontNegotiateWithWorkerId.HasValue)
				{
					negotiatorBehaviour.WontNegotiateWithWorkerId = config.WontNegotiateWithWorkerId.Value;
					negotiatorBehaviour.WontNegotiateWithWorkerBBTTextKey = config.WontNegotiateWithWorkerBBTTextKey;
				}
				TraderType byID = Repository<TraderTypeRepository, TraderType>.Instance.GetByID("shakedown_negotiator");
				if (byID == null)
				{
					throw new Exception("Trader type 'shakedown_negotiator' not found. Failed to initialize negotiator.");
				}
				negotiatorBehaviour.TraderType = byID;
			}
			negotiatorNPCId = NegotiatorNPC.UniqueId;
			if (config.SpawnCampfire)
			{
				campfirePosition = ((campfireNode.WaterDepthLevel != WaterDepthLevel.None) ? Vector3.negativeInfinity : campfireNode.WorldPosition);
				bannerPosition = bannerNode.WorldPosition;
				bannerYRotation = UnityEngine.Random.Range(-45f, 45f);
			}
			return true;
		}

		private void SetupPropsAndViews()
		{
			if (!config.SpawnCampfire)
			{
				return;
			}
			if (campfirePosition != Vector3.negativeInfinity)
			{
				GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("camp_fire_prop");
				campfireProp = UnityEngine.Object.Instantiate(byAddress, campfirePosition, byAddress.transform.rotation);
			}
			MapNode node = negotiator.Humanoid.GetNode();
			Vector3 vector = ((!(campfireProp != null)) ? (GridUtils.GetWorldPosition(MonoSingleton<World>.Instance.Center) - node.WorldPosition) : (campfireProp.transform.position - node.WorldPosition));
			vector.Normalize();
			GameObject byAddress2 = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("linen_banner_prop");
			Quaternion rotation = Quaternion.LookRotation(-vector) * Quaternion.Euler(0f, bannerYRotation, 0f);
			bannerProp = UnityEngine.Object.Instantiate(byAddress2, bannerPosition, rotation);
			MeshRenderer componentInChildren = bannerProp.GetComponentInChildren<MeshRenderer>();
			MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(componentInChildren);
			MonoSingleton<HeraldryManager>.Instance.SetHeraldryOnBlock(materialPropertyBlock, RaiderFactionInstance);
			componentInChildren.SetPropertyBlock(materialPropertyBlock);
			negotiator.Humanoid.UpdateRotation(Quaternion.LookRotation(vector));
			if (node.WaterDepthLevel == WaterDepthLevel.None)
			{
				negotiator.Humanoid.GetAgentView<NPCView>().BodyPreview.SetShieldOnBack(putOnBack: true);
				MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
				{
					MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(negotiator.Humanoid, "FloorSit");
				});
			}
		}

		private static bool TryFindNegotiatorSpawnPoints(out MapNode negotiatorNode, out MapNode campfireNode, out MapNode bannerNode)
		{
			negotiatorNode = null;
			campfireNode = null;
			bannerNode = null;
			WalkableModel testAgentWalkableDoorsNoWater = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoorsNoWater();
			List<MapNode> spawnAreaNodes = MonoSingleton<NPCStartPositionManager>.Instance.GetRandomEdgeFloodFill(testAgentWalkableDoorsNoWater, 16, 0.4f, 2f);
			if (spawnAreaNodes.Count == 0)
			{
				Log.Info("Failed to find negotiator spawn points on the first try, relaxing the params and trying again", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
				spawnAreaNodes = MonoSingleton<NPCStartPositionManager>.Instance.GetRandomEdgeFloodFill(testAgentWalkableDoorsNoWater, 4, 0f, 4f);
				if (spawnAreaNodes.Count == 0)
				{
					Log.Info("Failed to find negotiator spawn points on the second relaxed try, relaxing the params even more and trying again (this time accepting unreachable areas)", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\NegotiationPhase.cs");
					spawnAreaNodes = MonoSingleton<NPCStartPositionManager>.Instance.GetRandomEdgeFloodFill(testAgentWalkableDoorsNoWater, 4, 0f, 4f, onlyReachable: false);
				}
			}
			if (spawnAreaNodes.Count == 0)
			{
				GameEventPhaseBase.Logger.Debug("SpawnAreaNodes.Count == 0, failed to find negotiator spawn points");
				return false;
			}
			Vec3Int mapCenter = MonoSingleton<World>.Instance.Center;
			spawnAreaNodes.Sort(delegate(MapNode node1, MapNode node2)
			{
				float num = (mapCenter - node1.Position).sqrMagnitude;
				float value = (mapCenter - node2.Position).sqrMagnitude;
				return num.CompareTo(value);
			});
			foreach (MapNode possibleCampfireNode in spawnAreaNodes)
			{
				MapNode mapNode = (from node in possibleCampfireNode.Neighbours
					where spawnAreaNodes.Contains(node) && node.Position.y == possibleCampfireNode.Position.y
					orderby (mapCenter - node.Position).sqrMagnitude descending
					select node).FirstOrDefault();
				MapNode mapNode2 = (from node in mapNode?.Neighbours
					where spawnAreaNodes.Contains(node) && node.Position.y == possibleCampfireNode.Position.y && node != possibleCampfireNode
					orderby (mapCenter - node.Position).sqrMagnitude
					select node).FirstOrDefault();
				if (mapNode != null && mapNode2 != null)
				{
					campfireNode = possibleCampfireNode;
					negotiatorNode = mapNode;
					bannerNode = mapNode2;
					break;
				}
			}
			if (negotiatorNode == null)
			{
				GameEventPhaseBase.Logger.Error("Failed to find spawn point with campfire for negotiator");
				return false;
			}
			return true;
		}

		private static List<MapNode> FindRaiderSpawnPoints(MapNode startNode, int count)
		{
			List<MapNode> list = new List<MapNode>();
			list.Add(startNode);
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(startNode, float.MaxValue))
			{
				if (list.Count >= count)
				{
					break;
				}
				list.Add(item);
			}
			return list;
		}

		private void MakeNegotiatorPartyLeaveMap()
		{
			MonoSingleton<ChatGraphManager>.Instance.BeforeShowDialogEvent -= OnBeforeShowChatDialog;
			MonoSingleton<ChatGraphManager>.Instance.ChatOptionChosenEvent -= OnChatOptionChosen;
			negotiatorLeaveTimeout = Cooldown.FromNowHours(6);
			negotiator.WantsToNegotiate = false;
			MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(negotiator.Humanoid, "ForceQuit");
			NPCView agentView = NegotiatorNPC.GetAgentView<NPCView>();
			agentView.BodyPreview.SetShieldOnBack(putOnBack: false);
			Animator negotiatorAnimator = agentView.Animator;
			int baseLayerIndex = negotiatorAnimator.GetLayerIndex("Base Layer");
			float startTime = Time.time;
			MonoSingleton<TaskController>.Instance.WaitFor(1f).ThenWaitUntil((float time) => time - startTime > 4f || negotiatorAnimator == null || !negotiatorAnimator.IsInTransition(baseLayerIndex)).Then(delegate
			{
				npcsRemainingToLeaveMap.Clear();
				if (NegotiatorNPC != null)
				{
					npcsRemainingToLeaveMap.Add(NegotiatorNPC.UniqueId);
				}
				foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.IsPrisoner() && npc.PrisonerBehaviour.Owner == NegotiatorNPC))
				{
					if (!item.HasDied && !item.HasDisposed)
					{
						item.SetWalkableModel("enemy_friendly");
						item.RopeTo(null);
						item.RetreatFromMap();
						npcsRemainingToLeaveMap.Add(item.UniqueId);
					}
				}
				if (NegotiatorNPC != null && npcsRemainingToLeaveMap.Count == 1 && npcsRemainingToLeaveMap.Contains(NegotiatorNPC.UniqueId))
				{
					NegotiatorNPC.RetreatFromMap();
				}
				(base.EventInstance as INegotiationPhaseHolder)?.OnNegotiatorLeaveMap();
			});
		}

		public NegotiationPhase NextPhaseOn(NegotiationEndResult endResult, GameEventPhaseBase nextPhase)
		{
			SetNextPhase(nextPhase, (int)endResult);
			return this;
		}

		public NegotiationPhase NextPhaseOnFailOther(GameEventPhaseBase nextPhase)
		{
			NegotiationEndResult[] array = new NegotiationEndResult[4]
			{
				NegotiationEndResult.FailNegotiatorAttacked,
				NegotiationEndResult.FailNegotiatorKilled,
				NegotiationEndResult.FailPlayerRejected,
				NegotiationEndResult.FailTimedOut
			};
			foreach (NegotiationEndResult num in array)
			{
				List<GameEventPhaseBase> list = nextPhases;
				int index = (int)num;
				if (list[index] == null)
				{
					GameEventPhaseBase gameEventPhaseBase = (list[index] = nextPhase);
				}
			}
			return this;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("config", config);
			serializer.WriteEnum("negotiationState", negotiationState);
			serializer.WriteEnum("negotiationEndResult", negotiationEndResult);
			serializer.Write("countdown", countdown);
			serializer.Write("negotiatorLeftMap", negotiatorLeftMap);
			serializer.Write("negotiatorNPCId", negotiatorNPCId);
			serializer.Write("campfirePosition", campfirePosition);
			serializer.Write("bannerPosition", bannerPosition);
			serializer.Write("bannerYRotation", bannerYRotation);
			serializer.Write("npcsRemainingToLeaveMap", npcsRemainingToLeaveMap);
		}

		public NegotiationPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			negotiationState = deserializer.ReadEnum("negotiationState", NegotiationState.None);
			negotiationEndResult = deserializer.ReadEnum("negotiationEndResult", NegotiationEndResult.None);
			countdown = deserializer.ReadObject<CountdownWithWarningMessage>("countdown");
			negotiatorLeftMap = deserializer.ReadBool("negotiatorLeftMap");
			negotiatorNPCId = deserializer.ReadInt("negotiatorNPCId");
			campfirePosition = deserializer.ReadVector3("campfirePosition");
			bannerPosition = deserializer.ReadVector3("bannerPosition");
			bannerYRotation = deserializer.ReadFloat("bannerYRotation");
			npcsRemainingToLeaveMap = deserializer.ReadIntHashSet("npcsRemainingToLeaveMap") ?? new HashSet<int>();
			config = deserializer.ReadObject<NegotiationPhaseConfig>("config");
			if (config.ChatGraphId == null)
			{
				config.ChatGraphId = deserializer.ReadString("chatGraphId");
				config.NewsMessage = deserializer.ReadObject<NewsData>("newsMessage");
				config.WontNegotiateWithWorkerId = deserializer.ReadNullableInt("wontNegotiateWithWorkerId");
				config.WontNegotiateWithWorkerBBTTextKey = deserializer.ReadString("wontNegotiateWithWorkerBBTTextKey");
				config.CountdownText = "warning_message_short_NegotiationCountdown";
				config.CountdownTooltip = "warning_message_info_NegotiationCountdown";
				config.CountdownIcon = "Idle";
				config.CountdownDurationMinutes = 60;
				config.SpawnCampfire = !campfirePosition.Equals(default(Vector3));
			}
		}
	}
}
