using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using PlayerState;
using Pug.UnityExtensions;
using PugMod;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeginSimulationSystemGroup))]
[UpdateAfter(typeof(PlayerConnectRequestSystem))]
public class StartGameRPCSystem : PugSimulationSystemBase
{
	private class CharacterDataEntry
	{
		public byte[] data;
	}

	private struct ConnectedPlayerData
	{
		public Entity playerEntity;

		public Entity playerPrefabEntity;

		public CharacterData characterData;

		public bool playerWasLastConnectedToThisServer;

		public Entity playerConnection;
	}

	[NoAlias]
	[BurstCompile]
	private struct StartGameRPCSystem_2FE3D5A9_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00002652_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00002652_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00002652_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public NativeList<Entity> playerEntities;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity)
		{
			playerEntities.Add(in entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00002652_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00002652_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<StartGameRPCSystem_2FE3D5A9_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct StartGameRPCSystem_2FE3D5A9_LambdaJob_1_Job : IJobChunk
	{
		public StartGameRPCSystem __this;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __reqEntTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StartGameRPC> __reqTypeHandle;

		private void OriginalLambdaBody(Entity reqEnt, in StartGameRPC req)
		{
			ecb.DestroyEntity(reqEnt);
			if (req.dataPartStart == 0)
			{
				if (__this.characterDataMap.ContainsKey(req.playerGuid))
				{
					Debug.LogWarning("reset unfinished start game rpc");
					__this.characterDataMap.Remove(req.playerGuid);
				}
				if (req.totalDataSize <= 4194304)
				{
					CharacterDataEntry value = new CharacterDataEntry
					{
						data = new byte[req.totalDataSize]
					};
					__this.characterDataMap.Add(req.playerGuid, value);
				}
				else
				{
					Debug.LogError("got invalid first start game rpc");
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __reqEntTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __reqTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<StartGameRPCSystem_2FE3D5A9_LambdaJob_1_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct StartGameRPCSystem_2FE3D5A9_LambdaJob_2_Job : IJobChunk
	{
		public StartGameRPCSystem __this;

		public ComponentTypeHandle<StartGameRPC> __reqTypeHandle;

		private unsafe void OriginalLambdaBody(ref StartGameRPC req)
		{
			if (!__this.characterDataMap.ContainsKey(req.playerGuid))
			{
				return;
			}
			CharacterDataEntry characterDataEntry = __this.characterDataMap[req.playerGuid];
			if (req.totalDataSize != characterDataEntry.data.Length || req.dataPartStart + req.dataPartSize > characterDataEntry.data.Length)
			{
				Debug.LogError("got invalid start game rpc");
				return;
			}
			fixed (byte* data = characterDataEntry.data)
			{
				UnsafeUtility.MemCpy(data + req.dataPartStart, req.dataPart.GetUnsafePtr(), req.dataPartSize);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __reqTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, i));
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
						OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, j));
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
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<StartGameRPCSystem_2FE3D5A9_LambdaJob_2_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct StartGameRPCSystem_2FE3D5A9_LambdaJob_3_Job : IJobChunk
	{
		public StartGameRPCSystem __this;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public ComponentLookup<NetworkId> networkIdLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public NativeList<bool> connectedPlayersLocal;

		public ConditionsTableCD conditionsTable;

		public NetworkTick currentTick;

		public uint tickRate;

		public double elapsedSeconds;

		public NativeList<Entity> playerEntities;

		public int maxSnapShotSize;

		public int snapshotTargetSize;

		[ReadOnly]
		public ComponentLookup<PlayerLastSessionCD> playerLastSessionLookup;

		public Unity.Entities.Hash128 serverSessionId;

		public UnityEngine.Hash128 localPlayerGuid;

		public float3 playerSpawnPosition;

		[ReadOnly]
		public ComponentTypeHandle<StartGameRPC> __reqTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __reqSrcTypeHandle;

		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_ComponentLookup;

		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_BufferLookup;

		private unsafe void OriginalLambdaBody(in StartGameRPC req, in ReceiveRpcCommandRequest reqSrc)
		{
			if (req.dataPartStart + req.dataPartSize != req.totalDataSize || !__this.characterDataMap.ContainsKey(req.playerGuid))
			{
				return;
			}
			float3 position = playerSpawnPosition;
			Entity entity = Entity.Null;
			Entity prefabEntity = Entity.Null;
			CharacterDataEntry characterDataEntry = __this.characterDataMap[req.playerGuid];
			__this.characterDataMap.Remove(req.playerGuid);
			Debug.Log($"spawning player with character data size {characterDataEntry.data.Length}");
			CharacterData characterDataFromSerialized = SaveManager.GetCharacterDataFromSerialized(characterDataEntry.data);
			if (characterDataFromSerialized == null)
			{
				Debug.LogError("characterData deserialization failed");
				ecb.AddComponent<NetworkStreamRequestDisconnect>(reqSrc.SourceConnection);
				return;
			}
			for (int i = 0; i < playerEntities.Length; i++)
			{
				if (!(playerGhostLookup[playerEntities[i]].playerGuid == req.playerGuid))
				{
					continue;
				}
				entity = playerEntities[i];
				if (!__Unity_Entities_Disabled_ComponentLookup.HasComponent(entity))
				{
					PlayerGhost playerGhost = __PlayerGhost_ComponentLookup[playerEntities[i]];
					ecb.AddComponent<NetworkStreamRequestDisconnect>(playerGhost.connection);
					ecb.AddComponent<NetworkStreamRequestDisconnect>(reqSrc.SourceConnection);
					Debug.Log("New connection uses same character as current connection; disconnecting both");
					return;
				}
				ecb.RemoveComponent<Disabled>(entity);
				LocalTransform component = __Unity_Transforms_LocalTransform_ComponentLookup[entity];
				component.Position.y = 0f;
				ecb.SetComponent(entity, component);
				position = component.Position;
				if (__PlayerState_PlayerStateCD_ComponentLookup[entity].HasAnyState(PlayerStateEnum.SpawningFromCore))
				{
					ecb.SetComponent(entity, default(PlayerStateCD));
				}
				Debug.Log("Enabling player entity");
				break;
			}
			bool flag = entity != Entity.Null;
			if (entity == Entity.Null)
			{
				Debug.Log("Creating new player entity");
				entity = EntityUtility.CreateEntity(ecb, position, ObjectID.Player, 1, databaseLocal, out prefabEntity);
			}
			int j;
			for (j = 0; j < connectedPlayersLocal.Length; j++)
			{
				if (!connectedPlayersLocal[j])
				{
					connectedPlayersLocal[j] = true;
					break;
				}
			}
			if (j == connectedPlayersLocal.Length)
			{
				connectedPlayersLocal.Add(true);
			}
			bool flag2 = localPlayerGuid != default(UnityEngine.Hash128) && req.playerGuid.Equals(localPlayerGuid);
			Manager.networking.OnPlayerConnect(characterDataFromSerialized.CharacterCustomization.name.ToString(), reqSrc.SourceConnection, __this.World, flag2);
			int adminPrivileges = Manager.networking.GetAdminPrivileges(reqSrc.SourceConnection, __this.World, req.onlineID);
			Unity.Entities.Hash128 hash = (flag ? playerLastSessionLookup[entity].Value : default(Unity.Entities.Hash128));
			bool playerWasLastConnectedToThisServer = hash.IsValid && characterDataFromSerialized.lastActiveSession == hash;
			Entity entity2 = ecb.CreateEntity(__this.playerGhostExtrapolatedArchetype);
			ecb.SetComponent(entity2, LocalTransform.FromPosition(position));
			ecb.SetComponent(entity2, new PlayerGhostExtrapolated
			{
				playerGhost = entity
			});
			ecb.SetComponent(entity, new PlayerGhost
			{
				connection = reqSrc.SourceConnection,
				playerGuid = req.playerGuid,
				playerGhostExtrapolated = entity2,
				playerIndex = j + 1,
				adminPrivileges = adminPrivileges,
				cameraPosition = position.ToFloat2(),
				onlineId = req.onlineID,
				onlineName = req.onlineName,
				platform = req.platform
			});
			PlayerCustomization characterCustomization = characterDataFromSerialized.CharacterCustomization;
			ecb.SetComponent(entity, new PlayerCustomizationCD
			{
				customization = PlayerCustomizationNetcode.ConvertFromAddress(characterCustomization)
			});
			PlayerLastSessionCD component2 = new PlayerLastSessionCD
			{
				Value = serverSessionId
			};
			ecb.SetComponent(entity, component2);
			ecb.AddComponent(reqSrc.SourceConnection, new ConnectionAdminLevelCD
			{
				adminPrivileges = adminPrivileges,
				onlineId = req.onlineID
			});
			ecb.AddComponent(reqSrc.SourceConnection, new PlayerConnectionCleanupCD
			{
				playerEntity = entity
			});
			DynamicBuffer<SkillBuffer> dynamicBuffer = ecb.SetBuffer<SkillBuffer>(entity);
			dynamicBuffer.Resize(12, NativeArrayOptions.ClearMemory);
			DynamicBuffer<SkillConditionsBuffer> dynamicBuffer2 = ecb.SetBuffer<SkillConditionsBuffer>(entity);
			for (int k = 0; k < characterDataFromSerialized.skills.Count; k++)
			{
				SkillData skillData = characterDataFromSerialized.skills[k];
				dynamicBuffer[(int)skillData.skillID] = new SkillBuffer
				{
					Value = skillData.value
				};
				ConditionData conditionDataForSkill = SkillExtensions.GetConditionDataForSkill(skillData.skillID, skillData.value);
				dynamicBuffer2.Add(new SkillConditionsBuffer
				{
					conditionData = conditionDataForSkill
				});
			}
			DynamicBuffer<SkillTalentConditionsBuffer> dynamicBuffer3 = ecb.SetBuffer<SkillTalentConditionsBuffer>(entity);
			for (int l = 0; l < characterDataFromSerialized.skillTalentTreeDatas.Count; l++)
			{
				SkillTalentTreeData skillTalentTreeData = characterDataFromSerialized.skillTalentTreeDatas[l];
				for (int m = 0; m < skillTalentTreeData.points.Count; m++)
				{
					ConditionData conditionDataForSkillTalent = Manager.mod.SkillTalentsTable.GetConditionDataForSkillTalent(skillTalentTreeData.skillTreeID, m, skillTalentTreeData.points[m]);
					dynamicBuffer3.Add(new SkillTalentConditionsBuffer
					{
						conditionData = conditionDataForSkillTalent
					});
				}
			}
			DynamicBuffer<CollectedSoulsBuffer> dynamicBuffer4 = ecb.SetBuffer<CollectedSoulsBuffer>(entity);
			DynamicBuffer<SoulsConditionsBuffer> dynamicBuffer5 = ecb.SetBuffer<SoulsConditionsBuffer>(entity);
			ecb.SetComponent(entity, new SoulsInfoCD
			{
				hasUnlockedSouls = characterDataFromSerialized.hasUnlockedSouls
			});
			for (int n = 0; n < characterDataFromSerialized.collectedSouls.Count; n++)
			{
				SoulID soulID = characterDataFromSerialized.collectedSouls[n];
				dynamicBuffer4.Add(new CollectedSoulsBuffer
				{
					soulId = soulID
				});
				ConditionData soulConditionData = SoulsExtensions.GetSoulConditionData(soulID);
				dynamicBuffer5.Add(new SoulsConditionsBuffer
				{
					conditionData = soulConditionData,
					soulID = soulID
				});
			}
			DynamicBuffer<ConditionsBuffer> conditionsBuffer = ecb.SetBuffer<ConditionsBuffer>(entity);
			for (int num = 0; num < characterDataFromSerialized.conditionsList.Count; num++)
			{
				ConditionSerialized c = characterDataFromSerialized.conditionsList[num];
				if (c.Value != 0)
				{
					Condition condition = c.ToCondition(currentTick, tickRate);
					if (condition.conditionData.conditionID != ConditionID.HealOverTimePercentage || condition.conditionData.duration != 0f)
					{
						conditionsBuffer.Add(new ConditionsBuffer
						{
							condition = condition
						});
					}
				}
			}
			Entity entity3 = ((prefabEntity != Entity.Null) ? prefabEntity : entity);
			int length = __ContainedObjectsBuffer_BufferLookup[entity3].Length;
			DynamicBuffer<LockedObjectsBuffer> dynamicBuffer6 = ecb.SetBuffer<LockedObjectsBuffer>(entity);
			for (int num2 = 0; num2 < length; num2++)
			{
				bool value = characterDataFromSerialized.lockedObjects.Count > num2 && characterDataFromSerialized.lockedObjects[num2];
				dynamicBuffer6.Add(new LockedObjectsBuffer
				{
					Value = value
				});
			}
			if (!req.isThinClient)
			{
				EntityUtility.AddOrRefreshConditionOverrideStacks(new ConditionData
				{
					conditionID = ConditionID.ImmuneToDamageAfterLogin,
					value = 1
				}, conditionsBuffer, conditionsTable, currentTick, tickRate);
			}
			ecb.SetComponent(entity, new CharacterTypeCD
			{
				characterType = characterDataFromSerialized.characterType
			});
			ecb.SetComponent(entity, new CoinAmountCD
			{
				Value = characterDataFromSerialized.coinAmount
			});
			ecb.SetComponent(entity, new RandomCD
			{
				Value = new Unity.Mathematics.Random((uint)((int)elapsedSeconds ^ req.playerGuid.GetHashCode()))
			});
			ecb.SetComponent(entity, new PlayerSpawnCD
			{
				lastRespawnTick = currentTick
			});
			ecb.SetComponent(entity, new GhostOwner
			{
				NetworkId = networkIdLookup[reqSrc.SourceConnection].Value
			});
			ecb.AddComponent<NetworkStreamInGame>(reqSrc.SourceConnection);
			if (flag2)
			{
				ecb.AddComponent(reqSrc.SourceConnection, new NetworkStreamSnapshotTargetSize
				{
					Value = maxSnapShotSize
				});
			}
			else if (snapshotTargetSize > 1200)
			{
				ecb.AddComponent(reqSrc.SourceConnection, new NetworkStreamSnapshotTargetSize
				{
					Value = snapshotTargetSize
				});
			}
			ecb.SetComponent(reqSrc.SourceConnection, new CommandTarget
			{
				targetEntity = entity
			});
			FixedString32Bytes name = characterDataFromSerialized.CharacterCustomization.name;
			if (name.Length > 0)
			{
				Entity e = ecb.CreateEntity(__this.connectEventRpcArchetype);
				int messageNumber = UnityEngine.Random.Range(int.MinValue, 0);
				NetworkCommDataMessageRPC component3 = new NetworkCommDataMessageRPC
				{
					messageNumber = messageNumber
				};
				UnsafeUtility.MemCpy(component3.messagePart.GetUnsafePtr(), name.GetUnsafePtr(), name.Length);
				ecb.SetComponent(e, component3);
				ecb.SetComponent(e, new NetworkCommMessageRPC
				{
					messageNumber = messageNumber,
					messageType = NetworkCommMessageType.PlayerConnected,
					totalSize = name.Length,
					platform = (byte)Manager.platform.Platform,
					platformID = Manager.platform.platformImpl.GetPlatformUserID().GetPlatformOnlineId()
				});
				ecb.SetComponent(e, reqSrc);
			}
			__this.connectedPlayerDataList.Add(new ConnectedPlayerData
			{
				playerEntity = entity,
				playerPrefabEntity = prefabEntity,
				characterData = characterDataFromSerialized,
				playerWasLastConnectedToThisServer = playerWasLastConnectedToThisServer,
				playerConnection = reqSrc.SourceConnection
			});
			Debug.Log("Started game for new connection");
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __reqTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __reqSrcTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StartGameRPC>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<StartGameRPCSystem_2FE3D5A9_LambdaJob_3_Job>(jobPtr), ref query);
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
		public ComponentTypeHandle<StartGameRPC> __StartGameRPC_RO_ComponentTypeHandle;

		public ComponentTypeHandle<StartGameRPC> __StartGameRPC_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentLookup;

		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<NetworkId> __Unity_NetCode_NetworkId_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerLastSessionCD> __PlayerLastSessionCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StartGameRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StartGameRPC>(isReadOnly: true);
			__StartGameRPC_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StartGameRPC>();
			__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
			__Unity_Entities_Disabled_RO_ComponentLookup = state.GetComponentLookup<Disabled>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__PlayerState_PlayerStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RW_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>();
			__Unity_NetCode_NetworkId_RO_ComponentLookup = state.GetComponentLookup<NetworkId>(isReadOnly: true);
			__PlayerLastSessionCD_RO_ComponentLookup = state.GetComponentLookup<PlayerLastSessionCD>(isReadOnly: true);
		}
	}

	public NativeList<bool> connectedPlayers;

	private Dictionary<Unity.Entities.Hash128, CharacterDataEntry> characterDataMap;

	private List<ConnectedPlayerData> connectedPlayerDataList;

	private EntityArchetype playerGhostExtrapolatedArchetype;

	private EntityArchetype connectEventRpcArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2146878412_0;

	private EntityQuery __query_2146878412_1;

	private EntityQuery __query_2146878412_2;

	private EntityQuery __query_2146878412_3;

	private EntityQuery __query_2146878412_4;

	private EntityQuery __query_2146878412_5;

	private EntityQuery __query_2146878412_6;

	private EntityQuery __query_2146878412_7;

	private EntityQuery __query_2146878412_8;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedDatabase();
		RequireForUpdate<ServerSeedCD>();
		RequireForUpdate<ServerSessionIdCD>();
		RequireForUpdate<ConditionsTableCD>();
		RequireForUpdate<StartGameRPC>();
		RequireForUpdate(__query_2146878412_3);
		characterDataMap = new Dictionary<Unity.Entities.Hash128, CharacterDataEntry>();
		connectedPlayerDataList = new List<ConnectedPlayerData>();
		connectedPlayers = new NativeList<bool>(64, Allocator.Persistent);
		playerGhostExtrapolatedArchetype = base.EntityManager.CreateArchetype(typeof(LocalTransform), typeof(PlayerGhostExtrapolated));
		connectEventRpcArchetype = base.EntityManager.CreateArchetype(typeof(NetworkCommMessageRPC), typeof(NetworkCommDataMessageRPC), typeof(ReceiveRpcCommandRequest));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		connectedPlayers.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		InventoryAuxDataSystemDataCD singleton = __query_2146878412_4.GetSingleton<InventoryAuxDataSystemDataCD>();
		EntityCommandBuffer ecb = CreateCommandBuffer();
		ComponentLookup<NetworkId> networkIdLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<PlayerGhost> playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref base.CheckedStateRef);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		NativeList<bool> connectedPlayersLocal = connectedPlayers;
		ConditionsTableCD conditionsTable = __query_2146878412_5.GetSingleton<ConditionsTableCD>();
		__query_2146878412_6.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		if (!__query_2146878412_7.TryGetSingleton<ClientServerTickRate>(out var value2))
		{
			value2.ResolveDefaults();
		}
		uint tickRate = (uint)value2.SimulationTickRate;
		double elapsedSeconds = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		bool num = Manager.sceneHandler != null && Manager.sceneHandler.isInGame;
		NativeList<Entity> playerEntities = new NativeList<Entity>(64, Allocator.Temp);
		int maxSnapShotSize = 9440;
		int x = Manager.prefs.serverMaxNumberOfPacketsSentPerFrame * 1200;
		ComponentLookup<PlayerLastSessionCD> playerLastSessionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerLastSessionCD_RO_ComponentLookup, ref base.CheckedStateRef);
		Unity.Entities.Hash128 serverSessionId = __query_2146878412_8.GetSingleton<ServerSessionIdCD>().Value;
		x = math.min(x, maxSnapShotSize);
		UnityEngine.Hash128 localPlayerGuid = (num ? Manager.saves.GetCharacterGuid() : default(UnityEngine.Hash128));
		StartGameRPCSystem_2FE3D5A9_LambdaJob_0_Execute(ref playerEntities);
		StartGameRPCSystem_2FE3D5A9_LambdaJob_1_Execute(ref ecb);
		StartGameRPCSystem_2FE3D5A9_LambdaJob_2_Execute();
		float3 playerSpawnPosition = PlayerControllerBurstableStatics.PLAYER_SPAWN_POSITION;
		StartGameRPCSystem_2FE3D5A9_LambdaJob_3_Execute(ref ecb, ref networkIdLookup, ref playerGhostLookup, ref databaseLocal, ref connectedPlayersLocal, ref conditionsTable, ref currentTick, ref tickRate, ref elapsedSeconds, ref playerEntities, ref maxSnapShotSize, ref x, ref playerLastSessionLookup, ref serverSessionId, ref localPlayerGuid, ref playerSpawnPosition);
		foreach (ConnectedPlayerData connectedPlayerData in connectedPlayerDataList)
		{
			if (connectedPlayerData.playerWasLastConnectedToThisServer)
			{
				Debug.Log("Skipping load inventory by PlayerWasLastConnectedToThisServer");
				continue;
			}
			Entity playerEntity = connectedPlayerData.playerEntity;
			Entity playerPrefabEntity = connectedPlayerData.playerPrefabEntity;
			CharacterData characterData = connectedPlayerData.characterData;
			int num2 = ((!(playerPrefabEntity != Entity.Null)) ? base.EntityManager.GetBuffer<ContainedObjectsBuffer>(playerEntity).Length : base.EntityManager.GetBuffer<ContainedObjectsBuffer>(playerPrefabEntity).Length);
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = ecb.SetBuffer<ContainedObjectsBuffer>(playerEntity);
			for (int i = 0; i < num2; i++)
			{
				if (characterData.inventoryObjectNames.Count > i && characterData.inventory.Count > i && characterData.inventory[i].objectID >= (ObjectID)32767 && !string.IsNullOrEmpty(characterData.inventoryObjectNames[i]))
				{
					ObjectID objectID = API.Authoring.GetObjectID(characterData.inventoryObjectNames[i]);
					if (objectID != ObjectID.None && characterData.inventory.Count > i)
					{
						ObjectDataCD value3 = characterData.inventory[i];
						value3.objectID = objectID;
						characterData.inventory[i] = value3;
					}
				}
				ObjectDataCD objectData = ((characterData.inventory.Count > i) ? characterData.inventory[i] : default(ObjectDataCD));
				CharacterInventoryAuxData characterInventoryAuxData = ((characterData.inventoryAuxData.Count > i) ? characterData.inventoryAuxData[i] : default(CharacterInventoryAuxData));
				int auxDataIndex = singleton.SetDataFromJson(base.EntityManager, characterInventoryAuxData.data);
				dynamicBuffer.Add(new ContainedObjectsBuffer
				{
					objectData = objectData,
					auxDataIndex = auxDataIndex
				});
			}
		}
		if (connectedPlayerDataList.Count != 0 && Manager.ecs != null)
		{
			Manager.ecs.QueueNewServerSave();
		}
		connectedPlayerDataList.Clear();
		playerEntities.Dispose();
		base.OnUpdate();
	}

	private void StartGameRPCSystem_2FE3D5A9_LambdaJob_0_Execute(ref NativeList<Entity> playerEntities)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		StartGameRPCSystem_2FE3D5A9_LambdaJob_0_Job value = new StartGameRPCSystem_2FE3D5A9_LambdaJob_0_Job
		{
			playerEntities = playerEntities,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle
		};
		if (!__query_2146878412_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			StartGameRPCSystem_2FE3D5A9_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_2146878412_0, jobPtr);
		}
		playerEntities = value.playerEntities;
	}

	private void StartGameRPCSystem_2FE3D5A9_LambdaJob_1_Execute(ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StartGameRPC_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		StartGameRPCSystem_2FE3D5A9_LambdaJob_1_Job value = new StartGameRPCSystem_2FE3D5A9_LambdaJob_1_Job
		{
			__this = this,
			ecb = ecb,
			__reqEntTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__reqTypeHandle = __TypeHandle.__StartGameRPC_RO_ComponentTypeHandle
		};
		if (!__query_2146878412_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			StartGameRPCSystem_2FE3D5A9_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_2146878412_1, jobPtr);
		}
		ecb = value.ecb;
	}

	private void StartGameRPCSystem_2FE3D5A9_LambdaJob_2_Execute()
	{
		__TypeHandle.__StartGameRPC_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		StartGameRPCSystem_2FE3D5A9_LambdaJob_2_Job value = new StartGameRPCSystem_2FE3D5A9_LambdaJob_2_Job
		{
			__this = this,
			__reqTypeHandle = __TypeHandle.__StartGameRPC_RW_ComponentTypeHandle
		};
		if (!__query_2146878412_2.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			StartGameRPCSystem_2FE3D5A9_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_2146878412_2, jobPtr);
		}
	}

	private void StartGameRPCSystem_2FE3D5A9_LambdaJob_3_Execute(ref EntityCommandBuffer ecb, ref ComponentLookup<NetworkId> networkIdLookup, ref ComponentLookup<PlayerGhost> playerGhostLookup, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref NativeList<bool> connectedPlayersLocal, ref ConditionsTableCD conditionsTable, ref NetworkTick currentTick, ref uint tickRate, ref double elapsedSeconds, ref NativeList<Entity> playerEntities, ref int maxSnapShotSize, ref int snapshotTargetSize, ref ComponentLookup<PlayerLastSessionCD> playerLastSessionLookup, ref Unity.Entities.Hash128 serverSessionId, ref UnityEngine.Hash128 localPlayerGuid, ref float3 playerSpawnPosition)
	{
		__TypeHandle.__StartGameRPC_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGhost_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup.Update(ref base.CheckedStateRef);
		StartGameRPCSystem_2FE3D5A9_LambdaJob_3_Job value = new StartGameRPCSystem_2FE3D5A9_LambdaJob_3_Job
		{
			__this = this,
			ecb = ecb,
			networkIdLookup = networkIdLookup,
			playerGhostLookup = playerGhostLookup,
			databaseLocal = databaseLocal,
			connectedPlayersLocal = connectedPlayersLocal,
			conditionsTable = conditionsTable,
			currentTick = currentTick,
			tickRate = tickRate,
			elapsedSeconds = elapsedSeconds,
			playerEntities = playerEntities,
			maxSnapShotSize = maxSnapShotSize,
			snapshotTargetSize = snapshotTargetSize,
			playerLastSessionLookup = playerLastSessionLookup,
			serverSessionId = serverSessionId,
			localPlayerGuid = localPlayerGuid,
			playerSpawnPosition = playerSpawnPosition,
			__reqTypeHandle = __TypeHandle.__StartGameRPC_RO_ComponentTypeHandle,
			__reqSrcTypeHandle = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle,
			__Unity_Entities_Disabled_ComponentLookup = __TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup,
			__PlayerGhost_ComponentLookup = __TypeHandle.__PlayerGhost_RO_ComponentLookup,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__PlayerState_PlayerStateCD_ComponentLookup = __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup,
			__ContainedObjectsBuffer_BufferLookup = __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup
		};
		if (!__query_2146878412_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			StartGameRPCSystem_2FE3D5A9_LambdaJob_3_Job.RunWithoutJobSystem(ref __query_2146878412_1, jobPtr);
		}
		ecb = value.ecb;
		networkIdLookup = value.networkIdLookup;
		playerGhostLookup = value.playerGhostLookup;
		databaseLocal = value.databaseLocal;
		connectedPlayersLocal = value.connectedPlayersLocal;
		conditionsTable = value.conditionsTable;
		currentTick = value.currentTick;
		tickRate = value.tickRate;
		elapsedSeconds = value.elapsedSeconds;
		playerEntities = value.playerEntities;
		maxSnapShotSize = value.maxSnapShotSize;
		snapshotTargetSize = value.snapshotTargetSize;
		playerLastSessionLookup = value.playerLastSessionLookup;
		serverSessionId = value.serverSessionId;
		localPlayerGuid = value.localPlayerGuid;
		playerSpawnPosition = value.playerSpawnPosition;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_2146878412_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<StartGameRPC>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_2146878412_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StartGameRPC>();
		__query_2146878412_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeCentroidsCD>();
		__query_2146878412_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataSystemDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2146878412_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2146878412_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2146878412_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2146878412_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSessionIdCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2146878412_8 = entityQueryBuilder2.Build(ref state);
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
	public StartGameRPCSystem()
	{
	}
}
