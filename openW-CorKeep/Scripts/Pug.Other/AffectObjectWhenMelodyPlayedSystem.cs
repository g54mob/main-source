using System;
using System.Runtime.CompilerServices;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class AffectObjectWhenMelodyPlayedSystem : PugSimulationSystemBase
{
	private struct AffectObjectWhenMelodyPlayedSystem_6B1B63DB_LambdaJob_0_Job : IJobChunk
	{
		public AffectObjectWhenMelodyPlayedSystem __this;

		[ReadOnly]
		public NativeArray<Entity> playerEntities;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		[ReadOnly]
		public BufferLookup<ItemsToAddToNewObjectBuffer> addItemsBufferLookUp;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedItemsBufferLookUp;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<AffectObjectWhenMelodyPlayedCD> __aCDTypeHandle;

		public BufferTypeHandle<TrackedNotesBuffer> __trackedNotesTypeHandle;

		public BufferTypeHandle<MelodiesBuffer> __melodyBufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __objectDataCDTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClientInput> __ClientInput_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_ComponentLookup;

		private void OriginalLambdaBody(Entity entity, ref AffectObjectWhenMelodyPlayedCD aCD, DynamicBuffer<TrackedNotesBuffer> trackedNotes, DynamicBuffer<MelodiesBuffer> melodyBuffer, in ObjectDataCD objectDataCD)
		{
			if (aCD.melodyID == MelodyID.None && melodyBuffer.Length > 0)
			{
				int index = Unity.Mathematics.Random.CreateFromIndex(PugRandom.GetSeedFromVector(__Unity_Transforms_LocalTransform_ComponentLookup[entity].Position)).NextInt(0, melodyBuffer.Length);
				aCD.melodyID = melodyBuffer[index].melodyID;
			}
			if (!aCD.listening)
			{
				return;
			}
			float hearRange = aCD.hearRange;
			float3 position = __Unity_Transforms_LocalTransform_ComponentLookup[entity].Position;
			aCD.playerHoldingInstrumentExists = false;
			for (int i = 0; i < playerEntities.Length; i++)
			{
				Entity entity2 = playerEntities[i];
				float3 position2 = __Unity_Transforms_LocalTransform_ComponentLookup[entity2].Position;
				float3 y = PugDatabase.GetEntityLocalCenter(objectDataCD.objectID, databaseLocal, objectDataCD.variation) + position;
				if (!(math.distance(position2, y) <= hearRange))
				{
					aCD.humIndex = -1;
					continue;
				}
				Melody obj = MelodyData.melodies[(int)(aCD.melodyID - 1)];
				int[] melody = obj.melody;
				float[] durations = obj.durations;
				float durationMod = obj.durationMod;
				if (aCD.humCooldown > 0f && (!aCD.timer.isRunning || aCD.timer.isTimerElapsed))
				{
					aCD.humIndex = ((aCD.humIndex < melody.Length - 1) ? (aCD.humIndex + 1) : (-1));
					if (aCD.humIndex == -1)
					{
						continue;
					}
					float num = ((aCD.humIndex < durations.Length - 1) ? durations[aCD.humIndex] : 1f);
					num = ((aCD.humIndex < melody.Length - 1) ? (num * durationMod * 0.5f) : aCD.humCooldown);
					aCD.timer.Start(num);
				}
				aCD.playerHoldingInstrumentExists = __PlayerState_PlayerStateCD_ComponentLookup.HasComponent(entity2) && __PlayerState_PlayerStateCD_ComponentLookup[entity2].HasAnyState(PlayerStateEnum.PlayingInstrument);
				if (__ClientInput_ComponentLookup.HasComponent(entity2))
				{
					PlayedNotes playedNotes = new PlayedNotes
					{
						Value = __ClientInput_ComponentLookup[entity2].playedNotes
					};
					bool flag = false;
					bool flag2 = false;
					playedNotes.SetOctave(value: false);
					for (int j = 0; j < trackedNotes.Length; j++)
					{
						if (trackedNotes[j].playerEntity == entity2)
						{
							TrackedNotesBuffer value = trackedNotes[j];
							value.notes = playedNotes.Value;
							if (value.notes != value.prevNotes)
							{
								value.prevNotes = value.notes;
								flag = true;
							}
							trackedNotes[j] = value;
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						trackedNotes.Add(new TrackedNotesBuffer
						{
							playerEntity = entity2,
							notes = playedNotes.Value,
							prevNotes = playedNotes.Value
						});
					}
					if (flag)
					{
						aCD.timer.Start(aCD.humCooldown);
						aCD.humIndex = -1;
						if (playedNotes.Value != 0)
						{
							int key = aCD.scale + melody[aCD.melodyProgress];
							int key2 = melody[aCD.melodyProgress];
							int key3 = melody[aCD.melodyProgress] + 12;
							bool key4 = playedNotes.GetKey(key);
							bool num2 = playedNotes.GetKey(key2) || playedNotes.GetKey(key3);
							int num3 = (int)math.log2(playedNotes.Value);
							bool flag3 = num2 && aCD.melodyProgress == 0;
							aCD.scale = (flag3 ? (num3 - melody[0]) : aCD.scale);
							aCD.melodyProgress = ((key4 || flag3) ? (aCD.melodyProgress + 1) : 0);
						}
					}
				}
				if (aCD.melodyProgress < melody.Length)
				{
					continue;
				}
				aCD.humCooldown = 0f;
				aCD.melodyProgress = 0;
				if (aCD.changeObjectID && aCD.newObjectId != ObjectID.None)
				{
					Entity e;
					if (addItemsBufferLookUp.HasComponent(entity) && containedItemsBufferLookUp.HasComponent(entity))
					{
						DynamicBuffer<ItemsToAddToNewObjectBuffer> dynamicBuffer = addItemsBufferLookUp[entity];
						NativeList<ObjectDataCD> items = new NativeList<ObjectDataCD>(dynamicBuffer.Length, Allocator.Temp);
						for (int k = 0; k < dynamicBuffer.Length; k++)
						{
							ItemsToAddToNewObjectBuffer itemsToAddToNewObjectBuffer = dynamicBuffer[k];
							items.Add(in itemsToAddToNewObjectBuffer.objectData);
						}
						e = EntityUtility.CreateEntityWithItems(ecb, position, aCD.newObjectId, 1, items, databaseLocal, containedItemsBufferLookUp, aCD.newVariation);
						items.Dispose();
					}
					else
					{
						e = EntityUtility.CreateEntity(ecb, position, aCD.newObjectId, 1, databaseLocal, aCD.newVariation);
					}
					if (aCD.tableLoot != LootTableID.Empty)
					{
						ecb.AddComponent(e, new AddRandomLootCD
						{
							lootTableID = aCD.tableLoot
						});
					}
					ecb.DestroyEntity(entity);
				}
				else
				{
					ObjectDataCD component = __ObjectDataCD_ComponentLookup[entity];
					component.variation = aCD.newVariation;
					ecb.SetComponent(entity, component);
					if (__DamageReductionCD_ComponentLookup.HasComponent(entity) && aCD.weakenWhenAffected)
					{
						DamageReductionCD component2 = __DamageReductionCD_ComponentLookup[entity];
						component2.reduction = 0;
						ecb.SetComponent(entity, component2);
					}
				}
				if (aCD.removeMelodyListener)
				{
					ecb.RemoveComponent<AffectObjectWhenMelodyPlayedCD>(entity);
				}
				aCD.listening = false;
				break;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __aCDTypeHandle);
			BufferAccessor<TrackedNotesBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __trackedNotesTypeHandle);
			BufferAccessor<MelodiesBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __melodyBufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataCDTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, i), bufferAccessor[i], bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, j), bufferAccessor[j], bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, k), bufferAccessor[k], bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, l), bufferAccessor[l], bufferAccessor2[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<AffectObjectWhenMelodyPlayedSystem_6B1B63DB_LambdaJob_0_Job>(jobPtr), ref query);
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

		public ComponentTypeHandle<AffectObjectWhenMelodyPlayedCD> __AffectObjectWhenMelodyPlayedCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<TrackedNotesBuffer> __TrackedNotesBuffer_RW_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<MelodiesBuffer> __MelodiesBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClientInput> __ClientInput_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<ItemsToAddToNewObjectBuffer> __ItemsToAddToNewObjectBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__AffectObjectWhenMelodyPlayedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AffectObjectWhenMelodyPlayedCD>();
			__TrackedNotesBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<TrackedNotesBuffer>();
			__MelodiesBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<MelodiesBuffer>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__PlayerState_PlayerStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			__ClientInput_RO_ComponentLookup = state.GetComponentLookup<ClientInput>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__DamageReductionCD_RO_ComponentLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
			__ItemsToAddToNewObjectBuffer_RO_BufferLookup = state.GetBufferLookup<ItemsToAddToNewObjectBuffer>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		}
	}

	private EntityQuery _playerQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1643736550_0;

	private EntityQuery __query_1643736550_1;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedDatabase();
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			ComponentType.ReadOnly<PlayerGhost>(),
			ComponentType.ReadOnly<LocalTransform>()
		};
		entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadOnly<DisablePhysicsCD>() };
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		_playerQuery = GetEntityQuery(entityQueryDesc2);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NativeArray<Entity> playerEntities = _playerQuery.ToEntityArray(Allocator.Temp);
		EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		BufferLookup<ItemsToAddToNewObjectBuffer> addItemsBufferLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ItemsToAddToNewObjectBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<ContainedObjectsBuffer> containedItemsBufferLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		__query_1643736550_1.TryGetSingleton<NetworkTime>(out var _);
		AffectObjectWhenMelodyPlayedSystem_6B1B63DB_LambdaJob_0_Execute(ref playerEntities, ref ecb, ref databaseLocal, ref addItemsBufferLookUp, ref containedItemsBufferLookUp);
		ecb.Playback(base.EntityManager);
		ecb.Dispose();
		base.OnUpdate();
	}

	private void AffectObjectWhenMelodyPlayedSystem_6B1B63DB_LambdaJob_0_Execute(ref NativeArray<Entity> playerEntities, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref BufferLookup<ItemsToAddToNewObjectBuffer> addItemsBufferLookUp, ref BufferLookup<ContainedObjectsBuffer> containedItemsBufferLookUp)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AffectObjectWhenMelodyPlayedCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TrackedNotesBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MelodiesBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClientInput_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DamageReductionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		AffectObjectWhenMelodyPlayedSystem_6B1B63DB_LambdaJob_0_Job value = new AffectObjectWhenMelodyPlayedSystem_6B1B63DB_LambdaJob_0_Job
		{
			__this = this,
			playerEntities = playerEntities,
			ecb = ecb,
			databaseLocal = databaseLocal,
			addItemsBufferLookUp = addItemsBufferLookUp,
			containedItemsBufferLookUp = containedItemsBufferLookUp,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__aCDTypeHandle = __TypeHandle.__AffectObjectWhenMelodyPlayedCD_RW_ComponentTypeHandle,
			__trackedNotesTypeHandle = __TypeHandle.__TrackedNotesBuffer_RW_BufferTypeHandle,
			__melodyBufferTypeHandle = __TypeHandle.__MelodiesBuffer_RO_BufferTypeHandle,
			__objectDataCDTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__PlayerState_PlayerStateCD_ComponentLookup = __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup,
			__ClientInput_ComponentLookup = __TypeHandle.__ClientInput_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup,
			__DamageReductionCD_ComponentLookup = __TypeHandle.__DamageReductionCD_RO_ComponentLookup
		};
		if (!__query_1643736550_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			AffectObjectWhenMelodyPlayedSystem_6B1B63DB_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1643736550_0, jobPtr);
		}
		playerEntities = value.playerEntities;
		ecb = value.ecb;
		databaseLocal = value.databaseLocal;
		addItemsBufferLookUp = value.addItemsBufferLookUp;
		containedItemsBufferLookUp = value.containedItemsBufferLookUp;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MelodiesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AffectObjectWhenMelodyPlayedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TrackedNotesBuffer>();
		_queryRequiredForUpdate = (__query_1643736550_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1643736550_1 = entityQueryBuilder2.Build(ref state);
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
	public AffectObjectWhenMelodyPlayedSystem()
	{
	}
}
