using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("SpawnIdleNPCsPhase", "")]
	public class SpawnIdleNPCsPhase : GameEventLinearPhaseBase
	{
		private const int PhaseDurationHours = 6;

		private TimeInterval eventEndTimer;

		private int npcSpawnCount;

		private bool npcsSentAway;

		private string idleAnimTrigger;

		private bool standInPlace;

		private readonly bool spawnInGroup;

		private readonly string[] targetRoomTypes;

		private IEndGamePhaseDataHolder ExternalDataHolder => base.EventInstance as IEndGamePhaseDataHolder;

		private List<HumanoidInstance> NPCs => ExternalDataHolder.NPCs;

		public SpawnIdleNPCsPhase(int npcSpawnCount, bool spawnInGroup, string[] targetRoomTypes, string idleAnimTrigger, bool standInPlace)
		{
			this.targetRoomTypes = targetRoomTypes;
			this.npcSpawnCount = npcSpawnCount;
			this.spawnInGroup = spawnInGroup;
			this.idleAnimTrigger = idleAnimTrigger;
			this.standInPlace = standInPlace;
		}

		public override bool OnStart()
		{
			SpawnNPCs(npcSpawnCount);
			eventEndTimer = TimeInterval.FromNowHours(6);
			return true;
		}

		protected override bool TickShouldEnd()
		{
			if (!eventEndTimer.HasEnded)
			{
				return false;
			}
			if (!npcsSentAway)
			{
				npcsSentAway = true;
				RetreatAll();
			}
			foreach (HumanoidInstance nPC in NPCs)
			{
				if (!nPC.HasDisposed)
				{
					return false;
				}
			}
			return true;
		}

		private void RetreatAll()
		{
			Log.Info("Retreating all npcs", "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\SpawnIdleNPCsPhase.cs");
			foreach (HumanoidInstance nPC in NPCs)
			{
				if (!nPC.HasDied && !nPC.HasDisposed)
				{
					nPC.RetreatFromMap();
				}
			}
		}

		private void SpawnNPCs(int spawnCount)
		{
			for (int i = 0; i < spawnCount; i++)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(16, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\SpawnIdleNPCsPhase.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Spawning NPC ");
					messageBuilder.AppendFormatted(i);
					messageBuilder.AppendLiteral(" / ");
					messageBuilder.AppendFormatted(spawnCount);
				}
				Log.Info(messageBuilder);
				HumanoidInstance item = SpawnNPC();
				NPCs.Add(item);
			}
			if (spawnInGroup)
			{
				NPCStartPositionManager.SetStartPositionsForAgents(NPCs[0].WalkableModel, NPCs);
				return;
			}
			List<Room> rooms;
			bool allRoomsOfType = NPCs[0].Map.RoomDetection.GetAllRoomsOfType(targetRoomTypes, out rooms);
			using PooledHashSet<Region> pooledHashSet = HashSetPool<Region>.GetJanitor();
			if (!allRoomsOfType || rooms.Count == 0)
			{
				foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
				{
					if (key != null && !key.HasDied && !key.HasDisposed && !key.IsInIncognitoMode())
					{
						Region region = key.GetNode().Region;
						if (region != null)
						{
							pooledHashSet.Add(region);
						}
					}
				}
			}
			foreach (Room item2 in rooms)
			{
				pooledHashSet.AddRange(item2.Regions);
			}
			NPCStartPositionManager.SetStartPositionsForAgentsRandom(NPCs[0].WalkableModel, NPCs, pooledHashSet);
		}

		private HumanoidInstance SpawnNPC()
		{
			VillagePlace villagePlace = FactionUtil.GetVillagesByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).PickRandom();
			FactionInstance factionInstance = villagePlace?.FactionInstance;
			if (factionInstance == null)
			{
				factionInstance = FactionUtil.GetFactionsByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).PickRandom();
			}
			string blueprintId = base.Blueprint.NpcId ?? "pilgrim_visitor_1";
			NPCManager instance = MonoSingleton<NPCManager>.Instance;
			BodyType randomBodyType = factionInstance.GetRandomBodyType();
			Vector3 zero = Vector3.zero;
			FactionInstance factionInstance2 = factionInstance;
			GameEventInstance eventInstance = base.EventInstance;
			HumanoidInstance npc = instance.SpawnPilgrimVisitor(blueprintId, randomBodyType, zero, villagePlace, factionInstance2, null, eventInstance);
			npc.ActiveBehaviour.IdleAnimationTrigger = idleAnimTrigger;
			npc.ActiveBehaviour.StandInPlace = standInPlace;
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				npc.GetGoapAgent()?.StartTicker();
			});
			return npc;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("eventEndTimer", eventEndTimer);
			serializer.Write("npcSpawnCount", npcSpawnCount);
			serializer.Write("npcsSentAway", npcsSentAway);
			serializer.Write("spawnInGroup", spawnInGroup);
			serializer.Write("targetRoomTypes", targetRoomTypes);
			serializer.Write("idleAnimTrigger", idleAnimTrigger);
			serializer.Write("standInPlace", standInPlace);
		}

		public SpawnIdleNPCsPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
			eventEndTimer = deserializer.ReadObject<TimeInterval>("eventEndTimer");
			npcSpawnCount = deserializer.ReadInt("npcSpawnCount");
			npcsSentAway = deserializer.ReadBool("npcsSentAway");
			spawnInGroup = deserializer.ReadBool("spawnInGroup");
			targetRoomTypes = deserializer.ReadStringArray("targetRoomTypes");
			idleAnimTrigger = deserializer.ReadString("idleAnimTrigger");
			standInPlace = deserializer.ReadBool("standInPlace");
		}
	}
}
