using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[UpdateAfter(typeof(WorldInfoSystem))]
public class MerchantBuyInventorySystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct MerchantBuyInventorySystem_D9B2F6A_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00002343_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00002343_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00002343_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public WorldInfoCD worldInfo;

		public bool worldInfoChanged;

		public Unity.Mathematics.Random rng;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public int updateEveryLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<MerchantCD> __merchantCDTypeHandle;

		public BufferTypeHandle<ContainedObjectsBuffer> __inventoryBufferTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public BufferTypeHandle<MerchantItemInfoBuffer> __itemInfosTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref MerchantCD merchantCD, DynamicBuffer<ContainedObjectsBuffer> inventoryBuffer, [NoAlias] ref ObjectDataCD objectData, [NoAlias] in StateInfoCD stateInfo, DynamicBuffer<MerchantItemInfoBuffer> itemInfos)
		{
			objectData.amount -= updateEveryLocal;
			bool flag = worldInfoChanged;
			if (!flag)
			{
				for (int i = 0; i < itemInfos.Length; i++)
				{
					if (inventoryBuffer.Length > i && inventoryBuffer[i].objectData.objectID != ObjectID.None && ItemIsAvailable(worldInfo, itemInfos[i].requirementToBeAvailable) && itemInfos[i].objectID != inventoryBuffer[i].objectData.objectID)
					{
						flag = true;
						break;
					}
				}
			}
			if (!(objectData.amount < 1 || flag))
			{
				return;
			}
			objectData.amount = rng.NextInt(1500, 2100);
			int j = 0;
			int num = 0;
			for (int k = 0; k < inventoryBuffer.Length; k++)
			{
				ObjectID objectID = ObjectID.None;
				int num2 = 0;
				for (; j < itemInfos.Length; j++)
				{
					if (itemInfos[j].amount != 0 && ItemIsAvailable(worldInfo, itemInfos[j].requirementToBeAvailable))
					{
						objectID = itemInfos[j].objectID;
						num2 = itemInfos[j].amount;
						j++;
						break;
					}
				}
				if (PugDatabase.HasObject(objectID, databaseLocal))
				{
					if (num2 == 1)
					{
						num2 = PugDatabase.GetEntityObjectInfo(objectID, databaseLocal).initialAmount;
					}
					inventoryBuffer[k] = new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = objectID,
							amount = num2
						}
					};
					num++;
				}
				else
				{
					inventoryBuffer[k] = new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = ObjectID.None,
							amount = 0
						}
					};
				}
			}
			if (worldInfoChanged && num > merchantCD.previousAmountOfItems)
			{
				merchantCD.hasNewItems = true;
			}
			merchantCD.previousAmountOfItems = num;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __merchantCDTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __inventoryBufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __objectDataTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __stateInfoTypeHandle);
			BufferAccessor<MerchantItemInfoBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __itemInfosTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MerchantCD>(nativeArrayPtr2, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, i), bufferAccessor2[i]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MerchantCD>(nativeArrayPtr2, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, j), bufferAccessor2[j]);
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MerchantCD>(nativeArrayPtr2, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, k), bufferAccessor2[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MerchantCD>(nativeArrayPtr2, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, l), bufferAccessor2[l]);
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00002343_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00002343_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<MerchantBuyInventorySystem_D9B2F6A_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<MerchantCD> __MerchantCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<MerchantItemInfoBuffer> __MerchantItemInfoBuffer_RO_BufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__MerchantCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MerchantCD>();
			__ContainedObjectsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>();
			__ObjectDataCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>();
			__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
			__MerchantItemInfoBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<MerchantItemInfoBuffer>(isReadOnly: true);
		}
	}

	private const int updateEvery = 4;

	private const int MIN_TIME_BEFORE_REFRESH = 1500;

	private const int MAX_TIME_BEFORE_REFRESH = 2100;

	private WorldInfoCD prevWorldInfo;

	private float accumulationTimer;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_721844794_0;

	private EntityQuery __query_721844794_1;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedDatabase();
		RequireForUpdate<WorldInfoCD>();
		accumulationTimer = 4f;
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		prevWorldInfo = __query_721844794_1.GetSingleton<WorldInfoCD>();
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		accumulationTimer -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (accumulationTimer > 0f)
		{
			base.OnUpdate();
			return;
		}
		accumulationTimer = 4f;
		WorldInfoCD worldInfo = __query_721844794_1.GetSingleton<WorldInfoCD>();
		bool worldInfoChanged = worldInfo.larvaBossStatueIsActivated != prevWorldInfo.larvaBossStatueIsActivated || worldInfo.hiveBossStatueIsActivated != prevWorldInfo.hiveBossStatueIsActivated || worldInfo.coreIsActivated != prevWorldInfo.coreIsActivated || worldInfo.coreBossHasBeenKilled != prevWorldInfo.coreBossHasBeenKilled;
		prevWorldInfo = worldInfo;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		int updateEveryLocal = 4;
		MerchantBuyInventorySystem_D9B2F6A_LambdaJob_0_Execute(ref worldInfo, ref worldInfoChanged, ref rng, ref databaseLocal, ref updateEveryLocal);
		base.OnUpdate();
	}

	private static bool ItemIsAvailable(WorldInfoCD worldInfo, MerchantItemRequirement requirement)
	{
		return requirement switch
		{
			MerchantItemRequirement.None => true, 
			MerchantItemRequirement.HiveBossStatueActivated => worldInfo.hiveBossStatueIsActivated, 
			MerchantItemRequirement.LarvaBossStatueActivated => worldInfo.larvaBossStatueIsActivated, 
			MerchantItemRequirement.CoreActivated => worldInfo.coreIsActivated, 
			MerchantItemRequirement.CoreBossDefeated => worldInfo.coreBossHasBeenKilled, 
			_ => false, 
		};
	}

	private void MerchantBuyInventorySystem_D9B2F6A_LambdaJob_0_Execute(ref WorldInfoCD worldInfo, ref bool worldInfoChanged, ref Unity.Mathematics.Random rng, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref int updateEveryLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MerchantCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ContainedObjectsBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MerchantItemInfoBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		MerchantBuyInventorySystem_D9B2F6A_LambdaJob_0_Job value = new MerchantBuyInventorySystem_D9B2F6A_LambdaJob_0_Job
		{
			worldInfo = worldInfo,
			worldInfoChanged = worldInfoChanged,
			rng = rng,
			databaseLocal = databaseLocal,
			updateEveryLocal = updateEveryLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__merchantCDTypeHandle = __TypeHandle.__MerchantCD_RW_ComponentTypeHandle,
			__inventoryBufferTypeHandle = __TypeHandle.__ContainedObjectsBuffer_RW_BufferTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle,
			__itemInfosTypeHandle = __TypeHandle.__MerchantItemInfoBuffer_RO_BufferTypeHandle
		};
		if (!__query_721844794_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			MerchantBuyInventorySystem_D9B2F6A_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_721844794_0, jobPtr);
		}
		worldInfo = value.worldInfo;
		worldInfoChanged = value.worldInfoChanged;
		rng = value.rng;
		databaseLocal = value.databaseLocal;
		updateEveryLocal = value.updateEveryLocal;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<MerchantItemInfoBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MerchantCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_721844794_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_721844794_1 = entityQueryBuilder2.Build(ref state);
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
	public MerchantBuyInventorySystem()
	{
	}
}
