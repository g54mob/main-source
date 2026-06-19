using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using PlayerState;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class MimicPlayerInstrumentNotesSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct MimicPlayerInstrumentNotesSystem_340834B8_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_0000234E_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_0000234E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_0000234E_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		[ReadOnly]
		public NativeArray<Entity> playerEntities;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<MimicPlayerInstrumentNotesCD> __aCDTypeHandle;

		public BufferTypeHandle<TrackedNotesBuffer> __trackedNotesTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __objectDataCDTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClientInput> __ClientInput_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref MimicPlayerInstrumentNotesCD aCD, DynamicBuffer<TrackedNotesBuffer> trackedNotes, [NoAlias] in ObjectDataCD objectDataCD)
		{
			float hearRange = aCD.hearRange;
			float3 position = __Unity_Transforms_LocalTransform_ComponentLookup[entity].Position;
			aCD.playerHoldingInstrumentExists = false;
			for (int i = 0; i < playerEntities.Length; i++)
			{
				Entity entity2 = playerEntities[i];
				float3 position2 = __Unity_Transforms_LocalTransform_ComponentLookup[entity2].Position;
				float3 y = PugDatabase.GetEntityLocalCenter(objectDataCD.objectID, databaseLocal, objectDataCD.variation) + position;
				if (!(math.distance(position2, y) <= hearRange) || !__PlayerState_PlayerStateCD_ComponentLookup.HasComponent(entity2) || !__PlayerState_PlayerStateCD_ComponentLookup[entity2].HasAnyState(PlayerStateEnum.PlayingInstrument))
				{
					continue;
				}
				aCD.playerHoldingInstrumentExists = true;
				if (!__ClientInput_ComponentLookup.HasComponent(entity2))
				{
					continue;
				}
				int playedNotes = __ClientInput_ComponentLookup[entity2].playedNotes;
				bool flag = false;
				bool flag2 = false;
				for (int j = 0; j < trackedNotes.Length; j++)
				{
					if (trackedNotes[j].playerEntity == entity2)
					{
						TrackedNotesBuffer value = trackedNotes[j];
						value.notes = playedNotes;
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
						notes = playedNotes
					});
				}
				if (flag)
				{
					aCD.isPlayingNotes = playedNotes != 0;
					if (aCD.isPlayingNotes)
					{
						aCD.pitch = Mathf.Pow(2f, (float)aCD.keyOffset / 12f);
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __aCDTypeHandle);
			BufferAccessor<TrackedNotesBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __trackedNotesTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataCDTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MimicPlayerInstrumentNotesCD>(nativeArrayPtr2, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MimicPlayerInstrumentNotesCD>(nativeArrayPtr2, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MimicPlayerInstrumentNotesCD>(nativeArrayPtr2, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MimicPlayerInstrumentNotesCD>(nativeArrayPtr2, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_0000234E_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_0000234E_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<MimicPlayerInstrumentNotesSystem_340834B8_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<MimicPlayerInstrumentNotesCD> __MimicPlayerInstrumentNotesCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<TrackedNotesBuffer> __TrackedNotesBuffer_RW_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClientInput> __ClientInput_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__MimicPlayerInstrumentNotesCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MimicPlayerInstrumentNotesCD>();
			__TrackedNotesBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<TrackedNotesBuffer>();
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__PlayerState_PlayerStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			__ClientInput_RO_ComponentLookup = state.GetComponentLookup<ClientInput>(isReadOnly: true);
		}
	}

	private EntityQuery _playerQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_306538985_0;

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
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		MimicPlayerInstrumentNotesSystem_340834B8_LambdaJob_0_Execute(ref playerEntities, ref databaseLocal);
		entityCommandBuffer.Playback(base.EntityManager);
		entityCommandBuffer.Dispose();
		base.OnUpdate();
	}

	private void MimicPlayerInstrumentNotesSystem_340834B8_LambdaJob_0_Execute(ref NativeArray<Entity> playerEntities, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MimicPlayerInstrumentNotesCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TrackedNotesBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClientInput_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		MimicPlayerInstrumentNotesSystem_340834B8_LambdaJob_0_Job value = new MimicPlayerInstrumentNotesSystem_340834B8_LambdaJob_0_Job
		{
			playerEntities = playerEntities,
			databaseLocal = databaseLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__aCDTypeHandle = __TypeHandle.__MimicPlayerInstrumentNotesCD_RW_ComponentTypeHandle,
			__trackedNotesTypeHandle = __TypeHandle.__TrackedNotesBuffer_RW_BufferTypeHandle,
			__objectDataCDTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__PlayerState_PlayerStateCD_ComponentLookup = __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup,
			__ClientInput_ComponentLookup = __TypeHandle.__ClientInput_RO_ComponentLookup
		};
		if (!__query_306538985_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			MimicPlayerInstrumentNotesSystem_340834B8_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_306538985_0, jobPtr);
		}
		playerEntities = value.playerEntities;
		databaseLocal = value.databaseLocal;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MimicPlayerInstrumentNotesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TrackedNotesBuffer>();
		_queryRequiredForUpdate = (__query_306538985_0 = entityQueryBuilder2.Build(ref state));
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
	public MimicPlayerInstrumentNotesSystem()
	{
	}
}
