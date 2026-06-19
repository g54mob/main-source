using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using I2.Loc;
using ModIO;
using PugMod;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class NetworkClientStartSystem : PugSimulationSystemBase
{
	private class LocalMod
	{
		public string name;

		public long modId;

		public Unity.Entities.Hash128 modGuid;

		public bool required;

		public bool handledByUserPrompt;
	}

	private class ModCheck
	{
		public enum ModCheckStatus
		{
			None = 0,
			Pending = 1,
			WaitingForUser = 2,
			Done = 3
		}

		public ModCheckStatus status;

		public string modName;

		public long modId;

		public Unity.Entities.Hash128 modGuid;
	}

	private struct NetworkClientStartSystem_33002849_LambdaJob_0_Job : IJobChunk
	{
		public NetworkClientStartSystem __this;

		public EntityCommandBuffer commandBuffer;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ModInfoRPC> __modInfoTypeHandle;

		private void OriginalLambdaBody(Entity entity, in ModInfoRPC modInfo)
		{
			commandBuffer.DestroyEntity(entity);
			if (modInfo.modId == 0L)
			{
				__this.allModsReceived = true;
				return;
			}
			bool flag = false;
			for (int num = __this.localMods.Count - 1; num >= 0; num--)
			{
				if ((__this.localMods[num].modId != 0L && __this.localMods[num].modId == modInfo.modId) || (__this.localMods[num].modGuid.IsValid && __this.localMods[num].modGuid == modInfo.modGuid))
				{
					__this.localMods.RemoveAt(num);
					flag = true;
				}
			}
			if (modInfo.required && !flag)
			{
				__this.modsToCheck.Add(new ModCheck
				{
					modId = modInfo.modId,
					modName = modInfo.modName.Value,
					modGuid = modInfo.modGuid
				});
			}
			__this.allModsReceived = modInfo.lastMod;
			if (__this.allModsReceived)
			{
				Debug.Log("got all mod infos from server");
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __modInfoTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ModInfoRPC>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ModInfoRPC>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ModInfoRPC>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ModInfoRPC>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<NetworkClientStartSystem_33002849_LambdaJob_0_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct NetworkClientStartSystem_33002849_LambdaJob_1_Job
	{
		public NetworkClientStartSystem __this;

		public bool isInGame;

		public EntityCommandBuffer commandBuffer;

		private void OriginalLambdaBody(Entity reqEnt, in PlayerConnectResponseRPC answer, in ReceiveRpcCommandRequest reqSrc)
		{
			commandBuffer.DestroyEntity(reqEnt);
			if (answer.rejected)
			{
				Debug.Log("Server rejected connection with reason " + answer.reason.Value);
				__this.Disconnect(answer.reason.Value, isInGame);
				return;
			}
			Debug.Log("Connected to server " + answer.serverName.Value + " (" + answer.serverGuid.ToString() + ")");
			if (Manager.networking.currentSessionIsDedicatedServer)
			{
				Manager.prefs.AddOrUpdateServer(answer.serverGuid.ToString(), answer.serverName.Value, Manager.networking.CurrentSession);
			}
			__this.isConnected = true;
			__this.waitForClassicWorldPopUp = answer.worldGenerationType == WorldGenerationType.Classic;
			Manager.networking.serverName = answer.serverName.Value;
			Manager.networking.serverGuid = answer.serverGuid.ToString();
			Manager.networking.serverSessionId = answer.serverSessionId.ToString();
			Manager.networking.serverWorldMode = answer.worldMode;
			Manager.networking.serverHasStreamIntegration = answer.streamIntegrationEnabled;
			Manager.prefs.SetSeason((Season)answer.season);
			__this.waitForMinorVersionMismatchPopup = false;
			__this.hostVersion = answer.serverVersionString.Value;
			Entity e = commandBuffer.CreateEntity();
			commandBuffer.AddComponent(e, new BiomeDirectionCD
			{
				Value = answer.biomeCompassDirections
			});
			Entity e2 = commandBuffer.CreateEntity();
			commandBuffer.AddComponent(e2, new ServerSeedCD
			{
				Value = answer.serverSeed
			});
			Entity e3 = commandBuffer.CreateEntity();
			commandBuffer.AddComponent(e3, new WorldGenerationTypeCD
			{
				Value = answer.worldGenerationType
			});
		}

		public void RunWithStructuralChange(EntityQuery query)
		{
			EntityQueryMask entityQueryMask = query.GetEntityQueryMask();
			InternalCompilerInterface.UnsafeCreateGatherEntitiesResult(ref query, out var result);
			TypeIndex typeIndex = TypeManager.GetTypeIndex<PlayerConnectResponseRPC>();
			TypeIndex typeIndex2 = TypeManager.GetTypeIndex<ReceiveRpcCommandRequest>();
			try
			{
				int entityCount = result.EntityCount;
				for (int i = 0; i != entityCount; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetEntityFromGatheredEntities(ref result, i);
					if (entityQueryMask.MatchesIgnoreFilter(entity))
					{
						OriginalLambdaBody(entity, InternalCompilerInterface.GetComponentData<PlayerConnectResponseRPC>(__this.EntityManager, entity, typeIndex, out var _), InternalCompilerInterface.GetComponentData<ReceiveRpcCommandRequest>(__this.EntityManager, entity, typeIndex2, out var _));
					}
				}
			}
			finally
			{
				InternalCompilerInterface.UnsafeReleaseGatheredEntities(ref query, ref result);
			}
		}
	}

	private struct NetworkClientStartSystem_33002849_LambdaJob_2_Job : IJobChunk
	{
		public EntityCommandBuffer commandBuffer;

		[ReadOnly]
		public EntityTypeHandle __entTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<NetworkId> __idTypeHandle;

		private unsafe void OriginalLambdaBody(Entity ent, in NetworkId id)
		{
			Manager.ui.mapUI.LoadMaps();
			UnityEngine.Hash128 characterGuid = Manager.saves.GetCharacterGuid();
			byte[] strippedAndSerializedCharacterData = Manager.saves.GetStrippedAndSerializedCharacterData();
			StartGameRPC component = new StartGameRPC
			{
				playerGuid = characterGuid,
				totalDataSize = (uint)strippedAndSerializedCharacterData.Length
			};
			component.onlineID = Manager.platform.platformImpl.GetPlatformUserID().GetPlatformOnlineId();
			component.platform = (byte)Manager.platform.Platform;
			int num = strippedAndSerializedCharacterData.Length;
			int num2 = 0;
			fixed (byte* ptr = strippedAndSerializedCharacterData)
			{
				while (num > 0)
				{
					int num3 = math.min(component.dataPart.Size, num);
					UnsafeUtility.MemCpy(component.dataPart.GetUnsafePtr(), ptr + num2, num3);
					component.dataPartSize = (uint)num3;
					component.dataPartStart = (uint)num2;
					Entity e = commandBuffer.CreateEntity();
					commandBuffer.AddComponent<SendRpcCommandRequest>(e);
					commandBuffer.AddComponent(e, component);
					num2 += num3;
					num -= num3;
				}
			}
			commandBuffer.AddComponent<NetworkStreamInGame>(ent);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __idTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkId>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkId>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkId>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkId>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<NetworkClientStartSystem_33002849_LambdaJob_2_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ModInfoRPC> __ModInfoRPC_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerConnectResponseRPC> __PlayerConnectResponseRPC_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<NetworkId> __Unity_NetCode_NetworkId_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__ModInfoRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ModInfoRPC>(isReadOnly: true);
			__PlayerConnectResponseRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerConnectResponseRPC>(isReadOnly: true);
			__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
			__Unity_NetCode_NetworkId_RO_ComponentTypeHandle = state.GetComponentTypeHandle<NetworkId>(isReadOnly: true);
		}
	}

	private const string StartingAClassicWorldUpdateTerm = "startingAClassicWorldUpdate";

	private const string MinorVersionMismatchTerm = "Menu/VersionsAreCompatibleButNotSameWarning";

	private const string ClientVersionTerm = "Menu/YourVersionIs";

	private const string HostVersionTerm = "Menu/HostVersionIs";

	private bool isConnected;

	private bool waitForMinorVersionMismatchPopup;

	private string hostVersion;

	private bool waitForClassicWorldPopUp;

	private List<LocalMod> localMods = new List<LocalMod>();

	private List<ModCheck> modsToCheck = new List<ModCheck>();

	private bool allModsReceived;

	private bool restartNeeded;

	private bool cancel;

	private bool displayingMessage;

	private bool hasSentConnectRequest;

	private bool hasSentModRequest;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_569364698_0;

	private EntityQuery __query_569364698_1;

	private EntityQuery __query_569364698_2;

	private EntityQuery __query_569364698_3;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		RequireForUpdate<NetworkId>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		bool isInGame = Manager.sceneHandler.isInGame;
		UpdateModChecks();
		if (cancel)
		{
			Disconnect("Error/Canceled", isInGame);
			base.OnUpdate();
			return;
		}
		EntityCommandBuffer commandBuffer = CreateCommandBuffer();
		if (!hasSentModRequest)
		{
			Debug.Log("send mod info request");
			hasSentModRequest = true;
			modsToCheck.Clear();
			foreach (LoadedMod loadedMod in Integration.Instance.LoadedMods)
			{
				localMods.Add(new LocalMod
				{
					modId = loadedMod.ModId,
					modGuid = ((loadedMod.Metadata.guid != null) ? new Unity.Entities.Hash128(loadedMod.Metadata.guid) : default(Unity.Entities.Hash128)),
					name = loadedMod.Metadata.name,
					required = ((loadedMod.Metadata.requiredOn & ModMetadata.ModExistsOn.Server) != 0)
				});
			}
			EntityArchetype archetype = base.EntityManager.CreateArchetype(typeof(ModInfoRequestRPC), typeof(SendRpcCommandRequest));
			base.EntityManager.CreateEntity(archetype);
		}
		NetworkClientStartSystem_33002849_LambdaJob_0_Execute(ref commandBuffer);
		if (!allModsReceived || modsToCheck.Count > 0)
		{
			base.OnUpdate();
			return;
		}
		if (localMods.Count > 0)
		{
			for (int num = localMods.Count - 1; num >= 0; num--)
			{
				if (!localMods[num].required)
				{
					localMods.RemoveAt(num);
				}
				else
				{
					if (!localMods[num].handledByUserPrompt)
					{
						LocalMod mod = localMods[num];
						bool num2 = mod.modId > 0;
						string message = (num2 ? "Menu/ModMissingServerDialogue" : "Menu/LocalModMissingServerDialogue");
						List<string> options = (num2 ? new List<string> { "cancelDialogue", "yes" } : new List<string> { "cancelDialogue" });
						DisplayMismatchedModsMessage(message, options, mod.name, delegate(bool unsubscribe)
						{
							mod.handledByUserPrompt = true;
							if (restartNeeded || unsubscribe)
							{
								restartNeeded = true;
							}
							else
							{
								cancel = true;
							}
							if (unsubscribe)
							{
								ModIOUnity.DisableMod(new ModId(mod.modId));
							}
						});
						break;
					}
					localMods.RemoveAt(num);
				}
			}
			base.OnUpdate();
			return;
		}
		if (restartNeeded)
		{
			Manager.mod.CheckForModChanges(restartIfNeeded: true, forceRestart: true);
			base.Enabled = false;
			base.OnUpdate();
			return;
		}
		if (!hasSentConnectRequest)
		{
			if (!Manager.ecs.TryCalculateGhostCollectionHash(out (ulong, ulong) result))
			{
				base.OnUpdate();
				return;
			}
			hasSentConnectRequest = true;
			ulong item = result.Item2;
			var (num3, _) = result;
			Debug.Log($"send connect with hash {num3} for {item} ghosts");
			EntityArchetype archetype2 = base.EntityManager.CreateArchetype(typeof(PlayerConnectRequestRPC), typeof(SendRpcCommandRequest));
			Entity entity = base.EntityManager.CreateEntity(archetype2);
			PlayerConnectRequestRPC componentData = new PlayerConnectRequestRPC
			{
				isOwner = (Manager.ecs.ServerWorld != null),
				ghostCollectionHash = num3
			};
			componentData.SetVersion(Manager.version, Manager.minorVersion);
			componentData.platform = (byte)Manager.platform.Platform;
			componentData.allowCrossPlay = Manager.platform.parentalControlManager.AllowCrossPlay(showUI: false);
			base.EntityManager.SetComponentData(entity, componentData);
		}
		NetworkClientStartSystem_33002849_LambdaJob_1_Execute(ref isInGame, ref commandBuffer);
		if (!isConnected)
		{
			base.OnUpdate();
			return;
		}
		Manager.networking.isConnected = isConnected;
		if (!isInGame)
		{
			return;
		}
		if (waitForClassicWorldPopUp)
		{
			RadicalMenu topMenu = Manager.menu.GetTopMenu();
			if (topMenu == null || !(topMenu is RadicalPopUpMenu))
			{
				Manager.menu.centerPopUpText.StartNewDisplaySequence("startingAClassicWorldUpdate", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
				{
					waitForClassicWorldPopUp = false;
				}, new List<string> { "ok" }, 10f, 0.8f, 0, 20f);
			}
			base.OnUpdate();
		}
		else if (waitForMinorVersionMismatchPopup)
		{
			string arg = Manager.version + Manager.minorVersion;
			string text = string.Format(LocalizationManager.GetTranslation("Menu/YourVersionIs"), arg) + "\n" + string.Format(LocalizationManager.GetTranslation("Menu/HostVersionIs"), hostVersion, hostVersion) + "\n" + LocalizationManager.GetTranslation("Menu/VersionsAreCompatibleButNotSameWarning");
			RadicalMenu topMenu2 = Manager.menu.GetTopMenu();
			if (topMenu2 == null || !(topMenu2 is RadicalPopUpMenu))
			{
				Manager.menu.centerPopUpText.StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: false, TextManager.FontFace.boldMedium, delegate
				{
					waitForMinorVersionMismatchPopup = false;
				}, new List<string> { "ok" }, 10f, 0.8f, 0, 20f);
			}
			base.OnUpdate();
		}
		else
		{
			NetworkClientStartSystem_33002849_LambdaJob_2_Execute(ref commandBuffer);
			base.OnUpdate();
		}
	}

	private void UpdateModChecks()
	{
		int num = modsToCheck.Count - 1;
		while (num >= 0)
		{
			ModCheck mod = modsToCheck[num];
			switch (mod.status)
			{
			case ModCheck.ModCheckStatus.None:
				mod.status = ModCheck.ModCheckStatus.Pending;
				if (mod.modId > 0)
				{
					ModIOUnity.GetMod(new ModId(mod.modId), delegate(ResultAnd<ModProfile> result)
					{
						string modName;
						if (!result.result.Succeeded())
						{
							Debug.LogError($"Failed to fetch mod {mod.modId}: {result.result.message}");
							modName = "Unknown";
						}
						else
						{
							modName = result.value.name;
						}
						Callback(mod.modId, mod.modGuid, modName);
					});
				}
				else
				{
					Callback(mod.modId, mod.modGuid, mod.modName);
				}
				break;
			case ModCheck.ModCheckStatus.Done:
				modsToCheck.RemoveAt(num);
				break;
			}
			num--;
			void Callback(long modId, Unity.Entities.Hash128 modGuid, string modName)
			{
				bool flag = false;
				foreach (LoadedMod loadedMod in Integration.Instance.LoadedMods)
				{
					if ((loadedMod.ModId != 0L && loadedMod.ModId == modId) || (modGuid.IsValid && new Unity.Entities.Hash128(loadedMod.Metadata.guid) == modGuid))
					{
						if (string.IsNullOrEmpty(modName))
						{
							modName = loadedMod.Metadata.name;
						}
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					mod.status = ModCheck.ModCheckStatus.WaitingForUser;
					bool num2 = mod.modId > 0;
					string message = (num2 ? "Menu/ModMissingClientDialogue" : "Menu/LocalModMissingClientDialogue");
					List<string> options = (num2 ? new List<string> { "cancelDialogue", "yes" } : new List<string> { "cancelDialogue" });
					if (!DisplayMismatchedModsMessage(message, options, modName, delegate(bool subscribe)
					{
						mod.status = ModCheck.ModCheckStatus.Done;
						if (subscribe)
						{
							ModIOUnity.SubscribeToMod(new ModId(modId), delegate(Result subscribeResult)
							{
								if (!subscribeResult.Succeeded())
								{
									Debug.LogError($"Failed to subscribe to mod {modId}");
								}
								else
								{
									Debug.Log($"Subscribed to mod {modId}");
								}
							});
						}
					}))
					{
						mod.status = ModCheck.ModCheckStatus.None;
					}
				}
				else
				{
					mod.status = ModCheck.ModCheckStatus.Done;
				}
			}
		}
	}

	private bool DisplayMismatchedModsMessage(string message, List<string> options, string modName, Action<bool> callback)
	{
		if (displayingMessage)
		{
			return false;
		}
		displayingMessage = true;
		Manager.menu.centerPopUpText.StartNewDisplaySequence(message, new string[1] { modName }, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
		{
			displayingMessage = false;
			if (restartNeeded || response.IsConfirm)
			{
				restartNeeded = true;
			}
			else
			{
				cancel = true;
			}
			callback?.Invoke(response.IsConfirm);
		}, options, 10f, 0.8f, 0, 20f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false);
		return true;
	}

	private void Disconnect(string error, bool isInGame)
	{
		if (error == "Consoles/MissingPrivilegeReason")
		{
			Manager.platform.parentalControlManager.AllowCrossPlay(showUI: true);
		}
		Manager.networking.connectionFailedReason = error;
		Manager.networking.connectionFailed = true;
		base.Enabled = false;
		if (isInGame && __query_569364698_3.TryGetSingletonEntity<NetworkStreamConnection>(out var value))
		{
			base.World.EntityManager.AddComponentData(value, new NetworkStreamRequestDisconnect
			{
				Reason = NetworkStreamDisconnectReason.ClosedByRemote
			});
		}
	}

	private void NetworkClientStartSystem_33002849_LambdaJob_0_Execute(ref EntityCommandBuffer commandBuffer)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ModInfoRPC_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		NetworkClientStartSystem_33002849_LambdaJob_0_Job value = new NetworkClientStartSystem_33002849_LambdaJob_0_Job
		{
			__this = this,
			commandBuffer = commandBuffer,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__modInfoTypeHandle = __TypeHandle.__ModInfoRPC_RO_ComponentTypeHandle
		};
		if (!__query_569364698_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			NetworkClientStartSystem_33002849_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_569364698_0, jobPtr);
		}
		commandBuffer = value.commandBuffer;
	}

	private void NetworkClientStartSystem_33002849_LambdaJob_1_Execute(ref bool isInGame, ref EntityCommandBuffer commandBuffer)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerConnectResponseRPC_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		NetworkClientStartSystem_33002849_LambdaJob_1_Job networkClientStartSystem_33002849_LambdaJob_1_Job = new NetworkClientStartSystem_33002849_LambdaJob_1_Job
		{
			__this = this,
			isInGame = isInGame,
			commandBuffer = commandBuffer
		};
		if (!__query_569364698_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			networkClientStartSystem_33002849_LambdaJob_1_Job.RunWithStructuralChange(__query_569364698_1);
		}
		isInGame = networkClientStartSystem_33002849_LambdaJob_1_Job.isInGame;
		commandBuffer = networkClientStartSystem_33002849_LambdaJob_1_Job.commandBuffer;
	}

	private void NetworkClientStartSystem_33002849_LambdaJob_2_Execute(ref EntityCommandBuffer commandBuffer)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		NetworkClientStartSystem_33002849_LambdaJob_2_Job value = new NetworkClientStartSystem_33002849_LambdaJob_2_Job
		{
			commandBuffer = commandBuffer,
			__entTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__idTypeHandle = __TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentTypeHandle
		};
		if (!__query_569364698_2.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			NetworkClientStartSystem_33002849_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_569364698_2, jobPtr);
		}
		commandBuffer = value.commandBuffer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ModInfoRPC>();
		__query_569364698_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerConnectResponseRPC>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_569364698_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<NetworkStreamInGame>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkId>();
		__query_569364698_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkStreamConnection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_569364698_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public NetworkClientStartSystem()
	{
	}
}
